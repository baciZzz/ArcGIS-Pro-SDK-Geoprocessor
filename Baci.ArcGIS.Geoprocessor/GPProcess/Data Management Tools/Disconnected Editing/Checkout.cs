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
	/// <para>Check Out</para>
	/// <para>Check Out</para>
	/// <para>Creates a check-out replica from datasets in ArcSDE.</para>
	/// </summary>
	[Obsolete()]
	public class Checkout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Check-out Data</para>
		/// </param>
		/// <param name="OutWorkspace">
		/// <para>Check-out to Workspace</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Check-out Name</para>
		/// </param>
		public Checkout(object InData, object OutWorkspace, object OutName)
		{
			this.InData = InData;
			this.OutWorkspace = OutWorkspace;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : Check Out</para>
		/// </summary>
		public override string DisplayName() => "Check Out";

		/// <summary>
		/// <para>Tool Name : Checkout</para>
		/// </summary>
		public override string ToolName() => "Checkout";

		/// <summary>
		/// <para>Tool Excute Name : management.Checkout</para>
		/// </summary>
		public override string ExcuteName() => "management.Checkout";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InData, OutWorkspace, OutName, InType, ReuseSchema, GetRelatedData };

		/// <summary>
		/// <para>Check-out Data</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Check-out to Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database")]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Check-out Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Check-out Type</para>
		/// <para><see cref="InTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InType { get; set; } = "DATA";

		/// <summary>
		/// <para>Re-use schema if this geodatabase was used for a check-out before</para>
		/// <para><see cref="ReuseSchemaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ReuseSchema { get; set; } = "false";

		/// <summary>
		/// <para>Check out related data</para>
		/// <para><see cref="GetRelatedDataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object GetRelatedData { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>Check-out Type</para>
		/// </summary>
		public enum InTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("DATA")]
			[Description("DATA")]
			DATA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("SCHEMA_ONLY")]
			[Description("SCHEMA_ONLY")]
			SCHEMA_ONLY,

		}

		/// <summary>
		/// <para>Re-use schema if this geodatabase was used for a check-out before</para>
		/// </summary>
		public enum ReuseSchemaEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REUSE")]
			REUSE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_REUSE")]
			NO_REUSE,

		}

		/// <summary>
		/// <para>Check out related data</para>
		/// </summary>
		public enum GetRelatedDataEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RELATED")]
			RELATED,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_RELATED")]
			NO_RELATED,

		}

#endregion
	}
}
