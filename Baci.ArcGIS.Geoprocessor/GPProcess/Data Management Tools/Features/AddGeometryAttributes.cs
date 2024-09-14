using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Add Geometry Attributes</para>
	/// <para>Add Geometry Attributes</para>
	/// <para>Adds new attribute fields to the input features representing the spatial or geometric characteristics and location of each feature, such as length or area and x-, y-, z-, and m-coordinates.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.DataManagementTools.CalculateGeometryAttributes"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[Obsolete()]
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.DataManagementTools.CalculateGeometryAttributes))]
	public class AddGeometryAttributes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>The input features to which new attribute fields will be added to store properties such as length, area, or x-, y-, z-, and m-coordinates.</para>
		/// </param>
		/// <param name="GeometryProperties">
		/// <para>Geometry Properties</para>
		/// <para>Specifies the geometry or shape properties that will be calculated into new attribute fields.</para>
		/// <para>Area—An attribute will be added to store the area of each polygon feature.</para>
		/// <para>Geodesic area—An attribute will be added to store the shape-preserving geodesic area of each polygon feature.</para>
		/// <para>Centroid coordinates—Attributes will be added to store the centroid coordinates of each feature.</para>
		/// <para>Central point coordinates—Attributes will be added to store the coordinates of a central point inside or on each feature.</para>
		/// <para>Extent coordinates—Attributes will be added to store the extent coordinates of each feature.</para>
		/// <para>Length—An attribute will be added to store the length of each line feature.</para>
		/// <para>Geodesic length—An attribute will be added to store the shape-preserving geodesic length of each line feature.</para>
		/// <para>3D length—An attribute will be added to store the 3D length of each line feature.</para>
		/// <para>Line bearing—An attribute will be added to store the start-to-end bearing of each line feature. Values range from 0 to 360, with 0 meaning north, 90 east, 180 south, and 270 west.</para>
		/// <para>Line start, midpoint, and end coordinates—Attributes will be added to store the coordinates of the start, mid, and end points of each feature.</para>
		/// <para>Number of parts—An attribute will be added to store the number of parts composing each feature.</para>
		/// <para>Length of perimeter—An attribute will be added to store the length of the perimeter or border of each polygon feature.</para>
		/// <para>Geodesic length of perimeter—An attribute will be added to store the shape-preserving geodesic length of the perimeter or border of each polygon feature.</para>
		/// <para>Number of vertices—An attribute will be added to store the number of points or vertices composing each feature.</para>
		/// <para>Point x-, y-, z-, and m-coordinates—Attributes will be added to store the x-, y-, z-, and m-coordinates of each point feature.</para>
		/// </param>
		public AddGeometryAttributes(object InputFeatures, object GeometryProperties)
		{
			this.InputFeatures = InputFeatures;
			this.GeometryProperties = GeometryProperties;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Geometry Attributes</para>
		/// </summary>
		public override string DisplayName() => "Add Geometry Attributes";

		/// <summary>
		/// <para>Tool Name : AddGeometryAttributes</para>
		/// </summary>
		public override string ToolName() => "AddGeometryAttributes";

		/// <summary>
		/// <para>Tool Excute Name : management.AddGeometryAttributes</para>
		/// </summary>
		public override string ExcuteName() => "management.AddGeometryAttributes";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatures, GeometryProperties, LengthUnit!, AreaUnit!, CoordinateSystem!, ModifiedInputFeatures! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features to which new attribute fields will be added to store properties such as length, area, or x-, y-, z-, and m-coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Geometry Properties</para>
		/// <para>Specifies the geometry or shape properties that will be calculated into new attribute fields.</para>
		/// <para>Area—An attribute will be added to store the area of each polygon feature.</para>
		/// <para>Geodesic area—An attribute will be added to store the shape-preserving geodesic area of each polygon feature.</para>
		/// <para>Centroid coordinates—Attributes will be added to store the centroid coordinates of each feature.</para>
		/// <para>Central point coordinates—Attributes will be added to store the coordinates of a central point inside or on each feature.</para>
		/// <para>Extent coordinates—Attributes will be added to store the extent coordinates of each feature.</para>
		/// <para>Length—An attribute will be added to store the length of each line feature.</para>
		/// <para>Geodesic length—An attribute will be added to store the shape-preserving geodesic length of each line feature.</para>
		/// <para>3D length—An attribute will be added to store the 3D length of each line feature.</para>
		/// <para>Line bearing—An attribute will be added to store the start-to-end bearing of each line feature. Values range from 0 to 360, with 0 meaning north, 90 east, 180 south, and 270 west.</para>
		/// <para>Line start, midpoint, and end coordinates—Attributes will be added to store the coordinates of the start, mid, and end points of each feature.</para>
		/// <para>Number of parts—An attribute will be added to store the number of parts composing each feature.</para>
		/// <para>Length of perimeter—An attribute will be added to store the length of the perimeter or border of each polygon feature.</para>
		/// <para>Geodesic length of perimeter—An attribute will be added to store the shape-preserving geodesic length of the perimeter or border of each polygon feature.</para>
		/// <para>Number of vertices—An attribute will be added to store the number of points or vertices composing each feature.</para>
		/// <para>Point x-, y-, z-, and m-coordinates—Attributes will be added to store the x-, y-, z-, and m-coordinates of each point feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object GeometryProperties { get; set; }

		/// <summary>
		/// <para>Length Unit</para>
		/// <para>Specifies the unit in which the length will be calculated.</para>
		/// <para>Feet (United States)—Length in feet (United States)</para>
		/// <para>Meters—Length in meters</para>
		/// <para>Kilometers—Length in kilometers</para>
		/// <para>Miles (United States)—Length in miles (United States)</para>
		/// <para>Nautical miles (United States)—Length in nautical miles (United States)</para>
		/// <para>Yards (United States)—Length in yards (United States)</para>
		/// <para><see cref="LengthUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LengthUnit { get; set; }

		/// <summary>
		/// <para>Area Unit</para>
		/// <para>Specifies the unit in which the area will be calculated.</para>
		/// <para>Acres—Area in acres</para>
		/// <para>Hectares—Area in hectares</para>
		/// <para>Square miles (United States)—Area in square miles (United States)</para>
		/// <para>Square kilometers—Area in square kilometers</para>
		/// <para>Square meters—Area in square meters</para>
		/// <para>Square feet (United States)—Area in square feet (United States)</para>
		/// <para>Square yards (United States)—Area in square yards (United States)</para>
		/// <para>Square nautical miles (United States)—Area in square nautical miles (United States)</para>
		/// <para><see cref="AreaUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? AreaUnit { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>The coordinate system in which the coordinates, length, and area will be calculated. The coordinate system of the input features is used by default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object? CoordinateSystem { get; set; }

		/// <summary>
		/// <para>Modified Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? ModifiedInputFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddGeometryAttributes SetEnviroment(object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Length Unit</para>
		/// </summary>
		public enum LengthUnitEnum 
		{
			/// <summary>
			/// <para>Feet (United States)—Length in feet (United States)</para>
			/// </summary>
			[GPValue("FEET_US")]
			[Description("Feet (United States)")]
			FEET_US,

			/// <summary>
			/// <para>Meters—Length in meters</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Kilometers—Length in kilometers</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Miles (United States)—Length in miles (United States)</para>
			/// </summary>
			[GPValue("MILES_US")]
			[Description("Miles (United States)")]
			MILES_US,

			/// <summary>
			/// <para>Nautical miles (United States)—Length in nautical miles (United States)</para>
			/// </summary>
			[GPValue("NAUTICAL_MILES")]
			[Description("Nautical miles (United States)")]
			NAUTICAL_MILES,

			/// <summary>
			/// <para>Yards (United States)—Length in yards (United States)</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("Yards (United States)")]
			YARDS,

		}

		/// <summary>
		/// <para>Area Unit</para>
		/// </summary>
		public enum AreaUnitEnum 
		{
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
			/// <para>Square miles (United States)—Area in square miles (United States)</para>
			/// </summary>
			[GPValue("SQUARE_MILES_US")]
			[Description("Square miles (United States)")]
			SQUARE_MILES_US,

			/// <summary>
			/// <para>Square kilometers—Area in square kilometers</para>
			/// </summary>
			[GPValue("SQUARE_KILOMETERS")]
			[Description("Square kilometers")]
			Square_kilometers,

			/// <summary>
			/// <para>Square meters—Area in square meters</para>
			/// </summary>
			[GPValue("SQUARE_METERS")]
			[Description("Square meters")]
			Square_meters,

			/// <summary>
			/// <para>Square feet (United States)—Area in square feet (United States)</para>
			/// </summary>
			[GPValue("SQUARE_FEET_US")]
			[Description("Square feet (United States)")]
			SQUARE_FEET_US,

			/// <summary>
			/// <para>Square yards (United States)—Area in square yards (United States)</para>
			/// </summary>
			[GPValue("SQUARE_YARDS")]
			[Description("Square yards (United States)")]
			SQUARE_YARDS,

			/// <summary>
			/// <para>Square nautical miles (United States)—Area in square nautical miles (United States)</para>
			/// </summary>
			[GPValue("SQUARE_NAUTICAL_MILES")]
			[Description("Square nautical miles (United States)")]
			SQUARE_NAUTICAL_MILES,

		}

#endregion
	}
}
