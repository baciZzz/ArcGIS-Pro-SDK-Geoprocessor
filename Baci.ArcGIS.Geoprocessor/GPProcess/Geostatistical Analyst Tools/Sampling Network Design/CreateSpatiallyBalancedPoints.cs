using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>Create Spatially Balanced Points</para>
	/// <para>Create Spatially Balanced Points</para>
	/// <para>Generates a set of sample points based on inclusion probabilities, resulting in a spatially balanced sample design. This tool is generally used for designing a monitoring network by suggesting locations to take samples, and a preference for particular locations can be defined using an inclusion probability raster.</para>
	/// </summary>
	public class CreateSpatiallyBalancedPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InProbabilityRaster">
		/// <para>Input inclusion probability raster</para>
		/// <para>This raster defines the inclusion probabilities for each location in the area of interest. The location values range from 0 (low inclusion probability) to 1 (high inclusion probability).</para>
		/// </param>
		/// <param name="NumberOutputPoints">
		/// <para>Number of  output points</para>
		/// <para>Specify how many sample locations to generate.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output point feature class</para>
		/// <para>The output feature class contains the selected sample locations and their inclusion probabilities.</para>
		/// </param>
		public CreateSpatiallyBalancedPoints(object InProbabilityRaster, object NumberOutputPoints, object OutFeatureClass)
		{
			this.InProbabilityRaster = InProbabilityRaster;
			this.NumberOutputPoints = NumberOutputPoints;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Spatially Balanced Points</para>
		/// </summary>
		public override string DisplayName() => "Create Spatially Balanced Points";

		/// <summary>
		/// <para>Tool Name : CreateSpatiallyBalancedPoints</para>
		/// </summary>
		public override string ToolName() => "CreateSpatiallyBalancedPoints";

		/// <summary>
		/// <para>Tool Excute Name : ga.CreateSpatiallyBalancedPoints</para>
		/// </summary>
		public override string ExcuteName() => "ga.CreateSpatiallyBalancedPoints";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise() => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "randomGenerator", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InProbabilityRaster, NumberOutputPoints, OutFeatureClass };

		/// <summary>
		/// <para>Input inclusion probability raster</para>
		/// <para>This raster defines the inclusion probabilities for each location in the area of interest. The location values range from 0 (low inclusion probability) to 1 (high inclusion probability).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InProbabilityRaster { get; set; }

		/// <summary>
		/// <para>Number of  output points</para>
		/// <para>Specify how many sample locations to generate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 2147483647)]
		public object NumberOutputPoints { get; set; }

		/// <summary>
		/// <para>Output point feature class</para>
		/// <para>The output feature class contains the selected sample locations and their inclusion probabilities.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateSpatiallyBalancedPoints SetEnviroment(object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? randomGenerator = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, randomGenerator: randomGenerator, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
