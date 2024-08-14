using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Generate Training Samples From Seed Points</para>
	/// <para>Generates training samples from seed points, such as accuracy assessment points or training sample points. A typical use case is generating training samples from an existing source, such as a thematic raster or a feature class.</para>
	/// </summary>
	public class GenerateTrainingSamplesFromSeedPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InClassData">
		/// <para>Input Raster or Feature Class Data</para>
		/// <para>The data source that labels the training samples.</para>
		/// </param>
		/// <param name="InSeedPoints">
		/// <para>Input Seed Points</para>
		/// <para>A point shapefile or feature class to provide the centers of training sample polygons.</para>
		/// </param>
		/// <param name="OutTrainingFeatureClass">
		/// <para>Output Training Sample Feature Class</para>
		/// <para>The output training sample feature class in the format that can be used in training tools, including shapefiles. The output feature class can be either a polygon feature class or a point feature class.</para>
		/// </param>
		public GenerateTrainingSamplesFromSeedPoints(object InClassData, object InSeedPoints, object OutTrainingFeatureClass)
		{
			this.InClassData = InClassData;
			this.InSeedPoints = InSeedPoints;
			this.OutTrainingFeatureClass = OutTrainingFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Training Samples From Seed Points</para>
		/// </summary>
		public override string DisplayName => "Generate Training Samples From Seed Points";

		/// <summary>
		/// <para>Tool Name : GenerateTrainingSamplesFromSeedPoints</para>
		/// </summary>
		public override string ToolName => "GenerateTrainingSamplesFromSeedPoints";

		/// <summary>
		/// <para>Tool Excute Name : sa.GenerateTrainingSamplesFromSeedPoints</para>
		/// </summary>
		public override string ExcuteName => "sa.GenerateTrainingSamplesFromSeedPoints";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InClassData, InSeedPoints, OutTrainingFeatureClass, MinSampleArea!, MaxSampleRadius! };

		/// <summary>
		/// <para>Input Raster or Feature Class Data</para>
		/// <para>The data source that labels the training samples.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InClassData { get; set; }

		/// <summary>
		/// <para>Input Seed Points</para>
		/// <para>A point shapefile or feature class to provide the centers of training sample polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSeedPoints { get; set; }

		/// <summary>
		/// <para>Output Training Sample Feature Class</para>
		/// <para>The output training sample feature class in the format that can be used in training tools, including shapefiles. The output feature class can be either a polygon feature class or a point feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutTrainingFeatureClass { get; set; }

		/// <summary>
		/// <para>Min Sample Area</para>
		/// <para>The minimum area needed for each training sample, in square meters. The minimum value must be greater than or equal to 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MinSampleArea { get; set; } = "30";

		/// <summary>
		/// <para>Max Sample Radius</para>
		/// <para>The longest distance (in meters) from any point within the training sample to its center seed point. If set to 0, the output training sample will be points instead of polygons. The minimum value must be greater than or equal to 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaxSampleRadius { get; set; } = "50";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateTrainingSamplesFromSeedPoints SetEnviroment(object? extent = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
