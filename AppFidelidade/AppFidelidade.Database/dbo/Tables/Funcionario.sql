CREATE TABLE [dbo].[Funcionario] (
    [FuncionarioId]     INT           IDENTITY (1, 1) NOT NULL,
    [EstabelecimentoId] INT           NOT NULL,
    [Nome]              VARCHAR (100) NOT NULL,
    [Login]             VARCHAR (20)  NOT NULL,
    [Senha]             VARCHAR (100) NOT NULL,
    [Administrador]     BIT           NOT NULL,
    [Status]            INT           NOT NULL,
    [DataCadastro]      DATETIME      NOT NULL,
    CONSTRAINT [PK_Funcionario] PRIMARY KEY CLUSTERED ([FuncionarioId] ASC),
    CONSTRAINT [FK_Funcionario_Estabelecimento] FOREIGN KEY ([EstabelecimentoId]) REFERENCES [dbo].[Estabelecimento] ([EstabelecimentoId])
);

