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
	/// <para>Polygon Volume</para>
	/// <para>面体积</para>
	/// <para>计算高度恒定的面和表面之间的体积和表面面积。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class PolygonVolume : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>待处理的 TIN、terrain 或 LAS 数据集表面。</para>
		/// </param>
		/// <param name="InFeatureClass">
		/// <para>Input Features</para>
		/// <para>定义正在处理的区域的面要素。</para>
		/// </param>
		/// <param name="InHeightField">
		/// <para>Height Field</para>
		/// <para>面属性表中的字段，用于定义确定体积计算中使用的参考平面高度。</para>
		/// </param>
		public PolygonVolume(object InSurface, object InFeatureClass, object InHeightField)
		{
			this.InSurface = InSurface;
			this.InFeatureClass = InFeatureClass;
			this.InHeightField = InHeightField;
		}

		/// <summary>
		/// <para>Tool Display Name : 面体积</para>
		/// </summary>
		public override string DisplayName() => "面体积";

		/// <summary>
		/// <para>Tool Name : PolygonVolume</para>
		/// </summary>
		public override string ToolName() => "PolygonVolume";

		/// <summary>
		/// <para>Tool Excute Name : 3d.PolygonVolume</para>
		/// </summary>
		public override string ExcuteName() => "3d.PolygonVolume";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "terrainMemoryUsage", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSurface, InFeatureClass, InHeightField, ReferencePlane!, OutVolumeField!, SurfaceAreaField!, PyramidLevelResolution!, OutputFeatureClass! };

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>待处理的 TIN、terrain 或 LAS 数据集表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Input Features</para>
		/// <para>定义正在处理的区域的面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Height Field</para>
		/// <para>面属性表中的字段，用于定义确定体积计算中使用的参考平面高度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InHeightField { get; set; }

		/// <summary>
		/// <para>Reference Plane</para>
		/// <para>要计算体积和表面积的参考平面的方向。</para>
		/// <para>在平面上方计算—计算面的参考平面高度以上的体积和表面积。</para>
		/// <para>在平面下方计算—计算面的参考平面高度以下的体积和表面积。这是默认设置。</para>
		/// <para><see cref="ReferencePlaneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ReferencePlane { get; set; } = "BELOW";

		/// <summary>
		/// <para>Volume Field</para>
		/// <para>指定体积计算所属字段的名称。默认设置为 Volume。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OutVolumeField { get; set; } = "Volume";

		/// <summary>
		/// <para>Surface Area Field</para>
		/// <para>指定表面积计算所属字段的名称。默认设置为 SArea。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? SurfaceAreaField { get; set; } = "SArea";

		/// <summary>
		/// <para>Pyramid Level Resolution</para>
		/// <para>将使用 terrain 金字塔等级的 z 容差或窗口大小分辨率。 默认值为 0，或全分辨率。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PolygonVolume SetEnviroment(object? extent = null, object? geographicTransformations = null, bool? terrainMemoryUsage = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, terrainMemoryUsage: terrainMemoryUsage, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Reference Plane</para>
		/// </summary>
		public enum ReferencePlaneEnum 
		{
			/// <summary>
			/// <para>在平面上方计算—计算面的参考平面高度以上的体积和表面积。</para>
			/// </summary>
			[GPValue("ABOVE")]
			[Description("在平面上方计算")]
			Calculate_above_the_plane,

			/// <summary>
			/// <para>在平面下方计算—计算面的参考平面高度以下的体积和表面积。这是默认设置。</para>
			/// </summary>
			[GPValue("BELOW")]
			[Description("在平面下方计算")]
			Calculate_below_the_plane,

		}

#endregion
	}
}
