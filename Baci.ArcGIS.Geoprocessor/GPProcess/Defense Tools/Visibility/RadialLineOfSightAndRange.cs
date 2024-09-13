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
	/// <para>Radial Line Of Sight And Range</para>
	/// <para>径向通视分析和范围</para>
	/// <para>可以根据给定距离和视角，显示一个或多个指定观察点位置的可见区域。</para>
	/// </summary>
	public class RadialLineOfSightAndRange : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InObserverFeatures">
		/// <para>Input Observer</para>
		/// <para>输入观察点。</para>
		/// </param>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>输入高程栅格表面。 高程表面必须进行投影。</para>
		/// </param>
		/// <param name="OutViewshedFeatureClass">
		/// <para>Output Viewshed Feature Class</para>
		/// <para>用于显示可见和不可见区域的输出面要素类。</para>
		/// </param>
		/// <param name="OutFovFeatureClass">
		/// <para>Output Field of View Outline Feature Class</para>
		/// <para>包含扇形视域的输出面要素类。</para>
		/// </param>
		/// <param name="OutRangeRadiusFeatureClass">
		/// <para>Output Range</para>
		/// <para>输出面要素类，其中包含由范围半径、起始角和终止角创建的查看扇区。</para>
		/// </param>
		public RadialLineOfSightAndRange(object InObserverFeatures, object InSurface, object OutViewshedFeatureClass, object OutFovFeatureClass, object OutRangeRadiusFeatureClass)
		{
			this.InObserverFeatures = InObserverFeatures;
			this.InSurface = InSurface;
			this.OutViewshedFeatureClass = OutViewshedFeatureClass;
			this.OutFovFeatureClass = OutFovFeatureClass;
			this.OutRangeRadiusFeatureClass = OutRangeRadiusFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 径向通视分析和范围</para>
		/// </summary>
		public override string DisplayName() => "径向通视分析和范围";

		/// <summary>
		/// <para>Tool Name : RadialLineOfSightAndRange</para>
		/// </summary>
		public override string ToolName() => "RadialLineOfSightAndRange";

		/// <summary>
		/// <para>Tool Excute Name : defense.RadialLineOfSightAndRange</para>
		/// </summary>
		public override string ExcuteName() => "defense.RadialLineOfSightAndRange";

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
		public override object[] Parameters() => new object[] { InObserverFeatures, InSurface, OutViewshedFeatureClass, OutFovFeatureClass, OutRangeRadiusFeatureClass, ObserverHeightOffset!, InnerRadius!, OuterRadius!, HorizontalStartAngle!, HorizontalEndAngle! };

		/// <summary>
		/// <para>Input Observer</para>
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
		/// <para>输入高程栅格表面。 高程表面必须进行投影。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Output Viewshed Feature Class</para>
		/// <para>用于显示可见和不可见区域的输出面要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutViewshedFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Field of View Outline Feature Class</para>
		/// <para>包含扇形视域的输出面要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFovFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Range</para>
		/// <para>输出面要素类，其中包含由范围半径、起始角和终止角创建的查看扇区。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutRangeRadiusFeatureClass { get; set; }

		/// <summary>
		/// <para>Observer Height Offset (meters)</para>
		/// <para>观察点表面高程以上的高度。 默认值为 2。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Visibility Options")]
		public object? ObserverHeightOffset { get; set; } = "2";

		/// <summary>
		/// <para>Minimum Distance (meters)</para>
		/// <para>距离分析中所考虑的观察点的最小（最近）距离，以米为单位。 默认值为 1000。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Visibility Options")]
		public object? InnerRadius { get; set; } = "1000";

		/// <summary>
		/// <para>Maximum Distance (meters)</para>
		/// <para>距离分析中所考虑的观察点的最大（最远）距离，以米为单位。 默认值为 3000。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Visibility Options")]
		public object? OuterRadius { get; set; } = "3000";

		/// <summary>
		/// <para>Horizontal Start Angle (degrees)</para>
		/// <para>左轴承限制，以度为单位。 默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Visibility Options")]
		public object? HorizontalStartAngle { get; set; } = "0";

		/// <summary>
		/// <para>Horizontal End Angle (degrees)</para>
		/// <para>右轴承限制，以度为单位。 默认值为 360。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Visibility Options")]
		public object? HorizontalEndAngle { get; set; } = "360";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RadialLineOfSightAndRange SetEnviroment(object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
