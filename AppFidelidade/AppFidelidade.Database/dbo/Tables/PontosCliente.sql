CREATE TABLE [dbo].[PontosCliente] (
    [PontoId]             INT IDENTITY (1, 1) NOT NULL,
    [ClienteId]           INT NOT NULL,
    [PromocaoId]          INT NOT NULL,
    [qtdPontosAcumulados] INT NOT NULL,
    CONSTRAINT [PK_PontosCliente] PRIMARY KEY CLUSTERED ([PontoId] ASC)
);

