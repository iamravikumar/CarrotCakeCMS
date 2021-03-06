﻿using System;
using System.Web.UI.WebControls;

/*
* CarrotCake CMS
* http://www.carrotware.com/
*
* Copyright 2011, Samantha Copeland
* Dual licensed under the MIT or GPL Version 3 licenses.
*
* Date: October 2011
*/

namespace Carrotware.CMS.Interface {

	public abstract class WidgetWebControl : WebControl, IWidget {

		#region IWidget Members

		public virtual Guid PageWidgetID { get; set; }

		public virtual Guid RootContentID { get; set; }

		public virtual Guid SiteID { get; set; }

		public virtual string JSEditFunction {
			get { return ""; }
		}

		public virtual bool EnableEdit {
			get { return true; }
		}

		#endregion IWidget Members
	}
}