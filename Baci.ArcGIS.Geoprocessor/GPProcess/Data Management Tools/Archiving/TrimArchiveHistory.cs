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
	/// <para>Trim Archive History</para>
	/// <para>Trim Archive History</para>
	/// <para>Deletes retired archive records from nonversioned archive-enabled datasets.</para>
	/// </summary>
	public class TrimArchiveHistory : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The nonversioned archive-enabled table with the archive history to be trimmed.</para>
		/// </param>
		/// <param name="TrimMode">
		/// <para>Trim Mode</para>
		/// <para>Specifies the trim mode to be used to trim the archive history.</para>
		/// <para>At ArcGIS Pro 2.6, only the delete trim mode is available.</para>
		/// <para>Delete—The archive records will be deleted.</para>
		/// <para><see cref="TrimModeEnum"/></para>
		/// </param>
		public TrimArchiveHistory(object InTable, object TrimMode)
		{
			this.InTable = InTable;
			this.TrimMode = TrimMode;
		}

		/// <summary>
		/// <para>Tool Display Name : Trim Archive History</para>
		/// </summary>
		public override string DisplayName() => "Trim Archive History";

		/// <summary>
		/// <para>Tool Name : TrimArchiveHistory</para>
		/// </summary>
		public override string ToolName() => "TrimArchiveHistory";

		/// <summary>
		/// <para>Tool Excute Name : management.TrimArchiveHistory</para>
		/// </summary>
		public override string ExcuteName() => "management.TrimArchiveHistory";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, TrimMode, TrimBeforeDate, OutTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The nonversioned archive-enabled table with the archive history to be trimmed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Trim Mode</para>
		/// <para>Specifies the trim mode to be used to trim the archive history.</para>
		/// <para>At ArcGIS Pro 2.6, only the delete trim mode is available.</para>
		/// <para>Delete—The archive records will be deleted.</para>
		/// <para><see cref="TrimModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TrimMode { get; set; }

		/// <summary>
		/// <para>Trim Before Date</para>
		/// <para>Archive records older than this date and time will be deleted. The date and time must be in UTC. If no date is provided, all archive records will be deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object TrimBeforeDate { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object OutTable { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Trim Mode</para>
		/// </summary>
		public enum TrimModeEnum 
		{
			/// <summary>
			/// <para>Delete—The archive records will be deleted.</para>
			/// </summary>
			[GPValue("DELETE")]
			[Description("Delete")]
			Delete,

		}

#endregion
	}
}
