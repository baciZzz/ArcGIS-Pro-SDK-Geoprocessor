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
	/// <para>Add Subtype</para>
	/// <para>添加子类型</para>
	/// <para>将新的子类型添加到输入表的子类型中。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddSubtype : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>要更新的子类型定义所在的要素类或表。</para>
		/// </param>
		/// <param name="SubtypeCode">
		/// <para>Subtype Code</para>
		/// <para>要添加的子类型的唯一整数值。</para>
		/// </param>
		/// <param name="SubtypeDescription">
		/// <para>Subtype Name</para>
		/// <para>子类型编码描述。</para>
		/// </param>
		public AddSubtype(object InTable, object SubtypeCode, object SubtypeDescription)
		{
			this.InTable = InTable;
			this.SubtypeCode = SubtypeCode;
			this.SubtypeDescription = SubtypeDescription;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加子类型</para>
		/// </summary>
		public override string DisplayName() => "添加子类型";

		/// <summary>
		/// <para>Tool Name : AddSubtype</para>
		/// </summary>
		public override string ToolName() => "AddSubtype";

		/// <summary>
		/// <para>Tool Excute Name : management.AddSubtype</para>
		/// </summary>
		public override string ExcuteName() => "management.AddSubtype";

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
		public override object[] Parameters() => new object[] { InTable, SubtypeCode, SubtypeDescription, OutTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>要更新的子类型定义所在的要素类或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Subtype Code</para>
		/// <para>要添加的子类型的唯一整数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object SubtypeCode { get; set; }

		/// <summary>
		/// <para>Subtype Name</para>
		/// <para>子类型编码描述。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SubtypeDescription { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddSubtype SetEnviroment(int? autoCommit = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

	}
}
