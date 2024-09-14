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
	/// <para>Classify Objects Using Deep Learning</para>
	/// <para>Classify Objects Using Deep Learning</para>
	/// <para>Runs a trained deep learning model on an input raster and an optional feature class to produce a feature class or table in which each input object or feature has an assigned class or category label.</para>
	/// </summary>
	public class ClassifyObjectsUsingDeepLearning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The input image used to detect objects. The input can be a single raster or multiple rasters in a mosaic dataset, image service, or folder of images. A feature class with image attachments is also supported.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Classified Objects Feature Class</para>
		/// <para>The output feature class that will contain geometries surrounding the objects or feature from the input feature class, as well as a field to store the categorization label.</para>
		/// </param>
		/// <param name="InModelDefinition">
		/// <para>Model Definition</para>
		/// <para>The Esri model definition parameter value can be an Esri model definition JSON file (.emd), a JSON string, or a deep learning model package (.dlpk). A JSON string is useful when this tool is used on the server so you can paste the JSON string rather than upload the .emd file. The .dlpk file must be stored locally.</para>
		/// <para>It contains the path to the deep learning binary model file, the path to the Python raster function to be used, and other parameters such as preferred tile size or padding.</para>
		/// </param>
		public ClassifyObjectsUsingDeepLearning(object InRaster, object OutFeatureClass, object InModelDefinition)
		{
			this.InRaster = InRaster;
			this.OutFeatureClass = OutFeatureClass;
			this.InModelDefinition = InModelDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : Classify Objects Using Deep Learning</para>
		/// </summary>
		public override string DisplayName() => "Classify Objects Using Deep Learning";

		/// <summary>
		/// <para>Tool Name : ClassifyObjectsUsingDeepLearning</para>
		/// </summary>
		public override string ToolName() => "ClassifyObjectsUsingDeepLearning";

		/// <summary>
		/// <para>Tool Excute Name : ia.ClassifyObjectsUsingDeepLearning</para>
		/// </summary>
		public override string ExcuteName() => "ia.ClassifyObjectsUsingDeepLearning";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "geographicTransformations", "gpuID", "outputCoordinateSystem", "parallelProcessingFactor", "processorType" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutFeatureClass, InModelDefinition, InFeatures, ClassLabelField, ProcessingMode, ModelArguments };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The input image used to detect objects. The input can be a single raster or multiple rasters in a mosaic dataset, image service, or folder of images. A feature class with image attachments is also supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Classified Objects Feature Class</para>
		/// <para>The output feature class that will contain geometries surrounding the objects or feature from the input feature class, as well as a field to store the categorization label.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

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
		/// <para>Input Features</para>
		/// <para>The point, line, or polygon input feature class that identifies the location of each object or feature to be classified and labelled. Each row in the input feature class represents a single object or feature.</para>
		/// <para>If no input feature class is specified, the tool assumes that each input image contains a single object to be classified. If the input image or images use a spatial reference, the output from the tool is a feature class, in which the extent of each image is used as the bounding geometry for each labelled feature class. If the input image or images are not spatially referenced, the output from the tool is a table containing the image ID values and the class labels for each image.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Class Label Field</para>
		/// <para>The name of the field that will contain the class or category label in the output feature class.</para>
		/// <para>If no field name is specified, a new field called ClassLabel will be generated in the output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ClassLabelField { get; set; } = "ClassLabel";

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
		public object ProcessingMode { get; set; } = "PROCESS_AS_MOSAICKED_IMAGE";

		/// <summary>
		/// <para>Model Arguments</para>
		/// <para>The function arguments defined in the Python raster function class. This is where additional deep learning parameters and arguments for experiments and refinement are listed, such as a confidence threshold for adjusting the sensitivity. The names of the arguments are populated from the Python module.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object ModelArguments { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClassifyObjectsUsingDeepLearning SetEnviroment(object cellSize = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor);
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
