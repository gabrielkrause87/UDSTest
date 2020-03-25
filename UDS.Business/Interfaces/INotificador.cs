using System;
using System.Collections.Generic;
using System.Text;
using UDS.Business.Notificacoes;

namespace UDS.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
