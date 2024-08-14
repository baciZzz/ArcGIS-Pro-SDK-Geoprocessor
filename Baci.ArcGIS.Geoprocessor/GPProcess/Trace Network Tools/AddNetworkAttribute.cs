using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TraceNetworkTools
{
	/// <summary>
	/// <para>Add Network Attribute</para>
	/// <para>Adds a network attribute to a trace network.</para>
	/// </summary>
	public class AddNetworkAttribute : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTraceNetwork">
		/// <para>Input Trace Network</para>
		/// <para>The input trace network to which the network attribute will be added.</para>
		/// </param>
		/// <param name="AttributeName">
		/// <para>Attribute Name</para>
		/// <para>The name of the network attribute to add to the trace network.</para>
		/// </param>
		/// <param name="AttributeType">
		/// <para>Attribute Type</para>
		/// <para>Specifies the data type of the network attribute.</para>
		/// <para>Short (16-bit integer)—The field type will be short.</para>
		/// <para>Long (32-bit integer)—The field type will be long.</para>
		/// <para>Double (64-bit floating point)—The field type will be double.</para>
		/// <para>Date—The field type will be date.</para>
		/// <para><see cref="AttributeTypeEnum"/></para>
		/// </param>
		public AddNetworkAttribute(object InTraceNetwork, object AttributeName, object AttributeType)
		{
			this.InTraceNetwork = InTraceNetwork;
			this.AttributeName = AttributeName;
			this.AttributeType = AttributeType;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Network Attribute</para>
		/// </summary>
		public override string DisplayName => "Add Network Attribute";

		/// <summary>
		/// <para>Tool Name : AddNetworkAttribute</para>
		/// </summary>
		public override string ToolName => "AddNetworkAttribute";

		/// <summary>
		/// <para>Tool Excute Name : tn.AddNetworkAttribute</para>
		/// </summary>
		public override string ExcuteName => "tn.AddNetworkAttribute";

		/// <summary>
		/// <para>Toolbox Display Name : Trace Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Trace Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : tn</para>
		/// </summary>
		public override string ToolboxAlise => "tn";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTraceNetwork, AttributeName, AttributeType, IsNullable!, OutTraceNetwork! };

		/// <summary>
		/// <para>Input Trace Network</para>
		/// <para>The input trace network to which the network attribute will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTraceNetwork { get; set; }

		/// <summary>
		/// <para>Attribute Name</para>
		/// <para>The name of the network attribute to add to the trace network.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object AttributeName { get; set; }

		/// <summary>
		/// <para>Attribute Type</para>
		/// <para>Specifies the data type of the network attribute.</para>
		/// <para>Short (16-bit integer)—The field type will be short.</para>
		/// <para>Long (32-bit integer)—The field type will be long.</para>
		/// <para>Double (64-bit floating point)—The field type will be double.</para>
		/// <para>Date—The field type will be date.</para>
		/// <para><see cref="AttributeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AttributeType { get; set; }

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
		public object? IsNullable { get; set; } = "false";

		/// <summary>
		/// <para>Updated Trace Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETraceNetwork()]
		public object? OutTraceNetwork { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Attribute Type</para>
		/// </summary>
		public enum AttributeTypeEnum 
		{
			/// <summary>
			/// <para>Short (16-bit integer)—The field type will be short.</para>
			/// </summary>
			[GPValue("SHORT")]
			[Description("Short (16-bit integer)")]
			SHORT,

			/// <summary>
			/// <para>Long (32-bit integer)—The field type will be long.</para>
			/// </summary>
			[GPValue("LONG")]
			[Description("Long (32-bit integer)")]
			LONG,

			/// <summary>
			/// <para>Double (64-bit floating point)—The field type will be double.</para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("Double (64-bit floating point)")]
			DOUBLE,

			/// <summary>
			/// <para>Date—The field type will be date.</para>
			/// </summary>
			[GPValue("DATE")]
			[Description("Date")]
			Date,

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

#endregion
	}
}
