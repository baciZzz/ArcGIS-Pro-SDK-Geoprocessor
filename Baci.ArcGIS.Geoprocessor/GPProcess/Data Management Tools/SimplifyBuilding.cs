using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Simplify Building</para>
	/// <para>简化建筑物</para>
	/// <para>在保持建筑物基本形状和大小不变的前提下简化建筑物面的边界或轮廓。</para>
	/// </summary>
	[Obsolete()]
	public class SimplifyBuilding : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要简化的建筑物面。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>要创建的输出要素类。</para>
		/// </param>
		/// <param name="SimplificationTolerance">
		/// <para>Simplification Tolerance</para>
		/// <para>建筑物简化的容差。 必须指定一个容差，且值必须大于零。 可以选择首选单位；默认为要素单位。</para>
		/// </param>
		public SimplifyBuilding(object InFeatures, object OutFeatureClass, object SimplificationTolerance)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.SimplificationTolerance = SimplificationTolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : 简化建筑物</para>
		/// </summary>
		public override string DisplayName() => "简化建筑物";

		/// <summary>
		/// <para>Tool Name : SimplifyBuilding</para>
		/// </summary>
		public override string ToolName() => "SimplifyBuilding";

		/// <summary>
		/// <para>Tool Excute Name : management.SimplifyBuilding</para>
		/// </summary>
		public override string ExcuteName() => "management.SimplifyBuilding";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "XYDomain", "XYTolerance", "cartographicPartitions", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, SimplificationTolerance, MinimumArea!, ConflictOption!, InBarriers!, OutPointFeatureClass!, CollapsedPointOption! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要简化的建筑物面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexJunction", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>要创建的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Simplification Tolerance</para>
		/// <para>建筑物简化的容差。 必须指定一个容差，且值必须大于零。 可以选择首选单位；默认为要素单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object SimplificationTolerance { get; set; }

		/// <summary>
		/// <para>Minimum Area</para>
		/// <para>要以要素单位保留的简化建筑物的最小面积。 默认值为零，即保留所有建筑物。 可以指定首选单位；默认为要素单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object? MinimumArea { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Check for spatial conflicts</para>
		/// <para>指定是否识别空间冲突，即建筑物之间是否重叠或接触。 将向输出添加 SimBldFlag 字段，以存储冲突标记。 值为 0 意味着无冲突；值为 1 意味着存在冲突。</para>
		/// <para>未选中 - 不识别空间冲突；生成的建筑物可能重叠。 这是默认设置。</para>
		/// <para>选中 - 将识别空间冲突并标记冲突建筑物。</para>
		/// <para><see cref="ConflictOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ConflictOption { get; set; } = "false";

		/// <summary>
		/// <para>Input barrier layers</para>
		/// <para>包含充当简化中障碍的要素的输入图层。 生成简化建筑物不会接触障碍要素或与其交叉。 例如，当简化建筑物时，生成的简化建筑物区域不会穿过被定义为障碍的道路要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? InBarriers { get; set; }

		/// <summary>
		/// <para>Polygons Collapsed To Zero Area</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutPointFeatureClass { get; set; } = "output_feature_class_Pnt";

		/// <summary>
		/// <para>Keep collapsed points</para>
		/// <para>指定是否创建输出点要素类，以存储因小于最小面积参数值而遭到移除的所有建筑物的中心。 点输出的派生和命名与在输出要素类参数中指定的输出要素类相同，但带有 _Pnt 后缀，并且位于同一文件夹中。</para>
		/// <para>选中 - 将创建派生的输出点要素类，以存储已移除建筑物的中心。</para>
		/// <para>未选中 - 不会创建输出点类。 这是默认设置。</para>
		/// <para><see cref="CollapsedPointOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CollapsedPointOption { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SimplifyBuilding SetEnviroment(object? MDomain = null , object? XYDomain = null , object? XYTolerance = null , object? cartographicPartitions = null , object? extent = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, XYDomain: XYDomain, XYTolerance: XYTolerance, cartographicPartitions: cartographicPartitions, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Check for spatial conflicts</para>
		/// </summary>
		public enum ConflictOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CHECK_CONFLICTS")]
			CHECK_CONFLICTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CHECK")]
			NO_CHECK,

		}

		/// <summary>
		/// <para>Keep collapsed points</para>
		/// </summary>
		public enum CollapsedPointOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_COLLAPSED_POINTS")]
			KEEP_COLLAPSED_POINTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_KEEP")]
			NO_KEEP,

		}

#endregion
	}
}
