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
	/// <para>Create Feature Class</para>
	/// <para>Create Feature Class</para>
	/// <para>Creates an empty feature class in a geodatabase or a shapefile in a folder.</para>
	/// </summary>
	public class CreateFeatureclass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutPath">
		/// <para>Feature Class Location</para>
		/// <para>The enterprise or file geodatabase or the folder in which the output feature class will be created. This workspace must already exist.</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Feature Class Name</para>
		/// <para>The name of the feature class to be created.</para>
		/// </param>
		public CreateFeatureclass(object OutPath, object OutName)
		{
			this.OutPath = OutPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Feature Class</para>
		/// </summary>
		public override string DisplayName() => "Create Feature Class";

		/// <summary>
		/// <para>Tool Name : CreateFeatureclass</para>
		/// </summary>
		public override string ToolName() => "CreateFeatureclass";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateFeatureclass</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateFeatureclass";

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
		public override string[] ValidEnvironments() => new string[] { "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "configKeyword", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutPath, OutName, GeometryType, Template, HasM, HasZ, SpatialReference, ConfigKeyword, SpatialGrid1, SpatialGrid2, SpatialGrid3, OutFeatureClass, OutAlias };

		/// <summary>
		/// <para>Feature Class Location</para>
		/// <para>The enterprise or file geodatabase or the folder in which the output feature class will be created. This workspace must already exist.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object OutPath { get; set; }

		/// <summary>
		/// <para>Feature Class Name</para>
		/// <para>The name of the feature class to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Geometry Type</para>
		/// <para>Specifies the geometry type of the feature class.</para>
		/// <para>Point—The geometry type is point.</para>
		/// <para>Multipoint—The geometry type is multipoint.</para>
		/// <para>Polygon—The geometry type is polygon.</para>
		/// <para>Polyline—The geometry type is polyline.</para>
		/// <para>Multipatch—The geometry type is multipatch.</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GeometryType { get; set; } = "POLYGON";

		/// <summary>
		/// <para>Template Dataset</para>
		/// <para>The feature class or table used as a template to define the attribute fields of the new feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Template { get; set; }

		/// <summary>
		/// <para>Has M</para>
		/// <para>Specifies whether the feature class contains linear measurement values (m-values).</para>
		/// <para>No—The output feature class will not have M-values. This is the default.</para>
		/// <para>Yes—The output feature class will have M-values.</para>
		/// <para>Same as the template feature class—The output feature class will have M-values if the dataset specified in the Template Feature Class parameter (template parameter in Python) has M-values.</para>
		/// <para><see cref="HasMEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object HasM { get; set; } = "DISABLED";

		/// <summary>
		/// <para>Has Z</para>
		/// <para>Specifies whether the feature class contains elevation values (z-values).</para>
		/// <para>No—The output feature class will not have Z-values. This is the default.</para>
		/// <para>Yes—The output feature class will have Z-values.</para>
		/// <para>Same as the template feature class—The output feature class will have Z-values if the dataset specified in the Template Feature Class parameter (template parameter in Python) has Z-values.</para>
		/// <para><see cref="HasZEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object HasZ { get; set; } = "DISABLED";

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>The spatial reference of the output feature dataset. On the Spatial Reference Properties dialog box, you can select, import, or create a new coordinate system. To set aspects of the spatial reference, such as the x,y-, z-, or m-domain, resolution, or tolerance, use the Environments dialog box.</para>
		/// <para>If a spatial reference is not provided, the output will have an undefined spatial reference.</para>
		/// <para>The spatial reference of the Template Feature Class has no effect on the output spatial reference. If you want your output to be in the coordinate system of the Template Feature Class, set the Coordinate System parameter to the spatial reference of the Template Feature Class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>The configuration keyword applies to enterprise geodatabase data only. It determines the storage parameters of the database table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Geodatabase Settings (optional)")]
		public object ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Output Spatial Grid 1</para>
		/// <para>This parameter has been deprecated in ArcGIS Pro. Any value you enter is ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Geodatabase Settings (optional)")]
		public object SpatialGrid1 { get; set; } = "0";

		/// <summary>
		/// <para>Output Spatial Grid 2</para>
		/// <para>This parameter has been deprecated in ArcGIS Pro. Any value you enter is ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Geodatabase Settings (optional)")]
		public object SpatialGrid2 { get; set; } = "0";

		/// <summary>
		/// <para>Output Spatial Grid 3</para>
		/// <para>This parameter has been deprecated in ArcGIS Pro. Any value you enter is ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Geodatabase Settings (optional)")]
		public object SpatialGrid3 { get; set; } = "0";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Feature Class Alias</para>
		/// <para>The alternate name for the output feature class that will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object OutAlias { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateFeatureclass SetEnviroment(object MResolution = null, object MTolerance = null, object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZResolution = null, object ZTolerance = null, object configKeyword = null, object geographicTransformations = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null)
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, configKeyword: configKeyword, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Geometry Type</para>
		/// </summary>
		public enum GeometryTypeEnum 
		{
			/// <summary>
			/// <para>Point—The geometry type is point.</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("Point")]
			Point,

			/// <summary>
			/// <para>Multipoint—The geometry type is multipoint.</para>
			/// </summary>
			[GPValue("MULTIPOINT")]
			[Description("Multipoint")]
			Multipoint,

			/// <summary>
			/// <para>Polygon—The geometry type is polygon.</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("Polygon")]
			Polygon,

			/// <summary>
			/// <para>Polyline—The geometry type is polyline.</para>
			/// </summary>
			[GPValue("POLYLINE")]
			[Description("Polyline")]
			Polyline,

			/// <summary>
			/// <para>Multipatch—The geometry type is multipatch.</para>
			/// </summary>
			[GPValue("MULTIPATCH")]
			[Description("Multipatch")]
			Multipatch,

		}

		/// <summary>
		/// <para>Has M</para>
		/// </summary>
		public enum HasMEnum 
		{
			/// <summary>
			/// <para>No—The output feature class will not have M-values. This is the default.</para>
			/// </summary>
			[GPValue("DISABLED")]
			[Description("No")]
			No,

			/// <summary>
			/// <para>Same as the template feature class—The output feature class will have M-values if the dataset specified in the Template Feature Class parameter (template parameter in Python) has M-values.</para>
			/// </summary>
			[GPValue("SAME_AS_TEMPLATE")]
			[Description("Same as the template feature class")]
			Same_as_the_template_feature_class,

			/// <summary>
			/// <para>Yes—The output feature class will have M-values.</para>
			/// </summary>
			[GPValue("ENABLED")]
			[Description("Yes")]
			Yes,

		}

		/// <summary>
		/// <para>Has Z</para>
		/// </summary>
		public enum HasZEnum 
		{
			/// <summary>
			/// <para>No—The output feature class will not have Z-values. This is the default.</para>
			/// </summary>
			[GPValue("DISABLED")]
			[Description("No")]
			No,

			/// <summary>
			/// <para>Same as the template feature class—The output feature class will have Z-values if the dataset specified in the Template Feature Class parameter (template parameter in Python) has Z-values.</para>
			/// </summary>
			[GPValue("SAME_AS_TEMPLATE")]
			[Description("Same as the template feature class")]
			Same_as_the_template_feature_class,

			/// <summary>
			/// <para>Yes—The output feature class will have Z-values.</para>
			/// </summary>
			[GPValue("ENABLED")]
			[Description("Yes")]
			Yes,

		}

#endregion
	}
}
