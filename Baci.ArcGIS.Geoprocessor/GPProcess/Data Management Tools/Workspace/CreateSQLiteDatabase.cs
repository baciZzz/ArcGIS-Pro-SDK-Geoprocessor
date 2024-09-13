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
	/// <para>创建 SQLite 数据库</para>
	/// <para>用于创建一个包含 ST_Geometry 或 SpatiaLite 空间类型的 GeoPackage 或 SQLite 数据库。</para>
	/// </summary>
	public class CreateSQLiteDatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutDatabaseName">
		/// <para>Output Database Name</para>
		/// <para>要创建的 SQLite 数据库或 GeoPackage 的位置以及文件名称。 如果空间类型参数值为 ST_Geometry 或 SpatiaLite，则将自动分配扩展名 .sqlite。 如果空间类型参数值为 GeoPackage 或任意 GeoPackage 版本，则将自动分配扩展名 .gpkg。</para>
		/// </param>
		public CreateSQLiteDatabase(object OutDatabaseName)
		{
			this.OutDatabaseName = OutDatabaseName;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 SQLite 数据库</para>
		/// </summary>
		public override string DisplayName() => "创建 SQLite 数据库";

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
		/// <para>要创建的 SQLite 数据库或 GeoPackage 的位置以及文件名称。 如果空间类型参数值为 ST_Geometry 或 SpatiaLite，则将自动分配扩展名 .sqlite。 如果空间类型参数值为 GeoPackage 或任意 GeoPackage 版本，则将自动分配扩展名 .gpkg。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object OutDatabaseName { get; set; }

		/// <summary>
		/// <para>Spatial Type</para>
		/// <para>指定要随新 SQLite 数据库安装的空间类型或要创建的 GeoPackage 版本。</para>
		/// <para>ST_Geometry—将安装 Esri 空间存储类型。 这是默认设置。</para>
		/// <para>SpatiaLite—将安装 SpatiaLite 空间存储类型。</para>
		/// <para>GeoPackage（相当于 GeoPackage 1.3）—已创建 OGC GeoPackage 1.3 数据集。</para>
		/// <para>GeoPackage 1.0—将创建 OGC GeoPackage 1.0 数据集。</para>
		/// <para>GeoPackage 1.1—将创建 OGC GeoPackage 1.1 数据集。</para>
		/// <para>GeoPackage 1.2.1—将创建 OGC GeoPackage 1.2.1 数据集。</para>
		/// <para>GeoPackage 1.3—将创建 OGC GeoPackage 1.3 数据集。</para>
		/// <para><see cref="SpatialTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SpatialType { get; set; } = "ST_GEOMETRY";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateSQLiteDatabase SetEnviroment(object workspace = null )
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
			/// <para>ST_Geometry—将安装 Esri 空间存储类型。 这是默认设置。</para>
			/// </summary>
			[GPValue("ST_GEOMETRY")]
			[Description("ST_Geometry")]
			ST_Geometry,

			/// <summary>
			/// <para>SpatiaLite—将安装 SpatiaLite 空间存储类型。</para>
			/// </summary>
			[GPValue("SPATIALITE")]
			[Description("SpatiaLite")]
			SpatiaLite,

			/// <summary>
			/// <para>GeoPackage（相当于 GeoPackage 1.3）—已创建 OGC GeoPackage 1.3 数据集。</para>
			/// </summary>
			[GPValue("GEOPACKAGE")]
			[Description("GeoPackage（相当于 GeoPackage 1.3）")]
			GEOPACKAGE,

			/// <summary>
			/// <para>GeoPackage 1.0—将创建 OGC GeoPackage 1.0 数据集。</para>
			/// </summary>
			[GPValue("GEOPACKAGE_1.0")]
			[Description("GeoPackage 1.0")]
			GeoPackage_10,

			/// <summary>
			/// <para>GeoPackage 1.1—将创建 OGC GeoPackage 1.1 数据集。</para>
			/// </summary>
			[GPValue("GEOPACKAGE_1.1")]
			[Description("GeoPackage 1.1")]
			GeoPackage_11,

			/// <summary>
			/// <para>GeoPackage 1.2.1—将创建 OGC GeoPackage 1.2.1 数据集。</para>
			/// </summary>
			[GPValue("GEOPACKAGE_1.2")]
			[Description("GeoPackage 1.2.1")]
			GeoPackage_121,

			/// <summary>
			/// <para>GeoPackage 1.3—将创建 OGC GeoPackage 1.3 数据集。</para>
			/// </summary>
			[GPValue("GEOPACKAGE_1.3")]
			[Description("GeoPackage 1.3")]
			GeoPackage_13,

		}

#endregion
	}
}
