CREATE TABLE [dbo].[Doacao]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Descricao] VARCHAR(500) NULL, 
    [IdInstituicao] BIGINT NOT NULL, 
    [DataCadastro] DATETIME NOT NULL, 
    [Ativa] BIT NOT NULL DEFAULT 1, 
    [DataAtualizacao] DATETIME NULL, 
    CONSTRAINT [FK_Doacao_Instituicao] FOREIGN KEY ([IdInstituicao]) REFERENCES [Usuario]([Id])
)
