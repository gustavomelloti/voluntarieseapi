CREATE TABLE [dbo].[Oportunidade]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Descricao] VARCHAR(500) NOT NULL, 
    [DataCriacao] DATETIME NOT NULL, 
    [DataAtualizacao] DATETIME NULL, 
    [Ativa] BIT NOT NULL DEFAULT 1, 
    [IdCausa] BIGINT NOT NULL, 
    [Turno] VARCHAR(300) NOT NULL, 
    [QuantidadeVagas] INT NOT NULL, 
    [IdInstituicao] BIGINT NOT NULL, 
    [Qualificacoes] VARCHAR(500) NULL, 
    CONSTRAINT [FK_Oportunidade_Causa] FOREIGN KEY ([IdCausa]) REFERENCES [Causa]([Id]),
	CONSTRAINT [FK_Oportunidade_Instituicao] FOREIGN KEY ([IdInstituicao]) REFERENCES [Usuario]([Id])
)
