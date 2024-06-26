﻿CREATE TABLE [dbo].[User]
(
   Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
   Email VARCHAR(70) NOT NULL UNIQUE,
   Pseudo VARCHAR(50) NOT NULL UNIQUE,
   MotDePasse VARCHAR(MAX) NOT NULL,
   PhotoProfilPath VARCHAR(MAX),
   PhotoBannierePath VARCHAR(MAX),
   DateCreation DATETIME NOT NULL DEFAULT GETDATE(),
   IsAdmin BIT NOT NULL DEFAULT 0
)
