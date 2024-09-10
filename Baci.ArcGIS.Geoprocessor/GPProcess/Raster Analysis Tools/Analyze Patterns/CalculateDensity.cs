using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.RasterAnalysisTools
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
		/// <param name="Inputpointorlinefeatures">
		/// <para>Input Point or Line Features</para>
		/// <para>The input point or line features that will be used to calculate the density raster.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the output raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </param>
		public CalculateDensity(object Inputpointorlinefeatures, object Outputname)
		{
			this.Inputpointorlinefeatures = Inputpointorlinefeatures;
			this.Outputname = Outputname;
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
		/// <para>Tool Excute Name : ra.CalculateDensity</para>
		/// </summary>
		public override string ExcuteName() => "ra.CalculateDensity";

		/// <summary>
		/// <para>Toolbox Display Name : Raster Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Raster Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : ra</para>
		/// </summary>
		public override string ToolboxAlise() => "ra";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputpointorlinefeatures, Outputname, Countfield, Searchdistance, Outputareaunits, Outputcellsize, Outputraster, Inbarriers };

		/// <summary>
		/// <para>Input Point or Line Features</para>
		/// <para>The input point or line features that will be used to calculate the density raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polyline")]
		[FeatureType("Simple")]
		public object Inputpointorlinefeatures { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Count Field</para>
		/// <para>A field indicating the number of incidents at each location. For example, if you are making a population density raster, and the input points are cities, it is appropriate to use the population of the city for the count field so cities with larger populations have more impact on the density calculations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object Countfield { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The search distance and units for the distance. When calculating the density of a cell, all features within this distance will be used in the density calculation for that cell.</para>
		/// <para>The units can be Kilometers, Meters, Miles, or Feet.</para>
		/// <para>The default units are Meters.</para>
		/// <para><see cref="SearchdistanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object Searchdistance { get; set; }

		/// <summary>
		/// <para>Output Area Units</para>
		/// <para>Specifies the units that will be used for calculating area. Density is count divided by area, and this parameter sets the units of the area in the density calculation.</para>
		/// <para>Square Meters—Calculate the density per square meter. This is the default.</para>
		/// <para>Square Kilometers—Calculate the density per square kilometer.</para>
		/// <para>Square Feet—Calculate the density per square foot.</para>
		/// <para>Square Miles—Calculate the density per square mile.</para>
		/// <para><see cref="OutputareaunitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Outputareaunits { get; set; }

		/// <summary>
		/// <para>Output Cell Size</para>
		/// <para>The cell size and units for the output raster.</para>
		/// <para>The units can be Kilometers, Meters, Miles, or Feet.</para>
		/// <para>The default units are Meters.</para>
		/// <para><see cref="OutputcellsizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object Outputcellsize { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputraster { get; set; }

		/// <summary>
		/// <para>Input Barrier Features</para>
		/// <para>The dataset that defines the barriers.</para>
		/// <para>The barriers can be a feature layer of polyline or polygon features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		[FeatureType("Simple")]
		public object Inbarriers { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateDensity SetEnviroment(object cellSize = null , object extent = null , object mask = null , object outputCoordinateSystem = null , object snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Search Distance</para>
		/// </summary>
		public enum SearchdistanceEnum 
		{
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
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>Output Area Units</para>
		/// </summary>
		public enum OutputareaunitsEnum 
		{
			/// <summary>
			/// <para>Square Meters—Calculate the density per square meter. This is the default.</para>
			/// </summary>
			[GPValue("Square Meters")]
			[Description("Square Meters")]
			Square_Meters,

			/// <summary>
			/// <para>Square Kilometers—Calculate the density per square kilometer.</para>
			/// </summary>
			[GPValue("Square Kilometers")]
			[Description("Square Kilometers")]
			Square_Kilometers,

			/// <summary>
			/// <para>Square Feet—Calculate the density per square foot.</para>
			/// </summary>
			[GPValue("Square Feet")]
			[Description("Square Feet")]
			Square_Feet,

			/// <summary>
			/// <para>Square Miles—Calculate the density per square mile.</para>
			/// </summary>
			[GPValue("Square Miles")]
			[Description("Square Miles")]
			Square_Miles,

		}

		/// <summary>
		/// <para>Output Cell Size</para>
		/// </summary>
		public enum OutputcellsizeEnum 
		{
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
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

#endregion
	}
}
