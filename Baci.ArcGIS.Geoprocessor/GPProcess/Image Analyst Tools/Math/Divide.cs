using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ImageAnalystTools
{
	/// <summary>
	/// <para>Divide</para>
	/// <para>除</para>
	/// <para>将两个栅格的值逐个像元相除。</para>
	/// </summary>
	public class Divide : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterOrConstant1">
		/// <para>Input raster or constant value 1</para>
		/// <para>该输入的值将被第二个输入的值除。</para>
		/// <para>假如已为其他参数指定栅格，则可将数字用作此参数的输入。 要为两个输入指定数字，像元大小和范围必须先在环境中进行设置。</para>
		/// </param>
		/// <param name="InRasterOrConstant2">
		/// <para>Input raster or constant value 2</para>
		/// <para>用该输入的值去除第一个输入的值。</para>
		/// <para>假如已为其他参数指定栅格，则可将数字用作此参数的输入。 要为两个输入指定数字，像元大小和范围必须先在环境中进行设置。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// <para>单元值为第一个输入栅格（被除数）除以第二个输入栅格（除数）的商。</para>
		/// </param>
		public Divide(object InRasterOrConstant1, object InRasterOrConstant2, object OutRaster)
		{
			this.InRasterOrConstant1 = InRasterOrConstant1;
			this.InRasterOrConstant2 = InRasterOrConstant2;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 除</para>
		/// </summary>
		public override string DisplayName() => "除";

		/// <summary>
		/// <para>Tool Name : 除</para>
		/// </summary>
		public override string ToolName() => "除";

		/// <summary>
		/// <para>Tool Excute Name : ia.Divide</para>
		/// </summary>
		public override string ExcuteName() => "ia.Divide";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise() => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRasterOrConstant1, InRasterOrConstant2, OutRaster };

		/// <summary>
		/// <para>Input raster or constant value 1</para>
		/// <para>该输入的值将被第二个输入的值除。</para>
		/// <para>假如已为其他参数指定栅格，则可将数字用作此参数的输入。 要为两个输入指定数字，像元大小和范围必须先在环境中进行设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "GPRasterFormulated", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile", "GPDouble", "GPLong")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRasterOrConstant1 { get; set; }

		/// <summary>
		/// <para>Input raster or constant value 2</para>
		/// <para>用该输入的值去除第一个输入的值。</para>
		/// <para>假如已为其他参数指定栅格，则可将数字用作此参数的输入。 要为两个输入指定数字，像元大小和范围必须先在环境中进行设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "GPRasterFormulated", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile", "GPDouble", "GPLong")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRasterOrConstant2 { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// <para>单元值为第一个输入栅格（被除数）除以第二个输入栅格（除数）的商。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Divide SetEnviroment(int? autoCommit = null, object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
