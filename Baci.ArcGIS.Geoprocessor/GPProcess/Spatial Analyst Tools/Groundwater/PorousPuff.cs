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
	/// <para>Porous Puff</para>
	/// <para>孔隙扩散</para>
	/// <para>计算与时间相关的二维浓度分布，形式为在某一离散点瞬时注入垂直混合蓄水层的单位体积溶质质量。</para>
	/// </summary>
	public class PorousPuff : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTrackFile">
		/// <para>Input particle track file</para>
		/// <para>输入粒子追踪路径文件。</para>
		/// <para>这是一个 ASCII 文本文件，其中包含沿路径移动的位置、局部速度矢量以及累积长度和时间的信息。</para>
		/// <para>此文件将使用粒子追踪工具进行生成。</para>
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
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>浓度分布的输出栅格。</para>
		/// <para>每个像元值都表示该位置的浓度。</para>
		/// </param>
		/// <param name="Mass">
		/// <para>Mass</para>
		/// <para>源点处瞬间释放的质量数量值（以质量单位为单位）。</para>
		/// </param>
		public PorousPuff(object InTrackFile, object InPorosityRaster, object InThicknessRaster, object OutRaster, object Mass)
		{
			this.InTrackFile = InTrackFile;
			this.InPorosityRaster = InPorosityRaster;
			this.InThicknessRaster = InThicknessRaster;
			this.OutRaster = OutRaster;
			this.Mass = Mass;
		}

		/// <summary>
		/// <para>Tool Display Name : 孔隙扩散</para>
		/// </summary>
		public override string DisplayName() => "孔隙扩散";

		/// <summary>
		/// <para>Tool Name : PorousPuff</para>
		/// </summary>
		public override string ToolName() => "PorousPuff";

		/// <summary>
		/// <para>Tool Excute Name : sa.PorousPuff</para>
		/// </summary>
		public override string ExcuteName() => "sa.PorousPuff";

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
		public override object[] Parameters() => new object[] { InTrackFile, InPorosityRaster, InThicknessRaster, OutRaster, Mass, DispersionTime, LongitudinalDispersivity, DispersivityRatio, RetardationFactor, DecayCoefficient };

		/// <summary>
		/// <para>Input particle track file</para>
		/// <para>输入粒子追踪路径文件。</para>
		/// <para>这是一个 ASCII 文本文件，其中包含沿路径移动的位置、局部速度矢量以及累积长度和时间的信息。</para>
		/// <para>此文件将使用粒子追踪工具进行生成。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TXT", "ASC")]
		public object InTrackFile { get; set; }

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
		/// <para>Output raster</para>
		/// <para>浓度分布的输出栅格。</para>
		/// <para>每个像元值都表示该位置的浓度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Mass</para>
		/// <para>源点处瞬间释放的质量数量值（以质量单位为单位）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		[GPNumericDomain()]
		public object Mass { get; set; }

		/// <summary>
		/// <para>Dispersion time</para>
		/// <para>表示溶质扩散的时间范围的值（以时间单位为单位）。</para>
		/// <para>该时间必须小于或等于追踪文件中的最大时间。如果请求的时间超过追踪文件中的可用时间，该工具将中止。默认时间为追踪文件中的最晚时间（对应于终点）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object DispersionTime { get; set; }

		/// <summary>
		/// <para>Longitudinal dispersivity</para>
		/// <para>表示与流向平行的扩散性的值。</para>
		/// <para>有关默认值的确定方法及其与研究范围的关系的详细信息，请参阅本文档的孔隙扩散的工作原理部分。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object LongitudinalDispersivity { get; set; }

		/// <summary>
		/// <para>Dispersivity ratio</para>
		/// <para>表示纵横扩散性比的值。</para>
		/// <para>横向扩散性在同一水平面中垂直于流向。默认值为三。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object DispersivityRatio { get; set; } = "3";

		/// <summary>
		/// <para>Retardation factor</para>
		/// <para>表示蓄水层中溶质延迟的无维度值。</para>
		/// <para>延迟可以是一至无穷大之间的任意值，一对应于无延迟。默认值为一。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object RetardationFactor { get; set; } = "1";

		/// <summary>
		/// <para>Decay coefficient</para>
		/// <para>经历一阶指数衰减的溶质（如放射性核素）的衰减系数，以反时间单位为单位。</para>
		/// <para>默认值为零，对应于无衰减。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object DecayCoefficient { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PorousPuff SetEnviroment(int? autoCommit = null , object cellSize = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
