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
	/// <para>Simplify 3D Line</para>
	/// <para>简化 3D 线</para>
	/// <para>概化 3D 线要素，以减少总折点数，同时在指定容差范围内在水平和垂直方向上近似于原始形状。</para>
	/// </summary>
	public class Simplify3DLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Line Features</para>
		/// <para>要进行简化的线要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Lines</para>
		/// <para>简化的输出线要素。</para>
		/// </param>
		/// <param name="Tolerance">
		/// <para>Simplification Tolerance</para>
		/// <para>距输入线的 3D 距离阈值，简化输出必须位于其中。</para>
		/// </param>
		public Simplify3DLine(object InFeatures, object OutFeatureClass, object Tolerance)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.Tolerance = Tolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : 简化 3D 线</para>
		/// </summary>
		public override string DisplayName() => "简化 3D 线";

		/// <summary>
		/// <para>Tool Name : Simplify3DLine</para>
		/// </summary>
		public override string ToolName() => "Simplify3DLine";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Simplify3DLine</para>
		/// </summary>
		public override string ExcuteName() => "3d.Simplify3DLine";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, Tolerance };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>要进行简化的线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Lines</para>
		/// <para>简化的输出线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Simplification Tolerance</para>
		/// <para>距输入线的 3D 距离阈值，简化输出必须位于其中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object Tolerance { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Simplify3DLine SetEnviroment(object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

	}
}
