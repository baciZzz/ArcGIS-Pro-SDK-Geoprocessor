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
	/// <para>Create SQLite Database</para>
	/// <para>Create SQLite Database</para>
	/// <para>Creates a GeoPackage or an SQLite database that contains the ST_Geometry or SpatiaLite spatial type.</para>
	/// </summary>
	public class CreateSQLiteDatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutDatabaseName">
		/// <para>Output Database Name</para>
		/// <para>The location of the SQLite database or GeoPackage to be created and the name of the file. The .sqlite extension will be automatically assigned if the Spatial Type parameter value is ST_Geometry or SpatiaLite. If the Spatial Type parameter value is GeoPackage or any of the GeoPackage versions, the .gpkg extension will be automatically assigned.</para>
		/// </param>
		public CreateSQLiteDatabase(object OutDatabaseName)
		{
			this.OutDatabaseName = OutDatabaseName;
		}

		/// <summary>
		/// <para>Tool Display Name : Create SQLite Database</para>
		/// </summary>
		public override string DisplayName() => "Create SQLite Database";

		/// <summary>
		/// <para>Tool Name : CreateSQLiteDatabase</para>
		/// </summary>
		public override string ToolName() => "CreateSQLiteDatabase";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateSQLiteDatabase</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateSQLiteDatabase";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutDatabaseName, SpatialType };

		/// <summary>
		/// <para>Output Database Name</para>
		/// <para>The location of the SQLite database or GeoPackage to be created and the name of the file. The .sqlite extension will be automatically assigned if the Spatial Type parameter value is ST_Geometry or SpatiaLite. If the Spatial Type parameter value is GeoPackage or any of the GeoPackage versions, the .gpkg extension will be automatically assigned.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object OutDatabaseName { get; set; }

		/// <summary>
		/// <para>Spatial Type</para>
		/// <para>Specifies the spatial type that will be installed with the new SQLite database or the GeoPackage version that will be created.</para>
		/// <para>ST_Geometry—The Esri spatial storage type will be installed. This is the default.</para>
		/// <para>SpatiaLite—SpatiaLite spatial storage type will be installed.</para>
		/// <para>GeoPackage (equivalent to GeoPackage 1.3)—An OGC GeoPackage 1.3 dataset is created.</para>
		/// <para>GeoPackage 1.0—An OGC GeoPackage 1.0 dataset will be created.</para>
		/// <para>GeoPackage 1.1—An OGC GeoPackage 1.1 dataset will be created.</para>
		/// <para>GeoPackage 1.2.1—An OGC GeoPackage 1.2.1 dataset will be created.</para>
		/// <para>GeoPackage 1.3—An OGC GeoPackage 1.3 dataset will be created.</para>
		/// <para><see cref="SpatialTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SpatialType { get; set; } = "ST_GEOMETRY";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateSQLiteDatabase SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Spatial Type</para>
		/// </summary>
		public enum SpatialTypeEnum 
		{
			/// <summary>
			/// <para>ST_Geometry—The Esri spatial storage type will be installed. This is the default.</para>
			/// </summary>
			[GPValue("ST_GEOMETRY")]
			[Description("ST_Geometry")]
			ST_Geometry,

			/// <summary>
			/// <para>SpatiaLite—SpatiaLite spatial storage type will be installed.</para>
			/// </summary>
			[GPValue("SPATIALITE")]
			[Description("SpatiaLite")]
			SpatiaLite,

			/// <summary>
			/// <para>GeoPackage (equivalent to GeoPackage 1.3)—An OGC GeoPackage 1.3 dataset is created.</para>
			/// </summary>
			[GPValue("GEOPACKAGE")]
			[Description("GeoPackage (equivalent to GeoPackage 1.3)")]
			GEOPACKAGE,

			/// <summary>
			/// <para>GeoPackage 1.0—An OGC GeoPackage 1.0 dataset will be created.</para>
			/// </summary>
			[GPValue("GEOPACKAGE_1.0")]
			[Description("GeoPackage 1.0")]
			GeoPackage_10,

			/// <summary>
			/// <para>GeoPackage 1.1—An OGC GeoPackage 1.1 dataset will be created.</para>
			/// </summary>
			[GPValue("GEOPACKAGE_1.1")]
			[Description("GeoPackage 1.1")]
			GeoPackage_11,

			/// <summary>
			/// <para>GeoPackage 1.2.1—An OGC GeoPackage 1.2.1 dataset will be created.</para>
			/// </summary>
			[GPValue("GEOPACKAGE_1.2")]
			[Description("GeoPackage 1.2.1")]
			GeoPackage_121,

			/// <summary>
			/// <para>GeoPackage 1.3—An OGC GeoPackage 1.3 dataset will be created.</para>
			/// </summary>
			[GPValue("GEOPACKAGE_1.3")]
			[Description("GeoPackage 1.3")]
			GeoPackage_13,

		}

#endregion
	}
}
