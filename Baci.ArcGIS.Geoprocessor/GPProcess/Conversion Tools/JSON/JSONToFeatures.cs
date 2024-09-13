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
	/// <para>JSON To Features</para>
	/// <para>JSON 转要素</para>
	/// <para>用于将 Esri JSON (.json) 文件或 GeoJSON (.geojson) 文件中的要素集合转换成要素类。</para>
	/// </summary>
	public class JSONToFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InJsonFile">
		/// <para>Input JSON or GeoJSON</para>
		/// <para>要转换为要素类的输入 JSON 或 GeoJSON 文件。</para>
		/// <para>确定该工具所使用的转换例程的输入文件扩展名。Esri JSON 格式的文件必须使用 .json 扩展名，GeoJSON 文件必须使用 .geojson 扩展名，才能进行正确的转换。</para>
		/// </param>
		/// <param name="OutFeatures">
		/// <para>Output Feature Class</para>
		/// <para>创建的输出要素类，要包含根据输入 JSON 或 GeoJSON 文件转换的要素。</para>
		/// </param>
		public JSONToFeatures(object InJsonFile, object OutFeatures)
		{
			this.InJsonFile = InJsonFile;
			this.OutFeatures = OutFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : JSON 转要素</para>
		/// </summary>
		public override string DisplayName() => "JSON 转要素";

		/// <summary>
		/// <para>Tool Name : JSONToFeatures</para>
		/// </summary>
		public override string ToolName() => "JSONToFeatures";

		/// <summary>
		/// <para>Tool Excute Name : conversion.JSONToFeatures</para>
		/// </summary>
		public override string ExcuteName() => "conversion.JSONToFeatures";

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
		public override object[] Parameters() => new object[] { InJsonFile, OutFeatures, GeometryType };

		/// <summary>
		/// <para>Input JSON or GeoJSON</para>
		/// <para>要转换为要素类的输入 JSON 或 GeoJSON 文件。</para>
		/// <para>确定该工具所使用的转换例程的输入文件扩展名。Esri JSON 格式的文件必须使用 .json 扩展名，GeoJSON 文件必须使用 .geojson 扩展名，才能进行正确的转换。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("json", "geojson")]
		public object InJsonFile { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>创建的输出要素类，要包含根据输入 JSON 或 GeoJSON 文件转换的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Geometry Type</para>
		/// <para>要从　GeoJSON　转换为要素的几何类型。该选项仅在输入为　GeoJSON　文件时适用。如果　GeoJSON　文件不包含任何所选几何类型，则输出要素类将为空。</para>
		/// <para>点—将任意点转换为要素。</para>
		/// <para>多点—将任意多点转换为要素。</para>
		/// <para>折线—将任意折线转换为要素。</para>
		/// <para>面—将任意面转换为要素。</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GeometryType { get; set; } = "POLYGON";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public JSONToFeatures SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Geometry Type</para>
		/// </summary>
		public enum GeometryTypeEnum 
		{
			/// <summary>
			/// <para>点—将任意点转换为要素。</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("点")]
			Point,

			/// <summary>
			/// <para>多点—将任意多点转换为要素。</para>
			/// </summary>
			[GPValue("MULTIPOINT")]
			[Description("多点")]
			Multipoint,

			/// <summary>
			/// <para>面—将任意面转换为要素。</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("面")]
			Polygon,

			/// <summary>
			/// <para>折线—将任意折线转换为要素。</para>
			/// </summary>
			[GPValue("POLYLINE")]
			[Description("折线")]
			Polyline,

		}

#endregion
	}
}
