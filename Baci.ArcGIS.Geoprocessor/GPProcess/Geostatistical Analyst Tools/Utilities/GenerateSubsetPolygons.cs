using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>Generate Subset Polygons</para>
	/// <para>生成子集面</para>
	/// <para>从一组输入点生成不重叠的子集面要素。目标是将点划分为紧凑、不重叠的子集，并在每个点子集周围创建面区域。可对每个子集中的最小点数和最大点数进行控制。</para>
	/// </summary>
	public class GenerateSubsetPolygons : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input point features</para>
		/// <para>将被分组到子集的点。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output feature class</para>
		/// <para>定义每个子集区域的面。单个面要素内的所有点都被视为同一子集的一部分。面要素类将包含一个名为 PointCount 的字段，该字段将存储每个面子集中包含的点数。</para>
		/// </param>
		public GenerateSubsetPolygons(object InPointFeatures, object OutFeatureClass)
		{
			this.InPointFeatures = InPointFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成子集面</para>
		/// </summary>
		public override string DisplayName() => "生成子集面";

		/// <summary>
		/// <para>Tool Name : GenerateSubsetPolygons</para>
		/// </summary>
		public override string ToolName() => "GenerateSubsetPolygons";

		/// <summary>
		/// <para>Tool Excute Name : ga.GenerateSubsetPolygons</para>
		/// </summary>
		public override string ExcuteName() => "ga.GenerateSubsetPolygons";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise() => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPointFeatures, OutFeatureClass, MinPointsPerSubset, MaxPointsPerSubset, CoincidentPoints };

		/// <summary>
		/// <para>Input point features</para>
		/// <para>将被分组到子集的点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Output feature class</para>
		/// <para>定义每个子集区域的面。单个面要素内的所有点都被视为同一子集的一部分。面要素类将包含一个名为 PointCount 的字段，该字段将存储每个面子集中包含的点数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Minimum number of points per subset</para>
		/// <para>可以分组到一个子集中的最小点数。所有子集面将至少包含这么多的点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 2147483647)]
		public object MinPointsPerSubset { get; set; } = "20";

		/// <summary>
		/// <para>Maximum number of points per subset</para>
		/// <para>可以分组到一个子集中的最大点数。</para>
		/// <para>无论提供的最大点数为何，每个子集都将始终包含少于两倍的每子集最小点数。这是因为如果一个子集包含至少两倍的最小点数，它将始终被细分为两个或多个新子集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 2147483647)]
		public object MaxPointsPerSubset { get; set; }

		/// <summary>
		/// <para>Treat coincident points as a single point</para>
		/// <para>指定是否将重合点（位于同一位置的点）视为单个点或多个单独的点。</para>
		/// <para>如果您打算在 EBK 回归预测中使用子集面作为子集面要素，您应保持此参数与 EBK 回归预测中重合点环境之间的一致性。</para>
		/// <para>如果未选中此参数，则您的输出要素类面可能会重叠。</para>
		/// <para>选中 - 重合点将被视为子集中的单个点。这是默认设置。</para>
		/// <para>未选中 - 重合点将被视为子集中的多个单独点。</para>
		/// <para><see cref="CoincidentPointsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CoincidentPoints { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateSubsetPolygons SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Treat coincident points as a single point</para>
		/// </summary>
		public enum CoincidentPointsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("COINCIDENT_SINGLE")]
			COINCIDENT_SINGLE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("COINCIDENT_ALL")]
			COINCIDENT_ALL,

		}

#endregion
	}
}
