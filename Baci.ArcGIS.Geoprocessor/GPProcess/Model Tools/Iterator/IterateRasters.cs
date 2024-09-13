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
	/// <para>Iterate Rasters</para>
	/// <para>Iterates over rasters in a workspace.</para>
	/// </summary>
	public class IterateRasters : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Workspace</para>
		/// <para>The workspace containing the rasters to iterate through.</para>
		/// </param>
		public IterateRasters(object InWorkspace)
		{
			this.InWorkspace = InWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : Iterate Rasters</para>
		/// </summary>
		public override string DisplayName() => "Iterate Rasters";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, Wildcard!, RasterFormat!, Recursive!, Raster!, Name! };

		/// <summary>
		/// <para>Workspace</para>
		/// <para>The workspace containing the rasters to iterate through.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Wildcard</para>
		/// <para>A combination of * and characters that help to limit the results. The asterisk is the same as specifying ALL. If no wildcard is specified, all inputs will be returned. For example, it can be used to restrict Iteration over input names starting with a certain character or word (for example, A* or Ari* or Land* and so on).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Wildcard { get; set; }

		/// <summary>
		/// <para>Raster Format</para>
		/// <para>The extension of the raster format, such as ASC, BIL, BIP, BMP, and so on, or type in another extension.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RasterFormat { get; set; }

		/// <summary>
		/// <para>Recursive</para>
		/// <para>Specifies whether subfolders of the main folder will be iterated through recursively.</para>
		/// <para>Checked—Subfolders will be iterated.</para>
		/// <para>Unchecked—Subfolders will not be iterated.</para>
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
			/// <para>Checked—Subfolders will be iterated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RECURSIVE")]
			RECURSIVE,

			/// <summary>
			/// <para>Unchecked—Subfolders will not be iterated.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_RECURSIVE")]
			NOT_RECURSIVE,

		}

#endregion
	}
}
