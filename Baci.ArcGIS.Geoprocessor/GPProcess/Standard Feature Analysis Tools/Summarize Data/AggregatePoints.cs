using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.StandardFeatureAnalysisTools
{
	/// <summary>
	/// <para>Aggregate Points</para>
	/// <para>聚合点</para>
	/// <para>使用点要素图层和面要素图层确定各面区域内的点。确定点与面的空间关系后，会计算出面内所有点的统计数据并将统计数据指定给该区域。</para>
	/// </summary>
	public class AggregatePoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Pointlayer">
		/// <para>Input Points</para>
		/// <para>将聚合到面图层中面的点要素。</para>
		/// </param>
		/// <param name="Polygonlayer">
		/// <para>Aggregating Polygons</para>
		/// <para>输入点将聚合到的面要素（区域）。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>要在门户中创建的输出图层的名称。</para>
		/// </param>
		/// <param name="Keepboundarieswithnopoints">
		/// <para>Keep boundaries with no points</para>
		/// <para>指定输出中是否返回不含点要素的面。</para>
		/// <para>选中 - 保留不含点要素的面。这是默认设置。</para>
		/// <para>未选中 - 输出中不返回不含点要素的面。</para>
		/// <para><see cref="KeepboundarieswithnopointsEnum"/></para>
		/// </param>
		public AggregatePoints(object Pointlayer, object Polygonlayer, object Outputname, object Keepboundarieswithnopoints)
		{
			this.Pointlayer = Pointlayer;
			this.Polygonlayer = Polygonlayer;
			this.Outputname = Outputname;
			this.Keepboundarieswithnopoints = Keepboundarieswithnopoints;
		}

		/// <summary>
		/// <para>Tool Display Name : 聚合点</para>
		/// </summary>
		public override string DisplayName() => "聚合点";

		/// <summary>
		/// <para>Tool Name : AggregatePoints</para>
		/// </summary>
		public override string ToolName() => "AggregatePoints";

		/// <summary>
		/// <para>Tool Excute Name : sfa.AggregatePoints</para>
		/// </summary>
		public override string ExcuteName() => "sfa.AggregatePoints";

		/// <summary>
		/// <para>Toolbox Display Name : Standard Feature Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Standard Feature Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : sfa</para>
		/// </summary>
		public override string ToolboxAlise() => "sfa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Pointlayer, Polygonlayer, Outputname, Keepboundarieswithnopoints, Summaryfields, Groupbyfield, Minoritymajority, Percentpoints, Aggregatedlayer, Groupsummary };

		/// <summary>
		/// <para>Input Points</para>
		/// <para>将聚合到面图层中面的点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		[FeatureType("Simple")]
		public object Pointlayer { get; set; }

		/// <summary>
		/// <para>Aggregating Polygons</para>
		/// <para>输入点将聚合到的面要素（区域）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object Polygonlayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>要在门户中创建的输出图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Keep boundaries with no points</para>
		/// <para>指定输出中是否返回不含点要素的面。</para>
		/// <para>选中 - 保留不含点要素的面。这是默认设置。</para>
		/// <para>未选中 - 输出中不返回不含点要素的面。</para>
		/// <para><see cref="KeepboundarieswithnopointsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Keepboundarieswithnopoints { get; set; } = "true";

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>字段名称及您想要为各面内全部点计算的统计汇总类型的列表。始终返回每个面内的点计数。支持的统计数据类型如下：</para>
		/// <para>总和 - 总值。</para>
		/// <para>最小值 - 最小值。</para>
		/// <para>最大值 - 最大值。</para>
		/// <para>平均值 - 平均值。</para>
		/// <para>标准差 - 标准差。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Summaryfields { get; set; }

		/// <summary>
		/// <para>Group By Field</para>
		/// <para>pointLayer 中的字段名称。分组条件字段具有相同值的点有属于其自身的计数和汇总字段统计数据。</para>
		/// <para>可以使用分析图层中的属性来创建统计组。例如，如果要将犯罪事件聚合至邻近地区边界，可能会有一个含有五种不同犯罪类型的 Crime_type 属性。各种唯一的犯罪类型构成一组，并将针对 Crime_type 的每个唯一值计算您选择的统计数据。选择分组属性后，将创建两个分析结果：结果图层，以及包含统计数据的相关表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object Groupbyfield { get; set; }

		/// <summary>
		/// <para>Add minority and majority attributes</para>
		/// <para>只有在指定分组条件字段后此布尔型参数才适用。如果选中，将对各个边界内每个组字段的少数（所占比例最小）或众数（所占比例最大）属性值进行计算。前缀为 Majority_ 和 Minority_ 的两个新字段将添加至输出图层。</para>
		/// <para>未选中 - 不添加少数和众数字段。这是默认设置。</para>
		/// <para>选中 - 添加少数和众数字段。</para>
		/// <para><see cref="MinoritymajorityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Minoritymajority { get; set; } = "false";

		/// <summary>
		/// <para>Add percentage</para>
		/// <para>只有在指定分组条件字段后此布尔型参数才适用。如果选中，会针对每个唯一的分组条件字段值对计算点的百分比计数。向输出组汇总表添加一个新字段，其中包含各组内每个属性值的百分比。如果添加少数和众数属性为真，则会有两个额外字段添加至输出，其中包含各组内少数属性值和多数属性值的百分比。</para>
		/// <para>未选中 - 不添加百分比字段。这是默认设置。</para>
		/// <para>选中 - 添加百分比字段。</para>
		/// <para><see cref="PercentpointsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Percentpoints { get; set; } = "false";

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Aggregatedlayer { get; set; }

		/// <summary>
		/// <para>Output Group Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object Groupsummary { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AggregatePoints SetEnviroment(object extent = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Keep boundaries with no points</para>
		/// </summary>
		public enum KeepboundarieswithnopointsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_EMPTY")]
			KEEP_EMPTY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("REMOVE_EMPTY")]
			REMOVE_EMPTY,

		}

		/// <summary>
		/// <para>Add minority and majority attributes</para>
		/// </summary>
		public enum MinoritymajorityEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_MIN_MAJ")]
			ADD_MIN_MAJ,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MIN_MAJ")]
			NO_MIN_MAJ,

		}

		/// <summary>
		/// <para>Add percentage</para>
		/// </summary>
		public enum PercentpointsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_PERCENT")]
			ADD_PERCENT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PERCENT")]
			NO_PERCENT,

		}

#endregion
	}
}
