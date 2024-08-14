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
	/// <para>Parses an input into its file name, extension, path, and the last workspace name. The output can be used as an inline variable in the output name of other tools.</para>
	/// </summary>
	public class ParsePathExt : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataElement">
		/// <para>Input Values</para>
		/// <para>The input values to parse.</para>
		/// </param>
		public ParsePathExt(object InDataElement)
		{
			this.InDataElement = InDataElement;
		}

		/// <summary>
		/// <para>Tool Display Name : Parse Path</para>
		/// </summary>
		public override string DisplayName => "Parse Path";

		/// <summary>
		/// <para>Tool Name : ParsePathExt</para>
		/// </summary>
		public override string ToolName => "ParsePathExt";

		/// <summary>
		/// <para>Tool Excute Name : mb.ParsePathExt</para>
		/// </summary>
		public override string ExcuteName => "mb.ParsePathExt";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InDataElement, Format!, Path!, Name!, ExtensionType!, WorkspaceName! };

		/// <summary>
		/// <para>Input Values</para>
		/// <para>The input values to parse.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPType()]
		public object InDataElement { get; set; }

		/// <summary>
		/// <para>Format Name, Extension and Workspace</para>
		/// <para>Removes all reserved characters. Given the input value of C:\1Tool Data\InputFC.shp:</para>
		/// <para>Path—The output will be the file path, for example, C:\1Tool Data.</para>
		/// <para>Name—The output will be the file name, for example, InputFC.</para>
		/// <para>Extension—The output will be the file extension, for example, shp.</para>
		/// <para>Workspace Name—The output will be the workspace name, for example, _1Tool_Data.</para>
		/// <para><see cref="FormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Format { get; set; } = "false";

		/// <summary>
		/// <para>Path</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? Path { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? Name { get; set; }

		/// <summary>
		/// <para>Extension</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? ExtensionType { get; set; }

		/// <summary>
		/// <para>Workspace Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? WorkspaceName { get; set; }

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
