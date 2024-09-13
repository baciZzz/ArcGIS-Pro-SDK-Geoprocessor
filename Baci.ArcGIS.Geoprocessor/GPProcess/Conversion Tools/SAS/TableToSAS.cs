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
	/// <para>Table To SAS</para>
	/// <para>Table To SAS</para>
	/// <para>Converts a table to a SAS dataset.</para>
	/// </summary>
	public class TableToSAS : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input table.</para>
		/// </param>
		/// <param name="OutSasDataset">
		/// <para>Output SAS Dataset (libref.tablename)</para>
		/// <para>The output SAS dataset. Provide the dataset in the form libref.table in which libref is the name of a SAS library and table is the name of the SAS table.</para>
		/// </param>
		public TableToSAS(object InTable, object OutSasDataset)
		{
			this.InTable = InTable;
			this.OutSasDataset = OutSasDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Table To SAS</para>
		/// </summary>
		public override string DisplayName() => "Table To SAS";

		/// <summary>
		/// <para>Tool Name : TableToSAS</para>
		/// </summary>
		public override string ToolName() => "TableToSAS";

		/// <summary>
		/// <para>Tool Excute Name : conversion.TableToSAS</para>
		/// </summary>
		public override string ExcuteName() => "conversion.TableToSAS";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, OutSasDataset, ReplaceSasDataset!, UseDomainAndSubtypeDescription!, UseCasConnection!, Hostname!, Port!, Username!, Password!, CustomCfgFile! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output SAS Dataset (libref.tablename)</para>
		/// <para>The output SAS dataset. Provide the dataset in the form libref.table in which libref is the name of a SAS library and table is the name of the SAS table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutSasDataset { get; set; }

		/// <summary>
		/// <para>Replace SAS Dataset</para>
		/// <para>Specifies whether an existing SAS dataset will be overwritten by the output.</para>
		/// <para>Checked—The output SAS dataset will be overwritten.</para>
		/// <para>Unchecked—The output SAS dataset will not be overwritten. This is the default.</para>
		/// <para><see cref="ReplaceSasDatasetEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ReplaceSasDataset { get; set; }

		/// <summary>
		/// <para>Use Domain and Subtype Descriptions</para>
		/// <para>Specifies whether domain and subtype descriptions will be included in the output SAS dataset.</para>
		/// <para>Checked—Domain and subtype descriptions will be included in the output SAS dataset.</para>
		/// <para>Unchecked—Domain and subtype descriptions will not be included in the output SAS dataset. This is the default.</para>
		/// <para><see cref="UseDomainAndSubtypeDescriptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? UseDomainAndSubtypeDescription { get; set; }

		/// <summary>
		/// <para>Upload SAS Dataset to SAS Cloud Analytic Services (CAS)</para>
		/// <para>Specifies whether the output SAS dataset will be uploaded to CAS or saved in a local SAS library.</para>
		/// <para>Checked—The output SAS dataset will be uploaded to CAS.</para>
		/// <para>Unchecked—The output SAS dataset will be saved in a local SAS library. This is the default.</para>
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
		/// <para>Replace SAS Dataset</para>
		/// </summary>
		public enum ReplaceSasDatasetEnum 
		{
			/// <summary>
			/// <para>Checked—The output SAS dataset will be overwritten.</para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERWRITE")]
			OVERWRITE,

			/// <summary>
			/// <para>Unchecked—The output SAS dataset will not be overwritten. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_OVERWRITE")]
			NO_OVERWRITE,

		}

		/// <summary>
		/// <para>Use Domain and Subtype Descriptions</para>
		/// </summary>
		public enum UseDomainAndSubtypeDescriptionEnum 
		{
			/// <summary>
			/// <para>Checked—Domain and subtype descriptions will be included in the output SAS dataset.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_DOMAIN")]
			USE_DOMAIN,

			/// <summary>
			/// <para>Unchecked—Domain and subtype descriptions will not be included in the output SAS dataset. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DOMAIN")]
			NO_DOMAIN,

		}

		/// <summary>
		/// <para>Upload SAS Dataset to SAS Cloud Analytic Services (CAS)</para>
		/// </summary>
		public enum UseCasConnectionEnum 
		{
			/// <summary>
			/// <para>Checked—The output SAS dataset will be uploaded to CAS.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_CAS")]
			USE_CAS,

			/// <summary>
			/// <para>Unchecked—The output SAS dataset will be saved in a local SAS library. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("LOCAL_SAS")]
			LOCAL_SAS,

		}

#endregion
	}
}
