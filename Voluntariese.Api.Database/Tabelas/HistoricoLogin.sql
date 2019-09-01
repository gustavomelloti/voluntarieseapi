CREATE TABLE [dbo].[HistoricoLogin]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY,
	[IdUsuario] BIGINT NOT NULL,
	[EnderecoIp] VARCHAR(20),
	[TokenAutenticacao] VARCHAR(2000),
	[DataCriacao] DATETIME NOT NULL, 
    CONSTRAINT [FK_HistoricoLogin_Usuario] FOREIGN KEY (IdUsuario) REFERENCES [Usuario]([Id])
)
