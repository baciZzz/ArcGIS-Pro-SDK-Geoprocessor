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
	/// <para>Test</para>
	/// <para>条件测试</para>
	/// <para>使用逻辑表达式对输入栅格执行布尔评估。</para>
	/// </summary>
	public class Test : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>基于逻辑表达式在其上执行布尔评估的输入栅格。</para>
		/// </param>
		/// <param name="WhereClause">
		/// <para>Where clause</para>
		/// <para>用于确定哪些输入像元将返回“真”值 (1) 以及哪些输入像元将返回“假”值 (0) 的逻辑表达式。</para>
		/// <para>Where 子句遵循 SQL 表达式的一般格式。 如果您单击编辑 SQL 模式按钮 ，则可以直接输入，例如 VALUE &gt; 100。 如果处于编辑子句模式 中，则可以通过单击添加子句模式按钮来开始构建表达式。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// <para>输出像元值为 0 或 1。</para>
		/// </param>
		public Test(object InRaster, object WhereClause, object OutRaster)
		{
			this.InRaster = InRaster;
			this.WhereClause = WhereClause;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 条件测试</para>
		/// </summary>
		public override string DisplayName() => "条件测试";

		/// <summary>
		/// <para>Tool Name : 条件测试</para>
		/// </summary>
		public override string ToolName() => "条件测试";

		/// <summary>
		/// <para>Tool Excute Name : ia.Test</para>
		/// </summary>
		public override string ExcuteName() => "ia.Test";

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
		public override object[] Parameters() => new object[] { InRaster, WhereClause, OutRaster };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>基于逻辑表达式在其上执行布尔评估的输入栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Where clause</para>
		/// <para>用于确定哪些输入像元将返回“真”值 (1) 以及哪些输入像元将返回“假”值 (0) 的逻辑表达式。</para>
		/// <para>Where 子句遵循 SQL 表达式的一般格式。 如果您单击编辑 SQL 模式按钮 ，则可以直接输入，例如 VALUE &gt; 100。 如果处于编辑子句模式 中，则可以通过单击添加子句模式按钮来开始构建表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// <para>输出像元值为 0 或 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Test SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
