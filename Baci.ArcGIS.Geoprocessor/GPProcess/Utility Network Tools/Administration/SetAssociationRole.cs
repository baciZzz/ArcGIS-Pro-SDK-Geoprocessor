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
	/// <para>Set Association Role</para>
	/// <para>设置关联角色</para>
	/// <para>用于更改分配到网络要素类或表的资产类型级别关联角色。</para>
	/// </summary>
	public class SetAssociationRole : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>公共设施网络，其中包含要设置关联角色的资产类型。</para>
		/// </param>
		/// <param name="DomainNetwork">
		/// <para>Domain Network</para>
		/// <para>域网络，其中包含要设置关联角色的资产类型。</para>
		/// </param>
		/// <param name="Featureclass">
		/// <para>Input Table</para>
		/// <para>将设置关联角色的公共设施网络要素类或表。</para>
		/// </param>
		/// <param name="Assetgroup">
		/// <para>Asset Group</para>
		/// <para>包含资产类型的资产组。</para>
		/// </param>
		/// <param name="Assettype">
		/// <para>Asset Type</para>
		/// <para>将为其设置关联角色的资产类型。</para>
		/// </param>
		/// <param name="AssociationRoleType">
		/// <para>Role Type</para>
		/// <para>指定要分配到资产类型的关联角色的类型。</para>
		/// <para>容器—该资产类型的要素或对象可以将其他要素或对象包含为内容。</para>
		/// <para>结构—该资产类型的要素或对象可以附加其他要素或对象。</para>
		/// <para>无—未分配角色类型。 这些要素或对象既不是容器，也不是结构，但确实与其他结构相连接。</para>
		/// <para><see cref="AssociationRoleTypeEnum"/></para>
		/// </param>
		/// <param name="AssociationDeletionSemantics">
		/// <para>Deletion Semantics</para>
		/// <para>指定要素的删除语义；即删除父要素后如何处理子要素。 这适用于容器和结构关联角色。</para>
		/// <para>级联—删除父容器或结构时，所有内容或附件网络要素也会一并删除。</para>
		/// <para>设为无—删除容器或结构时，不会删除其内容或附件要素和对象。 但是，会从包含或结构附件关联中将其移除。</para>
		/// <para>受限—如果存在内容或附件要素或对象，则在尝试删除容器或结构时将返回错误。 必须移除内容或附件要素和对象后，才能删除容器或结构。</para>
		/// <para><see cref="AssociationDeletionSemanticsEnum"/></para>
		/// </param>
		public SetAssociationRole(object InUtilityNetwork, object DomainNetwork, object Featureclass, object Assetgroup, object Assettype, object AssociationRoleType, object AssociationDeletionSemantics)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.DomainNetwork = DomainNetwork;
			this.Featureclass = Featureclass;
			this.Assetgroup = Assetgroup;
			this.Assettype = Assettype;
			this.AssociationRoleType = AssociationRoleType;
			this.AssociationDeletionSemantics = AssociationDeletionSemantics;
		}

		/// <summary>
		/// <para>Tool Display Name : 设置关联角色</para>
		/// </summary>
		public override string DisplayName() => "设置关联角色";

		/// <summary>
		/// <para>Tool Name : SetAssociationRole</para>
		/// </summary>
		public override string ToolName() => "SetAssociationRole";

		/// <summary>
		/// <para>Tool Excute Name : un.SetAssociationRole</para>
		/// </summary>
		public override string ExcuteName() => "un.SetAssociationRole";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, DomainNetwork, Featureclass, Assetgroup, Assettype, AssociationRoleType, AssociationDeletionSemantics, ViewScale!, SplitContent!, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>公共设施网络，其中包含要设置关联角色的资产类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Domain Network</para>
		/// <para>域网络，其中包含要设置关联角色的资产类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainNetwork { get; set; }

		/// <summary>
		/// <para>Input Table</para>
		/// <para>将设置关联角色的公共设施网络要素类或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Featureclass { get; set; }

		/// <summary>
		/// <para>Asset Group</para>
		/// <para>包含资产类型的资产组。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Assetgroup { get; set; }

		/// <summary>
		/// <para>Asset Type</para>
		/// <para>将为其设置关联角色的资产类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Assettype { get; set; }

		/// <summary>
		/// <para>Role Type</para>
		/// <para>指定要分配到资产类型的关联角色的类型。</para>
		/// <para>容器—该资产类型的要素或对象可以将其他要素或对象包含为内容。</para>
		/// <para>结构—该资产类型的要素或对象可以附加其他要素或对象。</para>
		/// <para>无—未分配角色类型。 这些要素或对象既不是容器，也不是结构，但确实与其他结构相连接。</para>
		/// <para><see cref="AssociationRoleTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AssociationRoleType { get; set; }

		/// <summary>
		/// <para>Deletion Semantics</para>
		/// <para>指定要素的删除语义；即删除父要素后如何处理子要素。 这适用于容器和结构关联角色。</para>
		/// <para>级联—删除父容器或结构时，所有内容或附件网络要素也会一并删除。</para>
		/// <para>设为无—删除容器或结构时，不会删除其内容或附件要素和对象。 但是，会从包含或结构附件关联中将其移除。</para>
		/// <para>受限—如果存在内容或附件要素或对象，则在尝试删除容器或结构时将返回错误。 必须移除内容或附件要素和对象后，才能删除容器或结构。</para>
		/// <para><see cref="AssociationDeletionSemanticsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AssociationDeletionSemantics { get; set; }

		/// <summary>
		/// <para>View Scale</para>
		/// <para>将输入包含模式比例，以开始编辑参与容器的要素。 例如，将视图比例设置为 5 意味着当您进入容器要素的包含模式时，比例将为 1:5。 单位基于公共设施网络图层属性窗格的源选项卡上的公共设施网络单位。 此属性不适用于交汇点和边对象。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ViewScale { get; set; }

		/// <summary>
		/// <para>Split Content</para>
		/// <para>指定对容器要素进行分割后，是否分割容器的关联内容。 仅当关联角色为容器时，此参数才可用，并且仅适用于线要素。</para>
		/// <para>选中 - 如果对容器要素进行分割，则分割容器的内容。 如果找到平行内容线要素，也会对内容进行分割，并且每部分将包含在最近的容器要素内。 如果内容线不平行，则内容将包含在最近的容器要素内。</para>
		/// <para>未选中 - 如果对容器要素进行分割，不会分割容器的内容。 如果找到平行内容线要素，则内容将包含在容器要素的两个部分中。 如果内容线不平行，则内容将包含在最近的容器要素内。 这是默认设置。</para>
		/// <para><see cref="SplitContentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SplitContent { get; set; } = "false";

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object? OutUtilityNetwork { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Role Type</para>
		/// </summary>
		public enum AssociationRoleTypeEnum 
		{
			/// <summary>
			/// <para>无—未分配角色类型。 这些要素或对象既不是容器，也不是结构，但确实与其他结构相连接。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>容器—该资产类型的要素或对象可以将其他要素或对象包含为内容。</para>
			/// </summary>
			[GPValue("CONTAINER")]
			[Description("容器")]
			Container,

			/// <summary>
			/// <para>结构—该资产类型的要素或对象可以附加其他要素或对象。</para>
			/// </summary>
			[GPValue("STRUCTURE")]
			[Description("结构")]
			Structure,

		}

		/// <summary>
		/// <para>Deletion Semantics</para>
		/// </summary>
		public enum AssociationDeletionSemanticsEnum 
		{
			/// <summary>
			/// <para>级联—删除父容器或结构时，所有内容或附件网络要素也会一并删除。</para>
			/// </summary>
			[GPValue("CASCADE")]
			[Description("级联")]
			Cascade,

			/// <summary>
			/// <para>设为无—删除容器或结构时，不会删除其内容或附件要素和对象。 但是，会从包含或结构附件关联中将其移除。</para>
			/// </summary>
			[GPValue("SET_TO_NONE")]
			[Description("设为无")]
			Set_to_none,

			/// <summary>
			/// <para>受限—如果存在内容或附件要素或对象，则在尝试删除容器或结构时将返回错误。 必须移除内容或附件要素和对象后，才能删除容器或结构。</para>
			/// </summary>
			[GPValue("RESTRICTED")]
			[Description("受限")]
			Restricted,

		}

		/// <summary>
		/// <para>Split Content</para>
		/// </summary>
		public enum SplitContentEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SPLIT")]
			SPLIT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_SPLIT")]
			DO_NOT_SPLIT,

		}

#endregion
	}
}
