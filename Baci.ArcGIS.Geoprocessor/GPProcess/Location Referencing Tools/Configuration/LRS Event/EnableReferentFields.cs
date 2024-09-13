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
	/// <para>Enable Referent Fields</para>
	/// <para>Enable Referent Fields</para>
	/// <para>Enables or modifies the referent fields so that you can  manage referent information for the registered LRS event.</para>
	/// </summary>
	public class EnableReferentFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>Event Feature Class</para>
		/// <para>The feature class that will be used for the LRS event.</para>
		/// </param>
		public EnableReferentFields(object InFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Enable Referent Fields</para>
		/// </summary>
		public override string DisplayName() => "Enable Referent Fields";

		/// <summary>
		/// <para>Tool Name : EnableReferentFields</para>
		/// </summary>
		public override string ToolName() => "EnableReferentFields";

		/// <summary>
		/// <para>Tool Excute Name : locref.EnableReferentFields</para>
		/// </summary>
		public override string ExcuteName() => "locref.EnableReferentFields";

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
		public override object[] Parameters() => new object[] { InFeatureClass, FromReferentMethodField!, FromReferentLocationField!, FromReferentOffsetField!, ToReferentMethodField!, ToReferentLocationField!, ToReferentOffsetField!, OffsetUnits!, OutFeatureClass! };

		/// <summary>
		/// <para>Event Feature Class</para>
		/// <para>The feature class that will be used for the LRS event.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Referent Method Field</para>
		/// <para>The From referent method field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short")]
		public object? FromReferentMethodField { get; set; }

		/// <summary>
		/// <para>Referent Location Field</para>
		/// <para>The From referent location field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? FromReferentLocationField { get; set; }

		/// <summary>
		/// <para>Referent Offset Field</para>
		/// <para>The From referent offset field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? FromReferentOffsetField { get; set; }

		/// <summary>
		/// <para>To Referent Method Field</para>
		/// <para>The To referent method field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short")]
		public object? ToReferentMethodField { get; set; }

		/// <summary>
		/// <para>To Referent Location Field</para>
		/// <para>The To referent location field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? ToReferentLocationField { get; set; }

		/// <summary>
		/// <para>To Referent Offset Field</para>
		/// <para>The To referent offset field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? ToReferentOffsetField { get; set; }

		/// <summary>
		/// <para>Offset Units</para>
		/// <para>Specifies the offset units that will be used.</para>
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
		public object? OffsetUnits { get; set; }

		/// <summary>
		/// <para>Output Event Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

	}
}
