using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Build Raster Attribute Table</para>
	/// <para>Create or update a table with information about the classes in your raster datasets. This is used primarily with discrete data.</para>
	/// </summary>
	public class BuildRasterAttributeTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The input raster dataset to which a table will be added. This tool will not run if the pixel type is floating point or double precision.</para>
		/// </param>
		public BuildRasterAttributeTable(object InRaster)
		{
			this.InRaster = InRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Build Raster Attribute Table</para>
		/// </summary>
		public override string DisplayName() => "Build Raster Attribute Table";

		/// <summary>
		/// <para>Tool Name : BuildRasterAttributeTable</para>
		/// </summary>
		public override string ToolName() => "BuildRasterAttributeTable";

		/// <summary>
		/// <para>Tool Excute Name : management.BuildRasterAttributeTable</para>
		/// </summary>
		public override string ExcuteName() => "management.BuildRasterAttributeTable";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, Overwrite, OutRaster };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The input raster dataset to which a table will be added. This tool will not run if the pixel type is floating point or double precision.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Overwrite</para>
		/// <para>Specifies whether the existing table will be overwritten.</para>
		/// <para>Unchecked—The existing raster attribute table will not be overwritten, and any edits will be appended to the current table. This is the default.</para>
		/// <para>Checked—The existing raster attribute table will be overwritten and a new raster attribute table will be created.</para>
		/// <para><see cref="OverwriteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Overwrite { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object OutRaster { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Overwrite</para>
		/// </summary>
		public enum OverwriteEnum 
		{
			/// <summary>
			/// <para>Overwrite</para>
			/// </summary>
			[GPValue("true")]
			[Description("Overwrite")]
			Overwrite,

			/// <summary>
			/// <para>Unchecked—The existing raster attribute table will not be overwritten, and any edits will be appended to the current table. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

#endregion
	}
}
