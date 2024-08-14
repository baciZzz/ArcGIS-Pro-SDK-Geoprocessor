using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.StandardFeatureAnalysisTools
{
	/// <summary>
	/// <para>Calculate Density</para>
	/// <para>Creates a density map from point or line features by spreading known quantities of some phenomenon (represented as attributes of the points or lines) across the map. The result is a layer of areas classified from least dense to most dense.</para>
	/// </summary>
	public class CalculateDensity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputlayer">
		/// <para>Input Features</para>
		/// <para>The point or line features from which to calculate density.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the output layer to create on your portal.</para>
		/// </param>
		public CalculateDensity(object Inputlayer, object Outputname)
		{
			this.Inputlayer = Inputlayer;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Density</para>
		/// </summary>
		public override string DisplayName => "Calculate Density";

		/// <summary>
		/// <para>Tool Name : CalculateDensity</para>
		/// </summary>
		public override string ToolName => "CalculateDensity";

		/// <summary>
		/// <para>Tool Excute Name : sfa.CalculateDensity</para>
		/// </summary>
		public override string ExcuteName => "sfa.CalculateDensity";

		/// <summary>
		/// <para>Toolbox Display Name : Standard Feature Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Standard Feature Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : sfa</para>
		/// </summary>
		public override string ToolboxAlise => "sfa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Inputlayer, Outputname, Field!, Cellsize!, Cellsizeunits!, Radius!, Radiusunits!, Boundingpolygonlayer!, Areaunits!, Classificationtype!, Numclasses!, Outputlayer! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The point or line features from which to calculate density.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		public object Inputlayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output layer to create on your portal.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Count Field</para>
		/// <para>A field specifying the number of incidents at each location. For example, if you have points that represent cities, you can use a field representing the population of the city as the count field, and the resulting population density layer will calculate larger population densities near cities with larger populations.</para>
		/// <para>If not specified, each location will be assumed to represent a single count.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? Field { get; set; }

		/// <summary>
		/// <para>Cell Size</para>
		/// <para>This value is used to create a mesh of points where density values are calculated. The default is approximately 1/1000th of the smaller of the width and height of the analysis extent as defined in the context parameter. The smaller the value, the smoother the polygon boundaries will be. Conversely, with larger values, the polygon boundaries will be more coarse and jagged.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Additional Options")]
		public object? Cellsize { get; set; }

		/// <summary>
		/// <para>Cell Size Units</para>
		/// <para>The units of the cell size value. You must provide a value if cell size has been set.</para>
		/// <para>Miles—Miles</para>
		/// <para>Feet—Feet</para>
		/// <para>Kilometers—Kilometers</para>
		/// <para>Meters—Meters</para>
		/// <para><see cref="CellsizeunitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object? Cellsizeunits { get; set; }

		/// <summary>
		/// <para>Radius</para>
		/// <para>A distance specifying how far to search to find point or line features when calculating density values. For example, if you provide a search distance of 1,800 meters, the density of any location in the output layer is calculated based on features that are within 1,800 meters of the location. Any location that does not have any incidents within 1,800 meters will receive a density value of zero.</para>
		/// <para>If no distance is provided, a default will be calculated based on the locations of the input features and the values in the count field (if a count field is provided).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Additional Options")]
		public object? Radius { get; set; }

		/// <summary>
		/// <para>Radius Units</para>
		/// <para>The units of the radius value. You must provide a value if a radius has been set.</para>
		/// <para>Miles—Miles</para>
		/// <para>Feet—Feet</para>
		/// <para>Kilometers—Kilometers</para>
		/// <para>Meters—Meters</para>
		/// <para><see cref="RadiusunitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object? Radiusunits { get; set; }

		/// <summary>
		/// <para>Bounding Polygons</para>
		/// <para>A layer specifying the polygons where you want densities to be calculated. For example, if you are interpolating densities of fish within a lake, you can use the boundary of the lake in this parameter and the output will only draw within the boundary of the lake.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Additional Options")]
		public object? Boundingpolygonlayer { get; set; }

		/// <summary>
		/// <para>Area Units</para>
		/// <para>The units of the calculated density values.</para>
		/// <para>Square miles—Square miles</para>
		/// <para>Square kilometers—Square kilometers</para>
		/// <para><see cref="AreaunitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object? Areaunits { get; set; } = "SQUAREMILES";

		/// <summary>
		/// <para>Classification Type</para>
		/// <para>Determines how density values will be classified into polygons.</para>
		/// <para>Equal interval— Polygons are created such that the range of density values is equal for each area.</para>
		/// <para>Geometric interval— Polygons are based on class intervals that have a geometric series. This method ensures that each class range has approximately the same number of values within each class and that the change between intervals is consistent.</para>
		/// <para>Natural breaks— Class intervals for polygons are based on natural groupings of the data. Class break values are identified that best group similar values and that maximize the differences between classes.</para>
		/// <para>Equal area— Polygons are created such that the size of each area is equal. For example, if the result has more high-density values than low-density values, more polygons will be created for high densities.</para>
		/// <para>Standard deviation— Polygons are created based upon the standard deviation of the predicted density values.</para>
		/// <para><see cref="ClassificationtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object? Classificationtype { get; set; } = "EQUALINTERVAL";

		/// <summary>
		/// <para>Number of Classes</para>
		/// <para>This value is used to divide the range of predicted values into distinct classes. The range of values in each class is determined by the classification type. Each class defines the boundaries of the result polygons.</para>
		/// <para>The default is 10 and the maximum is 32.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain()]
		[Category("Additional Options")]
		public object? Numclasses { get; set; } = "10";

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? Outputlayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateDensity SetEnviroment(object? extent = null )
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Cell Size Units</para>
		/// </summary>
		public enum CellsizeunitsEnum 
		{
			/// <summary>
			/// <para>Miles—Miles</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para>Feet—Feet</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>Kilometers—Kilometers</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Meters—Meters</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

		}

		/// <summary>
		/// <para>Radius Units</para>
		/// </summary>
		public enum RadiusunitsEnum 
		{
			/// <summary>
			/// <para>Miles—Miles</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para>Feet—Feet</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>Kilometers—Kilometers</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Meters—Meters</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

		}

		/// <summary>
		/// <para>Area Units</para>
		/// </summary>
		public enum AreaunitsEnum 
		{
			/// <summary>
			/// <para>Square miles—Square miles</para>
			/// </summary>
			[GPValue("SQUAREMILES")]
			[Description("Square miles")]
			Square_miles,

			/// <summary>
			/// <para>Square kilometers—Square kilometers</para>
			/// </summary>
			[GPValue("SQUAREKILOMETERS")]
			[Description("Square kilometers")]
			Square_kilometers,

		}

		/// <summary>
		/// <para>Classification Type</para>
		/// </summary>
		public enum ClassificationtypeEnum 
		{
			/// <summary>
			/// <para>Equal interval— Polygons are created such that the range of density values is equal for each area.</para>
			/// </summary>
			[GPValue("EQUALINTERVAL")]
			[Description("Equal interval")]
			Equal_interval,

			/// <summary>
			/// <para>Geometric interval— Polygons are based on class intervals that have a geometric series. This method ensures that each class range has approximately the same number of values within each class and that the change between intervals is consistent.</para>
			/// </summary>
			[GPValue("GEOMETRICINTERVAL")]
			[Description("Geometric interval")]
			Geometric_interval,

			/// <summary>
			/// <para>Natural breaks— Class intervals for polygons are based on natural groupings of the data. Class break values are identified that best group similar values and that maximize the differences between classes.</para>
			/// </summary>
			[GPValue("NATURALBREAKS")]
			[Description("Natural breaks")]
			Natural_breaks,

			/// <summary>
			/// <para>Equal area— Polygons are created such that the size of each area is equal. For example, if the result has more high-density values than low-density values, more polygons will be created for high densities.</para>
			/// </summary>
			[GPValue("EQUALAREA")]
			[Description("Equal area")]
			Equal_area,

			/// <summary>
			/// <para>Standard deviation— Polygons are created based upon the standard deviation of the predicted density values.</para>
			/// </summary>
			[GPValue("STANDARDDEVIATION")]
			[Description("Standard deviation")]
			Standard_deviation,

		}

#endregion
	}
}
