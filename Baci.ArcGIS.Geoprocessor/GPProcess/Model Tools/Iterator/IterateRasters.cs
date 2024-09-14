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
	/// <para>Iterate Rasters</para>
	/// <para>迭代栅格数据</para>
	/// <para>迭代工作空间中的所有栅格数据。</para>
	/// </summary>
	public class IterateRasters : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Workspace</para>
		/// <para>要进行迭代的栅格所在的工作空间。</para>
		/// </param>
		public IterateRasters(object InWorkspace)
		{
			this.InWorkspace = InWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : 迭代栅格数据</para>
		/// </summary>
		public override string DisplayName() => "迭代栅格数据";

		/// <summary>
		/// <para>Tool Name : IterateRasters</para>
		/// </summary>
		public override string ToolName() => "IterateRasters";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateRasters</para>
		/// </summary>
		public override string ExcuteName() => "mb.IterateRasters";

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
		public override object[] Parameters() => new object[] { InWorkspace, Wildcard!, RasterFormat!, Recursive!, Raster!, Name! };

		/// <summary>
		/// <para>Workspace</para>
		/// <para>要进行迭代的栅格所在的工作空间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Wildcard</para>
		/// <para>* 与有助于限制结果的字符的组合。 星号相当于指定全部。 如果未指定通配符，将返回所有输入。 例如，可将其用于将输入名称迭代限制为从某一字符或词语开始（例如，A*、Ari* 或 Land* 等）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Wildcard { get; set; }

		/// <summary>
		/// <para>Raster Format</para>
		/// <para>栅格格式的扩展名，如 ASC、BIL、BIP、BMP 等，或输入其他扩展名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RasterFormat { get; set; }

		/// <summary>
		/// <para>Recursive</para>
		/// <para>指定是否以递归方式迭代主文件夹的子文件夹。</para>
		/// <para>选中 - 将迭代子文件夹。</para>
		/// <para>未选中 - 不会迭代子文件夹。</para>
		/// <para><see cref="RecursiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Recursive { get; set; } = "false";

		/// <summary>
		/// <para>Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object? Raster { get; set; }

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
