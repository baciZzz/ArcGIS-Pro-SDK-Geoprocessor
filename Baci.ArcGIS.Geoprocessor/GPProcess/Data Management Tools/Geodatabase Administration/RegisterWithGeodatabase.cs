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
	/// <para>Register with Geodatabase</para>
	/// <para>Registers with the geodatabase the feature classes, tables, views, and raster layers that were created in the database using third-party tools or views created with the  Create Database View  tool. Once registered, information about the items—such as table and column names, spatial extent, and geometry type—is stored in the geodatabase's system tables, allowing these registered items to participate in geodatabase functionality.</para>
	/// </summary>
	public class RegisterWithGeodatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Datasets</para>
		/// <para>The feature class, table, view, or raster created using third-party tools or SQL, or the view created using the Create Database View tool that will be registered with the geodatabase. The dataset must exist in the same database as the geodatabase.</para>
		/// </param>
		public RegisterWithGeodatabase(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Register with Geodatabase</para>
		/// </summary>
		public override string DisplayName => "Register with Geodatabase";

		/// <summary>
		/// <para>Tool Name : RegisterWithGeodatabase</para>
		/// </summary>
		public override string ToolName => "RegisterWithGeodatabase";

		/// <summary>
		/// <para>Tool Excute Name : management.RegisterWithGeodatabase</para>
		/// </summary>
		public override string ExcuteName => "management.RegisterWithGeodatabase";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InDataset, RegDataset, InObjectIdField, InShapeField, InGeometryType, InSpatialReference, InExtent };

		/// <summary>
		/// <para>Input Datasets</para>
		/// <para>The feature class, table, view, or raster created using third-party tools or SQL, or the view created using the Create Database View tool that will be registered with the geodatabase. The dataset must exist in the same database as the geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Registered Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object RegDataset { get; set; }

		/// <summary>
		/// <para>Object ID Field</para>
		/// <para>The field that will be used as the ObjectID field. This input is required when registering a view, and you must supply an existing integer field. This parameter is optional when registering other dataset types; if you use an existing field, it must be an integer data type. If an existing field is not supplied when registering these other dataset types, an ObjectID field will be created and populated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object InObjectIdField { get; set; }

		/// <summary>
		/// <para>Shape Field</para>
		/// <para>If the input dataset contains a spatial data type column, include this field during the registration process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object InShapeField { get; set; }

		/// <summary>
		/// <para>Geometry Type</para>
		/// <para>Specifies the geometry type. If the Shape Field parameter value is present, you must specify a geometry type. Supported geometry types are point, multipoint, polygon, and polyline. If the dataset being registered contains existing features, the geometry type specified must match the entity type of these features.</para>
		/// <para><see cref="InGeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InGeometryType { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>If the Shape Field parameter value is present and the table is empty, specify the coordinate system to be used for features. If the dataset being registered contains existing features, the coordinate system specified must match the coordinate system of the existing features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object InSpatialReference { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>If the Shape Field parameter value is present, specify the allowable coordinate range for x,y coordinates. If the dataset being registered contains existing features, the extent of the existing features will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEnvelope()]
		public object InExtent { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RegisterWithGeodatabase SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Geometry Type</para>
		/// </summary>
		public enum InGeometryTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("POINT")]
			[Description("Point")]
			Point,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("MULTIPOINT")]
			[Description("Multipoint")]
			Multipoint,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("Polygon")]
			Polygon,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("POLYLINE")]
			[Description("Polyline")]
			Polyline,

		}

#endregion
	}
}
