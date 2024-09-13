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
	/// <para>Thin</para>
	/// <para>细化</para>
	/// <para>通过减少表示要素宽度的像元数来对栅格化的线状要素进行细化。</para>
	/// </summary>
	public class Thin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>要进行细化的输入栅格。</para>
		/// <para>必须为整型。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>细化的输出栅格。</para>
		/// <para>输出始终为整型。</para>
		/// </param>
		public Thin(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 细化</para>
		/// </summary>
		public override string DisplayName() => "细化";

		/// <summary>
		/// <para>Tool Name : 细化</para>
		/// </summary>
		public override string ToolName() => "细化";

		/// <summary>
		/// <para>Tool Excute Name : sa.Thin</para>
		/// </summary>
		public override string ExcuteName() => "sa.Thin";

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
		public override object[] Parameters() => new object[] { InRaster, OutRaster, BackgroundValue, Filter, Corners, MaximumThickness };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>要进行细化的输入栅格。</para>
		/// <para>必须为整型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>细化的输出栅格。</para>
		/// <para>输出始终为整型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Background value</para>
		/// <para>指定用于识别背景像元的像元值。线状要素将基于前景像元生成。</para>
		/// <para>零—背景由 0 像元、负值像元或 NoData 像元组成。值大于 0 的所有像元均为前景像元。</para>
		/// <para>NoData— 背景由 NoData 像元组成。所有具备有效值的单元均属于前景单元。</para>
		/// <para><see cref="BackgroundValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BackgroundValue { get; set; } = "ZERO";

		/// <summary>
		/// <para>Filter input first</para>
		/// <para>指定是否要在细化的第一阶段使用过滤器。</para>
		/// <para>未选中 - 不应用任何过滤器。这是默认设置。</para>
		/// <para>选中 - 将过滤栅格以平滑前景像元和背景像元间的边界。此选项将排除输出栅格中次要的不规则内容。</para>
		/// <para><see cref="FilterEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Filter { get; set; } = "false";

		/// <summary>
		/// <para>Shape for corners</para>
		/// <para>指定在转弯处或交汇点处使用平滑拐角还是尖锐拐角。</para>
		/// <para>在样条化曲线或创建尖锐交点和拐角等矢量转换过程中，同样会使用此选项。</para>
		/// <para>圆形— 尝试对拐角处和交汇点处进行平滑。对等值线或河流等自然要素进行矢量化时，最好选中此选项。</para>
		/// <para>尖锐— 尝试保留直角拐角和交汇点。对街道等人造要素进行矢量化时，最好选中此选项。</para>
		/// <para><see cref="CornersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Corners { get; set; } = "ROUND";

		/// <summary>
		/// <para>Maximum thickness of input linear features</para>
		/// <para>输入栅格中线状要素的最大线宽（以地图单位表示）。</para>
		/// <para>默认线宽是像元大小的十倍。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object MaximumThickness { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Thin SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Background value</para>
		/// </summary>
		public enum BackgroundValueEnum 
		{
			/// <summary>
			/// <para>零—背景由 0 像元、负值像元或 NoData 像元组成。值大于 0 的所有像元均为前景像元。</para>
			/// </summary>
			[GPValue("ZERO")]
			[Description("零")]
			Zero,

			/// <summary>
			/// <para>NoData— 背景由 NoData 像元组成。所有具备有效值的单元均属于前景单元。</para>
			/// </summary>
			[GPValue("NODATA")]
			[Description("NoData")]
			NoData,

		}

		/// <summary>
		/// <para>Filter input first</para>
		/// </summary>
		public enum FilterEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FILTER")]
			NO_FILTER,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FILTER")]
			FILTER,

		}

		/// <summary>
		/// <para>Shape for corners</para>
		/// </summary>
		public enum CornersEnum 
		{
			/// <summary>
			/// <para>圆形— 尝试对拐角处和交汇点处进行平滑。对等值线或河流等自然要素进行矢量化时，最好选中此选项。</para>
			/// </summary>
			[GPValue("ROUND")]
			[Description("圆形")]
			Round,

			/// <summary>
			/// <para>尖锐— 尝试保留直角拐角和交汇点。对街道等人造要素进行矢量化时，最好选中此选项。</para>
			/// </summary>
			[GPValue("SHARP")]
			[Description("尖锐")]
			Sharp,

		}

#endregion
	}
}
