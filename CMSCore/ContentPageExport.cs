﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Carrotware.CMS.Data;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO;
/*
* CarrotCake CMS
* http://carrotware.com/
*
* Copyright 2011, Samantha Copeland
* Dual licensed under the MIT or GPL Version 2 licenses.
*
* Date: October 2011
*/


namespace Carrotware.CMS.Core {

	public class ContentPageExport {

		public ContentPageExport() {
			ThePage = new ContentPage();
			ThePageWidgets = new List<PageWidget>();
		}

		public ContentPageExport(Guid rootContentID) {

			using (ContentPageHelper cph = new ContentPageHelper()) {
				ThePage = cph.GetLatestContent(SiteData.CurrentSiteID, rootContentID);
			}

			using (PageWidgetHelper pwh = new PageWidgetHelper()) {
				ThePageWidgets = pwh.GetWidgets(rootContentID, null);
			}

			if (ThePage == null) {
				ThePage = new ContentPage();
				ThePage.Root_ContentID = Guid.NewGuid();
				ThePage.ContentID = ThePage.Root_ContentID;
			}
			if (ThePageWidgets == null) {
				ThePageWidgets = new List<PageWidget>();
			}

			OriginalRootContentID = ThePage.Root_ContentID;
			OriginalParentContentID = Guid.Empty;
			ParentFileName = "";

			if (ThePage.Parent_ContentID !=null) {
				var parent = new ContentPage();
				using (ContentPageHelper cph = new ContentPageHelper()) {
					parent = cph.GetLatestContent(SiteData.CurrentSiteID, (Guid)ThePage.Parent_ContentID);
				}
				ParentFileName = parent.FileName;
				OriginalParentContentID = parent.Root_ContentID;
			}

			ThePage.Root_ContentID = Guid.NewGuid();
			ThePage.ContentID = ThePage.Root_ContentID;

			foreach (var w in ThePageWidgets) {
				w.Root_ContentID = ThePage.Root_ContentID;
				w.Root_WidgetID = Guid.NewGuid();
			}
		}

		public Guid OriginalRootContentID { get; set; }

		public Guid OriginalParentContentID { get; set; }

		public string ParentFileName { get; set; }

		public ContentPage ThePage { get; set; }

		public List<PageWidget> ThePageWidgets { get; set; }


		public static ContentPageExport GetExportPage(Guid rootContentID) {
			ContentPageExport cpe = new ContentPageExport(rootContentID);

			return cpe;
		}

		public static string GetExportXML(ContentPageExport cpe) {

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ContentPageExport));
			string sXML = "";
			using (StringWriter stringWriter = new StringWriter()) {
				xmlSerializer.Serialize(stringWriter, cpe);
				sXML = stringWriter.ToString();
			}

			return sXML;
		}

		public static string GetExportXML(Guid rootContentID) {
			ContentPageExport cpe = GetExportPage(rootContentID);

			return GetExportXML(cpe);
		}

		public static void SaveSerializedContentPageExport(ContentPageExport cpe) {

			if (cpe == null) {
				CMSConfigHelper.ClearSerialized(cpe.ThePage.Root_ContentID, "cmsContentPageExport");
			} else {
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(ContentPageExport));
				string sXML = "";
				using (StringWriter stringWriter = new StringWriter()) {
					xmlSerializer.Serialize(stringWriter, cpe);
					sXML = stringWriter.ToString();
				}
				CMSConfigHelper.SaveSerialized(cpe.ThePage.Root_ContentID, "cmsContentPageExport", sXML);
			}
		}

		public static ContentPageExport GetSerializedContentPageExport(Guid rootContentID) {

			ContentPageExport c = null;
			try {
				var sXML = CMSConfigHelper.GetSerialized(rootContentID, "cmsContentPageExport");
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(ContentPageExport));
				Object genpref = null;
				using (StringReader stringReader = new StringReader(sXML)) {
					genpref = xmlSerializer.Deserialize(stringReader);
				}
				c = genpref as ContentPageExport;
			} catch (Exception ex) { }
			return c;
		}

		public static ContentPageExport GetSerializedContentPageExport(string sData) {
			ContentPageExport c = null;
			try {
				var sXML = sData;
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(ContentPageExport));
				Object genpref = null;
				using (StringReader stringReader = new StringReader(sXML)) {
					genpref = xmlSerializer.Deserialize(stringReader);
				}
				c = genpref as ContentPageExport;
			} catch (Exception ex) { }
			return c;
		}

	}
}
