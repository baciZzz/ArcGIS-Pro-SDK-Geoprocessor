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
	/// <para>Train ISO Cluster Classifier</para>
	/// <para>Generates an Esri classifier definition file (.ecd) using the Iso Cluster classification definition.</para>
	/// </summary>
	public class TrainIsoClusterClassifier : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster dataset to classify.</para>
		/// </param>
		/// <param name="MaxClasses">
		/// <para>Max Number Of Classes / Clusters</para>
		/// <para>Maximum number of desired classes to group pixels or segments. This should be set to be greater than the number of classes in your legend.</para>
		/// <para>It is possible that you will get fewer classes than what you specified for this parameter. If you need more, increase this value and aggregate classes after the training process is complete.</para>
		/// </param>
		/// <param name="OutClassifierDefinition">
		/// <para>Output Classifier Definition File</para>
		/// <para>The output JSON format file that will contain attribute information, statistics, hyperplane vectors, and other information for the classifier. An .ecd file will be created.</para>
		/// </param>
		public TrainIsoClusterClassifier(object InRaster, object MaxClasses, object OutClassifierDefinition)
		{
			this.InRaster = InRaster;
			this.MaxClasses = MaxClasses;
			this.OutClassifierDefinition = OutClassifierDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : Train ISO Cluster Classifier</para>
		/// </summary>
		public override string DisplayName() => "Train ISO Cluster Classifier";

		/// <summary>
		/// <para>Tool Name : TrainIsoClusterClassifier</para>
		/// </summary>
		public override string ToolName() => "TrainIsoClusterClassifier";

		/// <summary>
		/// <para>Tool Excute Name : ia.TrainIsoClusterClassifier</para>
		/// </summary>
		public override string ExcuteName() => "ia.TrainIsoClusterClassifier";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, MaxClasses, OutClassifierDefinition, InAdditionalRaster, MaxIterations, MinSamplesPerCluster, SkipFactor, UsedAttributes, MaxMergePerIter, MaxMergeDistance };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster dataset to classify.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Max Number Of Classes / Clusters</para>
		/// <para>Maximum number of desired classes to group pixels or segments. This should be set to be greater than the number of classes in your legend.</para>
		/// <para>It is possible that you will get fewer classes than what you specified for this parameter. If you need more, increase this value and aggregate classes after the training process is complete.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object MaxClasses { get; set; }

		/// <summary>
		/// <para>Output Classifier Definition File</para>
		/// <para>The output JSON format file that will contain attribute information, statistics, hyperplane vectors, and other information for the classifier. An .ecd file will be created.</para>
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
		/// <para>Maximum Number Of Iterations</para>
		/// <para>The maximum number of iterations the clustering process will run.</para>
		/// <para>The recommended range is between 10 and 20 iterations. Increasing this value will linearly increase the processing time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaxIterations { get; set; } = "20";

		/// <summary>
		/// <para>Minimum Number of Samples Per Cluster</para>
		/// <para>The minimum number of pixels or segments in a valid cluster or class.</para>
		/// <para>The default value of 20 is effective in creating statistically significant classes. You can increase this number for more robust classes; however, it may limit the overall number of classes that are created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MinSamplesPerCluster { get; set; } = "20";

		/// <summary>
		/// <para>Skip Factor</para>
		/// <para>Number of pixels to skip for a pixel image input. If a segmented image is an input, specify the number of segments to skip.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object SkipFactor { get; set; } = "10";

		/// <summary>
		/// <para>Segment Attributes Used</para>
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
		/// <para>Maximum Number Of Cluster Merges per Iteration</para>
		/// <para>The maximum number of cluster merges per iteration. Increasing the number of merges will reduce the number of classes that are created. A lower value will result in more classes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaxMergePerIter { get; set; } = "5";

		/// <summary>
		/// <para>Maximum Merge Distance</para>
		/// <para>The maximum distance between cluster centers in feature space. Increasing the distance will allow more clusters to merge, resulting in fewer classes. A lower value will result in more classes. Values from 0 to 5 typically return the best results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MaxMergeDistance { get; set; } = "0.5";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TrainIsoClusterClassifier SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Segment Attributes Used</para>
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
