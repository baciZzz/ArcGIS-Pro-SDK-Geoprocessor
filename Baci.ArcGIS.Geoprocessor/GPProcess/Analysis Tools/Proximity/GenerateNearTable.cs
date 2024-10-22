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
	/// <para>Generate Near Table</para>
	/// <para>Generate Near Table</para>
	/// <para>Calculates distances and other proximity information between features in one or more feature classes or layers. Unlike the Near tool, which modifies the input, Generate Near Table writes results to a new stand-alone table and supports finding more than one near feature.</para>
	/// </summary>
	public class GenerateNearTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input features that can be point, polyline, polygon, or multipoint type.</para>
		/// </param>
		/// <param name="NearFeatures">
		/// <para>Near Features</para>
		/// <para>One or more layers of a feature class containing near feature candidates. The near features can be point, polyline, polygon, or multipoint. If multiple layers or feature classes are specified, a NEAR_FC field will be added to the input table and will store the paths of the source feature class containing the nearest feature found. The same feature class or layer can be used as both input and near features.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>The output table containing the result of the analysis.</para>
		/// </param>
		public GenerateNearTable(object InFeatures, object NearFeatures, object OutTable)
		{
			this.InFeatures = InFeatures;
			this.NearFeatures = NearFeatures;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Near Table</para>
		/// </summary>
		public override string DisplayName() => "Generate Near Table";

		/// <summary>
		/// <para>Tool Name : GenerateNearTable</para>
		/// </summary>
		public override string ToolName() => "GenerateNearTable";

		/// <summary>
		/// <para>Tool Excute Name : analysis.GenerateNearTable</para>
		/// </summary>
		public override string ExcuteName() => "analysis.GenerateNearTable";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, NearFeatures, OutTable, SearchRadius!, Location!, Angle!, Closest!, ClosestCount!, Method! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features that can be point, polyline, polygon, or multipoint type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Near Features</para>
		/// <para>One or more layers of a feature class containing near feature candidates. The near features can be point, polyline, polygon, or multipoint. If multiple layers or feature classes are specified, a NEAR_FC field will be added to the input table and will store the paths of the source feature class containing the nearest feature found. The same feature class or layer can be used as both input and near features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object NearFeatures { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The output table containing the result of the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>The radius that will be used to search for near features. If no value is specified, all near features will be candidates. If a distance is entered, but the unit is left blank or set to Unknown, the units of the coordinate system of the input features will be used. If the Geodesic option is used for the Method parameter, use a linear unit such as kilometers or miles.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SearchRadius { get; set; }

		/// <summary>
		/// <para>Location</para>
		/// <para>Specifies whether x- and y-coordinates of the input feature&apos;s location and nearest location of the near feature will be written to the FROM_X, FROM_Y, NEAR_X, and NEAR_Y fields.</para>
		/// <para>Unchecked—Locations will not be written to the output table. This is the default.</para>
		/// <para>Checked—Locations will be written to the output table.</para>
		/// <para><see cref="LocationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Location { get; set; } = "false";

		/// <summary>
		/// <para>Angle</para>
		/// <para>Specifies whether the near angle will be calculated and written to the NEAR_ANGLE field in the output table. A near angle measures direction of the line connecting an input feature to its nearest feature at their closest locations. When the Planar method is used for the Method parameter, the angle is within the range of -180° to 180°, with 0° to the east, 90° to the north, 180° (or -180°) to the west, and -90° to the south. When the Geodesic method is used for the Method parameter, the angle is within the range of -180° to 180°, with 0° to the north, 90° to the east, 180° (or -180°) to the south, and -90° to the west.</para>
		/// <para>Unchecked—The NEAR_ANGLE field will not be added to the output table. This is the default.</para>
		/// <para>Checked—The NEAR_ANGLE field will be added to the output table.</para>
		/// <para><see cref="AngleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Angle { get; set; } = "false";

		/// <summary>
		/// <para>Find only closest feature</para>
		/// <para>Specifies whether only the closest feature will be written to the output table.</para>
		/// <para>Checked—Only the closest near feature will be written to the output table. This is the default.</para>
		/// <para>Unchecked—Multiple near features will be written to the output table (a limit can be specified in the Maximum number of closest matches parameter).</para>
		/// <para><see cref="ClosestEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Closest { get; set; } = "true";

		/// <summary>
		/// <para>Maximum number of closest matches</para>
		/// <para>Limits the number of near features reported for each input feature. This parameter is inactive if the Find only closest feature parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? ClosestCount { get; set; } = "0";

		/// <summary>
		/// <para>Method</para>
		/// <para>Specifies whether a shortest path on a spheroid (geodesic) or a flat earth (planar) distance method will be used. It is recommended that you use the Geodesic method for data stored in a coordinate system that is not appropriate for distance measurements (for example, Web Mercator and any geographic coordinate system) and for a dataset that spans a large geographic area.</para>
		/// <para>Planar—Planar distance will be used between features. This is the default.</para>
		/// <para>Geodesic—Geodesic distance will be used between features. This method takes into account the curvature of the spheroid and correctly deals with data near the international date line and the poles.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateNearTable SetEnviroment(object? extent = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Location</para>
		/// </summary>
		public enum LocationEnum 
		{
			/// <summary>
			/// <para>Checked—Locations will be written to the output table.</para>
			/// </summary>
			[GPValue("true")]
			[Description("LOCATION")]
			LOCATION,

			/// <summary>
			/// <para>Unchecked—Locations will not be written to the output table. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_LOCATION")]
			NO_LOCATION,

		}

		/// <summary>
		/// <para>Angle</para>
		/// </summary>
		public enum AngleEnum 
		{
			/// <summary>
			/// <para>Checked—The NEAR_ANGLE field will be added to the output table.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ANGLE")]
			ANGLE,

			/// <summary>
			/// <para>Unchecked—The NEAR_ANGLE field will not be added to the output table. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ANGLE")]
			NO_ANGLE,

		}

		/// <summary>
		/// <para>Find only closest feature</para>
		/// </summary>
		public enum ClosestEnum 
		{
			/// <summary>
			/// <para>Checked—Only the closest near feature will be written to the output table. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLOSEST")]
			CLOSEST,

			/// <summary>
			/// <para>Unchecked—Multiple near features will be written to the output table (a limit can be specified in the Maximum number of closest matches parameter).</para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL")]
			ALL,

		}

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Planar—Planar distance will be used between features. This is the default.</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("Planar")]
			Planar,

			/// <summary>
			/// <para>Geodesic—Geodesic distance will be used between features. This method takes into account the curvature of the spheroid and correctly deals with data near the international date line and the poles.</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic")]
			Geodesic,

		}

#endregion
	}
}
