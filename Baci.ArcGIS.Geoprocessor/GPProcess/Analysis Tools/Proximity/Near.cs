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
	/// <para>Near</para>
	/// <para>Near</para>
	/// <para>Calculates distance and additional proximity information between the input features and the closest feature in another layer or feature class.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class Near : AbstractGPProcess
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
		/// <para>One or more feature layers or feature classes containing near feature candidates. The near features can be point, polyline, polygon, or multipoint. If multiple layers or feature classes are specified, the NEAR_FC field is added to the input table and will store the paths of the source feature class containing the nearest feature found. The same feature class or layer can be used as both input and near features.</para>
		/// </param>
		public Near(object InFeatures, object NearFeatures)
		{
			this.InFeatures = InFeatures;
			this.NearFeatures = NearFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Near</para>
		/// </summary>
		public override string DisplayName() => "Near";

		/// <summary>
		/// <para>Tool Name : Near</para>
		/// </summary>
		public override string ToolName() => "Near";

		/// <summary>
		/// <para>Tool Excute Name : analysis.Near</para>
		/// </summary>
		public override string ExcuteName() => "analysis.Near";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, NearFeatures, SearchRadius, Location, Angle, OutFeatureClass, Method, FieldNames };

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
		/// <para>One or more feature layers or feature classes containing near feature candidates. The near features can be point, polyline, polygon, or multipoint. If multiple layers or feature classes are specified, the NEAR_FC field is added to the input table and will store the paths of the source feature class containing the nearest feature found. The same feature class or layer can be used as both input and near features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object NearFeatures { get; set; }

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>The radius used to search for near features. If no value is specified, all near features are considered. If a distance but no unit or unknown is specified, the units of the coordinate system of the input features are used. If the Geodesic option is used for the Method parameter, use a linear unit such as kilometers or miles.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object SearchRadius { get; set; }

		/// <summary>
		/// <para>Location</para>
		/// <para>Specifies whether x- and y-coordinates of the closest location of the near feature will be written to the NEAR_X and NEAR_Y fields.</para>
		/// <para>Unchecked—Locations will not be written. This is the default.</para>
		/// <para>Checked—Locations will be written.</para>
		/// <para><see cref="LocationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Location { get; set; } = "false";

		/// <summary>
		/// <para>Angle</para>
		/// <para>Specifies whether the near angle will be calculated and written to a NEAR_ANGLE field in the output table. A near angle measures direction of the line connecting an input feature to its nearest feature at their closest location. When the Planar method is used in the Method parameter, the angle is within the range of -180° to 180°, with 0° to the east, 90° to the north, 180° (or -180°) to the west, and -90° to the south. When the Geodesic method is used, the angle is within the range of -180° to 180°, with 0° to the north, 90° to the east, 180° (or -180°) to the south, and -90° to the west.</para>
		/// <para>Unchecked—The NEAR_ANGLE field will not be added. This is the default.</para>
		/// <para>Checked—The NEAR_ANGLE field will be added.</para>
		/// <para><see cref="AngleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Angle { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>Specifies whether a shortest path will be used on a spheroid (geodesic) or a flat earth (planar) method. It is recommended that you use the Geodesic method with data stored in a coordinate system that is not appropriate for distance measurements (for example, Web Mercator or any geographic coordinate system) and any analysis that spans a large geographic area.</para>
		/// <para>Planar—Planar distances will be used between the features. This is the default.</para>
		/// <para>Geodesic—Geodesic distances will be used between features. This method takes into account the curvature of the spheroid and correctly deals with data near the dateline and poles.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Field Names</para>
		/// <para>Specifies the names of the attribute fields that will be added during processing.</para>
		/// <para>If this parameter is not used or any fields that will be added are excluded from this parameter, the default field names will be used.</para>
		/// <para>By default, NEAR_FID and NEAR_DIST fields will always be added, NEAR_X and NEAR_Y fields will be added when the Location parameter (location in Python) is enabled, the NEAR_ANGLE field will be added when the Angle parameter (angle in Python) is enabled, and the NEAR_FC field will be added when multiple inputs are used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object FieldNames { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Near SetEnviroment(object extent = null, object workspace = null)
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Location</para>
		/// </summary>
		public enum LocationEnum 
		{
			/// <summary>
			/// <para>Checked—Locations will be written.</para>
			/// </summary>
			[GPValue("true")]
			[Description("LOCATION")]
			LOCATION,

			/// <summary>
			/// <para>Unchecked—Locations will not be written. This is the default.</para>
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
			/// <para>Checked—The NEAR_ANGLE field will be added.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ANGLE")]
			ANGLE,

			/// <summary>
			/// <para>Unchecked—The NEAR_ANGLE field will not be added. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ANGLE")]
			NO_ANGLE,

		}

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Planar—Planar distances will be used between the features. This is the default.</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("Planar")]
			Planar,

			/// <summary>
			/// <para>Geodesic—Geodesic distances will be used between features. This method takes into account the curvature of the spheroid and correctly deals with data near the dateline and poles.</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic")]
			Geodesic,

		}

#endregion
	}
}
