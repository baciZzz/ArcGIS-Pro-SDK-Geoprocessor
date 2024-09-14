using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DefenseTools
{
	/// <summary>
	/// <para>Radial Line Of Sight</para>
	/// <para>径向通视分析</para>
	/// <para>显示一个或多个观察点位置可见的区域。</para>
	/// </summary>
	public class RadialLineOfSight : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InObserverFeatures">
		/// <para>Input Observer Features</para>
		/// <para>输入观察点。</para>
		/// </param>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>输入高程栅格表面。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Visibility</para>
		/// <para>用于显示可见和不可见表面区域的输出面要素类。</para>
		/// </param>
		public RadialLineOfSight(object InObserverFeatures, object InSurface, object OutFeatureClass)
		{
			this.InObserverFeatures = InObserverFeatures;
			this.InSurface = InSurface;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 径向通视分析</para>
		/// </summary>
		public override string DisplayName() => "径向通视分析";

		/// <summary>
		/// <para>Tool Name : RadialLineOfSight</para>
		/// </summary>
		public override string ToolName() => "RadialLineOfSight";

		/// <summary>
		/// <para>Tool Excute Name : defense.RadialLineOfSight</para>
		/// </summary>
		public override string ExcuteName() => "defense.RadialLineOfSight";

		/// <summary>
		/// <para>Toolbox Display Name : Defense Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Defense Tools";

		/// <summary>
		/// <para>Toolbox Alise : defense</para>
		/// </summary>
		public override string ToolboxAlise() => "defense";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InObserverFeatures, InSurface, OutFeatureClass, Radius!, ObserverHeightAboveSurface! };

		/// <summary>
		/// <para>Input Observer Features</para>
		/// <para>输入观察点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InObserverFeatures { get; set; }

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>输入高程栅格表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Output Visibility</para>
		/// <para>用于显示可见和不可见表面区域的输出面要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Radius Of Observer (meters)</para>
		/// <para>分析区域距离观察点的半径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Visibility Options")]
		public object? Radius { get; set; } = "1000";

		/// <summary>
		/// <para>Observer Height Above Surface (meters)</para>
		/// <para>观察点表面高程以上的高度。 默认值为 2。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Visibility Options")]
		public object? ObserverHeightAboveSurface { get; set; } = "2";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RadialLineOfSight SetEnviroment(object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
