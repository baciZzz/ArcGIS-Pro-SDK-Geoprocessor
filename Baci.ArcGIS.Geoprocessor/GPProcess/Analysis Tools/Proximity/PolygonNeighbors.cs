using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Polygon Neighbors</para>
	/// <para>Polygon Neighbors</para>
	/// <para>Creates a table with statistics based on polygon contiguity (overlaps, coincident edges, or nodes).</para>
	/// </summary>
	public class PolygonNeighbors : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input polygon features.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>The output table.</para>
		/// </param>
		public PolygonNeighbors(object InFeatures, object OutTable)
		{
			this.InFeatures = InFeatures;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Polygon Neighbors</para>
		/// </summary>
		public override string DisplayName() => "Polygon Neighbors";

		/// <summary>
		/// <para>Tool Name : PolygonNeighbors</para>
		/// </summary>
		public override string ToolName() => "PolygonNeighbors";

		/// <summary>
		/// <para>Tool Excute Name : analysis.PolygonNeighbors</para>
		/// </summary>
		public override string ExcuteName() => "analysis.PolygonNeighbors";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise() => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "extent", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutTable, InFields, AreaOverlap, BothSides, ClusterTolerance, OutLinearUnits, OutAreaUnits };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input polygon features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The output table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Report By Field(s)</para>
		/// <para>The input attribute field or fields that will be used to identify unique polygons or polygon groups and represent them in the output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Date")]
		public object InFields { get; set; }

		/// <summary>
		/// <para>Include area overlaps</para>
		/// <para>Specifies whether overlapping area relationships will be analyzed and included in the output.</para>
		/// <para>Unchecked—Overlapping relationships will not be analyzed or included in the output. This is the default.</para>
		/// <para>Checked—Overlapping relationships will be analyzed and included in the output.</para>
		/// <para><see cref="AreaOverlapEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AreaOverlap { get; set; } = "false";

		/// <summary>
		/// <para>Include both sides of neighbor relationship</para>
		/// <para>Specifies whether both sides of neighbor relationships will be included in the output.</para>
		/// <para>Checked—For a pair of neighboring polygons, both neighboring information of one polygon being the source and the other being the neighbor and vice versa will be included. This is the default.</para>
		/// <para>Unchecked—For a pair of neighboring polygons, only neighboring information of one polygon being the source and the other being the neighbor will be included. The reciprocal relationship will not be included.</para>
		/// <para><see cref="BothSidesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object BothSides { get; set; } = "true";

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>The minimum distance between coordinates before they will be considered equal. By default, this is the x,y tolerance of the input features.</para>
		/// <para>Changing this parameter&apos;s value may cause failure or unexpected results. It is recommended that this parameter not be modified. It has been removed from view in the tool dialog. By default, the input feature class&apos;s spatial reference x,y tolerance property is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object ClusterTolerance { get; set; }

		/// <summary>
		/// <para>Output Linear Units</para>
		/// <para>Specifies the units that will be used to report the total length of the coincident edge between neighboring polygons. The default is the input feature units.</para>
		/// <para>Unknown—The units will be unknown.</para>
		/// <para>Inches—The units will be inches.</para>
		/// <para>Feet—The units will be feet.</para>
		/// <para>Yards—The units will be yards.</para>
		/// <para>Miles—The units will be miles.</para>
		/// <para>Nautical miles—The units will be nautical miles.</para>
		/// <para>Millimeters—The units will be millimeters.</para>
		/// <para>Centimeters—The units will be centimeters.</para>
		/// <para>Decimeters—The units will be decimeters.</para>
		/// <para>Meters—The units will be meters.</para>
		/// <para>Kilometers—The units will be kilometers.</para>
		/// <para>Decimal degrees—The units will be decimal degrees.</para>
		/// <para>Points—The units will be points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutLinearUnits { get; set; } = "UNKNOWN";

		/// <summary>
		/// <para>Output Area Units</para>
		/// <para>Specifies the units that will be used to report the area overlap of neighboring polygons. The default is the input feature units. This parameter is only active when the Include area overlaps parameter is checked.</para>
		/// <para>Unknown—The units will be unknown.</para>
		/// <para>Ares—The units will be ares.</para>
		/// <para>Acres—The units will be acres.</para>
		/// <para>Hectares—The units will be hectares.</para>
		/// <para>Square inches—The units will be square inches.</para>
		/// <para>Square feet—The units will be square feet.</para>
		/// <para>Square yards—The units will be square yards.</para>
		/// <para>Square miles—The units will be square miles.</para>
		/// <para>Square millimeters—The units will be square millimeters.</para>
		/// <para>Square centimeters—The units will be square centimeters.</para>
		/// <para>Square decimeters—The units will be square decimeters.</para>
		/// <para>Square meters—The units will be square meters.</para>
		/// <para>Square kilometers—The units will be square kilometers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutAreaUnits { get; set; } = "UNKNOWN";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PolygonNeighbors SetEnviroment(int? autoCommit = null, object extent = null, bool? qualifiedFieldNames = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, extent: extent, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Include area overlaps</para>
		/// </summary>
		public enum AreaOverlapEnum 
		{
			/// <summary>
			/// <para>Checked—Overlapping relationships will be analyzed and included in the output.</para>
			/// </summary>
			[GPValue("true")]
			[Description("AREA_OVERLAP")]
			AREA_OVERLAP,

			/// <summary>
			/// <para>Unchecked—Overlapping relationships will not be analyzed or included in the output. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_AREA_OVERLAP")]
			NO_AREA_OVERLAP,

		}

		/// <summary>
		/// <para>Include both sides of neighbor relationship</para>
		/// </summary>
		public enum BothSidesEnum 
		{
			/// <summary>
			/// <para>Checked—For a pair of neighboring polygons, both neighboring information of one polygon being the source and the other being the neighbor and vice versa will be included. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("BOTH_SIDES")]
			BOTH_SIDES,

			/// <summary>
			/// <para>Unchecked—For a pair of neighboring polygons, only neighboring information of one polygon being the source and the other being the neighbor will be included. The reciprocal relationship will not be included.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_BOTH_SIDES")]
			NO_BOTH_SIDES,

		}

#endregion
	}
}
