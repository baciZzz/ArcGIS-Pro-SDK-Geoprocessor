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
	/// <para>Analyze Market Potential</para>
	/// <para>Analyze Market Potential</para>
	/// <para>Generates a layer that displays expected customers by a selected geography level.</para>
	/// </summary>
	public class AnalyzeMarketPotential : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
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
		/// <para>The geography level that will be used to define the market potential layer.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing the market potential analysis.</para>
		/// </param>
		public AnalyzeMarketPotential(object TargetProfile, object BaseProfile, object GeographyLevel, object OutFeatureClass)
		{
			this.TargetProfile = TargetProfile;
			this.BaseProfile = BaseProfile;
			this.GeographyLevel = GeographyLevel;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Analyze Market Potential</para>
		/// </summary>
		public override string DisplayName() => "Analyze Market Potential";

		/// <summary>
		/// <para>Tool Name : AnalyzeMarketPotential</para>
		/// </summary>
		public override string ToolName() => "AnalyzeMarketPotential";

		/// <summary>
		/// <para>Tool Excute Name : ba.AnalyzeMarketPotential</para>
		/// </summary>
		public override string ExcuteName() => "ba.AnalyzeMarketPotential";

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
		public override string[] ValidEnvironments() => new string[] { "baDataSource", "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetProfile, BaseProfile, GeographyLevel, OutFeatureClass, BoundaryLayer, CreateReport, ReportTitle, ReportFolder, ReportFormat, OutputReport };

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
		/// <para>The geography level that will be used to define the market potential layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object GeographyLevel { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing the market potential analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

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
		/// <para>Specifies whether a market potential report will be created.</para>
		/// <para>Checked—A market potential report will be created.</para>
		/// <para>Unchecked—A market potential report will not be created. This is the default.</para>
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
		public AnalyzeMarketPotential SetEnviroment(object extent = null , object workspace = null )
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
			/// <para>Checked—A market potential report will be created.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_REPORT")]
			CREATE_REPORT,

			/// <summary>
			/// <para>Unchecked—A market potential report will not be created. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_CREATE_REPORT")]
			DO_NOT_CREATE_REPORT,

		}

#endregion
	}
}
