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
	/// <para>Parse Path</para>
	/// <para>解析路径</para>
	/// <para>用于将输入解析成相应的文件名、扩展名、路径和最后一个工作空间名称。输出可用作其他工具的输出名称中的行内变量。</para>
	/// </summary>
	public class ParsePathExt : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataElement">
		/// <para>Input Values</para>
		/// <para>要解析的输入值。</para>
		/// </param>
		public ParsePathExt(object InDataElement)
		{
			this.InDataElement = InDataElement;
		}

		/// <summary>
		/// <para>Tool Display Name : 解析路径</para>
		/// </summary>
		public override string DisplayName() => "解析路径";

		/// <summary>
		/// <para>Tool Name : ParsePathExt</para>
		/// </summary>
		public override string ToolName() => "ParsePathExt";

		/// <summary>
		/// <para>Tool Excute Name : mb.ParsePathExt</para>
		/// </summary>
		public override string ExcuteName() => "mb.ParsePathExt";

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
		public override object[] Parameters() => new object[] { InDataElement, Format, Path, Name, ExtensionType, WorkspaceName };

		/// <summary>
		/// <para>Input Values</para>
		/// <para>要解析的输入值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPType()]
		public object InDataElement { get; set; }

		/// <summary>
		/// <para>Format Name, Extension and Workspace</para>
		/// <para>移除所有保留字符。给定 C:\1Tool Data\InputFC.shp 的输入值：</para>
		/// <para>路径 - 输出将为文件路径，例如 C:\1Tool Data。</para>
		/// <para>名称 - 输出将为文件名，例如 InputFC。</para>
		/// <para>扩展名 - 输出将为文件扩展名，例如 shp。</para>
		/// <para>工作空间名称 - 输出将为工作空间名称，例如 _1Tool_Data。</para>
		/// <para><see cref="FormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Format { get; set; } = "false";

		/// <summary>
		/// <para>Path</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object Path { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Extension</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object ExtensionType { get; set; }

		/// <summary>
		/// <para>Workspace Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object WorkspaceName { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Format Name, Extension and Workspace</para>
		/// </summary>
		public enum FormatEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FORMAT")]
			FORMAT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_FORMAT")]
			NOT_FORMAT,

		}

#endregion
	}
}
