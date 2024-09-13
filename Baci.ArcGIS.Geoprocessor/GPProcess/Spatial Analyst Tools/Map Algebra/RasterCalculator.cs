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
	/// <para>Raster Calculator</para>
	/// <para>栅格计算器</para>
	/// <para>使用 Python 语法构建和执行单个地图代数表达式。</para>
	/// </summary>
	public class RasterCalculator : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Expression">
		/// <para>Map Algebra expression</para>
		/// <para>想要运行的地图代数表达式。</para>
		/// <para>通过指定输入、值、运算符和要使用的工具来构成表达式。可直接输入表达式，也可使用控件来帮助您创建表达式。</para>
		/// <para>栅格列表识别了可以在地图代数表达式中使用的数据集。</para>
		/// <para>工具列表为您提供可从中选择的常用工具集合。</para>
		/// </param>
		/// <param name="OutputRaster">
		/// <para>Output raster</para>
		/// <para>由地图代数表达式产生的输出栅格。</para>
		/// </param>
		public RasterCalculator(object Expression, object OutputRaster)
		{
			this.Expression = Expression;
			this.OutputRaster = OutputRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 栅格计算器</para>
		/// </summary>
		public override string DisplayName() => "栅格计算器";

		/// <summary>
		/// <para>Tool Name : RasterCalculator</para>
		/// </summary>
		public override string ToolName() => "RasterCalculator";

		/// <summary>
		/// <para>Tool Excute Name : sa.RasterCalculator</para>
		/// </summary>
		public override string ExcuteName() => "sa.RasterCalculator";

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
		public override object[] Parameters() => new object[] { Expression, OutputRaster };

		/// <summary>
		/// <para>Map Algebra expression</para>
		/// <para>想要运行的地图代数表达式。</para>
		/// <para>通过指定输入、值、运算符和要使用的工具来构成表达式。可直接输入表达式，也可使用控件来帮助您创建表达式。</para>
		/// <para>栅格列表识别了可以在地图代数表达式中使用的数据集。</para>
		/// <para>工具列表为您提供可从中选择的常用工具集合。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterCalculatorExpression()]
		public object Expression { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>由地图代数表达式产生的输出栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutputRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterCalculator SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
