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
	/// <para>Generate Elevation Bands</para>
	/// <para>Creates an elevation bands feature class from a Digital Elevation Model (DEM).</para>
	/// </summary>
	public class GenerateElevationBands : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The rasters used to create elevation bands.</para>
		/// </param>
		/// <param name="InAoi">
		/// <para>Area of Interest</para>
		/// <para>The layer that defines the processing extent.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class containing the output elevation band features.</para>
		/// </param>
		/// <param name="ContourInterval">
		/// <para>Contour Interval</para>
		/// <para>Determines the closest available contour when calculating the elevation band area. The default is 20.</para>
		/// <para>10—A contour interval of 10.</para>
		/// <para>20—A contour interval of 20.</para>
		/// <para>40—A contour interval of 40.</para>
		/// <para>80—A contour interval of 80.</para>
		/// <para><see cref="ContourIntervalEnum"/></para>
		/// </param>
		/// <param name="MinArea">
		/// <para>Minimum Feature Area</para>
		/// <para>The minimum area for output polygons. Features smaller than this value will be removed. The default is 0.00016 square decimal degrees.If you&apos;re creating an output dataset with a projected coordinate system, this value should reflect the square units of that coordinate system—for example, square meters for a UTM dataset. Otherwise, the default value may result in an empty output dataset.</para>
		/// </param>
		/// <param name="SmoothTolerance">
		/// <para>Smoothing Tolerance</para>
		/// <para>The tolerance used by the smoothing algorithm. The larger the value, the more generalized the output band features. The default is 0.002 decimal degrees.</para>
		/// </param>
		public GenerateElevationBands(object InRaster, object InAoi, object OutFeatureClass, object ContourInterval, object MinArea, object SmoothTolerance)
		{
			this.InRaster = InRaster;
			this.InAoi = InAoi;
			this.OutFeatureClass = OutFeatureClass;
			this.ContourInterval = ContourInterval;
			this.MinArea = MinArea;
			this.SmoothTolerance = SmoothTolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Elevation Bands</para>
		/// </summary>
		public override string DisplayName => "Generate Elevation Bands";

		/// <summary>
		/// <para>Tool Name : GenerateElevationBands</para>
		/// </summary>
		public override string ToolName => "GenerateElevationBands";

		/// <summary>
		/// <para>Tool Excute Name : topographic.GenerateElevationBands</para>
		/// </summary>
		public override string ExcuteName => "topographic.GenerateElevationBands";

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
		public override object[] Parameters => new object[] { InRaster, InAoi, OutFeatureClass, ContourInterval, MinArea, SmoothTolerance, InHydroFeatures!, NumberOfBands! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The rasters used to create elevation bands.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>The layer that defines the processing extent.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPFeatureClassDomain()]
		public object InAoi { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class containing the output elevation band features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Contour Interval</para>
		/// <para>Determines the closest available contour when calculating the elevation band area. The default is 20.</para>
		/// <para>10—A contour interval of 10.</para>
		/// <para>20—A contour interval of 20.</para>
		/// <para>40—A contour interval of 40.</para>
		/// <para>80—A contour interval of 80.</para>
		/// <para><see cref="ContourIntervalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object ContourInterval { get; set; } = "20";

		/// <summary>
		/// <para>Minimum Feature Area</para>
		/// <para>The minimum area for output polygons. Features smaller than this value will be removed. The default is 0.00016 square decimal degrees.If you&apos;re creating an output dataset with a projected coordinate system, this value should reflect the square units of that coordinate system—for example, square meters for a UTM dataset. Otherwise, the default value may result in an empty output dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object MinArea { get; set; } = "0.00016";

		/// <summary>
		/// <para>Smoothing Tolerance</para>
		/// <para>The tolerance used by the smoothing algorithm. The larger the value, the more generalized the output band features. The default is 0.002 decimal degrees.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object SmoothTolerance { get; set; } = "0.002 DecimalDegrees";

		/// <summary>
		/// <para>Hydro Exclusion Features</para>
		/// <para>The bodies of water to exclude when calculating the elevation band area.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object? InHydroFeatures { get; set; }

		/// <summary>
		/// <para>Number of Elevation Bands</para>
		/// <para>The number of elevation bands generated by the tool.</para>
		/// <para>1—One elevation band will be generated.</para>
		/// <para>2—Two elevation bands will be generated.</para>
		/// <para>3—Three elevation bands will be generated.</para>
		/// <para>4—Four elevation bands will be generated.</para>
		/// <para><see cref="NumberOfBandsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object? NumberOfBands { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Contour Interval</para>
		/// </summary>
		public enum ContourIntervalEnum 
		{
			/// <summary>
			/// <para>10—A contour interval of 10.</para>
			/// </summary>
			[GPValue("10")]
			[Description("10")]
			_10,

			/// <summary>
			/// <para>20—A contour interval of 20.</para>
			/// </summary>
			[GPValue("20")]
			[Description("20")]
			_20,

			/// <summary>
			/// <para>40—A contour interval of 40.</para>
			/// </summary>
			[GPValue("40")]
			[Description("40")]
			_40,

			/// <summary>
			/// <para>80—A contour interval of 80.</para>
			/// </summary>
			[GPValue("80")]
			[Description("80")]
			_80,

		}

		/// <summary>
		/// <para>Number of Elevation Bands</para>
		/// </summary>
		public enum NumberOfBandsEnum 
		{
			/// <summary>
			/// <para>1—One elevation band will be generated.</para>
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
