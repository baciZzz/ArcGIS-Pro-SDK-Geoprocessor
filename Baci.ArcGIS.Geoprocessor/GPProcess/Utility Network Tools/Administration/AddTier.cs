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
	/// <para>Add Tier</para>
	/// <para>添加层</para>
	/// <para>在公共设施网络中针对域网络创建新层。</para>
	/// </summary>
	public class AddTier : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>包含域网络的公共设施网络，将向该域网络中添加层。</para>
		/// </param>
		/// <param name="DomainNetwork">
		/// <para>Domain Network</para>
		/// <para>将要创建该层的域网络。</para>
		/// </param>
		/// <param name="Name">
		/// <para>Name</para>
		/// <para>新层的名称。该名称在整个公共设施网络中必须唯一。</para>
		/// </param>
		/// <param name="Rank">
		/// <para>Rank</para>
		/// <para>正在添加的层的等级。最高等级是第 1 级。</para>
		/// </param>
		public AddTier(object InUtilityNetwork, object DomainNetwork, object Name, object Rank)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.DomainNetwork = DomainNetwork;
			this.Name = Name;
			this.Rank = Rank;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加层</para>
		/// </summary>
		public override string DisplayName() => "添加层";

		/// <summary>
		/// <para>Tool Name : AddTier</para>
		/// </summary>
		public override string ToolName() => "AddTier";

		/// <summary>
		/// <para>Tool Excute Name : un.AddTier</para>
		/// </summary>
		public override string ExcuteName() => "un.AddTier";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, DomainNetwork, Name, Rank, TopologyType!, TierGroupName!, SubnetworkFieldName!, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>包含域网络的公共设施网络，将向该域网络中添加层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Domain Network</para>
		/// <para>将要创建该层的域网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainNetwork { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// <para>新层的名称。该名称在整个公共设施网络中必须唯一。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Rank</para>
		/// <para>正在添加的层的等级。最高等级是第 1 级。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object Rank { get; set; }

		/// <summary>
		/// <para>Topology Type</para>
		/// <para>指定新层的拓扑类型。具有径向和网格拓扑类型的子网均支持一个或多个子网控制器。如果使用等级层定义创建了输入域网络并且拓扑类型默认为网格，则将在工具对话框上禁用此参数。如果使用分区层定义创建了域网络，则此参数将在下拉列表中列出所有拓扑类型。</para>
		/// <para>对于追踪或子网管理，此参数当前不提供行为差异。此参数的功能正在研发中，且将在未来的版本中适用。</para>
		/// <para><see cref="TopologyTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TopologyType { get; set; }

		/// <summary>
		/// <para>Tier Group Name</para>
		/// <para>将添加新层的现有层组。对于具有等级层定义的域网络，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? TierGroupName { get; set; }

		/// <summary>
		/// <para>Subnetwork Field Name</para>
		/// <para>将在其中存储该层子网名称的字段名称。该字段为系统维护字段，将在第一次将层添加到层组并重新用于任何附加层时创建该字段。例如，您有两个层组：Distribution 和 Transmission。当您将名为 system 的层添加到 Distribution 组，并将子网字段名称指定为 systemsubnet 时，将创建该字段。接下来，您要将第二个名为 system 的层添加到 Transmission 组。此参数将检测到应将 systemsubnet 字段用作子网字段名称。此参数是等级层类型的必要参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? SubnetworkFieldName { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object? OutUtilityNetwork { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Topology Type</para>
		/// </summary>
		public enum TopologyTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("RADIAL")]
			[Description("半径")]
			Radial,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("MESH")]
			[Description("网格")]
			Mesh,

		}

#endregion
	}
}
