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
	/// <para>Create Viewshed</para>
	/// <para>Create Viewshed</para>
	/// <para>Creates areas where an observer can see objects on the ground. The input observer points can represent either observers (such as people on the ground or lookouts in a fire tower) or observed objects (such as wind turbines, water towers, vehicles, or other people).</para>
	/// </summary>
	public class CreateViewshed : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputelevationsurface">
		/// <para>Input Elevation Surface</para>
		/// <para>The elevation surface to use for calculating the viewshed.</para>
		/// <para>If the vertical unit of the input surface is different from the horizontal unit, such as when the elevation values are represented in feet but the coordinate system is in meters, the surface must have a defined vertical coordinate system. The reason for this is that the tool uses the vertical (Z) and horizontal (XY) units to compute a z-factor for the viewshed analysis. Without a vertical coordinate system, and thus having no Z unit information available, the tool will assume that the Z unit is the same as the XY unit. The result of this is that an internal Z factor of 1.0 will be used for the analysis, which may give unexpected results.</para>
		/// <para>The elevation surface can be integer or floating point.</para>
		/// </param>
		/// <param name="Inputobserverfeatures">
		/// <para>Observer Features</para>
		/// <para>The point features that represent the observer locations when calculating the viewsheds.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the output raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </param>
		public CreateViewshed(object Inputelevationsurface, object Inputobserverfeatures, object Outputname)
		{
			this.Inputelevationsurface = Inputelevationsurface;
			this.Inputobserverfeatures = Inputobserverfeatures;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Viewshed</para>
		/// </summary>
		public override string DisplayName() => "Create Viewshed";

		/// <summary>
		/// <para>Tool Name : CreateViewshed</para>
		/// </summary>
		public override string ToolName() => "CreateViewshed";

		/// <summary>
		/// <para>Tool Excute Name : ra.CreateViewshed</para>
		/// </summary>
		public override string ExcuteName() => "ra.CreateViewshed";

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
		public override object[] Parameters() => new object[] { Inputelevationsurface, Inputobserverfeatures, Outputname, Optimizefor, Maximumviewingdistancetype, Maximumviewingdistance, Maximumviewingdistancefield, Minimumviewingdistancetype, Minimumviewingdistance, Minimumviewingdistancefield, Viewingdistanceis3d, Observerselevationtype, Observerselevation, Observerselevationfield, Observersheighttype, Observersheight, Observersheightfield, Targetheighttype, Targetheight, Targetheightfield, Abovegroundleveloutputname, Outputraster, Outputabovegroundlevelraster };

		/// <summary>
		/// <para>Input Elevation Surface</para>
		/// <para>The elevation surface to use for calculating the viewshed.</para>
		/// <para>If the vertical unit of the input surface is different from the horizontal unit, such as when the elevation values are represented in feet but the coordinate system is in meters, the surface must have a defined vertical coordinate system. The reason for this is that the tool uses the vertical (Z) and horizontal (XY) units to compute a z-factor for the viewshed analysis. Without a vertical coordinate system, and thus having no Z unit information available, the tool will assume that the Z unit is the same as the XY unit. The result of this is that an internal Z factor of 1.0 will be used for the analysis, which may give unexpected results.</para>
		/// <para>The elevation surface can be integer or floating point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputelevationsurface { get; set; }

		/// <summary>
		/// <para>Observer Features</para>
		/// <para>The point features that represent the observer locations when calculating the viewsheds.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polyline")]
		[FeatureType("Simple")]
		public object Inputobserverfeatures { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Optimize For</para>
		/// <para>The optimization method to use for calculating the viewshed.</para>
		/// <para>Speed—This method optimizes the processing speed, trading some accuracy in the result for higher performance. This is the default.</para>
		/// <para>Accuracy—This method is optimized for accuracy in the results, at the expense of a longer processing time.</para>
		/// <para><see cref="OptimizeforEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Optimizefor { get; set; } = "SPEED";

		/// <summary>
		/// <para>Maximum Viewing Distance Type</para>
		/// <para>The method by which the maximum viewing distance will be determined.</para>
		/// <para>Distance—The maximum distance is defined by a value you specify. This is the default method.</para>
		/// <para>Field— The maximum distance for each observer location is determined by the values in a field you specify.</para>
		/// <para>If you change the type from Distance to Field, the Maximum Viewing Distance parameter will change to Maximum Viewing Distance Field.</para>
		/// <para><see cref="MaximumviewingdistancetypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Maximumviewingdistancetype { get; set; } = "DISTANCE";

		/// <summary>
		/// <para>Maximum Viewing Distance</para>
		/// <para>This is a cutoff distance, where the computation of visible areas stops. Beyond this distance, it is unknown whether the observer points and the other objects can see each other.</para>
		/// <para>The units can be Kilometers, Meters, Miles, Yards, or Feet.</para>
		/// <para>The default is miles.</para>
		/// <para><see cref="MaximumviewingdistanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object Maximumviewingdistance { get; set; } = "9 Miles";

		/// <summary>
		/// <para>Maximum Viewing Distance Field</para>
		/// <para>This is a field you can use to specify the maximum viewing distance for each observer. The values contained in the field must be in the same unit as the XY unit of the input elevation surface.</para>
		/// <para>The maximum viewing distance is a cutoff distance where the computation of visible areas stops. Beyond this distance, it is unknown whether the observer points and the other objects can see each other.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "OID")]
		public object Maximumviewingdistancefield { get; set; }

		/// <summary>
		/// <para>Minimum Viewing Distance Type</para>
		/// <para>Choose the method by which the minimum visible distance will be determined.</para>
		/// <para>Distance—The minimum distance is defined by a value you specify. This is the default method.</para>
		/// <para>Field— The minimum distance for each observer location is determined by the values in a field you specify.</para>
		/// <para>If you change the type from Distance to Field, the Minimum Viewing Distance parameter will change to Minimum Viewing Distance Field.</para>
		/// <para><see cref="MinimumviewingdistancetypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Minimumviewingdistancetype { get; set; } = "DISTANCE";

		/// <summary>
		/// <para>Minimum Viewing Distance</para>
		/// <para>This is a distance where the computation of visible areas begins. Cells on the surface closer than this distance are not visible in the output but can still block visibility of the cells between the minimum and maximum viewing distance.</para>
		/// <para>The units can be Kilometers, Meters, Miles, Yards, or Feet.</para>
		/// <para>The default units are Meters.</para>
		/// <para><see cref="MinimumviewingdistanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object Minimumviewingdistance { get; set; }

		/// <summary>
		/// <para>Minimum Viewing Distance Field</para>
		/// <para>This is a field you can use to specify the minimum viewing distance for each observer. The values contained in the field must be in the same unit as the XY unit of the input elevation surface.</para>
		/// <para>The minimum viewing distance defines where the computation of visible areas begins. Cells on the surface closer than this distance are not visible in the output but can still block visibility of the cells between the minimum and maximum viewing distance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "OID")]
		public object Minimumviewingdistancefield { get; set; }

		/// <summary>
		/// <para>Viewing Distance is 3D</para>
		/// <para>Specify whether the minimum and maximum viewing distance parameters are measured in a three-dimensional way or a simpler, two-dimensional way. A 2D distance is the simple linear distance measured between an observer and the target using their projected locations at sea level. A 3D distance gives a more realistic value by taking their relative heights into consideration.</para>
		/// <para>Checked—The viewing distance is measured in 3D distance.</para>
		/// <para>Unchecked—The viewing distance is measured in 2D distance. This is the default.</para>
		/// <para><see cref="Viewingdistanceis3dEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Viewingdistanceis3d { get; set; } = "false";

		/// <summary>
		/// <para>Observers Elevation Type</para>
		/// <para>The method by which the elevation of the observers will be determined.</para>
		/// <para>Elevation—The observer elevation is defined by a value you specify. This is the default method.</para>
		/// <para>Field—The elevation for each observer location is determined by the values in a field you specify.</para>
		/// <para>If you change the type from Elevation to Field, the Observers Elevation parameter will change to Observers Elevation Field.</para>
		/// <para><see cref="ObserverselevationtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Observerselevationtype { get; set; } = "ELEVATION";

		/// <summary>
		/// <para>Observers Elevation</para>
		/// <para>This is the elevation of your observer locations.</para>
		/// <para>If this parameter is not specified, the observer elevation will be obtained from the surface raster using bilinear interpolation. If this parameter is set to a value, that value will be applied to all the observers. To specify different values for each observer, set this parameter to a field in the input observer features.</para>
		/// <para>The units can be Kilometers, Meters, Miles, Yards, or Feet.</para>
		/// <para>The default units are Meters.</para>
		/// <para><see cref="ObserverselevationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object Observerselevation { get; set; }

		/// <summary>
		/// <para>Observers Elevation Field</para>
		/// <para>This is a field you can use to specify the elevation for the observers. The value contained in the field must be in the same unit as the Z unit of the input elevation surface.</para>
		/// <para>If this parameter is not specified, the observer elevation will be obtained from the surface raster using bilinear interpolation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "OID")]
		public object Observerselevationfield { get; set; }

		/// <summary>
		/// <para>Observers Height Type</para>
		/// <para>The method by which the height of the observers will be determined.</para>
		/// <para>Height—The observer height is obtained from the value you specify. This is the default method.</para>
		/// <para>Field— The height for each observer location is determined by the values in a field you specify.</para>
		/// <para>If you change the type from Height to Field, the Observers Height parameter will change to Observers Height Field.</para>
		/// <para><see cref="ObserversheighttypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Observersheighttype { get; set; } = "HEIGHT";

		/// <summary>
		/// <para>Observers Height</para>
		/// <para>This is the height used for your observer locations.</para>
		/// <para>The units can be Kilometers, Meters, Miles, Yards, or Feet.</para>
		/// <para>The default units are Meters.</para>
		/// <para><see cref="ObserversheightEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object Observersheight { get; set; } = "6 Feet";

		/// <summary>
		/// <para>Observers Height Field</para>
		/// <para>This is a field you can use to specify the height for the observers. The value contained in the field must be in the same unit as the Z unit of the input elevation surface.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "OID")]
		public object Observersheightfield { get; set; }

		/// <summary>
		/// <para>Target Height Type</para>
		/// <para>The method by which the height of the targets will be determined.</para>
		/// <para>Height—The target height is obtained from the value you specify. This is the default method.</para>
		/// <para>Field— The height for each target is determined by the values in a field you specify.</para>
		/// <para>If you change the type from Height to Field, the Target Height parameter will change to Target Height Field.</para>
		/// <para><see cref="TargetheighttypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Targetheighttype { get; set; } = "HEIGHT";

		/// <summary>
		/// <para>Target Height</para>
		/// <para>This is the height of structures or people on the ground used to establish visibility. The result viewshed are those areas where an observer point can see these other objects. The converse is also true; the other objects can see an observer point.</para>
		/// <para>The units can be Kilometers, Meters, Miles, Yards, or Feet.</para>
		/// <para>The default units are Meters.</para>
		/// <para><see cref="TargetheightEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object Targetheight { get; set; }

		/// <summary>
		/// <para>Target Height Field</para>
		/// <para>This is a field used to specify the height for the targets. The value contained in the field must be in the same unit as the Z unit of the input elevation surface.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "OID")]
		public object Targetheightfield { get; set; }

		/// <summary>
		/// <para>Above Ground Level Output Name</para>
		/// <para>The name of the output aboveground-level (AGL) raster. The AGL result is a raster where each cell value is the minimum height that must be added to an otherwise nonvisible cell to make it visible by at least one observer. Cells that were already visible will be assigned 0 in this output raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Abovegroundleveloutputname { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputraster { get; set; }

		/// <summary>
		/// <para>Output Above Ground Level Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputabovegroundlevelraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateViewshed SetEnviroment(object cellSize = null, object extent = null, object mask = null, object outputCoordinateSystem = null, object snapRaster = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Optimize For</para>
		/// </summary>
		public enum OptimizeforEnum 
		{
			/// <summary>
			/// <para>Speed—This method optimizes the processing speed, trading some accuracy in the result for higher performance. This is the default.</para>
			/// </summary>
			[GPValue("SPEED")]
			[Description("Speed")]
			Speed,

			/// <summary>
			/// <para>Accuracy—This method is optimized for accuracy in the results, at the expense of a longer processing time.</para>
			/// </summary>
			[GPValue("ACCURACY")]
			[Description("Accuracy")]
			Accuracy,

		}

		/// <summary>
		/// <para>Maximum Viewing Distance Type</para>
		/// </summary>
		public enum MaximumviewingdistancetypeEnum 
		{
			/// <summary>
			/// <para>Distance—The maximum distance is defined by a value you specify. This is the default method.</para>
			/// </summary>
			[GPValue("DISTANCE")]
			[Description("Distance")]
			Distance,

			/// <summary>
			/// <para>Field— The maximum distance for each observer location is determined by the values in a field you specify.</para>
			/// </summary>
			[GPValue("FIELD")]
			[Description("Field")]
			Field,

		}

		/// <summary>
		/// <para>Maximum Viewing Distance</para>
		/// </summary>
		public enum MaximumviewingdistanceEnum 
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
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>Minimum Viewing Distance Type</para>
		/// </summary>
		public enum MinimumviewingdistancetypeEnum 
		{
			/// <summary>
			/// <para>Distance—The minimum distance is defined by a value you specify. This is the default method.</para>
			/// </summary>
			[GPValue("DISTANCE")]
			[Description("Distance")]
			Distance,

			/// <summary>
			/// <para>Field— The minimum distance for each observer location is determined by the values in a field you specify.</para>
			/// </summary>
			[GPValue("FIELD")]
			[Description("Field")]
			Field,

		}

		/// <summary>
		/// <para>Minimum Viewing Distance</para>
		/// </summary>
		public enum MinimumviewingdistanceEnum 
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
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>Viewing Distance is 3D</para>
		/// </summary>
		public enum Viewingdistanceis3dEnum 
		{
			/// <summary>
			/// <para>Checked—The viewing distance is measured in 3D distance.</para>
			/// </summary>
			[GPValue("true")]
			[Description("3D")]
			_3D,

			/// <summary>
			/// <para>Unchecked—The viewing distance is measured in 2D distance. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("2D")]
			_2D,

		}

		/// <summary>
		/// <para>Observers Elevation Type</para>
		/// </summary>
		public enum ObserverselevationtypeEnum 
		{
			/// <summary>
			/// <para>Elevation—The observer elevation is defined by a value you specify. This is the default method.</para>
			/// </summary>
			[GPValue("ELEVATION")]
			[Description("Elevation")]
			Elevation,

			/// <summary>
			/// <para>Field—The elevation for each observer location is determined by the values in a field you specify.</para>
			/// </summary>
			[GPValue("FIELD")]
			[Description("Field")]
			Field,

		}

		/// <summary>
		/// <para>Observers Elevation</para>
		/// </summary>
		public enum ObserverselevationEnum 
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
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>Observers Height Type</para>
		/// </summary>
		public enum ObserversheighttypeEnum 
		{
			/// <summary>
			/// <para>Height—The observer height is obtained from the value you specify. This is the default method.</para>
			/// </summary>
			[GPValue("HEIGHT")]
			[Description("Height")]
			Height,

			/// <summary>
			/// <para>Field— The height for each observer location is determined by the values in a field you specify.</para>
			/// </summary>
			[GPValue("FIELD")]
			[Description("Field")]
			Field,

		}

		/// <summary>
		/// <para>Observers Height</para>
		/// </summary>
		public enum ObserversheightEnum 
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
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>Target Height Type</para>
		/// </summary>
		public enum TargetheighttypeEnum 
		{
			/// <summary>
			/// <para>Height—The target height is obtained from the value you specify. This is the default method.</para>
			/// </summary>
			[GPValue("HEIGHT")]
			[Description("Height")]
			Height,

			/// <summary>
			/// <para>Field— The height for each target is determined by the values in a field you specify.</para>
			/// </summary>
			[GPValue("FIELD")]
			[Description("Field")]
			Field,

		}

		/// <summary>
		/// <para>Target Height</para>
		/// </summary>
		public enum TargetheightEnum 
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
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

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
