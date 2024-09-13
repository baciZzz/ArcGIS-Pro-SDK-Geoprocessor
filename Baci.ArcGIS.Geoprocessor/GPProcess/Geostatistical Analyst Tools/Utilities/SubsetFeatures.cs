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
	/// <para>Subset Features</para>
	/// <para>子集要素</para>
	/// <para>将原始数据集分为两部分：一部分用于建立空间结构模型和生成表面，另一部分用于比较和验证输出表面。</para>
	/// </summary>
	public class SubsetFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input features</para>
		/// <para>用于创建子集的点、线、面要素或表。</para>
		/// </param>
		/// <param name="OutTrainingFeatureClass">
		/// <para>Output training feature class</para>
		/// <para>要创建的训练要素的子集。</para>
		/// </param>
		public SubsetFeatures(object InFeatures, object OutTrainingFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutTrainingFeatureClass = OutTrainingFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 子集要素</para>
		/// </summary>
		public override string DisplayName() => "子集要素";

		/// <summary>
		/// <para>Tool Name : SubsetFeatures</para>
		/// </summary>
		public override string ToolName() => "SubsetFeatures";

		/// <summary>
		/// <para>Tool Excute Name : ga.SubsetFeatures</para>
		/// </summary>
		public override string ExcuteName() => "ga.SubsetFeatures";

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
		public override object[] Parameters() => new object[] { InFeatures, OutTrainingFeatureClass, OutTestFeatureClass!, SizeOfTrainingDataset!, SubsetSizeUnits! };

		/// <summary>
		/// <para>Input features</para>
		/// <para>用于创建子集的点、线、面要素或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output training feature class</para>
		/// <para>要创建的训练要素的子集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutTrainingFeatureClass { get; set; }

		/// <summary>
		/// <para>Output test feature class</para>
		/// <para>要创建的测试要素的子集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? OutTestFeatureClass { get; set; }

		/// <summary>
		/// <para>Size of training  feature subset</para>
		/// <para>作为输入要素百分数或要素绝对数量输入的输出训练要素类的大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 2.2250738585072014e-308, Max = 100)]
		public object? SizeOfTrainingDataset { get; set; } = "50";

		/// <summary>
		/// <para>Subset size units</para>
		/// <para>子集大小的类型。</para>
		/// <para>Percentage of input— 将要出现在训练数据集中的输入要素的百分数。</para>
		/// <para>Absolute value— 将要出现在训练数据集中的要素的数量。</para>
		/// <para><see cref="SubsetSizeUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SubsetSizeUnits { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SubsetFeatures SetEnviroment(object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? randomGenerator = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, randomGenerator: randomGenerator, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Subset size units</para>
		/// </summary>
		public enum SubsetSizeUnitsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PERCENTAGE_OF_INPUT")]
			PERCENTAGE_OF_INPUT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ABSOLUTE_VALUE")]
			ABSOLUTE_VALUE,

		}

#endregion
	}
}
