CREATE TABLE [dbo].[Endereco]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY,
	[Cep] INT NOT NULL, 
    [Estado] VARCHAR(50) NOT NULL, 
    [Cidade] VARCHAR(80) NOT NULL, 
    [Bairro] VARCHAR(80) NOT NULL, 
    [Logradouro] VARCHAR(250) NOT NULL, 
    [Numero] VARCHAR(10) NULL, 
    [Complemento] VARCHAR(255) NULL 
)
