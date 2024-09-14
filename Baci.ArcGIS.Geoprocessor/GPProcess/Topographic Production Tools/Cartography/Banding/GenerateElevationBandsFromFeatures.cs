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
	/// <para>Generate Elevation Bands From Features</para>
	/// <para>Generate Elevation Bands From Features</para>
	/// <para>Generates band features that represent elevation levels on a map product. The tool can be run with set values from standardized product specifications or with custom-defined values.</para>
	/// </summary>
	public class GenerateElevationBandsFromFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="ContourFeatures">
		/// <para>Contour Features</para>
		/// <para>The polyline feature layer that contains the contours. The information for the output bands will be derived from these features.</para>
		/// </param>
		/// <param name="ElevationField">
		/// <para>Elevation Field</para>
		/// <para>The field in the Contour Features feature layer from which the elevation values will be derived.</para>
		/// </param>
		/// <param name="AreaOfInterest">
		/// <para>Area of Interest</para>
		/// <para>The area of interest (AOI) for the area where the elevation bands will be created. This feature is typically stored in an index feature class that contains the extents for standard map sheets.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will contain the banding features.</para>
		/// </param>
		public GenerateElevationBandsFromFeatures(object ContourFeatures, object ElevationField, object AreaOfInterest, object OutFeatureClass)
		{
			this.ContourFeatures = ContourFeatures;
			this.ElevationField = ElevationField;
			this.AreaOfInterest = AreaOfInterest;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Elevation Bands From Features</para>
		/// </summary>
		public override string DisplayName() => "Generate Elevation Bands From Features";

		/// <summary>
		/// <para>Tool Name : GenerateElevationBandsFromFeatures</para>
		/// </summary>
		public override string ToolName() => "GenerateElevationBandsFromFeatures";

		/// <summary>
		/// <para>Tool Excute Name : topographic.GenerateElevationBandsFromFeatures</para>
		/// </summary>
		public override string ExcuteName() => "topographic.GenerateElevationBandsFromFeatures";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { ContourFeatures, ElevationField, AreaOfInterest, OutFeatureClass, ExclusionFeatures!, Product!, BandInterval!, BandValues! };

		/// <summary>
		/// <para>Contour Features</para>
		/// <para>The polyline feature layer that contains the contours. The information for the output bands will be derived from these features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object ContourFeatures { get; set; }

		/// <summary>
		/// <para>Elevation Field</para>
		/// <para>The field in the Contour Features feature layer from which the elevation values will be derived.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double", "Long", "Short")]
		public object ElevationField { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>The area of interest (AOI) for the area where the elevation bands will be created. This feature is typically stored in an index feature class that contains the extents for standard map sheets.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will contain the banding features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Exclusion Features</para>
		/// <para>The feature layers that define areas where bands will not be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object? ExclusionFeatures { get; set; }

		/// <summary>
		/// <para>Product</para>
		/// <para>Specifies the supported map products.</para>
		/// <para>JOG-A—The Joint Operations Graphic-Air product</para>
		/// <para>ONC—The Operational Navigation Chart product</para>
		/// <para>TPC—The Tactical Pilotage Chart product</para>
		/// <para>Custom—A custom product</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Product { get; set; }

		/// <summary>
		/// <para>Band Interval</para>
		/// <para>The interval specified when the band interval type is regular.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? BandInterval { get; set; }

		/// <summary>
		/// <para>Band Values</para>
		/// <para>The low and high values in the bands to be created. These values will be populated automatically from an .xml file if a particular product is specified for the Product parameter; however, these values must be provided manually if the custom option is specified for the Product parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? BandValues { get; set; }

	}
}
