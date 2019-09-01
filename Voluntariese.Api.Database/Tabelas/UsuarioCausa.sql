CREATE TABLE [dbo].[UsuarioCausa]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [IdUsuario] BIGINT NOT NULL, 
    [IdCausa] BIGINT NOT NULL, 
    CONSTRAINT [FK_UsuarioCausa_Usuario] FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id),
	CONSTRAINT [FK_UsuarioCausa_Causa] FOREIGN KEY (IdCausa) REFERENCES Causa(Id)
	
)
