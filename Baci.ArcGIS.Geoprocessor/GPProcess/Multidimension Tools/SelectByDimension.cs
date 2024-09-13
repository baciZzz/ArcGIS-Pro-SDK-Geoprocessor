using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.MultidimensionTools
{
	/// <summary>
	/// <para>Select by Dimension</para>
	/// <para>按维度选择</para>
	/// <para>基于维度值更新 netCDF 图层显示或 netCDF 表视图。</para>
	/// </summary>
	public class SelectByDimension : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayerOrTable">
		/// <para>Input Layer or Table</para>
		/// <para>输入 netCDF 栅格图层、netCDF 要素图层、netCDF 表视图或镶嵌图层。如果输入是镶嵌图层，则必须为多维度。</para>
		/// </param>
		public SelectByDimension(object InLayerOrTable)
		{
			this.InLayerOrTable = InLayerOrTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 按维度选择</para>
		/// </summary>
		public override string DisplayName() => "按维度选择";

		/// <summary>
		/// <para>Tool Name : SelectByDimension</para>
		/// </summary>
		public override string ToolName() => "SelectByDimension";

		/// <summary>
		/// <para>Tool Excute Name : md.SelectByDimension</para>
		/// </summary>
		public override string ExcuteName() => "md.SelectByDimension";

		/// <summary>
		/// <para>Toolbox Display Name : Multidimension Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Multidimension Tools";

		/// <summary>
		/// <para>Toolbox Alise : md</para>
		/// </summary>
		public override string ToolboxAlise() => "md";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLayerOrTable, DimensionValues!, ValueSelectionMethod!, OutputLayerOrTable! };

		/// <summary>
		/// <para>Input Layer or Table</para>
		/// <para>输入 netCDF 栅格图层、netCDF 要素图层、netCDF 表视图或镶嵌图层。如果输入是镶嵌图层，则必须为多维度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InLayerOrTable { get; set; }

		/// <summary>
		/// <para>Dimension Values</para>
		/// <para>指定部分多维变量时使用的一组维度值对。</para>
		/// <para>维度 - netCDF 维度。</para>
		/// <para>值 - 用于指定部分多维变量的维度值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? DimensionValues { get; set; }

		/// <summary>
		/// <para>Value Selection Method</para>
		/// <para>指定将使用的维度值选择方法。</para>
		/// <para>按值—输入值将与实际维度值匹配。</para>
		/// <para>按索引—输入值将与维度值的位置或索引匹配。 索引的第一个值为 0；即位置从 0 开始。</para>
		/// <para><see cref="ValueSelectionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ValueSelectionMethod { get; set; } = "BY_VALUE";

		/// <summary>
		/// <para>Updated layer or table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutputLayerOrTable { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Value Selection Method</para>
		/// </summary>
		public enum ValueSelectionMethodEnum 
		{
			/// <summary>
			/// <para>按索引—输入值将与维度值的位置或索引匹配。 索引的第一个值为 0；即位置从 0 开始。</para>
			/// </summary>
			[GPValue("BY_INDEX")]
			[Description("按索引")]
			By_index,

			/// <summary>
			/// <para>按值—输入值将与实际维度值匹配。</para>
			/// </summary>
			[GPValue("BY_VALUE")]
			[Description("按值")]
			By_value,

		}

#endregion
	}
}
