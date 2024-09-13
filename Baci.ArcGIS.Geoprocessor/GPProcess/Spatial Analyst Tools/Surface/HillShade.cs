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
	/// <para>Hillshade</para>
	/// <para>山体阴影</para>
	/// <para>通过考虑光照源的角度和阴影，根据表面栅格创建地貌晕渲。</para>
	/// </summary>
	public class HillShade : AbstractGPProcess
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
		/// <para>输出山体阴影栅格。</para>
		/// <para>山体阴影栅格的整数值范围为 0 到 255。</para>
		/// </param>
		public HillShade(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 山体阴影</para>
		/// </summary>
		public override string DisplayName() => "山体阴影";

		/// <summary>
		/// <para>Tool Name : HillShade</para>
		/// </summary>
		public override string ToolName() => "HillShade";

		/// <summary>
		/// <para>Tool Excute Name : sa.HillShade</para>
		/// </summary>
		public override string ExcuteName() => "sa.HillShade";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, Azimuth!, Altitude!, ModelShadows!, ZFactor! };

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
		/// <para>输出山体阴影栅格。</para>
		/// <para>山体阴影栅格的整数值范围为 0 到 255。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Azimuth</para>
		/// <para>光源的方位角。</para>
		/// <para>方位角由 0 到 360 度之间的正度数表示，以北为基准方向按顺时针进行测量。</para>
		/// <para>默认值为 315 度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 360)]
		public object? Azimuth { get; set; } = "315";

		/// <summary>
		/// <para>Altitude</para>
		/// <para>高于地平线的光源高度角。</para>
		/// <para>高度角由正度数表示，0 度代表地平线，而 90 度代表头顶正上方。</para>
		/// <para>默认值为 45 度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 90)]
		public object? Altitude { get; set; } = "45";

		/// <summary>
		/// <para>Model shadows</para>
		/// <para>要生成的地貌晕渲类型。</para>
		/// <para>未选中 - 输出栅格只会考虑本地光照入射角度而不会考虑阴影的影响。输出值的范围从 0 到 255，0 表示最暗区域，255 表示最亮区域。这是默认设置。</para>
		/// <para>选中 - 输出晕渲栅格会同时考虑本地光照入射角度和阴影。输出值的范围从 0 到 255，0 表示阴影区域，255 表示最亮区域。</para>
		/// <para><see cref="ModelShadowsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ModelShadows { get; set; } = "false";

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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public HillShade SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Model shadows</para>
		/// </summary>
		public enum ModelShadowsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SHADOWS")]
			NO_SHADOWS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SHADOWS")]
			SHADOWS,

		}

#endregion
	}
}
