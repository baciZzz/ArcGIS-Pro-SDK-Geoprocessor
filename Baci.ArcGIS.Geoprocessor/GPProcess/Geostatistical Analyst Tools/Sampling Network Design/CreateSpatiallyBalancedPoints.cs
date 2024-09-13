using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>Create Spatially Balanced Points</para>
	/// <para>创建空间平衡点</para>
	/// <para>基于包含概率生成一组采样点，进而获得空间平衡的采样设计。此工具通常用于通过对采样位置提出建议来设计监控网络，以及使用包含概率栅格定义特定位置的优先级。</para>
	/// </summary>
	public class CreateSpatiallyBalancedPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InProbabilityRaster">
		/// <para>Input inclusion probability raster</para>
		/// <para>此栅格定义感兴趣区域内每个位置的包含概率。位置的值范围为 0（低包含概率）到 1（高包含概率）。</para>
		/// </param>
		/// <param name="NumberOutputPoints">
		/// <para>Number of  output points</para>
		/// <para>指定要生成的采样位置的数量。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output point feature class</para>
		/// <para>输出要素类包含所选采样位置及其包含概率。</para>
		/// </param>
		public CreateSpatiallyBalancedPoints(object InProbabilityRaster, object NumberOutputPoints, object OutFeatureClass)
		{
			this.InProbabilityRaster = InProbabilityRaster;
			this.NumberOutputPoints = NumberOutputPoints;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建空间平衡点</para>
		/// </summary>
		public override string DisplayName() => "创建空间平衡点";

		/// <summary>
		/// <para>Tool Name : CreateSpatiallyBalancedPoints</para>
		/// </summary>
		public override string ToolName() => "CreateSpatiallyBalancedPoints";

		/// <summary>
		/// <para>Tool Excute Name : ga.CreateSpatiallyBalancedPoints</para>
		/// </summary>
		public override string ExcuteName() => "ga.CreateSpatiallyBalancedPoints";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise() => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "randomGenerator", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InProbabilityRaster, NumberOutputPoints, OutFeatureClass };

		/// <summary>
		/// <para>Input inclusion probability raster</para>
		/// <para>此栅格定义感兴趣区域内每个位置的包含概率。位置的值范围为 0（低包含概率）到 1（高包含概率）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InProbabilityRaster { get; set; }

		/// <summary>
		/// <para>Number of  output points</para>
		/// <para>指定要生成的采样位置的数量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 2147483647)]
		public object NumberOutputPoints { get; set; }

		/// <summary>
		/// <para>Output point feature class</para>
		/// <para>输出要素类包含所选采样位置及其包含概率。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateSpatiallyBalancedPoints SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object randomGenerator = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, randomGenerator: randomGenerator, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
