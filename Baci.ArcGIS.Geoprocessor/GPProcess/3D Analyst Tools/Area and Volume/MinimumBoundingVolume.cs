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
	/// <para>Minimum Bounding Volume</para>
	/// <para>最小包围体</para>
	/// <para>创建代表一组 3D 要素所占空间体积的多面体要素。</para>
	/// </summary>
	public class MinimumBoundingVolume : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>将评估其最小包围体的 LAS 数据集或 3D 要素。</para>
		/// </param>
		/// <param name="ZValue">
		/// <para>Z Value</para>
		/// <para>输入数据 z 值的源。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </param>
		public MinimumBoundingVolume(object InFeatures, object ZValue, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.ZValue = ZValue;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 最小包围体</para>
		/// </summary>
		public override string DisplayName() => "最小包围体";

		/// <summary>
		/// <para>Tool Name : MinimumBoundingVolume</para>
		/// </summary>
		public override string ToolName() => "MinimumBoundingVolume";

		/// <summary>
		/// <para>Tool Excute Name : 3d.MinimumBoundingVolume</para>
		/// </summary>
		public override string ExcuteName() => "3d.MinimumBoundingVolume";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, ZValue, OutFeatureClass, GeometryType!, Group!, GroupField!, MbvFields! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将评估其最小包围体的 LAS 数据集或 3D 要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Z Value</para>
		/// <para>输入数据 z 值的源。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		[ExcludeField("SHAPE_Length", "SHAPE_Area")]
		[KeyField("Shape.Z")]
		public object ZValue { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class Type</para>
		/// <para>指定用来确定最小包围体的几何的方法。</para>
		/// <para>凸包—输入数据周围的最小凸形区域。</para>
		/// <para>球体—封闭输入数据的最小球体。</para>
		/// <para>包络—输入数据的 XYZ 范围。</para>
		/// <para>凹包—包围输入数据的凹包。</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? GeometryType { get; set; } = "CONVEX_HULL";

		/// <summary>
		/// <para>Group Options</para>
		/// <para>指定如何对输入要素进行分组；每组都会通过一个输出多面体来封闭。</para>
		/// <para>无—输入要素不会被分组。这是默认设置。此选项不适用于点输入数据。</para>
		/// <para>所有—所有输入要素将视为位于一个组中。</para>
		/// <para>列表—根据指定字段的公共值或分组字段参数中的字段对输入要素进行分组。</para>
		/// <para><see cref="GroupEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Group { get; set; } = "NONE";

		/// <summary>
		/// <para>Group Field(s)</para>
		/// <para>将 List 指定为组选项时用于对要素进行分组的输入要素的字段（一个或多个）。对于 List 选项，至少需要一个分组字段。指定字段（一个或多个）的值相同的所有要素均将视为位于一个组中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		[ExcludeField("SHAPE_Length", "SHAPE_Area")]
		public object? GroupField { get; set; }

		/// <summary>
		/// <para>Add geometry characteristics as attributes to output</para>
		/// <para>指定每个要素是否具有最小包围体的体积和表面积属性。</para>
		/// <para>未选中 - 不会向输出要素添加几何属性。这是默认设置。</para>
		/// <para>选中 - 将会向输出要素添加几何属性。</para>
		/// <para><see cref="MbvFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MbvFields { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MinimumBoundingVolume SetEnviroment(object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Feature Class Type</para>
		/// </summary>
		public enum GeometryTypeEnum 
		{
			/// <summary>
			/// <para>凸包—输入数据周围的最小凸形区域。</para>
			/// </summary>
			[GPValue("CONVEX_HULL")]
			[Description("凸包")]
			Convex_hull,

			/// <summary>
			/// <para>球体—封闭输入数据的最小球体。</para>
			/// </summary>
			[GPValue("SPHERE")]
			[Description("球体")]
			Sphere,

			/// <summary>
			/// <para>包络—输入数据的 XYZ 范围。</para>
			/// </summary>
			[GPValue("ENVELOPE")]
			[Description("包络")]
			Envelope,

			/// <summary>
			/// <para>凹包—包围输入数据的凹包。</para>
			/// </summary>
			[GPValue("CONCAVE_HULL")]
			[Description("凹包")]
			Concave_hull,

		}

		/// <summary>
		/// <para>Group Options</para>
		/// </summary>
		public enum GroupEnum 
		{
			/// <summary>
			/// <para>无—输入要素不会被分组。这是默认设置。此选项不适用于点输入数据。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>所有—所有输入要素将视为位于一个组中。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有")]
			All,

			/// <summary>
			/// <para>列表—根据指定字段的公共值或分组字段参数中的字段对输入要素进行分组。</para>
			/// </summary>
			[GPValue("LIST")]
			[Description("列表")]
			List,

		}

		/// <summary>
		/// <para>Add geometry characteristics as attributes to output</para>
		/// </summary>
		public enum MbvFieldsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MBV_FIELDS")]
			MBV_FIELDS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MBV_FIELDS")]
			NO_MBV_FIELDS,

		}

#endregion
	}
}
