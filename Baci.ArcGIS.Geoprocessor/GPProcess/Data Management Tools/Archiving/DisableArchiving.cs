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
	/// <para>Disable Archiving</para>
	/// <para>禁用存档</para>
	/// <para>禁用地理数据库要素类、表或要素数据集的存档。</para>
	/// </summary>
	public class DisableArchiving : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>要禁用存档的地理数据库要素类、表或要素数据集。</para>
		/// </param>
		public DisableArchiving(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 禁用存档</para>
		/// </summary>
		public override string DisplayName() => "禁用存档";

		/// <summary>
		/// <para>Tool Name : DisableArchiving</para>
		/// </summary>
		public override string ToolName() => "DisableArchiving";

		/// <summary>
		/// <para>Tool Excute Name : management.DisableArchiving</para>
		/// </summary>
		public override string ExcuteName() => "management.DisableArchiving";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, PreserveHistory!, OutDataset! };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>要禁用存档的地理数据库要素类、表或要素数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Preserve History Table</para>
		/// <para>指定是否保留非当前时刻的记录。如果表或要素类已版本化，则历史记录表将变为可用状态。对于非版本化数据，将创建包含历史信息的附加 _h 的表或要素类。</para>
		/// <para>选中 - 保留非当前时刻的记录。这是默认设置。</para>
		/// <para>未选中 - 系统不会保留非当前时刻的记录；记录将被删除。</para>
		/// <para><see cref="PreserveHistoryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? PreserveHistory { get; set; } = "true";

		/// <summary>
		/// <para>Updated Input Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DisableArchiving SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Preserve History Table</para>
		/// </summary>
		public enum PreserveHistoryEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE")]
			PRESERVE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DELETE")]
			DELETE,

		}

#endregion
	}
}
