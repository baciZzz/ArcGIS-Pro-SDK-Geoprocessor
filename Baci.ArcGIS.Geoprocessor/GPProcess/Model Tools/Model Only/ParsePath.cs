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
	/// <para>Parse Path</para>
	/// <para>The Parse Path tool parses the input into its file, path, name, or extension. The output can be used as inline variable in the output name of other tools.</para>
	/// </summary>
	public class ParsePath : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataElement">
		/// <para>Input Values</para>
		/// <para>Input values that you want to parse.</para>
		/// </param>
		public ParsePath(object InDataElement)
		{
			this.InDataElement = InDataElement;
		}

		/// <summary>
		/// <para>Tool Display Name : Parse Path</para>
		/// </summary>
		public override string DisplayName() => "Parse Path";

		/// <summary>
		/// <para>Tool Name : ParsePath</para>
		/// </summary>
		public override string ToolName() => "ParsePath";

		/// <summary>
		/// <para>Tool Excute Name : mb.ParsePath</para>
		/// </summary>
		public override string ExcuteName() => "mb.ParsePath";

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
		public override object[] Parameters() => new object[] { InDataElement, ParseType!, Value! };

		/// <summary>
		/// <para>Input Values</para>
		/// <para>Input values that you want to parse.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPType()]
		public object InDataElement { get; set; }

		/// <summary>
		/// <para>Parse type</para>
		/// <para>Specifies the parse type.</para>
		/// <para>Given an input value of C:\ToolData\InputFC.shp:</para>
		/// <para>File name and extension—Output will be the file. Example: InputFC.shp</para>
		/// <para>File path—Output will be the file path. Example: C:\ToolData</para>
		/// <para>File name—Output will be the file name. Example: InputFC</para>
		/// <para>File extension—Output will be the file extension. Example: shp</para>
		/// <para><see cref="ParseTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ParseType { get; set; } = "FILE";

		/// <summary>
		/// <para>Value</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? Value { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Parse type</para>
		/// </summary>
		public enum ParseTypeEnum 
		{
			/// <summary>
			/// <para>File name and extension—Output will be the file. Example: InputFC.shp</para>
			/// </summary>
			[GPValue("FILE")]
			[Description("File name and extension")]
			File_name_and_extension,

			/// <summary>
			/// <para>File path—Output will be the file path. Example: C:\ToolData</para>
			/// </summary>
			[GPValue("PATH")]
			[Description("File path")]
			File_path,

			/// <summary>
			/// <para>File extension—Output will be the file extension. Example: shp</para>
			/// </summary>
			[GPValue("EXTENSION")]
			[Description("File extension")]
			File_extension,

			/// <summary>
			/// <para>File name and extension—Output will be the file. Example: InputFC.shp</para>
			/// </summary>
			[GPValue("NAME")]
			[Description("File name")]
			File_name,

		}

#endregion
	}
}
