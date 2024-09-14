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
	/// <para>Aggregate Polygons</para>
	/// <para>Aggregate Polygons</para>
	/// <para>Combines polygons that are within a specified distance of each other into new polygons.</para>
	/// </summary>
	public class AggregatePolygons : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The polygon features to be aggregated. If this is a layer referencing a representation and shape overrides are present on the input features, the overridden shapes, not the feature shapes, will be considered in aggregation processing.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class to be created.</para>
		/// </param>
		/// <param name="AggregationDistance">
		/// <para>Aggregation Distance</para>
		/// <para>The distance to be satisfied between polygon boundaries for aggregation to occur. A distance must be specified, and it must be greater than zero. You can choose a preferred unit; the default is the feature unit.</para>
		/// </param>
		public AggregatePolygons(object InFeatures, object OutFeatureClass, object AggregationDistance)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.AggregationDistance = AggregationDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : Aggregate Polygons</para>
		/// </summary>
		public override string DisplayName() => "Aggregate Polygons";

		/// <summary>
		/// <para>Tool Name : AggregatePolygons</para>
		/// </summary>
		public override string ToolName() => "AggregatePolygons";

		/// <summary>
		/// <para>Tool Excute Name : cartography.AggregatePolygons</para>
		/// </summary>
		public override string ExcuteName() => "cartography.AggregatePolygons";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "XYDomain", "XYTolerance", "cartographicPartitions", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, AggregationDistance, MinimumArea!, MinimumHoleSize!, OrthogonalityOption!, BarrierFeatures!, OutTable!, AggregateField! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The polygon features to be aggregated. If this is a layer referencing a representation and shape overrides are present on the input features, the overridden shapes, not the feature shapes, will be considered in aggregation processing.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Aggregation Distance</para>
		/// <para>The distance to be satisfied between polygon boundaries for aggregation to occur. A distance must be specified, and it must be greater than zero. You can choose a preferred unit; the default is the feature unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object AggregationDistance { get; set; }

		/// <summary>
		/// <para>Minimum Area</para>
		/// <para>The minimum area for an aggregated polygon to be retained. The default value is zero, that is, to keep all polygons. You can specify a preferred unit; the default is the feature unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object? MinimumArea { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Minimum Hole Size</para>
		/// <para>The minimum size of a polygon hole to be retained. The default value is zero, that is, to keep all polygon holes. You can specify a preferred unit; the default is the feature unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object? MinimumHoleSize { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Preserve orthogonal shape</para>
		/// <para>Specifies the characteristic of the output features when constructing the aggregated boundaries.</para>
		/// <para>Unchecked--Organically shaped output features will be created. This is suitable for natural features, such as vegetation or soil polygons. This is the default.</para>
		/// <para>Checked--Orthogonally shaped output features will be created. This is suitable for preserving the geometric characteristic of anthropogenic input features, such as building footprints.</para>
		/// <para><see cref="OrthogonalityOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? OrthogonalityOption { get; set; } = "false";

		/// <summary>
		/// <para>Barrier Features</para>
		/// <para>The layers containing the line or polygon features that are aggregation barriers for input features. Features will not be aggregated across barrier features. Barrier features that are in geometric conflict with input features will be ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object? BarrierFeatures { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>A one-to-many relationship table that links the aggregated polygons to their source polygon features. This table contains two fields, OUTPUT_FID and INPUT_FID, that store the aggregated feature IDs and their source feature IDs, respectively. Use this table to derive necessary attributes for the output features from their source features. The default name for this table is the name of the output feature class, appended with _tbl. The default path is the same as the output feature class. If the output features location is specified in a feature dataset, this table will be created one level higher, at the geodatabase level. No table is created when this parameter is left blank.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Aggregate Field</para>
		/// <para>The field that contains attributes for aggregation. Features must share the same attribute value to be considered for aggregation. For example, use a building classification field as the aggregate field to prevent commercial buildings from aggregating with residential buildings.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "Date")]
		public object? AggregateField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AggregatePolygons SetEnviroment(object? MDomain = null, object? XYDomain = null, object? XYTolerance = null, object? cartographicPartitions = null, object? extent = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(MDomain: MDomain, XYDomain: XYDomain, XYTolerance: XYTolerance, cartographicPartitions: cartographicPartitions, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Preserve orthogonal shape</para>
		/// </summary>
		public enum OrthogonalityOptionEnum 
		{
			/// <summary>
			/// <para>Checked--Orthogonally shaped output features will be created. This is suitable for preserving the geometric characteristic of anthropogenic input features, such as building footprints.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ORTHOGONAL")]
			ORTHOGONAL,

			/// <summary>
			/// <para>Unchecked--Organically shaped output features will be created. This is suitable for natural features, such as vegetation or soil polygons. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NON_ORTHOGONAL")]
			NON_ORTHOGONAL,

		}

#endregion
	}
}
