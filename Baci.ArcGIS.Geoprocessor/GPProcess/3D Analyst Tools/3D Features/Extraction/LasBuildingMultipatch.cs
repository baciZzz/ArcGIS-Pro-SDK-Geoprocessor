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
	/// <para>LAS Building Multipatch</para>
	/// <para>LAS 建筑物多面体</para>
	/// <para>通过从激光雷达数据中捕获的屋顶点创建建筑物模型。</para>
	/// </summary>
	public class LasBuildingMultipatch : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>LAS 数据集包含将用于定义建筑物屋顶的点。</para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>定义建筑物覆盖区面的面要素。</para>
		/// </param>
		/// <param name="Ground">
		/// <para>Ground Height</para>
		/// <para>地面高度值的来源可以是建筑物覆盖区面属性表中的数值字段、栅格或 TIN 表面。 基于字段的地面源将比基于表面的地面源的处理速度快。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Multipatch Feature Class</para>
		/// <para>用于存储输出建筑物模型的多面体要素类。</para>
		/// </param>
		public LasBuildingMultipatch(object InLasDataset, object InFeatures, object Ground, object OutFeatureClass)
		{
			this.InLasDataset = InLasDataset;
			this.InFeatures = InFeatures;
			this.Ground = Ground;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : LAS 建筑物多面体</para>
		/// </summary>
		public override string DisplayName() => "LAS 建筑物多面体";

		/// <summary>
		/// <para>Tool Name : LasBuildingMultipatch</para>
		/// </summary>
		public override string ToolName() => "LasBuildingMultipatch";

		/// <summary>
		/// <para>Tool Excute Name : 3d.LasBuildingMultipatch</para>
		/// </summary>
		public override string ExcuteName() => "3d.LasBuildingMultipatch";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, InFeatures, Ground, OutFeatureClass, PointSelection!, Simplification!, SamplingResolution! };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>LAS 数据集包含将用于定义建筑物屋顶的点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Input Features</para>
		/// <para>定义建筑物覆盖区面的面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Ground Height</para>
		/// <para>地面高度值的来源可以是建筑物覆盖区面属性表中的数值字段、栅格或 TIN 表面。 基于字段的地面源将比基于表面的地面源的处理速度快。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Ground { get; set; }

		/// <summary>
		/// <para>Output Multipatch Feature Class</para>
		/// <para>用于存储输出建筑物模型的多面体要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>LAS Rooftop Point Selection</para>
		/// <para>指定将用于定义建筑物屋顶的 LAS 点。</para>
		/// <para>建筑物分类点—将使用分配的类代码值为 6 的 LAS 点。 这是默认设置。</para>
		/// <para>图层过滤点—将使用按输入图层过滤的 LAS 点。</para>
		/// <para>所有点—将使用与建筑物覆盖区面重叠的所有 LAS 点。</para>
		/// <para><see cref="PointSelectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PointSelection { get; set; } = "BUILDING_CLASSIFIED_POINTS";

		/// <summary>
		/// <para>Simplification Tolerance</para>
		/// <para>将用于简化屋顶几何图形的 z 容差值。 该值定义了输出屋顶模型与使用 LAS 点创建的 TIN 表面的最大偏差。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object? Simplification { get; set; }

		/// <summary>
		/// <para>Sampling Resolution</para>
		/// <para>用于在构建屋顶表面之前细化点云的分组大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object? SamplingResolution { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LasBuildingMultipatch SetEnviroment(object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>LAS Rooftop Point Selection</para>
		/// </summary>
		public enum PointSelectionEnum 
		{
			/// <summary>
			/// <para>建筑物分类点—将使用分配的类代码值为 6 的 LAS 点。 这是默认设置。</para>
			/// </summary>
			[GPValue("BUILDING_CLASSIFIED_POINTS")]
			[Description("建筑物分类点")]
			Building_Classified_Points,

			/// <summary>
			/// <para>图层过滤点—将使用按输入图层过滤的 LAS 点。</para>
			/// </summary>
			[GPValue("LAYER_FILTERED_POINTS")]
			[Description("图层过滤点")]
			Layer_Filtered_Points,

			/// <summary>
			/// <para>所有点—将使用与建筑物覆盖区面重叠的所有 LAS 点。</para>
			/// </summary>
			[GPValue("ALL_POINTS")]
			[Description("所有点")]
			All_Points,

		}

#endregion
	}
}
