CREATE TABLE [dbo].[Promocao] (
    [PromocaoId]           INT           IDENTITY (1, 1) NOT NULL,
    [EstabelecimentoId]    INT           NOT NULL,
    [Titulo]               VARCHAR (100) NOT NULL,
    [Regulamento]          VARCHAR (MAX) NOT NULL,
    [TotalCarimbo]         INT           NOT NULL,
    [CarimbosAcumulativos] BIT           NOT NULL,
    [DataInicio]           DATETIME      NOT NULL,
    [DataTermino]          DATETIME      NOT NULL,
    [Status]               INT           NOT NULL,
    [DataCadastro]         DATETIME      NOT NULL,
    CONSTRAINT [PK_Promocao] PRIMARY KEY CLUSTERED ([PromocaoId] ASC),
    CONSTRAINT [FK_Promocao_Promocao] FOREIGN KEY ([PromocaoId]) REFERENCES [dbo].[Promocao] ([PromocaoId])
);

