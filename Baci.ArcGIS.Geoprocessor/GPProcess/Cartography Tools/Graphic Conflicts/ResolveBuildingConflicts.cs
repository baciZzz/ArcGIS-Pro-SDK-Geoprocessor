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
	/// <para>Resolve Building Conflicts</para>
	/// <para>解决建筑物冲突</para>
	/// <para>通过移动、调整大小或隐藏建筑物解决建筑物间的符号冲突以及与线状障碍要素有关的符号冲突。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ResolveBuildingConflicts : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InBuildings">
		/// <para>Input Building Layers</para>
		/// <para>包含可能存在冲突或者小于容许大小的建筑物要素的输入图层。 建筑物可以是点或面。 将对建筑物进行修改以解决它们与其他建筑物和障碍要素的冲突。</para>
		/// <para>将点建筑物图层用作输入时，必须将标记符号图层的角度属性设置为要素类中的字段。 该字段将存储旋转调整。</para>
		/// </param>
		/// <param name="InvisibilityField">
		/// <para>Invisibility Field</para>
		/// <para>存储不可见性值的字段，不可见性值可用于从显示中移除某些建筑物以解决符号冲突。 值为 1 的建筑物将从显示中移除；值为零的建筑物不会被移除。 对图层使用定义查询可只显示可见建筑物。 未删除要素。</para>
		/// </param>
		/// <param name="InBarriers">
		/// <para>Input Barrier Layers</para>
		/// <para>作为与输入建筑物要素存在冲突的障碍的所有线状要素或面状要素所在的图层。 将对建筑物进行修改以解决建筑物与障碍之间的冲突。 定向值为布尔值，用于指定是否将建筑物定向到障碍图层。</para>
		/// <para>间距用于指定建筑物将朝向或远离障碍图层所移动的距离。 输入此值时必须带有单位。</para>
		/// <para>间距值 0（零）表示会将建筑物直接捕捉到障碍线或轮廓符号系统的边缘。</para>
		/// <para>null（未指定）间距值表示除解决冲突所需的移动外，建筑物将不会移向或远离障碍线或轮廓线。</para>
		/// <para>如果输入间距值时未带有单位（如输入 10 而不是 10 米），将使用输入要素的坐标系的线性单位。</para>
		/// </param>
		/// <param name="BuildingGap">
		/// <para>Building Gap</para>
		/// <para>某比例下符号化的建筑物之间的最小容许距离。 将移动或隐藏间距小于此距离的建筑物以保持此距离。 最小容许距离将相对于参考比例进行设置（如，1:50,000 比例下为 15 米）。 如果未设置参考比例，最小容许距离值为 0。</para>
		/// </param>
		/// <param name="MinimumSize">
		/// <para>Minimum Allowable Building Size</para>
		/// <para>经旋转的最佳大小边界框的最短侧的最小容许大小，此边界框位于以参考比例绘制的符号化的建筑物要素周围。 会将边界框侧小于此值的建筑物进行扩大以达到此值。 可能会不按比例来调整建筑物大小，这将导致建筑物的形态发生改变。</para>
		/// </param>
		public ResolveBuildingConflicts(object InBuildings, object InvisibilityField, object InBarriers, object BuildingGap, object MinimumSize)
		{
			this.InBuildings = InBuildings;
			this.InvisibilityField = InvisibilityField;
			this.InBarriers = InBarriers;
			this.BuildingGap = BuildingGap;
			this.MinimumSize = MinimumSize;
		}

		/// <summary>
		/// <para>Tool Display Name : 解决建筑物冲突</para>
		/// </summary>
		public override string DisplayName() => "解决建筑物冲突";

		/// <summary>
		/// <para>Tool Name : ResolveBuildingConflicts</para>
		/// </summary>
		public override string ToolName() => "ResolveBuildingConflicts";

		/// <summary>
		/// <para>Tool Excute Name : cartography.ResolveBuildingConflicts</para>
		/// </summary>
		public override string ExcuteName() => "cartography.ResolveBuildingConflicts";

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
		public override object[] Parameters() => new object[] { InBuildings, InvisibilityField, InBarriers, BuildingGap, MinimumSize, HierarchyField, OutLayers };

		/// <summary>
		/// <para>Input Building Layers</para>
		/// <para>包含可能存在冲突或者小于容许大小的建筑物要素的输入图层。 建筑物可以是点或面。 将对建筑物进行修改以解决它们与其他建筑物和障碍要素的冲突。</para>
		/// <para>将点建筑物图层用作输入时，必须将标记符号图层的角度属性设置为要素类中的字段。 该字段将存储旋转调整。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPLayerDomain()]
		[GeometryType("Polygon", "Point")]
		public object InBuildings { get; set; }

		/// <summary>
		/// <para>Invisibility Field</para>
		/// <para>存储不可见性值的字段，不可见性值可用于从显示中移除某些建筑物以解决符号冲突。 值为 1 的建筑物将从显示中移除；值为零的建筑物不会被移除。 对图层使用定义查询可只显示可见建筑物。 未删除要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InvisibilityField { get; set; }

		/// <summary>
		/// <para>Input Barrier Layers</para>
		/// <para>作为与输入建筑物要素存在冲突的障碍的所有线状要素或面状要素所在的图层。 将对建筑物进行修改以解决建筑物与障碍之间的冲突。 定向值为布尔值，用于指定是否将建筑物定向到障碍图层。</para>
		/// <para>间距用于指定建筑物将朝向或远离障碍图层所移动的距离。 输入此值时必须带有单位。</para>
		/// <para>间距值 0（零）表示会将建筑物直接捕捉到障碍线或轮廓符号系统的边缘。</para>
		/// <para>null（未指定）间距值表示除解决冲突所需的移动外，建筑物将不会移向或远离障碍线或轮廓线。</para>
		/// <para>如果输入间距值时未带有单位（如输入 10 而不是 10 米），将使用输入要素的坐标系的线性单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object InBarriers { get; set; }

		/// <summary>
		/// <para>Building Gap</para>
		/// <para>某比例下符号化的建筑物之间的最小容许距离。 将移动或隐藏间距小于此距离的建筑物以保持此距离。 最小容许距离将相对于参考比例进行设置（如，1:50,000 比例下为 15 米）。 如果未设置参考比例，最小容许距离值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object BuildingGap { get; set; }

		/// <summary>
		/// <para>Minimum Allowable Building Size</para>
		/// <para>经旋转的最佳大小边界框的最短侧的最小容许大小，此边界框位于以参考比例绘制的符号化的建筑物要素周围。 会将边界框侧小于此值的建筑物进行扩大以达到此值。 可能会不按比例来调整建筑物大小，这将导致建筑物的形态发生改变。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object MinimumSize { get; set; }

		/// <summary>
		/// <para>Hierarchy Field</para>
		/// <para>该字段包含要素重要性的等级级别，其中 1 表示非常重要，重要性随整数值的增大而递减。 虽然可能会对建筑物进行一定程度的移动以解决冲突，但值 0（零）将使建筑物保持可见。 如果未使用此参数，此工具将根据要素的周长及其与障碍要素的距离对要素重要性进行评估。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object HierarchyField { get; set; }

		/// <summary>
		/// <para>Output Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutLayers { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ResolveBuildingConflicts SetEnviroment(object cartographicCoordinateSystem = null, object cartographicPartitions = null, object referenceScale = null)
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem, cartographicPartitions: cartographicPartitions, referenceScale: referenceScale);
			return this;
		}

	}
}
