CREATE TABLE [dbo].[TokenRecuperacaoSenha]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[IdUsuario] BIGINT NOT NULL,
    [Token] VARCHAR(2000) NOT NULL, 
    [DataValidade] DATETIME NOT NULL, 
    [DataUtilizacao] DATETIME NULL, 
    [DataCriacao] DATETIME NOT NULL,
	CONSTRAINT [FK_TokenRecuperacaoSenha_Usuario] FOREIGN KEY (IdUsuario) REFERENCES [Usuario]([Id])
)
