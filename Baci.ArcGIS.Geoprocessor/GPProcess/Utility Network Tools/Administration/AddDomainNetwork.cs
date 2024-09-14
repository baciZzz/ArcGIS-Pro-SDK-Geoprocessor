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
	/// <para>Add Domain Network</para>
	/// <para>添加域网络</para>
	/// <para>用于向公共设施网络添加域网络。</para>
	/// </summary>
	public class AddDomainNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>将添加域网络的公共设施网络。</para>
		/// </param>
		/// <param name="DomainNetworkName">
		/// <para>Domain Network Name</para>
		/// <para>新域网络的名称。域网络名称将作为创建的要素类名称的前缀。例如，名称为 ElectricDistribution 的域将包含名称为 ElectricDistributionJunction 的要素类。</para>
		/// </param>
		/// <param name="TierDefinition">
		/// <para>Tier Definition</para>
		/// <para>指定新域网络的层定义。</para>
		/// <para>等级—层将被定义为等级层。在等级域网络中，层之间相互嵌套，所以较低级别层的子网中存在的要素会自然参与到所有较高级别的层中。例如，在燃气网络中，阀门隔离区存在于压力区中，而压力区又存在于系统区中。隔离区中的要素同时还存在于压力区和系统区中。</para>
		/// <para>分区— 层将被定义为分区层。分区域网络中的要素仅存在于一个层中。层之间的关系按线性排列。要素可以存在于一个层内的一个或多个子网中。</para>
		/// <para><see cref="TierDefinitionEnum"/></para>
		/// </param>
		/// <param name="SubnetworkControllerType">
		/// <para>Subnetwork Controller Type</para>
		/// <para>指定新域网络的子网控制器类型。</para>
		/// <para>子网源—子网控制器类型是一组源。源是已交付资源的原点。例如，在电气系统中，电力源是指发电站和变电站。</para>
		/// <para>子网汇—子网控制器类型是一组汇。汇是所收集的资源的目的地。</para>
		/// <para><see cref="SubnetworkControllerTypeEnum"/></para>
		/// </param>
		public AddDomainNetwork(object InUtilityNetwork, object DomainNetworkName, object TierDefinition, object SubnetworkControllerType)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.DomainNetworkName = DomainNetworkName;
			this.TierDefinition = TierDefinition;
			this.SubnetworkControllerType = SubnetworkControllerType;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加域网络</para>
		/// </summary>
		public override string DisplayName() => "添加域网络";

		/// <summary>
		/// <para>Tool Name : AddDomainNetwork</para>
		/// </summary>
		public override string ToolName() => "AddDomainNetwork";

		/// <summary>
		/// <para>Tool Excute Name : un.AddDomainNetwork</para>
		/// </summary>
		public override string ExcuteName() => "un.AddDomainNetwork";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, DomainNetworkName, TierDefinition, SubnetworkControllerType, DomainNetworkAliasName, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>将添加域网络的公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Domain Network Name</para>
		/// <para>新域网络的名称。域网络名称将作为创建的要素类名称的前缀。例如，名称为 ElectricDistribution 的域将包含名称为 ElectricDistributionJunction 的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainNetworkName { get; set; }

		/// <summary>
		/// <para>Tier Definition</para>
		/// <para>指定新域网络的层定义。</para>
		/// <para>等级—层将被定义为等级层。在等级域网络中，层之间相互嵌套，所以较低级别层的子网中存在的要素会自然参与到所有较高级别的层中。例如，在燃气网络中，阀门隔离区存在于压力区中，而压力区又存在于系统区中。隔离区中的要素同时还存在于压力区和系统区中。</para>
		/// <para>分区— 层将被定义为分区层。分区域网络中的要素仅存在于一个层中。层之间的关系按线性排列。要素可以存在于一个层内的一个或多个子网中。</para>
		/// <para><see cref="TierDefinitionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TierDefinition { get; set; }

		/// <summary>
		/// <para>Subnetwork Controller Type</para>
		/// <para>指定新域网络的子网控制器类型。</para>
		/// <para>子网源—子网控制器类型是一组源。源是已交付资源的原点。例如，在电气系统中，电力源是指发电站和变电站。</para>
		/// <para>子网汇—子网控制器类型是一组汇。汇是所收集的资源的目的地。</para>
		/// <para><see cref="SubnetworkControllerTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SubnetworkControllerType { get; set; }

		/// <summary>
		/// <para>Domain Network Alias Name</para>
		/// <para>域网络的别名。此可选参数用于为域网络提供更具描述性的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DomainNetworkAliasName { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Tier Definition</para>
		/// </summary>
		public enum TierDefinitionEnum 
		{
			/// <summary>
			/// <para>等级—层将被定义为等级层。在等级域网络中，层之间相互嵌套，所以较低级别层的子网中存在的要素会自然参与到所有较高级别的层中。例如，在燃气网络中，阀门隔离区存在于压力区中，而压力区又存在于系统区中。隔离区中的要素同时还存在于压力区和系统区中。</para>
			/// </summary>
			[GPValue("HIERARCHICAL")]
			[Description("等级")]
			Hierarchical,

			/// <summary>
			/// <para>分区— 层将被定义为分区层。分区域网络中的要素仅存在于一个层中。层之间的关系按线性排列。要素可以存在于一个层内的一个或多个子网中。</para>
			/// </summary>
			[GPValue("PARTITIONED")]
			[Description("分区")]
			Partitioned,

		}

		/// <summary>
		/// <para>Subnetwork Controller Type</para>
		/// </summary>
		public enum SubnetworkControllerTypeEnum 
		{
			/// <summary>
			/// <para>子网源—子网控制器类型是一组源。源是已交付资源的原点。例如，在电气系统中，电力源是指发电站和变电站。</para>
			/// </summary>
			[GPValue("SOURCE")]
			[Description("子网源")]
			Subnetwork_source,

			/// <summary>
			/// <para>子网汇—子网控制器类型是一组汇。汇是所收集的资源的目的地。</para>
			/// </summary>
			[GPValue("SINK")]
			[Description("子网汇")]
			Subnetwork_sink,

		}

#endregion
	}
}
