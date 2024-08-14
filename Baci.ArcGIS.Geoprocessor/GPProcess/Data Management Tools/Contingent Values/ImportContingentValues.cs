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
	/// <para>Import Contingent Values</para>
	/// <para>Imports multiple contingent values and field groups from a comma-separated values file (.csv) into a dataset.</para>
	/// </summary>
	public class ImportContingentValues : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetTable">
		/// <para>Target Table</para>
		/// <para>The input geodatabase table or feature class to which the field groups and contingent values will be imported.</para>
		/// </param>
		/// <param name="FieldGroupFile">
		/// <para>Field Groups Input File (.csv)</para>
		/// <para>A .csv file with specific column names that contains information about the field groups.</para>
		/// </param>
		/// <param name="ContingentValueFile">
		/// <para>Contingent Values Input File (.csv)</para>
		/// <para>A .csv file with specific column names that contains information about the contingent values.</para>
		/// </param>
		public ImportContingentValues(object TargetTable, object FieldGroupFile, object ContingentValueFile)
		{
			this.TargetTable = TargetTable;
			this.FieldGroupFile = FieldGroupFile;
			this.ContingentValueFile = ContingentValueFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Import Contingent Values</para>
		/// </summary>
		public override string DisplayName => "Import Contingent Values";

		/// <summary>
		/// <para>Tool Name : ImportContingentValues</para>
		/// </summary>
		public override string ToolName => "ImportContingentValues";

		/// <summary>
		/// <para>Tool Excute Name : management.ImportContingentValues</para>
		/// </summary>
		public override string ExcuteName => "management.ImportContingentValues";

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
		public override object[] Parameters => new object[] { TargetTable, FieldGroupFile, ContingentValueFile, ImportType, UpdatedTable };

		/// <summary>
		/// <para>Target Table</para>
		/// <para>The input geodatabase table or feature class to which the field groups and contingent values will be imported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object TargetTable { get; set; }

		/// <summary>
		/// <para>Field Groups Input File (.csv)</para>
		/// <para>A .csv file with specific column names that contains information about the field groups.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object FieldGroupFile { get; set; }

		/// <summary>
		/// <para>Contingent Values Input File (.csv)</para>
		/// <para>A .csv file with specific column names that contains information about the contingent values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object ContingentValueFile { get; set; }

		/// <summary>
		/// <para>Replace existing contingent values</para>
		/// <para>Specifies whether existing values will be replaced or merged upon import.</para>
		/// <para>Checked—Existing values for the target table will be replaced with the values in the input .csv files.</para>
		/// <para>Unchecked—Existing values will be merged with the values in the input .csv files. Any duplicates will be excluded. This is the default.</para>
		/// <para><see cref="ImportTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ImportType { get; set; } = "false";

		/// <summary>
		/// <para>Updated Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object UpdatedTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportContingentValues SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Replace existing contingent values</para>
		/// </summary>
		public enum ImportTypeEnum 
		{
			/// <summary>
			/// <para>Checked—Existing values for the target table will be replaced with the values in the input .csv files.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REPLACE")]
			REPLACE,

			/// <summary>
			/// <para>Unchecked—Existing values will be merged with the values in the input .csv files. Any duplicates will be excluded. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("UNION")]
			UNION,

		}

#endregion
	}
}
