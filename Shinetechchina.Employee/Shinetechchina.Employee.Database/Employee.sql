CREATE TABLE [dbo].[Employee]
(
	[Id] UNIQUEIDENTIFIER NOT NULL ,
	[EmployeeID] [nchar](20) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Gender] NVARCHAR(50) NULL,
	[Married] [bit] NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL, 
    [Created] DATETIME NOT NULL, 
    [Modified] DATETIME NOT NULL, 
    CONSTRAINT [PK_Employee] PRIMARY KEY ([Id]),
)
