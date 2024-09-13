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
	/// <para>Make LAS Dataset Layer</para>
	/// <para>创建 LAS 数据集图层</para>
	/// <para>创建可将过滤器应用于 LAS 点并可控制表面约束要素强化的 LAS 数据集图层。</para>
	/// </summary>
	public class MakeLasDatasetLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output Layer</para>
		/// <para>生成的 LAS 数据集图层的名称。可使用反斜线或正斜线表示图层组。</para>
		/// </param>
		public MakeLasDatasetLayer(object InLasDataset, object OutLayer)
		{
			this.InLasDataset = InLasDataset;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 LAS 数据集图层</para>
		/// </summary>
		public override string DisplayName() => "创建 LAS 数据集图层";

		/// <summary>
		/// <para>Tool Name : MakeLasDatasetLayer</para>
		/// </summary>
		public override string ToolName() => "MakeLasDatasetLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeLasDatasetLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.MakeLasDatasetLayer";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, OutLayer, ClassCode, ReturnValues, NoFlag, Synthetic, Keypoint, Withheld, SurfaceConstraints, Overlap };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// <para>生成的 LAS 数据集图层的名称。可使用反斜线或正斜线表示图层组。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Class Codes</para>
		/// <para>允许通过分类代码过滤 LAS 点。有效值的范围将取决于 LAS 数据集引用的 LAS 文件版本所支持的类代码。默认情况下会选择所有类代码。</para>
		/// <para>0—从不使用分类方法进行处理</para>
		/// <para>1—使用分类方法进行处理，但尚未确定</para>
		/// <para>2—裸露地面测量</para>
		/// <para>3—认为该区域的植被高度较低</para>
		/// <para>4—认为该区域的植被具有中等高度</para>
		/// <para>5—认为该区域的植被高度较高</para>
		/// <para>6—屋顶和墙面结构</para>
		/// <para>7—错误或接近地面的不必要数据</para>
		/// <para>8—保留以供日后使用，但用于 LAS 1.1 - 1.3 中的模型关键点</para>
		/// <para>9—水域</para>
		/// <para>10—火车使用的铁路轨道</para>
		/// <para>11—道路表面</para>
		/// <para>12—保留以供日后使用，但用于 LAS 1.1 - 1.3 中的重叠点</para>
		/// <para>13—电线周围的防护</para>
		/// <para>14—电力线</para>
		/// <para>15—用于支持架空电力线路的格架塔</para>
		/// <para>16—用于连接电路的机械装配</para>
		/// <para>17—桥的表面</para>
		/// <para>18—错误或远离地面的不必要数据</para>
		/// <para>19 - 63—为 ASPRS 指定保留的类代码。</para>
		/// <para>64 - 255—用户自定义的类代码。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object ClassCode { get; set; }

		/// <summary>
		/// <para>Return Values</para>
		/// <para>用于过滤 LAS 点的返回值。如果未指定任何值，将使用所有返回值。</para>
		/// <para>最后回波—最后回波</para>
		/// <para>第一个多重回波—多个回波中的第一个</para>
		/// <para>最后一个多重回波—多个回波中的最后一个</para>
		/// <para>单一回波—单一回波</para>
		/// <para>第 1 个回波—第 1 个回波</para>
		/// <para>第 2 个回波—第 2 个回波</para>
		/// <para>第 3 个回波—第 3 个回波</para>
		/// <para>第 4 个回波—第 4 个回波</para>
		/// <para>第 5 个回波—第 5 个回波</para>
		/// <para>第 6 个回波—第 6 个回波</para>
		/// <para>第 7 个回波—第 7 个回波</para>
		/// <para>第 8 个回波—第 8 个回波</para>
		/// <para>第 9 个回波—第 9 个回波</para>
		/// <para>第 10 个回波—第 10 个回波</para>
		/// <para>第 11 个回波—第 11 个回波</para>
		/// <para>第 12 个回波—第 12 个回波</para>
		/// <para>第 13 个回波—第 13 个回波</para>
		/// <para>第 14 个回波—第 14 个回波</para>
		/// <para>第 15 个回波—第 15 个回波</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object ReturnValues { get; set; }

		/// <summary>
		/// <para>Unflagged Points</para>
		/// <para>指定是否应启用未分配任何分类标记的数据点以用于显示和分析。</para>
		/// <para>选中 - 将显示无标记的点。这是默认设置。</para>
		/// <para>未选中 - 不显示无标记的点。</para>
		/// <para><see cref="NoFlagEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object NoFlag { get; set; } = "true";

		/// <summary>
		/// <para>Synthetic Points</para>
		/// <para>指定应启用标记为合成点的数据点，还是启用源自非激光雷达数据源的点，以用于显示和分析。</para>
		/// <para>选中 - 将显示合成点。这是默认设置。</para>
		/// <para>未选中 - 不显示合成点。</para>
		/// <para><see cref="SyntheticEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Synthetic { get; set; } = "true";

		/// <summary>
		/// <para>Model Key-Point</para>
		/// <para>指定应启用标记为模型关键点的数据点，还是启用不应被细化掉的重要测量点，以用于显示和分析。</para>
		/// <para>选中 - 将显示模型关键点。这是默认设置。</para>
		/// <para>未选中 - 不显示模型关键点。</para>
		/// <para><see cref="KeypointEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Keypoint { get; set; } = "true";

		/// <summary>
		/// <para>Withheld Points</para>
		/// <para>指定是否应启用标记为保留点的数据点（这些点通常表示不需要的噪音测量点）以用于显示和分析。</para>
		/// <para>取消选中 - 不显示保留点。这是默认设置。</para>
		/// <para>选中 - 将显示保留点。</para>
		/// <para><see cref="WithheldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Withheld { get; set; } = "false";

		/// <summary>
		/// <para>Surface Constraints</para>
		/// <para>图层中将启用的表面约束要素的名称。默认情况下，所有约束均启用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object SurfaceConstraints { get; set; }

		/// <summary>
		/// <para>Overlap Points</para>
		/// <para>指定是否应启用标记为重叠的数据点，以用于显示和分析。</para>
		/// <para>选中 - 将显示重叠的点。这是默认设置。</para>
		/// <para>未选中 - 不显示重叠的点。</para>
		/// <para><see cref="OverlapEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Overlap { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeLasDatasetLayer SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Unflagged Points</para>
		/// </summary>
		public enum NoFlagEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_UNFLAGGED")]
			INCLUDE_UNFLAGGED,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_UNFLAGGED")]
			EXCLUDE_UNFLAGGED,

		}

		/// <summary>
		/// <para>Synthetic Points</para>
		/// </summary>
		public enum SyntheticEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_SYNTHETIC")]
			INCLUDE_SYNTHETIC,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_SYNTHETIC")]
			EXCLUDE_SYNTHETIC,

		}

		/// <summary>
		/// <para>Model Key-Point</para>
		/// </summary>
		public enum KeypointEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_KEYPOINT")]
			INCLUDE_KEYPOINT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_KEYPOINT")]
			EXCLUDE_KEYPOINT,

		}

		/// <summary>
		/// <para>Withheld Points</para>
		/// </summary>
		public enum WithheldEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_WITHHELD")]
			INCLUDE_WITHHELD,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_WITHHELD")]
			EXCLUDE_WITHHELD,

		}

		/// <summary>
		/// <para>Overlap Points</para>
		/// </summary>
		public enum OverlapEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_OVERLAP")]
			INCLUDE_OVERLAP,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_OVERLAP")]
			EXCLUDE_OVERLAP,

		}

#endregion
	}
}
