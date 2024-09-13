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
	/// <para>Layer 3D To Feature Class</para>
	/// <para>3D 图层转要素类</para>
	/// <para>将具有 3D 显示属性的要素图层导出为 3D 线或多面体要素。</para>
	/// </summary>
	public class Layer3DToFeatureClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureLayer">
		/// <para>Input Feature Layer</para>
		/// <para>定义了 3D 显示属性的输入要素图层。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>具有 3D 要素的输出要素类。拉伸点将导出为 3D 线。具有 3D 符号的点、拉伸线和面将导出为多面体要素。</para>
		/// </param>
		public Layer3DToFeatureClass(object InFeatureLayer, object OutFeatureClass)
		{
			this.InFeatureLayer = InFeatureLayer;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 3D 图层转要素类</para>
		/// </summary>
		public override string DisplayName() => "3D 图层转要素类";

		/// <summary>
		/// <para>Tool Name : Layer3DToFeatureClass</para>
		/// </summary>
		public override string ToolName() => "Layer3DToFeatureClass";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Layer3DToFeatureClass</para>
		/// </summary>
		public override string ExcuteName() => "3d.Layer3DToFeatureClass";

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
		public override object[] Parameters() => new object[] { InFeatureLayer, OutFeatureClass, GroupField!, DisableMaterials! };

		/// <summary>
		/// <para>Input Feature Layer</para>
		/// <para>定义了 3D 显示属性的输入要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polyline", "Polygon", "MultiPatch")]
		public object InFeatureLayer { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>具有 3D 要素的输出要素类。拉伸点将导出为 3D 线。具有 3D 符号的点、拉伸线和面将导出为多面体要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Grouping Field</para>
		/// <para>用于将多个输入要素合并为同一输出要素的输入要素文本字段。所生成输出的其余属性将从其中一个输入记录继承。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("OID", "Short", "Long", "Text")]
		public object? GroupField { get; set; }

		/// <summary>
		/// <para>Disable Color and Texture</para>
		/// <para>指定将 3D 图层导出为多面体要素类时，是否要保留颜色和纹理属性。</para>
		/// <para>选中 - 不会将颜色和纹理保存为多面体定义的一部分。这是默认设置。</para>
		/// <para>未选中 - 将颜色与纹理保存在多面体中。</para>
		/// <para><see cref="DisableMaterialsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DisableMaterials { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Layer3DToFeatureClass SetEnviroment(object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Disable Color and Texture</para>
		/// </summary>
		public enum DisableMaterialsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DISABLE_COLORS_AND_TEXTURES")]
			DISABLE_COLORS_AND_TEXTURES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ENABLE_COLORS_AND_TEXTURES")]
			ENABLE_COLORS_AND_TEXTURES,

		}

#endregion
	}
}
