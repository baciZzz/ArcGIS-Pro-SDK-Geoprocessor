using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Classify Point Cloud Using Trained Model</para>
	/// <para>Classifies a point cloud using a PointCNN classification model.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ClassifyPointCloudUsingTrainedModel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointCloud">
		/// <para>Target Point Cloud</para>
		/// <para>The point cloud that will be classified.</para>
		/// </param>
		/// <param name="InTrainedModel">
		/// <para>Input Model Definition</para>
		/// <para>The input Esri model definition file (*.emd) or deep learning package (*.dlpk) that will be used to classify the point cloud. A web address for a deep learning package that is published on ArcGIS Online or ArcGIS Living Atlas can also be used.</para>
		/// </param>
		/// <param name="OutputClasses">
		/// <para>Target Classification</para>
		/// <para>The class codes from the trained model that will be used to classify the input point cloud. All classes from the input model will be used by default unless a subset is specified.</para>
		/// </param>
		public ClassifyPointCloudUsingTrainedModel(object InPointCloud, object InTrainedModel, object OutputClasses)
		{
			this.InPointCloud = InPointCloud;
			this.InTrainedModel = InTrainedModel;
			this.OutputClasses = OutputClasses;
		}

		/// <summary>
		/// <para>Tool Display Name : Classify Point Cloud Using Trained Model</para>
		/// </summary>
		public override string DisplayName => "Classify Point Cloud Using Trained Model";

		/// <summary>
		/// <para>Tool Name : ClassifyPointCloudUsingTrainedModel</para>
		/// </summary>
		public override string ToolName => "ClassifyPointCloudUsingTrainedModel";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ClassifyPointCloudUsingTrainedModel</para>
		/// </summary>
		public override string ExcuteName => "3d.ClassifyPointCloudUsingTrainedModel";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "geographicTransformations", "gpuID", "outputCoordinateSystem", "processorType" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InPointCloud, InTrainedModel, OutputClasses, InClassMode, TargetClasses, ComputeStats, Boundary, UpdatePyramid, OutPointCloud };

		/// <summary>
		/// <para>Target Point Cloud</para>
		/// <para>The point cloud that will be classified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InPointCloud { get; set; }

		/// <summary>
		/// <para>Input Model Definition</para>
		/// <para>The input Esri model definition file (*.emd) or deep learning package (*.dlpk) that will be used to classify the point cloud. A web address for a deep learning package that is published on ArcGIS Online or ArcGIS Living Atlas can also be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InTrainedModel { get; set; }

		/// <summary>
		/// <para>Target Classification</para>
		/// <para>The class codes from the trained model that will be used to classify the input point cloud. All classes from the input model will be used by default unless a subset is specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object OutputClasses { get; set; }

		/// <summary>
		/// <para>Existing Class Code Handling</para>
		/// <para>Specifies how the editable points from the input point cloud will be defined.</para>
		/// <para>EDIT_ALL—All points in the input point cloud will be edited. This is the default.</para>
		/// <para>EDIT_SELECTED—Only points with class codes specified in the Existing Class Codes parameter will be edited; all other points remain unchanged.</para>
		/// <para>PRESERVE_SELECTED—Points with class codes specified in the Existing Class Codes parameter will be preserved; the remaining points will be edited.</para>
		/// <para><see cref="InClassModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InClassMode { get; set; } = "EDIT_ALL";

		/// <summary>
		/// <para>Existing Class Codes</para>
		/// <para>The classes for which points will be edited or have their original class code designation preserved based on the Existing Class Code Handling parameter value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object TargetClasses { get; set; }

		/// <summary>
		/// <para>Compute statistics</para>
		/// <para>Specifies whether statistics will be computed for the .las files referenced by the LAS dataset. Computing statistics provides a spatial index for each .las file, which improves analysis and display performance. Statistics also enhance the filtering and symbology experience by limiting the display of LAS attributes, such as classification codes and return information, to values that are present in the .las file.</para>
		/// <para>Checked—Statistics will be computed. This is the default.</para>
		/// <para>Unchecked—Statistics will not be computed.</para>
		/// <para><see cref="ComputeStatsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ComputeStats { get; set; } = "true";

		/// <summary>
		/// <para>Processing Boundary</para>
		/// <para>The polygon boundary that defines the subset of points to be processed from the input point cloud. Points outside the boundary features will not be evaluated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object Boundary { get; set; }

		/// <summary>
		/// <para>Update pyramid</para>
		/// <para>Specifies whether the LAS dataset pyramid will be updated after the class codes are modified.</para>
		/// <para>Checked—The LAS dataset pyramid will be updated. This is the default.</para>
		/// <para>Unchecked—The LAS dataset pyramid will not be updated.</para>
		/// <para><see cref="UpdatePyramidEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UpdatePyramid { get; set; } = "true";

		/// <summary>
		/// <para>Output Point Cloud</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutPointCloud { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClassifyPointCloudUsingTrainedModel SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Existing Class Code Handling</para>
		/// </summary>
		public enum InClassModeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("EDIT_ALL")]
			[Description("Edit All Points")]
			Edit_All_Points,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("EDIT_SELECTED")]
			[Description("Edit Selected Points")]
			Edit_Selected_Points,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PRESERVE_SELECTED")]
			[Description("Preserve Selected Points")]
			Preserve_Selected_Points,

		}

		/// <summary>
		/// <para>Compute statistics</para>
		/// </summary>
		public enum ComputeStatsEnum 
		{
			/// <summary>
			/// <para>Checked—Statistics will be computed. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPUTE_STATS")]
			COMPUTE_STATS,

			/// <summary>
			/// <para>Unchecked—Statistics will not be computed.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_COMPUTE_STATS")]
			NO_COMPUTE_STATS,

		}

		/// <summary>
		/// <para>Update pyramid</para>
		/// </summary>
		public enum UpdatePyramidEnum 
		{
			/// <summary>
			/// <para>Checked—The LAS dataset pyramid will be updated. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_PYRAMID")]
			UPDATE_PYRAMID,

			/// <summary>
			/// <para>Unchecked—The LAS dataset pyramid will not be updated.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_UPDATE_PYRAMID")]
			NO_UPDATE_PYRAMID,

		}

#endregion
	}
}
