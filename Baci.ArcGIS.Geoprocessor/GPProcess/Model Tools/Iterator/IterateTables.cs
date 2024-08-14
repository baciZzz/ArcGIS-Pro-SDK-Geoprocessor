using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ModelTools
{
	/// <summary>
	/// <para>Iterate Tables</para>
	/// <para>Iterates over tables in a workspace.</para>
	/// </summary>
	public class IterateTables : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Workspace</para>
		/// <para>Workspace containing the tables to iterate.</para>
		/// </param>
		public IterateTables(object InWorkspace)
		{
			this.InWorkspace = InWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : Iterate Tables</para>
		/// </summary>
		public override string DisplayName => "Iterate Tables";

		/// <summary>
		/// <para>Tool Name : IterateTables</para>
		/// </summary>
		public override string ToolName => "IterateTables";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateTables</para>
		/// </summary>
		public override string ExcuteName => "mb.IterateTables";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InWorkspace, Wildcard, TableType, Recursive, Table, Name };

		/// <summary>
		/// <para>Workspace</para>
		/// <para>Workspace containing the tables to iterate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Wildcard</para>
		/// <para>A combination of * and characters that help to limit the results. The asterisk is the same as saying ALL. If no wildcard is specified, all inputs will be returned. For example, it can be used to restrict Iteration over input names starting with a certain character or word (for example, A* or Ari* or Land* and so on).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Wildcard { get; set; }

		/// <summary>
		/// <para>Table Type</para>
		/// <para>For folder workspaces (shapefiles and coverages), choose the table type.</para>
		/// <para>dBASE (shapefiles)—dBASE table (shapefiles)</para>
		/// <para>INFO (coverages)—INFO table (coverages)</para>
		/// <para><see cref="TableTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TableType { get; set; }

		/// <summary>
		/// <para>Recursive</para>
		/// <para>Determines if subfolders in the main folder will be iterated through recursively.</para>
		/// <para>Checked—Will iterate through all subfolders.</para>
		/// <para>Unchecked—Will not iterate through all subfolders.</para>
		/// <para><see cref="RecursiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Recursive { get; set; } = "false";

		/// <summary>
		/// <para>Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object Table { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object Name { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Table Type</para>
		/// </summary>
		public enum TableTypeEnum 
		{
			/// <summary>
			/// <para>dBASE (shapefiles)—dBASE table (shapefiles)</para>
			/// </summary>
			[GPValue("DBASE")]
			[Description("dBASE (shapefiles)")]
			DBASE,

			/// <summary>
			/// <para>INFO (coverages)—INFO table (coverages)</para>
			/// </summary>
			[GPValue("INFO")]
			[Description("INFO (coverages)")]
			INFO,

		}

		/// <summary>
		/// <para>Recursive</para>
		/// </summary>
		public enum RecursiveEnum 
		{
			/// <summary>
			/// <para>Checked—Will iterate through all subfolders.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RECURSIVE")]
			RECURSIVE,

			/// <summary>
			/// <para>Unchecked—Will not iterate through all subfolders.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_RECURSIVE")]
			NOT_RECURSIVE,

		}

#endregion
	}
}
