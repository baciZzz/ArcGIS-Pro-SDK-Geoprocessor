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
	/// <para>Rescale by Function</para>
	/// <para>Rescale by Function</para>
	/// <para>Rescales the input raster values by applying a selected transformation function and transforming the resulting values onto a specified continuous evaluation scale.</para>
	/// </summary>
	public class RescaleByFunction : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster to rescale.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output rescaled raster.</para>
		/// <para>The output will be a floating-point raster with values ranging from (or within) the From scale and the To scale evaluation values.</para>
		/// </param>
		public RescaleByFunction(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Rescale by Function</para>
		/// </summary>
		public override string DisplayName() => "Rescale by Function";

		/// <summary>
		/// <para>Tool Name : RescaleByFunction</para>
		/// </summary>
		public override string ToolName() => "RescaleByFunction";

		/// <summary>
		/// <para>Tool Excute Name : sa.RescaleByFunction</para>
		/// </summary>
		public override string ExcuteName() => "sa.RescaleByFunction";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, TransformationFunction!, FromScale!, ToScale! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input raster to rescale.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output rescaled raster.</para>
		/// <para>The output will be a floating-point raster with values ranging from (or within) the From scale and the To scale evaluation values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Transformation function</para>
		/// <para>Specifies the continuous function to transform the values from the input raster.</para>
		/// <para>The transformation functions are used to specify the function to rescale the input data. A general description of each function and the default values for the functions are detailed in the table below.</para>
		/// <para>Exponential—Rescale input values using an exponential function.Use when the preference increases with an increase in the input values and the preference increases more rapidly as the input values become larger.</para>
		/// <para>Input shift—The default is derived from the input raster.</para>
		/// <para>Base factor—The default is derived from the input raster.</para>
		/// <para>Lower threshold—The default is the minimum of the input raster.</para>
		/// <para>Value below threshold—The default is the From scale value.</para>
		/// <para>Upper threshold—The default is the maximum of the input raster.</para>
		/// <para>Value above threshold—The default is the To scale value.</para>
		/// <para>Gaussian—Rescale input values using a Gaussian function.The midpoint of the normal distribution defines the most preferred value and is generally assigned to the To scale. Preference values decrease as the values move from the midpoint until eventually reaching the least preference with the lowest and highest input values generally being assigned to the From scale.</para>
		/// <para>Midpoint—The default is derived from the input raster.</para>
		/// <para>Spread—The default is derived from the input raster.</para>
		/// <para>Lower threshold—The default is the minimum of the input raster.</para>
		/// <para>Value below threshold—The default is the From scale value.</para>
		/// <para>Upper threshold—The default is the maximum of the input raster.</para>
		/// <para>Value above threshold—The default is the To scale value.</para>
		/// <para>Large—Used to indicate that the larger values from the input raster have higher preference.The midpoint identifies the crossover point with input values greater than the midpoint having increasing preference and values below having decreasing preference.</para>
		/// <para>Midpoint—The default is derived from the input raster.</para>
		/// <para>Spread—The default is 5.</para>
		/// <para>Lower threshold—The default is the minimum of the input raster.</para>
		/// <para>Value below threshold—The default is the From scale value.</para>
		/// <para>Upper threshold—The default is the maximum of the input raster.</para>
		/// <para>Value above threshold—The default is the To scale value.</para>
		/// <para>Linear—Rescale the input values using a linear function.When the minimum is less than the maximum the larger values are more preferred.</para>
		/// <para>Minimum—The default is the minimum of the input raster.</para>
		/// <para>Maximum—The default is the maximum of the input raster.</para>
		/// <para>Lower threshold—The default is the minimum of the input raster.</para>
		/// <para>Value below threshold—The default is the From scale value.</para>
		/// <para>Upper threshold—The default is the maximum of the input raster.</para>
		/// <para>Value above threshold—The default is the To scale value.</para>
		/// <para>Logarithm—Rescale input data using a logarithm function.Used when the preference for the lower input values increases rapidly. As the input values increase, the preference tapers off, with a further increase in the input values.</para>
		/// <para>Input shift—The default is derived from the input raster.</para>
		/// <para>Factor—The default is derived from the input raster.</para>
		/// <para>Lower threshold—The default is the minimum of the input raster.</para>
		/// <para>Value below threshold—The default is the From scale value.</para>
		/// <para>Upper threshold—The default is the maximum of the input raster.</para>
		/// <para>Value above threshold—The default is the To scale value.</para>
		/// <para>LogisticDecay—Rescale input data using a logistic decay function.Used when small input values are most preferred. As the values increase, the preferences rapidly decrease, until the preferences taper off at the larger input values.</para>
		/// <para>Minimum—The default is the minimum of the input raster.</para>
		/// <para>Maximum—The default is the maximum of the input raster.</para>
		/// <para>Y intercept percent—The default is 99.0.</para>
		/// <para>Lower threshold—The default is the minimum of the input raster.</para>
		/// <para>Value below threshold—The default is the From scale value.</para>
		/// <para>Upper threshold—The default is the maximum of the input raster.</para>
		/// <para>Value above threshold—The default is the To scale value.</para>
		/// <para>LogisticGrowth—Rescale input data using a logistic growth function.Used when small input values are least preferred. As the values increase, the preferences rapidly increase, until the preferences taper off at the larger input values.</para>
		/// <para>Minimum—The default is the minimum of the input raster.</para>
		/// <para>Maximum—The default is the maximum of the input raster.</para>
		/// <para>Y intercept percent—The default is 1.0.</para>
		/// <para>Lower threshold—The default is the minimum of the input raster.</para>
		/// <para>Value below threshold—The default is the From scale value.</para>
		/// <para>Upper threshold—The default is the maximum of the input raster.</para>
		/// <para>Value above threshold—The default is the To scale value.</para>
		/// <para>MSLarge—Rescale input data based on the mean and standard deviation, where larger values in the input raster have higher preference.The result can be similar to the Large function, depending on how the multipliers of the mean and standard deviation are defined.</para>
		/// <para>Mean multiplier—The default is 1.</para>
		/// <para>Standard deviation multiplier—The default is 1.</para>
		/// <para>Lower threshold—The default is the minimum of the input raster.</para>
		/// <para>Value below threshold—The default is the From scale value.</para>
		/// <para>Upper threshold—The default is the maximum of the input raster.</para>
		/// <para>Value above threshold—The default is the To scale value.</para>
		/// <para>MSSmall—Rescale input data based on the mean and standard deviation, where smaller values in the input raster have higher preference.The result can be similar to the Small function, depending on how the multipliers of the mean and standard deviation are defined.</para>
		/// <para>Mean multiplier—The default is 1.</para>
		/// <para>Standard deviation multiplier—The default is 1.</para>
		/// <para>Lower threshold—The default is the minimum of the input raster.</para>
		/// <para>Value below threshold—The default is the From scale value.</para>
		/// <para>Upper threshold—The default is the maximum of the input raster.</para>
		/// <para>Value above threshold—The default is the To scale value.</para>
		/// <para>Near—Use when the input values very close to the midpoint are preferred.Near is similar to the Gaussian function but decreases at a faster rate.</para>
		/// <para>Midpoint—The default is derived from the input raster.</para>
		/// <para>Spread—The default is derived from the input raster.</para>
		/// <para>Lower threshold—The default is the minimum of the input raster.</para>
		/// <para>Value below threshold—The default is the From scale value.</para>
		/// <para>Upper threshold—The default is the maximum of the input raster.</para>
		/// <para>Value above threshold—The default is the To scale value.</para>
		/// <para>Power—Rescale the input data, applying a power function using a specified exponent.Use when the preference for the input values increases rapidly, with an increase in the input values.</para>
		/// <para>Input shift—The default is derived from the input raster.</para>
		/// <para>Exponent—The default is derived from the input raster.</para>
		/// <para>Lower threshold—The default is the minimum of the input raster.</para>
		/// <para>Value below threshold—The default is the From scale value.</para>
		/// <para>Upper threshold—The default is the maximum of the input raster.</para>
		/// <para>Value above threshold—The default is the To scale value.</para>
		/// <para>Small—Use to indicate that the smaller values from the input raster have higher preference.The midpoint identifies the crossover point, with input values below the midpoint having increasing preference, and values that are greater having decreasing preference.</para>
		/// <para>Midpoint—The default is derived from the input raster.</para>
		/// <para>Spread—The default is 5.</para>
		/// <para>Lower threshold—The default is the minimum of the input raster.</para>
		/// <para>Value below threshold—The default is the From scale value.</para>
		/// <para>Upper threshold—The default is the maximum of the input raster.</para>
		/// <para>Value above threshold—The default is the To scale value.</para>
		/// <para>SymmetricLinear—Rescale input data by mirroring a linear function around the midpoint of the minimum and maximum.Use when a particular input value is the most preferred, with the preferences decreasing linearly as the input values move from the mirrored point.</para>
		/// <para>Minimum—The default is the minimum of the input raster.</para>
		/// <para>Maximum—The default is the maximum of the input raster.</para>
		/// <para>Lower threshold—The default is the minimum of the input raster.</para>
		/// <para>Value below threshold—The default is the From scale value.</para>
		/// <para>Upper threshold—The default is the maximum of the input raster.</para>
		/// <para>Value above threshold—The default is the To scale value.</para>
		/// <para>The default transformation is MS Small.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSATransformationFunction()]
		public object? TransformationFunction { get; set; } = "MSSMALL # # # # # #";

		/// <summary>
		/// <para>From scale</para>
		/// <para>The starting value of the output evaluation scale.</para>
		/// <para>The From scale value cannot be equal to the To scale value. The From scale can be lower or higher than the To scale (for example, from 1 to 10, or from 10 to 1).</para>
		/// <para>The value must be positive and it can be either an integer or double.</para>
		/// <para>The default is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object? FromScale { get; set; } = "1";

		/// <summary>
		/// <para>To scale</para>
		/// <para>The ending value of the output evaluation scale.</para>
		/// <para>The To scale value cannot be equal to the From scale value. The To scale can be lower or higher than the From scale (for example, from 1 to 10, or from 10 to 1).</para>
		/// <para>The value must be positive and it can be either an integer or double.</para>
		/// <para>The default is 10.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object? ToScale { get; set; } = "10";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RescaleByFunction SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
