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
	/// <para>Detect Objects Using Deep Learning</para>
	/// <para>Detect Objects Using Deep Learning</para>
	/// <para>Runs a trained deep learning model on an input raster to produce a feature class containing the objects it identifies. The feature class can be shared as a hosted feature layer in your portal. The features can be bounding boxes or polygons around the objects found, or points at the centers of the objects.</para>
	/// </summary>
	public class DetectObjectsUsingDeepLearning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputraster">
		/// <para>Input Raster</para>
		/// <para>The input image used to detect objects. It can be an image service URL, a raster layer, an image service, a map server layer, or an internet tiled layer.</para>
		/// </param>
		/// <param name="Inputmodel">
		/// <para>Input Model</para>
		/// <para>The input model can be a file or a URL of a deep learning package (.dlpk) item from the portal.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the output feature service of detected objects.</para>
		/// </param>
		public DetectObjectsUsingDeepLearning(object Inputraster, object Inputmodel, object Outputname)
		{
			this.Inputraster = Inputraster;
			this.Inputmodel = Inputmodel;
			this.Outputname = Outputname;
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
		/// <para>Tool Excute Name : ra.DetectObjectsUsingDeepLearning</para>
		/// </summary>
		public override string ExcuteName() => "ra.DetectObjectsUsingDeepLearning";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "outputCoordinateSystem", "parallelProcessingFactor", "processorType" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputraster, Inputmodel, Outputname, Modelarguments, Runnms, Confidencescorefield, Classvaluefield, Maxoverlapratio, Outobjects, Processingmode };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The input image used to detect objects. It can be an image service URL, a raster layer, an image service, a map server layer, or an internet tiled layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputraster { get; set; }

		/// <summary>
		/// <para>Input Model</para>
		/// <para>The input model can be a file or a URL of a deep learning package (.dlpk) item from the portal.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("", "dlpk_remote")]
		public object Inputmodel { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output feature service of detected objects.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Model Arguments</para>
		/// <para>The function model arguments are defined in the Python raster function class referenced by the input model. This is where you list additional deep learning parameters and arguments for experiments and refinement, such as a confidence threshold for fine tuning the sensitivity. The names of the arguments are populated by the tool from reading the Python module on the RA server.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Modelarguments { get; set; }

		/// <summary>
		/// <para>Non Maximum Suppression</para>
		/// <para>Specifies whether non maximum suppression, where duplicate objects are identified and the duplicate feature with a lower confidence value is removed, will be performed.</para>
		/// <para>Unchecked—All detected objects will be in the output feature class. This is the default.</para>
		/// <para>Checked— Duplicate detected objects will be removed.</para>
		/// <para><see cref="RunnmsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Runnms { get; set; } = "false";

		/// <summary>
		/// <para>Confidence Score Field</para>
		/// <para>The field in the feature service that contains the confidence scores that will be used as output by the object detection method.</para>
		/// <para>This parameter is required when the Non Maximum Suppression parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Confidencescorefield { get; set; } = "Confidence";

		/// <summary>
		/// <para>Class Value Field</para>
		/// <para>The name of the class value field in the feature service.</para>
		/// <para>If a field name is not specified, a Classvalue or Value field will be used. If these fields do not exist, all records will be identified as belonging to one class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Classvaluefield { get; set; } = "Class";

		/// <summary>
		/// <para>Max Overlap Ratio</para>
		/// <para>The maximum overlap ratio for two overlapping features, which is defined as the ratio of intersection area over union area. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Maxoverlapratio { get; set; } = "0";

		/// <summary>
		/// <para>Out Objects</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object Outobjects { get; set; }

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
		public DetectObjectsUsingDeepLearning SetEnviroment(object cellSize = null, object extent = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Non Maximum Suppression</para>
		/// </summary>
		public enum RunnmsEnum 
		{
			/// <summary>
			/// <para>Checked— Duplicate detected objects will be removed.</para>
			/// </summary>
			[GPValue("true")]
			[Description("NMS")]
			NMS,

			/// <summary>
			/// <para>Unchecked—All detected objects will be in the output feature class. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_NMS")]
			NO_NMS,

		}

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
