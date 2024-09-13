using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CartographyTools
{
	/// <summary>
	/// <para>Aggregate Polygons</para>
	/// <para>聚合面</para>
	/// <para>将指定距离内的面要素合并成新的面要素。</para>
	/// </summary>
	public class AggregatePolygons : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要聚合的面要素。 如果这是一个引用某个制图表达的图层，并且在输入要素中存在形状覆盖，则在聚合处理中将采用这些覆盖的形状、而不是要素形状。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>要创建的输出要素类。</para>
		/// </param>
		/// <param name="AggregationDistance">
		/// <para>Aggregation Distance</para>
		/// <para>聚合时面要素边界间要满足的距离。 必须指定一个距离，且此距离必须大于零。 可以选择首选单位；默认为要素单位。</para>
		/// </param>
		public AggregatePolygons(object InFeatures, object OutFeatureClass, object AggregationDistance)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.AggregationDistance = AggregationDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : 聚合面</para>
		/// </summary>
		public override string DisplayName() => "聚合面";

		/// <summary>
		/// <para>Tool Name : AggregatePolygons</para>
		/// </summary>
		public override string ToolName() => "AggregatePolygons";

		/// <summary>
		/// <para>Tool Excute Name : cartography.AggregatePolygons</para>
		/// </summary>
		public override string ExcuteName() => "cartography.AggregatePolygons";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise() => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "XYDomain", "XYTolerance", "cartographicPartitions", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, AggregationDistance, MinimumArea, MinimumHoleSize, OrthogonalityOption, BarrierFeatures, OutTable, AggregateField };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要聚合的面要素。 如果这是一个引用某个制图表达的图层，并且在输入要素中存在形状覆盖，则在聚合处理中将采用这些覆盖的形状、而不是要素形状。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>要创建的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Aggregation Distance</para>
		/// <para>聚合时面要素边界间要满足的距离。 必须指定一个距离，且此距离必须大于零。 可以选择首选单位；默认为要素单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object AggregationDistance { get; set; }

		/// <summary>
		/// <para>Minimum Area</para>
		/// <para>聚合面得以保留的最小面积。 默认值为零，即保留所有面。 可以指定首选单位；默认为要素单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object MinimumArea { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Minimum Hole Size</para>
		/// <para>面要素中的孔洞得以保留的最小大小。 默认值为零，即保留所有面要素中的孔洞。 可以指定首选单位；默认为要素单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object MinimumHoleSize { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Preserve orthogonal shape</para>
		/// <para>指定构造聚合边界时输出要素的特征。</para>
		/// <para>不选中 - 将创建有机形状的输出要素。 这适用于自然要素，例如，植被或土壤多边形。 这是默认设置。</para>
		/// <para>选中 - 将创建正交形状的输出要素。 此选项适用于保留人为输入要素的几何特性，例如，建筑物轮廓线。</para>
		/// <para><see cref="OrthogonalityOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object OrthogonalityOption { get; set; } = "false";

		/// <summary>
		/// <para>Barrier Features</para>
		/// <para>包含在输入要素中作为聚合障碍的线要素或面要素的图层。 要素不会跨障碍要素聚合。 与输入要素存在几何冲突的障碍要素将被忽略。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object BarrierFeatures { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>将聚合的面连接到其源面要素的一对多关系表。 该表包含两个字段（OUTPUT_FID 和 INPUT_FID），分别用于存储聚合要素 ID 和其源要素 ID。 使用此表根据源要素派生输出要素的必要属性。 该表的默认名称为输出要素类名称加上 _tbl。 默认路径与输出要素类相同。 当该参数留空时，不创建任何表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Aggregate Field</para>
		/// <para>包含聚合属性的字段。 要素必须共享相同的属性值才能进行聚合。 例如，可将建筑物分类字段用作聚合字段，以防止商业建筑物与住宅建筑物聚合在一起。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "Date")]
		public object AggregateField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AggregatePolygons SetEnviroment(object MDomain = null , object XYDomain = null , object XYTolerance = null , object cartographicPartitions = null , object extent = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, XYDomain: XYDomain, XYTolerance: XYTolerance, cartographicPartitions: cartographicPartitions, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Preserve orthogonal shape</para>
		/// </summary>
		public enum OrthogonalityOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ORTHOGONAL")]
			ORTHOGONAL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NON_ORTHOGONAL")]
			NON_ORTHOGONAL,

		}

#endregion
	}
}
