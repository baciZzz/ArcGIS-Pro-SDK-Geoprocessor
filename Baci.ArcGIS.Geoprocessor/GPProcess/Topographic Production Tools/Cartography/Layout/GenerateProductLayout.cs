using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Generate Product Layout</para>
	/// <para>Automates the process of producing a layout or map based on a standard specification.</para>
	/// </summary>
	public class GenerateProductLayout : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Geodatabase">
		/// <para>Input Geodatabase</para>
		/// <para>The input geodatabase that contains the features for the final map product. The schema of the workspace must match the schema of the product selected.</para>
		/// </param>
		/// <param name="AoiLayer">
		/// <para>Area Of Interest</para>
		/// <para>A polygon feature layer that describes the processing extent. The feature layer must have only one feature selected or must be a feature class with only one feature.</para>
		/// </param>
		/// <param name="Product">
		/// <para>Product</para>
		/// <para>The list of supported map products.</para>
		/// </param>
		/// <param name="Version">
		/// <para>Version</para>
		/// <para>The list of supported versions for the selected product.</para>
		/// </param>
		/// <param name="OutputLocation">
		/// <para>Output Location</para>
		/// <para>The full folder path to which the output .pagx file will be written.</para>
		/// </param>
		public GenerateProductLayout(object Geodatabase, object AoiLayer, object Product, object Version, object OutputLocation)
		{
			this.Geodatabase = Geodatabase;
			this.AoiLayer = AoiLayer;
			this.Product = Product;
			this.Version = Version;
			this.OutputLocation = OutputLocation;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Product Layout</para>
		/// </summary>
		public override string DisplayName => "Generate Product Layout";

		/// <summary>
		/// <para>Tool Name : GenerateProductLayout</para>
		/// </summary>
		public override string ToolName => "GenerateProductLayout";

		/// <summary>
		/// <para>Tool Excute Name : topographic.GenerateProductLayout</para>
		/// </summary>
		public override string ExcuteName => "topographic.GenerateProductLayout";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Geodatabase, AoiLayer, Product, Version, OutputLocation, Rasters, Template, OutTemplate };

		/// <summary>
		/// <para>Input Geodatabase</para>
		/// <para>The input geodatabase that contains the features for the final map product. The schema of the workspace must match the schema of the product selected.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object Geodatabase { get; set; }

		/// <summary>
		/// <para>Area Of Interest</para>
		/// <para>A polygon feature layer that describes the processing extent. The feature layer must have only one feature selected or must be a feature class with only one feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPLayerDomain()]
		public object AoiLayer { get; set; }

		/// <summary>
		/// <para>Product</para>
		/// <para>The list of supported map products.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Product { get; set; }

		/// <summary>
		/// <para>Version</para>
		/// <para>The list of supported versions for the selected product.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Version { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The full folder path to which the output .pagx file will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputLocation { get; set; }

		/// <summary>
		/// <para>Input Rasters</para>
		/// <para>The input rasters used if the product requires an elevation guide surround element to calculate the elevation bands and spot height features. If you specify more than one raster, the rasters must have the same cell size, band number, and pixel type. If no raster is specified, the tool will not process the elevation guide data frame and will give a warning.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Rasters { get; set; }

		/// <summary>
		/// <para>Layout Template</para>
		/// <para>The layout template to be used. If no layout template is specified, the default layout template for the product will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLayout()]
		public object Template { get; set; }

		/// <summary>
		/// <para>Layout Template</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLayout()]
		public object OutTemplate { get; set; }

	}
}
