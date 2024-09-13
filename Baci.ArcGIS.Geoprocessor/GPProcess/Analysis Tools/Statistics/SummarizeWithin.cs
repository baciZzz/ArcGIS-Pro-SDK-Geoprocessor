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
	/// <para>Summarize Within</para>
	/// <para>范围内汇总</para>
	/// <para>将一个面图层与另一个图层叠加，以便汇总各面内点的数量、线的长度或面的面积，并计算面内此类要素的属性字段统计数据。</para>
	/// </summary>
	public class SummarizeWithin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPolygons">
		/// <para>Input Polygons</para>
		/// <para>用于汇总输入要素图层内要素或要素部分的面。</para>
		/// </param>
		/// <param name="InSumFeatures">
		/// <para>Input Summary Features</para>
		/// <para>将为输入面中的各面汇总点、线或面要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>输出面要素类，包括与输入面相同的几何和属性，还有一些新属性（关于各输入面内点的数量、线的长度和面的面积以及这些要素的统计数据）。</para>
		/// </param>
		public SummarizeWithin(object InPolygons, object InSumFeatures, object OutFeatureClass)
		{
			this.InPolygons = InPolygons;
			this.InSumFeatures = InSumFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 范围内汇总</para>
		/// </summary>
		public override string DisplayName() => "范围内汇总";

		/// <summary>
		/// <para>Tool Name : SummarizeWithin</para>
		/// </summary>
		public override string ToolName() => "SummarizeWithin";

		/// <summary>
		/// <para>Tool Excute Name : analysis.SummarizeWithin</para>
		/// </summary>
		public override string ExcuteName() => "analysis.SummarizeWithin";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPolygons, InSumFeatures, OutFeatureClass, KeepAllPolygons, SumFields, SumShape, ShapeUnit, GroupField, AddMinMaj, AddGroupPercent, OutGroupTable };

		/// <summary>
		/// <para>Input Polygons</para>
		/// <para>用于汇总输入要素图层内要素或要素部分的面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InPolygons { get; set; }

		/// <summary>
		/// <para>Input Summary Features</para>
		/// <para>将为输入面中的各面汇总点、线或面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polygon", "Polyline")]
		[FeatureType("Simple")]
		public object InSumFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出面要素类，包括与输入面相同的几何和属性，还有一些新属性（关于各输入面内点的数量、线的长度和面的面积以及这些要素的统计数据）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Keep all input polygons</para>
		/// <para>确定是所有输入面还是仅那些相交或包括至少一个输入汇总要素的面将会复制到输出要素类。</para>
		/// <para>选中 - 所有输入面都将复制到输出要素类。这是默认设置。</para>
		/// <para>未选中 - 只有相交或包括至少一个输入汇总要素的输入面将会复制到输出要素类。</para>
		/// <para><see cref="KeepAllPolygonsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object KeepAllPolygons { get; set; } = "true";

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>输入汇总要素中的属性字段名称及您想要为各面内全部点计算属性字段的统计汇总类型的列表。</para>
		/// <para>汇总字段必须为数值型。不支持文本和其他属性字段类型。</para>
		/// <para>统计类型包括：</para>
		/// <para>Sum - 添加每个面内所有点的总值。</para>
		/// <para>Mean - 计算每个面内所有点的平均值。</para>
		/// <para>Min - 查找每个面内所有点的最小值。</para>
		/// <para>Max - 查找每个面内所有点的最大值。</para>
		/// <para>Stddev - 查找每个面内所有点的标准差。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object SumFields { get; set; }

		/// <summary>
		/// <para>Add shape summary  attributes</para>
		/// <para>确定是否输出要素类将包括各输入面中汇总得出的点数量、线长度及面要素面积等属性。</para>
		/// <para>选中 - 将形状汇总属性添加到输出要素类。这是默认设置。</para>
		/// <para>未选中 - 不将形状汇总属性添加到输出要素类。</para>
		/// <para><see cref="SumShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SumShape { get; set; } = "true";

		/// <summary>
		/// <para>Shape Unit</para>
		/// <para>用以计算形状汇总属性的单位。如果输入汇总要素为点，则不需要使用形状单位，因为仅添加各输入面内点的计数。</para>
		/// <para>&lt;para/&gt;如果输入汇总要素为线，则指定一个线性单位。如果输入汇总要素为面，则指定一个面积单位。</para>
		/// <para>米—米</para>
		/// <para>千米—千米</para>
		/// <para>英尺—英尺</para>
		/// <para>码—码</para>
		/// <para>英里—英里</para>
		/// <para>英亩—英亩</para>
		/// <para>公顷—公顷</para>
		/// <para>平方米—平方米</para>
		/// <para>平方千米—平方千米</para>
		/// <para>平方英尺—平方英尺</para>
		/// <para>平方码—平方码</para>
		/// <para>平方英里—平方英里</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ShapeUnit { get; set; }

		/// <summary>
		/// <para>Group Field</para>
		/// <para>用于分组的输入汇总要素中的属性字段。具有相同组字段值的要素将合并与具有相同组字段值的其他要素汇总。</para>
		/// <para>如果选择一个组字段，则需要创建一个附加输出分组表格并必须指定其位置。使用组字段时需要使用该输出分组表格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object GroupField { get; set; }

		/// <summary>
		/// <para>Add minority and majority attributes</para>
		/// <para>仅当选定组字段时，才启用此选项。通过该选项，您可以确定各输入面中哪个组字段值为少数（所占比例最小），哪个为众数（所占比例最大）。</para>
		/// <para>未选中 - 不向输出添加少数和众数字段。这是默认设置。</para>
		/// <para>选中 - 向输出添加少数和众数字段。</para>
		/// <para><see cref="AddMinMajEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AddMinMaj { get; set; } = "false";

		/// <summary>
		/// <para>Add group percentages</para>
		/// <para>仅当选定组字段时，才启用此选项。您可以确定各组内各个属性值的百分比。</para>
		/// <para>未选中 - 不向输出添加百分比属性字段。这是默认设置。</para>
		/// <para>选中 - 向输出添加百分比属性字段。</para>
		/// <para><see cref="AddGroupPercentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AddGroupPercent { get; set; } = "false";

		/// <summary>
		/// <para>Output Grouped Table</para>
		/// <para>如果指定了组字段，则需要输出分组表。</para>
		/// <para>各个输入面各汇总要素组的汇总字段的输出表。该表将具有以下属性字段：</para>
		/// <para>Join_ID - 与添加到输出要素类的 ID 字段对应的 ID。</para>
		/// <para>组字段。</para>
		/// <para>形状汇总字段。</para>
		/// <para>每个汇总字段对应一个字段。</para>
		/// <para>百分比字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object OutGroupTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SummarizeWithin SetEnviroment(object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputZFlag = null , object outputZValue = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Keep all input polygons</para>
		/// </summary>
		public enum KeepAllPolygonsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_ALL")]
			KEEP_ALL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ONLY_INTERSECTING")]
			ONLY_INTERSECTING,

		}

		/// <summary>
		/// <para>Add shape summary  attributes</para>
		/// </summary>
		public enum SumShapeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_SHAPE_SUM")]
			ADD_SHAPE_SUM,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SHAPE_SUM")]
			NO_SHAPE_SUM,

		}

		/// <summary>
		/// <para>Add minority and majority attributes</para>
		/// </summary>
		public enum AddMinMajEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_MIN_MAJ")]
			ADD_MIN_MAJ,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MIN_MAJ")]
			NO_MIN_MAJ,

		}

		/// <summary>
		/// <para>Add group percentages</para>
		/// </summary>
		public enum AddGroupPercentEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_PERCENT")]
			ADD_PERCENT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PERCENT")]
			NO_PERCENT,

		}

#endregion
	}
}
