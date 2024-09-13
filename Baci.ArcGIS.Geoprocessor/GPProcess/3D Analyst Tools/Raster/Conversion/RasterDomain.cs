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
	/// <para>Raster Domain</para>
	/// <para>栅格范围</para>
	/// <para>用于构造 3D 面或折线，以描绘沿栅格表面边界的高度。</para>
	/// </summary>
	public class RasterDomain : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>待处理的栅格。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </param>
		/// <param name="OutGeometryType">
		/// <para>Output Feature Class Type</para>
		/// <para>输出要素类的几何。</para>
		/// <para>线—输出将是启用了 z 值的线要素类。</para>
		/// <para>面—输出将是启用了 z 值的面要素类。</para>
		/// <para><see cref="OutGeometryTypeEnum"/></para>
		/// </param>
		public RasterDomain(object InRaster, object OutFeatureClass, object OutGeometryType)
		{
			this.InRaster = InRaster;
			this.OutFeatureClass = OutFeatureClass;
			this.OutGeometryType = OutGeometryType;
		}

		/// <summary>
		/// <para>Tool Display Name : 栅格范围</para>
		/// </summary>
		public override string DisplayName() => "栅格范围";

		/// <summary>
		/// <para>Tool Name : RasterDomain</para>
		/// </summary>
		public override string ToolName() => "RasterDomain";

		/// <summary>
		/// <para>Tool Excute Name : 3d.RasterDomain</para>
		/// </summary>
		public override string ExcuteName() => "3d.RasterDomain";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutFeatureClass, OutGeometryType };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>待处理的栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class Type</para>
		/// <para>输出要素类的几何。</para>
		/// <para>线—输出将是启用了 z 值的线要素类。</para>
		/// <para>面—输出将是启用了 z 值的面要素类。</para>
		/// <para><see cref="OutGeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutGeometryType { get; set; } = "LINE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterDomain SetEnviroment(object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Feature Class Type</para>
		/// </summary>
		public enum OutGeometryTypeEnum 
		{
			/// <summary>
			/// <para>线—输出将是启用了 z 值的线要素类。</para>
			/// </summary>
			[GPValue("LINE")]
			[Description("线")]
			Line,

			/// <summary>
			/// <para>面—输出将是启用了 z 值的面要素类。</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("面")]
			Polygon,

		}

#endregion
	}
}
