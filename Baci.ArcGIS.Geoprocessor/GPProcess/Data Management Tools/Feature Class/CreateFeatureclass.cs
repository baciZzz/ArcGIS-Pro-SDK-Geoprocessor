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
	/// <para>创建要素类</para>
	/// <para>在地理数据库中创建空要素类，或在文件夹中创建 shapefile。</para>
	/// </summary>
	public class CreateFeatureclass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutPath">
		/// <para>Feature Class Location</para>
		/// <para>将在其中创建输出要素类的企业级地理数据库、文件地理数据库或文件夹。此工作空间必须已经存在。</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Feature Class Name</para>
		/// <para>要创建的要素类的名称。</para>
		/// </param>
		public CreateFeatureclass(object OutPath, object OutName)
		{
			this.OutPath = OutPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建要素类</para>
		/// </summary>
		public override string DisplayName() => "创建要素类";

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
		/// <para>将在其中创建输出要素类的企业级地理数据库、文件地理数据库或文件夹。此工作空间必须已经存在。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
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
		/// <para>用于指定要素类的几何类型。</para>
		/// <para>点—几何类型为点。</para>
		/// <para>多点—几何类型为多点。</para>
		/// <para>Polygon—几何类型为面。</para>
		/// <para>折线—几何类型为折线。</para>
		/// <para>多面体—几何类型为多面体。</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GeometryType { get; set; } = "POLYGON";

		/// <summary>
		/// <para>Template Dataset</para>
		/// <para>用作模板以定义新要素类的属性字段的要素类或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Template { get; set; }

		/// <summary>
		/// <para>Has M</para>
		/// <para>指定要素类是否包含线性测量值（m 值）。</para>
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
		/// <para>指定要素类是否包含高程值（z 值）。</para>
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
		/// <para>Coordinate System</para>
		/// <para>输出要素数据集的空间参考。在空间参考属性对话框中，可以选择、导入或新建坐标系。要设置空间参考的各个方面（例如，x,y 值域、z 值域、m 值域、分辨率或容差），请使用环境对话框。</para>
		/// <para>如果未提供空间参考，则输出将具有一个未定义的空间参考。</para>
		/// <para>模板要素类的空间参考对输出空间参考没有影响。如果想在模板要素类的坐标系中输出，请将坐标系参数设置为模板要素类的空间参考。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>配置关键字仅适用于企业级地理数据库数据。它用于确定数据库表的存储参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Geodatabase Settings (optional)")]
		public object ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Output Spatial Grid 1</para>
		/// <para>已在 ArcGIS Pro 中弃用此参数。将忽略您输入的任何值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Geodatabase Settings (optional)")]
		public object SpatialGrid1 { get; set; } = "0";

		/// <summary>
		/// <para>Output Spatial Grid 2</para>
		/// <para>已在 ArcGIS Pro 中弃用此参数。将忽略您输入的任何值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Geodatabase Settings (optional)")]
		public object SpatialGrid2 { get; set; } = "0";

		/// <summary>
		/// <para>Output Spatial Grid 3</para>
		/// <para>已在 ArcGIS Pro 中弃用此参数。将忽略您输入的任何值。</para>
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
		/// <para>将创建输出要素类的备用名称。</para>
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
			/// <para>点—几何类型为点。</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("点")]
			Point,

			/// <summary>
			/// <para>多点—几何类型为多点。</para>
			/// </summary>
			[GPValue("MULTIPOINT")]
			[Description("多点")]
			Multipoint,

			/// <summary>
			/// <para>Polygon—几何类型为面。</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("Polygon")]
			Polygon,

			/// <summary>
			/// <para>折线—几何类型为折线。</para>
			/// </summary>
			[GPValue("POLYLINE")]
			[Description("折线")]
			Polyline,

			/// <summary>
			/// <para>多面体—几何类型为多面体。</para>
			/// </summary>
			[GPValue("MULTIPATCH")]
			[Description("多面体")]
			Multipatch,

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
