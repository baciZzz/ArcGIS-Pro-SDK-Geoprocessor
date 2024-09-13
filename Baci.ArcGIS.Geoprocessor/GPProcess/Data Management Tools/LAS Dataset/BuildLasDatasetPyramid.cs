using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Build LAS Dataset Pyramid</para>
	/// <para>构建 LAS 数据集金字塔</para>
	/// <para>构建或更新 LAS 数据集显示缓存，以优化其渲染性能。</para>
	/// </summary>
	public class BuildLasDatasetPyramid : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </param>
		public BuildLasDatasetPyramid(object InLasDataset)
		{
			this.InLasDataset = InLasDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 构建 LAS 数据集金字塔</para>
		/// </summary>
		public override string DisplayName() => "构建 LAS 数据集金字塔";

		/// <summary>
		/// <para>Tool Name : BuildLasDatasetPyramid</para>
		/// </summary>
		public override string ToolName() => "BuildLasDatasetPyramid";

		/// <summary>
		/// <para>Tool Excute Name : management.BuildLasDatasetPyramid</para>
		/// </summary>
		public override string ExcuteName() => "management.BuildLasDatasetPyramid";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, PointSelectionMethod!, ClassCodesWeights!, DerivedLasDataset! };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Point Selection Method</para>
		/// <para>指定如何选择每个图格区域中的点以构建金字塔。 如果 LAS 数据集包含金字塔，将禁用此参数。</para>
		/// <para>最低点—将选择具有最小 z 值的点。</para>
		/// <para>最高点—将选择具有最大 z 值的点。</para>
		/// <para>最接近中心—将选择最接近图格区域中心的点。</para>
		/// <para>类代码和权重—将选择权重值最高的点。</para>
		/// <para><see cref="PointSelectionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PointSelectionMethod { get; set; } = "CLOSEST_TO_CENTER";

		/// <summary>
		/// <para>Input Class Codes and Weights</para>
		/// <para>赋予每个类代码的权重，用于确定在每个稀疏化区域保留哪些点。仅当在点选择方法参数中指定了类代码权重选项时才会启用该参数。具有最高权重的类代码将保留在稀疏化区域中。如果给定稀疏化区域中存在两个具有相同权重的类代码，则将保留具有最小点源 ID 的类代码。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? ClassCodesWeights { get; set; }

		/// <summary>
		/// <para>Output LAS Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLasDatasetLayer()]
		public object? DerivedLasDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BuildLasDatasetPyramid SetEnviroment(object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Point Selection Method</para>
		/// </summary>
		public enum PointSelectionMethodEnum 
		{
			/// <summary>
			/// <para>最接近中心—将选择最接近图格区域中心的点。</para>
			/// </summary>
			[GPValue("CLOSEST_TO_CENTER")]
			[Description("最接近中心")]
			Closest_to_Center,

			/// <summary>
			/// <para>类代码和权重—将选择权重值最高的点。</para>
			/// </summary>
			[GPValue("CLASS_CODE")]
			[Description("类代码和权重")]
			Class_Codes_and_Weights,

			/// <summary>
			/// <para>最低点—将选择具有最小 z 值的点。</para>
			/// </summary>
			[GPValue("Z_MIN")]
			[Description("最低点")]
			Lowest_Point,

			/// <summary>
			/// <para>最高点—将选择具有最大 z 值的点。</para>
			/// </summary>
			[GPValue("Z_MAX")]
			[Description("最高点")]
			Highest_Point,

		}

#endregion
	}
}
