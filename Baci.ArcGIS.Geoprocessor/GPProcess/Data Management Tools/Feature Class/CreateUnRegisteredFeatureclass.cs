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
	/// <para>Create Unregistered Feature Class</para>
	/// <para>Creates an empty feature class in a database or enterprise geodatabase. The feature class is not registered with the geodatabase.</para>
	/// </summary>
	public class CreateUnRegisteredFeatureclass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutPath">
		/// <para>Feature Class Location</para>
		/// <para>The enterprise geodatabase or database in which the output feature class will be created.</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Feature Class Name</para>
		/// <para>The name of the feature class to be created.</para>
		/// </param>
		public CreateUnRegisteredFeatureclass(object OutPath, object OutName)
		{
			this.OutPath = OutPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Unregistered Feature Class</para>
		/// </summary>
		public override string DisplayName() => "Create Unregistered Feature Class";

		/// <summary>
		/// <para>Tool Name : CreateUnRegisteredFeatureclass</para>
		/// </summary>
		public override string ToolName() => "CreateUnRegisteredFeatureclass";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateUnRegisteredFeatureclass</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateUnRegisteredFeatureclass";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutPath, OutName, GeometryType, Template, HasM, HasZ, SpatialReference, ConfigKeyword, OutFeatureClass };

		/// <summary>
		/// <para>Feature Class Location</para>
		/// <para>The enterprise geodatabase or database in which the output feature class will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
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
		/// <para>Specifies the geometry type of the feature class. This parameter is only relevant for those geometry types that store dimensionality metadata, such as ST_Geometry in PostgreSQL, PostGIS Geometry, and Oracle SDO_Geometry.</para>
		/// <para>Point—The geometry type will be point.</para>
		/// <para>Multipoint—The geometry type will be multipoint.</para>
		/// <para>Polyline—The geometry type will be polyline.</para>
		/// <para>Polygon—The geometry type will be polygon. This is the default.</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GeometryType { get; set; } = "POLYGON";

		/// <summary>
		/// <para>Template Feature Class</para>
		/// <para>An existing feature class or list of feature classes with fields and attribute schema used to defined the fields in the output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Template { get; set; }

		/// <summary>
		/// <para>Has M</para>
		/// <para>Determines if the output feature class contains linear measurement values (M-values).</para>
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
		/// <para>Determines if the output feature class contains elevation values (Z-values).</para>
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
		/// <para>Spatial Reference</para>
		/// <para>The spatial reference of the output feature dataset. On the Spatial Reference Properties dialog box, you can select, import, or create a new coordinate system. To set aspects of the spatial reference, such as the x,y-, z-, or m-domain, resolution, or tolerance, use the Environments dialog box.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>Specifies the default storage parameters (configurations) for geodatabases in a relational database management system (RDBMS). This setting is applicable only when using enterprise geodatabase tables.</para>
		/// <para>Configuration keywords are set by the database administrator.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateUnRegisteredFeatureclass SetEnviroment(object configKeyword = null , object workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Geometry Type</para>
		/// </summary>
		public enum GeometryTypeEnum 
		{
			/// <summary>
			/// <para>Point—The geometry type will be point.</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("Point")]
			Point,

			/// <summary>
			/// <para>Multipoint—The geometry type will be multipoint.</para>
			/// </summary>
			[GPValue("MULTIPOINT")]
			[Description("Multipoint")]
			Multipoint,

			/// <summary>
			/// <para>Polygon—The geometry type will be polygon. This is the default.</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("Polygon")]
			Polygon,

			/// <summary>
			/// <para>Polyline—The geometry type will be polyline.</para>
			/// </summary>
			[GPValue("POLYLINE")]
			[Description("Polyline")]
			Polyline,

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
