using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Slope</para>
	/// <para>坡度</para>
	/// <para>识别栅格中每个像元的坡度（梯度或陡度）。</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.SurfaceParameters"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.SurfaceParameters))]
	public class Slope : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>输入表面栅格。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出坡度栅格。</para>
		/// <para>此栅格为浮点类型。</para>
		/// </param>
		public Slope(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 坡度</para>
		/// </summary>
		public override string DisplayName() => "坡度";

		/// <summary>
		/// <para>Tool Name : 坡度</para>
		/// </summary>
		public override string ToolName() => "坡度";

		/// <summary>
		/// <para>Tool Excute Name : sa.Slope</para>
		/// </summary>
		public override string ExcuteName() => "sa.Slope";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, OutputMeasurement!, ZFactor!, Method!, ZUnit! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>输入表面栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = true)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出坡度栅格。</para>
		/// <para>此栅格为浮点类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output measurement</para>
		/// <para>确定输出坡度数据的测量单位（度或百分比）。</para>
		/// <para>度—坡度倾角将以度为单位进行计算。</para>
		/// <para>增量百分比—坡度倾角将以增量百分比进行计算，也称为百分比坡度。</para>
		/// <para><see cref="OutputMeasurementEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutputMeasurement { get; set; } = "DEGREE";

		/// <summary>
		/// <para>Z factor</para>
		/// <para>一个表面 z 单位中地面 x,y 单位的数量。</para>
		/// <para>z 单位与输入表面的 x,y 单位不同时，可使用 z 因子调整 z 单位的测量单位。 计算最终输出表面时，将用 z 因子乘以输入表面的 z 值。</para>
		/// <para>如果 x,y 单位和 z 单位采用相同的测量单位，则 z 因子为 1。 这是默认设置。</para>
		/// <para>如果 x,y 单位和 z 单位采用不同的测量单位，则必须将 z 因子设置为适当的因子，否则会得到错误的结果。 例如，如果 z 单位是英尺，而 x,y 单位是米，则应使用 z 因子 0.3048 将 z 单位从英尺转换为米（1 英尺 = 0.3048 米）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Method</para>
		/// <para>指定计算将基于平面（平地）还是测地线（椭球）方法。</para>
		/// <para>平面—将使用 2D 笛卡尔坐标系对投影平面执行计算。 这是默认方法。</para>
		/// <para>测地线—通过将地球形状视为椭球体，在 3D 笛卡尔坐标系中执行计算。</para>
		/// <para>平面方法适用于保持正确距离和面积的投影中的局部区域。 适用于覆盖诸如城市、县或面积较小的州等区域的分析。 测地线方法可以产生更精确的结果，但会造成处理时间这一潜在成本增加。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Z unit</para>
		/// <para>垂直 z 值的线性单位。</para>
		/// <para>由垂直坐标系（如果存在）定义。 如果垂直坐标系不存在，则应根据单位列表来定义 z 单位，以确保测地线计算正确。 默认单位为米。</para>
		/// <para>英寸—线性单位将为英寸。</para>
		/// <para>英尺—线性单位将为英尺。</para>
		/// <para>码—线性单位将为码。</para>
		/// <para>英里(美制)—线性单位将为英里。</para>
		/// <para>海里—线性单位将为海里。</para>
		/// <para>毫米—线性单位将为毫米。</para>
		/// <para>厘米—线性单位将为厘米。</para>
		/// <para>米—线性单位将为米。</para>
		/// <para>千米—线性单位将为公里。</para>
		/// <para>分米—线性单位将为分米。</para>
		/// <para><see cref="ZUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ZUnit { get; set; } = "METER";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Slope SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output measurement</para>
		/// </summary>
		public enum OutputMeasurementEnum 
		{
			/// <summary>
			/// <para>度—坡度倾角将以度为单位进行计算。</para>
			/// </summary>
			[GPValue("DEGREE")]
			[Description("度")]
			Degree,

			/// <summary>
			/// <para>增量百分比—坡度倾角将以增量百分比进行计算，也称为百分比坡度。</para>
			/// </summary>
			[GPValue("PERCENT_RISE")]
			[Description("增量百分比")]
			Percent_rise,

		}

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>平面—将使用 2D 笛卡尔坐标系对投影平面执行计算。 这是默认方法。</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("平面")]
			Planar,

			/// <summary>
			/// <para>测地线—通过将地球形状视为椭球体，在 3D 笛卡尔坐标系中执行计算。</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("测地线")]
			Geodesic,

		}

		/// <summary>
		/// <para>Z unit</para>
		/// </summary>
		public enum ZUnitEnum 
		{
			/// <summary>
			/// <para>英寸—线性单位将为英寸。</para>
			/// </summary>
			[GPValue("INCH")]
			[Description("英寸")]
			Inch,

			/// <summary>
			/// <para>英尺—线性单位将为英尺。</para>
			/// </summary>
			[GPValue("FOOT")]
			[Description("英尺")]
			Foot,

			/// <summary>
			/// <para>码—线性单位将为码。</para>
			/// </summary>
			[GPValue("YARD")]
			[Description("码")]
			Yard,

			/// <summary>
			/// <para>英里(美制)—线性单位将为英里。</para>
			/// </summary>
			[GPValue("MILE_US")]
			[Description("英里(美制)")]
			Mile_US,

			/// <summary>
			/// <para>海里—线性单位将为海里。</para>
			/// </summary>
			[GPValue("NAUTICAL_MILE")]
			[Description("海里")]
			Nautical_mile,

			/// <summary>
			/// <para>毫米—线性单位将为毫米。</para>
			/// </summary>
			[GPValue("MILLIMETER")]
			[Description("毫米")]
			Millimeter,

			/// <summary>
			/// <para>厘米—线性单位将为厘米。</para>
			/// </summary>
			[GPValue("CENTIMETER")]
			[Description("厘米")]
			Centimeter,

			/// <summary>
			/// <para>米—线性单位将为米。</para>
			/// </summary>
			[GPValue("METER")]
			[Description("米")]
			Meter,

			/// <summary>
			/// <para>千米—线性单位将为公里。</para>
			/// </summary>
			[GPValue("KILOMETER")]
			[Description("千米")]
			Kilometer,

			/// <summary>
			/// <para>分米—线性单位将为分米。</para>
			/// </summary>
			[GPValue("DECIMETER")]
			[Description("分米")]
			Decimeter,

		}

#endregion
	}
}
