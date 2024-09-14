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
	/// <para>Geodetic Densify</para>
	/// <para>Geodetic Densify</para>
	/// <para>Creates new features by replacing input feature's segments with densified approximations of geodesic segments. Four type of geodesic segments can be constructed: Geodesic, Great Elliptic, Loxodrome, and Normal Section.</para>
	/// </summary>
	public class GeodeticDensify : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input line or polygon features.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing the densified geodesic features.</para>
		/// </param>
		/// <param name="GeodeticType">
		/// <para>Geodetic Type</para>
		/// <para>Specifies the type of geodetic segment to construct. Geodetic calculations are performed on the ellipsoid associated with the input data&apos;s coordinate system.</para>
		/// <para>Geodesic—The shortest distance between two points on the surface of the spheroid (ellipsoid).</para>
		/// <para>Loxodrome—The line of equal azimuth (from a pole) connecting the two points.</para>
		/// <para>Great elliptic— The line made by the intersection of a plane that contains the center of the spheroid and the two points.</para>
		/// <para>Normal section—The line made by the intersection of a plane that contains the center of the spheroid and is perpendicular to the surface at the first point.</para>
		/// <para><see cref="GeodeticTypeEnum"/></para>
		/// </param>
		public GeodeticDensify(object InFeatures, object OutFeatureClass, object GeodeticType)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.GeodeticType = GeodeticType;
		}

		/// <summary>
		/// <para>Tool Display Name : Geodetic Densify</para>
		/// </summary>
		public override string DisplayName() => "Geodetic Densify";

		/// <summary>
		/// <para>Tool Name : GeodeticDensify</para>
		/// </summary>
		public override string ToolName() => "GeodeticDensify";

		/// <summary>
		/// <para>Tool Excute Name : management.GeodeticDensify</para>
		/// </summary>
		public override string ExcuteName() => "management.GeodeticDensify";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, GeodeticType, Distance };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input line or polygon features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing the densified geodesic features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Geodetic Type</para>
		/// <para>Specifies the type of geodetic segment to construct. Geodetic calculations are performed on the ellipsoid associated with the input data&apos;s coordinate system.</para>
		/// <para>Geodesic—The shortest distance between two points on the surface of the spheroid (ellipsoid).</para>
		/// <para>Loxodrome—The line of equal azimuth (from a pole) connecting the two points.</para>
		/// <para>Great elliptic— The line made by the intersection of a plane that contains the center of the spheroid and the two points.</para>
		/// <para>Normal section—The line made by the intersection of a plane that contains the center of the spheroid and is perpendicular to the surface at the first point.</para>
		/// <para><see cref="GeodeticTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GeodeticType { get; set; } = "GEODESIC";

		/// <summary>
		/// <para>Distance</para>
		/// <para>The distance between vertices along the output geodesic segment. The default value is 50 kilometers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object Distance { get; set; } = "50 Kilometers";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GeodeticDensify SetEnviroment(object extent = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Geodetic Type</para>
		/// </summary>
		public enum GeodeticTypeEnum 
		{
			/// <summary>
			/// <para>Geodesic—The shortest distance between two points on the surface of the spheroid (ellipsoid).</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic")]
			Geodesic,

			/// <summary>
			/// <para>Loxodrome—The line of equal azimuth (from a pole) connecting the two points.</para>
			/// </summary>
			[GPValue("LOXODROME")]
			[Description("Loxodrome")]
			Loxodrome,

			/// <summary>
			/// <para>Great elliptic— The line made by the intersection of a plane that contains the center of the spheroid and the two points.</para>
			/// </summary>
			[GPValue("GREAT_ELLIPTIC")]
			[Description("Great elliptic")]
			Great_elliptic,

			/// <summary>
			/// <para>Normal section—The line made by the intersection of a plane that contains the center of the spheroid and is perpendicular to the surface at the first point.</para>
			/// </summary>
			[GPValue("NORMAL_SECTION")]
			[Description("Normal section")]
			Normal_section,

		}

#endregion
	}
}
