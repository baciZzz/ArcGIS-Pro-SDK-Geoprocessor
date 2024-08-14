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
	/// <para>Alter Domain</para>
	/// <para>Alters the properties of an existing attribute domain in a workspace.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AlterDomain : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>The geodatabase that contains the domain to be altered.</para>
		/// </param>
		/// <param name="DomainName">
		/// <para>Domain Name</para>
		/// <para>The name of the domain to be altered.</para>
		/// </param>
		public AlterDomain(object InWorkspace, object DomainName)
		{
			this.InWorkspace = InWorkspace;
			this.DomainName = DomainName;
		}

		/// <summary>
		/// <para>Tool Display Name : Alter Domain</para>
		/// </summary>
		public override string DisplayName => "Alter Domain";

		/// <summary>
		/// <para>Tool Name : AlterDomain</para>
		/// </summary>
		public override string ToolName => "AlterDomain";

		/// <summary>
		/// <para>Tool Excute Name : management.AlterDomain</para>
		/// </summary>
		public override string ExcuteName => "management.AlterDomain";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InWorkspace, DomainName, NewDomainName, NewDomainDescription, SplitPolicy, MergePolicy, OutWorkspace };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>The geodatabase that contains the domain to be altered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Domain Name</para>
		/// <para>The name of the domain to be altered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainName { get; set; }

		/// <summary>
		/// <para>New Domain Name</para>
		/// <para>The new name of the domain.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object NewDomainName { get; set; }

		/// <summary>
		/// <para>New Domain Description</para>
		/// <para>The new description of the domain.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object NewDomainDescription { get; set; }

		/// <summary>
		/// <para>New Split Policy</para>
		/// <para>The split policy of the domain. The behavior of an attribute&apos;s values when a feature that is split is controlled by its split policy.</para>
		/// <para>Use the attribute&apos;s default value—The attributes of the two resulting features take on the default value of the attribute of the given feature class or subtype.</para>
		/// <para>Duplicate attribute values—The attribute of the two resulting features takes on a copy of the original object&apos;s attribute value.</para>
		/// <para>Use geometric ratio—The attributes of resulting features are a ratio of the original feature&apos;s value. The ratio is based on the proportion into which the original geometry is divided. If the geometry is divided equally, each new feature&apos;s attribute gets one-half the value of the original object&apos;s attribute. The geometry ratio policy only applies to range domains.</para>
		/// <para><see cref="SplitPolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SplitPolicy { get; set; } = "DEFAULT";

		/// <summary>
		/// <para>New Merge Policy</para>
		/// <para>The merge policy of the domain. When two features are merged into a single feature, merge policies control attribute values in the new feature. Altering this property applies only to range domains, as coded value domains may only use the default merge policy.</para>
		/// <para>Use the attribute&apos;s default value—The attribute of the resulting feature takes on the default value of the attribute of the given feature class or subtype. This is the only merge policy that applies to nonnumeric fields and coded value domains.</para>
		/// <para>Sum of the values—The attribute of the resulting feature takes on the sum of the values from the original feature&apos;s attribute. The sum values policy only applies to range domains.</para>
		/// <para>Area weighted average—The attribute of the resulting feature is the weighted average of the attribute values of the original features. This average is based on the original feature&apos;s geometry. The area weighted policy only applies to range domains.</para>
		/// <para><see cref="MergePolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MergePolicy { get; set; } = "DEFAULT";

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AlterDomain SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>New Split Policy</para>
		/// </summary>
		public enum SplitPolicyEnum 
		{
			/// <summary>
			/// <para>Use the attribute&apos;s default value—The attributes of the two resulting features take on the default value of the attribute of the given feature class or subtype.</para>
			/// </summary>
			[GPValue("DEFAULT")]
			[Description("Use the attribute's default value")]
			DEFAULT,

			/// <summary>
			/// <para>Duplicate attribute values—The attribute of the two resulting features takes on a copy of the original object&apos;s attribute value.</para>
			/// </summary>
			[GPValue("DUPLICATE")]
			[Description("Duplicate attribute values")]
			Duplicate_attribute_values,

			/// <summary>
			/// <para>Use geometric ratio—The attributes of resulting features are a ratio of the original feature&apos;s value. The ratio is based on the proportion into which the original geometry is divided. If the geometry is divided equally, each new feature&apos;s attribute gets one-half the value of the original object&apos;s attribute. The geometry ratio policy only applies to range domains.</para>
			/// </summary>
			[GPValue("GEOMETRY_RATIO")]
			[Description("Use geometric ratio")]
			Use_geometric_ratio,

		}

		/// <summary>
		/// <para>New Merge Policy</para>
		/// </summary>
		public enum MergePolicyEnum 
		{
			/// <summary>
			/// <para>Use the attribute&apos;s default value—The attribute of the resulting feature takes on the default value of the attribute of the given feature class or subtype. This is the only merge policy that applies to nonnumeric fields and coded value domains.</para>
			/// </summary>
			[GPValue("DEFAULT")]
			[Description("Use the attribute's default value")]
			DEFAULT,

			/// <summary>
			/// <para>Sum of the values—The attribute of the resulting feature takes on the sum of the values from the original feature&apos;s attribute. The sum values policy only applies to range domains.</para>
			/// </summary>
			[GPValue("SUM_VALUES")]
			[Description("Sum of the values")]
			Sum_of_the_values,

			/// <summary>
			/// <para>Area weighted average—The attribute of the resulting feature is the weighted average of the attribute values of the original features. This average is based on the original feature&apos;s geometry. The area weighted policy only applies to range domains.</para>
			/// </summary>
			[GPValue("AREA_WEIGHTED")]
			[Description("Area weighted average")]
			Area_weighted_average,

		}

#endregion
	}
}
