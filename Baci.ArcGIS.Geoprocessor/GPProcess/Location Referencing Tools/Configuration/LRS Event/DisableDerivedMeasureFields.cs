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
	/// <para>Disable Derived Measure Fields</para>
	/// <para>Disable Derived Measure Fields</para>
	/// <para>Disables fields that store the derived network route ID, route name, and measure fields.</para>
	/// </summary>
	public class DisableDerivedMeasureFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>LRS Event Feature Class</para>
		/// <para>An existing event feature class or feature layer that is registered to an LRS.</para>
		/// </param>
		public DisableDerivedMeasureFields(object InFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Disable Derived Measure Fields</para>
		/// </summary>
		public override string DisplayName() => "Disable Derived Measure Fields";

		/// <summary>
		/// <para>Tool Name : DisableDerivedMeasureFields</para>
		/// </summary>
		public override string ToolName() => "DisableDerivedMeasureFields";

		/// <summary>
		/// <para>Tool Excute Name : locref.DisableDerivedMeasureFields</para>
		/// </summary>
		public override string ExcuteName() => "locref.DisableDerivedMeasureFields";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureClass, OutFeatureClass };

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
		/// <para>Updated Input Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

	}
}
