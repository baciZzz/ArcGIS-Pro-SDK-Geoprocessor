using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.BusinessAnalystTools
{
	/// <summary>
	/// <para>Export Segmentation Profile</para>
	/// <para>Export Segmentation Profile</para>
	/// <para>Exports a segmentation profile to a table.</para>
	/// </summary>
	public class ExportSegmentationProfile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InProfile">
		/// <para>Input Profile</para>
		/// <para>The segmentation file to export.</para>
		/// </param>
		/// <param name="OutTableName">
		/// <para>Output Table</para>
		/// <para>The name of the table to be created.</para>
		/// </param>
		public ExportSegmentationProfile(object InProfile, object OutTableName)
		{
			this.InProfile = InProfile;
			this.OutTableName = OutTableName;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Segmentation Profile</para>
		/// </summary>
		public override string DisplayName() => "Export Segmentation Profile";

		/// <summary>
		/// <para>Tool Name : ExportSegmentationProfile</para>
		/// </summary>
		public override string ToolName() => "ExportSegmentationProfile";

		/// <summary>
		/// <para>Tool Excute Name : ba.ExportSegmentationProfile</para>
		/// </summary>
		public override string ExcuteName() => "ba.ExportSegmentationProfile";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise() => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "baDataSource", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InProfile, OutTableName };

		/// <summary>
		/// <para>Input Profile</para>
		/// <para>The segmentation file to export.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("sgprofile")]
		public object InProfile { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The name of the table to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTableName { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportSegmentationProfile SetEnviroment(object? baDataSource = null , object? workspace = null )
		{
			base.SetEnv(baDataSource: baDataSource, workspace: workspace);
			return this;
		}

	}
}
