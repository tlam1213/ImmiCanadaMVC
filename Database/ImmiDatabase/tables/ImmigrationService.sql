CREATE TABLE [dbo].[ImmigrationService]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[State] [int] NULL,
	[PermanentResident] [int] NULL,
	[Fee] [nvarchar](200) NULL,
	[Time] [nvarchar](200) NULL,
	[Type] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[Overview] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Base64Image1] [varchar](max) NULL,
	[Base64Image2] [varchar](max) NULL,
	[Base64Image3] [varchar](max) NULL,
	[Base64Image4] [varchar](max) NULL,
	[Base64Image5] [varchar](max) NULL, 
    CONSTRAINT [PK_ImmigrationService] PRIMARY KEY ([Id]),
)
GO

ALTER TABLE [dbo].[ImmigrationService]  WITH CHECK ADD FOREIGN KEY([State])
REFERENCES [dbo].[State] ([Id])
GO

ALTER TABLE [dbo].[ImmigrationService]  WITH CHECK ADD FOREIGN KEY([PermanentResident])
REFERENCES [dbo].[PermanentResident] ([Id])

GO
ALTER TABLE [dbo].[ImmigrationService]  WITH CHECK ADD FOREIGN KEY([Type])
REFERENCES [dbo].[ImmigrationServiceType] ([Id])
GO