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
	/// <para>Regularize Adjacent Building Footprint</para>
	/// <para>规则化邻近建筑物覆盖区</para>
	/// <para>规则化具有公共边界的建筑物覆盖区。</para>
	/// </summary>
	public class RegularizeAdjacentBuildingFootprint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>待处理的输入要素。</para>
		/// </param>
		/// <param name="Group">
		/// <para>Grouping Field</para>
		/// <para>此字段用于确定哪些要素将共享重合、非重叠边界。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </param>
		public RegularizeAdjacentBuildingFootprint(object InFeatures, object Group, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.Group = Group;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 规则化邻近建筑物覆盖区</para>
		/// </summary>
		public override string DisplayName() => "规则化邻近建筑物覆盖区";

		/// <summary>
		/// <para>Tool Name : RegularizeAdjacentBuildingFootprint</para>
		/// </summary>
		public override string ToolName() => "RegularizeAdjacentBuildingFootprint";

		/// <summary>
		/// <para>Tool Excute Name : 3d.RegularizeAdjacentBuildingFootprint</para>
		/// </summary>
		public override string ExcuteName() => "3d.RegularizeAdjacentBuildingFootprint";

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
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, Group, OutFeatureClass, Method, Tolerance, Precision, AngularLimit };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>待处理的输入要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Grouping Field</para>
		/// <para>此字段用于确定哪些要素将共享重合、非重叠边界。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Text")]
		public object Group { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>规则化输入要素时使用的方法。</para>
		/// <para>直角—标识符合沿 90° 和 180° 角的输入要素折点的最佳线段。</para>
		/// <para>直角和对角—标识符合沿 90°、135° 和 180° 内角的输入要素折点的最佳线段。</para>
		/// <para>任意角—标识沿任意角度的最佳拟合线，同时减少输入要素的总折点数。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "RIGHT_ANGLES";

		/// <summary>
		/// <para>Tolerance</para>
		/// <para>规则化覆盖区可从其原始要素的边界偏移的最大距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object Tolerance { get; set; } = "1 Meters";

		/// <summary>
		/// <para>Precision</para>
		/// <para>在规则化过程中使用的空间格网精度。值的有效范围为 0.05 到 0.25。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0.050000000000000003, Max = 0.25)]
		public object Precision { get; set; } = "0.25";

		/// <summary>
		/// <para>Angular Deviation Limit</para>
		/// <para>最佳拟合线内角的最大偏差，可适用于使用直角和对角 (RIGHT_ANGLES_AND_DIAGONALS) 方法时。为获得最佳结果，通常应保持此值小于 5°。对于其他规则化方法，此参数将处于禁用状态。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0.001, Max = 15)]
		public object AngularLimit { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RegularizeAdjacentBuildingFootprint SetEnviroment(object geographicTransformations = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>任意角—标识沿任意角度的最佳拟合线，同时减少输入要素的总折点数。</para>
			/// </summary>
			[GPValue("ANY_ANGLES")]
			[Description("任意角")]
			Any_angles,

			/// <summary>
			/// <para>直角—标识符合沿 90° 和 180° 角的输入要素折点的最佳线段。</para>
			/// </summary>
			[GPValue("RIGHT_ANGLES")]
			[Description("直角")]
			Right_angles,

			/// <summary>
			/// <para>直角和对角—标识符合沿 90°、135° 和 180° 内角的输入要素折点的最佳线段。</para>
			/// </summary>
			[GPValue("RIGHT_ANGLES_AND_DIAGONALS")]
			[Description("直角和对角")]
			Right_angles_and_diagonals,

		}

#endregion
	}
}
