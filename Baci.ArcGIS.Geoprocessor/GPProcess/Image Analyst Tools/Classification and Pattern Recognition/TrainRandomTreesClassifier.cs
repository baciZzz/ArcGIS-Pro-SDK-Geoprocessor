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
	/// <para>Train Random Trees Classifier</para>
	/// <para>Generates an Esri classifier definition file (.ecd) using the Random Trees classification method.</para>
	/// </summary>
	public class TrainRandomTreesClassifier : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster dataset to classify.</para>
		/// <para>You can use any Esri-supported raster dataset. One option is a 3-band, 8-bit segmented raster dataset in which all the pixels in the same segment have the same color. The input can also be a single band, 8-bit, grayscale segmented raster.</para>
		/// </param>
		/// <param name="InTrainingFeatures">
		/// <para>Input Training Sample File</para>
		/// <para>The training sample file or layer that delineates the training sites.</para>
		/// <para>These can be either shapefiles or feature classes that contain the training samples. The following field names are required in the training sample file:</para>
		/// <para>classname—A text field indicating the name of the class category</para>
		/// <para>classvalue—A long integer field containing the integer value for each class category</para>
		/// </param>
		/// <param name="OutClassifierDefinition">
		/// <para>Output Classifier Definition File</para>
		/// <para>A JSON file that contains attribute information, statistics, or other information for the classifier. An .ecd file is created.</para>
		/// </param>
		public TrainRandomTreesClassifier(object InRaster, object InTrainingFeatures, object OutClassifierDefinition)
		{
			this.InRaster = InRaster;
			this.InTrainingFeatures = InTrainingFeatures;
			this.OutClassifierDefinition = OutClassifierDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : Train Random Trees Classifier</para>
		/// </summary>
		public override string DisplayName => "Train Random Trees Classifier";

		/// <summary>
		/// <para>Tool Name : TrainRandomTreesClassifier</para>
		/// </summary>
		public override string ToolName => "TrainRandomTreesClassifier";

		/// <summary>
		/// <para>Tool Excute Name : ia.TrainRandomTreesClassifier</para>
		/// </summary>
		public override string ExcuteName => "ia.TrainRandomTreesClassifier";

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
		public override string[] ValidEnvironments => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRaster, InTrainingFeatures, OutClassifierDefinition, InAdditionalRaster, MaxNumTrees, MaxTreeDepth, MaxSamplesPerClass, UsedAttributes, DimensionValueField };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster dataset to classify.</para>
		/// <para>You can use any Esri-supported raster dataset. One option is a 3-band, 8-bit segmented raster dataset in which all the pixels in the same segment have the same color. The input can also be a single band, 8-bit, grayscale segmented raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Input Training Sample File</para>
		/// <para>The training sample file or layer that delineates the training sites.</para>
		/// <para>These can be either shapefiles or feature classes that contain the training samples. The following field names are required in the training sample file:</para>
		/// <para>classname—A text field indicating the name of the class category</para>
		/// <para>classvalue—A long integer field containing the integer value for each class category</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTrainingFeatures { get; set; }

		/// <summary>
		/// <para>Output Classifier Definition File</para>
		/// <para>A JSON file that contains attribute information, statistics, or other information for the classifier. An .ecd file is created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPCompositeDomain()]
		public object OutClassifierDefinition { get; set; }

		/// <summary>
		/// <para>Additional Input Raster</para>
		/// <para>Ancillary raster datasets, such as a multispectral image or a DEM, will be incorporated to generate attributes and other required information for classification. This parameter is optional.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object InAdditionalRaster { get; set; }

		/// <summary>
		/// <para>Max Number of Trees</para>
		/// <para>The maximum number of trees in the forest. Increasing the number of trees will lead to higher accuracy rates, although this improvement will level off eventually. The number of trees increases the processing time linearly.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaxNumTrees { get; set; } = "50";

		/// <summary>
		/// <para>Max Tree Depth</para>
		/// <para>The maximum depth of each tree in the forest. Depth is another way of saying the number of rules each tree is allowed to create to come to a decision. Trees will not grow any deeper than this setting.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaxTreeDepth { get; set; } = "30";

		/// <summary>
		/// <para>Max Number of Samples Per Class</para>
		/// <para>The maximum number of samples that will be used to define each class.</para>
		/// <para>The default value of 1000 is recommended when the inputs are nonsegmented rasters. A value that is less than or equal to 0 means that the system will use all the samples from the training sites to train the classifier.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaxSamplesPerClass { get; set; } = "1000";

		/// <summary>
		/// <para>Segment Attributes</para>
		/// <para>Specifies the attributes that will be included in the attribute table associated with the output raster.</para>
		/// <para>Converged color—The RGB color values will be derived from the input raster on a per-segment basis.</para>
		/// <para>Mean digital number—The average digital number (DN) will be derived from the optional pixel image on a per-segment basis.</para>
		/// <para>Standard deviation—The standard deviation will be derived from the optional pixel image on a per-segment basis.</para>
		/// <para>Count of pixels—The number of pixels composing the segment, on a per-segment basis.</para>
		/// <para>Compactness—The degree to which a segment is compact or circular, on a per-segment basis. The values range from 0 to 1, in which 1 is a circle.</para>
		/// <para>Rectangularity—The degree to which the segment is rectangular, on a per-segment basis. The values range from 0 to 1, in which 1 is a rectangle.</para>
		/// <para>This parameter is only active if the Segmented key property is set to true on the input raster. If the only input to the tool is a segmented image, the default attributes are Average chromaticity color, Count of pixels, Compactness, and Rectangularity. If an Additional Input Raster value is included as an input with a segmented image, Mean digital number and Standard deviation are also available attributes.</para>
		/// <para><see cref="UsedAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Segment Attributes")]
		public object UsedAttributes { get; set; } = "COLOR;MEAN";

		/// <summary>
		/// <para>Dimension Value Field</para>
		/// <para>Contains dimension values in the input training sample feature class.</para>
		/// <para>This parameter is required to classify a time series of raster data using the change analysis raster output from the Analyze Changes Using CCDC tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object DimensionValueField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TrainRandomTreesClassifier SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Segment Attributes</para>
		/// </summary>
		public enum UsedAttributesEnum 
		{
			/// <summary>
			/// <para>Converged color—The RGB color values will be derived from the input raster on a per-segment basis.</para>
			/// </summary>
			[GPValue("COLOR")]
			[Description("Converged color")]
			Converged_color,

			/// <summary>
			/// <para>Mean digital number—The average digital number (DN) will be derived from the optional pixel image on a per-segment basis.</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("Mean digital number")]
			Mean_digital_number,

			/// <summary>
			/// <para>Standard deviation—The standard deviation will be derived from the optional pixel image on a per-segment basis.</para>
			/// </summary>
			[GPValue("STD")]
			[Description("Standard deviation")]
			Standard_deviation,

			/// <summary>
			/// <para>Count of pixels—The number of pixels composing the segment, on a per-segment basis.</para>
			/// </summary>
			[GPValue("COUNT")]
			[Description("Count of pixels")]
			Count_of_pixels,

			/// <summary>
			/// <para>Compactness—The degree to which a segment is compact or circular, on a per-segment basis. The values range from 0 to 1, in which 1 is a circle.</para>
			/// </summary>
			[GPValue("COMPACTNESS")]
			[Description("Compactness")]
			Compactness,

			/// <summary>
			/// <para>Rectangularity—The degree to which the segment is rectangular, on a per-segment basis. The values range from 0 to 1, in which 1 is a rectangle.</para>
			/// </summary>
			[GPValue("RECTANGULARITY")]
			[Description("Rectangularity")]
			Rectangularity,

		}

#endregion
	}
}
