using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Geodatabase To Shape</para>
	/// <para>Geodatabase To Shape</para>
	/// <para>Exports one or more feature classes in a geodatabase to shapefiles using one of three modes: defense, generic, and Multinational Geospatial Co-Production Program</para>
	/// <para>(MGCP).</para>
	/// </summary>
	public class GeodatabaseToShape : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The features used to create the shapefiles.</para>
		/// </param>
		/// <param name="OutputFolder">
		/// <para>Output Folder</para>
		/// <para>The folder that will contain the output shapefiles.</para>
		/// </param>
		/// <param name="CodedValueDomainExportMode">
		/// <para>Coded Value Domain Export Mode</para>
		/// <para>Indicates what method will be used to export coded domain values.</para>
		/// <para>Descriptions—Coded domain values will be exported using their descriptions rather than raw values.</para>
		/// <para>Values—Coded domain values will be exported as raw values. This is the default.</para>
		/// <para>Values and descriptions—Coded domain values will be exported as raw values and string descriptions</para>
		/// <para><see cref="CodedValueDomainExportModeEnum"/></para>
		/// </param>
		/// <param name="ConversionMethod">
		/// <para>Conversion Method</para>
		/// <para>Indicates which conversion method will be applied.</para>
		/// <para>Defense by feature class—Creates a shapefile based on the feature class name and removes trailing underscores from fields.</para>
		/// <para>Defense by subtype—Creates a shapefile based on subtype name, exports attributes applicable to that subtype, and removes trailing underscores from fields. This is the default.</para>
		/// <para>Generic by feature class—Creates a shapefile for each feature class selected. The shapefile name matches the feature class name.</para>
		/// <para>Generic by subtype—Creates a shapefile for each subtype of the feature class selected. The shapefile name matches the subtype name.</para>
		/// <para>MGCP—Creates a shapefile based on the feature class subtype. The shapefile is named using the geometry type and feature code. For example, the River subtype in the WatrcrsL feature class would be exported to a shapefile called LBH140.</para>
		/// <para><see cref="ConversionMethodEnum"/></para>
		/// </param>
		/// <param name="CreateEmpties">
		/// <para>Create Empty Shapefiles</para>
		/// <para>Indicates that the tool will create empty shapefiles if the input feature classes are also empty.</para>
		/// <para>Checked—Create empty shapefiles if the corresponding feature classes to export are empty.</para>
		/// <para>Unchecked—Do not create empty shapefiles if the corresponding feature classes to export are empty. This is the default.</para>
		/// <para><see cref="CreateEmptiesEnum"/></para>
		/// </param>
		public GeodatabaseToShape(object InFeatures, object OutputFolder, object CodedValueDomainExportMode, object ConversionMethod, object CreateEmpties)
		{
			this.InFeatures = InFeatures;
			this.OutputFolder = OutputFolder;
			this.CodedValueDomainExportMode = CodedValueDomainExportMode;
			this.ConversionMethod = ConversionMethod;
			this.CreateEmpties = CreateEmpties;
		}

		/// <summary>
		/// <para>Tool Display Name : Geodatabase To Shape</para>
		/// </summary>
		public override string DisplayName() => "Geodatabase To Shape";

		/// <summary>
		/// <para>Tool Name : GeodatabaseToShape</para>
		/// </summary>
		public override string ToolName() => "GeodatabaseToShape";

		/// <summary>
		/// <para>Tool Excute Name : topographic.GeodatabaseToShape</para>
		/// </summary>
		public override string ExcuteName() => "topographic.GeodatabaseToShape";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise() => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutputFolder, CodedValueDomainExportMode, ConversionMethod, CreateEmpties, DerivedFolder };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The features used to create the shapefiles.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>The folder that will contain the output shapefiles.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Coded Value Domain Export Mode</para>
		/// <para>Indicates what method will be used to export coded domain values.</para>
		/// <para>Descriptions—Coded domain values will be exported using their descriptions rather than raw values.</para>
		/// <para>Values—Coded domain values will be exported as raw values. This is the default.</para>
		/// <para>Values and descriptions—Coded domain values will be exported as raw values and string descriptions</para>
		/// <para><see cref="CodedValueDomainExportModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CodedValueDomainExportMode { get; set; } = "VALUES";

		/// <summary>
		/// <para>Conversion Method</para>
		/// <para>Indicates which conversion method will be applied.</para>
		/// <para>Defense by feature class—Creates a shapefile based on the feature class name and removes trailing underscores from fields.</para>
		/// <para>Defense by subtype—Creates a shapefile based on subtype name, exports attributes applicable to that subtype, and removes trailing underscores from fields. This is the default.</para>
		/// <para>Generic by feature class—Creates a shapefile for each feature class selected. The shapefile name matches the feature class name.</para>
		/// <para>Generic by subtype—Creates a shapefile for each subtype of the feature class selected. The shapefile name matches the subtype name.</para>
		/// <para>MGCP—Creates a shapefile based on the feature class subtype. The shapefile is named using the geometry type and feature code. For example, the River subtype in the WatrcrsL feature class would be exported to a shapefile called LBH140.</para>
		/// <para><see cref="ConversionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConversionMethod { get; set; } = "DEFENSE_BY_SUBTYPE";

		/// <summary>
		/// <para>Create Empty Shapefiles</para>
		/// <para>Indicates that the tool will create empty shapefiles if the input feature classes are also empty.</para>
		/// <para>Checked—Create empty shapefiles if the corresponding feature classes to export are empty.</para>
		/// <para>Unchecked—Do not create empty shapefiles if the corresponding feature classes to export are empty. This is the default.</para>
		/// <para><see cref="CreateEmptiesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CreateEmpties { get; set; } = "false";

		/// <summary>
		/// <para>Derived Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object DerivedFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GeodatabaseToShape SetEnviroment(object extent = null , object workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Coded Value Domain Export Mode</para>
		/// </summary>
		public enum CodedValueDomainExportModeEnum 
		{
			/// <summary>
			/// <para>Values—Coded domain values will be exported as raw values. This is the default.</para>
			/// </summary>
			[GPValue("VALUES")]
			[Description("Values")]
			Values,

			/// <summary>
			/// <para>Descriptions—Coded domain values will be exported using their descriptions rather than raw values.</para>
			/// </summary>
			[GPValue("DESCRIPTIONS")]
			[Description("Descriptions")]
			Descriptions,

			/// <summary>
			/// <para>Values and descriptions—Coded domain values will be exported as raw values and string descriptions</para>
			/// </summary>
			[GPValue("VALUES_AND_DESCRIPTIONS")]
			[Description("Values and descriptions")]
			Values_and_descriptions,

		}

		/// <summary>
		/// <para>Conversion Method</para>
		/// </summary>
		public enum ConversionMethodEnum 
		{
			/// <summary>
			/// <para>Defense by feature class—Creates a shapefile based on the feature class name and removes trailing underscores from fields.</para>
			/// </summary>
			[GPValue("DEFENSE_BY_FEATURECLASS")]
			[Description("Defense by feature class")]
			Defense_by_feature_class,

			/// <summary>
			/// <para>Defense by subtype—Creates a shapefile based on subtype name, exports attributes applicable to that subtype, and removes trailing underscores from fields. This is the default.</para>
			/// </summary>
			[GPValue("DEFENSE_BY_SUBTYPE")]
			[Description("Defense by subtype")]
			Defense_by_subtype,

			/// <summary>
			/// <para>Generic by feature class—Creates a shapefile for each feature class selected. The shapefile name matches the feature class name.</para>
			/// </summary>
			[GPValue("GENERIC_BY_FEATURECLASS")]
			[Description("Generic by feature class")]
			Generic_by_feature_class,

			/// <summary>
			/// <para>Generic by subtype—Creates a shapefile for each subtype of the feature class selected. The shapefile name matches the subtype name.</para>
			/// </summary>
			[GPValue("GENERIC_BY_SUBTYPE")]
			[Description("Generic by subtype")]
			Generic_by_subtype,

			/// <summary>
			/// <para>MGCP—Creates a shapefile based on the feature class subtype. The shapefile is named using the geometry type and feature code. For example, the River subtype in the WatrcrsL feature class would be exported to a shapefile called LBH140.</para>
			/// </summary>
			[GPValue("MGCP")]
			[Description("MGCP")]
			MGCP,

		}

		/// <summary>
		/// <para>Create Empty Shapefiles</para>
		/// </summary>
		public enum CreateEmptiesEnum 
		{
			/// <summary>
			/// <para>Unchecked—Do not create empty shapefiles if the corresponding feature classes to export are empty. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CREATE_EMPTIES")]
			NO_CREATE_EMPTIES,

			/// <summary>
			/// <para>Checked—Create empty shapefiles if the corresponding feature classes to export are empty.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_EMPTIES")]
			CREATE_EMPTIES,

		}

#endregion
	}
}
