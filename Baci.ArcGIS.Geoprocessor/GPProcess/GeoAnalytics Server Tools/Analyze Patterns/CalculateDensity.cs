using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsServerTools
{
	/// <summary>
	/// <para>Calculate Density</para>
	/// <para>Calculates a magnitude-per-unit area from point features that fall within a neighborhood around each cell.</para>
	/// </summary>
	public class CalculateDensity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input layer</para>
		/// <para>The points that will be used to calculate the density.</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </param>
		/// <param name="BinType">
		/// <para>Bin Type</para>
		/// <para>Specifies the bin shape that will be used in the analysis.</para>
		/// <para>Square—The bin shape will be square. This is the default.</para>
		/// <para>Hexagon—The bin shape will be hexagonal.</para>
		/// <para><see cref="BinTypeEnum"/></para>
		/// </param>
		/// <param name="BinSize">
		/// <para>Bin Size</para>
		/// <para>The size of the bins used to aggregate input features. When generating bins for squares, the number and units specified determine the height and length of the square. For hexagons, the number and units specified determine the distance between parallel sides.</para>
		/// <para><see cref="BinSizeEnum"/></para>
		/// </param>
		/// <param name="Weight">
		/// <para>Weight</para>
		/// <para>Specifies the weighting to be applied to the density function.</para>
		/// <para>Uniform—A magnitude-per-area calculation in which each bin is equally weighted. This is the default.</para>
		/// <para>Kernel—A magnitude-per-area calculation with a smoothing algorithm applied (kernel) that weights bins closer to the points more heavily.</para>
		/// <para><see cref="WeightEnum"/></para>
		/// </param>
		/// <param name="NeighborhoodSize">
		/// <para>Neighborhood Size</para>
		/// <para>The search radius to be applied to density calculations.</para>
		/// <para><see cref="NeighborhoodSizeEnum"/></para>
		/// </param>
		public CalculateDensity(object InputLayer, object OutputName, object BinType, object BinSize, object Weight, object NeighborhoodSize)
		{
			this.InputLayer = InputLayer;
			this.OutputName = OutputName;
			this.BinType = BinType;
			this.BinSize = BinSize;
			this.Weight = Weight;
			this.NeighborhoodSize = NeighborhoodSize;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Density</para>
		/// </summary>
		public override string DisplayName() => "Calculate Density";

		/// <summary>
		/// <para>Tool Name : CalculateDensity</para>
		/// </summary>
		public override string ToolName() => "CalculateDensity";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.CalculateDensity</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.CalculateDensity";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise() => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, OutputName, BinType, BinSize, Weight, NeighborhoodSize, Fields, AreaUnitScaleFactor, TimeStepInterval, TimeStepRepeat, TimeStepReference, Output, DataStore };

		/// <summary>
		/// <para>Input layer</para>
		/// <para>The points that will be used to calculate the density.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		[PortalType("DataStoreCatalogLayer")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Bin Type</para>
		/// <para>Specifies the bin shape that will be used in the analysis.</para>
		/// <para>Square—The bin shape will be square. This is the default.</para>
		/// <para>Hexagon—The bin shape will be hexagonal.</para>
		/// <para><see cref="BinTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BinType { get; set; } = "SQUARE";

		/// <summary>
		/// <para>Bin Size</para>
		/// <para>The size of the bins used to aggregate input features. When generating bins for squares, the number and units specified determine the height and length of the square. For hexagons, the number and units specified determine the distance between parallel sides.</para>
		/// <para><see cref="BinSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object BinSize { get; set; }

		/// <summary>
		/// <para>Weight</para>
		/// <para>Specifies the weighting to be applied to the density function.</para>
		/// <para>Uniform—A magnitude-per-area calculation in which each bin is equally weighted. This is the default.</para>
		/// <para>Kernel—A magnitude-per-area calculation with a smoothing algorithm applied (kernel) that weights bins closer to the points more heavily.</para>
		/// <para><see cref="WeightEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Weight { get; set; } = "UNIFORM";

		/// <summary>
		/// <para>Neighborhood Size</para>
		/// <para>The search radius to be applied to density calculations.</para>
		/// <para><see cref="NeighborhoodSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object NeighborhoodSize { get; set; }

		/// <summary>
		/// <para>Fields</para>
		/// <para>One or more fields denoting population values for each feature. The population field is the count or quantity to be spread across the landscape to create a continuous surface.</para>
		/// <para>Values in the population field must be numeric. By default, the density of the count of input points will always be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object Fields { get; set; }

		/// <summary>
		/// <para>Area Unit Scale Factor</para>
		/// <para>Specifies the area units of the output density values. The default unit is based on the units of the output spatial reference.</para>
		/// <para>Acres—Area in acres</para>
		/// <para>Hectares—Area in hectares</para>
		/// <para>Square miles—Area in square miles</para>
		/// <para>Square kilometers—Area in square kilometers</para>
		/// <para>Square meters—Area in square meters</para>
		/// <para>Square feet—Area in square feet</para>
		/// <para>Square yards—Area in square yards</para>
		/// <para><see cref="AreaUnitScaleFactorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AreaUnitScaleFactor { get; set; } = "SQUARE_KILOMETERS";

		/// <summary>
		/// <para>Time Step Interval</para>
		/// <para>A value that specifies the duration of the time step. This parameter is only available if the input points are time enabled and represent an instant in time.</para>
		/// <para>Time stepping can only be applied if time is enabled on the input.</para>
		/// <para><see cref="TimeStepIntervalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TimeStepInterval { get; set; }

		/// <summary>
		/// <para>Time Step Repeat</para>
		/// <para>A value that specifies how often the time-step interval occurs. This parameter is only available if the input points are time enabled and represent an instant in time.</para>
		/// <para><see cref="TimeStepRepeatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TimeStepRepeat { get; set; }

		/// <summary>
		/// <para>Time Step Reference</para>
		/// <para>A date that specifies the reference time with which to align the time steps. The default is January 1, 1970, at 12:00 a.m. This parameter is only available if the input points are time enabled and represent an instant in time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object TimeStepReference { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Data Store</para>
		/// <para>Specifies the ArcGIS Data Store where the output will be saved. The default is Spatiotemporal big data store. All results stored in a spatiotemporal big data store will be stored in WGS84. Results stored in a relational data store will maintain their coordinate system.</para>
		/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
		/// <para>Relational data store—Output will be stored in a relational data store.</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateDensity SetEnviroment(object extent = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Bin Type</para>
		/// </summary>
		public enum BinTypeEnum 
		{
			/// <summary>
			/// <para>Square—The bin shape will be square. This is the default.</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("Square")]
			Square,

			/// <summary>
			/// <para>Hexagon—The bin shape will be hexagonal.</para>
			/// </summary>
			[GPValue("HEXAGON")]
			[Description("Hexagon")]
			Hexagon,

		}

		/// <summary>
		/// <para>Bin Size</para>
		/// </summary>
		public enum BinSizeEnum 
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

		}

		/// <summary>
		/// <para>Weight</para>
		/// </summary>
		public enum WeightEnum 
		{
			/// <summary>
			/// <para>Kernel—A magnitude-per-area calculation with a smoothing algorithm applied (kernel) that weights bins closer to the points more heavily.</para>
			/// </summary>
			[GPValue("KERNEL")]
			[Description("Kernel")]
			Kernel,

			/// <summary>
			/// <para>Uniform—A magnitude-per-area calculation in which each bin is equally weighted. This is the default.</para>
			/// </summary>
			[GPValue("UNIFORM")]
			[Description("Uniform")]
			Uniform,

		}

		/// <summary>
		/// <para>Neighborhood Size</para>
		/// </summary>
		public enum NeighborhoodSizeEnum 
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

		}

		/// <summary>
		/// <para>Area Unit Scale Factor</para>
		/// </summary>
		public enum AreaUnitScaleFactorEnum 
		{
			/// <summary>
			/// <para>Square miles—Area in square miles</para>
			/// </summary>
			[GPValue("SQUARE_MILES")]
			[Description("Square miles")]
			Square_miles,

			/// <summary>
			/// <para>Square kilometers—Area in square kilometers</para>
			/// </summary>
			[GPValue("SQUARE_KILOMETERS")]
			[Description("Square kilometers")]
			Square_kilometers,

			/// <summary>
			/// <para>Acres—Area in acres</para>
			/// </summary>
			[GPValue("ACRES")]
			[Description("Acres")]
			Acres,

			/// <summary>
			/// <para>Hectares—Area in hectares</para>
			/// </summary>
			[GPValue("HECTARES")]
			[Description("Hectares")]
			Hectares,

			/// <summary>
			/// <para>Square yards—Area in square yards</para>
			/// </summary>
			[GPValue("SQUARE_YARDS")]
			[Description("Square yards")]
			Square_yards,

			/// <summary>
			/// <para>Square feet—Area in square feet</para>
			/// </summary>
			[GPValue("SQUARE_FEET")]
			[Description("Square feet")]
			Square_feet,

			/// <summary>
			/// <para>Square meters—Area in square meters</para>
			/// </summary>
			[GPValue("SQUARE_METERS")]
			[Description("Square meters")]
			Square_meters,

		}

		/// <summary>
		/// <para>Time Step Interval</para>
		/// </summary>
		public enum TimeStepIntervalEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Milliseconds")]
			[Description("Milliseconds")]
			Milliseconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Hours")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Days")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Weeks")]
			[Description("Weeks")]
			Weeks,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Months")]
			[Description("Months")]
			Months,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Years")]
			[Description("Years")]
			Years,

		}

		/// <summary>
		/// <para>Time Step Repeat</para>
		/// </summary>
		public enum TimeStepRepeatEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Milliseconds")]
			[Description("Milliseconds")]
			Milliseconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Hours")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Days")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Weeks")]
			[Description("Weeks")]
			Weeks,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Months")]
			[Description("Months")]
			Months,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Years")]
			[Description("Years")]
			Years,

		}

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("Spatiotemporal big data store")]
			Spatiotemporal_big_data_store,

			/// <summary>
			/// <para>Relational data store—Output will be stored in a relational data store.</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("Relational data store")]
			Relational_data_store,

		}

#endregion
	}
}
