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
		/// <para>生成的 LAS 数据集图层的名称。 可使用反斜线或正斜线表示图层组。</para>
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
		public override object[] Parameters() => new object[] { InLasDataset, OutLayer, ClassCode!, ReturnValues!, NoFlag!, Synthetic!, Keypoint!, Withheld!, SurfaceConstraints!, Overlap! };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// <para>生成的 LAS 数据集图层的名称。 可使用反斜线或正斜线表示图层组。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Class Codes</para>
		/// <para>指定将用于过滤 LAS 点的分类代码。 默认情况下会选择所有类代码。</para>
		/// <para>0—从不使用分类方法进行处理</para>
		/// <para>1—使用分类方法进行处理，但尚未确定</para>
		/// <para>2—裸露地面测量</para>
		/// <para>3—认为该区域的植被高度较低</para>
		/// <para>4—认为该区域的植被具有中等高度</para>
		/// <para>5—认为该区域的植被高度较高</para>
		/// <para>6—屋顶和墙面结构</para>
		/// <para>7—错误或接近地面的不必要数据</para>
		/// <para>8—保留以供日后使用，但用于 LAS 1.1 - 1.3 中的模型关键点</para>
		/// <para>9—水体</para>
		/// <para>10—火车使用的铁路轨道</para>
		/// <para>11—道路表面</para>
		/// <para>12—保留以供日后使用，但用于 LAS 1.1 - 1.3 中的重叠点</para>
		/// <para>13—电线周围的防护</para>
		/// <para>14—电力线</para>
		/// <para>15—用于支持架空电力线路的格架塔</para>
		/// <para>16—用于连接电路的机械装配</para>
		/// <para>17—桥的表面</para>
		/// <para>18—错误或远离地面的不必要数据</para>
		/// <para>19 - 63—为 ASPRS 指定保留的类代码</para>
		/// <para>64 - 255—用户自定义的类代码</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? ClassCode { get; set; }

		/// <summary>
		/// <para>Return Values</para>
		/// <para>指定将用于过滤 LAS 点的序数脉冲返回值。 如果未指定任何值，将使用所有回波。 回波信息仅适用于从激光雷达扫描仪收集的 LAS 点云。 回波数反映了从激光雷达脉冲中获得的离散点的顺序，即第一个回波距离扫描仪最近，最后一个回波距离扫描仪最远。</para>
		/// <para>LAST—将使用所有激光雷达脉冲的最后一个点。</para>
		/// <para>FIRST_OF_MANY—将使用具有多个回波的每个激光雷达脉冲的第一个点。</para>
		/// <para>LAST_OF_MANY—将使用具有多个回波的每个激光雷达脉冲的最后一个点。</para>
		/// <para>SINGLE—将使用仅具有一个回波的激光雷达脉冲的所有点。</para>
		/// <para>第 1 个回波—将使用返回值为 1 的所有点。</para>
		/// <para>第 2 个回波—将使用返回值为 2 的所有点。</para>
		/// <para>第 3 个回波—将使用返回值为 3 的所有点。</para>
		/// <para>第 4 个回波—将使用返回值为 4 的所有点。</para>
		/// <para>第 5 个回波—将使用返回值为 5 的所有点。</para>
		/// <para>第 6 个回波—将使用返回值为 6 的所有点。</para>
		/// <para>第 7 个回波—将使用返回值为 7 的所有点。</para>
		/// <para>第 8 个回波—将使用返回值为 8 的所有点。</para>
		/// <para>第 9 个回波—将使用返回值为 9 的所有点。</para>
		/// <para>第 10 个回波—将使用返回值为 10 的所有点。</para>
		/// <para>第 11 个回波—将使用返回值为 11 的所有点。</para>
		/// <para>第 12 个回波—将使用返回值为 12 的所有点。</para>
		/// <para>第 13 个回波—将使用返回值为 13 的所有点。</para>
		/// <para>第 14 个回波—将使用返回值为 14 的所有点。</para>
		/// <para>第 15 个回波—将使用返回值为 15 的所有点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? ReturnValues { get; set; }

		/// <summary>
		/// <para>Unflagged Points</para>
		/// <para>指定是否将包含未分配分类标记的数据点。</para>
		/// <para>选中 - 将包含无标记的点。 这是默认设置。</para>
		/// <para>未选中 - 将排除无标记的点。</para>
		/// <para><see cref="NoFlagEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? NoFlag { get; set; } = "true";

		/// <summary>
		/// <para>Synthetic Points</para>
		/// <para>指定是否包含标记为合成点的数据点。 合成点是指源自激光雷达扫描仪以外数据源的 LAS 点。</para>
		/// <para>选中 - 将包含合成点。 这是默认设置。</para>
		/// <para>未选中 - 将排除合成点。</para>
		/// <para><see cref="SyntheticEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Synthetic { get; set; } = "true";

		/// <summary>
		/// <para>Model Key-Point</para>
		/// <para>指定是否包含标记为模型关键点的数据点。 模型关键点是指对与其关联的对象建模具有重要意义的 LAS 点。</para>
		/// <para>选中 - 将包含模型关键点。 这是默认设置。</para>
		/// <para>未选中 - 将排除模型关键点。</para>
		/// <para><see cref="KeypointEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Keypoint { get; set; } = "true";

		/// <summary>
		/// <para>Withheld Points</para>
		/// <para>指定是否包含标记为保留点的数据点。 保留点表示在 LAS 点中捕获的错误或不需要的测量值。</para>
		/// <para>选中 - 将包含保留点。</para>
		/// <para>未选中 - 将排除保留点。 这是默认设置。</para>
		/// <para><see cref="WithheldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Withheld { get; set; } = "false";

		/// <summary>
		/// <para>Surface Constraints</para>
		/// <para>图层中将启用的表面约束要素的名称。 默认情况下，所有约束均启用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? SurfaceConstraints { get; set; }

		/// <summary>
		/// <para>Overlap Points</para>
		/// <para>指定是否包含标记为重叠点的数据点。 重叠点是指在重叠扫描中采集的点，这些点通常具有较大的扫描角度。 过滤重叠点有助于确保在整个数据范围内实现 LAS 点的规则分布。</para>
		/// <para>选中 - 将包含重叠点。 这是默认设置。</para>
		/// <para>未选中 - 将排除重叠点。</para>
		/// <para><see cref="OverlapEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Overlap { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeLasDatasetLayer SetEnviroment(object? workspace = null )
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
