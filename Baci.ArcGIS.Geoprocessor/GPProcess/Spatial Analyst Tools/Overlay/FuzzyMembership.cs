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
	/// <para>Fuzzy Membership</para>
	/// <para>Transforms  the input raster   into a 0 to 1 scale, indicating the strength of a membership in a set, based on a specified fuzzification algorithm.</para>
	/// </summary>
	public class FuzzyMembership : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster whose values will be scaled from 0 to 1.</para>
		/// <para>It can be an integer or a floating-point raster.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output will be a floating-point raster with values ranging from 0 to 1.</para>
		/// </param>
		public FuzzyMembership(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Fuzzy Membership</para>
		/// </summary>
		public override string DisplayName => "Fuzzy Membership";

		/// <summary>
		/// <para>Tool Name : FuzzyMembership</para>
		/// </summary>
		public override string ToolName => "FuzzyMembership";

		/// <summary>
		/// <para>Tool Excute Name : sa.FuzzyMembership</para>
		/// </summary>
		public override string ExcuteName => "sa.FuzzyMembership";

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
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRaster, OutRaster, FuzzyFunction, Hedge };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input raster whose values will be scaled from 0 to 1.</para>
		/// <para>It can be an integer or a floating-point raster.</para>
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
		/// <para>The output will be a floating-point raster with values ranging from 0 to 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Membership type</para>
		/// <para>Specifies the algorithm used in fuzzification of the input raster.</para>
		/// <para>Certain settings for Membership type employ a Spread parameter to determine how rapidly the fuzzy membership values decrease from 1 to 0. The default values for the spread are detailed in the table below.</para>
		/// <para>Gaussian—Assigns a membership value of 1 at the midpoint.The membership decreases to 0 for values that deviate from the midpoint according to a normal curve. Gaussian is similar to the Near function but has a more narrow spread.</para>
		/// <para>Midpoint — Default is the midpoint of the range of values of the input raster.</para>
		/// <para>Spread — Default is 0.1. Typically, the values vary between [0.01–1].</para>
		/// <para>Small—Used to indicate that small values of the input raster have high membership in the fuzzy set.Assigns a membership value of 0.5 at the midpoint.</para>
		/// <para>Midpoint — Default is the midpoint of the range of values of the input raster.</para>
		/// <para>Spread — Default is 5.</para>
		/// <para>Large—Used to indicate that large values of the input raster have high membership in the fuzzy set.Assigns a membership value of 0.5 at the midpoint.</para>
		/// <para>Midpoint — Default is the midpoint of the range of values of the input raster.</para>
		/// <para>Spread — Default is 5.</para>
		/// <para>Near—Calculates memberships for values near some intermediate value.Assigns a membership value of 1 at the midpoint. The membership decreases to 0 for values that deviate from the midpoint.</para>
		/// <para>Midpoint — Default is the midpoint of the range of values of the input raster.</para>
		/// <para>Spread — Default is 0.1. Typically, the values vary within the range of [0.001–1].</para>
		/// <para>MSLarge—Calculates membership based on the mean and standard deviation of the input data where large values have high membership. The result can be similar to the Large function, depending on how the multipliers of the mean and standard deviation are defined.</para>
		/// <para>Mean multiplier — Default is 1.</para>
		/// <para>Standard deviation multiplier — Default is 2.</para>
		/// <para>MSSmall—Calculates membership based on the mean and standard deviation of the input data where small values have high membership. This is the default membership type. The result can be similar to the Small function, depending on how the multipliers of the mean and standard deviation are defined.</para>
		/// <para>Mean multiplier — Default is 1.</para>
		/// <para>Standard deviation multiplier — Default is 2.</para>
		/// <para>Linear—Calculates membership based on the linear transformation of the input raster. Assigns a membership value of 0 at the minimum and a membership of 1 at the maximum.</para>
		/// <para>Minimum — Default is 1.</para>
		/// <para>Maximum — Default is 2.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAFuzzyFunction()]
		public object FuzzyFunction { get; set; } = "MSSMALL 1 1";

		/// <summary>
		/// <para>Hedge</para>
		/// <para>Defining a hedge increases or decreases the fuzzy membership values which modify the meaning of a fuzzy set. Hedges are useful to help in controlling the criteria or important attributes.</para>
		/// <para>None—No hedge is applied. This is the default.</para>
		/// <para>Somewhat—Known as dilation, defined as the square root of the fuzzy membership function. This hedge increases the fuzzy membership functions.</para>
		/// <para>Very—Also known as concentration, defined as the fuzzy membership function squared. This hedge decreases the fuzzy membership functions.</para>
		/// <para><see cref="HedgeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Hedge { get; set; } = "NONE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FuzzyMembership SetEnviroment(int? autoCommit = null , object cellSize = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Hedge</para>
		/// </summary>
		public enum HedgeEnum 
		{
			/// <summary>
			/// <para>None—No hedge is applied. This is the default.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>Somewhat—Known as dilation, defined as the square root of the fuzzy membership function. This hedge increases the fuzzy membership functions.</para>
			/// </summary>
			[GPValue("SOMEWHAT")]
			[Description("Somewhat")]
			Somewhat,

			/// <summary>
			/// <para>Very—Also known as concentration, defined as the fuzzy membership function squared. This hedge decreases the fuzzy membership functions.</para>
			/// </summary>
			[GPValue("VERY")]
			[Description("Very")]
			Very,

		}

#endregion
	}
}
