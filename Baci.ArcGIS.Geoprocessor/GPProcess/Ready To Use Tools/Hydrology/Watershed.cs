using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ReadyToUseTools
{
	/// <summary>
	/// <para>Watershed</para>
	/// <para>集水区</para>
	/// <para>用于确定各个输入点之上的汇流区域。集水区是汇集水流的上坡区域。</para>
	/// </summary>
	public class Watershed : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputpoints">
		/// <para>Input Points</para>
		/// <para>用于计算集水区的点要素。这些点要素被称为倾泻点，因为其是水从集水区倾泻而出的位置。</para>
		/// </param>
		public Watershed(object Inputpoints)
		{
			this.Inputpoints = Inputpoints;
		}

		/// <summary>
		/// <para>Tool Display Name : 集水区</para>
		/// </summary>
		public override string DisplayName() => "集水区";

		/// <summary>
		/// <para>Tool Name : 集水区</para>
		/// </summary>
		public override string ToolName() => "集水区";

		/// <summary>
		/// <para>Tool Excute Name : agolservices.Watershed</para>
		/// </summary>
		public override string ExcuteName() => "agolservices.Watershed";

		/// <summary>
		/// <para>Toolbox Display Name : Ready To Use Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Ready To Use Tools";

		/// <summary>
		/// <para>Toolbox Alise : agolservices</para>
		/// </summary>
		public override string ToolboxAlise() => "agolservices";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputpoints, Pointidfield!, Snapdistance!, Snapdistanceunits!, Datasourceresolution!, Generalize!, Returnsnappedpoints!, Watershedarea!, Snappedpoints! };

		/// <summary>
		/// <para>Input Points</para>
		/// <para>用于计算集水区的点要素。这些点要素被称为倾泻点，因为其是水从集水区倾泻而出的位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Inputpoints { get; set; }

		/// <summary>
		/// <para>Point Identification Field</para>
		/// <para>用于标识输入点的整型或字符串字段。</para>
		/// <para>默认使用唯一 ID 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Pointidfield { get; set; }

		/// <summary>
		/// <para>Snap Distance</para>
		/// <para>用于移动输入点位置的最大距离。</para>
		/// <para>交互式输入点和记录的标尺位置可能与 DEM 中的河流位置未完全对齐。此参数允许服务将该点移动到具有最大汇集水流面积的附近位置。</para>
		/// <para>默认情况下，捕捉距离的计算方法为源数据的分辨率乘以 5。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Snapdistance { get; set; }

		/// <summary>
		/// <para>Snap Distance Units</para>
		/// <para>针对捕捉距离指定的线性单位。</para>
		/// <para>米—单位为米。 这是默认设置。</para>
		/// <para>千米—单位为千米。</para>
		/// <para>英尺—单位为英尺。</para>
		/// <para>码—单位为码。</para>
		/// <para>英里—单位为英里。</para>
		/// <para><see cref="SnapdistanceunitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Snapdistanceunits { get; set; } = "Meters";

		/// <summary>
		/// <para>Data Source Resolution</para>
		/// <para>指定将用于分析的源数据分辨率。 这些值是用于构建基础水文数据库的数字高程模型的空间分辨率近似值。 由于许多高程源以弧秒为单位进行分布，为了更方便理解，我们提供了以米为单位的近似值。</para>
		/// <para>空—将使用基于 3 弧秒的数据源（分辨率大约为 90 米的高程数据）构建的水文源。 这是默认设置。</para>
		/// <para>最精细—将使用所有可能数据源的每个位置的最佳可用分辨率。</para>
		/// <para>10 米—将使用基于 1/3 弧秒的数据源（分辨率大约为 10 米的高程数据）构建的水文源。</para>
		/// <para>30 米—将使用基于 1 弧秒的数据源（分辨率大约为 30 米的高程数据）构建的水文源。</para>
		/// <para>90 米—将使用基于 3 弧秒的数据源（分辨率大约为 90 米的高程数据）构建的水文源。</para>
		/// <para><see cref="DatasourceresolutionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Datasourceresolution { get; set; } = " ";

		/// <summary>
		/// <para>Generalize</para>
		/// <para>指定是将输出流域平滑处理为更简单的形状还是将其与原始 DEM 的像元边保持一致。</para>
		/// <para>未选中 - 面的边缘将与原始 DEM 的像元边缘保持一致。 这是默认设置。</para>
		/// <para>选中 - 面边界将被平滑处理为简单的形状。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		public object? Generalize { get; set; } = "false";

		/// <summary>
		/// <para>Return Snapped Points</para>
		/// <para>确定是否返回集水区倾泻点处的点要素。如果启用捕捉，则捕捉到的点可能与输入点不同。</para>
		/// <para>未选中 - 将不返回点要素。</para>
		/// <para>选中 - 将返回点要素。这是默认设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		public object? Returnsnappedpoints { get; set; } = "true";

		/// <summary>
		/// <para>Output Watershed</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? Watershedarea { get; set; }

		/// <summary>
		/// <para>Output Snapped Points</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? Snappedpoints { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Snap Distance Units</para>
		/// </summary>
		public enum SnapdistanceunitsEnum 
		{
			/// <summary>
			/// <para>米—单位为米。 这是默认设置。</para>
			/// </summary>
			[GPValue("Meters")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para>千米—单位为千米。</para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("千米")]
			Kilometers,

			/// <summary>
			/// <para>英尺—单位为英尺。</para>
			/// </summary>
			[GPValue("Feet")]
			[Description("英尺")]
			Feet,

			/// <summary>
			/// <para>码—单位为码。</para>
			/// </summary>
			[GPValue("Yards")]
			[Description("码")]
			Yards,

			/// <summary>
			/// <para>英里—单位为英里。</para>
			/// </summary>
			[GPValue("Miles")]
			[Description("英里")]
			Miles,

		}

		/// <summary>
		/// <para>Data Source Resolution</para>
		/// </summary>
		public enum DatasourceresolutionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue(" ")]
			[Description(" ")]
			_,

			/// <summary>
			/// <para>最精细—将使用所有可能数据源的每个位置的最佳可用分辨率。</para>
			/// </summary>
			[GPValue("FINEST")]
			[Description("最精细")]
			Finest,

			/// <summary>
			/// <para>10 米—将使用基于 1/3 弧秒的数据源（分辨率大约为 10 米的高程数据）构建的水文源。</para>
			/// </summary>
			[GPValue("10m")]
			[Description("10 米")]
			_10_meters,

			/// <summary>
			/// <para>30 米—将使用基于 1 弧秒的数据源（分辨率大约为 30 米的高程数据）构建的水文源。</para>
			/// </summary>
			[GPValue("30m")]
			[Description("30 米")]
			_30_meters,

			/// <summary>
			/// <para>90 米—将使用基于 3 弧秒的数据源（分辨率大约为 90 米的高程数据）构建的水文源。</para>
			/// </summary>
			[GPValue("90m")]
			[Description("90 米")]
			_90_meters,

		}

#endregion
	}
}
