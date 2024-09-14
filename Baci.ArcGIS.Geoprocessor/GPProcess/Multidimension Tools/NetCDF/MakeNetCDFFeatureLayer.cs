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
	/// <para>Make NetCDF Feature Layer</para>
	/// <para>创建 NetCDF 要素图层</para>
	/// <para>根据 NetCDF 文件创建要素图层。</para>
	/// </summary>
	public class MakeNetCDFFeatureLayer : AbstractGPProcess
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
		/// <para>将以字段形式添加到要素属性表中的 netCDF 变量。</para>
		/// </param>
		/// <param name="XVariable">
		/// <para>X Variable</para>
		/// <para>定义输出图层的 x 坐标或经度坐标时使用的 netCDF 坐标变量。</para>
		/// </param>
		/// <param name="YVariable">
		/// <para>Y Variable</para>
		/// <para>定义输出图层的 y 坐标或纬度坐标时使用的 netCDF 坐标变量。</para>
		/// </param>
		/// <param name="OutFeatureLayer">
		/// <para>Output Feature Layer</para>
		/// <para>输出要素图层的名称。</para>
		/// </param>
		public MakeNetCDFFeatureLayer(object InNetcdfFile, object Variable, object XVariable, object YVariable, object OutFeatureLayer)
		{
			this.InNetcdfFile = InNetcdfFile;
			this.Variable = Variable;
			this.XVariable = XVariable;
			this.YVariable = YVariable;
			this.OutFeatureLayer = OutFeatureLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 NetCDF 要素图层</para>
		/// </summary>
		public override string DisplayName() => "创建 NetCDF 要素图层";

		/// <summary>
		/// <para>Tool Name : MakeNetCDFFeatureLayer</para>
		/// </summary>
		public override string ToolName() => "MakeNetCDFFeatureLayer";

		/// <summary>
		/// <para>Tool Excute Name : md.MakeNetCDFFeatureLayer</para>
		/// </summary>
		public override string ExcuteName() => "md.MakeNetCDFFeatureLayer";

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
		public override object[] Parameters() => new object[] { InNetcdfFile, Variable, XVariable, YVariable, OutFeatureLayer, RowDimension!, ZVariable!, MVariable!, DimensionValues!, ValueSelectionMethod! };

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
		/// <para>将以字段形式添加到要素属性表中的 netCDF 变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Variable { get; set; }

		/// <summary>
		/// <para>X Variable</para>
		/// <para>定义输出图层的 x 坐标或经度坐标时使用的 netCDF 坐标变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object XVariable { get; set; }

		/// <summary>
		/// <para>Y Variable</para>
		/// <para>定义输出图层的 y 坐标或纬度坐标时使用的 netCDF 坐标变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object YVariable { get; set; }

		/// <summary>
		/// <para>Output Feature Layer</para>
		/// <para>输出要素图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object OutFeatureLayer { get; set; }

		/// <summary>
		/// <para>Row Dimensions</para>
		/// <para>在要素图层中创建具有唯一值的要素时使用的 netCDF 维度。 此处设置的维度决定了要素图层中的要素数量以及将在要素图层的属性表中显示的字段。</para>
		/// <para>例如，如果 StationID 是 netCDF 文件中的一个维度且具有 10 个值，则通过将 StationID 设置为要使用的维度，将可以创建 10 个要素（在要素图层的属性表中将创建 10 行）。 如果当前使用 StationID 和时间，且存在 3 个时间片，则将创建 30 个要素（要素图层的属性表中将创建 30 行）。 如果要以动画形式呈现 netCDF 要素图层，出于效率方面的考虑，建议您不要将时间设置为行维度。 在动画处理的整个过程中仍可以将时间用作维度，但属性表中将不存储此信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? RowDimension { get; set; }

		/// <summary>
		/// <para>Z Variable</para>
		/// <para>指定要素的高程值（z 值）时使用的 netCDF 变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ZVariable { get; set; }

		/// <summary>
		/// <para>M Variable</para>
		/// <para>指定要素的线性测量值（m 值）时使用的 netCDF 变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? MVariable { get; set; }

		/// <summary>
		/// <para>Dimension Values</para>
		/// <para>在输出图层中显示变量时要使用的维度（如时间）的值（如 01/30/05）。 默认情况下，将使用维度的第一个值。</para>
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
		public MakeNetCDFFeatureLayer SetEnviroment(object? workspace = null)
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
