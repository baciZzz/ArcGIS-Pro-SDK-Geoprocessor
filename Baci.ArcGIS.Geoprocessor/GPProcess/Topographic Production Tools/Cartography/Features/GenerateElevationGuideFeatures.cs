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
	/// <para>Generate Elevation Guide Features</para>
	/// <para>Creates data required for an elevation guide diagram </para>
	/// <para>surround element as required by various supported map product specifications.  This tool uses existing </para>
	/// <para>banding </para>
	/// <para>and thinning parameters to generate output elevation band features, spot height features, and </para>
	/// <para>hydrology features.</para>
	/// </summary>
	public class GenerateElevationGuideFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureDataset">
		/// <para>Input Feature Dataset</para>
		/// <para>An existing feature dataset that will contain the EGB feature classes. Data created for the elevation guide box is maintained in these feature classes in this feature dataset.</para>
		/// </param>
		/// <param name="AreaOfInterest">
		/// <para>Area Of Interest</para>
		/// <para>A feature layer with a single selected feature that defines a processing extent for banding operations and a clipping extent for spot heights, input hydro areas, and lines.</para>
		/// </param>
		/// <param name="InRasters">
		/// <para>Input Rasters</para>
		/// <para>One or more rasters used to create elevation bands and supply elevation values to the created features.</para>
		/// </param>
		public GenerateElevationGuideFeatures(object InFeatureDataset, object AreaOfInterest, object InRasters)
		{
			this.InFeatureDataset = InFeatureDataset;
			this.AreaOfInterest = AreaOfInterest;
			this.InRasters = InRasters;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Elevation Guide Features</para>
		/// </summary>
		public override string DisplayName => "Generate Elevation Guide Features";

		/// <summary>
		/// <para>Tool Name : GenerateElevationGuideFeatures</para>
		/// </summary>
		public override string ToolName => "GenerateElevationGuideFeatures";

		/// <summary>
		/// <para>Tool Excute Name : topographic.GenerateElevationGuideFeatures</para>
		/// </summary>
		public override string ExcuteName => "topographic.GenerateElevationGuideFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatureDataset, AreaOfInterest, InRasters, HydroExclusionFeatures!, SpotHeightFeatures!, HydroLineFeatures!, HydroAreaFeatures!, ContourInterval!, BandsMinarea!, SmoothTolerance!, NumberOfBands!, HeightField!, SearchDistance!, HydrolineMinlength!, HydrolineMinspacing!, HydroareaMinlength!, HydroareaMinwidth!, OutFeatureDataset! };

		/// <summary>
		/// <para>Input Feature Dataset</para>
		/// <para>An existing feature dataset that will contain the EGB feature classes. Data created for the elevation guide box is maintained in these feature classes in this feature dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object InFeatureDataset { get; set; }

		/// <summary>
		/// <para>Area Of Interest</para>
		/// <para>A feature layer with a single selected feature that defines a processing extent for banding operations and a clipping extent for spot heights, input hydro areas, and lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPFeatureClassDomain()]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Input Rasters</para>
		/// <para>One or more rasters used to create elevation bands and supply elevation values to the created features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InRasters { get; set; }

		/// <summary>
		/// <para>Hydro Exclusion Features</para>
		/// <para>A feature layer that defines a large water body area to exclude from the elevation band area computation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[Category("Banding Settings (optional)")]
		public object? HydroExclusionFeatures { get; set; }

		/// <summary>
		/// <para>Spot Height Features</para>
		/// <para>A feature layer or class that contains spot heights.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[Category("Spot Settings (optional)")]
		public object? SpotHeightFeatures { get; set; }

		/// <summary>
		/// <para>Hydro Line Features</para>
		/// <para>Hydrology line features used to generate the output of a thinned hydrology dataset. Only the output features are generalized through this thinning process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[Category("Hydro Settings (optional)")]
		public object? HydroLineFeatures { get; set; }

		/// <summary>
		/// <para>Hydro Area Features</para>
		/// <para>Hydrology area features used to generate the thinned hydrology dataset. Only the output features are generalized through this thinning process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[Category("Hydro Settings (optional)")]
		public object? HydroAreaFeatures { get; set; }

		/// <summary>
		/// <para>Contour Interval</para>
		/// <para>Specifies the contour interval that will be used to determine the closest available contour when calculating the elevation band area. Elevation bands are created with their limits aligned to the specified contour interval, except low and high values, which will represent their actual calculated values.</para>
		/// <para>10—A contour interval of 10 will be used.</para>
		/// <para>20—A contour interval of 20 will be used. This is the default.</para>
		/// <para>40—A contour interval of 40 will be used.</para>
		/// <para>80—A contour interval of 80 will be used.</para>
		/// <para><see cref="ContourIntervalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		[Category("Banding Settings (optional)")]
		public object? ContourInterval { get; set; } = "20";

		/// <summary>
		/// <para>Minimum Feature Area</para>
		/// <para>The minimum area for output polygons. Features smaller than this value will be removed. The default is 0.00016 square decimal degrees.If you are creating an output dataset with a projected coordinate system, ensure that this value reflects the square units of that coordinate system—for example, square meters for a UTM dataset. Otherwise, the default value may result in an empty output dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Banding Settings (optional)")]
		public object? BandsMinarea { get; set; } = "0.00016";

		/// <summary>
		/// <para>Smoothing Tolerance</para>
		/// <para>The tolerance used by the smoothing algorithm. The larger the value, the more generalized the output band features. The default is 0.002 decimal degrees.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SmoothTolerance { get; set; } = "0.002 DecimalDegrees";

		/// <summary>
		/// <para>Number Of Elevation Bands</para>
		/// <para>Specifies the number of elevation bands that will be generated.</para>
		/// <para>1 —One elevation band will be generated.</para>
		/// <para>2—Two elevation bands will be generated.</para>
		/// <para>3—Three elevation bands will be generated.</para>
		/// <para>4—Four elevation bands will be generated.</para>
		/// <para><see cref="NumberOfBandsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		[Category("Banding Settings (optional)")]
		public object? NumberOfBands { get; set; }

		/// <summary>
		/// <para>Height Field</para>
		/// <para>The field that identifies the elevation values of the spot height features. These values will be evaluated during the thinning process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[Category("Spot Settings (optional)")]
		public object? HeightField { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The minimum distance between spot heights. The default is 0 meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Spot Settings (optional)")]
		public object? SearchDistance { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Minimum Hydro Line Length</para>
		/// <para>The minimum length used to eliminate hydrographic features. The tool will thin hydro features that have a length less than this value. This value is used when generalizing input hydro lines and areas.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Hydro Settings (optional)")]
		public object? HydrolineMinlength { get; set; }

		/// <summary>
		/// <para>Minimum Hydro Line Spacing</para>
		/// <para>The shortest distance between a hydrographic segments that will display at the output scale. If the spacing between two parallel trending features is smaller than this value, one of the features will be hidden. This parameter defines a sense of the density of the resulting thinned hydrography. It should correspond to the distance between two parallel trending features that is visually significant to include at the final scale. When the density of features is too high (that is, the features are too closely spaced), at least one feature will be hidden. This can result in important features or features longer than the Minimum Hydro Line Length value being hidden.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Hydro Settings (optional)")]
		public object? HydrolineMinspacing { get; set; }

		/// <summary>
		/// <para>Minimum Hydro Area Length</para>
		/// <para>The length used to split and classify hydrographic polygons as short or long. Polygons will be split at any location where the edge-to-edge distance is equal to the Minimum Hydro Area Length value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Hydro Settings (optional)")]
		public object? HydroareaMinlength { get; set; }

		/// <summary>
		/// <para>Minimum Hydro Area Width</para>
		/// <para>The width used to split and classify hydrographic polygons as narrow or wide. Polygons will be split at any location where the edge-to-edge distance is equal to the Minimum Hydro Area Width value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Hydro Settings (optional)")]
		public object? HydroareaMinwidth { get; set; }

		/// <summary>
		/// <para>Modified Feature Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureDataset()]
		public object? OutFeatureDataset { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Contour Interval</para>
		/// </summary>
		public enum ContourIntervalEnum 
		{
			/// <summary>
			/// <para>10—A contour interval of 10 will be used.</para>
			/// </summary>
			[GPValue("10")]
			[Description("10")]
			_10,

			/// <summary>
			/// <para>20—A contour interval of 20 will be used. This is the default.</para>
			/// </summary>
			[GPValue("20")]
			[Description("20")]
			_20,

			/// <summary>
			/// <para>40—A contour interval of 40 will be used.</para>
			/// </summary>
			[GPValue("40")]
			[Description("40")]
			_40,

			/// <summary>
			/// <para>80—A contour interval of 80 will be used.</para>
			/// </summary>
			[GPValue("80")]
			[Description("80")]
			_80,

		}

		/// <summary>
		/// <para>Number Of Elevation Bands</para>
		/// </summary>
		public enum NumberOfBandsEnum 
		{
			/// <summary>
			/// <para>1 —One elevation band will be generated.</para>
			/// </summary>
			[GPValue("1")]
			[Description("1")]
			_1,

			/// <summary>
			/// <para>2—Two elevation bands will be generated.</para>
			/// </summary>
			[GPValue("2")]
			[Description("2")]
			_2,

			/// <summary>
			/// <para>3—Three elevation bands will be generated.</para>
			/// </summary>
			[GPValue("3")]
			[Description("3")]
			_3,

			/// <summary>
			/// <para>4—Four elevation bands will be generated.</para>
			/// </summary>
			[GPValue("4")]
			[Description("4")]
			_4,

		}

#endregion
	}
}
