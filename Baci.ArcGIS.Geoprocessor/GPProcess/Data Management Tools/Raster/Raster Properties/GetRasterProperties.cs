using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Get Raster Properties</para>
	/// <para>获取栅格属性</para>
	/// <para>从元数据和栅格数据集的相关描述性统计数据中检索信息。</para>
	/// </summary>
	public class GetRasterProperties : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>包含要检索的属性的栅格。</para>
		/// </param>
		public GetRasterProperties(object InRaster)
		{
			this.InRaster = InRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 获取栅格属性</para>
		/// </summary>
		public override string DisplayName() => "获取栅格属性";

		/// <summary>
		/// <para>Tool Name : GetRasterProperties</para>
		/// </summary>
		public override string ToolName() => "GetRasterProperties";

		/// <summary>
		/// <para>Tool Excute Name : management.GetRasterProperties</para>
		/// </summary>
		public override string ExcuteName() => "management.GetRasterProperties";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, PropertyType, BandIndex, Property };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>包含要检索的属性的栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Property type</para>
		/// <para>要从输入栅格获取的属性。</para>
		/// <para>最小像元值—输入栅格中所有像元的最小值。</para>
		/// <para>最大像元值—输入栅格中所有像元的最大值。</para>
		/// <para>所有像元的平均值—输入栅格中所有像元的平均值。</para>
		/// <para>所有像元的标准差—输入栅格中所有像元的标准差。</para>
		/// <para>唯一值计数—输入栅格中的唯一值的数目。</para>
		/// <para>最大 Y 坐标（顶部）—范围的顶部值（最大 y 坐标）。</para>
		/// <para>最小 X 坐标（左侧）—范围的左侧值（最小 x 坐标）。</para>
		/// <para>最大 X 坐标（右侧）—范围的右侧值（最大 x 坐标）。</para>
		/// <para>最小 Y 坐标（底部）—范围的底部值（最小 y 坐标）。</para>
		/// <para>x 方向上的像元大小—x 方向上的像元大小。</para>
		/// <para>y 方向上的像元大小—y 方向上的像元大小。</para>
		/// <para>像元值类型—输入栅格中像元值的类型。</para>
		/// <para>列数—输入栅格中的列数。</para>
		/// <para>行数—输入栅格中的行数。</para>
		/// <para>波段数—输入栅格中的波段数。</para>
		/// <para>包含 NoData 像元—返回栅格中是否存在 NoData。</para>
		/// <para>所有像元都包含 NoData—返回是否所有像素均为 NoData。这也称为 ISNULL。</para>
		/// <para>传感器名称—传感器名称。</para>
		/// <para>产品名称—与传感器相关的产品名。</para>
		/// <para>采集日期—捕获数据的日期。</para>
		/// <para>源类型—源类型。</para>
		/// <para>云量—百分比形式的云覆盖量。</para>
		/// <para>太阳方位角—太阳方位角，以度为单位。</para>
		/// <para>太阳高程—太阳高度角，以度为单位。</para>
		/// <para>传感器方位角—传感器方位角，以度为单位。</para>
		/// <para>传感器高程—传感器高度角，以度为单位。</para>
		/// <para>像底点偏离量—偏离像底点的角度，以度为单位。</para>
		/// <para>波长—波段的波长范围，以纳米为单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PropertyType { get; set; } = "MINIMUM";

		/// <summary>
		/// <para>Band Name</para>
		/// <para>从下拉框中选择波段名称。如果未选择任何波段，则将使用第一个波段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BandIndex { get; set; }

		/// <summary>
		/// <para>Property</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPVariant()]
		public object Property { get; set; }

	}
}
