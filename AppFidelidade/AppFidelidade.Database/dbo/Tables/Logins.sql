CREATE TABLE [dbo].[Logins] (
    [LoginProvider]   NVARCHAR (128) NOT NULL,
    [ProviderKey]     NVARCHAR (128) NOT NULL,
    [UserId]          NVARCHAR (128) NOT NULL,
    [IdentityUser_Id] NVARCHAR (128) NULL,
    CONSTRAINT [PK_dbo.Logins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC, [UserId] ASC),
    CONSTRAINT [FK_dbo.Logins_dbo.Usuario_IdentityUser_Id] FOREIGN KEY ([IdentityUser_Id]) REFERENCES [dbo].[Usuario] ([UsuarioId])
);


GO
CREATE NONCLUSTERED INDEX [IX_IdentityUser_Id]
    ON [dbo].[Logins]([IdentityUser_Id] ASC);

