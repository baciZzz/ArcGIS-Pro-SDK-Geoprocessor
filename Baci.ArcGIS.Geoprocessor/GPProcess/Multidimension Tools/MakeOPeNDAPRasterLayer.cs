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
	/// <para>Make OPeNDAP Raster Layer</para>
	/// <para>创建 OPeNDAP 栅格图层</para>
	/// <para>通过存储在 OPeNDAP 服务器上的数据创建栅格图层。</para>
	/// </summary>
	public class MakeOPeNDAPRasterLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InOpendapURL">
		/// <para>Input OPeNDAP URL</para>
		/// <para>引用远程 OPeNDAP 数据集的 URL。URL 应解析到数据集级别（例如，文件名），而非目录名称。</para>
		/// </param>
		/// <param name="Variable">
		/// <para>Variable</para>
		/// <para>将用于创建栅格图层的 OPeNDAP 数据集中的变量。</para>
		/// </param>
		/// <param name="XDimension">
		/// <para>X Dimension</para>
		/// <para>用于定义输出栅格图层 x 坐标（或经度坐标）的 OPeNDAP 数据集维度。</para>
		/// </param>
		/// <param name="YDimension">
		/// <para>Y Dimension</para>
		/// <para>用于定义输出栅格图层 y 坐标（或纬度坐标）的 OPeNDAP 数据集维度。</para>
		/// </param>
		/// <param name="OutRasterLayer">
		/// <para>Output Raster Layer</para>
		/// <para>输出栅格图层的名称。</para>
		/// </param>
		public MakeOPeNDAPRasterLayer(object InOpendapURL, object Variable, object XDimension, object YDimension, object OutRasterLayer)
		{
			this.InOpendapURL = InOpendapURL;
			this.Variable = Variable;
			this.XDimension = XDimension;
			this.YDimension = YDimension;
			this.OutRasterLayer = OutRasterLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 OPeNDAP 栅格图层</para>
		/// </summary>
		public override string DisplayName() => "创建 OPeNDAP 栅格图层";

		/// <summary>
		/// <para>Tool Name : MakeOPeNDAPRasterLayer</para>
		/// </summary>
		public override string ToolName() => "MakeOPeNDAPRasterLayer";

		/// <summary>
		/// <para>Tool Excute Name : md.MakeOPeNDAPRasterLayer</para>
		/// </summary>
		public override string ExcuteName() => "md.MakeOPeNDAPRasterLayer";

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
		public override object[] Parameters() => new object[] { InOpendapURL, Variable, XDimension, YDimension, OutRasterLayer, Extent, DimensionValues, ValueSelectionMethod, CellRegistration };

		/// <summary>
		/// <para>Input OPeNDAP URL</para>
		/// <para>引用远程 OPeNDAP 数据集的 URL。URL 应解析到数据集级别（例如，文件名），而非目录名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InOpendapURL { get; set; }

		/// <summary>
		/// <para>Variable</para>
		/// <para>将用于创建栅格图层的 OPeNDAP 数据集中的变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Variable { get; set; }

		/// <summary>
		/// <para>X Dimension</para>
		/// <para>用于定义输出栅格图层 x 坐标（或经度坐标）的 OPeNDAP 数据集维度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object XDimension { get; set; }

		/// <summary>
		/// <para>Y Dimension</para>
		/// <para>用于定义输出栅格图层 y 坐标（或纬度坐标）的 OPeNDAP 数据集维度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object YDimension { get; set; }

		/// <summary>
		/// <para>Output Raster Layer</para>
		/// <para>输出栅格图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object OutRasterLayer { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>栅格图层的输出范围。按 OPeNDAP 数据源的单位（可能为纬度-经度、投影坐标或一些任意格网坐标）指定范围坐标。此参数用于在感兴趣区域构建子集或减少所传输数据的大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEnvelope()]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Dimension Values</para>
		/// <para>一个或多个维度的开始和结束值，可用于限制从远程 OPeNDAP 服务器中提取的数据。默认情况下，将使用一个或多个维度的最小和最大值。</para>
		/// <para>维度 - netCDF 维度。</para>
		/// <para>起始值 - 用于所指定维度的起始值。</para>
		/// <para>结束值 - 可用的结束值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object DimensionValues { get; set; }

		/// <summary>
		/// <para>Value Selection Method</para>
		/// <para>指定将使用的维度值选择方法。</para>
		/// <para>按值—输入值与实际维度值匹配。</para>
		/// <para>按索引—输入值与维度值的位置或索引匹配。 索引的第一个值为 0；即位置从 0 开始。</para>
		/// <para><see cref="ValueSelectionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ValueSelectionMethod { get; set; } = "BY_VALUE";

		/// <summary>
		/// <para>Cell Registration</para>
		/// <para>指定像元相对于 XY 坐标的配准方式。</para>
		/// <para>中心—XY 坐标表示像元中心。 这是默认设置。</para>
		/// <para>左下角—XY 坐标表示像元左下角。</para>
		/// <para>左上角—XY 坐标表示像元左上角。</para>
		/// <para><see cref="CellRegistrationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CellRegistration { get; set; } = "CENTER";

		#region InnerClass

		/// <summary>
		/// <para>Value Selection Method</para>
		/// </summary>
		public enum ValueSelectionMethodEnum 
		{
			/// <summary>
			/// <para>按索引—输入值与维度值的位置或索引匹配。 索引的第一个值为 0；即位置从 0 开始。</para>
			/// </summary>
			[GPValue("BY_INDEX")]
			[Description("按索引")]
			By_index,

			/// <summary>
			/// <para>按值—输入值与实际维度值匹配。</para>
			/// </summary>
			[GPValue("BY_VALUE")]
			[Description("按值")]
			By_value,

		}

		/// <summary>
		/// <para>Cell Registration</para>
		/// </summary>
		public enum CellRegistrationEnum 
		{
			/// <summary>
			/// <para>中心—XY 坐标表示像元中心。 这是默认设置。</para>
			/// </summary>
			[GPValue("CENTER")]
			[Description("中心")]
			Center,

			/// <summary>
			/// <para>左下角—XY 坐标表示像元左下角。</para>
			/// </summary>
			[GPValue("LOWER_LEFT")]
			[Description("左下角")]
			Lower_Left,

			/// <summary>
			/// <para>左上角—XY 坐标表示像元左上角。</para>
			/// </summary>
			[GPValue("UPPER_LEFT")]
			[Description("左上角")]
			Upper_Left,

		}

#endregion
	}
}
