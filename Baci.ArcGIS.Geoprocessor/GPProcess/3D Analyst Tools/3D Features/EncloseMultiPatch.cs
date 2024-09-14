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
	/// <para>Enclose Multipatch</para>
	/// <para>封闭多面体</para>
	/// <para>根据非闭合多面体要素创建闭合多面体要素。</para>
	/// </summary>
	public class EncloseMultiPatch : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Multipatch Features</para>
		/// <para>用于构造闭合多面体的多面体要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Multipatch Feature Class</para>
		/// <para>输出闭合多面体要素。</para>
		/// </param>
		public EncloseMultiPatch(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 封闭多面体</para>
		/// </summary>
		public override string DisplayName() => "封闭多面体";

		/// <summary>
		/// <para>Tool Name : EncloseMultiPatch</para>
		/// </summary>
		public override string ToolName() => "EncloseMultiPatch";

		/// <summary>
		/// <para>Tool Excute Name : 3d.EncloseMultiPatch</para>
		/// </summary>
		public override string ExcuteName() => "3d.EncloseMultiPatch";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "ZDomain", "ZResolution", "autoCommit", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, GridSize };

		/// <summary>
		/// <para>Input Multipatch Features</para>
		/// <para>用于构造闭合多面体的多面体要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Multipatch Feature Class</para>
		/// <para>输出闭合多面体要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Grid Size</para>
		/// <para>用于构造闭合多面体要素的分辨率。此值使用输入要素空间参考的线性单位定义。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object GridSize { get; set; } = "0.15";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EncloseMultiPatch SetEnviroment(object XYDomain = null, object XYResolution = null, object ZDomain = null, object ZResolution = null, int? autoCommit = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, ZDomain: ZDomain, ZResolution: ZResolution, autoCommit: autoCommit, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

	}
}
