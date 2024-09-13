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
	/// <para>修剪存档历史</para>
	/// <para>从非版本化且已启用存档的数据集中删除已停用存档记录。</para>
	/// </summary>
	public class TrimArchiveHistory : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含要修剪的存档历史的非版本化且已启用存档的表。</para>
		/// </param>
		/// <param name="TrimMode">
		/// <para>Trim Mode</para>
		/// <para>指定将用于修剪存档历史的修剪模式。</para>
		/// <para>在 ArcGIS Pro 的当前版本中，仅删除修剪模式可用。</para>
		/// <para>删除—将删除存档记录。</para>
		/// <para><see cref="TrimModeEnum"/></para>
		/// </param>
		public TrimArchiveHistory(object InTable, object TrimMode)
		{
			this.InTable = InTable;
			this.TrimMode = TrimMode;
		}

		/// <summary>
		/// <para>Tool Display Name : 修剪存档历史</para>
		/// </summary>
		public override string DisplayName() => "修剪存档历史";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, TrimMode, TrimBeforeDate!, OutTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含要修剪的存档历史的非版本化且已启用存档的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Trim Mode</para>
		/// <para>指定将用于修剪存档历史的修剪模式。</para>
		/// <para>在 ArcGIS Pro 的当前版本中，仅删除修剪模式可用。</para>
		/// <para>删除—将删除存档记录。</para>
		/// <para><see cref="TrimModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TrimMode { get; set; }

		/// <summary>
		/// <para>Trim Before Date</para>
		/// <para>将删除早于该日期和时间的存档记录。 日期和时间必须使用 UTC。 如果未提供日期，则将删除所有存档记录。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? TrimBeforeDate { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutTable { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Trim Mode</para>
		/// </summary>
		public enum TrimModeEnum 
		{
			/// <summary>
			/// <para>删除—将删除存档记录。</para>
			/// </summary>
			[GPValue("DELETE")]
			[Description("删除")]
			Delete,

		}

#endregion
	}
}
