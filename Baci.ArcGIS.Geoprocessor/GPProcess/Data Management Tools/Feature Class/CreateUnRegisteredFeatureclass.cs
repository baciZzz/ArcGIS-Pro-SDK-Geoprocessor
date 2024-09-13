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
	/// <para>创建未注册要素类</para>
	/// <para>用于在数据库或企业级地理数据库中创建空要素类。此要素类未注册到地理数据库。</para>
	/// </summary>
	public class CreateUnRegisteredFeatureclass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutPath">
		/// <para>Feature Class Location</para>
		/// <para>将创建输出要素类的企业级地理数据库或数据库。</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Feature Class Name</para>
		/// <para>要创建的要素类的名称。</para>
		/// </param>
		public CreateUnRegisteredFeatureclass(object OutPath, object OutName)
		{
			this.OutPath = OutPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建未注册要素类</para>
		/// </summary>
		public override string DisplayName() => "创建未注册要素类";

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
		/// <para>将创建输出要素类的企业级地理数据库或数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutPath { get; set; }

		/// <summary>
		/// <para>Feature Class Name</para>
		/// <para>要创建的要素类的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Geometry Type</para>
		/// <para>用于指定要素类的几何类型。此参数仅适用于存储维数元数据的几何类型，如 PostgreSQL 中的 ST_Geometry、PostGIS Geometry 和 Oracle SDO_Geometry。</para>
		/// <para>点—该几何类型将为点。</para>
		/// <para>多点—该几何类型将为多点。</para>
		/// <para>折线—该几何类型将为折线。</para>
		/// <para>面—该几何类型将为面。这是默认设置。</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GeometryType { get; set; } = "POLYGON";

		/// <summary>
		/// <para>Template Feature Class</para>
		/// <para>现有要素类或者包含用于定义输出要素类中字段的字段和属性方案的要素类列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Template { get; set; }

		/// <summary>
		/// <para>Has M</para>
		/// <para>确定输出要素类是否包含线性测量值（M 值）。</para>
		/// <para>不支持—输出要素类将不具有 M 值。这是默认设置。</para>
		/// <para>支持—输出要素类将具有 M 值。</para>
		/// <para>与模板要素类相同—如果在模板要素类参数（Python 中的 template 参数）中指定的数据集具有 M 值，则输出要素类将具有 M 值。</para>
		/// <para><see cref="HasMEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object HasM { get; set; } = "DISABLED";

		/// <summary>
		/// <para>Has Z</para>
		/// <para>确定输出要素类是否包含高程值（Z 值）。</para>
		/// <para>不支持—输出要素类将不具有 Z 值。这是默认设置。</para>
		/// <para>支持—输出要素类将具有 Z 值。</para>
		/// <para>与模板要素类相同—如果模板要素类参数（Python 中的 template 参数）中指定的数据集具有 Z 值，则输出要素类将具有 Z 值。</para>
		/// <para><see cref="HasZEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object HasZ { get; set; } = "DISABLED";

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>输出要素数据集的空间参考。在空间参考属性对话框中，可以选择、导入或新建坐标系。要设置空间参考的各个方面（例如，x,y 值域、z 值域、m 值域、分辨率或容差），请使用环境对话框。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>指定关系数据库管理系统 (RDBMS) 中的地理数据库的默认存储参数（配置）。此设置仅在使用企业级地理数据库表时可用。</para>
		/// <para>配置关键字由数据库管理员进行设置。</para>
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
			/// <para>点—该几何类型将为点。</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("点")]
			Point,

			/// <summary>
			/// <para>多点—该几何类型将为多点。</para>
			/// </summary>
			[GPValue("MULTIPOINT")]
			[Description("多点")]
			Multipoint,

			/// <summary>
			/// <para>面—该几何类型将为面。这是默认设置。</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("面")]
			Polygon,

			/// <summary>
			/// <para>折线—该几何类型将为折线。</para>
			/// </summary>
			[GPValue("POLYLINE")]
			[Description("折线")]
			Polyline,

		}

		/// <summary>
		/// <para>Has M</para>
		/// </summary>
		public enum HasMEnum 
		{
			/// <summary>
			/// <para>不支持—输出要素类将不具有 M 值。这是默认设置。</para>
			/// </summary>
			[GPValue("DISABLED")]
			[Description("不支持")]
			No,

			/// <summary>
			/// <para>与模板要素类相同—如果在模板要素类参数（Python 中的 template 参数）中指定的数据集具有 M 值，则输出要素类将具有 M 值。</para>
			/// </summary>
			[GPValue("SAME_AS_TEMPLATE")]
			[Description("与模板要素类相同")]
			Same_as_the_template_feature_class,

			/// <summary>
			/// <para>支持—输出要素类将具有 M 值。</para>
			/// </summary>
			[GPValue("ENABLED")]
			[Description("支持")]
			Yes,

		}

		/// <summary>
		/// <para>Has Z</para>
		/// </summary>
		public enum HasZEnum 
		{
			/// <summary>
			/// <para>不支持—输出要素类将不具有 Z 值。这是默认设置。</para>
			/// </summary>
			[GPValue("DISABLED")]
			[Description("不支持")]
			No,

			/// <summary>
			/// <para>与模板要素类相同—如果模板要素类参数（Python 中的 template 参数）中指定的数据集具有 Z 值，则输出要素类将具有 Z 值。</para>
			/// </summary>
			[GPValue("SAME_AS_TEMPLATE")]
			[Description("与模板要素类相同")]
			Same_as_the_template_feature_class,

			/// <summary>
			/// <para>支持—输出要素类将具有 Z 值。</para>
			/// </summary>
			[GPValue("ENABLED")]
			[Description("支持")]
			Yes,

		}

#endregion
	}
}
