using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpaceTimePatternMiningTools
{
	/// <summary>
	/// <para>Fill Missing Values</para>
	/// <para>填充缺失值</para>
	/// <para>用于将缺失值（空值）替换为基于空间邻域、时空邻域或时间序列值的估算值。</para>
	/// </summary>
	public class FillMissingValues : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>包含要填充的空值的要素类。</para>
		/// </param>
		/// <param name="FieldsToFill">
		/// <para>Fields to Fill</para>
		/// <para>包含缺失数据（空值）的数值字段。</para>
		/// </param>
		/// <param name="FillMethod">
		/// <para>Fill Method</para>
		/// <para>指定将要应用的计算类型。 仅当位置 ID 和时间字段参数值已指定时，时间趋势选项才可用。</para>
		/// <para>平均值—空值将替换为要素邻域的平均值。</para>
		/// <para>最小值—空值将替换为要素邻域的最小值。</para>
		/// <para>最大值—空值将替换为要素邻域的最大值。</para>
		/// <para>中值—空值将替换为要素邻域的中位数（中值）。</para>
		/// <para>时间趋势—空值将基于该唯一位置处的趋势进行替换。</para>
		/// <para><see cref="FillMethodEnum"/></para>
		/// </param>
		public FillMissingValues(object InFeatures, object FieldsToFill, object FillMethod)
		{
			this.InFeatures = InFeatures;
			this.FieldsToFill = FieldsToFill;
			this.FillMethod = FillMethod;
		}

		/// <summary>
		/// <para>Tool Display Name : 填充缺失值</para>
		/// </summary>
		public override string DisplayName() => "填充缺失值";

		/// <summary>
		/// <para>Tool Name : FillMissingValues</para>
		/// </summary>
		public override string ToolName() => "FillMissingValues";

		/// <summary>
		/// <para>Tool Excute Name : stpm.FillMissingValues</para>
		/// </summary>
		public override string ExcuteName() => "stpm.FillMissingValues";

		/// <summary>
		/// <para>Toolbox Display Name : Space Time Pattern Mining Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Space Time Pattern Mining Tools";

		/// <summary>
		/// <para>Toolbox Alise : stpm</para>
		/// </summary>
		public override string ToolboxAlise() => "stpm";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatures, FieldsToFill, FillMethod, ConceptualizationOfSpatialRelationships, DistanceBand, TemporalNeighborhood, TimeField, NumberOfSpatialNeighbors, LocationId, RelatedTable, RelatedLocationId, WeightsMatrixFile, UniqueId, NullValue, OutTable, AppendToInput, UpdatedFeatures };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>包含要填充的空值的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>将包含已填充（估算）值的输出。</para>
		/// <para>如果已指定相关表参数值，输出要素将包含每个位置的估算值数，而输出表将包含已填充（估算）值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Fields to Fill</para>
		/// <para>包含缺失数据（空值）的数值字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Double", "Long", "Float", "Short")]
		public object FieldsToFill { get; set; }

		/// <summary>
		/// <para>Fill Method</para>
		/// <para>指定将要应用的计算类型。 仅当位置 ID 和时间字段参数值已指定时，时间趋势选项才可用。</para>
		/// <para>平均值—空值将替换为要素邻域的平均值。</para>
		/// <para>最小值—空值将替换为要素邻域的最小值。</para>
		/// <para>最大值—空值将替换为要素邻域的最大值。</para>
		/// <para>中值—空值将替换为要素邻域的中位数（中值）。</para>
		/// <para>时间趋势—空值将基于该唯一位置处的趋势进行替换。</para>
		/// <para><see cref="FillMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FillMethod { get; set; }

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// <para>指定要素空间关系的定义方式。</para>
		/// <para>固定距离—每个要素的指定临界距离（距离范围参数值）内的邻域要素都将包含在计算中；临界距离以外的所有要素都将排除在外。</para>
		/// <para>K - 最近邻—最近的 k 个要素将包含在计算中；k 是指定的数字参数。</para>
		/// <para>仅邻接边—只有共享边界或重叠的相邻面要素会影响目标面要素的计算。</para>
		/// <para>邻接边拐角—共享边界、节点或重叠的面要素会影响目标面要素的计算。</para>
		/// <para>通过文件获取空间权重—将由指定空间权重文件定义空间关系。 指向空间权重文件的路径由权重矩阵文件参数指定。</para>
		/// <para><see cref="ConceptualizationOfSpatialRelationshipsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConceptualizationOfSpatialRelationships { get; set; }

		/// <summary>
		/// <para>Distance Band</para>
		/// <para>用于空间关系的概念化参数固定距离选项的中断距离。 将在针对目标要素的计算中忽略为该要素指定的中断之外的要素。 此参数不适用于仅邻接边或邻接边拐角选项。</para>
		/// <para><see cref="DistanceBandEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object DistanceBand { get; set; }

		/// <summary>
		/// <para>Temporal Neighborhood</para>
		/// <para>向前和向后的间隔时间，用于确定要在针对目标要素的计算中使用的要素。 不在此目标要素间隔内的要素将在针对该要素的计算中忽略。</para>
		/// <para><see cref="TemporalNeighborhoodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TemporalNeighborhood { get; set; }

		/// <summary>
		/// <para>Time Field</para>
		/// <para>包含数据集中每条记录的时间戳的字段。 此字段的类型必须是日期。</para>
		/// <para>如果已提供位置 ID 参数值，则此参数为必填项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object TimeField { get; set; }

		/// <summary>
		/// <para>Number of Spatial Neighbors</para>
		/// <para>要包括在计算中的最近领域数。</para>
		/// <para>如果选择空间关系的概念化参数的固定距离、仅邻接边或邻接边拐角选项，则此数量为要包括在计算中的最小邻域数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumberOfSpatialNeighbors { get; set; }

		/// <summary>
		/// <para>Location ID</para>
		/// <para>包含每个位置的唯一 ID 编号的整型字段。</para>
		/// <para>此参数用于将输入要素参数中的要素与相关表中的行进行匹配，或指定用于确定时间邻域的唯一位置 ID。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short")]
		public object LocationId { get; set; }

		/// <summary>
		/// <para>Related Table</para>
		/// <para>包含输入要素参数的每个要素时态数据的表或表视图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object RelatedTable { get; set; }

		/// <summary>
		/// <para>Related Location ID</para>
		/// <para>相关表参数中包含关联所依据的位置 ID 参数值的整型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short")]
		public object RelatedLocationId { get; set; }

		/// <summary>
		/// <para>Spatial Weights Matrix File</para>
		/// <para>包含权重（定义要素间的空间关系以及可能的时态关系）的文件的路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("swm")]
		public object WeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Unique ID</para>
		/// <para>包含输入要素参数中每条记录的不同值的整型字段。 此字段可用于将结果连接回原始数据集。</para>
		/// <para>如果没有 Unique ID 字段，则可以创建一个，方法是向输入要素属性表添加一个整型字段，然后将此字段的值计算为与 FID 或 OBJECTID 字段的值相等。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short")]
		public object UniqueId { get; set; }

		/// <summary>
		/// <para>Null Value</para>
		/// <para>表示空（缺失）值的值。 如果未指定任何值，则将地理数据库要素类假定为 &lt;Null&gt;。 对于 shapefile 输入，空占位符的数值为必填项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object NullValue { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>包含已填充（估算）值的输出表。</para>
		/// <para>如果提供了相关表，则输出表为必填项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Append Fields to Input Features</para>
		/// <para>指定是将已填充值的字段追加到输入要素还是使用已填充值的字段创建新的输出要素类。 如果您追加字段，则不能提供相关表，且将忽略输出坐标系环境。</para>
		/// <para>选中 - 包含已填充值的字段将被追加到输入要素。 此选项会修改输入数据。</para>
		/// <para>未选中 - 将创建包含已填充值的字段的输出要素类。 这是默认设置。</para>
		/// <para><see cref="AppendToInputEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AppendToInput { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object UpdatedFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FillMissingValues SetEnviroment(object geographicTransformations = null, object outputCoordinateSystem = null)
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Fill Method</para>
		/// </summary>
		public enum FillMethodEnum 
		{
			/// <summary>
			/// <para>最小值—空值将替换为要素邻域的最小值。</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("最小值")]
			Minimum,

			/// <summary>
			/// <para>平均值—空值将替换为要素邻域的平均值。</para>
			/// </summary>
			[GPValue("AVERAGE")]
			[Description("平均值")]
			Average,

			/// <summary>
			/// <para>中值—空值将替换为要素邻域的中位数（中值）。</para>
			/// </summary>
			[GPValue("MEDIAN")]
			[Description("中值")]
			Median,

			/// <summary>
			/// <para>最大值—空值将替换为要素邻域的最大值。</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("最大值")]
			Maximum,

			/// <summary>
			/// <para>时间趋势—空值将基于该唯一位置处的趋势进行替换。</para>
			/// </summary>
			[GPValue("TEMPORAL_TREND")]
			[Description("时间趋势")]
			Temporal_Trend,

		}

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// </summary>
		public enum ConceptualizationOfSpatialRelationshipsEnum 
		{
			/// <summary>
			/// <para>固定距离—每个要素的指定临界距离（距离范围参数值）内的邻域要素都将包含在计算中；临界距离以外的所有要素都将排除在外。</para>
			/// </summary>
			[GPValue("FIXED_DISTANCE")]
			[Description("固定距离")]
			Fixed_distance,

			/// <summary>
			/// <para>K - 最近邻—最近的 k 个要素将包含在计算中；k 是指定的数字参数。</para>
			/// </summary>
			[GPValue("K_NEAREST_NEIGHBORS")]
			[Description("K - 最近邻")]
			K_nearest_neighbors,

			/// <summary>
			/// <para>仅邻接边—只有共享边界或重叠的相邻面要素会影响目标面要素的计算。</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_ONLY")]
			[Description("仅邻接边")]
			Contiguity_edges_only,

			/// <summary>
			/// <para>邻接边拐角—共享边界、节点或重叠的面要素会影响目标面要素的计算。</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_CORNERS")]
			[Description("邻接边拐角")]
			Contiguity_edges_corners,

			/// <summary>
			/// <para>通过文件获取空间权重—将由指定空间权重文件定义空间关系。 指向空间权重文件的路径由权重矩阵文件参数指定。</para>
			/// </summary>
			[GPValue("GET_SPATIAL_WEIGHTS_FROM_FILE")]
			[Description("通过文件获取空间权重")]
			Get_spatial_weights_from_file,

		}

		/// <summary>
		/// <para>Distance Band</para>
		/// </summary>
		public enum DistanceBandEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>Temporal Neighborhood</para>
		/// </summary>
		public enum TemporalNeighborhoodEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Hours")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Days")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Weeks")]
			[Description("Weeks")]
			Weeks,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Months")]
			[Description("Months")]
			Months,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Years")]
			[Description("Years")]
			Years,

		}

		/// <summary>
		/// <para>Append Fields to Input Features</para>
		/// </summary>
		public enum AppendToInputEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("APPEND_TO_INPUT")]
			APPEND_TO_INPUT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NEW_FEATURES")]
			NEW_FEATURES,

		}

#endregion
	}
}
