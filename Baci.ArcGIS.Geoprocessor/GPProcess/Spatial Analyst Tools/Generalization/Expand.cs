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
	/// <para>Expand</para>
	/// <para>扩展</para>
	/// <para>按指定的像元数目扩展指定的栅格区域。</para>
	/// </summary>
	public class Expand : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>要扩展识别区域的输入栅格</para>
		/// <para>必须为整型。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出概化的栅格。</para>
		/// <para>将按指定数量扩展的输入栅格指定区域。</para>
		/// <para>输出始终为整型。</para>
		/// </param>
		/// <param name="NumberCells">
		/// <para>Number of cells</para>
		/// <para>每个指定区域要扩展的像元数。</para>
		/// <para>该值必须为大于 1 的整数。</para>
		/// </param>
		/// <param name="ZoneValues">
		/// <para>Zone values</para>
		/// <para>要扩展的区域值列表。</para>
		/// <para>区域值必须为整数。可以按任意顺序排列。</para>
		/// </param>
		public Expand(object InRaster, object OutRaster, object NumberCells, object ZoneValues)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
			this.NumberCells = NumberCells;
			this.ZoneValues = ZoneValues;
		}

		/// <summary>
		/// <para>Tool Display Name : 扩展</para>
		/// </summary>
		public override string DisplayName() => "扩展";

		/// <summary>
		/// <para>Tool Name : 扩展</para>
		/// </summary>
		public override string ToolName() => "扩展";

		/// <summary>
		/// <para>Tool Excute Name : sa.Expand</para>
		/// </summary>
		public override string ExcuteName() => "sa.Expand";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, NumberCells, ZoneValues, ExpandMethod! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>要扩展识别区域的输入栅格</para>
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
		/// <para>输出概化的栅格。</para>
		/// <para>将按指定数量扩展的输入栅格指定区域。</para>
		/// <para>输出始终为整型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Number of cells</para>
		/// <para>每个指定区域要扩展的像元数。</para>
		/// <para>该值必须为大于 1 的整数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPNumericDomain()]
		public object NumberCells { get; set; }

		/// <summary>
		/// <para>Zone values</para>
		/// <para>要扩展的区域值列表。</para>
		/// <para>区域值必须为整数。可以按任意顺序排列。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object ZoneValues { get; set; }

		/// <summary>
		/// <para>Expand method</para>
		/// <para>用于扩展所选区域的方法。</para>
		/// <para>形态—使用数学形态学方法扩展区域。 这是默认设置。</para>
		/// <para>距离—使用基于距离的方法扩展区域。</para>
		/// <para>距离选项支持并行处理，可以使用并行处理因子环境设定进行控制。</para>
		/// <para><see cref="ExpandMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ExpandMethod { get; set; } = "MORPHOLOGICAL";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Expand SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Expand method</para>
		/// </summary>
		public enum ExpandMethodEnum 
		{
			/// <summary>
			/// <para>形态—使用数学形态学方法扩展区域。 这是默认设置。</para>
			/// </summary>
			[GPValue("MORPHOLOGICAL")]
			[Description("形态")]
			Morphological,

			/// <summary>
			/// <para>距离—使用基于距离的方法扩展区域。</para>
			/// </summary>
			[GPValue("DISTANCE")]
			[Description("距离")]
			Distance,

		}

#endregion
	}
}
