﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web;
using Carrotware.CMS.Data;
using Carrotware.CMS.Core;
using Carrotware.CMS.UI.Base;

/*
* CarrotCake CMS
* http://carrotware.com/
*
* Copyright 2011, Samantha Copeland
* Dual licensed under the MIT or GPL Version 2 licenses.
*
* Date: October 2011
*/

namespace Carrotware.CMS.UI.Admin {
	public class AdminBasePage : BasePage {

		protected CarrotCMSDataContext db = new CarrotCMSDataContext();

		protected SiteNavHelper navHelper = new SiteNavHelper();

		public bool IsPageLocked(ContentPage cp) {

			bool bLock = false;

			if (cp.Heartbeat_UserId != null) {
				if (cp.Heartbeat_UserId != SiteData.CurrentUserGuid
						&& cp.EditHeartbeat.Value > DateTime.Now.AddMinutes(-2)) {
					bLock = true;
				}
				if (cp.Heartbeat_UserId == SiteData.CurrentUserGuid
					|| cp.Heartbeat_UserId == null) {
					bLock = false;
				}
			}
			return bLock;
		}


		protected override void OnInit(EventArgs e) {
			if (Page.User.Identity.IsAuthenticated) {

				bool bHasAccess = siteHelper.VerifyUserHasSiteAccess(SiteData.CurrentSiteID, SiteData.CurrentUserGuid);

				if (!bHasAccess) {
					FormsAuthentication.SignOut();
					Response.Redirect("./Logon.aspx");
				}
			}

			Response.Cache.SetCacheability(System.Web.HttpCacheability.Private);
			DateTime dtExpire = System.DateTime.Now.AddMinutes(-5);
			Response.Cache.SetExpires(dtExpire);

			base.OnInit(e);

		}



	}
}
