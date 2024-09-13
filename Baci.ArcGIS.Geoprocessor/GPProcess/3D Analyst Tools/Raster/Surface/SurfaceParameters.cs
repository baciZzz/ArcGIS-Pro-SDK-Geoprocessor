using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Surface Parameters</para>
	/// <para>表面参数</para>
	/// <para>确定栅格表面的参数，例如坡向、坡度和曲率。</para>
	/// </summary>
	public class SurfaceParameters : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input surface raster</para>
		/// <para>输入表面栅格。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// <para>此栅格为浮点类型。</para>
		/// </param>
		public SurfaceParameters(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
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
		/// <para>Tool Excute Name : 3d.SurfaceParameters</para>
		/// </summary>
		public override string ExcuteName() => "3d.SurfaceParameters";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, ParameterType, LocalSurfaceType, NeighborhoodDistance, UseAdaptiveNeighborhood, ZUnit, OutputSlopeMeasurement, ProjectGeodesicAzimuths, UseEquatorialAspect };

		/// <summary>
		/// <para>Input surface raster</para>
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
		/// <para>输出栅格。</para>
		/// <para>此栅格为浮点类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Parameter type</para>
		/// <para>确定要计算的输出表面参数类型。</para>
		/// <para>坡度—高程变化率。 这是默认设置。</para>
		/// <para>坡向—每个像元的最大变化率的下坡方向。</para>
		/// <para>平均曲率—测量表面的总曲率。 计算最小曲率和最大曲率的平均值即可获得平均曲率。 此曲率可描述表面的固有凸度或凹度，与方向或重力影响无关。</para>
		/// <para>切向（标准等高线）曲率—在垂直于坡度线且与等值线相切的位置处测量几何法曲率。 通常应用此曲率来表征流经某表面的流的汇聚和分散。</para>
		/// <para>剖面（法向坡度线）曲率—沿坡度线测量几何法曲率。 通常应用此曲率来表征流经某表面的流的加速和减速。</para>
		/// <para><see cref="ParameterTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ParameterType { get; set; } = "SLOPE";

		/// <summary>
		/// <para>Local surface type</para>
		/// <para>确定在目标像元周围拟合的表面函数的类型。</para>
		/// <para>二次—将二次表面函数拟合到邻域像元。 这是默认设置。</para>
		/// <para>双二次—将双二次表面函数拟合到邻域单元。</para>
		/// <para><see cref="LocalSurfaceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LocalSurfaceType { get; set; } = "QUADRATIC";

		/// <summary>
		/// <para>Neighborhood distance</para>
		/// <para>根据与目标像元中心之间的这一距离计算输出。 邻域距离可确定邻域大小。</para>
		/// <para>默认值为输入栅格像元大小，可生成 3 x 3 邻域。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object NeighborhoodDistance { get; set; }

		/// <summary>
		/// <para>Use adaptive neighborhood</para>
		/// <para>允许邻域距离随地表变化而变化。 最大距离由邻域距离确定。 最小距离为输入栅格像元大小。</para>
		/// <para>未选中 - 在所有位置使用单一（固定）邻域距离。 这是默认设置。</para>
		/// <para>选中 - 在所有位置使用自适应邻域距离。</para>
		/// <para><see cref="UseAdaptiveNeighborhoodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseAdaptiveNeighborhood { get; set; } = "false";

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
		public object ZUnit { get; set; } = "METER";

		/// <summary>
		/// <para>Output slope measurement</para>
		/// <para>当参数类型为坡度时，确定输出坡度栅格的测量单位（度或百分比）。</para>
		/// <para>度—坡度倾角将以度为单位进行计算。</para>
		/// <para>增量百分比—坡度倾角将以增量百分比进行计算，也称为百分比坡度。</para>
		/// <para><see cref="OutputSlopeMeasurementEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputSlopeMeasurement { get; set; } = "DEGREE";

		/// <summary>
		/// <para>Project geodesic azimuths</para>
		/// <para>指定是否将投影测地线方位角以校正由输出空间参考引起的角度失真。</para>
		/// <para>未选中 - 将不会投影测地线方位角。 这是默认设置。</para>
		/// <para>选中 - 将投影测地线方位角。</para>
		/// <para><see cref="ProjectGeodesicAzimuthsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ProjectGeodesicAzimuths { get; set; } = "false";

		/// <summary>
		/// <para>Use equatorial aspect</para>
		/// <para>从赤道上的一点测量坡向。</para>
		/// <para>未选中 - 从北极测量坡向。 这是默认设置。</para>
		/// <para>选中 - 从赤道上的一点测量坡向。</para>
		/// <para><see cref="UseEquatorialAspectEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseEquatorialAspect { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SurfaceParameters SetEnviroment(int? autoCommit = null , object cellSize = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Parameter type</para>
		/// </summary>
		public enum ParameterTypeEnum 
		{
			/// <summary>
			/// <para>坡度—高程变化率。 这是默认设置。</para>
			/// </summary>
			[GPValue("SLOPE")]
			[Description("坡度")]
			Slope,

			/// <summary>
			/// <para>坡向—每个像元的最大变化率的下坡方向。</para>
			/// </summary>
			[GPValue("ASPECT")]
			[Description("坡向")]
			Aspect,

			/// <summary>
			/// <para>平均曲率—测量表面的总曲率。 计算最小曲率和最大曲率的平均值即可获得平均曲率。 此曲率可描述表面的固有凸度或凹度，与方向或重力影响无关。</para>
			/// </summary>
			[GPValue("MEAN_CURVATURE")]
			[Description("平均曲率")]
			Mean_curvature,

			/// <summary>
			/// <para>剖面（法向坡度线）曲率—沿坡度线测量几何法曲率。 通常应用此曲率来表征流经某表面的流的加速和减速。</para>
			/// </summary>
			[GPValue("PROFILE_CURVATURE")]
			[Description("剖面（法向坡度线）曲率")]
			PROFILE_CURVATURE,

			/// <summary>
			/// <para>切向（标准等高线）曲率—在垂直于坡度线且与等值线相切的位置处测量几何法曲率。 通常应用此曲率来表征流经某表面的流的汇聚和分散。</para>
			/// </summary>
			[GPValue("TANGENTIAL_CURVATURE")]
			[Description("切向（标准等高线）曲率")]
			TANGENTIAL_CURVATURE,

		}

		/// <summary>
		/// <para>Local surface type</para>
		/// </summary>
		public enum LocalSurfaceTypeEnum 
		{
			/// <summary>
			/// <para>二次—将二次表面函数拟合到邻域像元。 这是默认设置。</para>
			/// </summary>
			[GPValue("QUADRATIC")]
			[Description("二次")]
			Quadratic,

			/// <summary>
			/// <para>双二次—将双二次表面函数拟合到邻域单元。</para>
			/// </summary>
			[GPValue("BIQUADRATIC")]
			[Description("双二次")]
			Biquadratic,

		}

		/// <summary>
		/// <para>Use adaptive neighborhood</para>
		/// </summary>
		public enum UseAdaptiveNeighborhoodEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("FIXED_NEIGHBORHOOD")]
			FIXED_NEIGHBORHOOD,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADAPTIVE_NEIGHBORHOOD")]
			ADAPTIVE_NEIGHBORHOOD,

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

		/// <summary>
		/// <para>Output slope measurement</para>
		/// </summary>
		public enum OutputSlopeMeasurementEnum 
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
		/// <para>Project geodesic azimuths</para>
		/// </summary>
		public enum ProjectGeodesicAzimuthsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("GEODESIC_AZIMUTHS")]
			GEODESIC_AZIMUTHS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PROJECT_GEODESIC_AZIMUTHS")]
			PROJECT_GEODESIC_AZIMUTHS,

		}

		/// <summary>
		/// <para>Use equatorial aspect</para>
		/// </summary>
		public enum UseEquatorialAspectEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NORTH_POLE_ASPECT")]
			NORTH_POLE_ASPECT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EQUATORIAL_ASPECT")]
			EQUATORIAL_ASPECT,

		}

#endregion
	}
}
