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
	/// <para>Iterate Files</para>
	/// <para>迭代文件</para>
	/// <para>迭代文件夹中的文件。</para>
	/// </summary>
	public class IterateFiles : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFolder">
		/// <para>Folder</para>
		/// <para>输入文件所位于的文件夹。</para>
		/// </param>
		public IterateFiles(object InFolder)
		{
			this.InFolder = InFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : 迭代文件</para>
		/// </summary>
		public override string DisplayName() => "迭代文件";

		/// <summary>
		/// <para>Tool Name : IterateFiles</para>
		/// </summary>
		public override string ToolName() => "IterateFiles";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateFiles</para>
		/// </summary>
		public override string ExcuteName() => "mb.IterateFiles";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFolder, Wildcard!, Extension!, Recursive!, File!, Name! };

		/// <summary>
		/// <para>Folder</para>
		/// <para>输入文件所位于的文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object InFolder { get; set; }

		/// <summary>
		/// <para>Wildcard</para>
		/// <para>* 与有助于限制结果的字符的组合。 星号相当于指定全部。 如果未指定通配符，将返回所有输入。 例如，可将其用于将输入名称迭代限制为从某一字符或词语开始（例如，A*、Ari* 或 Land* 等）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Wildcard { get; set; }

		/// <summary>
		/// <para>FileType</para>
		/// <para>文件扩展名，例如 TXT、ZIP 等。只会迭代具有扩展名的文件。不要在文件扩展名前使用句点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Extension { get; set; }

		/// <summary>
		/// <para>Recursive</para>
		/// <para>确定是否递归迭代主文件夹的所有子文件夹。</para>
		/// <para>选中 - 将递归迭代所有子文件夹。</para>
		/// <para>未选中 - 将不会递归迭代所有子文件。</para>
		/// <para><see cref="RecursiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Recursive { get; set; } = "false";

		/// <summary>
		/// <para>File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? File { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? Name { get; set; }

		#region InnerClass

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
