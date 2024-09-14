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
	/// <para>Build Boundary</para>
	/// <para>构建边界</para>
	/// <para>添加新栅格数据集到范围超出先前 coverage 的镶嵌数据集时更新边界的范围。</para>
	/// </summary>
	public class BuildBoundary : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>选择想重新计算边界的镶嵌数据集。</para>
		/// </param>
		public BuildBoundary(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 构建边界</para>
		/// </summary>
		public override string DisplayName() => "构建边界";

		/// <summary>
		/// <para>Tool Name : BuildBoundary</para>
		/// </summary>
		public override string ToolName() => "BuildBoundary";

		/// <summary>
		/// <para>Tool Excute Name : management.BuildBoundary</para>
		/// </summary>
		public override string ExcuteName() => "management.BuildBoundary";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, WhereClause!, AppendToExisting!, SimplificationMethod!, OutMosaicDataset! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>选择想重新计算边界的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>用于计算边界以选择栅格数据集的 SQL 查询。将此选项与追加至现有边界选项结合使用可以节约添加新栅格数据集的时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Append To Existing Boundary</para>
		/// <para>向现有镶嵌数据集添加新栅格数据集时使用此选项。它会将新栅格数据集的边界与现有边界合并，而不是计算整个边界。</para>
		/// <para>选中 - 将覆盖区周长追加到现有边界。由于不重新计算整个边界，因此在向镶嵌数据集添加其他栅格数据时，使用该选项可以节省时间。如果选择了栅格，则将重新计算边界以便仅包括所选覆盖区。这是默认设置。</para>
		/// <para>未选中 - 重新计算整个边界。</para>
		/// <para><see cref="AppendToExistingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? AppendToExisting { get; set; } = "false";

		/// <summary>
		/// <para>Simplification Method</para>
		/// <para>指定将用于减少折点数量的简化方法，因为密集的边界可能会影响性能。</para>
		/// <para>选择为简化边界所使用的简化方法。</para>
		/// <para>无—不会执行简化方法。 这是默认设置。</para>
		/// <para>凸包—镶嵌数据集的最小边界几何将用于简化边界。 如果存在断开的轮廓线，则每个连续的轮廓线组的最小边界几何将用于简化边界。</para>
		/// <para>包络—镶嵌数据集的包络矩形将提供简化的边界。 如果存在断开的轮廓线，则每个连续轮廓线组的包络矩形将用于简化边界。</para>
		/// <para><see cref="SimplificationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? SimplificationMethod { get; set; } = "NONE";

		/// <summary>
		/// <para>Updated Input Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BuildBoundary SetEnviroment(object? parallelProcessingFactor = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Append To Existing Boundary</para>
		/// </summary>
		public enum AppendToExistingEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("APPEND")]
			APPEND,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("OVERWRITE")]
			OVERWRITE,

		}

		/// <summary>
		/// <para>Simplification Method</para>
		/// </summary>
		public enum SimplificationMethodEnum 
		{
			/// <summary>
			/// <para>无—不会执行简化方法。 这是默认设置。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>凸包—镶嵌数据集的最小边界几何将用于简化边界。 如果存在断开的轮廓线，则每个连续的轮廓线组的最小边界几何将用于简化边界。</para>
			/// </summary>
			[GPValue("CONVEX_HULL")]
			[Description("凸包")]
			Convex_hull,

			/// <summary>
			/// <para>包络—镶嵌数据集的包络矩形将提供简化的边界。 如果存在断开的轮廓线，则每个连续轮廓线组的包络矩形将用于简化边界。</para>
			/// </summary>
			[GPValue("ENVELOPE")]
			[Description("包络")]
			Envelope,

		}

#endregion
	}
}
