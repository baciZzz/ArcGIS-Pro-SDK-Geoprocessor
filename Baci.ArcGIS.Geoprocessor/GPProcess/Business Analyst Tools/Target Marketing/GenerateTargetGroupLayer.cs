using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.BusinessAnalystTools
{
	/// <summary>
	/// <para>Generate Target Group Layer</para>
	/// <para>Generate Target Group Layer</para>
	/// <para>Generates a layer that identifies geographies that contain selected segments and categorized groups based on targets.</para>
	/// </summary>
	public class GenerateTargetGroupLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="GeographyLevel">
		/// <para>Geography Level</para>
		/// <para>The geography level that will be used to define the target layer.</para>
		/// </param>
		/// <param name="SegmentationBase">
		/// <para>Segmentation Base</para>
		/// <para>The segmentation base for the profile being created. Available options are provided by the segmentation dataset in use.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class for the target layer.</para>
		/// </param>
		/// <param name="TargetGroup">
		/// <para>Target Group</para>
		/// <para>A user-created group of targets. This is used if the dataset supports target groups.</para>
		/// </param>
		public GenerateTargetGroupLayer(object GeographyLevel, object SegmentationBase, object OutFeatureClass, object TargetGroup)
		{
			this.GeographyLevel = GeographyLevel;
			this.SegmentationBase = SegmentationBase;
			this.OutFeatureClass = OutFeatureClass;
			this.TargetGroup = TargetGroup;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Target Group Layer</para>
		/// </summary>
		public override string DisplayName() => "Generate Target Group Layer";

		/// <summary>
		/// <para>Tool Name : GenerateTargetGroupLayer</para>
		/// </summary>
		public override string ToolName() => "GenerateTargetGroupLayer";

		/// <summary>
		/// <para>Tool Excute Name : ba.GenerateTargetGroupLayer</para>
		/// </summary>
		public override string ExcuteName() => "ba.GenerateTargetGroupLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise() => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "baDataSource", "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { GeographyLevel, SegmentationBase, OutFeatureClass, TargetGroup, BoundaryLayer! };

		/// <summary>
		/// <para>Geography Level</para>
		/// <para>The geography level that will be used to define the target layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object GeographyLevel { get; set; }

		/// <summary>
		/// <para>Segmentation Base</para>
		/// <para>The segmentation base for the profile being created. Available options are provided by the segmentation dataset in use.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SegmentationBase { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class for the target layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Target Group</para>
		/// <para>A user-created group of targets. This is used if the dataset supports target groups.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("sgtargetgroup")]
		public object TargetGroup { get; set; }

		/// <summary>
		/// <para>Boundary Layer</para>
		/// <para>The boundary that determines the layer extent.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object? BoundaryLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateTargetGroupLayer SetEnviroment(object? baDataSource = null, object? extent = null, object? workspace = null)
		{
			base.SetEnv(baDataSource: baDataSource, extent: extent, workspace: workspace);
			return this;
		}

	}
}
