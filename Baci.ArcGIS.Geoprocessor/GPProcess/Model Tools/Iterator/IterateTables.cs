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
	/// <para>迭代表</para>
	/// <para>用于在工作空间中对表进行迭代。</para>
	/// </summary>
	public class IterateTables : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Workspace</para>
		/// <para>包含要迭代的表的工作空间。</para>
		/// </param>
		public IterateTables(object InWorkspace)
		{
			this.InWorkspace = InWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : 迭代表</para>
		/// </summary>
		public override string DisplayName() => "迭代表";

		/// <summary>
		/// <para>Tool Name : IterateTables</para>
		/// </summary>
		public override string ToolName() => "IterateTables";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateTables</para>
		/// </summary>
		public override string ExcuteName() => "mb.IterateTables";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise() => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, Wildcard!, TableType!, Recursive!, Table!, Name! };

		/// <summary>
		/// <para>Workspace</para>
		/// <para>包含要迭代的表的工作空间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Wildcard</para>
		/// <para>* 与有助于限制结果的字符的组合。 星号相当于指定全部。 如果未指定通配符，将返回所有输入。 例如，可将其用于将输入名称迭代限制为从某一字符或词语开始（例如，A*、Ari* 或 Land* 等）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Wildcard { get; set; }

		/// <summary>
		/// <para>Table Type</para>
		/// <para>为文件夹工作空间（shapefile 和 coverage）指定表类型。</para>
		/// <para>dBASE (shapefile)—表类型将为 dBASE 表 (shapefile)。</para>
		/// <para>INFO (coverage)—表类型将为 INFO 表 (coverage)。</para>
		/// <para><see cref="TableTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TableType { get; set; }

		/// <summary>
		/// <para>Recursive</para>
		/// <para>指定是否将递归迭代主文件夹中的子文件夹。</para>
		/// <para>选中 - 将递归迭代主文件夹中的所有子文件夹。</para>
		/// <para>未选中 - 将不会递归迭代主文件夹中的子文件夹。 将仅使用主文件夹。</para>
		/// <para><see cref="RecursiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Recursive { get; set; } = "false";

		/// <summary>
		/// <para>Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? Table { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? Name { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Table Type</para>
		/// </summary>
		public enum TableTypeEnum 
		{
			/// <summary>
			/// <para>dBASE (shapefile)—表类型将为 dBASE 表 (shapefile)。</para>
			/// </summary>
			[GPValue("DBASE")]
			[Description("dBASE (shapefile)")]
			DBASE,

			/// <summary>
			/// <para>INFO (coverage)—表类型将为 INFO 表 (coverage)。</para>
			/// </summary>
			[GPValue("INFO")]
			[Description("INFO (coverage)")]
			INFO,

		}

		/// <summary>
		/// <para>Recursive</para>
		/// </summary>
		public enum RecursiveEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RECURSIVE")]
			RECURSIVE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_RECURSIVE")]
			NOT_RECURSIVE,

		}

#endregion
	}
}
