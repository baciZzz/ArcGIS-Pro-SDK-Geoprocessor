using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CartographyTools
{
	/// <summary>
	/// <para>Strip Map Index Features</para>
	/// <para>Creates a series of rectangular polygons, or index features, that follow a single linear feature or a group of linear features. These index features can be used with spatial map series to define pages in a strip map or a set of maps that follow a linear feature. The resulting index features contain attributes that can be used to rotate and orient the map on the page and determine which index features, or pages, are next to the current page (to the left and right or to the top and bottom).</para>
	/// </summary>
	public class StripMapIndexFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Line Features</para>
		/// <para>The input polyline features defining the path of the strip map index features.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class of polygon index features.</para>
		/// </param>
		public StripMapIndexFeatures(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Strip Map Index Features</para>
		/// </summary>
		public override string DisplayName => "Strip Map Index Features";

		/// <summary>
		/// <para>Tool Name : StripMapIndexFeatures</para>
		/// </summary>
		public override string ToolName => "StripMapIndexFeatures";

		/// <summary>
		/// <para>Tool Excute Name : cartography.StripMapIndexFeatures</para>
		/// </summary>
		public override string ExcuteName => "cartography.StripMapIndexFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClass, UsePageUnit!, Scale!, LengthAlongLine!, LengthPerpendicularToLine!, PageOrientation!, OverlapPercentage!, StartingPageNumber!, DirectionType! };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>The input polyline features defining the path of the strip map index features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class of polygon index features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Use Page Unit and Scale</para>
		/// <para>Specifies whether index feature size input is in page units.</para>
		/// <para>Checked—Index polygon height and width are calculated in page units.</para>
		/// <para>Unchecked—Index polygon height and width are calculated in map units. This is the default.</para>
		/// <para><see cref="UsePageUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? UsePageUnit { get; set; } = "false";

		/// <summary>
		/// <para>Map Scale</para>
		/// <para>Map scale must be specified if index feature lengths (along the line and perpendicular to the line) are to be calculated in page units. If you're using ArcGIS Pro, the default value will be the scale of the active data frame; otherwise, the default will be 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object? Scale { get; set; }

		/// <summary>
		/// <para>Length Along the Line</para>
		/// <para>The length of the polygon index feature along the input line feature specified in either map or page units. The default value is determined by the spatial reference of the input line feature or features. This value will be 1/100 of the input feature class extent along the x axis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? LengthAlongLine { get; set; } = "2 DecimalDegrees";

		/// <summary>
		/// <para>Length Perpendicular to the Line</para>
		/// <para>The length of the polygon index feature perpendicular to the input line feature specified in either map or page units. The default value is determined by the spatial reference of the input line feature or features. This value will be one-half the number used for the length along the line.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? LengthPerpendicularToLine { get; set; } = "1 DecimalDegrees";

		/// <summary>
		/// <para>Page Orientation</para>
		/// <para>Specifies the orientation of the input line features on the layout page.</para>
		/// <para>Vertical—The direction of the strip map series on the page is top to bottom.</para>
		/// <para>Horizontal—The direction of the strip map series on the page is left to right. This is the default.</para>
		/// <para><see cref="PageOrientationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PageOrientation { get; set; } = "HORIZONTAL";

		/// <summary>
		/// <para>Percentage of Overlap</para>
		/// <para>The approximate percentage of geographic overlap between an individual map page and its adjoining pages in the series. The default is 10.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? OverlapPercentage { get; set; } = "10";

		/// <summary>
		/// <para>Starting Page Number</para>
		/// <para>The page number of the starting page. Each grid index feature is assigned a sequential page number beginning with the specified starting page number. The default is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object? StartingPageNumber { get; set; } = "1";

		/// <summary>
		/// <para>Strip Map Direction</para>
		/// <para>Specifies the initial direction of the strip maps.</para>
		/// <para>West to East and North to South—If the line&apos;s directional trend is West to East, the starting point will be at the westernmost end of the line, or if the line&apos;s direction trend is North to South, the starting point will be at the northernmost end of the line. This is the default.</para>
		/// <para>West to East and South to North—If the line&apos;s directional trend is West to East, the starting point will be at the westernmost end of the line, or if the line&apos;s direction trend is South to North, the starting point will be at the southernmost end of the line.</para>
		/// <para>East to West and North to South—If the line&apos;s directional trend is East to West, the starting point will be at the easternmost end of the line, or if the line&apos;s direction trend is North to South, the starting point will be at the northernmost end of the line.</para>
		/// <para>East to West and South to North—If the line&apos;s directional trend is East to West, the starting point will be at the easternmost end of the line, or if the line&apos;s direction trend is South to North, the starting point will be at the southernmost end of the line.</para>
		/// <para><see cref="DirectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DirectionType { get; set; } = "WE_NS";

		#region InnerClass

		/// <summary>
		/// <para>Use Page Unit and Scale</para>
		/// </summary>
		public enum UsePageUnitEnum 
		{
			/// <summary>
			/// <para>Checked—Index polygon height and width are calculated in page units.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USEPAGEUNIT")]
			USEPAGEUNIT,

			/// <summary>
			/// <para>Unchecked—Index polygon height and width are calculated in map units. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_USEPAGEUNIT")]
			NO_USEPAGEUNIT,

		}

		/// <summary>
		/// <para>Page Orientation</para>
		/// </summary>
		public enum PageOrientationEnum 
		{
			/// <summary>
			/// <para>Horizontal—The direction of the strip map series on the page is left to right. This is the default.</para>
			/// </summary>
			[GPValue("HORIZONTAL")]
			[Description("Horizontal")]
			Horizontal,

			/// <summary>
			/// <para>Vertical—The direction of the strip map series on the page is top to bottom.</para>
			/// </summary>
			[GPValue("VERTICAL")]
			[Description("Vertical")]
			Vertical,

		}

		/// <summary>
		/// <para>Strip Map Direction</para>
		/// </summary>
		public enum DirectionTypeEnum 
		{
			/// <summary>
			/// <para>West to East and North to South—If the line&apos;s directional trend is West to East, the starting point will be at the westernmost end of the line, or if the line&apos;s direction trend is North to South, the starting point will be at the northernmost end of the line. This is the default.</para>
			/// </summary>
			[GPValue("WE_NS")]
			[Description("West to East and North to South")]
			West_to_East_and_North_to_South,

			/// <summary>
			/// <para>West to East and South to North—If the line&apos;s directional trend is West to East, the starting point will be at the westernmost end of the line, or if the line&apos;s direction trend is South to North, the starting point will be at the southernmost end of the line.</para>
			/// </summary>
			[GPValue("WE_SN")]
			[Description("West to East and South to North")]
			West_to_East_and_South_to_North,

			/// <summary>
			/// <para>East to West and North to South—If the line&apos;s directional trend is East to West, the starting point will be at the easternmost end of the line, or if the line&apos;s direction trend is North to South, the starting point will be at the northernmost end of the line.</para>
			/// </summary>
			[GPValue("EW_NS")]
			[Description("East to West and North to South")]
			East_to_West_and_North_to_South,

			/// <summary>
			/// <para>East to West and South to North—If the line&apos;s directional trend is East to West, the starting point will be at the easternmost end of the line, or if the line&apos;s direction trend is South to North, the starting point will be at the southernmost end of the line.</para>
			/// </summary>
			[GPValue("EW_SN")]
			[Description("East to West and South to North")]
			East_to_West_and_South_to_North,

		}

#endregion
	}
}
