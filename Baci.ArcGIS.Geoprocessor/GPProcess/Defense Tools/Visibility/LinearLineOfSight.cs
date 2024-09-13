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
	/// <para>Linear Line Of Sight</para>
	/// <para>线性通视分析</para>
	/// <para>在观察点和目标之间创建视线。</para>
	/// </summary>
	public class LinearLineOfSight : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InObserverFeatures">
		/// <para>Observers</para>
		/// <para>输入观察点。</para>
		/// </param>
		/// <param name="InTargetFeatures">
		/// <para>Targets</para>
		/// <para>输入目标点。</para>
		/// </param>
		/// <param name="InSurface">
		/// <para>Input Elevation Surface</para>
		/// <para>输入高程栅格表面。</para>
		/// </param>
		/// <param name="OutLosFeatureClass">
		/// <para>Output Line Of Sight Feature Class</para>
		/// <para>用于显示可见和不可见表面区域线的输出要素类。</para>
		/// </param>
		/// <param name="OutSightLineFeatureClass">
		/// <para>Output Sight Line Feature Class</para>
		/// <para>用于显示观察点与目标之间的直接视线的输出线要素类。</para>
		/// </param>
		/// <param name="OutObserverFeatureClass">
		/// <para>Output Observer Feature Class</para>
		/// <para>输出观察点要素类。</para>
		/// </param>
		/// <param name="OutTargetFeatureClass">
		/// <para>Output Target Feature Class</para>
		/// <para>输出目标点要素类。</para>
		/// </param>
		public LinearLineOfSight(object InObserverFeatures, object InTargetFeatures, object InSurface, object OutLosFeatureClass, object OutSightLineFeatureClass, object OutObserverFeatureClass, object OutTargetFeatureClass)
		{
			this.InObserverFeatures = InObserverFeatures;
			this.InTargetFeatures = InTargetFeatures;
			this.InSurface = InSurface;
			this.OutLosFeatureClass = OutLosFeatureClass;
			this.OutSightLineFeatureClass = OutSightLineFeatureClass;
			this.OutObserverFeatureClass = OutObserverFeatureClass;
			this.OutTargetFeatureClass = OutTargetFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 线性通视分析</para>
		/// </summary>
		public override string DisplayName() => "线性通视分析";

		/// <summary>
		/// <para>Tool Name : LinearLineOfSight</para>
		/// </summary>
		public override string ToolName() => "LinearLineOfSight";

		/// <summary>
		/// <para>Tool Excute Name : defense.LinearLineOfSight</para>
		/// </summary>
		public override string ExcuteName() => "defense.LinearLineOfSight";

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
		public override object[] Parameters() => new object[] { InObserverFeatures, InTargetFeatures, InSurface, OutLosFeatureClass, OutSightLineFeatureClass, OutObserverFeatureClass, OutTargetFeatureClass, InObstructionFeatures!, ObserverHeightAboveSurface!, TargetHeightAboveSurface!, AddProfileAttachment! };

		/// <summary>
		/// <para>Observers</para>
		/// <para>输入观察点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InObserverFeatures { get; set; }

		/// <summary>
		/// <para>Targets</para>
		/// <para>输入目标点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InTargetFeatures { get; set; }

		/// <summary>
		/// <para>Input Elevation Surface</para>
		/// <para>输入高程栅格表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Output Line Of Sight Feature Class</para>
		/// <para>用于显示可见和不可见表面区域线的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutLosFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Sight Line Feature Class</para>
		/// <para>用于显示观察点与目标之间的直接视线的输出线要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutSightLineFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Observer Feature Class</para>
		/// <para>输出观察点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutObserverFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Target Feature Class</para>
		/// <para>输出目标点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutTargetFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Obstruction Features</para>
		/// <para>可能会遮挡视线的输入多面体要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[Category("Visibility Options")]
		public object? InObstructionFeatures { get; set; }

		/// <summary>
		/// <para>Observer Height Above Surface (meters)</para>
		/// <para>观察点表面高程以上的高度。 默认值为 2。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Visibility Options")]
		public object? ObserverHeightAboveSurface { get; set; } = "2";

		/// <summary>
		/// <para>Target Height Above Surface (meters)</para>
		/// <para>目标表面高程以上的高度。 默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Visibility Options")]
		public object? TargetHeightAboveSurface { get; set; } = "0";

		/// <summary>
		/// <para>Add Profile Graph Attachment To Sight Line</para>
		/// <para>指定工具是否将观察点和目标之间的剖面（横截面地形图）附件添加到要素。</para>
		/// <para>无剖面图—不会添加剖面图。 这是默认设置。</para>
		/// <para>添加剖面图—将添加剖面图。</para>
		/// <para><see cref="AddProfileAttachmentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Visibility Options")]
		public object? AddProfileAttachment { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LinearLineOfSight SetEnviroment(object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Add Profile Graph Attachment To Sight Line</para>
		/// </summary>
		public enum AddProfileAttachmentEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_PROFILE_GRAPH")]
			ADD_PROFILE_GRAPH,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PROFILE_GRAPH")]
			NO_PROFILE_GRAPH,

		}

#endregion
	}
}
