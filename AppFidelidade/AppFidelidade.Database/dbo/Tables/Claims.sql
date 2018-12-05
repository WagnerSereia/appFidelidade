CREATE TABLE [dbo].[Claims] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [UserId]          NVARCHAR (MAX) NULL,
    [ClaimType]       NVARCHAR (MAX) NULL,
    [ClaimValue]      NVARCHAR (MAX) NULL,
    [IdentityUser_Id] NVARCHAR (128) NULL,
    CONSTRAINT [PK_dbo.Claims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Claims_dbo.Usuario_IdentityUser_Id] FOREIGN KEY ([IdentityUser_Id]) REFERENCES [dbo].[Usuario] ([UsuarioId])
);


GO
CREATE NONCLUSTERED INDEX [IX_IdentityUser_Id]
    ON [dbo].[Claims]([IdentityUser_Id] ASC);

