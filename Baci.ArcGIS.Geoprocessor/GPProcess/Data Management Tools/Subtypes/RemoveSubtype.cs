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
	/// <para>Remove Subtype</para>
	/// <para>移除子类型</para>
	/// <para>使用子类型编码从输入表中移除子类型。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RemoveSubtype : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含子类型定义的要素类或表。</para>
		/// </param>
		/// <param name="SubtypeCode">
		/// <para>Subtype Code</para>
		/// <para>从输入表或要素类中移除子类型的子类型编码。</para>
		/// </param>
		public RemoveSubtype(object InTable, object SubtypeCode)
		{
			this.InTable = InTable;
			this.SubtypeCode = SubtypeCode;
		}

		/// <summary>
		/// <para>Tool Display Name : 移除子类型</para>
		/// </summary>
		public override string DisplayName() => "移除子类型";

		/// <summary>
		/// <para>Tool Name : RemoveSubtype</para>
		/// </summary>
		public override string ToolName() => "RemoveSubtype";

		/// <summary>
		/// <para>Tool Excute Name : management.RemoveSubtype</para>
		/// </summary>
		public override string ExcuteName() => "management.RemoveSubtype";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, SubtypeCode, OutTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含子类型定义的要素类或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Subtype Code</para>
		/// <para>从输入表或要素类中移除子类型的子类型编码。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object SubtypeCode { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveSubtype SetEnviroment(int? autoCommit = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

	}
}
