/****** Object:  Table [dbo].[carrot_Widget]    Script Date: 08/14/2012 21:59:26 ******/

CREATE TABLE [dbo].[carrot_Widget](
	[Root_WidgetID] [uniqueidentifier] NOT NULL,
	[Root_ContentID] [uniqueidentifier] NOT NULL,
	[WidgetOrder] [int] NOT NULL,
	[PlaceholderName] [varchar](256) NOT NULL,
	[ControlPath] [varchar](512) NOT NULL,
	[WidgetActive] [bit] NOT NULL,
 CONSTRAINT [PK_carrot_Widget] PRIMARY KEY CLUSTERED 
(
	[Root_WidgetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[carrot_Widget]  WITH CHECK ADD  CONSTRAINT [carrot_RootContent_carrot_Widget_FK] FOREIGN KEY([Root_ContentID])
REFERENCES [dbo].[carrot_RootContent] ([Root_ContentID])
GO
ALTER TABLE [dbo].[carrot_Widget] CHECK CONSTRAINT [carrot_RootContent_carrot_Widget_FK]
GO
ALTER TABLE [dbo].[carrot_Widget] ADD  CONSTRAINT [DF_carrot_Widget_Root_WidgetID]  DEFAULT (newid()) FOR [Root_WidgetID]
GO
