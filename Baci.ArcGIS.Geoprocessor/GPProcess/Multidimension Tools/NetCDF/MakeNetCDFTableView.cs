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
	/// <para>Make NetCDF Table View</para>
	/// <para>创建 NetCDF 表视图</para>
	/// <para>根据 NetCDF 文件创建表格视图。</para>
	/// </summary>
	public class MakeNetCDFTableView : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetcdfFile">
		/// <para>Input netCDF File</para>
		/// <para>输入的 NetCDF 文件。</para>
		/// </param>
		/// <param name="Variable">
		/// <para>Variables</para>
		/// <para>在表视图中创建字段时使用的 netCDF 变量。</para>
		/// </param>
		/// <param name="OutTableView">
		/// <para>Output Table View</para>
		/// <para>输出表视图的名称。</para>
		/// </param>
		public MakeNetCDFTableView(object InNetcdfFile, object Variable, object OutTableView)
		{
			this.InNetcdfFile = InNetcdfFile;
			this.Variable = Variable;
			this.OutTableView = OutTableView;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 NetCDF 表视图</para>
		/// </summary>
		public override string DisplayName() => "创建 NetCDF 表视图";

		/// <summary>
		/// <para>Tool Name : MakeNetCDFTableView</para>
		/// </summary>
		public override string ToolName() => "MakeNetCDFTableView";

		/// <summary>
		/// <para>Tool Excute Name : md.MakeNetCDFTableView</para>
		/// </summary>
		public override string ExcuteName() => "md.MakeNetCDFTableView";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InNetcdfFile, Variable, OutTableView, RowDimension!, DimensionValues!, ValueSelectionMethod! };

		/// <summary>
		/// <para>Input netCDF File</para>
		/// <para>输入的 NetCDF 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc", "nc4")]
		public object InNetcdfFile { get; set; }

		/// <summary>
		/// <para>Variables</para>
		/// <para>在表视图中创建字段时使用的 netCDF 变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Variable { get; set; }

		/// <summary>
		/// <para>Output Table View</para>
		/// <para>输出表视图的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object OutTableView { get; set; }

		/// <summary>
		/// <para>Row Dimensions</para>
		/// <para>在表视图中创建包含唯一值的字段时使用的 netCDF 维度。 此处设置的维度决定了表视图中的行数和要显示的字段。</para>
		/// <para>例如，如果 stationID 是 netCDF 文件中的一个维度且具有 10 个值，则通过将 stationID 设置为要使用的维度，将可以在表视图中创建 10 行。 如果当前使用 stationID 和时间，且存在 3 个时间片，则将在表视图中创建 30 行。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? RowDimension { get; set; }

		/// <summary>
		/// <para>Dimension Values</para>
		/// <para>指定部分多维变量时使用的一组维度值对。</para>
		/// <para>维度 - netCDF 维度。</para>
		/// <para>值 - 可用的维度值。</para>
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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeNetCDFTableView SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

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
