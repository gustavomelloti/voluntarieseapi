﻿CREATE TABLE [dbo].[Usuario]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] VARCHAR(100) NOT NULL, 
    [Email] VARCHAR(50) NOT NULL UNIQUE, 
    [Senha] VARCHAR(500) NOT NULL,   
    [Telefone] VARCHAR(20) NOT NULL, 
	[IdPerfil] BIGINT NOT NULL,
    [IdFotoPerfil] BIGINT NULL, 
	[IdEndereco] BIGINT NOT NULL, 
	[DataCriacao] DATETIME NOT NULL,
	[DataAtualizacao] DATETIME NULL, 
    [Ativo] BIT NOT NULL DEFAULT 1, 
    [DataNascimento] DATE NULL, 
    [Sexo] CHAR NULL, 
    [Descricao] VARCHAR(500) NULL, 
    [Qualificacoes] VARCHAR(250) NULL, 
    CONSTRAINT [FK_Usuario_Arquivo] FOREIGN KEY (IdFotoPerfil) REFERENCES Arquivo(Id),
    CONSTRAINT [FK_Usuario_Endereco] FOREIGN KEY ([IdEndereco]) REFERENCES [Endereco]([Id]),
	CONSTRAINT [FK_Usuario_PerfilUsuario] FOREIGN KEY ([IdPerfil]) REFERENCES [PerfilUsuario]([Id]),
)