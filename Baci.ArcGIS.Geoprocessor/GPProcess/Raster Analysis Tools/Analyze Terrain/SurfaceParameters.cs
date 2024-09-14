using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.RasterAnalysisTools
{
	/// <summary>
	/// <para>Surface Parameters</para>
	/// <para>表面参数</para>
	/// <para>使用测地线方法确定表面栅格的参数，例如坡向、坡度和多种类型的曲率。</para>
	/// </summary>
	public class SurfaceParameters : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputsurfaceraster">
		/// <para>Input Surface Raster</para>
		/// <para>输入表面栅格。 可为整型或浮点型。</para>
		/// </param>
		/// <param name="Outputrastername">
		/// <para>Output Raster Name</para>
		/// <para>输出栅格服务的名称。</para>
		/// </param>
		public SurfaceParameters(object Inputsurfaceraster, object Outputrastername)
		{
			this.Inputsurfaceraster = Inputsurfaceraster;
			this.Outputrastername = Outputrastername;
		}

		/// <summary>
		/// <para>Tool Display Name : 表面参数</para>
		/// </summary>
		public override string DisplayName() => "表面参数";

		/// <summary>
		/// <para>Tool Name : SurfaceParameters</para>
		/// </summary>
		public override string ToolName() => "SurfaceParameters";

		/// <summary>
		/// <para>Tool Excute Name : ra.SurfaceParameters</para>
		/// </summary>
		public override string ExcuteName() => "ra.SurfaceParameters";

		/// <summary>
		/// <para>Toolbox Display Name : Raster Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Raster Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : ra</para>
		/// </summary>
		public override string ToolboxAlise() => "ra";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "pyramid", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputsurfaceraster, Outputrastername, Parametertype!, Localsurfacetype!, Neighborhooddistance!, Useadaptiveneighborhood!, Zunit!, Outputslopemeasurement!, Projectgeodesicazimuths!, Useequatorialaspect!, Outputraster! };

		/// <summary>
		/// <para>Input Surface Raster</para>
		/// <para>输入表面栅格。 可为整型或浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputsurfaceraster { get; set; }

		/// <summary>
		/// <para>Output Raster Name</para>
		/// <para>输出栅格服务的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputrastername { get; set; }

		/// <summary>
		/// <para>Parameter Type</para>
		/// <para>指定要计算的输出表面参数类型。</para>
		/// <para>坡度—将计算高程变化率。 这是默认设置。</para>
		/// <para>坡向—将计算每个像元的最大变化率的下坡方向。</para>
		/// <para>平均曲率—将计算表面的总曲率。 计算最小曲率和最大曲率的平均值即可获得平均曲率。 此曲率可描述表面的固有凸度或凹度，与方向或重力影响无关。</para>
		/// <para>切向（标准等高线）曲率—将计算垂直于坡度线且与等值线相切的几何法曲率。 通常应用此曲率来表征流经某表面的流的汇聚和分散。</para>
		/// <para>剖面（法向坡度线）曲率—将计算沿坡度线的几何法曲率。 通常应用此曲率来表征流经某表面的流的加速和减速。</para>
		/// <para>平面（投影等值线）曲率—将计算沿等值线的曲率。</para>
		/// <para>等值测地线扭转—将计算沿等值线的坡度角变化率。</para>
		/// <para>高斯曲率—将计算表面的总曲率。 计算最小曲率和最大曲率的结果即可获得平均曲率。</para>
		/// <para>Casorati 曲率—将计算表面的总曲率。 该值可为零或任意其他正数。</para>
		/// <para><see cref="ParametertypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Parametertype { get; set; } = "SLOPE";

		/// <summary>
		/// <para>Local Surface Type</para>
		/// <para>指定在目标像元周围拟合的表面函数的类型。</para>
		/// <para>二次—将二次表面函数拟合到邻域像元。 这是默认设置。</para>
		/// <para>双二次—将四次表面函数拟合到邻域像元。</para>
		/// <para><see cref="LocalsurfacetypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Localsurfacetype { get; set; } = "QUADRATIC";

		/// <summary>
		/// <para>Neighborhood Distance</para>
		/// <para>根据与目标像元中心之间的这一距离计算输出。 邻域距离可确定邻域大小。</para>
		/// <para>默认值为输入栅格像元大小，可生成 3 x 3 邻域。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? Neighborhooddistance { get; set; }

		/// <summary>
		/// <para>Use Adaptive Neighborhood</para>
		/// <para>指定邻域距离是否随地表变化而变化（自适应）。 最大距离由邻域距离确定。 最小距离为输入栅格像元大小。</para>
		/// <para>未选中 - 在所有位置使用单一（固定）邻域距离。 这是默认设置。</para>
		/// <para>选中 - 在所有位置使用自适应邻域距离。</para>
		/// <para><see cref="UseadaptiveneighborhoodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Useadaptiveneighborhood { get; set; } = "false";

		/// <summary>
		/// <para>Z Unit</para>
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
		/// <para><see cref="ZunitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Zunit { get; set; } = "METER";

		/// <summary>
		/// <para>Output Slope Measurement</para>
		/// <para>将用于输出坡度栅格的测量单位（度或百分比）。 仅当将参数类型设置为坡度时，此参数才处于活动状态。</para>
		/// <para>度—坡度倾角将以度为单位进行计算。</para>
		/// <para>增量百分比—坡度倾角将以增量百分比进行计算，也称为百分比坡度。</para>
		/// <para><see cref="OutputslopemeasurementEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Outputslopemeasurement { get; set; } = "DEGREE";

		/// <summary>
		/// <para>Project Geodesic Azimuths</para>
		/// <para>指定是否将投影测地线方位角以校正由输出空间参考引起的角度失真。</para>
		/// <para>未选中 - 将不会投影测地线方位角。 这是默认设置。</para>
		/// <para>选中 - 将投影测地线方位角。</para>
		/// <para><see cref="ProjectgeodesicazimuthsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Projectgeodesicazimuths { get; set; } = "false";

		/// <summary>
		/// <para>Use Equatorial Aspect</para>
		/// <para>指定是从赤道上的点还是从北极测量坡向。</para>
		/// <para>未选中 - 将从北极测量坡向。 这是默认设置。</para>
		/// <para>选中 - 将从赤道上的点测量坡向。</para>
		/// <para><see cref="UseequatorialaspectEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Useequatorialaspect { get; set; } = "false";

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SurfaceParameters SetEnviroment(object? cellSize = null, object? extent = null, object? mask = null, object? outputCoordinateSystem = null, object? pyramid = null, object? snapRaster = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Parameter Type</para>
		/// </summary>
		public enum ParametertypeEnum 
		{
			/// <summary>
			/// <para>坡度—将计算高程变化率。 这是默认设置。</para>
			/// </summary>
			[GPValue("SLOPE")]
			[Description("坡度")]
			Slope,

			/// <summary>
			/// <para>坡向—将计算每个像元的最大变化率的下坡方向。</para>
			/// </summary>
			[GPValue("ASPECT")]
			[Description("坡向")]
			Aspect,

			/// <summary>
			/// <para>平均曲率—将计算表面的总曲率。 计算最小曲率和最大曲率的平均值即可获得平均曲率。 此曲率可描述表面的固有凸度或凹度，与方向或重力影响无关。</para>
			/// </summary>
			[GPValue("MEAN_CURVATURE")]
			[Description("平均曲率")]
			Mean_curvature,

			/// <summary>
			/// <para>切向（标准等高线）曲率—将计算垂直于坡度线且与等值线相切的几何法曲率。 通常应用此曲率来表征流经某表面的流的汇聚和分散。</para>
			/// </summary>
			[GPValue("TANGENTIAL_CURVATURE")]
			[Description("切向（标准等高线）曲率")]
			TANGENTIAL_CURVATURE,

			/// <summary>
			/// <para>剖面（法向坡度线）曲率—将计算沿坡度线的几何法曲率。 通常应用此曲率来表征流经某表面的流的加速和减速。</para>
			/// </summary>
			[GPValue("PROFILE_CURVATURE")]
			[Description("剖面（法向坡度线）曲率")]
			PROFILE_CURVATURE,

			/// <summary>
			/// <para>平面（投影等值线）曲率—将计算沿等值线的曲率。</para>
			/// </summary>
			[GPValue("CONTOUR_CURVATURE")]
			[Description("平面（投影等值线）曲率")]
			CONTOUR_CURVATURE,

			/// <summary>
			/// <para>等值测地线扭转—将计算沿等值线的坡度角变化率。</para>
			/// </summary>
			[GPValue("CONTOUR_GEODESIC_TORSION")]
			[Description("等值测地线扭转")]
			Contour_geodesic_torsion,

			/// <summary>
			/// <para>高斯曲率—将计算表面的总曲率。 计算最小曲率和最大曲率的结果即可获得平均曲率。</para>
			/// </summary>
			[GPValue("GAUSSIAN_CURVATURE")]
			[Description("高斯曲率")]
			Gaussian_curvature,

			/// <summary>
			/// <para>Casorati 曲率—将计算表面的总曲率。 该值可为零或任意其他正数。</para>
			/// </summary>
			[GPValue("CASORATI_CURVATURE")]
			[Description("Casorati 曲率")]
			Casorati_curvature,

		}

		/// <summary>
		/// <para>Local Surface Type</para>
		/// </summary>
		public enum LocalsurfacetypeEnum 
		{
			/// <summary>
			/// <para>二次—将二次表面函数拟合到邻域像元。 这是默认设置。</para>
			/// </summary>
			[GPValue("QUADRATIC")]
			[Description("二次")]
			Quadratic,

			/// <summary>
			/// <para>双二次—将四次表面函数拟合到邻域像元。</para>
			/// </summary>
			[GPValue("BIQUADRATIC")]
			[Description("双二次")]
			Biquadratic,

		}

		/// <summary>
		/// <para>Use Adaptive Neighborhood</para>
		/// </summary>
		public enum UseadaptiveneighborhoodEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADAPTIVE_NEIGHBORHOOD")]
			ADAPTIVE_NEIGHBORHOOD,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("FIXED_NEIGHBORHOOD")]
			FIXED_NEIGHBORHOOD,

		}

		/// <summary>
		/// <para>Z Unit</para>
		/// </summary>
		public enum ZunitEnum 
		{
			/// <summary>
			/// <para>米—线性单位将为米。</para>
			/// </summary>
			[GPValue("METER")]
			[Description("米")]
			Meter,

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

		/// <summary>
		/// <para>Output Slope Measurement</para>
		/// </summary>
		public enum OutputslopemeasurementEnum 
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
		/// <para>Project Geodesic Azimuths</para>
		/// </summary>
		public enum ProjectgeodesicazimuthsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PROJECT_GEODESIC_AZIMUTHS")]
			PROJECT_GEODESIC_AZIMUTHS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("GEODESIC_AZIMUTHS")]
			GEODESIC_AZIMUTHS,

		}

		/// <summary>
		/// <para>Use Equatorial Aspect</para>
		/// </summary>
		public enum UseequatorialaspectEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EQUATORIAL_ASPECT")]
			EQUATORIAL_ASPECT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NORTH_POLE_ASPECT")]
			NORTH_POLE_ASPECT,

		}

#endregion
	}
}
