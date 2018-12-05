CREATE TABLE [dbo].[Usuario] (
    [UsuarioId]            NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    [Status]               BIT            NULL,
    [DataCadastro]         DATETIME       NULL,
    [Discriminator]        NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.Usuario] PRIMARY KEY CLUSTERED ([UsuarioId] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[Usuario]([UserName] ASC);

