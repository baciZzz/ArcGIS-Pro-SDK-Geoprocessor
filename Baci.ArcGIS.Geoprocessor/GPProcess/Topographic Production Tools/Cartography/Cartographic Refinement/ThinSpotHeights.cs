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
	/// <para>Thin Spot Heights</para>
	/// <para>Thin Spot Heights</para>
	/// <para>Generalizes spot heights for a given area of interest in accordance with product specifications.</para>
	/// </summary>
	public class ThinSpotHeights : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>A point feature layer or feature class representing the spot heights for a given area of interest.</para>
		/// </param>
		/// <param name="AreaOfInterest">
		/// <para>Area of Interest</para>
		/// <para>The selected feature in the area of interest (AOI) that is used to identify input features to process. There should be one and only one selected AOI.</para>
		/// </param>
		/// <param name="ElevationField">
		/// <para>Elevation Field</para>
		/// <para>The elevation field in Input Features to use for the spot height.</para>
		/// </param>
		/// <param name="InvisibilityField">
		/// <para>Invisibility Field</para>
		/// <para>The field where the visibility attribute will be written.</para>
		/// </param>
		public ThinSpotHeights(object InFeatures, object AreaOfInterest, object ElevationField, object InvisibilityField)
		{
			this.InFeatures = InFeatures;
			this.AreaOfInterest = AreaOfInterest;
			this.ElevationField = ElevationField;
			this.InvisibilityField = InvisibilityField;
		}

		/// <summary>
		/// <para>Tool Display Name : Thin Spot Heights</para>
		/// </summary>
		public override string DisplayName() => "Thin Spot Heights";

		/// <summary>
		/// <para>Tool Name : ThinSpotHeights</para>
		/// </summary>
		public override string ToolName() => "ThinSpotHeights";

		/// <summary>
		/// <para>Tool Excute Name : topographic.ThinSpotHeights</para>
		/// </summary>
		public override string ExcuteName() => "topographic.ThinSpotHeights";

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
		public override object[] Parameters() => new object[] { InFeatures, AreaOfInterest, ElevationField, InvisibilityField, HighLowSpots, SearchDistance, MaxSpots, InputContours, ContourCodeField, DepressionCodeValue, UpdatedFeatures };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>A point feature layer or feature class representing the spot heights for a given area of interest.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPLayerDomain()]
		[GeometryType("Point")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>The selected feature in the area of interest (AOI) that is used to identify input features to process. There should be one and only one selected AOI.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Elevation Field</para>
		/// <para>The elevation field in Input Features to use for the spot height.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double", "Long", "Float", "Short")]
		public object ElevationField { get; set; }

		/// <summary>
		/// <para>Invisibility Field</para>
		/// <para>The field where the visibility attribute will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double", "Long", "Float", "Short")]
		public object InvisibilityField { get; set; }

		/// <summary>
		/// <para>High Low Spots Field</para>
		/// <para>The field that will be used to identify the highest and lowest spots.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object HighLowSpots { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The minimum distance between spot heights. For example, if the search distance is 3,000 meters, there will be at least 3,000 meters between a chosen spot height and the next chosen spot height. The default value will be 1,300 meters, as this is the optimal value for 50K sheets.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; } = "1300 Meters";

		/// <summary>
		/// <para>Maximum Number  Of Spots</para>
		/// <para>The number of spot heights will not exceed this number.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaxSpots { get; set; }

		/// <summary>
		/// <para>Input Contours</para>
		/// <para>Input contours used to identify if point features are in depressions or tops.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPLayerDomain()]
		[GeometryType("Polyline")]
		public object InputContours { get; set; }

		/// <summary>
		/// <para>Contour Code Field</para>
		/// <para>The field in the database that contains the domain value for index contour, intermediate contour, depression contour, and depression intermediate contour. It is a string value of the field, such as HQC.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Float", "Short")]
		public object ContourCodeField { get; set; }

		/// <summary>
		/// <para>Depression Code  Value</para>
		/// <para>Used to identify depression code values. A depression refers to an elevation completely surrounded by higher-elevation contour lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object DepressionCodeValue { get; set; }

		/// <summary>
		/// <para>Updated Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object UpdatedFeatures { get; set; }

	}
}
