/****** Object:  Table [dbo].[carrot_Sites]    Script Date: 08/14/2012 21:59:26 ******/

CREATE TABLE [dbo].[carrot_Sites](
	[SiteID] [uniqueidentifier] NOT NULL,
	[MetaKeyword] [varchar](1000) NULL,
	[MetaDescription] [varchar](2000) NULL,
	[SiteName] [varchar](256) NULL,
	[MainURL] [varchar](256) NULL,
	[BlockIndex] [bit] NOT NULL,
	[SiteFolder] [varchar](256) NULL,
 CONSTRAINT [carrot_Sites_PK] PRIMARY KEY CLUSTERED 
(
	[SiteID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[carrot_Sites] ADD  CONSTRAINT [DF_carrot_Sites_SiteID]  DEFAULT (newid()) FOR [SiteID]
GO
