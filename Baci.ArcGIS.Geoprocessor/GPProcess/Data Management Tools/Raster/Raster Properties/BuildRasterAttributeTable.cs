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
	/// <para>Build Raster Attribute Table</para>
	/// <para>Adds a raster attribute table to a raster dataset or updates and existing one. This is used primarily with discrete data.</para>
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
		public override object[] Parameters() => new object[] { InRaster, Overwrite!, OutRaster!, ConvertColormap! };

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
		/// <para>Unchecked—The existing raster attribute table will not be overwritten and any edits will be appended to it. This is the default.</para>
		/// <para>Checked—The existing raster attribute table will be overwritten and a new raster attribute table will be created.</para>
		/// <para><see cref="OverwriteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Overwrite { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? OutRaster { get; set; }

		/// <summary>
		/// <para>Convert colormap</para>
		/// <para>Specifies whether the color map will be converted to a raster attribute table. The output raster attribute table will include Red, Green, and Blue fields containing color values from the color map. These fields define the display colors for the corresponding class values.</para>
		/// <para>This parameter only applies when the Input Raster parameter value includes an associated color map.</para>
		/// <para>Checked—The color map will be converted to a new raster attribute table.</para>
		/// <para>Unchecked—The color map will not be converted to a raster attribute table. This is the default.</para>
		/// <para>Convert Colormap—The color map will be converted to a new raster attribute table.</para>
		/// <para>None—The color map will not be converted to a raster attribute table. This is the default.</para>
		/// <para><see cref="ConvertColormapEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ConvertColormap { get; set; } = "false";

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
			/// <para>Unchecked—The existing raster attribute table will not be overwritten and any edits will be appended to it. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Convert colormap</para>
		/// </summary>
		public enum ConvertColormapEnum 
		{
			/// <summary>
			/// <para>Checked—The color map will be converted to a new raster attribute table.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ConvertColormap")]
			ConvertColormap,

			/// <summary>
			/// <para>Unchecked—The color map will not be converted to a raster attribute table. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

#endregion
	}
}
