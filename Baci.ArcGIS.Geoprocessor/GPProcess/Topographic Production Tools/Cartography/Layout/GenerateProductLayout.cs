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
		/// <para>Specifies the supported map product that will be used.</para>
		/// <para>MTM50—An MGCP Topographic Map at 1:50,000 cartographic product scale will be used.</para>
		/// <para>MTM100—A MGCP Topographic Map at 1:100,000 cartographic product scale will be used.</para>
		/// <para>TM25—A Topographic Map at 1:25,000 cartographic product scale will be used.</para>
		/// <para>TM50—A Topographic Map at 1:50,000 cartographic product scale will be used.</para>
		/// <para>TM100—A Topographic Map at 1:100,000 cartographic product scale will be used.</para>
		/// <para>JOGA—A Joint Operations Graphic at 1:250,000 cartographic product scale will be used.</para>
		/// <para>CTM50—A Civilian Topographic map at 1:50,000 cartographic product scale will be used.</para>
		/// </param>
		/// <param name="Version">
		/// <para>Version</para>
		/// <para>The supported versions of the selected product.</para>
		/// </param>
		/// <param name="OutputLocation">
		/// <para>Output Location</para>
		/// <para>The folder path to which the output .pagx file will be written.</para>
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
		public override object[] Parameters => new object[] { Geodatabase, AoiLayer, Product, Version, OutputLocation, Rasters!, Template!, OutTemplate!, OutputType!, ExportFile! };

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
		/// <para>Specifies the supported map product that will be used.</para>
		/// <para>MTM50—An MGCP Topographic Map at 1:50,000 cartographic product scale will be used.</para>
		/// <para>MTM100—A MGCP Topographic Map at 1:100,000 cartographic product scale will be used.</para>
		/// <para>TM25—A Topographic Map at 1:25,000 cartographic product scale will be used.</para>
		/// <para>TM50—A Topographic Map at 1:50,000 cartographic product scale will be used.</para>
		/// <para>TM100—A Topographic Map at 1:100,000 cartographic product scale will be used.</para>
		/// <para>JOGA—A Joint Operations Graphic at 1:250,000 cartographic product scale will be used.</para>
		/// <para>CTM50—A Civilian Topographic map at 1:50,000 cartographic product scale will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Product { get; set; }

		/// <summary>
		/// <para>Version</para>
		/// <para>The supported versions of the selected product.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Version { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The folder path to which the output .pagx file will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputLocation { get; set; }

		/// <summary>
		/// <para>Input Rasters</para>
		/// <para>The input rasters used if the product requires an elevation guide surround element to calculate the elevation bands and spot height features. If you specify more than one raster, the rasters must have the same cell size, band number, and pixel type. If no raster is specified, the tool will not process the elevation guide data frame and a warning will appear.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Rasters { get; set; }

		/// <summary>
		/// <para>Layout Template</para>
		/// <para>The layout template to be used. If no layout template is specified, the default layout template for the product will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLayout()]
		public object? Template { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutTemplate { get; set; }

		/// <summary>
		/// <para>Output Type</para>
		/// <para>Specifies the type of output.</para>
		/// <para>PAGX—A layout file will be created. This is the default.</para>
		/// <para>APRX—An ArcGIS Pro project file will be created.</para>
		/// <para>PDF—A .pdf file will be created.</para>
		/// <para>TIFF—A .tiff file will be created.</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutputType { get; set; } = "PAGX";

		/// <summary>
		/// <para>Preset File</para>
		/// <para>Defines a set of parameter values for the specified Output Type parameter value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object? ExportFile { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Output Type</para>
		/// </summary>
		public enum OutputTypeEnum 
		{
			/// <summary>
			/// <para>PAGX—A layout file will be created. This is the default.</para>
			/// </summary>
			[GPValue("PAGX")]
			[Description("PAGX")]
			PAGX,

			/// <summary>
			/// <para>APRX—An ArcGIS Pro project file will be created.</para>
			/// </summary>
			[GPValue("APRX")]
			[Description("APRX")]
			APRX,

			/// <summary>
			/// <para>PDF—A .pdf file will be created.</para>
			/// </summary>
			[GPValue("PDF")]
			[Description("PDF")]
			PDF,

			/// <summary>
			/// <para>TIFF—A .tiff file will be created.</para>
			/// </summary>
			[GPValue("TIFF")]
			[Description("TIFF")]
			TIFF,

		}

#endregion
	}
}
