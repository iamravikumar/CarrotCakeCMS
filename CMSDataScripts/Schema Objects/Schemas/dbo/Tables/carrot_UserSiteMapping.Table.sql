/****** Object:  Table [dbo].[carrot_UserSiteMapping]    Script Date: 08/14/2012 21:59:26 ******/

CREATE TABLE [dbo].[carrot_UserSiteMapping](
	[UserSiteMappingID] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[SiteID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [carrot_UserSiteMapping_PK] PRIMARY KEY CLUSTERED 
(
	[UserSiteMappingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[carrot_UserSiteMapping]  WITH CHECK ADD  CONSTRAINT [aspnet_Users_carrot_UserSiteMapping_FK] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[carrot_UserSiteMapping] CHECK CONSTRAINT [aspnet_Users_carrot_UserSiteMapping_FK]
GO
ALTER TABLE [dbo].[carrot_UserSiteMapping]  WITH CHECK ADD  CONSTRAINT [carrot_Sites_carrot_UserSiteMapping_FK] FOREIGN KEY([SiteID])
REFERENCES [dbo].[carrot_Sites] ([SiteID])
GO
ALTER TABLE [dbo].[carrot_UserSiteMapping] CHECK CONSTRAINT [carrot_Sites_carrot_UserSiteMapping_FK]
GO
ALTER TABLE [dbo].[carrot_UserSiteMapping] ADD  CONSTRAINT [DF_carrot_UserSiteMapping_UserSiteMappingID]  DEFAULT (newid()) FOR [UserSiteMappingID]
GO
