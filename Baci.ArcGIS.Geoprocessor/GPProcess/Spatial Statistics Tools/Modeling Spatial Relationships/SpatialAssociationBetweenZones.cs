using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools
{
	/// <summary>
	/// <para>Spatial Association Between Zones</para>
	/// <para>区域之间的空间关联</para>
	/// <para>测量同一研究区的两个区域化之间的空间关联程度，其中每个区域化由一组称为区域的类别组成。 区域化之间的关联取决于每个区域化的区域之间的区域重叠。 当一个区域化的每个区域与另一个区域化的区域紧密对应时，关联程度最高。 同样，如果一个区域化的区域与另一个区域化的许多不同区域存在较大程度的重叠，则空间关联性最低。 该工具的主要输出是分类变量之间的空间关联的全局度量：范围介于 0（无对应）到 1（区域在空间上完全对齐）的单个数字。 （可选）可以为任一区域化的特定区域或区域化之间的特定区域组合计算和可视化此全局关联。</para>
	/// </summary>
	public class SpatialAssociationBetweenZones : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureOrRaster">
		/// <para>Input Polygon Feature or Raster Zones</para>
		/// <para>表示第一个区域化的区域的数据集。 可以使用面要素或栅格来定义区域。</para>
		/// </param>
		/// <param name="CategoricalZoneField">
		/// <para>Categorical Zone Field</para>
		/// <para>表示输入区域的区域类别的字段。 该字段的每个唯一值定义一个单独区域。 对于要素，该字段必须为整型或文本字段。 对于栅格，VALUE 字段同样受支持。</para>
		/// </param>
		/// <param name="OverlayFeatureOrRaster">
		/// <para>Overlay Polygon Feature or Raster Zones</para>
		/// <para>表示第二个区域化的区域的数据集。 区域可以是面要素或栅格。</para>
		/// </param>
		/// <param name="CategoricalOverlayZoneField">
		/// <para>Categorical Overlay Zone Field</para>
		/// <para>表示叠加区域的区域类别的字段。 该字段的每个唯一值定义一个单独区域。 对于要素，该字段必须为整型或文本字段。 对于栅格，VALUE 字段同样受支持。</para>
		/// </param>
		public SpatialAssociationBetweenZones(object InputFeatureOrRaster, object CategoricalZoneField, object OverlayFeatureOrRaster, object CategoricalOverlayZoneField)
		{
			this.InputFeatureOrRaster = InputFeatureOrRaster;
			this.CategoricalZoneField = CategoricalZoneField;
			this.OverlayFeatureOrRaster = OverlayFeatureOrRaster;
			this.CategoricalOverlayZoneField = CategoricalOverlayZoneField;
		}

		/// <summary>
		/// <para>Tool Display Name : 区域之间的空间关联</para>
		/// </summary>
		public override string DisplayName() => "区域之间的空间关联";

		/// <summary>
		/// <para>Tool Name : SpatialAssociationBetweenZones</para>
		/// </summary>
		public override string ToolName() => "SpatialAssociationBetweenZones";

		/// <summary>
		/// <para>Tool Excute Name : stats.SpatialAssociationBetweenZones</para>
		/// </summary>
		public override string ExcuteName() => "stats.SpatialAssociationBetweenZones";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise() => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "cellSizeProjectionMethod", "extent", "mask", "outputCoordinateSystem", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatureOrRaster, CategoricalZoneField, OverlayFeatureOrRaster, CategoricalOverlayZoneField, OutputFeatures!, OutputRaster!, CorrespondenceOverlayToInput!, CorrespondenceInputToOverlay!, GlobalMeasureOfSpatialAssociation!, GlobalCorrespondenceInputToOverlay!, GlobalCorrespondenceOverlayToInput! };

		/// <summary>
		/// <para>Input Polygon Feature or Raster Zones</para>
		/// <para>表示第一个区域化的区域的数据集。 可以使用面要素或栅格来定义区域。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InputFeatureOrRaster { get; set; }

		/// <summary>
		/// <para>Categorical Zone Field</para>
		/// <para>表示输入区域的区域类别的字段。 该字段的每个唯一值定义一个单独区域。 对于要素，该字段必须为整型或文本字段。 对于栅格，VALUE 字段同样受支持。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object CategoricalZoneField { get; set; }

		/// <summary>
		/// <para>Overlay Polygon Feature or Raster Zones</para>
		/// <para>表示第二个区域化的区域的数据集。 区域可以是面要素或栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object OverlayFeatureOrRaster { get; set; }

		/// <summary>
		/// <para>Categorical Overlay Zone Field</para>
		/// <para>表示叠加区域的区域类别的字段。 该字段的每个唯一值定义一个单独区域。 对于要素，该字段必须为整型或文本字段。 对于栅格，VALUE 字段同样受支持。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object CategoricalOverlayZoneField { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>包含输入区域和叠加区域的所有交集的空间关联度量的输出面要素。</para>
		/// <para>可使用输出要素衡量输入区域和叠加区域的特定组合之间的关联，例如玉米生产区域（农作物类型）与排水良好的土壤区域（土壤排水分类）之间的关联。 仅当输入区域和叠加区域均为面要素时，此参数才会启用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutputFeatures { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>包含输入区域和叠加区域之间的空间关联度量的输出栅格。</para>
		/// <para>输出栅格将具有三个字段，用于指示输入区域和叠加区域的交集的空间关联度量、输入区域内叠加区域的对应程度以及叠加区域内输入区域的对应程度。 仅当输入区域和叠加区域中至少有一个是栅格时，此参数才会启用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object? OutputRaster { get; set; }

		/// <summary>
		/// <para>Correspondence of Overlay Zones within Input Zones</para>
		/// <para>包含输入区域内叠加区域的对应度量的输出面要素。</para>
		/// <para>此输出将具有与输入区域相同的几何，并且可用于识别哪些输入区域整体上与叠加区域紧密对应。 然后可以使用输出要素来研究特定区域组合。 仅当输入区域和叠加区域均为面要素时，此参数才会启用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? CorrespondenceOverlayToInput { get; set; }

		/// <summary>
		/// <para>Correspondence of Input Zones within Overlay Zones</para>
		/// <para>包含叠加区域内输入区域的对应度量的输出面要素。</para>
		/// <para>此输出将具有与叠加区域相同的几何，并且可用于识别哪些叠加区域整体上与输入区域紧密对应。 然后可以使用输出要素来研究特定区域组合。 仅当输入区域和叠加区域均为面要素时，此参数才会启用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? CorrespondenceInputToOverlay { get; set; }

		/// <summary>
		/// <para>Global Measure of Spatial Association</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object? GlobalMeasureOfSpatialAssociation { get; set; }

		/// <summary>
		/// <para>Global Correspondence of Input Zones within Overlay Zones</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object? GlobalCorrespondenceInputToOverlay { get; set; }

		/// <summary>
		/// <para>Global Correspondence of Overlay Zones within Input Zones</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object? GlobalCorrespondenceOverlayToInput { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SpatialAssociationBetweenZones SetEnviroment(object? cellSize = null , object? cellSizeProjectionMethod = null , object? extent = null , object? mask = null , object? outputCoordinateSystem = null , object? snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster);
			return this;
		}

	}
}
