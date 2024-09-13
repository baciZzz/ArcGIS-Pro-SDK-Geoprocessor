using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LocationReferencingTools
{
	/// <summary>
	/// <para>Enable Stationing Fields</para>
	/// <para>Enable Stationing Fields</para>
	/// <para>Enables or modifies stationing fields so that you can manage</para>
	/// <para>referent information for the registered LRS event.</para>
	/// </summary>
	public class EnableStationingFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>Event Feature Class</para>
		/// <para>An existing event feature class or feature layer that is registered to an LRS.</para>
		/// </param>
		public EnableStationingFields(object InFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Enable Stationing Fields</para>
		/// </summary>
		public override string DisplayName() => "Enable Stationing Fields";

		/// <summary>
		/// <para>Tool Name : EnableStationingFields</para>
		/// </summary>
		public override string ToolName() => "EnableStationingFields";

		/// <summary>
		/// <para>Tool Excute Name : locref.EnableStationingFields</para>
		/// </summary>
		public override string ExcuteName() => "locref.EnableStationingFields";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise() => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureClass, StationField!, BackStationField!, StationDirectionField!, StationMeasureUnits!, DecreasingStationValues!, OutFeatureClass! };

		/// <summary>
		/// <para>Event Feature Class</para>
		/// <para>An existing event feature class or feature layer that is registered to an LRS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Station Field</para>
		/// <para>The field that will be used as the starting reference station.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? StationField { get; set; }

		/// <summary>
		/// <para>Back Station Field</para>
		/// <para>The field that will be used as the back station.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? BackStationField { get; set; }

		/// <summary>
		/// <para>Station Value Direction Field</para>
		/// <para>The field that will be used to indicate the direction of increasing stations, either increasing toward the direction of calibration of the route or away from it.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? StationDirectionField { get; set; }

		/// <summary>
		/// <para>Station Measure Units</para>
		/// <para>Specifies the measure units that will be used for stationing.</para>
		/// <para>Miles (US Survey)—The unit of measure will be miles. This is the default.</para>
		/// <para>Inches (US Survey)—The unit of measure will be inches.</para>
		/// <para>Feet (US Survey)—The unit of measure will be feet.</para>
		/// <para>Yards (US Survey)—The unit of measure will be yards.</para>
		/// <para>Nautical miles (US Survey)—The unit of measure will be nautical miles.</para>
		/// <para>Feet (International)—The unit of measure will be international feet.</para>
		/// <para>Millimeters—The unit of measure will be millimeters.</para>
		/// <para>Centimeters—The unit of measure will be centimeters</para>
		/// <para>Meters—The unit of measure will be meters.</para>
		/// <para>Kilometers—The unit of measure will be kilometers.</para>
		/// <para>Decimeters—The unit of measure will be decimeters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StationMeasureUnits { get; set; }

		/// <summary>
		/// <para>Decreasing Station Values</para>
		/// <para>A comma-separated list of user-provided values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DecreasingStationValues { get; set; }

		/// <summary>
		/// <para>Output Event Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

	}
}
