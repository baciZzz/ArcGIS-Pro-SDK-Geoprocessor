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
	/// <para>Iterate Files</para>
	/// <para>Iterates over files in a folder.</para>
	/// </summary>
	public class IterateFiles : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFolder">
		/// <para>Folder</para>
		/// <para>Folder in which the input files are located.</para>
		/// </param>
		public IterateFiles(object InFolder)
		{
			this.InFolder = InFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Iterate Files</para>
		/// </summary>
		public override string DisplayName() => "Iterate Files";

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
		public override object[] Parameters() => new object[] { InFolder, Wildcard, Extension, Recursive, File, Name };

		/// <summary>
		/// <para>Folder</para>
		/// <para>Folder in which the input files are located.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object InFolder { get; set; }

		/// <summary>
		/// <para>Wildcard</para>
		/// <para>A combination of * and characters that help to limit the results. The asterisk is the same as saying ALL. If no wildcard is specified, all inputs will be returned. For example, it can be used to restrict Iteration over input names starting with a certain character or word (for example, A* or Ari* or Land* and so on).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Wildcard { get; set; }

		/// <summary>
		/// <para>FileType</para>
		/// <para>The file extension, such as TXT, ZIP, and so on. Only files with the extension will be iterated. Do not use a period before the file extension.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Extension { get; set; }

		/// <summary>
		/// <para>Recursive</para>
		/// <para>Determines if all subfolders of the main folder will be recursively iterated through.</para>
		/// <para>Checked—Will iterate through all subfolders.</para>
		/// <para>Unchecked—Will not iterate through all subfolders.</para>
		/// <para><see cref="RecursiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Recursive { get; set; } = "false";

		/// <summary>
		/// <para>File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object File { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object Name { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Recursive</para>
		/// </summary>
		public enum RecursiveEnum 
		{
			/// <summary>
			/// <para>Checked—Will iterate through all subfolders.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RECURSIVE")]
			RECURSIVE,

			/// <summary>
			/// <para>Unchecked—Will not iterate through all subfolders.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_RECURSIVE")]
			NOT_RECURSIVE,

		}

#endregion
	}
}
