# UDSApiPublic
Teste aplicação UDS

Ao executar a aplicação via F5, o endereço será esse: https://localhost:44324/swagger/index.html

A instancia do banco é padrão, caso seja uma instancia diferente,alterar no arquivo appsettings.Development.json

Para criar estrutura de banco, efetuar o migration no nps, o banco precisa estar criado (UDSApi):
> add-migration initial

> update-database

Após estrutura criada efetuar o cadastramento dos tamanhos, sabores e personalizações:
> Pode ser via t-sql ou via Api

#--SABORES:
>INSERT INTO Sabores (Descricao,TempoPreparo,Valor,Ativo) values ('Morango',0,0,1)

>INSERT INTO Sabores (Descricao,TempoPreparo,Valor,Ativo) values ('Banana',0,0,1)

>INSERT INTO Sabores (Descricao,TempoPreparo,Valor,Ativo) values ('Kiwi',5,0,1)

#--TAMANHOS:

>INSERT INTO Tamanhos (Descricao,Volume,TempoPreparo,Valor,Ativo) values ('Pequeno (300ml)',300,5,10,1)

>INSERT INTO Tamanhos (Descricao,Volume,TempoPreparo,Valor,Ativo) values ('Medio (500ml)',500,7,13,1)

>INSERT INTO Tamanhos (Descricao,Volume,TempoPreparo,Valor,Ativo) values ('Grande (700ml)',700,10,15,1)

#--PERSONALIZACOES:

>INSERT INTO Personalizacoes (Descricao,TempoPreparo,Valor,Ativo) values ('Granola',0,0,1)

>INSERT INTO Personalizacoes (Descricao,TempoPreparo,Valor,Ativo) values ('Paçoca',3,3,1)

>INSERT INTO Personalizacoes (Descricao,TempoPreparo,Valor,Ativo) values ('Leite ninho',0,3,1)
