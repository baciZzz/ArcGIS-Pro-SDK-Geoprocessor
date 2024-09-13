using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>Least Cost Path</para>
	/// <para>最低成本路径</para>
	/// <para>查找成本表面上起点和终点之间的最短路径。</para>
	/// </summary>
	public class LeastCostPath : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCostSurface">
		/// <para>Input Cost Surface</para>
		/// <para>用于确定从起点行驶到终点的成本的输入栅格。 无法跨越“无数据”值。</para>
		/// </param>
		/// <param name="InStartPoint">
		/// <para>Input Starting Point</para>
		/// <para>输入起点要素。 多个起点将显著增加处理时间。</para>
		/// </param>
		/// <param name="InEndPoint">
		/// <para>Input Ending Point</para>
		/// <para>输入终点要素。 多个终点将增加输出线的数量，因为生成的路径会分支为独立的路径。</para>
		/// </param>
		/// <param name="OutPathFeatureClass">
		/// <para>Output Path Feature Class</para>
		/// <para>输出路径要素类。</para>
		/// </param>
		public LeastCostPath(object InCostSurface, object InStartPoint, object InEndPoint, object OutPathFeatureClass)
		{
			this.InCostSurface = InCostSurface;
			this.InStartPoint = InStartPoint;
			this.InEndPoint = InEndPoint;
			this.OutPathFeatureClass = OutPathFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 最低成本路径</para>
		/// </summary>
		public override string DisplayName() => "最低成本路径";

		/// <summary>
		/// <para>Tool Name : LeastCostPath</para>
		/// </summary>
		public override string ToolName() => "LeastCostPath";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.LeastCostPath</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.LeastCostPath";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise() => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCostSurface, InStartPoint, InEndPoint, OutPathFeatureClass, HandleZeros, OutStartPoint, OutEndPoint };

		/// <summary>
		/// <para>Input Cost Surface</para>
		/// <para>用于确定从起点行驶到终点的成本的输入栅格。 无法跨越“无数据”值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InCostSurface { get; set; }

		/// <summary>
		/// <para>Input Starting Point</para>
		/// <para>输入起点要素。 多个起点将显著增加处理时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InStartPoint { get; set; }

		/// <summary>
		/// <para>Input Ending Point</para>
		/// <para>输入终点要素。 多个终点将增加输出线的数量，因为生成的路径会分支为独立的路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InEndPoint { get; set; }

		/// <summary>
		/// <para>Output Path Feature Class</para>
		/// <para>输出路径要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPathFeatureClass { get; set; }

		/// <summary>
		/// <para>Zero Cost Handled As</para>
		/// <para>指定输入成本表面参数中零值的处理方式。</para>
		/// <para>较小正值—所有零值都将更改为较小的正值。 这样即可遍历像元。 这是默认设置。</para>
		/// <para>无数据—所有零值都将更改为空值。 不会遍历像元且将避开像元。</para>
		/// <para><see cref="HandleZerosEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object HandleZeros { get; set; } = "SMALL_POSITIVE";

		/// <summary>
		/// <para>Output Start Point</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutStartPoint { get; set; }

		/// <summary>
		/// <para>Output End Point</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutEndPoint { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Zero Cost Handled As</para>
		/// </summary>
		public enum HandleZerosEnum 
		{
			/// <summary>
			/// <para>较小正值—所有零值都将更改为较小的正值。 这样即可遍历像元。 这是默认设置。</para>
			/// </summary>
			[GPValue("SMALL_POSITIVE")]
			[Description("较小正值")]
			Small_positive,

			/// <summary>
			/// <para>无数据—所有零值都将更改为空值。 不会遍历像元且将避开像元。</para>
			/// </summary>
			[GPValue("NO_DATA")]
			[Description("无数据")]
			No_data,

		}

#endregion
	}
}
