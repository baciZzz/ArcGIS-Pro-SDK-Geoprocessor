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
	/// <para>Detect Objects Using Deep Learning</para>
	/// <para>Detect Objects Using Deep Learning</para>
	/// <para>Runs a trained deep learning model on an input raster to produce a feature class containing the objects it finds. The features can be bounding boxes or polygons around the objects found or points at the centers of the objects.</para>
	/// </summary>
	public class DetectObjectsUsingDeepLearning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The input image used to detect objects. The input can be a single raster or multiple rasters in a mosaic dataset, image service, or folder of images. A feature class with image attachments is also supported.</para>
		/// </param>
		/// <param name="OutDetectedObjects">
		/// <para>Output Detected Objects</para>
		/// <para>The output feature class that will contain geometries circling the object or objects detected in the input image.</para>
		/// </param>
		/// <param name="InModelDefinition">
		/// <para>Model Definition</para>
		/// <para>This parameter can be an Esri model definition JSON file (.emd), a JSON string, or a deep learning model package (.dlpk). A JSON string is useful when this tool is used on the server so you can paste the JSON string rather than upload the .emd file. The .dlpk file must be stored locally.</para>
		/// <para>It contains the path to the deep learning binary model file, the path to the Python raster function to be used, and other parameters such as preferred tile size or padding.</para>
		/// </param>
		public DetectObjectsUsingDeepLearning(object InRaster, object OutDetectedObjects, object InModelDefinition)
		{
			this.InRaster = InRaster;
			this.OutDetectedObjects = OutDetectedObjects;
			this.InModelDefinition = InModelDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : Detect Objects Using Deep Learning</para>
		/// </summary>
		public override string DisplayName() => "Detect Objects Using Deep Learning";

		/// <summary>
		/// <para>Tool Name : DetectObjectsUsingDeepLearning</para>
		/// </summary>
		public override string ToolName() => "DetectObjectsUsingDeepLearning";

		/// <summary>
		/// <para>Tool Excute Name : ia.DetectObjectsUsingDeepLearning</para>
		/// </summary>
		public override string ExcuteName() => "ia.DetectObjectsUsingDeepLearning";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "geographicTransformations", "gpuID", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "processorType", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutDetectedObjects, InModelDefinition, Arguments, RunNms, ConfidenceScoreField, ClassValueField, MaxOverlapRatio, ProcessingMode };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The input image used to detect objects. The input can be a single raster or multiple rasters in a mosaic dataset, image service, or folder of images. A feature class with image attachments is also supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Detected Objects</para>
		/// <para>The output feature class that will contain geometries circling the object or objects detected in the input image.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutDetectedObjects { get; set; }

		/// <summary>
		/// <para>Model Definition</para>
		/// <para>This parameter can be an Esri model definition JSON file (.emd), a JSON string, or a deep learning model package (.dlpk). A JSON string is useful when this tool is used on the server so you can paste the JSON string rather than upload the .emd file. The .dlpk file must be stored locally.</para>
		/// <para>It contains the path to the deep learning binary model file, the path to the Python raster function to be used, and other parameters such as preferred tile size or padding.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InModelDefinition { get; set; }

		/// <summary>
		/// <para>Arguments</para>
		/// <para>The function arguments defined in the Python raster function class. This is where additional deep learning parameters and arguments for experiments and refinement are listed, such as a confidence threshold for adjusting the sensitivity. The names of the arguments are populated from the Python module.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object Arguments { get; set; }

		/// <summary>
		/// <para>Non Maximum Suppression</para>
		/// <para>Specifies whether nonmaximum suppression will be performed in which duplicate objects are identified and the duplicate features with lower confidence value are removed.</para>
		/// <para>Unchecked—Nonmaximum suppression will not be performed. All objects that are detected will be in the output feature class. This is the default.</para>
		/// <para>Checked—Nonmaximum suppression will be performed and duplicate objects that are detected will be removed.</para>
		/// <para><see cref="RunNmsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RunNms { get; set; } = "false";

		/// <summary>
		/// <para>Confidence Score Field</para>
		/// <para>The name of the field in the feature class that will contain the confidence scores as output by the object detection method.</para>
		/// <para>This parameter is required when the Non Maximum Suppression parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ConfidenceScoreField { get; set; } = "Confidence";

		/// <summary>
		/// <para>Class Value Field</para>
		/// <para>The name of the class value field in the input feature class.</para>
		/// <para>If a field name is not specified, a Classvalue or Value field will be used. If these fields do not exist, all records will be identified as belonging to one class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ClassValueField { get; set; } = "Class";

		/// <summary>
		/// <para>Max Overlap Ratio</para>
		/// <para>The maximum overlap ratio for two overlapping features, which is defined as the ratio of intersection area over union area. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MaxOverlapRatio { get; set; } = "0";

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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DetectObjectsUsingDeepLearning SetEnviroment(object cellSize = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Non Maximum Suppression</para>
		/// </summary>
		public enum RunNmsEnum 
		{
			/// <summary>
			/// <para>Checked—Nonmaximum suppression will be performed and duplicate objects that are detected will be removed.</para>
			/// </summary>
			[GPValue("true")]
			[Description("NMS")]
			NMS,

			/// <summary>
			/// <para>Unchecked—Nonmaximum suppression will not be performed. All objects that are detected will be in the output feature class. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_NMS")]
			NO_NMS,

		}

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
