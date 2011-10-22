﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Carrotware.CMS.Core;
using Carrotware.CMS.UI.Base;
using Carrotware.CMS.Interface;
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
	public partial class ucGenericContent : BaseUserControl, IWidget {

		#region IWidget Members

		public Guid PageWidgetID { get; set; }

		public Guid RootContentID { get; set; }

		public new Guid SiteID { get; set; }

		public string JSEditFunction {
			get { return "click" + this.ClientID + "('" + this.PageWidgetID + "');"; }
			//get { return ""; }
		}

		public bool EnableEdit { get { return false; } }

		#endregion


		protected void Page_Load(object sender, EventArgs e) {

			PageWidget pageWidget = null;

			if (AdvancedEditMode) {
				pageWidget = (from w in cmsHelper.cmsAdminWidget
							  where (w.PageWidgetID == PageWidgetID)
							  orderby w.WidgetOrder
							  select w).FirstOrDefault();
				pnlJS.Visible = true;
			} else {
				pageWidget = widgetHelper.Get(PageWidgetID);
				pnlJS.Visible = false;
			}

			GenericBody.ZoneChar = "w";
			GenericBody.DatabaseKey = PageWidgetID;
			GenericBody.Text = pageWidget.ControlProperties;
			GenericBody.JQueryUIScope = "GlossySeaGreen";
			GenericBody.IsAdminMode = AdvancedEditMode;

			txtGeneric.Text = pageWidget.ControlProperties;

		}


	}
}