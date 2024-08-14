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
	/// <para>Detect Change Using Deep Learning</para>
	/// <para>Runs a trained deep learning model to detect change between two rasters.</para>
	/// </summary>
	public class DetectChangeUsingDeepLearning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="FromRaster">
		/// <para>From Raster</para>
		/// <para>The input images of the previous raster.</para>
		/// </param>
		/// <param name="ToRaster">
		/// <para>To Raster</para>
		/// <para>The input images of the recent raster.</para>
		/// </param>
		/// <param name="OutClassifiedRaster">
		/// <para>Output Classified Raster</para>
		/// <para>The output classified raster that shows the change.</para>
		/// </param>
		/// <param name="InModelDefinition">
		/// <para>Model Definition</para>
		/// <para>The Esri model definition parameter value can be an Esri model definition JSON file (.emd), a JSON string, or a deep learning model package (.dlpk). A JSON string is useful when this tool is used on the server so you can paste the JSON string rather than upload the .emd file. The .dlpk file must be stored locally.</para>
		/// <para>It contains the path to the deep learning binary model file, the path to the Python raster function to be used, and other parameters such as preferred tile size or padding.</para>
		/// </param>
		public DetectChangeUsingDeepLearning(object FromRaster, object ToRaster, object OutClassifiedRaster, object InModelDefinition)
		{
			this.FromRaster = FromRaster;
			this.ToRaster = ToRaster;
			this.OutClassifiedRaster = OutClassifiedRaster;
			this.InModelDefinition = InModelDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : Detect Change Using Deep Learning</para>
		/// </summary>
		public override string DisplayName => "Detect Change Using Deep Learning";

		/// <summary>
		/// <para>Tool Name : DetectChangeUsingDeepLearning</para>
		/// </summary>
		public override string ToolName => "DetectChangeUsingDeepLearning";

		/// <summary>
		/// <para>Tool Excute Name : ia.DetectChangeUsingDeepLearning</para>
		/// </summary>
		public override string ExcuteName => "ia.DetectChangeUsingDeepLearning";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cellSize", "extent", "geographicTransformations", "gpuID", "outputCoordinateSystem", "parallelProcessingFactor", "processorType", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { FromRaster, ToRaster, OutClassifiedRaster, InModelDefinition, Arguments };

		/// <summary>
		/// <para>From Raster</para>
		/// <para>The input images of the previous raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object FromRaster { get; set; }

		/// <summary>
		/// <para>To Raster</para>
		/// <para>The input images of the recent raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object ToRaster { get; set; }

		/// <summary>
		/// <para>Output Classified Raster</para>
		/// <para>The output classified raster that shows the change.</para>
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
		public object Arguments { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DetectChangeUsingDeepLearning SetEnviroment(object cellSize = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
