CREATE TABLE Persona (
    IdPersona int IDENTITY (1,1) NOT NULL
      , CONSTRAINT PK_IdPersona PRIMARY KEY CLUSTERED (IdPersona),
    Cuit varchar(11) NOT NULL,
    RazonSocial varchar(100) null default '',
	FechaAlta datetime default getdate()
);

CREATE TABLE SujetoObligado (
    IdSujetoObligado int IDENTITY (1,1) NOT NULL,
      CONSTRAINT PK_SujetoObligado PRIMARY KEY CLUSTERED (IdSujetoObligado),
	IdPersona int,
	  CONSTRAINT FK_Persona
		FOREIGN KEY (IdPersona)
		REFERENCES Persona,
    Tipo varchar(255) NOT NULL,
    Estado bit NOT NULL,
	Mensaje varchar(255) NOT NULL,
	FechaCreacion datetime NOT NULL,
	FechaModificacion datetime NOT NULL,
	FechaAlta datetime default getdate()
);


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ariel Vergara
-- Create date: 20-03-2020
-- Description:	Agrega registro a la tabla Persona
-- =============================================
CREATE PROCEDURE Qry_Persona_ADD
	
	@Cuit varchar(11),
	@RazonSocial varchar(100) = ''

AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Persona]
           ([Cuit]
           ,[RazonSocial]
           ,[FechaAlta])
     OUTPUT Inserted.IdPersona
     VALUES
           (@Cuit
           ,@RazonSocial
           ,GETDATE())
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ariel Vergara
-- Create date: 20-03-2020
-- Description:	Agrega registro a la tabla SujetoObligado
-- =============================================
CREATE PROCEDURE Qry_SujetoObligado_ADD
	@IdPersona int,
	@Tipo varchar(255), 
	@Estado bit,
	@Mensaje varchar(255),
	@FechaCreacion datetime
AS
BEGIN
	
	SET NOCOUNT ON;

    INSERT INTO [dbo].[SujetoObligado]
           ([IdPersona]
           ,[Tipo]
           ,[Estado]
           ,[Mensaje]
           ,[FechaCreacion]
           ,[FechaModificacion]
           ,[FechaAlta])
     VALUES
           (@IdPersona
           ,@Tipo
           ,@Estado
           ,@Mensaje
           ,@FechaCreacion
           ,GETDATE()
           ,GETDATE())
END
GO
