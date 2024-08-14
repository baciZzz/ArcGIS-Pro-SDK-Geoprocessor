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
	/// <para>Alters the association role assigned to a network feature class or table  at the asset type level.</para>
	/// </summary>
	public class SetAssociationRole : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the asset type with an association role to set.</para>
		/// </param>
		/// <param name="DomainNetwork">
		/// <para>Domain Network</para>
		/// <para>The domain network that contains the asset type with an association role to set.</para>
		/// </param>
		/// <param name="Featureclass">
		/// <para>Input Table</para>
		/// <para>The utility network feature class or table where the association role will be set.</para>
		/// </param>
		/// <param name="Assetgroup">
		/// <para>Asset Group</para>
		/// <para>The asset group that contains the asset type.</para>
		/// </param>
		/// <param name="Assettype">
		/// <para>Asset Type</para>
		/// <para>The asset type that the association role will be set for.</para>
		/// </param>
		/// <param name="AssociationRoleType">
		/// <para>Role Type</para>
		/// <para>Specifies the type of association role to assign to the asset type.</para>
		/// <para>Container—Features or objects of this asset type can contain other features and objects as content.</para>
		/// <para>Structure—Features or objects of this asset type can have other features and objects attached to them.</para>
		/// <para>None—No role type will be assigned. These are features or objects that are neither a container nor a structure but do connect to other structures.</para>
		/// <para><see cref="AssociationRoleTypeEnum"/></para>
		/// </param>
		/// <param name="AssociationDeletionSemantics">
		/// <para>Deletion Semantics</para>
		/// <para>Specifies the deletion semantics for the features, which is how child features will be handled when the parent feature is deleted. This applies to both container and structure association roles.</para>
		/// <para>Cascade—When the parent container or structure is deleted, all content or attachment network features will be deleted.</para>
		/// <para>Set to none— When a container or structure is deleted, its content or attachment features and objects will not be deleted. Instead, it will be removed from the containment or structural attachment association.</para>
		/// <para>Restricted— If content or attachment features or objects exist, an error will be returned when attempting to delete the container or structure. The content or attachment features and objects must be removed before deleting the container or structure.</para>
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
		/// <para>Tool Display Name : Set Association Role</para>
		/// </summary>
		public override string DisplayName => "Set Association Role";

		/// <summary>
		/// <para>Tool Name : SetAssociationRole</para>
		/// </summary>
		public override string ToolName => "SetAssociationRole";

		/// <summary>
		/// <para>Tool Excute Name : un.SetAssociationRole</para>
		/// </summary>
		public override string ExcuteName => "un.SetAssociationRole";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InUtilityNetwork, DomainNetwork, Featureclass, Assetgroup, Assettype, AssociationRoleType, AssociationDeletionSemantics, ViewScale!, SplitContent!, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the asset type with an association role to set.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Domain Network</para>
		/// <para>The domain network that contains the asset type with an association role to set.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainNetwork { get; set; }

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The utility network feature class or table where the association role will be set.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Featureclass { get; set; }

		/// <summary>
		/// <para>Asset Group</para>
		/// <para>The asset group that contains the asset type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Assetgroup { get; set; }

		/// <summary>
		/// <para>Asset Type</para>
		/// <para>The asset type that the association role will be set for.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Assettype { get; set; }

		/// <summary>
		/// <para>Role Type</para>
		/// <para>Specifies the type of association role to assign to the asset type.</para>
		/// <para>Container—Features or objects of this asset type can contain other features and objects as content.</para>
		/// <para>Structure—Features or objects of this asset type can have other features and objects attached to them.</para>
		/// <para>None—No role type will be assigned. These are features or objects that are neither a container nor a structure but do connect to other structures.</para>
		/// <para><see cref="AssociationRoleTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AssociationRoleType { get; set; }

		/// <summary>
		/// <para>Deletion Semantics</para>
		/// <para>Specifies the deletion semantics for the features, which is how child features will be handled when the parent feature is deleted. This applies to both container and structure association roles.</para>
		/// <para>Cascade—When the parent container or structure is deleted, all content or attachment network features will be deleted.</para>
		/// <para>Set to none— When a container or structure is deleted, its content or attachment features and objects will not be deleted. Instead, it will be removed from the containment or structural attachment association.</para>
		/// <para>Restricted— If content or attachment features or objects exist, an error will be returned when attempting to delete the container or structure. The content or attachment features and objects must be removed before deleting the container or structure.</para>
		/// <para><see cref="AssociationDeletionSemanticsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AssociationDeletionSemantics { get; set; }

		/// <summary>
		/// <para>View Scale</para>
		/// <para>The scale at which containment mode will be entered to edit features participating in the container. For example, setting the view scale to 5 means that when you enter containment mode of the container feature, the scale will be 1:5. Units are based on the utility network units, which are located on the Source tab of the utility network layer properties pane. This property does not apply to junction and edge objects.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ViewScale { get; set; }

		/// <summary>
		/// <para>Split Content</para>
		/// <para>Specifies whether the associated content of a container will be split if the container feature is split. This parameter is only available if the association role is container and is only applicable for line features.</para>
		/// <para>Checked—The container&apos;s content will be split if the container feature is split. If a parallel content line feature is found, the content is also split and each section will be contained by the closest container feature. If the content line is not parallel, the content will be contained by the container feature that is closest to it.</para>
		/// <para>Unchecked—The container&apos;s content will not be split if the container feature is split. If a parallel content line feature is found, the content will be contained by both sections of the container feature. If the content line is not parallel, the content will be contained by the container feature that is closest to it. This is the default.</para>
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
			/// <para>None—No role type will be assigned. These are features or objects that are neither a container nor a structure but do connect to other structures.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>Container—Features or objects of this asset type can contain other features and objects as content.</para>
			/// </summary>
			[GPValue("CONTAINER")]
			[Description("Container")]
			Container,

			/// <summary>
			/// <para>Structure—Features or objects of this asset type can have other features and objects attached to them.</para>
			/// </summary>
			[GPValue("STRUCTURE")]
			[Description("Structure")]
			Structure,

		}

		/// <summary>
		/// <para>Deletion Semantics</para>
		/// </summary>
		public enum AssociationDeletionSemanticsEnum 
		{
			/// <summary>
			/// <para>Cascade—When the parent container or structure is deleted, all content or attachment network features will be deleted.</para>
			/// </summary>
			[GPValue("CASCADE")]
			[Description("Cascade")]
			Cascade,

			/// <summary>
			/// <para>Set to none— When a container or structure is deleted, its content or attachment features and objects will not be deleted. Instead, it will be removed from the containment or structural attachment association.</para>
			/// </summary>
			[GPValue("SET_TO_NONE")]
			[Description("Set to none")]
			Set_to_none,

			/// <summary>
			/// <para>Restricted— If content or attachment features or objects exist, an error will be returned when attempting to delete the container or structure. The content or attachment features and objects must be removed before deleting the container or structure.</para>
			/// </summary>
			[GPValue("RESTRICTED")]
			[Description("Restricted")]
			Restricted,

		}

		/// <summary>
		/// <para>Split Content</para>
		/// </summary>
		public enum SplitContentEnum 
		{
			/// <summary>
			/// <para>Checked—The container&apos;s content will be split if the container feature is split. If a parallel content line feature is found, the content is also split and each section will be contained by the closest container feature. If the content line is not parallel, the content will be contained by the container feature that is closest to it.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SPLIT")]
			SPLIT,

			/// <summary>
			/// <para>Unchecked—The container&apos;s content will not be split if the container feature is split. If a parallel content line feature is found, the content will be contained by both sections of the container feature. If the content line is not parallel, the content will be contained by the container feature that is closest to it. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_SPLIT")]
			DO_NOT_SPLIT,

		}

#endregion
	}
}
