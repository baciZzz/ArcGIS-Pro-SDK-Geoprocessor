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
	/// <para>Create Domain</para>
	/// <para>Creates an attribute domain in the specified workspace.</para>
	/// </summary>
	public class CreateDomain : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>The geodatabase that will contain the new domain.</para>
		/// </param>
		/// <param name="DomainName">
		/// <para>Domain Name</para>
		/// <para>The name of the domain that will be created.</para>
		/// </param>
		public CreateDomain(object InWorkspace, object DomainName)
		{
			this.InWorkspace = InWorkspace;
			this.DomainName = DomainName;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Domain</para>
		/// </summary>
		public override string DisplayName => "Create Domain";

		/// <summary>
		/// <para>Tool Name : CreateDomain</para>
		/// </summary>
		public override string ToolName => "CreateDomain";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateDomain</para>
		/// </summary>
		public override string ExcuteName => "management.CreateDomain";

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
		public override string[] ValidEnvironments => new string[] { "autoCommit", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InWorkspace, DomainName, DomainDescription!, FieldType!, DomainType!, SplitPolicy!, MergePolicy!, OutWorkspace! };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>The geodatabase that will contain the new domain.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Domain Name</para>
		/// <para>The name of the domain that will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainName { get; set; }

		/// <summary>
		/// <para>Domain Description</para>
		/// <para>The description of the domain that will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DomainDescription { get; set; }

		/// <summary>
		/// <para>Field Type</para>
		/// <para>Specifies the type of attribute domain that will be created. Attribute domains are rules that describe the accepted values of a field type. Specify a field type that matches the data type of the field to which the attribute domain will be assigned.</para>
		/// <para>Text—The field type will be text. Text fields support a string of characters.</para>
		/// <para>Float (32-bit floating point)—The field type will be float. Float fields support fractional numbers between -3.4E38 and 1.2E38.</para>
		/// <para>Double (64-bit floating point)—The field type will be double. Double fields support fractional numbers between -2.2E308 and 1.8E308.</para>
		/// <para>Short (16-bit integer)—The field type will be short. Short fields support whole numbers between -32,768 and 32,767.</para>
		/// <para>Long (32-bit integer)—The field type will be long. Long fields support whole numbers between -2,147,483,648 and 2,147,483,647.</para>
		/// <para>Date—The field type will be date. Date fields support date and time values.</para>
		/// <para><see cref="FieldTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FieldType { get; set; } = "SHORT";

		/// <summary>
		/// <para>Domain Type</para>
		/// <para>Specifies the domain type that will be created.</para>
		/// <para>Coded value domain—A coded type domain will be created that contains a valid set of values for an attribute. This is the default. For example, a coded value domain can specify valid pipe material values such as CL—cast iron pipe, DL—ductile iron pipe, or ACP—asbestos concrete pipe.</para>
		/// <para>Range domain—A range type domain will be created that contains a valid range of values for a numeric attribute. For example, if distribution water mains have a pressure between 50 and 75 psi, a range domain specifies these minimum and maximum values.</para>
		/// <para><see cref="DomainTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DomainType { get; set; } = "CODED";

		/// <summary>
		/// <para>Split Policy</para>
		/// <para>Specifies the split policy that will be used for the created domain. The behavior of an attribute&apos;s values when a feature that is split is controlled by its split policy.</para>
		/// <para>Use the attribute&apos;s default value—The attributes of the two resulting features will use the default value of the attribute of the given feature class or subtype.</para>
		/// <para>Duplicate attribute values—The attribute of the two resulting features will use a copy of the original object&apos;s attribute value.</para>
		/// <para>Use geometric ratio—The attributes of resulting features will be a ratio of the original feature&apos;s value. The ratio is based on the proportion into which the original geometry is divided. If the geometry is divided equally, each new feature&apos;s attribute gets one-half the value of the original object&apos;s attribute. The geometry ratio policy only applies to range domains.</para>
		/// <para><see cref="SplitPolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SplitPolicy { get; set; } = "DEFAULT";

		/// <summary>
		/// <para>Merge Policy</para>
		/// <para>Specifies the merge policy that will be used for the created domain. When two features are merged into a single feature, merge policies control attribute values in the new feature.</para>
		/// <para>Use the attribute&apos;s default value—The attribute of the resulting feature will use the default value of the attribute of the given feature class or subtype. This is the only merge policy that applies to nonnumeric fields and coded value domains.</para>
		/// <para>Sum of the values—The attribute of the resulting feature will use the sum of the values from the original feature&apos;s attribute. The sum values policy only applies to range domains.</para>
		/// <para>Area weighted average—The attribute of the resulting feature will be the weighted average of the attribute values of the original features. This average is based on the original feature&apos;s geometry. The area weighted policy only applies to range domains.</para>
		/// <para><see cref="MergePolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? MergePolicy { get; set; } = "DEFAULT";

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateDomain SetEnviroment(int? autoCommit = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Field Type</para>
		/// </summary>
		public enum FieldTypeEnum 
		{
			/// <summary>
			/// <para>Short (16-bit integer)—The field type will be short. Short fields support whole numbers between -32,768 and 32,767.</para>
			/// </summary>
			[GPValue("SHORT")]
			[Description("Short (16-bit integer)")]
			SHORT,

			/// <summary>
			/// <para>Long (32-bit integer)—The field type will be long. Long fields support whole numbers between -2,147,483,648 and 2,147,483,647.</para>
			/// </summary>
			[GPValue("LONG")]
			[Description("Long (32-bit integer)")]
			LONG,

			/// <summary>
			/// <para>Float (32-bit floating point)—The field type will be float. Float fields support fractional numbers between -3.4E38 and 1.2E38.</para>
			/// </summary>
			[GPValue("FLOAT")]
			[Description("Float (32-bit floating point)")]
			FLOAT,

			/// <summary>
			/// <para>Double (64-bit floating point)—The field type will be double. Double fields support fractional numbers between -2.2E308 and 1.8E308.</para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("Double (64-bit floating point)")]
			DOUBLE,

			/// <summary>
			/// <para>Text—The field type will be text. Text fields support a string of characters.</para>
			/// </summary>
			[GPValue("TEXT")]
			[Description("Text")]
			Text,

			/// <summary>
			/// <para>Date—The field type will be date. Date fields support date and time values.</para>
			/// </summary>
			[GPValue("DATE")]
			[Description("Date")]
			Date,

		}

		/// <summary>
		/// <para>Domain Type</para>
		/// </summary>
		public enum DomainTypeEnum 
		{
			/// <summary>
			/// <para>Coded value domain—A coded type domain will be created that contains a valid set of values for an attribute. This is the default. For example, a coded value domain can specify valid pipe material values such as CL—cast iron pipe, DL—ductile iron pipe, or ACP—asbestos concrete pipe.</para>
			/// </summary>
			[GPValue("CODED")]
			[Description("Coded value domain")]
			Coded_value_domain,

			/// <summary>
			/// <para>Range domain—A range type domain will be created that contains a valid range of values for a numeric attribute. For example, if distribution water mains have a pressure between 50 and 75 psi, a range domain specifies these minimum and maximum values.</para>
			/// </summary>
			[GPValue("RANGE")]
			[Description("Range domain")]
			Range_domain,

		}

		/// <summary>
		/// <para>Split Policy</para>
		/// </summary>
		public enum SplitPolicyEnum 
		{
			/// <summary>
			/// <para>Use the attribute&apos;s default value—The attributes of the two resulting features will use the default value of the attribute of the given feature class or subtype.</para>
			/// </summary>
			[GPValue("DEFAULT")]
			[Description("Use the attribute's default value")]
			DEFAULT,

			/// <summary>
			/// <para>Duplicate attribute values—The attribute of the two resulting features will use a copy of the original object&apos;s attribute value.</para>
			/// </summary>
			[GPValue("DUPLICATE")]
			[Description("Duplicate attribute values")]
			Duplicate_attribute_values,

			/// <summary>
			/// <para>Use geometric ratio—The attributes of resulting features will be a ratio of the original feature&apos;s value. The ratio is based on the proportion into which the original geometry is divided. If the geometry is divided equally, each new feature&apos;s attribute gets one-half the value of the original object&apos;s attribute. The geometry ratio policy only applies to range domains.</para>
			/// </summary>
			[GPValue("GEOMETRY_RATIO")]
			[Description("Use geometric ratio")]
			Use_geometric_ratio,

		}

		/// <summary>
		/// <para>Merge Policy</para>
		/// </summary>
		public enum MergePolicyEnum 
		{
			/// <summary>
			/// <para>Use the attribute&apos;s default value—The attribute of the resulting feature will use the default value of the attribute of the given feature class or subtype. This is the only merge policy that applies to nonnumeric fields and coded value domains.</para>
			/// </summary>
			[GPValue("DEFAULT")]
			[Description("Use the attribute's default value")]
			DEFAULT,

			/// <summary>
			/// <para>Sum of the values—The attribute of the resulting feature will use the sum of the values from the original feature&apos;s attribute. The sum values policy only applies to range domains.</para>
			/// </summary>
			[GPValue("SUM_VALUES")]
			[Description("Sum of the values")]
			Sum_of_the_values,

			/// <summary>
			/// <para>Area weighted average—The attribute of the resulting feature will be the weighted average of the attribute values of the original features. This average is based on the original feature&apos;s geometry. The area weighted policy only applies to range domains.</para>
			/// </summary>
			[GPValue("AREA_WEIGHTED")]
			[Description("Area weighted average")]
			Area_weighted_average,

		}

#endregion
	}
}
