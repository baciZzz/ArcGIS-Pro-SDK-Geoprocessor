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
	/// <para>Weighted Sum</para>
	/// <para>加权总和</para>
	/// <para>通过将栅格各自乘以指定的权重并合计在一起来叠加多个栅格。</para>
	/// </summary>
	public class WeightedSum : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasters">
		/// <para>Input rasters</para>
		/// <para>加权总和表允许您在对输入栅格求和之前对其应用不同的权重。</para>
		/// <para>栅格 - 进行加权的栅格。</para>
		/// <para>字段 - 用于加权的栅格字段。</para>
		/// <para>权重 - 与栅格数据相乘的权重值。该值可以是正的或负的小数值。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出加权栅格。</para>
		/// <para>此栅格为浮点类型。</para>
		/// </param>
		public WeightedSum(object InRasters, object OutRaster)
		{
			this.InRasters = InRasters;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 加权总和</para>
		/// </summary>
		public override string DisplayName() => "加权总和";

		/// <summary>
		/// <para>Tool Name : WeightedSum</para>
		/// </summary>
		public override string ToolName() => "WeightedSum";

		/// <summary>
		/// <para>Tool Excute Name : sa.WeightedSum</para>
		/// </summary>
		public override string ExcuteName() => "sa.WeightedSum";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRasters, OutRaster };

		/// <summary>
		/// <para>Input rasters</para>
		/// <para>加权总和表允许您在对输入栅格求和之前对其应用不同的权重。</para>
		/// <para>栅格 - 进行加权的栅格。</para>
		/// <para>字段 - 用于加权的栅格字段。</para>
		/// <para>权重 - 与栅格数据相乘的权重值。该值可以是正的或负的小数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAWeightedSum()]
		[GPCompositeDomain()]
		public object InRasters { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出加权栅格。</para>
		/// <para>此栅格为浮点类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public WeightedSum SetEnviroment(int? autoCommit = null, object cellSize = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
