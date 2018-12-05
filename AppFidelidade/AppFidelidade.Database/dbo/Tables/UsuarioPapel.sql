CREATE TABLE [dbo].[UsuarioPapel] (
    [UserId]          NVARCHAR (128) NOT NULL,
    [RoleId]          NVARCHAR (128) NOT NULL,
    [IdentityUser_Id] NVARCHAR (128) NULL,
    CONSTRAINT [PK_dbo.UsuarioPapel] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_dbo.UsuarioPapel_dbo.Papeis_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Papeis] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.UsuarioPapel_dbo.Usuario_IdentityUser_Id] FOREIGN KEY ([IdentityUser_Id]) REFERENCES [dbo].[Usuario] ([UsuarioId])
);


GO
CREATE NONCLUSTERED INDEX [IX_IdentityUser_Id]
    ON [dbo].[UsuarioPapel]([IdentityUser_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RoleId]
    ON [dbo].[UsuarioPapel]([RoleId] ASC);

