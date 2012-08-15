/****** Object:  Table [dbo].[carrot_WidgetData]    Script Date: 08/14/2012 21:59:26 ******/

CREATE TABLE [dbo].[carrot_WidgetData](
	[WidgetDataID] [uniqueidentifier] NOT NULL,
	[Root_WidgetID] [uniqueidentifier] NOT NULL,
	[IsLatestVersion] [bit] NULL,
	[EditDate] [datetime] NOT NULL,
	[ControlProperties] [varchar](max) NULL,
 CONSTRAINT [PK_carrot_WidgetData] PRIMARY KEY CLUSTERED 
(
	[WidgetDataID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[carrot_WidgetData]  WITH CHECK ADD  CONSTRAINT [carrot_WidgetData_Root_WidgetID_FK] FOREIGN KEY([Root_WidgetID])
REFERENCES [dbo].[carrot_Widget] ([Root_WidgetID])
GO
ALTER TABLE [dbo].[carrot_WidgetData] CHECK CONSTRAINT [carrot_WidgetData_Root_WidgetID_FK]
GO
ALTER TABLE [dbo].[carrot_WidgetData] ADD  CONSTRAINT [DF_carrot_WidgetData_WidgetDataID]  DEFAULT (newid()) FOR [WidgetDataID]
GO
ALTER TABLE [dbo].[carrot_WidgetData] ADD  CONSTRAINT [DF_carrot_WidgetData_EditDate]  DEFAULT (getdate()) FOR [EditDate]
GO
