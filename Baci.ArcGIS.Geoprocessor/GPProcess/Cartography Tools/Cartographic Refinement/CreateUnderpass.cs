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
	/// <para>Create Underpass</para>
	/// <para>Creates bridge parapets and polygon masks at line intersections to indicate underpasses.</para>
	/// </summary>
	public class CreateUnderpass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InAboveFeatures">
		/// <para>Input Above Features</para>
		/// <para>The input line feature layer containing lines that intersect—and will be symbolized as passing above—lines in the Input Below Features parameter.</para>
		/// </param>
		/// <param name="InBelowFeatures">
		/// <para>Input Below Features</para>
		/// <para>The input line feature layer that intersects—and will be symbolized as passing below—lines in the Input Above Features parameter. These features will be masked by the polygons created in the Output Underpass Feature Class parameter.</para>
		/// </param>
		/// <param name="MarginAlong">
		/// <para>Margin Along</para>
		/// <para>Sets the length of the mask polygons along the Input Above Features parameter by specifying the distance in page units that the mask should extend beyond the width of the stroke symbol of the Input Below Features parameter. The Margin Along parameter must be specified, and it must be greater than or equal to zero. Choose a page unit for the margin; the default is points.</para>
		/// </param>
		/// <param name="MarginAcross">
		/// <para>Margin Across</para>
		/// <para>Sets the width of the mask polygons across the Input Above Features parameter by specifying the distance in page units that the mask should extend beyond the width of the stroke symbol of the Input Below Features parameter. The Margin Across parameter must be specified, and it must be greater than or equal to zero. Choose a page unit for the margin; the default is points.</para>
		/// </param>
		/// <param name="OutUnderpassFeatureClass">
		/// <para>Output Underpass Feature Class</para>
		/// <para>The output feature class that will be created to store polygons to mask the Input Below Features parameter.</para>
		/// </param>
		/// <param name="OutMaskRelationshipClass">
		/// <para>Output Mask Relationship Class</para>
		/// <para>The output relationship class that will be created to store links between underpass mask polygons and the lines of the Input Below Features parameter.</para>
		/// </param>
		public CreateUnderpass(object InAboveFeatures, object InBelowFeatures, object MarginAlong, object MarginAcross, object OutUnderpassFeatureClass, object OutMaskRelationshipClass)
		{
			this.InAboveFeatures = InAboveFeatures;
			this.InBelowFeatures = InBelowFeatures;
			this.MarginAlong = MarginAlong;
			this.MarginAcross = MarginAcross;
			this.OutUnderpassFeatureClass = OutUnderpassFeatureClass;
			this.OutMaskRelationshipClass = OutMaskRelationshipClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Underpass</para>
		/// </summary>
		public override string DisplayName() => "Create Underpass";

		/// <summary>
		/// <para>Tool Name : CreateUnderpass</para>
		/// </summary>
		public override string ToolName() => "CreateUnderpass";

		/// <summary>
		/// <para>Tool Excute Name : cartography.CreateUnderpass</para>
		/// </summary>
		public override string ExcuteName() => "cartography.CreateUnderpass";

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
		public override string[] ValidEnvironments() => new string[] { "cartographicCoordinateSystem", "referenceScale" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InAboveFeatures, InBelowFeatures, MarginAlong, MarginAcross, OutUnderpassFeatureClass, OutMaskRelationshipClass, WhereClause, OutDecorationFeatureClass, WingType, WingTickLength };

		/// <summary>
		/// <para>Input Above Features</para>
		/// <para>The input line feature layer containing lines that intersect—and will be symbolized as passing above—lines in the Input Below Features parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPLayerDomain()]
		[GeometryType("Polyline")]
		public object InAboveFeatures { get; set; }

		/// <summary>
		/// <para>Input Below Features</para>
		/// <para>The input line feature layer that intersects—and will be symbolized as passing below—lines in the Input Above Features parameter. These features will be masked by the polygons created in the Output Underpass Feature Class parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPLayerDomain()]
		[GeometryType("Polyline")]
		public object InBelowFeatures { get; set; }

		/// <summary>
		/// <para>Margin Along</para>
		/// <para>Sets the length of the mask polygons along the Input Above Features parameter by specifying the distance in page units that the mask should extend beyond the width of the stroke symbol of the Input Below Features parameter. The Margin Along parameter must be specified, and it must be greater than or equal to zero. Choose a page unit for the margin; the default is points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object MarginAlong { get; set; }

		/// <summary>
		/// <para>Margin Across</para>
		/// <para>Sets the width of the mask polygons across the Input Above Features parameter by specifying the distance in page units that the mask should extend beyond the width of the stroke symbol of the Input Below Features parameter. The Margin Across parameter must be specified, and it must be greater than or equal to zero. Choose a page unit for the margin; the default is points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object MarginAcross { get; set; }

		/// <summary>
		/// <para>Output Underpass Feature Class</para>
		/// <para>The output feature class that will be created to store polygons to mask the Input Below Features parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutUnderpassFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Mask Relationship Class</para>
		/// <para>The output relationship class that will be created to store links between underpass mask polygons and the lines of the Input Below Features parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERelationshipClass()]
		public object OutMaskRelationshipClass { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>An SQL expression used to select a subset of features in the Input Above Features parameter.</para>
		/// <para>Use quotation marks—for example, &quot;MY_FIELD&quot;—or if you&apos;re querying personal geodatabases, enclose fields in square brackets—for example, [MY_FIELD].</para>
		/// <para>See SQL reference for query expressions used in ArcGIS for more information on SQL syntax.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Output Decoration Feature Class</para>
		/// <para>The output line feature class that will be created to store parapet features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutDecorationFeatureClass { get; set; }

		/// <summary>
		/// <para>Wing Type</para>
		/// <para>Specifies the wing style of the parapet features.</para>
		/// <para>Wing ticks angled between above and below features—The wing tick of the parapet will be angled between the Input Above Features parameter and the Input Below Features parameter. This is the default.</para>
		/// <para>Wing ticks parallel to below features—The wing tick of the underpass wing will be parallel to the Input Below Features parameter.</para>
		/// <para>No wing ticks created—No wing ticks will be created on the parapets.</para>
		/// <para><see cref="WingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object WingType { get; set; } = "ANGLED";

		/// <summary>
		/// <para>Wing Tick Length</para>
		/// <para>The length of the parapet wings in page units. The length must be greater than or equal to zero; the default length is 1. Choose a page unit (points, millimeters, and so on) for the length; the default is points. This parameter does not apply to the Wing Type value of NONE.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object WingTickLength { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateUnderpass SetEnviroment(object cartographicCoordinateSystem = null , object referenceScale = null )
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem, referenceScale: referenceScale);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Wing Type</para>
		/// </summary>
		public enum WingTypeEnum 
		{
			/// <summary>
			/// <para>Wing ticks angled between above and below features—The wing tick of the parapet will be angled between the Input Above Features parameter and the Input Below Features parameter. This is the default.</para>
			/// </summary>
			[GPValue("ANGLED")]
			[Description("Wing ticks angled between above and below features")]
			Wing_ticks_angled_between_above_and_below_features,

			/// <summary>
			/// <para>Wing ticks parallel to below features—The wing tick of the underpass wing will be parallel to the Input Below Features parameter.</para>
			/// </summary>
			[GPValue("PARALLEL")]
			[Description("Wing ticks parallel to below features")]
			Wing_ticks_parallel_to_below_features,

			/// <summary>
			/// <para>No wing ticks created—No wing ticks will be created on the parapets.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("No wing ticks created")]
			No_wing_ticks_created,

		}

#endregion
	}
}
