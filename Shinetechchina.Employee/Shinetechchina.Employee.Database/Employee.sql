CREATE TABLE [dbo].[Employee]
(
	[Id] [uniqueidentifier] NOT NULL,
	[EmployeeID] [nchar](20) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[Married] [bit] NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
)
