using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.RasterAnalysisTools
{
	/// <summary>
	/// <para>Classify Pixels Using Deep Learning</para>
	/// <para>Runs a trained deep learning model on an input image to produce a classified raster published as a hosted imagery layer in your portal.</para>
	/// </summary>
	public class ClassifyPixelsUsingDeepLearning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputraster">
		/// <para>Input Raster</para>
		/// <para>The input image to classify. It can be an image service URL, a raster layer, an image service, a map server layer, or an Internet tiled layer.</para>
		/// </param>
		/// <param name="Inputmodel">
		/// <para>Input Model</para>
		/// <para>The input is a URL of a deep learning package (.dlpk) item. It contains the path to the deep learning binary model file, the path to the Python raster function to be used, and other parameters such as preferred tile size or padding.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the image service of the classified pixels.</para>
		/// </param>
		public ClassifyPixelsUsingDeepLearning(object Inputraster, object Inputmodel, object Outputname)
		{
			this.Inputraster = Inputraster;
			this.Inputmodel = Inputmodel;
			this.Outputname = Outputname;
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
		/// <para>Tool Excute Name : ra.ClassifyPixelsUsingDeepLearning</para>
		/// </summary>
		public override string ExcuteName() => "ra.ClassifyPixelsUsingDeepLearning";

		/// <summary>
		/// <para>Toolbox Display Name : Raster Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Raster Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : ra</para>
		/// </summary>
		public override string ToolboxAlise() => "ra";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "outputCoordinateSystem", "parallelProcessingFactor", "processorType", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputraster, Inputmodel, Outputname, Modelarguments, Outraster, Processingmode };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The input image to classify. It can be an image service URL, a raster layer, an image service, a map server layer, or an Internet tiled layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputraster { get; set; }

		/// <summary>
		/// <para>Input Model</para>
		/// <para>The input is a URL of a deep learning package (.dlpk) item. It contains the path to the deep learning binary model file, the path to the Python raster function to be used, and other parameters such as preferred tile size or padding.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("", "dlpk_remote")]
		public object Inputmodel { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the image service of the classified pixels.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Model Arguments</para>
		/// <para>The function arguments are defined in the Python raster function class referenced by the input model. This is where you list additional deep learning parameters and arguments for experiments and refinement, such as a confidence threshold for adjusting the sensitivity. The names of the arguments are populated by the tool from reading the Python module on the RA server.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Modelarguments { get; set; }

		/// <summary>
		/// <para>Updated Input Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outraster { get; set; }

		/// <summary>
		/// <para>Processing Mode</para>
		/// <para>Specifies how all raster items in a mosaic dataset or an image service will be processed. This parameter is applied when the input raster is a mosaic dataset or an image service.</para>
		/// <para>Process as mosaicked image—All raster items in the mosaic dataset or image service will be mosaicked together and processed. This is the default.</para>
		/// <para>Process all raster items separately—All raster items in the mosaic dataset or image service will be processed as separate images.</para>
		/// <para><see cref="ProcessingmodeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Processingmode { get; set; } = "PROCESS_AS_MOSAICKED_IMAGE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClassifyPixelsUsingDeepLearning SetEnviroment(object cellSize = null , object extent = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Processing Mode</para>
		/// </summary>
		public enum ProcessingmodeEnum 
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
