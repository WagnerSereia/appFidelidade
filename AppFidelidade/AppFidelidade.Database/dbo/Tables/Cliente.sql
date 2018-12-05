CREATE TABLE [dbo].[Cliente] (
    [ClienteId]         INT            IDENTITY (1, 1) NOT NULL,
    [EstabelecimentoId] INT            NOT NULL,
    [Favorito]          BIT            NOT NULL,
    [UsuarioId]         NVARCHAR (128) NULL,
    [Status]            INT            NOT NULL,
    [DataCadastro]      DATETIME       NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED ([ClienteId] ASC),
    CONSTRAINT [FK_Cliente_Estabelecimento] FOREIGN KEY ([EstabelecimentoId]) REFERENCES [dbo].[Estabelecimento] ([EstabelecimentoId]),
    CONSTRAINT [FK_Cliente_Usuario] FOREIGN KEY ([UsuarioId]) REFERENCES [dbo].[Usuario] ([UsuarioId])
);

