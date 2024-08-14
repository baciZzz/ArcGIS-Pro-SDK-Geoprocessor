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
	/// <para>Import Segmentation Profile</para>
	/// <para>Generates a segmentation profile from a table.</para>
	/// </summary>
	public class ImportSegmentationProfile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input table with segmentation information.</para>
		/// </param>
		/// <param name="SegmentationBase">
		/// <para>Segmentation Base</para>
		/// <para>The segmentation base for the profile being created. Available options are provided by the segmentation dataset in use.</para>
		/// </param>
		/// <param name="OutProfile">
		/// <para>Output Profile</para>
		/// <para>The name of the segmentation file to be created.</para>
		/// </param>
		/// <param name="SegmentIdField">
		/// <para>Segment ID Field</para>
		/// <para>A string field that contains the segmentation code.</para>
		/// </param>
		/// <param name="CountField">
		/// <para>Count Field</para>
		/// <para>A numeric field that contains segment count information.</para>
		/// </param>
		public ImportSegmentationProfile(object InTable, object SegmentationBase, object OutProfile, object SegmentIdField, object CountField)
		{
			this.InTable = InTable;
			this.SegmentationBase = SegmentationBase;
			this.OutProfile = OutProfile;
			this.SegmentIdField = SegmentIdField;
			this.CountField = CountField;
		}

		/// <summary>
		/// <para>Tool Display Name : Import Segmentation Profile</para>
		/// </summary>
		public override string DisplayName => "Import Segmentation Profile";

		/// <summary>
		/// <para>Tool Name : ImportSegmentationProfile</para>
		/// </summary>
		public override string ToolName => "ImportSegmentationProfile";

		/// <summary>
		/// <para>Tool Excute Name : ba.ImportSegmentationProfile</para>
		/// </summary>
		public override string ExcuteName => "ba.ImportSegmentationProfile";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "baDataSource", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, SegmentationBase, OutProfile, SegmentIdField, CountField, TotalVolumeField! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input table with segmentation information.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Segmentation Base</para>
		/// <para>The segmentation base for the profile being created. Available options are provided by the segmentation dataset in use.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SegmentationBase { get; set; }

		/// <summary>
		/// <para>Output Profile</para>
		/// <para>The name of the segmentation file to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutProfile { get; set; }

		/// <summary>
		/// <para>Segment ID Field</para>
		/// <para>A string field that contains the segmentation code.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object SegmentIdField { get; set; }

		/// <summary>
		/// <para>Count Field</para>
		/// <para>A numeric field that contains segment count information.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object CountField { get; set; }

		/// <summary>
		/// <para>Total Volume Field</para>
		/// <para>A numeric field that contains volume information.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? TotalVolumeField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportSegmentationProfile SetEnviroment(object? baDataSource = null , object? workspace = null )
		{
			base.SetEnv(baDataSource: baDataSource, workspace: workspace);
			return this;
		}

	}
}
