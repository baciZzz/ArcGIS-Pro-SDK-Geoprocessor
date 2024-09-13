using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CartographyTools
{
	/// <summary>
	/// <para>Create Cartographic Partitions</para>
	/// <para>创建制图分区</para>
	/// <para>创建一组网状面要素，来覆盖输入要素类，其中每个输出面封闭的输入要素或输入折点不超过指定的数量，该数量由输入要素的密度和分布决定。</para>
	/// </summary>
	public class CreateCartographicPartitions : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要素分布和密度或折点分布和密度指定输出面的大小和排列的输入要素类或图层。 输入要素通常会使用其他地理处理工具进行后续处理。 同时处理输入要素时，通常会超出其他工具的内存限制，所以要创建分区以细分要处理的输入。</para>
		/// </param>
		/// <param name="OutFeatures">
		/// <para>Output Features</para>
		/// <para>分区的输出面要素类，其中的每个面封闭数量可控的输入要素或输入折点，不超过要素计数参数指定的数量。</para>
		/// </param>
		/// <param name="FeatureCount">
		/// <para>Feature Count</para>
		/// <para>输出要素类中每个面封闭的理想要素或折点数（取决于分区方法参数值）。 建议的要素计数为 50,000，该值为默认值。 对于折点，一百万个折点将消耗大约 0.5 GB 的内存，具体取决于使用分区的工具。 要素计数不能少于 500。</para>
		/// </param>
		public CreateCartographicPartitions(object InFeatures, object OutFeatures, object FeatureCount)
		{
			this.InFeatures = InFeatures;
			this.OutFeatures = OutFeatures;
			this.FeatureCount = FeatureCount;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建制图分区</para>
		/// </summary>
		public override string DisplayName() => "创建制图分区";

		/// <summary>
		/// <para>Tool Name : CreateCartographicPartitions</para>
		/// </summary>
		public override string ToolName() => "CreateCartographicPartitions";

		/// <summary>
		/// <para>Tool Excute Name : cartography.CreateCartographicPartitions</para>
		/// </summary>
		public override string ExcuteName() => "cartography.CreateCartographicPartitions";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise() => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatures, FeatureCount, PartitionMethod };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要素分布和密度或折点分布和密度指定输出面的大小和排列的输入要素类或图层。 输入要素通常会使用其他地理处理工具进行后续处理。 同时处理输入要素时，通常会超出其他工具的内存限制，所以要创建分区以细分要处理的输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>分区的输出面要素类，其中的每个面封闭数量可控的输入要素或输入折点，不超过要素计数参数指定的数量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Feature Count</para>
		/// <para>输出要素类中每个面封闭的理想要素或折点数（取决于分区方法参数值）。 建议的要素计数为 50,000，该值为默认值。 对于折点，一百万个折点将消耗大约 0.5 GB 的内存，具体取决于使用分区的工具。 要素计数不能少于 500。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain(Min = 500, Max = 2147483647)]
		public object FeatureCount { get; set; } = "50000";

		/// <summary>
		/// <para>Partition Method</para>
		/// <para>指定要素计数参数是否引用每个输出面中的理想要素数或理想折点数。</para>
		/// <para>要素—分区考虑了各个要素的数量和密度。 此方法为默认方法，适用于大多数情况。</para>
		/// <para>折点—分区考虑了折点的数量和密度。 在输入数据包含数量相对较少的极复杂要素（如高分辨率国家/地区面）的情况下，或者在极长要素（如等值线）可能跨越多个分区边界的情况下，使用该方法。</para>
		/// <para><see cref="PartitionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PartitionMethod { get; set; } = "FEATURES";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateCartographicPartitions SetEnviroment(object outputCoordinateSystem = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Partition Method</para>
		/// </summary>
		public enum PartitionMethodEnum 
		{
			/// <summary>
			/// <para>要素—分区考虑了各个要素的数量和密度。 此方法为默认方法，适用于大多数情况。</para>
			/// </summary>
			[GPValue("FEATURES")]
			[Description("要素")]
			Features,

			/// <summary>
			/// <para>折点—分区考虑了折点的数量和密度。 在输入数据包含数量相对较少的极复杂要素（如高分辨率国家/地区面）的情况下，或者在极长要素（如等值线）可能跨越多个分区边界的情况下，使用该方法。</para>
			/// </summary>
			[GPValue("VERTICES")]
			[Description("折点")]
			Vertices,

		}

#endregion
	}
}
