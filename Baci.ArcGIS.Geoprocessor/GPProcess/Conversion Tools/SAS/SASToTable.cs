using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>SAS To Table</para>
	/// <para>SAS To Table</para>
	/// <para>Converts a SAS dataset to a table.</para>
	/// </summary>
	public class SASToTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSasDataset">
		/// <para>Input SAS Dataset (libref.tablename)</para>
		/// <para>The input SAS dataset. Provide the dataset in the form libref.tablename in which libref is the name of a SAS library and tablename is the name of the SAS dataset.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>The output table.</para>
		/// </param>
		public SASToTable(object InSasDataset, object OutTable)
		{
			this.InSasDataset = InSasDataset;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : SAS To Table</para>
		/// </summary>
		public override string DisplayName() => "SAS To Table";

		/// <summary>
		/// <para>Tool Name : SASToTable</para>
		/// </summary>
		public override string ToolName() => "SASToTable";

		/// <summary>
		/// <para>Tool Excute Name : conversion.SASToTable</para>
		/// </summary>
		public override string ExcuteName() => "conversion.SASToTable";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSasDataset, OutTable, UseCasConnection!, Hostname!, Port!, Username!, Password!, CustomCfgFile! };

		/// <summary>
		/// <para>Input SAS Dataset (libref.tablename)</para>
		/// <para>The input SAS dataset. Provide the dataset in the form libref.tablename in which libref is the name of a SAS library and tablename is the name of the SAS dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InSasDataset { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The output table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Download SAS Dataset from SAS Cloud Analytic Services (CAS)</para>
		/// <para>Specifies whether the input SAS dataset will be downloaded from CAS or accessed from a local SAS library.</para>
		/// <para>Checked—The input SAS dataset will be downloaded from CAS.</para>
		/// <para>Unchecked—The input SAS dataset will be accessed from a local SAS library. This is the default.</para>
		/// <para><see cref="UseCasConnectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? UseCasConnection { get; set; } = "false";

		/// <summary>
		/// <para>CAS Hostname URL</para>
		/// <para>The URL of the CAS host.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Hostname { get; set; }

		/// <summary>
		/// <para>Port</para>
		/// <para>The port of the CAS connection.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? Port { get; set; }

		/// <summary>
		/// <para>CAS Username</para>
		/// <para>The user name for the CAS connection.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Username { get; set; }

		/// <summary>
		/// <para>Password</para>
		/// <para>The password for the CAS connection. This password is hidden and not accessible after running the tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPStringHidden()]
		public object? Password { get; set; }

		/// <summary>
		/// <para>Custom Session Configuration File</para>
		/// <para>The file specifying custom configurations for the SAS session. The file is only required for customized local or remote SAS deployments.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object? CustomCfgFile { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Download SAS Dataset from SAS Cloud Analytic Services (CAS)</para>
		/// </summary>
		public enum UseCasConnectionEnum 
		{
			/// <summary>
			/// <para>Checked—The input SAS dataset will be downloaded from CAS.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_CAS")]
			USE_CAS,

			/// <summary>
			/// <para>Unchecked—The input SAS dataset will be accessed from a local SAS library. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("LOCAL_SAS")]
			LOCAL_SAS,

		}

#endregion
	}
}
