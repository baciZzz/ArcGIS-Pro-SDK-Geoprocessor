using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ReadyToUseTools
{
	/// <summary>
	/// <para>Viewshed</para>
	/// <para>Returns polygons of visible areas for a given set of input observation points.</para>
	/// </summary>
	public class Viewshed : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputpoints">
		/// <para>Input Point Features</para>
		/// <para>The point features to use as the observer locations.</para>
		/// </param>
		public Viewshed(object Inputpoints)
		{
			this.Inputpoints = Inputpoints;
		}

		/// <summary>
		/// <para>Tool Display Name : Viewshed</para>
		/// </summary>
		public override string DisplayName => "Viewshed";

		/// <summary>
		/// <para>Tool Name : Viewshed</para>
		/// </summary>
		public override string ToolName => "Viewshed";

		/// <summary>
		/// <para>Tool Excute Name : agolservices.Viewshed</para>
		/// </summary>
		public override string ExcuteName => "agolservices.Viewshed";

		/// <summary>
		/// <para>Toolbox Display Name : Ready To Use Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Ready To Use Tools";

		/// <summary>
		/// <para>Toolbox Alise : agolservices</para>
		/// </summary>
		public override string ToolboxAlise => "agolservices";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Inputpoints, Maximumdistance!, Maximumdistanceunits!, Demresolution!, Observerheight!, Observerheightunits!, Surfaceoffset!, Surfaceoffsetunits!, Generalizeviewshedpolygons!, Outputviewshed! };

		/// <summary>
		/// <para>Input Point Features</para>
		/// <para>The point features to use as the observer locations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Inputpoints { get; set; }

		/// <summary>
		/// <para>Maximum Distance</para>
		/// <para>The maximum distance to calculate the viewshed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Maximumdistance { get; set; }

		/// <summary>
		/// <para>Maximum Distance Units</para>
		/// <para>Specifies the units for the Maximum Distance parameter.</para>
		/// <para>Meters—The units are meters. This is the default.</para>
		/// <para>Kilometers—The units are kilometers.</para>
		/// <para>Feet—The units are feet.</para>
		/// <para>Yards—The units are yards.</para>
		/// <para>Miles—The units are miles.</para>
		/// <para><see cref="MaximumdistanceunitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Maximumdistanceunits { get; set; } = "Meters";

		/// <summary>
		/// <para>DEM Resolution</para>
		/// <para>Specifies the approximate spatial resolution (cell size) of the source elevation data used for the calculation.</para>
		/// <para>The resolution keyword is an approximation of the spatial resolution of the digital elevation model. Many elevation sources are distributed in units of arc seconds; the keyword is an approximation in meters for easier understanding.</para>
		/// <para>Finest—The finest units available for the extent are used.</para>
		/// <para>10 meters—The elevation source resolution is 1/3 arc second or approximately 10 meters.</para>
		/// <para>24 meters—The elevation source is the Airbus WorldDEM4Ortho dataset at 24 meters resolution.</para>
		/// <para>30 meters—The elevation source resolution is 1 arc second or approximately 30 meters.</para>
		/// <para>90 meters—The elevation source resolution is 3 arc seconds or approximately 90 meters. This is the default.</para>
		/// <para><see cref="DemresolutionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Demresolution { get; set; }

		/// <summary>
		/// <para>Observer Height</para>
		/// <para>The height above the surface of the observer. The default value of 1.75 meters is an average height of a person. If you are looking from an elevated location such as an observation tower or a tall building, use that height instead.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Observerheight { get; set; } = "1.75";

		/// <summary>
		/// <para>Observer Height Units</para>
		/// <para>Specifies the units for the Observer Height parameter.</para>
		/// <para>Meters—The units are meters. This is the default.</para>
		/// <para>Kilometers—The units are kilometers.</para>
		/// <para>Feet—The units are feet.</para>
		/// <para>Yards—The units are yards.</para>
		/// <para>Miles—The units are miles.</para>
		/// <para><see cref="ObserverheightunitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Observerheightunits { get; set; } = "Meters";

		/// <summary>
		/// <para>Surface Offset</para>
		/// <para>The height above the surface of the object you are viewing. The default value is 0. If you are viewing buildings or wind turbines, use their height.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Surfaceoffset { get; set; } = "0";

		/// <summary>
		/// <para>Surface Offset Units</para>
		/// <para>Specifies the units for the Surface Offset parameter.</para>
		/// <para>Meters—The units are meters. This is the default.</para>
		/// <para>Kilometers—The units are kilometers.</para>
		/// <para>Feet—The units are feet.</para>
		/// <para>Yards—The units are yards.</para>
		/// <para>Miles—The units are miles.</para>
		/// <para><see cref="SurfaceoffsetunitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Surfaceoffsetunits { get; set; } = "Meters";

		/// <summary>
		/// <para>Generalize Viewshed Polygons</para>
		/// <para>Specifies whether the viewshed polygons will be generalized.</para>
		/// <para>The viewshed calculation is based on a raster elevation model that creates a result with stair-stepped edges. To create a more pleasing appearance and improve performance, the default behavior generalizes the polygons. This generalization will not change the accuracy of the result for any location more than one half of the DEM resolution.</para>
		/// <para>Checked—The viewshed polygons will be generalized. This is the default.</para>
		/// <para>Unchecked—The viewshed polygons will not be generalized.</para>
		/// <para><see cref="GeneralizeviewshedpolygonsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Generalizeviewshedpolygons { get; set; } = "true";

		/// <summary>
		/// <para>Output Viewshed</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? Outputviewshed { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Maximum Distance Units</para>
		/// </summary>
		public enum MaximumdistanceunitsEnum 
		{
			/// <summary>
			/// <para>Meters—The units are meters. This is the default.</para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Kilometers—The units are kilometers.</para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Feet—The units are feet.</para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>Yards—The units are yards.</para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para>Miles—The units are miles.</para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>DEM Resolution</para>
		/// </summary>
		public enum DemresolutionEnum 
		{
			/// <summary>
			/// <para>Finest—The finest units available for the extent are used.</para>
			/// </summary>
			[GPValue("FINEST")]
			[Description("Finest")]
			Finest,

			/// <summary>
			/// <para>10 meters—The elevation source resolution is 1/3 arc second or approximately 10 meters.</para>
			/// </summary>
			[GPValue("10m")]
			[Description("10 meters")]
			_10_meters,

			/// <summary>
			/// <para>24 meters—The elevation source is the Airbus WorldDEM4Ortho dataset at 24 meters resolution.</para>
			/// </summary>
			[GPValue("24m")]
			[Description("24 meters")]
			_24_meters,

			/// <summary>
			/// <para>30 meters—The elevation source resolution is 1 arc second or approximately 30 meters.</para>
			/// </summary>
			[GPValue("30m")]
			[Description("30 meters")]
			_30_meters,

			/// <summary>
			/// <para>90 meters—The elevation source resolution is 3 arc seconds or approximately 90 meters. This is the default.</para>
			/// </summary>
			[GPValue("90m")]
			[Description("90 meters")]
			_90_meters,

		}

		/// <summary>
		/// <para>Observer Height Units</para>
		/// </summary>
		public enum ObserverheightunitsEnum 
		{
			/// <summary>
			/// <para>Meters—The units are meters. This is the default.</para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Kilometers—The units are kilometers.</para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Feet—The units are feet.</para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>Yards—The units are yards.</para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para>Miles—The units are miles.</para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>Surface Offset Units</para>
		/// </summary>
		public enum SurfaceoffsetunitsEnum 
		{
			/// <summary>
			/// <para>Meters—The units are meters. This is the default.</para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Kilometers—The units are kilometers.</para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Feet—The units are feet.</para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>Yards—The units are yards.</para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para>Miles—The units are miles.</para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>Generalize Viewshed Polygons</para>
		/// </summary>
		public enum GeneralizeviewshedpolygonsEnum 
		{
			/// <summary>
			/// <para>Checked—The viewshed polygons will be generalized. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERALIZE")]
			GENERALIZE,

			/// <summary>
			/// <para>Unchecked—The viewshed polygons will not be generalized.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_GENERALIZE")]
			NO_GENERALIZE,

		}

#endregion
	}
}
