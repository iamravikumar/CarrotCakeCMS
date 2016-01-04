﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using Carrotware.CMS.Interface;

/*
* CarrotCake CMS
* http://www.carrotware.com/
*
* Copyright 2011, Samantha Copeland
* Dual licensed under the MIT or GPL Version 3 licenses.
*
* Date: October 2011
*/

namespace Carrotware.CMS.UI.Controls {

	public abstract class BaseNavHeaded : BaseNav, IHeadedList, IWidgetLimitedProperties {

		public BaseNavHeaded()
			: base() {
			this.ItemCount = -1;
			this.MetaDataTitle = String.Empty;
			this.HeadWrapTag = TagType.H2;
		}

		public int ItemCount { get; set; }

		[Category("Appearance")]
		[DefaultValue("")]
		public string MetaDataTitle {
			get {
				string s = (string)ViewState["MetaDataTitle"];
				return ((s == null) ? "" : s);
			}
			set {
				ViewState["MetaDataTitle"] = value;
			}
		}

		[Category("Appearance")]
		[DefaultValue("H2")]
		public TagType HeadWrapTag {
			get {
				String s = (String)ViewState["HeadWrapTag"];
				TagType c = TagType.H2;
				if (!String.IsNullOrEmpty(s)) {
					c = (TagType)Enum.Parse(typeof(TagType), s, true);
				}
				return c;
			}

			set {
				ViewState["HeadWrapTag"] = value.ToString();
			}
		}

		protected override void WriteListPrefix(HtmlTextWriter output) {
			if (this.NavigationData != null) {
				this.ItemCount = this.NavigationData.Count;
			}

			if (this.NavigationData != null && this.NavigationData.Count > 0 && !String.IsNullOrEmpty(this.MetaDataTitle)) {
				output.WriteLine("<" + this.HeadWrapTag.ToString().ToLower() + ">" + this.MetaDataTitle + "</" + this.HeadWrapTag.ToString().ToLower() + ">\r\n");
			}

			base.WriteListPrefix(output);
		}

		public virtual List<string> LimitedPropertyList {
			get {
				List<string> lst = new List<string>();
				lst.Add("MetaDataTitle");
				lst.Add("HeadWrapTag");

				return lst.Distinct().ToList();
			}
		}

		protected override void OnPreRender(System.EventArgs e) {
			if (this.PublicParmValues.Any()) {
				string sTmp = "";
				try {
					sTmp = GetParmValue("MetaDataTitle", "");
					if (!String.IsNullOrEmpty(sTmp)) {
						this.MetaDataTitle = sTmp;
					}

					sTmp = GetParmValue("HeadWrapTag", "");
					if (!String.IsNullOrEmpty(sTmp)) {
						this.HeadWrapTag = (TagType)Enum.Parse(typeof(TagType), sTmp, true);
					}
				} catch (Exception ex) {
				}
			}

			base.OnPreRender(e);
		}
	}
}