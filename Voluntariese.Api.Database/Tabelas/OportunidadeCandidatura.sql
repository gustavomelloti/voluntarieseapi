CREATE TABLE [dbo].[OportunidadeCandidatura]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [IdOportunidade] BIGINT NOT NULL, 
    [IdVoluntario] BIGINT NOT NULL, 
    [DataCriacao] DATETIME NOT NULL, 
    [Aprovada] BIT NULL DEFAULT 0, 
    [DataAtualizacao] DATETIME NULL, 
    [Justificativa] VARCHAR(250) NULL, 
    CONSTRAINT [FK_OportunidadeCandidatura_Oportunidade] FOREIGN KEY ([IdOportunidade]) REFERENCES [Oportunidade]([Id]),
	CONSTRAINT [FK_OportunidadeCandidatura_Voluntario] FOREIGN KEY ([IdVoluntario]) REFERENCES [Usuario]([Id])
)
