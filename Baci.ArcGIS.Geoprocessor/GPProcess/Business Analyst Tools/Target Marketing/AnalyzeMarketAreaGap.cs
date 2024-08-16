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
	/// <para>Analyze Market Area Gap</para>
	/// <para>Generates a layer that displays the gap between total customers and expected customers.</para>
	/// </summary>
	public class AnalyzeMarketAreaGap : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="CustomerLayer">
		/// <para>Customer Layer</para>
		/// <para>A point layer representing customers.</para>
		/// </param>
		/// <param name="TargetProfile">
		/// <para>Target Profile</para>
		/// <para>A segmentation profile representing the segments to be analyzed. The target profile usually represents your customer segmentation profile.</para>
		/// </param>
		/// <param name="BaseProfile">
		/// <para>Base Profile</para>
		/// <para>A segmentation profile representing the base profile segments. This is the segmentation used for comparison. The base profile usually represents your market area segmentation profile.</para>
		/// </param>
		/// <param name="GeographyLevel">
		/// <para>Geography Level</para>
		/// <para>The geography level that will be used to define the market area gap analysis layer.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing the market area gap analysis.</para>
		/// </param>
		/// <param name="TargetGroup">
		/// <para>Target Group</para>
		/// <para>A collection of segments grouped into targets. Targets represent segments that are selected based on similar characteristics—for example, segments that have high index and percent composition.</para>
		/// </param>
		/// <param name="CoreTarget">
		/// <para>Core Target</para>
		/// <para>A group of segments that make up a large percentage of your customer base and have an above average index, indicating likelihood to be a customer.</para>
		/// </param>
		/// <param name="DevelopmentalTarget">
		/// <para>Developmental Target</para>
		/// <para>A group of segments that make up a significant percentage of your customers and of the market area but do not have an above average index.</para>
		/// </param>
		public AnalyzeMarketAreaGap(object CustomerLayer, object TargetProfile, object BaseProfile, object GeographyLevel, object OutFeatureClass, object TargetGroup, object CoreTarget, object DevelopmentalTarget)
		{
			this.CustomerLayer = CustomerLayer;
			this.TargetProfile = TargetProfile;
			this.BaseProfile = BaseProfile;
			this.GeographyLevel = GeographyLevel;
			this.OutFeatureClass = OutFeatureClass;
			this.TargetGroup = TargetGroup;
			this.CoreTarget = CoreTarget;
			this.DevelopmentalTarget = DevelopmentalTarget;
		}

		/// <summary>
		/// <para>Tool Display Name : Analyze Market Area Gap</para>
		/// </summary>
		public override string DisplayName => "Analyze Market Area Gap";

		/// <summary>
		/// <para>Tool Name : AnalyzeMarketAreaGap</para>
		/// </summary>
		public override string ToolName => "AnalyzeMarketAreaGap";

		/// <summary>
		/// <para>Tool Excute Name : ba.AnalyzeMarketAreaGap</para>
		/// </summary>
		public override string ExcuteName => "ba.AnalyzeMarketAreaGap";

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
		public override string[] ValidEnvironments => new string[] { "baDataSource", "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { CustomerLayer, TargetProfile, BaseProfile, GeographyLevel, OutFeatureClass, TargetGroup, CoreTarget, DevelopmentalTarget, BoundaryLayer, CreateReport, ReportTitle, ReportFolder, ReportFormat, OutputReport };

		/// <summary>
		/// <para>Customer Layer</para>
		/// <para>A point layer representing customers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object CustomerLayer { get; set; }

		/// <summary>
		/// <para>Target Profile</para>
		/// <para>A segmentation profile representing the segments to be analyzed. The target profile usually represents your customer segmentation profile.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("sgprofile")]
		public object TargetProfile { get; set; }

		/// <summary>
		/// <para>Base Profile</para>
		/// <para>A segmentation profile representing the base profile segments. This is the segmentation used for comparison. The base profile usually represents your market area segmentation profile.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("sgprofile")]
		public object BaseProfile { get; set; }

		/// <summary>
		/// <para>Geography Level</para>
		/// <para>The geography level that will be used to define the market area gap analysis layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object GeographyLevel { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing the market area gap analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Target Group</para>
		/// <para>A collection of segments grouped into targets. Targets represent segments that are selected based on similar characteristics—for example, segments that have high index and percent composition.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("sgtargetgroup")]
		public object TargetGroup { get; set; }

		/// <summary>
		/// <para>Core Target</para>
		/// <para>A group of segments that make up a large percentage of your customer base and have an above average index, indicating likelihood to be a customer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object CoreTarget { get; set; }

		/// <summary>
		/// <para>Developmental Target</para>
		/// <para>A group of segments that make up a significant percentage of your customers and of the market area but do not have an above average index.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DevelopmentalTarget { get; set; }

		/// <summary>
		/// <para>Boundary Layer</para>
		/// <para>The boundary that determines the layer extent. If not specified, the entire country will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object BoundaryLayer { get; set; }

		/// <summary>
		/// <para>Create Report</para>
		/// <para>Specifies whether a gap analysis report will be created.</para>
		/// <para>Checked—A gap analysis report will be created.</para>
		/// <para>Unchecked—A gap analysis report will not be created. This is the default.</para>
		/// <para><see cref="CreateReportEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CreateReport { get; set; } = "false";

		/// <summary>
		/// <para>Report Title</para>
		/// <para>The title of the report.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Report Options")]
		public object ReportTitle { get; set; }

		/// <summary>
		/// <para>Output Report Folder</para>
		/// <para>The output location where the report will be saved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		[Category("Report Options")]
		public object ReportFolder { get; set; }

		/// <summary>
		/// <para>Report Output Formats</para>
		/// <para>The report output format. The default value is PDF. Additional available formats are XLSX, HTML, CSV, and PAGX.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Report Options")]
		public object ReportFormat { get; set; }

		/// <summary>
		/// <para>Output Report</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutputReport { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AnalyzeMarketAreaGap SetEnviroment(object extent = null , object workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Create Report</para>
		/// </summary>
		public enum CreateReportEnum 
		{
			/// <summary>
			/// <para>Checked—A gap analysis report will be created.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_REPORT")]
			CREATE_REPORT,

			/// <summary>
			/// <para>Unchecked—A gap analysis report will not be created. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_CREATE_REPORT")]
			DO_NOT_CREATE_REPORT,

		}

#endregion
	}
}
