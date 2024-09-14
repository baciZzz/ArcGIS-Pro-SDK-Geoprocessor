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
	/// <para>Delineate Built-Up Areas</para>
	/// <para>Delineate Built-Up Areas</para>
	/// <para>Creates polygons to represent built-up areas by delineating densely clustered arrangements of buildings on small-scale maps.</para>
	/// </summary>
	public class DelineateBuiltUpAreas : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InBuildings">
		/// <para>Input Building Layers</para>
		/// <para>The layers containing buildings with density and arrangement that are used to define appropriate output built-up polygons. Multiple building layers can be assessed simultaneously. Building features can be points or polygons.</para>
		/// </param>
		/// <param name="GroupingDistance">
		/// <para>Grouping Distance</para>
		/// <para>Buildings closer together than the grouping distance are considered collectively as candidates for representation by an output built-up area polygon. This distance is measured from the edges of polygon buildings and the centers of point buildings.</para>
		/// </param>
		/// <param name="MinimumDetailSize">
		/// <para>Minimum Detail Size</para>
		/// <para>The relative degree of detail in the output built-up area polygons. This is approximately to the minimum allowable diameter of a hole or cavity in the built-up area polygon. The actual size and shape of holes and cavities within the polygon is determined also by the arrangement of the input buildings, the grouping distance, and the presence of edge features if they are used.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing built-up area polygons representing clustered arrangements of input buildings.</para>
		/// </param>
		public DelineateBuiltUpAreas(object InBuildings, object GroupingDistance, object MinimumDetailSize, object OutFeatureClass)
		{
			this.InBuildings = InBuildings;
			this.GroupingDistance = GroupingDistance;
			this.MinimumDetailSize = MinimumDetailSize;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Delineate Built-Up Areas</para>
		/// </summary>
		public override string DisplayName() => "Delineate Built-Up Areas";

		/// <summary>
		/// <para>Tool Name : DelineateBuiltUpAreas</para>
		/// </summary>
		public override string ToolName() => "DelineateBuiltUpAreas";

		/// <summary>
		/// <para>Tool Excute Name : cartography.DelineateBuiltUpAreas</para>
		/// </summary>
		public override string ExcuteName() => "cartography.DelineateBuiltUpAreas";

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
		public override string[] ValidEnvironments() => new string[] { "cartographicPartitions", "referenceScale" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InBuildings, IdentifierField!, EdgeFeatures!, GroupingDistance, MinimumDetailSize, OutFeatureClass, MinimumBuildingCount! };

		/// <summary>
		/// <para>Input Building Layers</para>
		/// <para>The layers containing buildings with density and arrangement that are used to define appropriate output built-up polygons. Multiple building layers can be assessed simultaneously. Building features can be points or polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Point")]
		public object InBuildings { get; set; }

		/// <summary>
		/// <para>Identifier Field</para>
		/// <para>A field in the input feature classes that will hold a status code indicating whether the input feature is part of the resulting built-up area . This field must be either short or long integer type and common to all input layers if multiple input layers are used.</para>
		/// <para>0—The building is not represented by an output built-up area polygon.</para>
		/// <para>1—The building is represented by an output built-up area polygon and is within the resulting polygon.</para>
		/// <para>2—The building is represented by an output built-up area polygon and is outside the resulting polygon.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? IdentifierField { get; set; }

		/// <summary>
		/// <para>Edge Features</para>
		/// <para>The layers that will be used to define the edges of the built-up area polygons. Typically, these are roads, but other common examples are rivers, coastlines, and administrative areas. Built-up area polygons snap to an edge feature if one is generally aligned with the trend of the polygon edge and within the grouping distance away. Edge features can be lines or polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline")]
		public object? EdgeFeatures { get; set; }

		/// <summary>
		/// <para>Grouping Distance</para>
		/// <para>Buildings closer together than the grouping distance are considered collectively as candidates for representation by an output built-up area polygon. This distance is measured from the edges of polygon buildings and the centers of point buildings.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object GroupingDistance { get; set; }

		/// <summary>
		/// <para>Minimum Detail Size</para>
		/// <para>The relative degree of detail in the output built-up area polygons. This is approximately to the minimum allowable diameter of a hole or cavity in the built-up area polygon. The actual size and shape of holes and cavities within the polygon is determined also by the arrangement of the input buildings, the grouping distance, and the presence of edge features if they are used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object MinimumDetailSize { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing built-up area polygons representing clustered arrangements of input buildings.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Minimum Building Count</para>
		/// <para>The minimum number of buildings that must be collectively considered for representation by an output built-up area polygon. The default value is 4. The minimum building count must be greater than or equal to 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MinimumBuildingCount { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DelineateBuiltUpAreas SetEnviroment(object? cartographicPartitions = null, double? referenceScale = null)
		{
			base.SetEnv(cartographicPartitions: cartographicPartitions, referenceScale: referenceScale);
			return this;
		}

	}
}
