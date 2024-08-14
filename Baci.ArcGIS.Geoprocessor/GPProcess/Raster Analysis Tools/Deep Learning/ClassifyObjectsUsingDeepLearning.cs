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
	/// <para>Classify Objects Using Deep Learning</para>
	/// <para>Runs a trained deep learning model on an input raster and an optional feature class to produce a feature class or table in which each input object or feature has an assigned class or category label.</para>
	/// </summary>
	public class ClassifyObjectsUsingDeepLearning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputraster">
		/// <para>Input Raster</para>
		/// <para>The input image to classify. The image can be an image service URL, a raster layer, an image service, a map server layer, or an internet tiled layer.</para>
		/// </param>
		/// <param name="Inputmodel">
		/// <para>Input Model</para>
		/// <para>The deep learning model that will be used to classify objects in the input image. The input is the URL of a deep learning package (.dlpk) item that contains the path to the deep learning binary model file, the path to the Python raster function to be used, and other parameters such as preferred tile size or padding.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the feature service containing the classified objects.</para>
		/// </param>
		public ClassifyObjectsUsingDeepLearning(object Inputraster, object Inputmodel, object Outputname)
		{
			this.Inputraster = Inputraster;
			this.Inputmodel = Inputmodel;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : Classify Objects Using Deep Learning</para>
		/// </summary>
		public override string DisplayName => "Classify Objects Using Deep Learning";

		/// <summary>
		/// <para>Tool Name : ClassifyObjectsUsingDeepLearning</para>
		/// </summary>
		public override string ToolName => "ClassifyObjectsUsingDeepLearning";

		/// <summary>
		/// <para>Tool Excute Name : ra.ClassifyObjectsUsingDeepLearning</para>
		/// </summary>
		public override string ExcuteName => "ra.ClassifyObjectsUsingDeepLearning";

		/// <summary>
		/// <para>Toolbox Display Name : Raster Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Raster Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : ra</para>
		/// </summary>
		public override string ToolboxAlise => "ra";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cellSize", "extent", "parallelProcessingFactor", "processorType" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Inputraster, Inputmodel, Outputname, Inputfeatures, Modelarguments, Classlabelfield, Processingmode, Outobjects };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The input image to classify. The image can be an image service URL, a raster layer, an image service, a map server layer, or an internet tiled layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputraster { get; set; }

		/// <summary>
		/// <para>Input Model</para>
		/// <para>The deep learning model that will be used to classify objects in the input image. The input is the URL of a deep learning package (.dlpk) item that contains the path to the deep learning binary model file, the path to the Python raster function to be used, and other parameters such as preferred tile size or padding.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object Inputmodel { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the feature service containing the classified objects.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The feature service that identifies the location of each object or feature to be classified and labeled. Each row in the input feature service represents a single object or feature.</para>
		/// <para>If no input feature service is specified, each input image will be classified as a single object. If the input image or images use a spatial reference, the output from the tool is a feature class in which the extent of each image is used as the bounding geometry for each labeled feature class. If the input image or images are not spatially referenced, the output from the tool is a table containing the image ID values and the class labels for each image.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputfeatures { get; set; }

		/// <summary>
		/// <para>Model Arguments</para>
		/// <para>The function model arguments to use for the classification. These are defined in the Python raster function class referenced by the input model. This is where you list additional deep learning parameters and arguments for experiments and refinement, such as a confidence threshold for adjusting the sensitivity. The names of the arguments are populated by the tool from the Python module on the Raster Analytics server.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Modelarguments { get; set; }

		/// <summary>
		/// <para>Class Label Field</para>
		/// <para>The name of the field that will contain the class or category label in the output feature class.</para>
		/// <para>If a field name is not specified, a new field named ClassLabel will be generated in the output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Classlabelfield { get; set; } = "ClassLabel";

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
		/// <para>Output Objects</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object Outobjects { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClassifyObjectsUsingDeepLearning SetEnviroment(object cellSize = null , object extent = null , object parallelProcessingFactor = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, parallelProcessingFactor: parallelProcessingFactor);
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
