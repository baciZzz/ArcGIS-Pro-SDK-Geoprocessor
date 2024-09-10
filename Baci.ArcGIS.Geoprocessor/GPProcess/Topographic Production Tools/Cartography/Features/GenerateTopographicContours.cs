using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Generate Topographic Contours</para>
	/// <para>Creates and smooths contours from an input raster.</para>
	/// </summary>
	public class GenerateTopographicContours : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasters">
		/// <para>Input Rasters</para>
		/// <para>The input raster layers used to derive the contour lines.</para>
		/// </param>
		/// <param name="AreaOfInterest">
		/// <para>Area of Interest</para>
		/// <para>A feature layer used to clip the input raster before processing. A buffer is created before clipping the raster, which results in larger output contours that extend beyond the selected AOI. The feature layer must have only one selected feature.</para>
		/// </param>
		/// <param name="ContourFeatures">
		/// <para>Target Contour Features</para>
		/// <para>An existing line feature class or feature layer. Contours will be appended to this feature class.</para>
		/// </param>
		/// <param name="ElevationField">
		/// <para>Contour Elevation Field</para>
		/// <para>The field from the input contours that will store the contour elevation value. This field defaults to ZV2 or ZVH if a field with either of those names exists in the contour feature class.</para>
		/// </param>
		public GenerateTopographicContours(object InRasters, object AreaOfInterest, object ContourFeatures, object ElevationField)
		{
			this.InRasters = InRasters;
			this.AreaOfInterest = AreaOfInterest;
			this.ContourFeatures = ContourFeatures;
			this.ElevationField = ElevationField;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Topographic Contours</para>
		/// </summary>
		public override string DisplayName() => "Generate Topographic Contours";

		/// <summary>
		/// <para>Tool Name : GenerateTopographicContours</para>
		/// </summary>
		public override string ToolName() => "GenerateTopographicContours";

		/// <summary>
		/// <para>Tool Excute Name : topographic.GenerateTopographicContours</para>
		/// </summary>
		public override string ExcuteName() => "topographic.GenerateTopographicContours";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise() => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRasters, AreaOfInterest, ContourFeatures, ElevationField, ContourSubtype, Scale, ResampleRaster, ContourInterval, BaseContour, ZFactor, ZeroContour, CodeField, IndexInterval, IndexCode, IntermediateCode, DepressionCode, DepressionIntermediateCode, RasterSmoothTolerance, MinimumLength, ContourSmoothTolerance, UpdatedContourFeatures };

		/// <summary>
		/// <para>Input Rasters</para>
		/// <para>The input raster layers used to derive the contour lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InRasters { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>A feature layer used to clip the input raster before processing. A buffer is created before clipping the raster, which results in larger output contours that extend beyond the selected AOI. The feature layer must have only one selected feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Target Contour Features</para>
		/// <para>An existing line feature class or feature layer. Contours will be appended to this feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object ContourFeatures { get; set; }

		/// <summary>
		/// <para>Contour Elevation Field</para>
		/// <para>The field from the input contours that will store the contour elevation value. This field defaults to ZV2 or ZVH if a field with either of those names exists in the contour feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Double", "Text")]
		public object ElevationField { get; set; }

		/// <summary>
		/// <para>Contour Subtype</para>
		/// <para>The subtype to which contours will be written if the input contours have subtypes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ContourSubtype { get; set; }

		/// <summary>
		/// <para>Map Scale</para>
		/// <para>Specifies the scale that will be used to optimize contours (the scale of the cartographic product that will be printed). Choosing the scale will set the defaults of other parameters to values that are appropriate for the output scale. The default value is the 1:50,000 cartographic product scale.</para>
		/// <para>1:5,000—The 1:5,000 cartographic product scale will be used.</para>
		/// <para>1:10,000—The 1:10,000 cartographic product scale will be used.</para>
		/// <para>1:12,500—The 1:12,500 cartographic product scale will be used.</para>
		/// <para>1:25,000—The 1:25,000 cartographic product scale will be used.</para>
		/// <para>1:50,000—The 1:50,000 cartographic product scale will be used. This is the default.</para>
		/// <para>1:100,000—The 1:100,000 cartographic product scale will be used.</para>
		/// <para>1:250,000—The 1:250,000 cartographic product scale will be used.</para>
		/// <para>1:500,000—The 1:500,000 cartographic product scale will be used.</para>
		/// <para>1:1,000,000—The 1:1,000,000 cartographic product scale will be used.</para>
		/// <para><see cref="ScaleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Scale { get; set; }

		/// <summary>
		/// <para>Resample Raster</para>
		/// <para>Specifies whether the input raster will be resampled before creating contours.</para>
		/// <para>Checked—The input raster will be resampled before creating contours. This is the default.</para>
		/// <para>Unchecked—The input raster will not be resampled when creating contours.</para>
		/// <para><see cref="ResampleRasterEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ResampleRaster { get; set; } = "true";

		/// <summary>
		/// <para>Contour Interval</para>
		/// <para>The interval, or distance, between contour lines. This can be any positive number. The default is set by the scale value. If this parameter is left blank, the default scale value will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Elevation Values")]
		public object ContourInterval { get; set; }

		/// <summary>
		/// <para>Base Contour</para>
		/// <para>Contours are generated above and below this value to cover the entire value range of the input raster. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Elevation Values")]
		public object BaseContour { get; set; } = "0";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>The unit conversion factor used when generating contours. The default value is 1.</para>
		/// <para>The contour lines are generated based on the z-values in the input raster, which are often measured in units of meters or feet. With the default value of 1, the contours will be in the same units as the z-values of the input raster. To create contours in a unit other than that of the z-values, set an appropriate value for the z-factor. It is not necessary that the ground x,y and surface z-units be consistent for this tool.</para>
		/// <para>For example, if the elevation values in your input raster are in feet, but you want the contours to be generated in meters, set the z-factor to 0.3048 (1 foot = 0.3048 meters).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Elevation Values")]
		public object ZFactor { get; set; }

		/// <summary>
		/// <para>Include Zero Contour</para>
		/// <para>Specifies whether a zero contour will be created. A zero contour represents sea level. Zero contours, when generated along a coastline, may be created inside a water body. Check this parameter if you want contours generated on land areas that are at or below sea level.</para>
		/// <para>Checked—A zero contour will be created.</para>
		/// <para>Unchecked—A zero contour will not be created. This is the default.</para>
		/// <para><see cref="ZeroContourEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Elevation Values")]
		public object ZeroContour { get; set; } = "false";

		/// <summary>
		/// <para>Contour Code Field</para>
		/// <para>The field from the input contour feature class where the appropriate code will be stored. The field defaults to the HQC field if it exists in the input contour feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Double", "Text")]
		[Category("Contour Codes")]
		public object CodeField { get; set; }

		/// <summary>
		/// <para>Contour Index Interval</para>
		/// <para>The interval, or distance, between index contour lines. For example, if the contour interval is 20 meters and you want index contours every 100 meters, specify 100. The default is set by the scale value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Contour Codes")]
		public object IndexInterval { get; set; }

		/// <summary>
		/// <para>Index Code</para>
		/// <para>The code value to be stored in the Contour Code Field (code_field in Python) when an index contour is identified. The default code will be 1 if the HQC field exists in the input contour feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Contour Codes")]
		public object IndexCode { get; set; }

		/// <summary>
		/// <para>Intermediate Code</para>
		/// <para>The code value to be stored in the Contour Code Field (code_field in Python) when an intermediate contour is identified. The default code will be 2 if the HQC field exists in the input contour feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Contour Codes")]
		public object IntermediateCode { get; set; }

		/// <summary>
		/// <para>Depression Code</para>
		/// <para>The code value to be stored in the Contour Code Field (code_field in Python) when a depression contour is identified. The default code will be 5 if the HQC field exists in the input contour feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Contour Codes")]
		public object DepressionCode { get; set; }

		/// <summary>
		/// <para>Depression Intermediate Code</para>
		/// <para>The code value to be stored in the Contour Code Field (code_field in Python) when a depression intermediate contour is identified. The default code will be 61 if the HQC field exists in the input contour feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Contour Codes")]
		public object DepressionIntermediateCode { get; set; }

		/// <summary>
		/// <para>Raster Smooth Tolerance</para>
		/// <para>The amount of smoothing to apply to the input raster before creating the contour lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Contour Refinement")]
		public object RasterSmoothTolerance { get; set; }

		/// <summary>
		/// <para>Contour Minimum Length</para>
		/// <para>The minimum length for an individual contour line. The default value is set by the scale value. If the value is set to 0 or left blank, no contours will be removed from the output contours based on their short length.</para>
		/// <para><see cref="MinimumLengthEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		[Category("Contour Refinement")]
		public object MinimumLength { get; set; }

		/// <summary>
		/// <para>Contour Smooth Tolerance</para>
		/// <para>The amount of smoothing to apply to the contour lines. The larger the value, the more generalized the contours. The default value is set by the scale value. If this parameter is set to 0 or left blank, no smoothing will be applied to the output contours.</para>
		/// <para><see cref="ContourSmoothToleranceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		[Category("Contour Refinement")]
		public object ContourSmoothTolerance { get; set; }

		/// <summary>
		/// <para>Updated Contour Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object UpdatedContourFeatures { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Map Scale</para>
		/// </summary>
		public enum ScaleEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue(" ")]
			[Description(" ")]
			_,

			/// <summary>
			/// <para>1:5,000—The 1:5,000 cartographic product scale will be used.</para>
			/// </summary>
			[GPValue("1:5,000")]
			[Description("1:5,000")]
			_1_5_000,

			/// <summary>
			/// <para>1:10,000—The 1:10,000 cartographic product scale will be used.</para>
			/// </summary>
			[GPValue("1:10,000")]
			[Description("1:10,000")]
			_1_10_000,

			/// <summary>
			/// <para>1:12,500—The 1:12,500 cartographic product scale will be used.</para>
			/// </summary>
			[GPValue("1:12,500")]
			[Description("1:12,500")]
			_1_12_500,

			/// <summary>
			/// <para>1:25,000—The 1:25,000 cartographic product scale will be used.</para>
			/// </summary>
			[GPValue("1:25,000")]
			[Description("1:25,000")]
			_1_25_000,

			/// <summary>
			/// <para>1:50,000—The 1:50,000 cartographic product scale will be used. This is the default.</para>
			/// </summary>
			[GPValue("1:50,000")]
			[Description("1:50,000")]
			_1_50_000,

			/// <summary>
			/// <para>1:100,000—The 1:100,000 cartographic product scale will be used.</para>
			/// </summary>
			[GPValue("1:100,000")]
			[Description("1:100,000")]
			_1_100_000,

			/// <summary>
			/// <para>1:250,000—The 1:250,000 cartographic product scale will be used.</para>
			/// </summary>
			[GPValue("1:250,000")]
			[Description("1:250,000")]
			_1_250_000,

			/// <summary>
			/// <para>1:500,000—The 1:500,000 cartographic product scale will be used.</para>
			/// </summary>
			[GPValue("1:500,000")]
			[Description("1:500,000")]
			_1_500_000,

			/// <summary>
			/// <para>1:1,000,000—The 1:1,000,000 cartographic product scale will be used.</para>
			/// </summary>
			[GPValue("1:1,000,000")]
			[Description("1:1,000,000")]
			_1_1_000_000,

		}

		/// <summary>
		/// <para>Resample Raster</para>
		/// </summary>
		public enum ResampleRasterEnum 
		{
			/// <summary>
			/// <para>Checked—The input raster will be resampled before creating contours. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RESAMPLE_RASTER")]
			RESAMPLE_RASTER,

			/// <summary>
			/// <para>Unchecked—The input raster will not be resampled when creating contours.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_RESAMPLE_RASTER")]
			NO_RESAMPLE_RASTER,

		}

		/// <summary>
		/// <para>Include Zero Contour</para>
		/// </summary>
		public enum ZeroContourEnum 
		{
			/// <summary>
			/// <para>Checked—A zero contour will be created.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ZERO_CONTOUR")]
			ZERO_CONTOUR,

			/// <summary>
			/// <para>Unchecked—A zero contour will not be created. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ZERO_CONTOUR")]
			NO_ZERO_CONTOUR,

		}

		/// <summary>
		/// <para>Contour Minimum Length</para>
		/// </summary>
		public enum MinimumLengthEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("NauticalMiles")]
			NauticalMiles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("DecimalDegrees")]
			[Description("DecimalDegrees")]
			DecimalDegrees,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

		}

		/// <summary>
		/// <para>Contour Smooth Tolerance</para>
		/// </summary>
		public enum ContourSmoothToleranceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("NauticalMiles")]
			NauticalMiles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("DecimalDegrees")]
			[Description("DecimalDegrees")]
			DecimalDegrees,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

		}

#endregion
	}
}
