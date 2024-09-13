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
	/// <para>表转 SAS</para>
	/// <para>将表转换为 SAS 数据集。</para>
	/// </summary>
	public class TableToSAS : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>输入表。</para>
		/// </param>
		/// <param name="OutSasDataset">
		/// <para>Output SAS Dataset (libref.tablename)</para>
		/// <para>输出 SAS 数据集。 以表单 libref.table 形式提供数据集，其中 libref 是 SAS 库的名称，table 是 SAS 表的名称。</para>
		/// </param>
		public TableToSAS(object InTable, object OutSasDataset)
		{
			this.InTable = InTable;
			this.OutSasDataset = OutSasDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 表转 SAS</para>
		/// </summary>
		public override string DisplayName() => "表转 SAS";

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
		public override object[] Parameters() => new object[] { InTable, OutSasDataset, ReplaceSasDataset, UseDomainAndSubtypeDescription, UseCasConnection, Hostname, Port, Username, Password };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>输入表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output SAS Dataset (libref.tablename)</para>
		/// <para>输出 SAS 数据集。 以表单 libref.table 形式提供数据集，其中 libref 是 SAS 库的名称，table 是 SAS 表的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutSasDataset { get; set; }

		/// <summary>
		/// <para>Replace SAS Dataset</para>
		/// <para>指定是否在输出中覆盖现有 SAS 数据集。</para>
		/// <para>选中 - 输出 SAS 数据集将被覆盖。</para>
		/// <para>未选中 - 输出 SAS 数据集不会被覆盖。 这是默认设置。</para>
		/// <para><see cref="ReplaceSasDatasetEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ReplaceSasDataset { get; set; }

		/// <summary>
		/// <para>Use Domain and Subtype Descriptions</para>
		/// <para>指定输出 SAS 数据集中是否包含域和子类型描述。</para>
		/// <para>选中 - 输出 SAS 数据集中将包含域和子类型描述。</para>
		/// <para>未选中 - 输出 SAS 数据集中不会包含域和子类型描述。 这是默认设置。</para>
		/// <para><see cref="UseDomainAndSubtypeDescriptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseDomainAndSubtypeDescription { get; set; }

		/// <summary>
		/// <para>Upload SAS Dataset to SAS Cloud Analytic Services (CAS)</para>
		/// <para>指定将输出 SAS 数据集上传到 CAS，还是保存在本地 SAS 库中。</para>
		/// <para>选中 - 输出 SAS 数据集将被上传到 CAS。</para>
		/// <para>未选中 - 输出 SAS 数据集将被保存在本地 SAS 库中。 这是默认设置。</para>
		/// <para><see cref="UseCasConnectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseCasConnection { get; set; } = "false";

		/// <summary>
		/// <para>CAS Hostname URL</para>
		/// <para>CAS 主机的 URL。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Hostname { get; set; }

		/// <summary>
		/// <para>Port</para>
		/// <para>CAS 连接的端口。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object Port { get; set; }

		/// <summary>
		/// <para>CAS Username</para>
		/// <para>CAS 连接的用户名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Username { get; set; }

		/// <summary>
		/// <para>Password</para>
		/// <para>CAS 连接的密码。 运行工具后，此密码被隐藏并且不可访问。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPStringHidden()]
		public object Password { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Replace SAS Dataset</para>
		/// </summary>
		public enum ReplaceSasDatasetEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERWRITE")]
			OVERWRITE,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_DOMAIN")]
			USE_DOMAIN,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_CAS")]
			USE_CAS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("LOCAL_SAS")]
			LOCAL_SAS,

		}

#endregion
	}
}
