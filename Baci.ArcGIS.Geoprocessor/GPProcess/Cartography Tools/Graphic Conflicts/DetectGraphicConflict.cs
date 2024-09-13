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
	/// <para>Detect Graphic Conflict</para>
	/// <para>检测图形冲突</para>
	/// <para>在两个或多个符号化要素发生图形冲突的位置处创建面。</para>
	/// </summary>
	public class DetectGraphicConflict : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Layer</para>
		/// <para>包含符号化要素的输入要素图层。 CAD、coverage 或 VPF 注记，以及尺寸、图表、点密度或比例符号、栅格图层、网络数据集和 3D 符号不是可接受的输入。</para>
		/// </param>
		/// <param name="ConflictFeatures">
		/// <para>Conflict Layer</para>
		/// <para>包含可能与输入图层中符号化要素产生冲突的符号化要素的要素图层。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>为存储冲突面而创建的输出要素类。 它不能是一个与输入图层关联的要素类。</para>
		/// </param>
		public DetectGraphicConflict(object InFeatures, object ConflictFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.ConflictFeatures = ConflictFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 检测图形冲突</para>
		/// </summary>
		public override string DisplayName() => "检测图形冲突";

		/// <summary>
		/// <para>Tool Name : DetectGraphicConflict</para>
		/// </summary>
		public override string ToolName() => "DetectGraphicConflict";

		/// <summary>
		/// <para>Tool Excute Name : cartography.DetectGraphicConflict</para>
		/// </summary>
		public override string ExcuteName() => "cartography.DetectGraphicConflict";

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
		public override string[] ValidEnvironments() => new string[] { "cartographicCoordinateSystem", "cartographicPartitions", "referenceScale" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, ConflictFeatures, OutFeatureClass, ConflictDistance!, LineConnectionAllowance! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>包含符号化要素的输入要素图层。 CAD、coverage 或 VPF 注记，以及尺寸、图表、点密度或比例符号、栅格图层、网络数据集和 3D 符号不是可接受的输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Conflict Layer</para>
		/// <para>包含可能与输入图层中符号化要素产生冲突的符号化要素的要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		public object ConflictFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>为存储冲突面而创建的输出要素类。 它不能是一个与输入图层关联的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Conflict Distance</para>
		/// <para>输入和冲突符号系统比指定距离近的区域。 将在输入和冲突图层中的符号周围创建一个大小为冲突距离值一半的临时缓冲区。 将在这些缓冲区叠置的位置处生成冲突面。 冲突距离以页面单位（磅、英寸、毫米或厘米）测量。 如果以地图单位输入冲突距离，则会使用参考比例将其转换为页面单位。 默认冲突距离为 0，此时不创建缓冲区，而且只会将物理上互相叠置的符号检测为冲突。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? ConflictDistance { get; set; } = "0 Points";

		/// <summary>
		/// <para>Line Connection Allowance</para>
		/// <para>中心位于线连接位置的圆的半径，在此圆内不会检测到图形叠置。 仅在输入图层和冲突图层相同时，才考虑此参数。 零容许值将检测各线连接处的冲突（如果端头叠置）。 以页面单位（磅、英寸、毫米或厘米）计算线连接容许值。 如果以地图单位输入容许值，则会使用参考比例将其转换为页面单位。 该值不能为负；默认值是 1 磅。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? LineConnectionAllowance { get; set; } = "1 Points";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DetectGraphicConflict SetEnviroment(object? cartographicCoordinateSystem = null , object? cartographicPartitions = null , double? referenceScale = null )
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem, cartographicPartitions: cartographicPartitions, referenceScale: referenceScale);
			return this;
		}

	}
}
