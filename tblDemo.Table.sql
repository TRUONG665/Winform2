﻿CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MaSV] NCHAR(50) NULL, 
    [TenSV] NCHAR(100) NULL, 
    [GT] BIT NULL, 
    [DC] NCHAR(500) NULL, 
    [GC] NCHAR(1000) NULL, 
    [NS] DATE NULL
)
