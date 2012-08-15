/****** Object:  Table [dbo].[tblFAQ]    Script Date: 08/14/2012 21:59:26 ******/

CREATE TABLE [dbo].[tblFAQ](
	[FaqID] [uniqueidentifier] NOT NULL,
	[Question] [varchar](max) NULL,
	[Answer] [varchar](max) NULL,
	[IsActive] [bit] NULL,
	[SortOrder] [int] NULL,
	[dtStamp] [datetime] NULL,
	[SiteID] [uniqueidentifier] NULL,
 CONSTRAINT [tblFAQ_PK_UC1] PRIMARY KEY CLUSTERED 
(
	[FaqID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


GO
ALTER TABLE [dbo].[tblFAQ] ADD  CONSTRAINT [DF_tblFAQ_FaqID]  DEFAULT (newid()) FOR [FaqID]
GO
