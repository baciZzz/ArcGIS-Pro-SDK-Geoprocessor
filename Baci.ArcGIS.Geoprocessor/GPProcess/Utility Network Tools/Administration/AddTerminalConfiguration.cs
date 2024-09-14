using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.UtilityNetworkTools
{
	/// <summary>
	/// <para>Add Terminal Configuration</para>
	/// <para>添加终端配置</para>
	/// <para>用于向现有公共设施网络添加终端配置。</para>
	/// </summary>
	public class AddTerminalConfiguration : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>将添加终端配置的输入公共设施网络。</para>
		/// </param>
		/// <param name="TerminalConfigurationName">
		/// <para>Name</para>
		/// <para>终端配置的名称。</para>
		/// </param>
		/// <param name="TraversabilityModel">
		/// <para>Directionality</para>
		/// <para>指定终端配置的方向性。 定向可遍历性模型意味着终端的流动仅有一个方向。 双向可遍历性模型意味着终端允许双向流动。</para>
		/// <para>定向—仅允许一个流向。</para>
		/// <para>双向—允许两个流向。</para>
		/// <para><see cref="TraversabilityModelEnum"/></para>
		/// </param>
		public AddTerminalConfiguration(object InUtilityNetwork, object TerminalConfigurationName, object TraversabilityModel)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TerminalConfigurationName = TerminalConfigurationName;
			this.TraversabilityModel = TraversabilityModel;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加终端配置</para>
		/// </summary>
		public override string DisplayName() => "添加终端配置";

		/// <summary>
		/// <para>Tool Name : AddTerminalConfiguration</para>
		/// </summary>
		public override string ToolName() => "AddTerminalConfiguration";

		/// <summary>
		/// <para>Tool Excute Name : un.AddTerminalConfiguration</para>
		/// </summary>
		public override string ExcuteName() => "un.AddTerminalConfiguration";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise() => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, TerminalConfigurationName, TraversabilityModel, TerminalsDirectional!, TerminalsBidirectional!, ValidPaths!, DefaultPath!, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>将添加终端配置的输入公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// <para>终端配置的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TerminalConfigurationName { get; set; }

		/// <summary>
		/// <para>Directionality</para>
		/// <para>指定终端配置的方向性。 定向可遍历性模型意味着终端的流动仅有一个方向。 双向可遍历性模型意味着终端允许双向流动。</para>
		/// <para>定向—仅允许一个流向。</para>
		/// <para>双向—允许两个流向。</para>
		/// <para><see cref="TraversabilityModelEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TraversabilityModel { get; set; } = "DIRECTIONAL";

		/// <summary>
		/// <para>Terminals</para>
		/// <para>每个定向终端的名称和方向流。 最少必须指定 2 个终端，最多可以指定 8 个终端。 每个终端的名称不能超过 32 个字符。 如果方向性参数值为定向，则此参数为必需项。</para>
		/// <para>名称 - 提供终端的名称。</para>
		/// <para>上游 - 指示终端为上游或下游。</para>
		/// <para>选中 - 终端为上游。</para>
		/// <para>未选中 - 终端为下游。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? TerminalsDirectional { get; set; }

		/// <summary>
		/// <para>Terminals</para>
		/// <para>每个双向终端的名称。 最少必须指定 2 个终端，最多可以指定 8 个终端。 每个终端的名称不能超过 32 个字符。 如果方向性参数值为双向（在 Python 中为 traversability_model = "BIDIRECTIONAL"），则此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? TerminalsBidirectional { get; set; }

		/// <summary>
		/// <para>Valid Path(s)</para>
		/// <para>终端配置的有效路径的名称。 对于双向可遍历性，如果存在三个或四个终端，则需要此参数。 如果使用定向可遍历性，则其中一个终端必须为上游，才能具有有效配置。 必须创建有效路径才能指示设备或交汇点对象内要遍历的资源的有效路径。 为每个有效路径提供名称并指定值。</para>
		/// <para>名称 - 有效路径的名称。</para>
		/// <para>值 - 有效路径的值。</para>
		/// <para>全部 - 输入值“全部”以创建一个选项，表示所有路径均有效。</para>
		/// <para>无 - 输入值“无”以创建一个选项，表示所有路径均无效。</para>
		/// <para>终端对 - 输入单个终端对或终端对集合。 输入单个终端对，方法是指定从一个终端到另一个终端的路径，使用连字符分隔，例如，A-B。 输入通过逗号分隔的终端对集合，例如，A-B, A-C。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? ValidPaths { get; set; }

		/// <summary>
		/// <para>Default Path</para>
		/// <para>有效配置的默认路径。 该路径将分配至将此终端配置分配至其资产类型的新要素。 如果未指定有效路径，将使用默认路径全部。</para>
		/// <para>全部 - 所有路径均有效。 这是默认设置。</para>
		/// <para>无 - 所有路径均无效。</para>
		/// <para>有效路径 - 在有效路径参数中指定的有效路径。</para>
		/// <para><see cref="DefaultPathEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DefaultPath { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object? OutUtilityNetwork { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Directionality</para>
		/// </summary>
		public enum TraversabilityModelEnum 
		{
			/// <summary>
			/// <para>定向—仅允许一个流向。</para>
			/// </summary>
			[GPValue("DIRECTIONAL")]
			[Description("定向")]
			Directional,

			/// <summary>
			/// <para>双向—允许两个流向。</para>
			/// </summary>
			[GPValue("BIDIRECTIONAL")]
			[Description("双向")]
			Bidirectional,

		}

		/// <summary>
		/// <para>Default Path</para>
		/// </summary>
		public enum DefaultPathEnum 
		{
			/// <summary>
			/// <para>全部 - 所有路径均有效。 这是默认设置。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("全部")]
			All,

			/// <summary>
			/// <para>无 - 所有路径均无效。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

		}

#endregion
	}
}
