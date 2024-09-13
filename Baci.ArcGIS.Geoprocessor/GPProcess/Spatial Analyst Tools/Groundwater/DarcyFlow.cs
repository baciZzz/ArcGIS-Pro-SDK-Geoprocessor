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
	/// <para>Darcy Flow</para>
	/// <para>达西流</para>
	/// <para>计算蓄水层中稳流的地下水量平衡残差以及其他输出。</para>
	/// </summary>
	public class DarcyFlow : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InHeadRaster">
		/// <para>Input groundwater head elevation raster</para>
		/// <para>所包含的每一单元值都代表该处地下水位高程的输入栅格。</para>
		/// <para>水位通常是高于某些基准面（如平均海平面）的高程。</para>
		/// </param>
		/// <param name="InPorosityRaster">
		/// <para>Input effective formation porosity raster</para>
		/// <para>所包含的每一单元值都代表该处有效地层孔隙度的输入栅格。</para>
		/// </param>
		/// <param name="InThicknessRaster">
		/// <para>Input saturated thickness raster</para>
		/// <para>所包含的每一单元值都代表该处饱和厚度的输入栅格。</para>
		/// <para>厚度值根据蓄水层的地质属性进行解释。</para>
		/// </param>
		/// <param name="InTransmissivityRaster">
		/// <para>Input formation transmissivity raster</para>
		/// <para>所包含的每一单元值都代表该地层导水系数的输入栅格。</para>
		/// <para>蓄水层的导水系数定义为导水率 K 乘以饱和蓄水层厚度 b，长度单位随时间变化进行乘方。此属性通常从字段实验数据（例如抽水测试）中估计得出。达西流和达西速度的工作原理中的表 1 和 2 列出了一些常见地质材料的导水率范围。</para>
		/// </param>
		/// <param name="OutVolumeRaster">
		/// <para>Output groundwater volume balance residual raster</para>
		/// <para>输出水量平衡残差栅格数据。</para>
		/// <para>其中各个像元均用于表示蓄水层中稳流的地下水量平衡残差，具体取决于达西定律。</para>
		/// </param>
		public DarcyFlow(object InHeadRaster, object InPorosityRaster, object InThicknessRaster, object InTransmissivityRaster, object OutVolumeRaster)
		{
			this.InHeadRaster = InHeadRaster;
			this.InPorosityRaster = InPorosityRaster;
			this.InThicknessRaster = InThicknessRaster;
			this.InTransmissivityRaster = InTransmissivityRaster;
			this.OutVolumeRaster = OutVolumeRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 达西流</para>
		/// </summary>
		public override string DisplayName() => "达西流";

		/// <summary>
		/// <para>Tool Name : DarcyFlow</para>
		/// </summary>
		public override string ToolName() => "DarcyFlow";

		/// <summary>
		/// <para>Tool Excute Name : sa.DarcyFlow</para>
		/// </summary>
		public override string ExcuteName() => "sa.DarcyFlow";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InHeadRaster, InPorosityRaster, InThicknessRaster, InTransmissivityRaster, OutVolumeRaster, OutDirectionRaster, OutMagnitudeRaster };

		/// <summary>
		/// <para>Input groundwater head elevation raster</para>
		/// <para>所包含的每一单元值都代表该处地下水位高程的输入栅格。</para>
		/// <para>水位通常是高于某些基准面（如平均海平面）的高程。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InHeadRaster { get; set; }

		/// <summary>
		/// <para>Input effective formation porosity raster</para>
		/// <para>所包含的每一单元值都代表该处有效地层孔隙度的输入栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InPorosityRaster { get; set; }

		/// <summary>
		/// <para>Input saturated thickness raster</para>
		/// <para>所包含的每一单元值都代表该处饱和厚度的输入栅格。</para>
		/// <para>厚度值根据蓄水层的地质属性进行解释。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InThicknessRaster { get; set; }

		/// <summary>
		/// <para>Input formation transmissivity raster</para>
		/// <para>所包含的每一单元值都代表该地层导水系数的输入栅格。</para>
		/// <para>蓄水层的导水系数定义为导水率 K 乘以饱和蓄水层厚度 b，长度单位随时间变化进行乘方。此属性通常从字段实验数据（例如抽水测试）中估计得出。达西流和达西速度的工作原理中的表 1 和 2 列出了一些常见地质材料的导水率范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InTransmissivityRaster { get; set; }

		/// <summary>
		/// <para>Output groundwater volume balance residual raster</para>
		/// <para>输出水量平衡残差栅格数据。</para>
		/// <para>其中各个像元均用于表示蓄水层中稳流的地下水量平衡残差，具体取决于达西定律。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutVolumeRaster { get; set; }

		/// <summary>
		/// <para>Output direction raster</para>
		/// <para>输出流向栅格。</para>
		/// <para>每一单元值都表示单元中心渗流速度矢量（平均线速度）的方向，以通过单元四个面渗流速度平均值的形式进行计算。</para>
		/// <para>该栅格与输出量级栅格一起来描述流向矢量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutDirectionRaster { get; set; }

		/// <summary>
		/// <para>Output magnitude raster</para>
		/// <para>可选输出栅格，其中的每一单元值都表示单元中心渗流速度矢量（平均线速度）的量级，以通过单元四个面渗流速度平均值的形式进行计算。</para>
		/// <para>该栅格与输出方向栅格一起来描述流向矢量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutMagnitudeRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DarcyFlow SetEnviroment(int? autoCommit = null , object cellSize = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
