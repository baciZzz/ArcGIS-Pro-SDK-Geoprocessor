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
	/// <para>Generate Market Area Segmentation Profile</para>
	/// <para>Creates a segmentation profile by summarizing segments from standard geography boundaries within the input area.</para>
	/// </summary>
	public class GenerateMarketAreaProfile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input features</para>
		/// <para>The input feature class with polygon features used to create a segmentation area profile.</para>
		/// </param>
		/// <param name="SegmentationBase">
		/// <para>Segmentation Base</para>
		/// <para>The segmentation base for the profile being created. Available options are provided by the segmentation dataset in use.</para>
		/// </param>
		/// <param name="OutProfile">
		/// <para>Output Profile</para>
		/// <para>The name of the segmentation profile file to be created.</para>
		/// </param>
		public GenerateMarketAreaProfile(object InFeatures, object SegmentationBase, object OutProfile)
		{
			this.InFeatures = InFeatures;
			this.SegmentationBase = SegmentationBase;
			this.OutProfile = OutProfile;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Market Area Segmentation Profile</para>
		/// </summary>
		public override string DisplayName => "Generate Market Area Segmentation Profile";

		/// <summary>
		/// <para>Tool Name : GenerateMarketAreaProfile</para>
		/// </summary>
		public override string ToolName => "GenerateMarketAreaProfile";

		/// <summary>
		/// <para>Tool Excute Name : ba.GenerateMarketAreaProfile</para>
		/// </summary>
		public override string ExcuteName => "ba.GenerateMarketAreaProfile";

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
		public override object[] Parameters => new object[] { InFeatures, SegmentationBase, OutProfile };

		/// <summary>
		/// <para>Input features</para>
		/// <para>The input feature class with polygon features used to create a segmentation area profile.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Segmentation Base</para>
		/// <para>The segmentation base for the profile being created. Available options are provided by the segmentation dataset in use.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SegmentationBase { get; set; }

		/// <summary>
		/// <para>Output Profile</para>
		/// <para>The name of the segmentation profile file to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("sgprofile")]
		public object OutProfile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateMarketAreaProfile SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
