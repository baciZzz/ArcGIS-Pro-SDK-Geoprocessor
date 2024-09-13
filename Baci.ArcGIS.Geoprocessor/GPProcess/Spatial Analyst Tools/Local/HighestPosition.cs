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
	/// <para>Highest Position</para>
	/// <para>最高位置</para>
	/// <para>逐个像元确定一组栅格中具有最大值的栅格的位置。</para>
	/// </summary>
	public class HighestPosition : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRastersOrConstants">
		/// <para>Input rasters or constant values</para>
		/// <para>确定具有最高值的输入栅格的位置时所用的输入栅格列表。</para>
		/// <para>数字可以作为输入，但是必须先在环境中设置像元大小和范围。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// <para>对于输出栅格中的各个像元，该值表示具有最高值的栅格的位置。</para>
		/// </param>
		public HighestPosition(object InRastersOrConstants, object OutRaster)
		{
			this.InRastersOrConstants = InRastersOrConstants;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 最高位置</para>
		/// </summary>
		public override string DisplayName() => "最高位置";

		/// <summary>
		/// <para>Tool Name : HighestPosition</para>
		/// </summary>
		public override string ToolName() => "HighestPosition";

		/// <summary>
		/// <para>Tool Excute Name : sa.HighestPosition</para>
		/// </summary>
		public override string ExcuteName() => "sa.HighestPosition";

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
		public override object[] Parameters() => new object[] { InRastersOrConstants, OutRaster };

		/// <summary>
		/// <para>Input rasters or constant values</para>
		/// <para>确定具有最高值的输入栅格的位置时所用的输入栅格列表。</para>
		/// <para>数字可以作为输入，但是必须先在环境中设置像元大小和范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "GPRasterFormulated", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile", "GPDouble", "GPLong")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRastersOrConstants { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// <para>对于输出栅格中的各个像元，该值表示具有最高值的栅格的位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public HighestPosition SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
