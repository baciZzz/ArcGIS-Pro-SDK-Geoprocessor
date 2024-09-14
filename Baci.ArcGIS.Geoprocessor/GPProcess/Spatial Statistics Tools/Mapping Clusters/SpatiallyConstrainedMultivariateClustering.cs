using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools
{
	/// <summary>
	/// <para>Spatially Constrained Multivariate Clustering</para>
	/// <para>空间约束多元聚类</para>
	/// <para>基于一组要素属性值以及可选的聚类大小限值来查找在空间上相邻的要素聚类。</para>
	/// </summary>
	public class SpatiallyConstrainedMultivariateClustering : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要创建聚类的要素类或要素图层。</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>创建的新输出要素类，其中包含所有要素、指定的分析字段以及一个用于指明每个要素所属聚类的字段。</para>
		/// </param>
		/// <param name="AnalysisFields">
		/// <para>Analysis Fields</para>
		/// <para>将用于区分各个聚类的字段的列表。</para>
		/// </param>
		public SpatiallyConstrainedMultivariateClustering(object InFeatures, object OutputFeatures, object AnalysisFields)
		{
			this.InFeatures = InFeatures;
			this.OutputFeatures = OutputFeatures;
			this.AnalysisFields = AnalysisFields;
		}

		/// <summary>
		/// <para>Tool Display Name : 空间约束多元聚类</para>
		/// </summary>
		public override string DisplayName() => "空间约束多元聚类";

		/// <summary>
		/// <para>Tool Name : SpatiallyConstrainedMultivariateClustering</para>
		/// </summary>
		public override string ToolName() => "SpatiallyConstrainedMultivariateClustering";

		/// <summary>
		/// <para>Tool Excute Name : stats.SpatiallyConstrainedMultivariateClustering</para>
		/// </summary>
		public override string ExcuteName() => "stats.SpatiallyConstrainedMultivariateClustering";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise() => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "parallelProcessingFactor", "qualifiedFieldNames", "randomGenerator", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutputFeatures, AnalysisFields, SizeConstraints!, ConstraintField!, MinConstraint!, MaxConstraint!, NumberOfClusters!, SpatialConstraints!, WeightsMatrixFile!, NumberOfPermutations!, OutputTable! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要创建聚类的要素类或要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>创建的新输出要素类，其中包含所有要素、指定的分析字段以及一个用于指明每个要素所属聚类的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Analysis Fields</para>
		/// <para>将用于区分各个聚类的字段的列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object AnalysisFields { get; set; }

		/// <summary>
		/// <para>Cluster Size Constraints</para>
		/// <para>根据每个组的要素数或每个组的目标属性值指定聚类大小。</para>
		/// <para>无—将不使用聚类大小约束。这是默认设置。</para>
		/// <para>要素数量—将使用每个组的最小和最大要素数。</para>
		/// <para>属性值—将使用每个组的最小和最大属性值。</para>
		/// <para><see cref="SizeConstraintsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SizeConstraints { get; set; } = "NONE";

		/// <summary>
		/// <para>Constraint Field</para>
		/// <para>每个聚类进行求和的属性值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? ConstraintField { get; set; }

		/// <summary>
		/// <para>Minimum per Cluster</para>
		/// <para>每个聚类的最小要素数或每个聚类的最小属性值。该值必须为正值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MinConstraint { get; set; }

		/// <summary>
		/// <para>Fill to Limit</para>
		/// <para>每个聚类的最大要素数或每个聚类的最大属性值。如果设置了最大约束，则聚类数参数会处于非活动状态。该值必须为正值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaxConstraint { get; set; }

		/// <summary>
		/// <para>Number of Clusters</para>
		/// <para>要创建的聚类数。如果此参数为空，则该工具将计算具有 2 至 30 个聚类的聚类解决方案的伪 F 统计量值，以评估出最佳聚类数。</para>
		/// <para>如果已设置最大要素数或最大属性值，则将禁用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumberOfClusters { get; set; }

		/// <summary>
		/// <para>Spatial Constraints</para>
		/// <para>指定要素空间关系的定义方式。</para>
		/// <para>仅邻接边—聚类中将包含相邻的面要素。只有共享一条边的面才属于同一个聚类。</para>
		/// <para>邻接边拐角— 聚类中将包含相邻的面要素。只有共享一条边或一个折点的面才属于同一个聚类。这是面要素的默认选项。</para>
		/// <para>修剪型 Delaunay 三角测量— 同一个聚类中的要素至少具有一个与该聚类中的另一要素共用的自然邻域。自然邻域关系基于修剪型 Delaunay 三角测量。从概念上讲，Delaunay 三角测量可以根据要素质心创建不重叠的三角网。每个要素是一个三角形结点，具有公共边的结点被视为邻域。然后将这些三角形剪裁成凸包，以确保要素无法与凸包外的任何要素相邻。这是点要素的默认选项。</para>
		/// <para>通过文件获取空间权重—空间关系和可选的时态关系通过指定空间权重文件 (.swm) 进行定义。使用生成空间权重矩阵或生成网络空间权重工具创建空间权重矩阵。指向空间权重文件的路径由空间权重矩阵文件参数指定。</para>
		/// <para><see cref="SpatialConstraintsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SpatialConstraints { get; set; }

		/// <summary>
		/// <para>Spatial Weights Matrix File</para>
		/// <para>包含空间权重（其定义要素间的空间关系以及可能的时态关系）的文件的路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("swm", "gwt")]
		public object? WeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Permutations to Calculate Membership Probabilities</para>
		/// <para>计算成员关系稳定性得分的随机置换次数。如果选择了 0（零），则不会计算概率。计算这些概率时会用到随机跨度树置换和证据累积。</para>
		/// <para>对于较大的数据集来说，此计算可能会耗费大量的运行时间。建议您首先进行迭代并为您的分析找到最佳聚类数，然后在随后的运行中计算分析的概率。将并行处理因子环境设置设为 50 可改善该工具的运行时间。</para>
		/// <para><see cref="NumberOfPermutationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object? NumberOfPermutations { get; set; } = "0";

		/// <summary>
		/// <para>Output Table for Evaluating Number of Clusters</para>
		/// <para>所创建的表格，其中包含经计算用来评估最佳聚类数的 F 统计量值结果。根据该表创建的图表可以在输出要素图层下的内容窗格中进行访问。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutputTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SpatiallyConstrainedMultivariateClustering SetEnviroment(double? MResolution = null, double? MTolerance = null, object? XYResolution = null, object? XYTolerance = null, object? ZResolution = null, object? ZTolerance = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null, object? parallelProcessingFactor = null, bool? qualifiedFieldNames = null, object? randomGenerator = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor, qualifiedFieldNames: qualifiedFieldNames, randomGenerator: randomGenerator, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Cluster Size Constraints</para>
		/// </summary>
		public enum SizeConstraintsEnum 
		{
			/// <summary>
			/// <para>无—将不使用聚类大小约束。这是默认设置。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>要素数量—将使用每个组的最小和最大要素数。</para>
			/// </summary>
			[GPValue("NUM_FEATURES")]
			[Description("要素数量")]
			Number_of_features,

			/// <summary>
			/// <para>属性值—将使用每个组的最小和最大属性值。</para>
			/// </summary>
			[GPValue("ATTRIBUTE_VALUE")]
			[Description("属性值")]
			Attribute_value,

		}

		/// <summary>
		/// <para>Spatial Constraints</para>
		/// </summary>
		public enum SpatialConstraintsEnum 
		{
			/// <summary>
			/// <para>仅邻接边—聚类中将包含相邻的面要素。只有共享一条边的面才属于同一个聚类。</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_ONLY")]
			[Description("仅邻接边")]
			Contiguity_edges_only,

			/// <summary>
			/// <para>邻接边拐角— 聚类中将包含相邻的面要素。只有共享一条边或一个折点的面才属于同一个聚类。这是面要素的默认选项。</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_CORNERS")]
			[Description("邻接边拐角")]
			Contiguity_edges_corners,

			/// <summary>
			/// <para>修剪型 Delaunay 三角测量— 同一个聚类中的要素至少具有一个与该聚类中的另一要素共用的自然邻域。自然邻域关系基于修剪型 Delaunay 三角测量。从概念上讲，Delaunay 三角测量可以根据要素质心创建不重叠的三角网。每个要素是一个三角形结点，具有公共边的结点被视为邻域。然后将这些三角形剪裁成凸包，以确保要素无法与凸包外的任何要素相邻。这是点要素的默认选项。</para>
			/// </summary>
			[GPValue("TRIMMED_DELAUNAY_TRIANGULATION")]
			[Description("修剪型 Delaunay 三角测量")]
			Trimmed_Delaunay_triangulation,

			/// <summary>
			/// <para>通过文件获取空间权重—空间关系和可选的时态关系通过指定空间权重文件 (.swm) 进行定义。使用生成空间权重矩阵或生成网络空间权重工具创建空间权重矩阵。指向空间权重文件的路径由空间权重矩阵文件参数指定。</para>
			/// </summary>
			[GPValue("GET_SPATIAL_WEIGHTS_FROM_FILE")]
			[Description("通过文件获取空间权重")]
			Get_spatial_weights_from_file,

		}

		/// <summary>
		/// <para>Permutations to Calculate Membership Probabilities</para>
		/// </summary>
		public enum NumberOfPermutationsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("0")]
			[Description("0")]
			_0,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("100")]
			[Description("100")]
			_100,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("200")]
			[Description("200")]
			_200,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("500")]
			[Description("500")]
			_500,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("1000")]
			[Description("1000")]
			_1000,

		}

#endregion
	}
}
