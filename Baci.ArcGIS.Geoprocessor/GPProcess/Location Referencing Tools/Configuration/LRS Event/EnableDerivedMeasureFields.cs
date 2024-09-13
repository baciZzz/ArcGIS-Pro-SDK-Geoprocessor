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
	/// <para>Enable Derived Measure Fields</para>
	/// <para>Enable Derived Measure Fields</para>
	/// <para>Enables fields to store the derived route ID, derived route name, and derived measure fields for the specified LRS event feature class.</para>
	/// </summary>
	public class EnableDerivedMeasureFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>LRS Event Feature Class</para>
		/// <para>An existing event feature class or feature layer that is registered to an LRS.</para>
		/// </param>
		public EnableDerivedMeasureFields(object InFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Enable Derived Measure Fields</para>
		/// </summary>
		public override string DisplayName() => "Enable Derived Measure Fields";

		/// <summary>
		/// <para>Tool Name : EnableDerivedMeasureFields</para>
		/// </summary>
		public override string ToolName() => "EnableDerivedMeasureFields";

		/// <summary>
		/// <para>Tool Excute Name : locref.EnableDerivedMeasureFields</para>
		/// </summary>
		public override string ExcuteName() => "locref.EnableDerivedMeasureFields";

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
		public override object[] Parameters() => new object[] { InFeatureClass, DerivedRouteIdField, DerivedRouteNameField, DerivedFromMeasureField, DerivedToMeasureField, OutFeatureClass };

		/// <summary>
		/// <para>LRS Event Feature Class</para>
		/// <para>An existing event feature class or feature layer that is registered to an LRS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Derived Route ID Field</para>
		/// <para>The derived route ID field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object DerivedRouteIdField { get; set; }

		/// <summary>
		/// <para>Derived Route Name Field</para>
		/// <para>The derived route name field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object DerivedRouteNameField { get; set; }

		/// <summary>
		/// <para>Derived (From) Measure Field</para>
		/// <para>The derived from measure field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object DerivedFromMeasureField { get; set; }

		/// <summary>
		/// <para>Derived To Measure Field</para>
		/// <para>The derived to measure field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object DerivedToMeasureField { get; set; }

		/// <summary>
		/// <para>Updated Input Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

	}
}
