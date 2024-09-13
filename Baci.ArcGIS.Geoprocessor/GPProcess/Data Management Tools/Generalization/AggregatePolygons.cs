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
	/// <para>Aggregate Polygons</para>
	/// <para>Aggregate Polygons</para>
	/// <para>Combines polygons within a specified distance to each other.</para>
	/// </summary>
	[Obsolete()]
	public class AggregatePolygons : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// </param>
		/// <param name="AggregationDistance">
		/// <para>Aggregation Distance</para>
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
		/// <para>Tool Excute Name : management.AggregatePolygons</para>
		/// </summary>
		public override string ExcuteName() => "management.AggregatePolygons";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, AggregationDistance, MinimumArea, MinimumHoleSize, OrthogonalityOption, BarrierFeatures, OutTable, AggregateField };

		/// <summary>
		/// <para>Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Aggregation Distance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object AggregationDistance { get; set; }

		/// <summary>
		/// <para>Minimum Area</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object MinimumArea { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Minimum Hole Size</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object MinimumHoleSize { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Preserve orthogonal shape</para>
		/// <para><see cref="OrthogonalityOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object OrthogonalityOption { get; set; } = "false";

		/// <summary>
		/// <para>Barrier Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object BarrierFeatures { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Aggregate Field</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "Date")]
		public object AggregateField { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Preserve orthogonal shape</para>
		/// </summary>
		public enum OrthogonalityOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ORTHOGONAL")]
			ORTHOGONAL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NON_ORTHOGONAL")]
			NON_ORTHOGONAL,

		}

#endregion
	}
}
