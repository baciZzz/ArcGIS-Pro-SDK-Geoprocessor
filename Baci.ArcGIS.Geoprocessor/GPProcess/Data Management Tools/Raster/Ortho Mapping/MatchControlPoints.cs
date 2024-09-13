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
	/// <para>Match Control Points</para>
	/// <para>匹配控制点</para>
	/// <para>针对其中一个重叠影像中的给定地面控制点和初始连接点创建匹配的连接点。</para>
	/// </summary>
	public class MatchControlPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>镶嵌数据集，其中包含将从中创建连接点的源影像。</para>
		/// </param>
		/// <param name="InControlPoints">
		/// <para>Input Control Points</para>
		/// <para>输入控制点集，其中包含地面控制点要素列表，且每个地面控制点至少对应一个初始连接点。</para>
		/// </param>
		/// <param name="OutControlPoints">
		/// <para>Output Control Point Table</para>
		/// <para>包含地面控制点的输出控制点要素。</para>
		/// </param>
		public MatchControlPoints(object InMosaicDataset, object InControlPoints, object OutControlPoints)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.InControlPoints = InControlPoints;
			this.OutControlPoints = OutControlPoints;
		}

		/// <summary>
		/// <para>Tool Display Name : 匹配控制点</para>
		/// </summary>
		public override string DisplayName() => "匹配控制点";

		/// <summary>
		/// <para>Tool Name : MatchControlPoints</para>
		/// </summary>
		public override string ToolName() => "MatchControlPoints";

		/// <summary>
		/// <para>Tool Excute Name : management.MatchControlPoints</para>
		/// </summary>
		public override string ExcuteName() => "management.MatchControlPoints";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, InControlPoints, OutControlPoints, Similarity! };

		/// <summary>
		/// <para>Input Mosaic Dataset</para>
		/// <para>镶嵌数据集，其中包含将从中创建连接点的源影像。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Input Control Points</para>
		/// <para>输入控制点集，其中包含地面控制点要素列表，且每个地面控制点至少对应一个初始连接点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InControlPoints { get; set; }

		/// <summary>
		/// <para>Output Control Point Table</para>
		/// <para>包含地面控制点的输出控制点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutControlPoints { get; set; }

		/// <summary>
		/// <para>Similarity</para>
		/// <para>指定将用于匹配连接点的相似性级别。</para>
		/// <para>低级相似性—两个匹配点的相似性条件为低级。 此选项将生成最匹配的连接点对，但是某些匹配连接点对的错误误差等级可能比较高。</para>
		/// <para>中级相似性—此匹配点对的相似性等级为中级。</para>
		/// <para>高级相似性—此匹配点对的相似性等级为高级。 此选项将生成数目最少的匹配连接点对，但是每个匹配连接点对的误差等级可能比较低。</para>
		/// <para><see cref="SimilarityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Similarity { get; set; } = "HIGH";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MatchControlPoints SetEnviroment(object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Similarity</para>
		/// </summary>
		public enum SimilarityEnum 
		{
			/// <summary>
			/// <para>低级相似性—两个匹配点的相似性条件为低级。 此选项将生成最匹配的连接点对，但是某些匹配连接点对的错误误差等级可能比较高。</para>
			/// </summary>
			[GPValue("LOW")]
			[Description("低级相似性")]
			Low_similarity,

			/// <summary>
			/// <para>中级相似性—此匹配点对的相似性等级为中级。</para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("中级相似性")]
			Medium_similarity,

			/// <summary>
			/// <para>高级相似性—此匹配点对的相似性等级为高级。 此选项将生成数目最少的匹配连接点对，但是每个匹配连接点对的误差等级可能比较低。</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("高级相似性")]
			High_similarity,

		}

#endregion
	}
}
