using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDS.Business.DTOs;
using UDS.Business.Interfaces;
using UDS.Business.Interfaces.Repositories;
using UDS.Business.Interfaces.Services;
using UDS.Business.Model;

namespace UDS.Business.Services
{
    public class PedidosService : BaseService, IPedidosService
    {
        private readonly IPedidosRepository _pedidos;
        private readonly ITamanhosRepository _tamanhos;
        private readonly ISaboresRepository _sabores;
        private readonly IPersonalizacoesRepository _personalizacoes;
        private readonly IPedidosPersonalizacoesRepository _pedidoPersonalizacoes;
        private readonly INotificador _notificador;

        public PedidosService(IPedidosRepository pedidos, ITamanhosRepository tamanhos, ISaboresRepository sabores,
            IPersonalizacoesRepository personalizacoes,
            IPedidosPersonalizacoesRepository pedidoPersonalizacoes,
            INotificador notificador) : base(notificador)
        {
            _pedidos = pedidos;
            _tamanhos = tamanhos;
            _sabores = sabores;
            _personalizacoes = personalizacoes;
            _pedidoPersonalizacoes = pedidoPersonalizacoes;
            _notificador = notificador;
        }

        public async Task<DTOPedidosResultado> Adicionar(DTOPedidos pedido)
        {
            //Objeto tamanho
            var tamanho = await _tamanhos.ObterPorId(pedido.Tamanho);
            //Objeto sabores
            var sabor = await _sabores.ObterPorId(pedido.Sabor);

            if (tamanho == null)
            {
                Notificar($"Tamanho {pedido.Tamanho} não localizado.");
            }
            if (sabor == null)
            {
                Notificar($"Sabor {pedido.Sabor} não localizado.");
            }

            if (_notificador.TemNotificacao())
            {
                return null;
            }
            //Objeto pedido
            var objPedido = new Pedidos
            {
                Cliente = string.Empty,
                DtPedido = DateTime.Now,
                SaboresId = sabor.Id,
                TempoSabor = sabor.TempoPreparo,
                ValorSabor = sabor.Valor,
                TamanhosId = tamanho.Id,
                TempoTamanho = tamanho.TempoPreparo,
                ValorTamanho = tamanho.Valor
            };
            var add = await _pedidos.Adicionar(objPedido);
            pedido.Id = add.Id;

            var personalizacoes = new List<DetalhesPersonalizacao>();
            //Adicionar personalizacao
            if (pedido.Personalizacoes.Count > 0)
            {
                personalizacoes = await AdicionarPersonalizacoes(pedido);
            }

            var tam = new DetalhesTamanho
            {
                Descricao = tamanho.Descricao,
                Id = add.Tamanhos.Id,
                TempoPreparo = add.TempoTamanho,
                Valor = add.ValorTamanho
            };
            var sab = new DetalhesSabor
            {
                Descricao = sabor.Descricao,
                Id = add.Sabores.Id,
                TempoPreparo = add.TempoSabor,
                Valor = add.ValorSabor
            };

            var resultado = GerarResultado(tam, sab, personalizacoes);
            resultado.Id = pedido.Id;
            return resultado;
        }

        private DTOPedidosResultado GerarResultado(DetalhesTamanho tamanho, DetalhesSabor sabor, List<DetalhesPersonalizacao> detalhesPersonalizacao = null)
        {
            decimal valorTotal = 0;
            int tempoPreparacao = 0;

            //Soma Valor e tempo
            valorTotal += tamanho.Valor;
            valorTotal += sabor.Valor;
            tempoPreparacao += tamanho.TempoPreparo;
            tempoPreparacao += sabor.TempoPreparo;
            if (detalhesPersonalizacao != null)
            {
                foreach (var item in detalhesPersonalizacao)
                {
                    valorTotal += item.Valor;
                    tempoPreparacao += item.TempoPreparo;
                }
            }

            var resumo = new ResumoAcai
            {
                ValorTotal = valorTotal,
                TempoPreparo = new TimeSpan(0, tempoPreparacao, 0)
            };

            return new DTOPedidosResultado
            {
                Detalhes = new DetalhesAcai
                {
                    Tamanho = tamanho,
                    Sabor = sabor,
                    ListaPersonalizacoes = detalhesPersonalizacao
                },
                Resumo = resumo
            };
        }

        private async Task<List<DetalhesPersonalizacao>> AdicionarPersonalizacoes(DTOPedidos pedido)
        {
            var lstRet = new List<DetalhesPersonalizacao>();
            foreach (var item in pedido.Personalizacoes)
            {
                var obj = await _personalizacoes.ObterPorId(item);
                if (obj == null)
                {
                    Notificar($"Personalização {item} não localizada.");
                }
                else
                {
                    var add = await _pedidoPersonalizacoes.Adicionar(new PedidosPersonalizacoes
                    {
                        PedidosId = pedido.Id,
                        PersonalizacoesId = obj.Id,
                        TempoPersonalizacao = obj.TempoPreparo,
                        ValorPersonalizacao = obj.Valor
                    });
                    var res = new DetalhesPersonalizacao
                    {
                        Id = obj.Id,
                        Descricao = obj.Descricao,
                        TempoPreparo = obj.TempoPreparo,
                        Valor = obj.Valor
                    };
                    lstRet.Add(res);
                }
            }
            return lstRet;
        }

        public async Task<bool> Excluir(int id)
        {
            var persn = await _pedidoPersonalizacoes.Buscar(p => p.PedidosId == id);
            var lstRet = new List<bool>();

            foreach (var item in persn)
            {
                var t = await _pedidoPersonalizacoes.Remover(item.Id);
                lstRet.Add(t);
            }

            var capa = await _pedidos.Remover(id);
            lstRet.Add(capa);
            return !lstRet.Any(p => p == false);
        }

        public async Task<List<DTOPedidosResultado>> ListarTodos()
        {
            var lstRetorno = new List<DTOPedidosResultado>();
            var lstPedidos = await _pedidos.CarregarTodosCompleto();
            foreach (var item in lstPedidos)
            {
                var tamanho = new DetalhesTamanho
                {
                    Id = item.Tamanhos.Id,
                    Descricao = item.Tamanhos.Descricao,
                    TempoPreparo = item.TempoTamanho,
                    Valor = item.ValorTamanho
                };
                var sabor = new DetalhesSabor
                {
                    Id = item.Sabores.Id,
                    Descricao = item.Sabores.Descricao,
                    TempoPreparo = item.TempoSabor,
                    Valor = item.ValorSabor
                };
                var personalizacoes = item.PedidosPersonalizacoes?.ToList();
                var listaPersonalizacoes = new List<DetalhesPersonalizacao>();
                if (personalizacoes.Count > 0)
                {
                    foreach (var itemPersonalizado in personalizacoes)
                    {
                        var personalizacao = new DetalhesPersonalizacao
                        {
                            Id = itemPersonalizado.Id,
                            Descricao = itemPersonalizado.Personalizacoes.Descricao,
                            TempoPreparo = itemPersonalizado.TempoPersonalizacao,
                            Valor = itemPersonalizado.ValorPersonalizacao
                        };
                        listaPersonalizacoes.Add(personalizacao);
                    }
                }
                var resultado = GerarResultado(tamanho, sabor, listaPersonalizacoes);
                resultado.Id = item.Id;
                lstRetorno.Add(resultado);
            }
            return lstRetorno;
        }

        public async Task<DTOPedidosResultado> ObterPorId(int id)
        {
            var item = await _pedidos.CarregarPorIdCompleto(id);
            var tamanho = new DetalhesTamanho
            {
                Id = item.Tamanhos.Id,
                Descricao = item.Tamanhos.Descricao,
                TempoPreparo = item.TempoTamanho,
                Valor = item.ValorTamanho
            };
            var sabor = new DetalhesSabor
            {
                Id = item.Sabores.Id,
                Descricao = item.Sabores.Descricao,
                TempoPreparo = item.TempoSabor,
                Valor = item.ValorSabor
            };
            var personalizacoes = item.PedidosPersonalizacoes?.ToList();
            var listaPersonalizacoes = new List<DetalhesPersonalizacao>();
            if (personalizacoes.Count > 0)
            {
                foreach (var itemPersonalizado in personalizacoes)
                {
                    var personalizacao = new DetalhesPersonalizacao
                    {
                        Id = itemPersonalizado.Id,
                        Descricao = itemPersonalizado.Personalizacoes.Descricao,
                        TempoPreparo = itemPersonalizado.TempoPersonalizacao,
                        Valor = itemPersonalizado.ValorPersonalizacao
                    };
                    listaPersonalizacoes.Add(personalizacao);
                }
            }
            var resultado = GerarResultado(tamanho, sabor, listaPersonalizacoes);
            resultado.Id = item.Id;
            return resultado;
        }
    }
}
