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
	/// <para>Tabulate Intersection</para>
	/// <para>Tabulate Intersection</para>
	/// <para>Computes the intersection between two feature classes and cross tabulates the area, length, or count of the intersecting features.</para>
	/// </summary>
	public class TabulateIntersection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InZoneFeatures">
		/// <para>Input Zone Features</para>
		/// <para>The features used to identify zones.</para>
		/// </param>
		/// <param name="ZoneFields">
		/// <para>Zone Fields</para>
		/// <para>The attribute field or fields that will be used to define zones.</para>
		/// </param>
		/// <param name="InClassFeatures">
		/// <para>Input Class Features</para>
		/// <para>The features used to identify classes.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>The table that will contain the cross tabulation of intersections between zones and classes.</para>
		/// </param>
		public TabulateIntersection(object InZoneFeatures, object ZoneFields, object InClassFeatures, object OutTable)
		{
			this.InZoneFeatures = InZoneFeatures;
			this.ZoneFields = ZoneFields;
			this.InClassFeatures = InClassFeatures;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Tabulate Intersection</para>
		/// </summary>
		public override string DisplayName() => "Tabulate Intersection";

		/// <summary>
		/// <para>Tool Name : TabulateIntersection</para>
		/// </summary>
		public override string ToolName() => "TabulateIntersection";

		/// <summary>
		/// <para>Tool Excute Name : analysis.TabulateIntersection</para>
		/// </summary>
		public override string ExcuteName() => "analysis.TabulateIntersection";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "autoCommit", "configKeyword", "extent", "outputCoordinateSystem", "qualifiedFieldNames", "scratchWorkspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InZoneFeatures, ZoneFields, InClassFeatures, OutTable, ClassFields!, SumFields!, XyTolerance!, OutUnits! };

		/// <summary>
		/// <para>Input Zone Features</para>
		/// <para>The features used to identify zones.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InZoneFeatures { get; set; }

		/// <summary>
		/// <para>Zone Fields</para>
		/// <para>The attribute field or fields that will be used to define zones.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Date", "GUID")]
		public object ZoneFields { get; set; }

		/// <summary>
		/// <para>Input Class Features</para>
		/// <para>The features used to identify classes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InClassFeatures { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The table that will contain the cross tabulation of intersections between zones and classes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Class Fields</para>
		/// <para>The attribute field or fields used to define classes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Date", "GUID")]
		public object? ClassFields { get; set; }

		/// <summary>
		/// <para>Sum Fields</para>
		/// <para>The fields to sum from the Input Class Features parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? SumFields { get; set; }

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>The distance that determines the range in which features or their vertices are considered equal. By default, this is the XY Tolerance of the Input Zone Features parameter.</para>
		/// <para>Changing this parameter&apos;s value may cause failure or unexpected results. It is recommended that you do not modify this parameter. It has been removed from view on the tool dialog box. By default, the input feature class&apos;s spatial reference x,y tolerance property is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? XyTolerance { get; set; }

		/// <summary>
		/// <para>Output Units</para>
		/// <para>Specifies the units that will be used to calculate area or length measurements. Setting output units when the input class features are points is not supported.</para>
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
		public object? OutUnits { get; set; } = "UNKNOWN";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TabulateIntersection SetEnviroment(object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? outputCoordinateSystem = null , bool? qualifiedFieldNames = null , object? scratchWorkspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace);
			return this;
		}

	}
}
