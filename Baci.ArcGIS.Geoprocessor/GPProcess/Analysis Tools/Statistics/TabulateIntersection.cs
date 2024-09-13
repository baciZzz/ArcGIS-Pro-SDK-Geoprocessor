using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Tabulate Intersection</para>
	/// <para>交集制表</para>
	/// <para>计算两个要素类之间的交集并对相交要素的面积、长度或数量进行交叉制表。</para>
	/// </summary>
	public class TabulateIntersection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InZoneFeatures">
		/// <para>Input Zone Features</para>
		/// <para>用于标识区域的要素。</para>
		/// </param>
		/// <param name="ZoneFields">
		/// <para>Zone Fields</para>
		/// <para>将用于定义区域的属性字段。</para>
		/// </param>
		/// <param name="InClassFeatures">
		/// <para>Input Class Features</para>
		/// <para>用于标识类的要素。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>将包含区域和类之间交集的交叉表的表。</para>
		/// </param>
		public TabulateIntersection(object InZoneFeatures, object ZoneFields, object InClassFeatures, object OutTable)
		{
			this.InZoneFeatures = InZoneFeatures;
			this.ZoneFields = ZoneFields;
			this.InClassFeatures = InClassFeatures;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 交集制表</para>
		/// </summary>
		public override string DisplayName() => "交集制表";

		/// <summary>
		/// <para>Tool Name : TabulateIntersection</para>
		/// </summary>
		public override string ToolName() => "TabulateIntersection";

		/// <summary>
		/// <para>Tool Excute Name : analysis.TabulateIntersection</para>
		/// </summary>
		public override string ExcuteName() => "analysis.TabulateIntersection";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise() => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "autoCommit", "configKeyword", "extent", "outputCoordinateSystem", "qualifiedFieldNames", "scratchWorkspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InZoneFeatures, ZoneFields, InClassFeatures, OutTable, ClassFields, SumFields, XyTolerance, OutUnits };

		/// <summary>
		/// <para>Input Zone Features</para>
		/// <para>用于标识区域的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InZoneFeatures { get; set; }

		/// <summary>
		/// <para>Zone Fields</para>
		/// <para>将用于定义区域的属性字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Date", "GUID")]
		public object ZoneFields { get; set; }

		/// <summary>
		/// <para>Input Class Features</para>
		/// <para>用于标识类的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InClassFeatures { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>将包含区域和类之间交集的交叉表的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Class Fields</para>
		/// <para>用于定义类的属性字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Date", "GUID")]
		public object ClassFields { get; set; }

		/// <summary>
		/// <para>Sum Fields</para>
		/// <para>输入类要素参数中用于求和的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object SumFields { get; set; }

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>确定要素或其顶点被视作相同的范围的距离。 默认情况下，为输入区域要素的 XY 容差。</para>
		/// <para>更改此参数的值可能会导致出现故障或意外结果。建议不要修改此参数。已将其从工具对话框的视图中移除。默认情况下，将使用输入要素类的空间参考 x,y 容差属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object XyTolerance { get; set; }

		/// <summary>
		/// <para>Output Units</para>
		/// <para>指定计算面积或长度测量值所使用的单位。 当输入类要素为点时，不支持设置输出单位。</para>
		/// <para>未知—未知单位。</para>
		/// <para>英寸—将以英寸为单位。</para>
		/// <para>英尺—单位将为英尺。</para>
		/// <para>码—将以码为单位。</para>
		/// <para>英里—单位将为英里。</para>
		/// <para>海里—单位将为海里。</para>
		/// <para>毫米—将以毫米为单位。</para>
		/// <para>厘米—将以厘米为单位。</para>
		/// <para>分米—将以分米为单位。</para>
		/// <para>米—单位将为米。</para>
		/// <para>千米—单位将为公里。</para>
		/// <para>十进制度—单位将为十进制度。</para>
		/// <para>点—将以磅为单位。</para>
		/// <para>公亩—将以公亩为单位。</para>
		/// <para>英亩—将以英亩为单位。</para>
		/// <para>公顷—将以公顷为单位。</para>
		/// <para>平方英寸—将以平方英寸为单位。</para>
		/// <para>平方英尺—将以平方英尺为单位。</para>
		/// <para>平方码—将以平方码为单位。</para>
		/// <para>平方英里—将以平方英里为单位。</para>
		/// <para>平方毫米—将以平方毫米为单位。</para>
		/// <para>平方厘米—将以平方厘米为单位。</para>
		/// <para>平方分米—将以平方分米为单位。</para>
		/// <para>平方米—将以平方米为单位。</para>
		/// <para>平方千米—将以平方公里为单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutUnits { get; set; } = "UNKNOWN";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TabulateIntersection SetEnviroment(object XYDomain = null , object XYResolution = null , object XYTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object outputCoordinateSystem = null , bool? qualifiedFieldNames = null , object scratchWorkspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace);
			return this;
		}

	}
}
