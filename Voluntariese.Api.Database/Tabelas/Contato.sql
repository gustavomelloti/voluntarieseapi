﻿CREATE TABLE [dbo].[Contato]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] VARCHAR(100) NOT NULL, 
    [Email] VARCHAR(150) NOT NULL, 
    [Telefone] VARCHAR(20) NOT NULL, 
    [Mensagem] VARCHAR(MAX) NOT NULL, 
    [DataCriacao] DATETIME NOT NULL,
)
