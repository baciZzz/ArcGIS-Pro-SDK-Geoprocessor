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
	/// <para>Add Colormap</para>
	/// <para>Add Colormap</para>
	/// <para>Adds a new color map or replaces an existing color map on a raster dataset.</para>
	/// </summary>
	public class AddColormap : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster dataset to add or replace a color map.</para>
		/// </param>
		public AddColormap(object InRaster)
		{
			this.InRaster = InRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Colormap</para>
		/// </summary>
		public override string DisplayName() => "Add Colormap";

		/// <summary>
		/// <para>Tool Name : AddColormap</para>
		/// </summary>
		public override string ToolName() => "AddColormap";

		/// <summary>
		/// <para>Tool Excute Name : management.AddColormap</para>
		/// </summary>
		public override string ExcuteName() => "management.AddColormap";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, InTemplateRaster!, InputCLRFile!, OutRaster! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster dataset to add or replace a color map.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Input Template Raster</para>
		/// <para>A raster dataset that has a color map that you want to apply to the input raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRasterLayer()]
		public object? InTemplateRaster { get; set; }

		/// <summary>
		/// <para>Input .clr or .act File</para>
		/// <para>Specify a .clr or .act file to use as the color map.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPCompositeDomain()]
		public object? InputCLRFile { get; set; }

		/// <summary>
		/// <para>Updated Input Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? OutRaster { get; set; }

	}
}
