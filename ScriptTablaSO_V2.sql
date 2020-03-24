CREATE TABLE Permiso (
    Id int IDENTITY (1,1) NOT NULL,
      CONSTRAINT PK_IdPermiso PRIMARY KEY CLUSTERED (Id),
	Nombre varchar(255) NOT NULL,
	Descripcion varchar(255) NOT NULL
);

CREATE TABLE Rol (
    Id int IDENTITY (1,1) NOT NULL,
      CONSTRAINT PK_IdRol PRIMARY KEY CLUSTERED (Id),
	Nombre varchar(255) NOT NULL,
	Descripcion varchar(255) NOT NULL
);

CREATE TABLE Usuario (
    Id int IDENTITY (1,1) NOT NULL,
      CONSTRAINT PK_IdUsuario PRIMARY KEY CLUSTERED (Id),
	Nombre varchar(100) NOT NULL,
	Email varchar(255) NOT NULL,
	Contrasenia varchar(255) NOT NULL
);

CREATE TABLE PermisoxRol (
    Id int IDENTITY (1,1) NOT NULL,
      CONSTRAINT PK_IdPermisoxRol PRIMARY KEY CLUSTERED (Id),
	IdPermiso int,
	  CONSTRAINT FK_Permiso_PermisoxRol
		FOREIGN KEY (IdPermiso)
		REFERENCES Permiso,
	IdRol int,
	  CONSTRAINT FK_Rol_PermisoxRol
		FOREIGN KEY (IdRol)
		REFERENCES Rol,
);

CREATE TABLE RolxUsuario (
    Id int IDENTITY (1,1) NOT NULL,
      CONSTRAINT PK_IdRolxUsuario PRIMARY KEY CLUSTERED (Id),
	IdUsuario int,
	  CONSTRAINT FK_Usuario_RolxUsuario
		FOREIGN KEY (IdUsuario)
		REFERENCES Usuario,
	IdRol int,
	  CONSTRAINT FK_Rol_RolxUsuario
		FOREIGN KEY (IdRol)
		REFERENCES Rol,
);

CREATE TABLE Persona (
    Id int IDENTITY (1,1) NOT NULL
      , CONSTRAINT PK_IdPersona PRIMARY KEY CLUSTERED (Id),
	IdUsuario int,
	  CONSTRAINT FK_Usuario_Persona
		FOREIGN KEY (IdUsuario)
		REFERENCES Usuario,
    Cuit varchar(11) NOT NULL,
    RazonSocial varchar(100) null default '',
	FechaAlta datetime default getdate()
);

CREATE TABLE SujetoObligado (
    IdSujetoObligado int IDENTITY (1,1) NOT NULL,
      CONSTRAINT PK_SujetoObligado PRIMARY KEY CLUSTERED (IdSujetoObligado),
	IdPersona int,
	  CONSTRAINT FK_Persona_SujetoObligado
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
	@IdUsuario int,
	@Cuit varchar(11),
	@RazonSocial varchar(100) = ''

AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Persona]
           ([IdUsuario]
		   ,[Cuit]
           ,[RazonSocial]
           ,[FechaAlta])
     OUTPUT Inserted.Id
     VALUES
           (@IdUsuario
		   ,@Cuit
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

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ariel Vergara
-- Create date: 23-03-2020
-- Description:	Lista las busquedas que realiz� un determinado usuario
-- =============================================
CREATE PROCEDURE Qry_SujetoObligado_SEEK
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT P.Cuit, SO.Tipo, SO.Mensaje, SO.Estado
	FROM Persona P 
	INNER JOIN SujetoObligado SO ON (P.Id = SO.IdPersona)
	WHERE IdUsuario = @IdUsuario
	ORDER BY P.Id, SO.IdSujetoObligado
END
GO


--ROL
INSERT INTO [dbo].[Rol]([Nombre],[Descripcion]) VALUES ('Administrador','Acceso total al sistema') 
INSERT INTO [dbo].[Rol]([Nombre],[Descripcion]) VALUES ('Desarrollador','Acceso total al sistema') 
INSERT INTO [dbo].[Rol]([Nombre],[Descripcion]) VALUES ('Premium','Usuario con acceso total a las herramientas del sistema') 
INSERT INTO [dbo].[Rol]([Nombre],[Descripcion]) VALUES ('Com�n','Usuario con acceso limitado a las herramientas del sistema') 

--PERMISO
INSERT INTO [dbo].[Permiso] ([Nombre],[Descripcion]) VALUES ('Consulta','Consulta com�n de sujeto obligado')
INSERT INTO [dbo].[Permiso] ([Nombre],[Descripcion]) VALUES ('Consulta masiva','Consulta masiva de sujeto obligado')
INSERT INTO [dbo].[Permiso] ([Nombre],[Descripcion]) VALUES ('Consulta masiva limitada','Consulta masiva limitada de sujetos obligados')
INSERT INTO [dbo].[Permiso] ([Nombre],[Descripcion]) VALUES ('Subscripci�n','Suscripci�n a personas registradas ante la UIF')
INSERT INTO [dbo].[Permiso] ([Nombre],[Descripcion]) VALUES ('Subscripci�n limitada','Suscripci�n limitada a personas registradas ante la UIF')

--PERMISO POR ROL
INSERT INTO [dbo].[PermisoxRol] ([IdPermiso],[IdRol]) VALUES (1,3)
INSERT INTO [dbo].[PermisoxRol] ([IdPermiso],[IdRol]) VALUES (2,3)
INSERT INTO [dbo].[PermisoxRol] ([IdPermiso],[IdRol]) VALUES (4,3)

INSERT INTO [dbo].[PermisoxRol] ([IdPermiso],[IdRol]) VALUES (3,4)
INSERT INTO [dbo].[PermisoxRol] ([IdPermiso],[IdRol]) VALUES (5,4)

--USUARIO

INSERT INTO [dbo].[Usuario] ([Nombre] ,[Email] ,[Contrasenia]) VALUES ('Ariel' ,'arielbvergara@gmail.com' ,'1234')
INSERT INTO [dbo].[Usuario] ([Nombre] ,[Email] ,[Contrasenia]) VALUES ('Usuario Premium' ,'upremium@gmail.com' ,'1234')
INSERT INTO [dbo].[Usuario] ([Nombre] ,[Email] ,[Contrasenia]) VALUES ('Usuario Comun' ,'ucomun@gmail.com' ,'1234')

--ROL POR USUARIO
INSERT INTO [dbo].[RolxUsuario] ([IdUsuario] ,[IdRol]) VALUES ( 1, 1)
INSERT INTO [dbo].[RolxUsuario] ([IdUsuario] ,[IdRol]) VALUES ( 2, 3)
INSERT INTO [dbo].[RolxUsuario] ([IdUsuario] ,[IdRol]) VALUES ( 3, 4)