using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CartographyTools
{
	/// <summary>
	/// <para>Collapse Hydro Polygons</para>
	/// <para>Collapse Hydro Polygons</para>
	/// <para>Collapse Hydro Polygons</para>
	/// </summary>
	[Obsolete()]
	public class CollapseHydroPolygons : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPolygons">
		/// <para>Input Hydro Polygons</para>
		/// </param>
		/// <param name="CollapseDist">
		/// <para>Minimum width for collapsing</para>
		/// </param>
		/// <param name="OutPolygonFeatureClass">
		/// <para>Output Polygon Feature Class</para>
		/// </param>
		/// <param name="OutLineFeatureClass">
		/// <para>Output Line Feature Class</para>
		/// </param>
		public CollapseHydroPolygons(object InPolygons, object CollapseDist, object OutPolygonFeatureClass, object OutLineFeatureClass)
		{
			this.InPolygons = InPolygons;
			this.CollapseDist = CollapseDist;
			this.OutPolygonFeatureClass = OutPolygonFeatureClass;
			this.OutLineFeatureClass = OutLineFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Collapse Hydro Polygons</para>
		/// </summary>
		public override string DisplayName() => "Collapse Hydro Polygons";

		/// <summary>
		/// <para>Tool Name : CollapseHydroPolygons</para>
		/// </summary>
		public override string ToolName() => "CollapseHydroPolygons";

		/// <summary>
		/// <para>Tool Excute Name : cartography.CollapseHydroPolygons</para>
		/// </summary>
		public override string ExcuteName() => "cartography.CollapseHydroPolygons";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise() => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPolygons, InLines, CollapseDist, CollapseDistTol, ContextRatio, OutPolygonFeatureClass, OutLineFeatureClass };

		/// <summary>
		/// <para>Input Hydro Polygons</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InPolygons { get; set; }

		/// <summary>
		/// <para>Input Hydro Lines</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLines { get; set; }

		/// <summary>
		/// <para>Minimum width for collapsing</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object CollapseDist { get; set; }

		/// <summary>
		/// <para>Minimum width tolerance %</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 1)]
		public object CollapseDistTol { get; set; }

		/// <summary>
		/// <para>Context decision ratio (length/width)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ContextRatio { get; set; }

		/// <summary>
		/// <para>Output Polygon Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object OutPolygonFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Line Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object OutLineFeatureClass { get; set; }

	}
}
