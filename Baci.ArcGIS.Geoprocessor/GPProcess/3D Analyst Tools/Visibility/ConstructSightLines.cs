using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Construct Sight Lines</para>
	/// <para>Construct Sight Lines</para>
	/// <para>Creates line features that represent sight lines from one or more observer points to features in a  target feature class.</para>
	/// </summary>
	public class ConstructSightLines : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InObserverPoints">
		/// <para>Observer Points</para>
		/// <para>The single-point features that represent observer points. Multipoint features are not supported.</para>
		/// </param>
		/// <param name="InTargetFeatures">
		/// <para>Target Features</para>
		/// <para>The target features (points, multipoints, lines, and polygons).</para>
		/// </param>
		/// <param name="OutLineFeatureClass">
		/// <para>Output</para>
		/// <para>The output feature class containing the sight lines.</para>
		/// </param>
		public ConstructSightLines(object InObserverPoints, object InTargetFeatures, object OutLineFeatureClass)
		{
			this.InObserverPoints = InObserverPoints;
			this.InTargetFeatures = InTargetFeatures;
			this.OutLineFeatureClass = OutLineFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Construct Sight Lines</para>
		/// </summary>
		public override string DisplayName() => "Construct Sight Lines";

		/// <summary>
		/// <para>Tool Name : ConstructSightLines</para>
		/// </summary>
		public override string ToolName() => "ConstructSightLines";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ConstructSightLines</para>
		/// </summary>
		public override string ExcuteName() => "3d.ConstructSightLines";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InObserverPoints, InTargetFeatures, OutLineFeatureClass, ObserverHeightField!, TargetHeightField!, JoinField!, SampleDistance!, OutputTheDirection!, SamplingMethod! };

		/// <summary>
		/// <para>Observer Points</para>
		/// <para>The single-point features that represent observer points. Multipoint features are not supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InObserverPoints { get; set; }

		/// <summary>
		/// <para>Target Features</para>
		/// <para>The target features (points, multipoints, lines, and polygons).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polyline", "Polygon")]
		public object InTargetFeatures { get; set; }

		/// <summary>
		/// <para>Output</para>
		/// <para>The output feature class containing the sight lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutLineFeatureClass { get; set; }

		/// <summary>
		/// <para>Observer Height Field</para>
		/// <para>The source of the height values for the observer points obtained from its attribute table.</para>
		/// <para>A default Observer Height Field field is selected from among the options listed below by order of priority. If multiple fields exist, and the desired field does not have a higher priority in the default field selection, the desired field will need to be specified.</para>
		/// <para>No Height Source—No Z values will be assigned to the resulting sight line features.</para>
		/// <para>Shape.Z</para>
		/// <para>Spot</para>
		/// <para>Z</para>
		/// <para>Z_Value</para>
		/// <para>Height</para>
		/// <para>Elev</para>
		/// <para>Elevation</para>
		/// <para>Contour</para>
		/// <para><see cref="ObserverHeightFieldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ObserverHeightField { get; set; } = "<None>";

		/// <summary>
		/// <para>Target Height Field</para>
		/// <para>The height field for the target.</para>
		/// <para>A default Target Height Field field is selected from among the options listed below by order of priority. If multiple fields exist, and the desired field does not have a higher priority in the default field selection, the desired field will need to be specified.</para>
		/// <para>No Height Source—No Z values will be assigned to the resulting sight line features.</para>
		/// <para>Shape.Z</para>
		/// <para>Spot</para>
		/// <para>Z</para>
		/// <para>Z_Value</para>
		/// <para>Height</para>
		/// <para>Elev</para>
		/// <para>Elevation</para>
		/// <para>Contour</para>
		/// <para><see cref="TargetHeightFieldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TargetHeightField { get; set; } = "<None>";

		/// <summary>
		/// <para>Join Field</para>
		/// <para>The join field is used to match observers to specific targets.</para>
		/// <para>No Join Field—No Z values will be assigned to the resulting sight line features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? JoinField { get; set; } = "<None>";

		/// <summary>
		/// <para>Sampling Distance</para>
		/// <para>The distance between samples when the target is either a line or polygon feature class. The Sampling Distance units are interpreted in the XY units of the output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = false, Value = 1.0000000000000001e-05)]
		public object? SampleDistance { get; set; } = "1";

		/// <summary>
		/// <para>Output The Direction</para>
		/// <para>Adds direction attributes to the output sight lines. Two additional fields will be added and populated to indicate direction: AZIMUTH and VERT_ANGLE (vertical angle).</para>
		/// <para>Unchecked—No direction attributes will be added to the output sight lines. This is the default.</para>
		/// <para>Checked—Two additional fields will be added and populated to indicate direction: azimuth and vertical angle.</para>
		/// <para><see cref="OutputTheDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? OutputTheDirection { get; set; } = "false";

		/// <summary>
		/// <para>Sampling Method</para>
		/// <para>Specifies how the sampling distance will be used to establish sight lines along the target feature.</para>
		/// <para>2D distance—The distance will be evaluated in two-dimensional Cartesian space. This is the default.</para>
		/// <para>3D distance—The distance will be evaluated in three-dimensional length.</para>
		/// <para><see cref="SamplingMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SamplingMethod { get; set; } = "2D_DISTANCE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConstructSightLines SetEnviroment(object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, int? autoCommit = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Observer Height Field</para>
		/// </summary>
		public enum ObserverHeightFieldEnum 
		{
			/// <summary>
			/// <para>No Height Source—No Z values will be assigned to the resulting sight line features.</para>
			/// </summary>
			[GPValue("<None>")]
			[Description("No Height Source")]
			No_Height_Source,

		}

		/// <summary>
		/// <para>Target Height Field</para>
		/// </summary>
		public enum TargetHeightFieldEnum 
		{
			/// <summary>
			/// <para>No Height Source—No Z values will be assigned to the resulting sight line features.</para>
			/// </summary>
			[GPValue("<None>")]
			[Description("No Height Source")]
			No_Height_Source,

		}

		/// <summary>
		/// <para>Output The Direction</para>
		/// </summary>
		public enum OutputTheDirectionEnum 
		{
			/// <summary>
			/// <para>Checked—Two additional fields will be added and populated to indicate direction: azimuth and vertical angle.</para>
			/// </summary>
			[GPValue("true")]
			[Description("OUTPUT_THE_DIRECTION")]
			OUTPUT_THE_DIRECTION,

			/// <summary>
			/// <para>Unchecked—No direction attributes will be added to the output sight lines. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_OUTPUT_THE_DIRECTION")]
			NOT_OUTPUT_THE_DIRECTION,

		}

		/// <summary>
		/// <para>Sampling Method</para>
		/// </summary>
		public enum SamplingMethodEnum 
		{
			/// <summary>
			/// <para>2D distance—The distance will be evaluated in two-dimensional Cartesian space. This is the default.</para>
			/// </summary>
			[GPValue("2D_DISTANCE")]
			[Description("2D distance")]
			_2D_distance,

			/// <summary>
			/// <para>3D distance—The distance will be evaluated in three-dimensional length.</para>
			/// </summary>
			[GPValue("3D_DISTANCE")]
			[Description("3D distance")]
			_3D_distance,

		}

#endregion
	}
}
