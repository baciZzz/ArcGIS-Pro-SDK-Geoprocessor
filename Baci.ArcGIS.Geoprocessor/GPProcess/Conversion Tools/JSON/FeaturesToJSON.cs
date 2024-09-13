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
	/// <para>要素转 JSON</para>
	/// <para>将要素转换为 JSON 或 GeoJSON 格式。要素的字段、几何和空间参考将转换为相应的 JSON 表示，并写入到扩展名为 .json 或 .geojson 的文件中。</para>
	/// </summary>
	public class FeaturesToJSON : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要转换为 JSON 的要素。</para>
		/// </param>
		/// <param name="OutJsonFile">
		/// <para>Output JSON</para>
		/// <para>输出 JSON 或 GeoJSON 文件。</para>
		/// </param>
		public FeaturesToJSON(object InFeatures, object OutJsonFile)
		{
			this.InFeatures = InFeatures;
			this.OutJsonFile = OutJsonFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 要素转 JSON</para>
		/// </summary>
		public override string DisplayName() => "要素转 JSON";

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
		public override object[] Parameters() => new object[] { InFeatures, OutJsonFile, FormatJson, IncludeZValues, IncludeMValues, Geojson, Outputtowgs84, UseFieldAlias };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要转换为 JSON 的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polyline", "Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output JSON</para>
		/// <para>输出 JSON 或 GeoJSON 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("json", "geojson")]
		public object OutJsonFile { get; set; }

		/// <summary>
		/// <para>Formatted JSON</para>
		/// <para>用于指定是否设置 JSON 的格式，以提高与 ArcGIS REST API 规范的 PJSON（美观的 JSON）格式相似的可读性。</para>
		/// <para>取消选中 - 将不会设置要素的格式。这是默认设置。</para>
		/// <para>已选中 - 会按照 PJSON 规范设置要素的格式。</para>
		/// <para><see cref="FormatJsonEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object FormatJson { get; set; } = "false";

		/// <summary>
		/// <para>Include Z Values</para>
		/// <para>用于指定是否包括要转为 JSON 的要素的 Z 值。</para>
		/// <para>取消选中 - Z 值不会包括在几何中，且 JSON 的 hasZ 属性也不会包括在内。这是默认设置。</para>
		/// <para>已选中 - Z 值将包括在几何中，且 JSON 的 hasZ 属性将设置为 True。</para>
		/// <para><see cref="IncludeZValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeZValues { get; set; } = "false";

		/// <summary>
		/// <para>Include M Values</para>
		/// <para>用于指定是否包括要转为 JSON 的要素的 M 值。</para>
		/// <para>取消选中 - M 值不会包括在几何中，且 JSON 的 hasM 属性也不会包括在内。这是默认设置。</para>
		/// <para>已选中 - M 值将包括在几何中，且 JSON 的 hasM 属性将设置为 True。</para>
		/// <para><see cref="IncludeMValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeMValues { get; set; } = "false";

		/// <summary>
		/// <para>Output to GeoJSON</para>
		/// <para>用于指定是否将输出创建为 GeoJSON。</para>
		/// <para>未选中 - 输出将创建为 Esri JSON (.json)。这是默认设置。</para>
		/// <para>已选中 - 输出将创建为 GeoJSON 格式 (.geojson)。</para>
		/// <para><see cref="GeojsonEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Geojson { get; set; } = "false";

		/// <summary>
		/// <para>Project to WGS_1984</para>
		/// <para>用于指定是否将输入要素投影到采用默认地理变换的地理坐标系 WGS_1984。该参数仅适用于输出为 GeoJSON 的情况。</para>
		/// <para>选中 - 要素将投影到 WGS_1984。</para>
		/// <para>未选中 - 要素不会投影到 WGS_1984。GeoJSON 将包含用于定义坐标系的 CRS 标签。这是默认设置。</para>
		/// <para><see cref="Outputtowgs84Enum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Outputtowgs84 { get; set; } = "false";

		/// <summary>
		/// <para>Use field aliases</para>
		/// <para>指定输出文件是否将使用要素属性的字段别名。</para>
		/// <para>未选中 - 输出要素属性将使用字段名称。这是默认设置。</para>
		/// <para>选中 - 输出要素属性将使用字段别名。</para>
		/// <para><see cref="UseFieldAliasEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseFieldAlias { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeaturesToJSON SetEnviroment(object scratchWorkspace = null , object workspace = null )
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FORMATTED")]
			FORMATTED,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("Z_VALUES")]
			Z_VALUES,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("M_VALUES")]
			M_VALUES,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("GEOJSON")]
			GEOJSON,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("WGS84")]
			WGS84,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_FIELD_ALIAS")]
			USE_FIELD_ALIAS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("USE_FIELD_NAME")]
			USE_FIELD_NAME,

		}

#endregion
	}
}
