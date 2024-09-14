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
	/// <para>Analyze Mosaic Dataset</para>
	/// <para>分析镶嵌数据集</para>
	/// <para>检查镶嵌数据集是否存在错误以及可能的改进。</para>
	/// </summary>
	public class AnalyzeMosaicDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>想要分析的镶嵌数据集。</para>
		/// </param>
		public AnalyzeMosaicDataset(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 分析镶嵌数据集</para>
		/// </summary>
		public override string DisplayName() => "分析镶嵌数据集";

		/// <summary>
		/// <para>Tool Name : AnalyzeMosaicDataset</para>
		/// </summary>
		public override string ToolName() => "AnalyzeMosaicDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.AnalyzeMosaicDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.AnalyzeMosaicDataset";

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
		public override object[] Parameters() => new object[] { InMosaicDataset, WhereClause!, CheckerKeywords!, OutMosaicDataset! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>想要分析的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>限制在此镶嵌数据集中对特定栅格数据集进行分析的 SQL 语句。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Checks Performed</para>
		/// <para>选择想要分析是否存在已知问题的镶嵌数据集部分。</para>
		/// <para>轮廓线几何— 对每个选定镶嵌数据集项目的轮廓线几何进行分析。该项为默认选中。</para>
		/// <para>函数链— 对每个选定镶嵌数据集项目的函数链进行分析。</para>
		/// <para>栅格— 分析原始栅格数据集。该项为默认选中。</para>
		/// <para>损坏的路径— 检查是否存在损坏的路径。该项为默认选中。</para>
		/// <para>源的有效性— 对与选定镶嵌数据集中每个镶嵌数据集项目相关联的源数据的潜在问题进行分析。此方法可以有效检测同步工作流期间可能发生的问题。</para>
		/// <para>失效概视图— 基础源数据更改后概视图失效。分析镶嵌数据集后，可通过右键单击错误，然后在快捷菜单中单击选择关联项目来选择失效的项目。</para>
		/// <para>金字塔— 对与选定镶嵌数据集中的每个镶嵌数据集项目相关联的栅格金字塔进行分析。测试辅助文件存储在栅格代理位置时是否会断开连接。</para>
		/// <para>统计— 测试如果辅助统计文件存储在栅格代理位置中是否会断开连接。当启用 Gram-Schmidt 全色锐化方法时，对与栅格相关联的协方差矩阵进行分析。将镶嵌数据集项目的辐射像素深度与镶嵌数据集的像素深度进行对比分析。</para>
		/// <para>性能— 提高性能的因素包括传输期间压缩和通过多种栅格函数缓存项目。</para>
		/// <para>信息— 生成有关镶嵌数据集的常规信息。</para>
		/// <para><see cref="CheckerKeywordsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? CheckerKeywords { get; set; }

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AnalyzeMosaicDataset SetEnviroment(object? parallelProcessingFactor = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Checks Performed</para>
		/// </summary>
		public enum CheckerKeywordsEnum 
		{
			/// <summary>
			/// <para>轮廓线几何— 对每个选定镶嵌数据集项目的轮廓线几何进行分析。该项为默认选中。</para>
			/// </summary>
			[GPValue("FOOTPRINT")]
			[Description("轮廓线几何")]
			Footprint_geometry,

			/// <summary>
			/// <para>函数链— 对每个选定镶嵌数据集项目的函数链进行分析。</para>
			/// </summary>
			[GPValue("FUNCTION")]
			[Description("函数链")]
			Function_chains,

			/// <summary>
			/// <para>栅格— 分析原始栅格数据集。该项为默认选中。</para>
			/// </summary>
			[GPValue("RASTER")]
			[Description("栅格")]
			Raster,

			/// <summary>
			/// <para>损坏的路径— 检查是否存在损坏的路径。该项为默认选中。</para>
			/// </summary>
			[GPValue("PATHS")]
			[Description("损坏的路径")]
			Broken_paths,

			/// <summary>
			/// <para>源的有效性— 对与选定镶嵌数据集中每个镶嵌数据集项目相关联的源数据的潜在问题进行分析。此方法可以有效检测同步工作流期间可能发生的问题。</para>
			/// </summary>
			[GPValue("SOURCE_VALIDITY")]
			[Description("源的有效性")]
			Source_validity,

			/// <summary>
			/// <para>失效概视图— 基础源数据更改后概视图失效。分析镶嵌数据集后，可通过右键单击错误，然后在快捷菜单中单击选择关联项目来选择失效的项目。</para>
			/// </summary>
			[GPValue("STALE")]
			[Description("失效概视图")]
			Stale_overviews,

			/// <summary>
			/// <para>金字塔— 对与选定镶嵌数据集中的每个镶嵌数据集项目相关联的栅格金字塔进行分析。测试辅助文件存储在栅格代理位置时是否会断开连接。</para>
			/// </summary>
			[GPValue("PYRAMIDS")]
			[Description("金字塔")]
			Pyramids,

			/// <summary>
			/// <para>统计— 测试如果辅助统计文件存储在栅格代理位置中是否会断开连接。当启用 Gram-Schmidt 全色锐化方法时，对与栅格相关联的协方差矩阵进行分析。将镶嵌数据集项目的辐射像素深度与镶嵌数据集的像素深度进行对比分析。</para>
			/// </summary>
			[GPValue("STATISTICS")]
			[Description("统计")]
			Statistics,

			/// <summary>
			/// <para>性能— 提高性能的因素包括传输期间压缩和通过多种栅格函数缓存项目。</para>
			/// </summary>
			[GPValue("PERFORMANCE")]
			[Description("性能")]
			Performance,

			/// <summary>
			/// <para>信息— 生成有关镶嵌数据集的常规信息。</para>
			/// </summary>
			[GPValue("INFORMATION")]
			[Description("信息")]
			Information,

		}

#endregion
	}
}
