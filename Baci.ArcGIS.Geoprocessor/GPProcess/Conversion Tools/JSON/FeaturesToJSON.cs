using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>Features To JSON</para>
	/// <para>Features To JSON</para>
	/// <para>Converts features to Esri JSON or GeoJSON format. The fields, geometry, and spatial reference of features will be converted to their corresponding JSON representation and written to a file with a .json or .geojson extension.</para>
	/// </summary>
	public class FeaturesToJSON : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The features to convert to JSON format.</para>
		/// </param>
		/// <param name="OutJsonFile">
		/// <para>Output JSON</para>
		/// <para>The output .json or .geojson file.</para>
		/// </param>
		public FeaturesToJSON(object InFeatures, object OutJsonFile)
		{
			this.InFeatures = InFeatures;
			this.OutJsonFile = OutJsonFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Features To JSON</para>
		/// </summary>
		public override string DisplayName() => "Features To JSON";

		/// <summary>
		/// <para>Tool Name : FeaturesToJSON</para>
		/// </summary>
		public override string ToolName() => "FeaturesToJSON";

		/// <summary>
		/// <para>Tool Excute Name : conversion.FeaturesToJSON</para>
		/// </summary>
		public override string ExcuteName() => "conversion.FeaturesToJSON";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutJsonFile, FormatJson!, IncludeZValues!, IncludeMValues!, Geojson!, Outputtowgs84!, UseFieldAlias! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The features to convert to JSON format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polyline", "Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output JSON</para>
		/// <para>The output .json or .geojson file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("json", "geojson")]
		public object OutJsonFile { get; set; }

		/// <summary>
		/// <para>Formatted JSON</para>
		/// <para>Specifies whether the JSON will be formatted to improve readability similar to the ArcGIS REST API specification&apos;s PJSON (Pretty JSON) format.</para>
		/// <para>Unchecked—The features will not be formatted. This is the default.</para>
		/// <para>Checked—The features will be formatted to the PJSON specification.</para>
		/// <para><see cref="FormatJsonEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? FormatJson { get; set; } = "false";

		/// <summary>
		/// <para>Include Z Values</para>
		/// <para>Specifies whether the z-values of the features will be included in the JSON.</para>
		/// <para>Unchecked—The z-values will not be included in geometries, and the hasZ property of the JSON will not be included. This is the default.</para>
		/// <para>Checked—The z-values will be included in geometries, and the hasZ property of the JSON will be set to true.</para>
		/// <para><see cref="IncludeZValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeZValues { get; set; } = "false";

		/// <summary>
		/// <para>Include M Values</para>
		/// <para>Specifies whether the m-values of the features will be included in the JSON.</para>
		/// <para>Unchecked—The m-values will not be included in geometries, and the hasM property of the JSON will not be included. This is the default.</para>
		/// <para>Checked—The m-values will be included in geometries, and the hasM property of the JSON will be set to true.</para>
		/// <para><see cref="IncludeMValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeMValues { get; set; } = "false";

		/// <summary>
		/// <para>Output to GeoJSON</para>
		/// <para>Specifies whether the output will be created in GeoJSON format.</para>
		/// <para>Unchecked—The output will be created in Esri JSON format (.json file). This is the default.</para>
		/// <para>Checked—The output will be created in GeoJSON format (.geojson file).</para>
		/// <para><see cref="GeojsonEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Geojson { get; set; } = "false";

		/// <summary>
		/// <para>Project to WGS_1984</para>
		/// <para>Specifies whether the input features will be projected to the geographic coordinate system WGS_1984 with a default geographic transformation. This parameter only applies when the output is GeoJSON.</para>
		/// <para>Checked—Features will be projected to WGS_1984.</para>
		/// <para>Unchecked—Features will not be projected to WGS_1984. The GeoJSON will contain a CRS tag that defines the coordinate system. This is the default.</para>
		/// <para><see cref="Outputtowgs84Enum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Outputtowgs84 { get; set; } = "false";

		/// <summary>
		/// <para>Use field aliases</para>
		/// <para>Specifies whether the output file will use field aliases for feature attributes.</para>
		/// <para>Unchecked—Output feature attributes will not use field aliases; they will use field names. This is the default.</para>
		/// <para>Checked—Output feature attributes will use field aliases.</para>
		/// <para><see cref="UseFieldAliasEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? UseFieldAlias { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeaturesToJSON SetEnviroment(object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Formatted JSON</para>
		/// </summary>
		public enum FormatJsonEnum 
		{
			/// <summary>
			/// <para>Checked—The features will be formatted to the PJSON specification.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FORMATTED")]
			FORMATTED,

			/// <summary>
			/// <para>Unchecked—The features will not be formatted. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_FORMATTED")]
			NOT_FORMATTED,

		}

		/// <summary>
		/// <para>Include Z Values</para>
		/// </summary>
		public enum IncludeZValuesEnum 
		{
			/// <summary>
			/// <para>Checked—The z-values will be included in geometries, and the hasZ property of the JSON will be set to true.</para>
			/// </summary>
			[GPValue("true")]
			[Description("Z_VALUES")]
			Z_VALUES,

			/// <summary>
			/// <para>Unchecked—The z-values will not be included in geometries, and the hasZ property of the JSON will not be included. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_Z_VALUES")]
			NO_Z_VALUES,

		}

		/// <summary>
		/// <para>Include M Values</para>
		/// </summary>
		public enum IncludeMValuesEnum 
		{
			/// <summary>
			/// <para>Checked—The m-values will be included in geometries, and the hasM property of the JSON will be set to true.</para>
			/// </summary>
			[GPValue("true")]
			[Description("M_VALUES")]
			M_VALUES,

			/// <summary>
			/// <para>Unchecked—The m-values will not be included in geometries, and the hasM property of the JSON will not be included. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_M_VALUES")]
			NO_M_VALUES,

		}

		/// <summary>
		/// <para>Output to GeoJSON</para>
		/// </summary>
		public enum GeojsonEnum 
		{
			/// <summary>
			/// <para>Checked—The output will be created in GeoJSON format (.geojson file).</para>
			/// </summary>
			[GPValue("true")]
			[Description("GEOJSON")]
			GEOJSON,

			/// <summary>
			/// <para>Unchecked—The output will be created in Esri JSON format (.json file). This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_GEOJSON")]
			NO_GEOJSON,

		}

		/// <summary>
		/// <para>Project to WGS_1984</para>
		/// </summary>
		public enum Outputtowgs84Enum 
		{
			/// <summary>
			/// <para>Checked—Features will be projected to WGS_1984.</para>
			/// </summary>
			[GPValue("true")]
			[Description("WGS84")]
			WGS84,

			/// <summary>
			/// <para>Unchecked—Features will not be projected to WGS_1984. The GeoJSON will contain a CRS tag that defines the coordinate system. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_INPUT_SR")]
			KEEP_INPUT_SR,

		}

		/// <summary>
		/// <para>Use field aliases</para>
		/// </summary>
		public enum UseFieldAliasEnum 
		{
			/// <summary>
			/// <para>Checked—Output feature attributes will use field aliases.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_FIELD_ALIAS")]
			USE_FIELD_ALIAS,

			/// <summary>
			/// <para>Unchecked—Output feature attributes will not use field aliases; they will use field names. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("USE_FIELD_NAME")]
			USE_FIELD_NAME,

		}

#endregion
	}
}
