using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Storage Capacity</para>
	/// <para>Creates a table and a chart of elevations and corresponding storage capacities for an input surface raster. The tool calculates the surface area and total volume of the underlying region at a series of elevation increments.</para>
	/// </summary>
	public class StorageCapacity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurfaceRaster">
		/// <para>Input surface raster</para>
		/// <para>The input raster representing a continuous surface.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output table</para>
		/// <para>The output table that contains for each zone the surface area and total volumes for each increment in elevation.</para>
		/// </param>
		public StorageCapacity(object InSurfaceRaster, object OutTable)
		{
			this.InSurfaceRaster = InSurfaceRaster;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Storage Capacity</para>
		/// </summary>
		public override string DisplayName() => "Storage Capacity";

		/// <summary>
		/// <para>Tool Name : StorageCapacity</para>
		/// </summary>
		public override string ToolName() => "StorageCapacity";

		/// <summary>
		/// <para>Tool Excute Name : sa.StorageCapacity</para>
		/// </summary>
		public override string ExcuteName() => "sa.StorageCapacity";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSurfaceRaster, OutTable, InZoneData, ZoneField, AnalysisType, MinElevation, MaxElevation, IncrementType, Increment, ZUnit, OutChart };

		/// <summary>
		/// <para>Input surface raster</para>
		/// <para>The input raster representing a continuous surface.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Output table</para>
		/// <para>The output table that contains for each zone the surface area and total volumes for each increment in elevation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Input raster or feature zone data</para>
		/// <para>The dataset that defines the zones.</para>
		/// <para>The zones can be defined by an integer raster or a feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object InZoneData { get; set; }

		/// <summary>
		/// <para>Zone field</para>
		/// <para>The field that contains the values that define each zone.</para>
		/// <para>It can be an integer or a string field of the zone dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object ZoneField { get; set; }

		/// <summary>
		/// <para>Analysis type</para>
		/// <para>Specifies the analysis type.</para>
		/// <para>Area and Volume—Both surface areas and total volumes are calculated at each elevation increment. This is the default.</para>
		/// <para>Area—Surface area is calculated at each elevation increment.</para>
		/// <para>Volume—Total volume is calculated at each elevation increment.</para>
		/// <para><see cref="AnalysisTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AnalysisType { get; set; } = "AREA_VOLUME";

		/// <summary>
		/// <para>Minimum elevation</para>
		/// <para>The minimum elevation from which storage capacities are assessed.</para>
		/// <para>By default, the tool uses the minimum surface raster value in each zone as the minimum elevation for that zone. If a value is provided, it is used as the minimum elevation across all zones.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MinElevation { get; set; }

		/// <summary>
		/// <para>Maximum elevation</para>
		/// <para>The maximum elevation from which storage capacities are assessed.</para>
		/// <para>By default, the tool uses the maximum surface raster value in each zone as the maximum elevation for that zone. If a value is provided, it is used as the maximum elevation across all zones.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MaxElevation { get; set; }

		/// <summary>
		/// <para>Increment type</para>
		/// <para>Specifies the increment type to use when computing elevation increments between minimum and maximum elevations.</para>
		/// <para>Number of Increments—The number of increments between minimum and maximum elevations is used. This is the default.</para>
		/// <para>Value of Increment—The elevation difference between each increment is used.</para>
		/// <para><see cref="IncrementTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object IncrementType { get; set; } = "NUMBER_OF_INCREMENTS";

		/// <summary>
		/// <para>Increment</para>
		/// <para>An incremental value that is either the number of increments or the difference in elevation between increments. The value is determined based on the increment type parameter value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Increment { get; set; }

		/// <summary>
		/// <para>Z unit</para>
		/// <para>The linear unit of vertical z-values.</para>
		/// <para>Inch—The linear unit will be inches.</para>
		/// <para>Foot—The linear unit will be feet.</para>
		/// <para>Yard—The linear unit will be yards.</para>
		/// <para>Mile US—The linear unit will be miles.</para>
		/// <para>Nautical mile—The linear unit will be nautical miles.</para>
		/// <para>Millimeter—The linear unit will be millimeters.</para>
		/// <para>Centimeter—The linear unit will be centimeters.</para>
		/// <para>Meter—The linear unit will be meters.</para>
		/// <para>Kilometer—The linear unit will be kilometers.</para>
		/// <para>Decimeter—The linear unit will be decimeters.</para>
		/// <para><see cref="ZUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ZUnit { get; set; }

		/// <summary>
		/// <para>Output chart name</para>
		/// <para>The name of the output chart for display.</para>
		/// <para>The chart is listed in the Contents pane under Standalone Tables.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object OutChart { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public StorageCapacity SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Analysis type</para>
		/// </summary>
		public enum AnalysisTypeEnum 
		{
			/// <summary>
			/// <para>Area and Volume—Both surface areas and total volumes are calculated at each elevation increment. This is the default.</para>
			/// </summary>
			[GPValue("AREA_VOLUME")]
			[Description("Area and Volume")]
			Area_and_Volume,

			/// <summary>
			/// <para>Area and Volume—Both surface areas and total volumes are calculated at each elevation increment. This is the default.</para>
			/// </summary>
			[GPValue("AREA")]
			[Description("Area")]
			Area,

			/// <summary>
			/// <para>Volume—Total volume is calculated at each elevation increment.</para>
			/// </summary>
			[GPValue("VOLUME")]
			[Description("Volume")]
			Volume,

		}

		/// <summary>
		/// <para>Increment type</para>
		/// </summary>
		public enum IncrementTypeEnum 
		{
			/// <summary>
			/// <para>Number of Increments—The number of increments between minimum and maximum elevations is used. This is the default.</para>
			/// </summary>
			[GPValue("NUMBER_OF_INCREMENTS")]
			[Description("Number of Increments")]
			Number_of_Increments,

			/// <summary>
			/// <para>Value of Increment—The elevation difference between each increment is used.</para>
			/// </summary>
			[GPValue("VALUE_OF_INCREMENT")]
			[Description("Value of Increment")]
			Value_of_Increment,

		}

		/// <summary>
		/// <para>Z unit</para>
		/// </summary>
		public enum ZUnitEnum 
		{
			/// <summary>
			/// <para>Meter—The linear unit will be meters.</para>
			/// </summary>
			[GPValue("METER")]
			[Description("Meter")]
			Meter,

			/// <summary>
			/// <para>Inch—The linear unit will be inches.</para>
			/// </summary>
			[GPValue("INCH")]
			[Description("Inch")]
			Inch,

			/// <summary>
			/// <para>Foot—The linear unit will be feet.</para>
			/// </summary>
			[GPValue("FOOT")]
			[Description("Foot")]
			Foot,

			/// <summary>
			/// <para>Yard—The linear unit will be yards.</para>
			/// </summary>
			[GPValue("YARD")]
			[Description("Yard")]
			Yard,

			/// <summary>
			/// <para>Mile US—The linear unit will be miles.</para>
			/// </summary>
			[GPValue("MILE_US")]
			[Description("Mile US")]
			Mile_US,

			/// <summary>
			/// <para>Nautical mile—The linear unit will be nautical miles.</para>
			/// </summary>
			[GPValue("NAUTICAL_MILE")]
			[Description("Nautical mile")]
			Nautical_mile,

			/// <summary>
			/// <para>Millimeter—The linear unit will be millimeters.</para>
			/// </summary>
			[GPValue("MILLIMETER")]
			[Description("Millimeter")]
			Millimeter,

			/// <summary>
			/// <para>Centimeter—The linear unit will be centimeters.</para>
			/// </summary>
			[GPValue("CENTIMETER")]
			[Description("Centimeter")]
			Centimeter,

			/// <summary>
			/// <para>Kilometer—The linear unit will be kilometers.</para>
			/// </summary>
			[GPValue("KILOMETER")]
			[Description("Kilometer")]
			Kilometer,

			/// <summary>
			/// <para>Decimeter—The linear unit will be decimeters.</para>
			/// </summary>
			[GPValue("DECIMETER")]
			[Description("Decimeter")]
			Decimeter,

		}

#endregion
	}
}
