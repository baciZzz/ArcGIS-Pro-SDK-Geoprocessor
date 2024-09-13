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
	/// <para>SAS 转表</para>
	/// <para>将 SAS 数据集转换为表。</para>
	/// </summary>
	public class SASToTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSasDataset">
		/// <para>Input SAS Dataset (libref.tablename)</para>
		/// <para>输入 SAS 数据集。 以表单 libref.tablename 形式提供数据集，其中 libref 是 SAS 库的名称，tablename 是 SAS 数据集的名称。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>输出表。</para>
		/// </param>
		public SASToTable(object InSasDataset, object OutTable)
		{
			this.InSasDataset = InSasDataset;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : SAS 转表</para>
		/// </summary>
		public override string DisplayName() => "SAS 转表";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSasDataset, OutTable, UseCasConnection, Hostname, Port, Username, Password };

		/// <summary>
		/// <para>Input SAS Dataset (libref.tablename)</para>
		/// <para>输入 SAS 数据集。 以表单 libref.tablename 形式提供数据集，其中 libref 是 SAS 库的名称，tablename 是 SAS 数据集的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InSasDataset { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>输出表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Download SAS Dataset from SAS Cloud Analytic Services (CAS)</para>
		/// <para>指定从 CAS 下载输入 SAS 数据集，还是从本地 SAS 库访问此数据集。</para>
		/// <para>选中 - 将从 CAS 下载输入 SAS 数据集。</para>
		/// <para>未选中 - 将从本地 SAS 库访问输入 SAS 数据集。 这是默认设置。</para>
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
		/// <para>Download SAS Dataset from SAS Cloud Analytic Services (CAS)</para>
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
