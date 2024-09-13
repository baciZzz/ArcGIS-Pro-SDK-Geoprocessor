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
	/// <para>Principal Components</para>
	/// <para>主成分分析</para>
	/// <para>对一组栅格波段执行主成分分析 (PCA) 并生成单波段栅格作为输出。</para>
	/// </summary>
	public class PrincipalComponents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterBands">
		/// <para>Input raster bands</para>
		/// <para>输入栅格波段。</para>
		/// <para>可为整型或浮点型。</para>
		/// </param>
		/// <param name="OutMultibandRaster">
		/// <para>Output multiband raster</para>
		/// <para>输出多波段栅格数据集。</para>
		/// <para>如果所有的输入波段为整型，那么输出栅格波段也为整型。如果任何输入波段属于浮点型，则输出波段也将为浮点型。</para>
		/// <para>如果输出是一个 Esri Grid 栅格，名称必须少于 10 个字符。</para>
		/// </param>
		public PrincipalComponents(object InRasterBands, object OutMultibandRaster)
		{
			this.InRasterBands = InRasterBands;
			this.OutMultibandRaster = OutMultibandRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 主成分分析</para>
		/// </summary>
		public override string DisplayName() => "主成分分析";

		/// <summary>
		/// <para>Tool Name : PrincipalComponents</para>
		/// </summary>
		public override string ToolName() => "PrincipalComponents";

		/// <summary>
		/// <para>Tool Excute Name : sa.PrincipalComponents</para>
		/// </summary>
		public override string ExcuteName() => "sa.PrincipalComponents";

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
		public override object[] Parameters() => new object[] { InRasterBands, OutMultibandRaster, NumberComponents, OutDataFile };

		/// <summary>
		/// <para>Input raster bands</para>
		/// <para>输入栅格波段。</para>
		/// <para>可为整型或浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRasterBands { get; set; }

		/// <summary>
		/// <para>Output multiband raster</para>
		/// <para>输出多波段栅格数据集。</para>
		/// <para>如果所有的输入波段为整型，那么输出栅格波段也为整型。如果任何输入波段属于浮点型，则输出波段也将为浮点型。</para>
		/// <para>如果输出是一个 Esri Grid 栅格，名称必须少于 10 个字符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutMultibandRaster { get; set; }

		/// <summary>
		/// <para>Number of Principal components</para>
		/// <para>主成分的数目。</para>
		/// <para>该数目必须大于零并小于等于输入栅格波段总数。</para>
		/// <para>默认值为输入的栅格波段总数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 1)]
		public object NumberComponents { get; set; }

		/// <summary>
		/// <para>Output data file</para>
		/// <para>存储主成分参数的输出 ASCII 数据文件。</para>
		/// <para>输出数据文件记录协方差和相关矩阵、特征值和特征向量以及各特征值所捕获的百分比方差和特征值所述的累积方差。</para>
		/// <para>该输出文件的扩展名可以是 .txt 或 .asc。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TXT", "ASC")]
		public object OutDataFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PrincipalComponents SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
