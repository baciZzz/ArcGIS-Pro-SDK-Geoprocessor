using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ImageAnalystTools
{
	/// <summary>
	/// <para>Classify Pixels Using Deep Learning</para>
	/// <para>Classify Pixels Using Deep Learning</para>
	/// <para>Runs a trained deep learning model on an input raster to produce a classified raster, with each valid pixel having an assigned class label.</para>
	/// </summary>
	public class ClassifyPixelsUsingDeepLearning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The input raster dataset to classify. The input can be a single raster or multiple rasters in a mosaic dataset, an image service, or a folder of images.</para>
		/// </param>
		/// <param name="OutClassifiedRaster">
		/// <para>Output Classified Raster</para>
		/// <para>The name of the classified raster or the mosaic dataset containing the classified rasters.</para>
		/// </param>
		/// <param name="InModelDefinition">
		/// <para>Model Definition</para>
		/// <para>The Esri model definition parameter value can be an Esri model definition JSON file (.emd), a JSON string, or a deep learning model package (.dlpk). A JSON string is useful when this tool is used on the server so you can paste the JSON string rather than upload the .emd file. The .dlpk file must be stored locally.</para>
		/// <para>It contains the path to the deep learning binary model file, the path to the Python raster function to be used, and other parameters such as preferred tile size or padding.</para>
		/// </param>
		public ClassifyPixelsUsingDeepLearning(object InRaster, object OutClassifiedRaster, object InModelDefinition)
		{
			this.InRaster = InRaster;
			this.OutClassifiedRaster = OutClassifiedRaster;
			this.InModelDefinition = InModelDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : Classify Pixels Using Deep Learning</para>
		/// </summary>
		public override string DisplayName() => "Classify Pixels Using Deep Learning";

		/// <summary>
		/// <para>Tool Name : ClassifyPixelsUsingDeepLearning</para>
		/// </summary>
		public override string ToolName() => "ClassifyPixelsUsingDeepLearning";

		/// <summary>
		/// <para>Tool Excute Name : ia.ClassifyPixelsUsingDeepLearning</para>
		/// </summary>
		public override string ExcuteName() => "ia.ClassifyPixelsUsingDeepLearning";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise() => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "geographicTransformations", "gpuID", "outputCoordinateSystem", "parallelProcessingFactor", "processorType", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutClassifiedRaster, InModelDefinition, Arguments!, ProcessingMode!, OutClassifiedFolder! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The input raster dataset to classify. The input can be a single raster or multiple rasters in a mosaic dataset, an image service, or a folder of images.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Classified Raster</para>
		/// <para>The name of the classified raster or the mosaic dataset containing the classified rasters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutClassifiedRaster { get; set; }

		/// <summary>
		/// <para>Model Definition</para>
		/// <para>The Esri model definition parameter value can be an Esri model definition JSON file (.emd), a JSON string, or a deep learning model package (.dlpk). A JSON string is useful when this tool is used on the server so you can paste the JSON string rather than upload the .emd file. The .dlpk file must be stored locally.</para>
		/// <para>It contains the path to the deep learning binary model file, the path to the Python raster function to be used, and other parameters such as preferred tile size or padding.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InModelDefinition { get; set; }

		/// <summary>
		/// <para>Arguments</para>
		/// <para>The function arguments are defined in the Python raster function class. This is where you list additional deep learning parameters and arguments for experiments and refinement, such as a confidence threshold for adjusting sensitivity. The names of the arguments are populated from reading the Python module.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? Arguments { get; set; }

		/// <summary>
		/// <para>Processing Mode</para>
		/// <para>Specifies how all raster items in a mosaic dataset or an image service will be processed. This parameter is applied when the input raster is a mosaic dataset or an image service.</para>
		/// <para>Process as mosaicked image—All raster items in the mosaic dataset or image service will be mosaicked together and processed. This is the default.</para>
		/// <para>Process all raster items separately—All raster items in the mosaic dataset or image service will be processed as separate images.</para>
		/// <para><see cref="ProcessingModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ProcessingMode { get; set; } = "PROCESS_AS_MOSAICKED_IMAGE";

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>The folder where the output classified rasters will be stored. A mosaic dataset will be generated using the classified rasters in this folder.</para>
		/// <para>This parameter is required when the input raster is a folder of images or a mosaic dataset in which all items are to be processed separately. The default is a folder in the project folder.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object? OutClassifiedFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClassifyPixelsUsingDeepLearning SetEnviroment(object? cellSize = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? processorType = null , object? scratchWorkspace = null , object? snapRaster = null , object? workspace = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, processorType: processorType, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Processing Mode</para>
		/// </summary>
		public enum ProcessingModeEnum 
		{
			/// <summary>
			/// <para>Process as mosaicked image—All raster items in the mosaic dataset or image service will be mosaicked together and processed. This is the default.</para>
			/// </summary>
			[GPValue("PROCESS_AS_MOSAICKED_IMAGE")]
			[Description("Process as mosaicked image")]
			Process_as_mosaicked_image,

			/// <summary>
			/// <para>Process all raster items separately—All raster items in the mosaic dataset or image service will be processed as separate images.</para>
			/// </summary>
			[GPValue("PROCESS_ITEMS_SEPARATELY")]
			[Description("Process all raster items separately")]
			Process_all_raster_items_separately,

		}

#endregion
	}
}
