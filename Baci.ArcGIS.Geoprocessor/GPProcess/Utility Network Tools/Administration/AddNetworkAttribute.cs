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
	/// <para>Add Network Attribute</para>
	/// <para>Add Network Attribute</para>
	/// <para>Adds a network attribute to a utility network.</para>
	/// </summary>
	public class AddNetworkAttribute : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The input utility network where the network attribute will be added.</para>
		/// </param>
		/// <param name="AttributeName">
		/// <para>Attribute Name</para>
		/// <para>The name of the network attribute to add to the utility network.</para>
		/// </param>
		/// <param name="AttributeType">
		/// <para>Attribute Type</para>
		/// <para>Specifies the data type of the network attribute.</para>
		/// <para>Short (small integer)—Short integer type</para>
		/// <para>Long (large integer)—Long integer type</para>
		/// <para>Double (double precision)—Double precision type</para>
		/// <para>Date—Date type</para>
		/// <para><see cref="AttributeTypeEnum"/></para>
		/// </param>
		public AddNetworkAttribute(object InUtilityNetwork, object AttributeName, object AttributeType)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.AttributeName = AttributeName;
			this.AttributeType = AttributeType;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Network Attribute</para>
		/// </summary>
		public override string DisplayName() => "Add Network Attribute";

		/// <summary>
		/// <para>Tool Name : AddNetworkAttribute</para>
		/// </summary>
		public override string ToolName() => "AddNetworkAttribute";

		/// <summary>
		/// <para>Tool Excute Name : un.AddNetworkAttribute</para>
		/// </summary>
		public override string ExcuteName() => "un.AddNetworkAttribute";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, AttributeName, AttributeType, IsInline, IsApportionable, Domain, IsOverridable, IsNullable, IsSubstitution, NetworkAttributeToSubstitute, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The input utility network where the network attribute will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Attribute Name</para>
		/// <para>The name of the network attribute to add to the utility network.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object AttributeName { get; set; }

		/// <summary>
		/// <para>Attribute Type</para>
		/// <para>Specifies the data type of the network attribute.</para>
		/// <para>Short (small integer)—Short integer type</para>
		/// <para>Long (large integer)—Long integer type</para>
		/// <para>Double (double precision)—Double precision type</para>
		/// <para>Date—Date type</para>
		/// <para><see cref="AttributeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AttributeType { get; set; }

		/// <summary>
		/// <para>In Line</para>
		/// <para>Specifies whether the network attribute will be persisted in line. In-line network attributes are slightly more efficient, but the number of bits for in-line attributes is limited to 28 per utility network. The most frequently used network attributes (for example, phase for electric networks, pressure for gas and water networks) should be stored in line if possible. The size of the bits is determined by the domain parameter. In-line attributes are only supported for integer network attributes.</para>
		/// <para>Checked—The attribute will be added internally to the topology, making retrieval more efficient.</para>
		/// <para>Unchecked—The attribute will be stored in an external table, and retrieval will require a call to the external weights table. This is the default.</para>
		/// <para><see cref="IsInlineEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsInline { get; set; } = "false";

		/// <summary>
		/// <para>Apportionable</para>
		/// <para>Specifies whether the network attribute will be apportioned across multiple edges belonging to the same feature.</para>
		/// <para>Network attributes with the apportionable property can be assigned to fields in line or junction feature classes, but only line features will have apportioned behavior.</para>
		/// <para>For example, with the shape_length network attribute, if one line feature consists of five edge elements, and if the total length of that line feature is 100 feet, that attribute will be apportioned across all edges, with 20 feet for each. The distribution of the value depends on the percentage along each edge element with respect to the from point of the original feature.</para>
		/// <para>Checked—The network attribute will be apportioned.</para>
		/// <para>Unchecked—The network attribute will not be apportioned. This is the default.</para>
		/// <para><see cref="IsApportionableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsApportionable { get; set; } = "false";

		/// <summary>
		/// <para>Domain Name</para>
		/// <para>The domain with which the network attribute is to be associated. This parameter is required when In Line is checked. This domain is used to determine how many bits to allocate for the in-line attribute and must be a coded value type. For example, the LifeCycleStatusDomain (0, Unknown | 1, In-Service | 2, Proposed | 3, Abandoned) domain has four entries, which means 2 bits are required to store the in-line attribute. The coded value domain must have sequential codes starting from 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Domain { get; set; }

		/// <summary>
		/// <para>Is Overridable</para>
		/// <para>This parameter is not used, and any entered value will be ignored in the current release. The functionality of this parameter is under development and will be applicable in a future release.</para>
		/// <para>Specifies whether a network attribute has an external override table that the network topology will read and override (or overwrite) the current value stored in the topology. This can be used to input live data from external systems, such as present position in the case of electric or pressure value in the case of gas. An example is a SCADA system pushing the updated switching positions of Device A to the override table of the DeviceStatus network attribute, which the topology engine then uses to override its current value of device status for Device A with the override value.</para>
		/// <para>Checked—The current value stored in the topology will be overridden.</para>
		/// <para>Unchecked—The current value stored in the topology will not be overridden. This is the default.</para>
		/// <para><see cref="IsOverridableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsOverridable { get; set; } = "false";

		/// <summary>
		/// <para>Nullable</para>
		/// <para>Specifies whether the network attribute will support null values.</para>
		/// <para>Checked—The network attribute will support null values.</para>
		/// <para>Unchecked—The network attribute will not support null values. This is the default.</para>
		/// <para><see cref="IsNullableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsNullable { get; set; } = "false";

		/// <summary>
		/// <para>Substitution</para>
		/// <para>Specifies whether the network attribute will be used as a substitution. Substitution network attributes allow a substituted value to be used instead of bitset network attribute values during a propagation in a trace operation.</para>
		/// <para>Checked—The network attribute will be used as a substitution.</para>
		/// <para>Unchecked—The network attribute will not be used as a substitution. This is the default.</para>
		/// <para><see cref="IsSubstitutionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsSubstitution { get; set; } = "false";

		/// <summary>
		/// <para>Network Attribute to Substitute</para>
		/// <para>The network attribute to be used for substitution. Substitutions are encoded based on the number of bits in the network attribute being propagated. The network attribute must be in-line and an integer field type less than or equal to 8 bits.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object NetworkAttributeToSubstitute { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddNetworkAttribute SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Attribute Type</para>
		/// </summary>
		public enum AttributeTypeEnum 
		{
			/// <summary>
			/// <para>Short (small integer)—Short integer type</para>
			/// </summary>
			[GPValue("SHORT")]
			[Description("Short (small integer)")]
			SHORT,

			/// <summary>
			/// <para>Long (large integer)—Long integer type</para>
			/// </summary>
			[GPValue("LONG")]
			[Description("Long (large integer)")]
			LONG,

			/// <summary>
			/// <para>Double (double precision)—Double precision type</para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("Double (double precision)")]
			DOUBLE,

			/// <summary>
			/// <para>Date—Date type</para>
			/// </summary>
			[GPValue("DATE")]
			[Description("Date")]
			Date,

		}

		/// <summary>
		/// <para>In Line</para>
		/// </summary>
		public enum IsInlineEnum 
		{
			/// <summary>
			/// <para>Checked—The attribute will be added internally to the topology, making retrieval more efficient.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INLINE")]
			INLINE,

			/// <summary>
			/// <para>Unchecked—The attribute will be stored in an external table, and retrieval will require a call to the external weights table. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_INLINE")]
			NOT_INLINE,

		}

		/// <summary>
		/// <para>Apportionable</para>
		/// </summary>
		public enum IsApportionableEnum 
		{
			/// <summary>
			/// <para>Checked—The network attribute will be apportioned.</para>
			/// </summary>
			[GPValue("true")]
			[Description("APPORTIONABLE")]
			APPORTIONABLE,

			/// <summary>
			/// <para>Unchecked—The network attribute will not be apportioned. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_APPORTIONABLE")]
			NOT_APPORTIONABLE,

		}

		/// <summary>
		/// <para>Is Overridable</para>
		/// </summary>
		public enum IsOverridableEnum 
		{
			/// <summary>
			/// <para>Checked—The current value stored in the topology will be overridden.</para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERRIDE")]
			OVERRIDE,

			/// <summary>
			/// <para>Unchecked—The current value stored in the topology will not be overridden. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_OVERRIDABLE")]
			NOT_OVERRIDABLE,

		}

		/// <summary>
		/// <para>Nullable</para>
		/// </summary>
		public enum IsNullableEnum 
		{
			/// <summary>
			/// <para>Checked—The network attribute will support null values.</para>
			/// </summary>
			[GPValue("true")]
			[Description("NULLABLE")]
			NULLABLE,

			/// <summary>
			/// <para>Unchecked—The network attribute will not support null values. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_NULLABLE")]
			NOT_NULLABLE,

		}

		/// <summary>
		/// <para>Substitution</para>
		/// </summary>
		public enum IsSubstitutionEnum 
		{
			/// <summary>
			/// <para>Checked—The network attribute will be used as a substitution.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SUBSTITUTION")]
			SUBSTITUTION,

			/// <summary>
			/// <para>Unchecked—The network attribute will not be used as a substitution. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_SUBSTITUTION")]
			NOT_SUBSTITUTION,

		}

#endregion
	}
}
