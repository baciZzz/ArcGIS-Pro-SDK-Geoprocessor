using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Generate Tessellation</para>
	/// <para>生成细分面</para>
	/// <para>用于生成覆盖给定范围的正多边形要素的镶嵌格网。该镶嵌可以是三角形、正方形、菱形、六边形或横向六边形。</para>
	/// </summary>
	public class GenerateTessellation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含镶嵌格网的输出要素类的路径和名称。</para>
		/// </param>
		/// <param name="Extent">
		/// <para>Extent</para>
		/// <para>细分曲面将覆盖的范围。该范围可以是当前可见区域、数据集的范围或手动输入值。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>输入的并集 - 该范围将基于所有输入的最大范围。</para>
		/// <para>输入的交集 - 该范围将基于所有输入共用的最小区域。</para>
		/// <para>当前显示范围 - 该范围与可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </param>
		public GenerateTessellation(object OutputFeatureClass, object Extent)
		{
			this.OutputFeatureClass = OutputFeatureClass;
			this.Extent = Extent;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成细分面</para>
		/// </summary>
		public override string DisplayName() => "生成细分面";

		/// <summary>
		/// <para>Tool Name : GenerateTessellation</para>
		/// </summary>
		public override string ToolName() => "GenerateTessellation";

		/// <summary>
		/// <para>Tool Excute Name : management.GenerateTessellation</para>
		/// </summary>
		public override string ExcuteName() => "management.GenerateTessellation";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutputFeatureClass, Extent, ShapeType, Size, SpatialReference };

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含镶嵌格网的输出要素类的路径和名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>细分曲面将覆盖的范围。该范围可以是当前可见区域、数据集的范围或手动输入值。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>输入的并集 - 该范围将基于所有输入的最大范围。</para>
		/// <para>输入的交集 - 该范围将基于所有输入共用的最小区域。</para>
		/// <para>当前显示范围 - 该范围与可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPExtent()]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Shape Type</para>
		/// <para>细分曲面的形状类型。</para>
		/// <para>六边形—边长相等的正六边形。每个六边形的上下两侧平行于坐标系的 x 轴（顶部和底部是平的）。</para>
		/// <para>横向六边形—边长相等的正六边形。每个六边形的左右两侧平行于数据集坐标系的 y 轴（顶部和底部是尖的）。</para>
		/// <para>正方形—边长相等的正四边形。每个多边形的顶端和底部平行于坐标系的 x 轴，并且左右两侧平行于坐标系的 y 轴。</para>
		/// <para>菱形—边长相等的正四边形。每个多边形的边均围绕坐标系的 x 轴和 y 轴旋转 45 度。</para>
		/// <para>三角形—正等边三角形。</para>
		/// <para><see cref="ShapeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ShapeType { get; set; } = "HEXAGON";

		/// <summary>
		/// <para>Size</para>
		/// <para>构成镶嵌的每个形状的面积。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object Size { get; set; }

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>输出数据集将投影到的空间参考。如果未提供空间参考，则输出将被投影到输入范围的空间参考中。如果空间参考也不存在，则输出将被投影到 GCS_WGS_1984。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateTessellation SetEnviroment(object XYDomain = null , object XYResolution = null , object XYTolerance = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Shape Type</para>
		/// </summary>
		public enum ShapeTypeEnum 
		{
			/// <summary>
			/// <para>正方形—边长相等的正四边形。每个多边形的顶端和底部平行于坐标系的 x 轴，并且左右两侧平行于坐标系的 y 轴。</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("正方形")]
			Square,

			/// <summary>
			/// <para>三角形—正等边三角形。</para>
			/// </summary>
			[GPValue("TRIANGLE")]
			[Description("三角形")]
			Triangle,

			/// <summary>
			/// <para>六边形—边长相等的正六边形。每个六边形的上下两侧平行于坐标系的 x 轴（顶部和底部是平的）。</para>
			/// </summary>
			[GPValue("HEXAGON")]
			[Description("六边形")]
			Hexagon,

			/// <summary>
			/// <para>菱形—边长相等的正四边形。每个多边形的边均围绕坐标系的 x 轴和 y 轴旋转 45 度。</para>
			/// </summary>
			[GPValue("DIAMOND")]
			[Description("菱形")]
			Diamond,

			/// <summary>
			/// <para>横向六边形—边长相等的正六边形。每个六边形的左右两侧平行于数据集坐标系的 y 轴（顶部和底部是尖的）。</para>
			/// </summary>
			[GPValue("TRANSVERSE_HEXAGON")]
			[Description("横向六边形")]
			Transverse_hexagon,

		}

#endregion
	}
}
