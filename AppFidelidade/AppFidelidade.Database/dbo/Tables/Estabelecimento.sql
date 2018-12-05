CREATE TABLE [dbo].[Estabelecimento] (
    [EstabelecimentoId] INT             IDENTITY (1, 1) NOT NULL,
    [Nome]              VARCHAR (100)   NOT NULL,
    [Sobre]             VARCHAR (500)   NOT NULL,
    [Foto]              VARBINARY (MAX) NOT NULL,
    [Status]            INT             NOT NULL,
    [DataCadastro]      DATETIME        NOT NULL,
    CONSTRAINT [PK_Estabelecimento] PRIMARY KEY CLUSTERED ([EstabelecimentoId] ASC)
);

