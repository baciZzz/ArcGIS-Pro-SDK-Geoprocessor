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
	/// <para>Observer Points</para>
	/// <para>视点分析</para>
	/// <para>识别从各栅格表面位置进行观察时可见的观察点。</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.Analyst3DTools.Viewshed2"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.Analyst3DTools.Viewshed2))]
	public class ObserverPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>输入表面栅格。</para>
		/// </param>
		/// <param name="InObserverPointFeatures">
		/// <para>Input point observer features</para>
		/// <para>用于识别观察点位置的点要素类。</para>
		/// <para>允许的最大点数为 16。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// <para>输出将精确识别从各栅格表面位置进行观察时可见的观察点。</para>
		/// </param>
		public ObserverPoints(object InRaster, object InObserverPointFeatures, object OutRaster)
		{
			this.InRaster = InRaster;
			this.InObserverPointFeatures = InObserverPointFeatures;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 视点分析</para>
		/// </summary>
		public override string DisplayName() => "视点分析";

		/// <summary>
		/// <para>Tool Name : ObserverPoints</para>
		/// </summary>
		public override string ToolName() => "ObserverPoints";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ObserverPoints</para>
		/// </summary>
		public override string ExcuteName() => "3d.ObserverPoints";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, InObserverPointFeatures, OutRaster, ZFactor, CurvatureCorrection, RefractivityCoefficient, OutAglRaster };

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
		/// <para>Input point observer features</para>
		/// <para>用于识别观察点位置的点要素类。</para>
		/// <para>允许的最大点数为 16。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer")]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		[GeometryType("Point", "Multipoint")]
		public object InObserverPointFeatures { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// <para>输出将精确识别从各栅格表面位置进行观察时可见的观察点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

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
		public object ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Use earth curvature corrections</para>
		/// <para>指定是否将应用地球曲率校正。</para>
		/// <para>未选中 - 不应用任何曲率校正。 这是默认设置。</para>
		/// <para>选中 - 应用曲率校正。</para>
		/// <para><see cref="CurvatureCorrectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CurvatureCorrection { get; set; } = "false";

		/// <summary>
		/// <para>Refractivity coefficient</para>
		/// <para>空气中可见光的折射系数。</para>
		/// <para>默认值为 0.13。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object RefractivityCoefficient { get; set; } = "0.13";

		/// <summary>
		/// <para>Output above ground level raster</para>
		/// <para>地面以上 (AGL) 输出栅格。</para>
		/// <para>AGL 结果是一个栅格，其中每个像元值都记录了为保证像元至少对一个观察点可见而需要向该像元添加的最小高度（若不添加此高度，像元不可见）。</para>
		/// <para>在输出栅格中已可见像元的值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutAglRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ObserverPoints SetEnviroment(int? autoCommit = null, object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Use earth curvature corrections</para>
		/// </summary>
		public enum CurvatureCorrectionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("FLAT_EARTH")]
			FLAT_EARTH,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CURVED_EARTH")]
			CURVED_EARTH,

		}

#endregion
	}
}
