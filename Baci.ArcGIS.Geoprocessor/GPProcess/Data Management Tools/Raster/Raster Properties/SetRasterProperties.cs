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
	/// <para>Set Raster Properties</para>
	/// <para>设置栅格属性</para>
	/// <para>为栅格数据集或镶嵌数据集设置数据类型、统计数据和 NoData 值。</para>
	/// </summary>
	public class SetRasterProperties : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>具有要设置属性的栅格或镶嵌数据集。</para>
		/// </param>
		public SetRasterProperties(object InRaster)
		{
			this.InRaster = InRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 设置栅格属性</para>
		/// </summary>
		public override string DisplayName() => "设置栅格属性";

		/// <summary>
		/// <para>Tool Name : SetRasterProperties</para>
		/// </summary>
		public override string ToolName() => "SetRasterProperties";

		/// <summary>
		/// <para>Tool Excute Name : management.SetRasterProperties</para>
		/// </summary>
		public override string ExcuteName() => "management.SetRasterProperties";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, DataType!, Statistics!, StatsFile!, Nodata!, KeyProperties!, OutRaster!, MultidimensionalInfo! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>具有要设置属性的栅格或镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Data Source Type</para>
		/// <para>指定镶嵌数据集内的影像类型。</para>
		/// <para>通用—镶嵌数据集没有指定的数据类型。</para>
		/// <para>高程—镶嵌数据集包含高程数据。</para>
		/// <para>专题—镶嵌数据集包含具有离散值的专题数据，例如土地覆被。</para>
		/// <para>已处理—已对镶嵌数据集进行了色彩校正。</para>
		/// <para>科学—数据具有科学信息，并且在默认情况下将通过从蓝到红的色带来显示。</para>
		/// <para>矢量 UV—此数据是包含矢量字段数据 U 和 V 分量的双波段栅格。</para>
		/// <para>量级和方向—此数据是包含矢量字段数据量级和方向的双波段栅格。</para>
		/// <para><see cref="DataTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DataType { get; set; }

		/// <summary>
		/// <para>Statistics Per Band</para>
		/// <para>最小值、最大值、平均值和标准差的波段和值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? Statistics { get; set; }

		/// <summary>
		/// <para>Import Statistics From File</para>
		/// <para>包含统计数据的 .xml 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object? StatsFile { get; set; }

		/// <summary>
		/// <para>Bands for NoData Value</para>
		/// <para>每个波段的 NoData 值。 每个波段都可定义唯一的 NoData 值，也可为所有波段指定相同的值。</para>
		/// <para>从 NoData 下拉箭头中选择波段，然后单击添加按钮将其添加到表中。 然后输入一个或多个值。 如果选择多个 NoData 值，则用空格分隔各值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? Nodata { get; set; }

		/// <summary>
		/// <para>Key Properties</para>
		/// <para>本身支持的属性。 您的数据可能具有未包含在以下列表中的附加属性。 属性不区分大小写。</para>
		/// <para>AcquisitionDate</para>
		/// <para>BandName</para>
		/// <para>BlockName</para>
		/// <para>CloudCover</para>
		/// <para>DatasetTag</para>
		/// <para>Dimensions</para>
		/// <para>FlowDirection</para>
		/// <para>Footprint</para>
		/// <para>HighCellSize</para>
		/// <para>LowCellSize</para>
		/// <para>MinCellSize</para>
		/// <para>MaxCellSize</para>
		/// <para>OffNadir</para>
		/// <para>ParentRasterType</para>
		/// <para>ParentTemplate</para>
		/// <para>PerspectiveX</para>
		/// <para>PerspectiveY</para>
		/// <para>PerspectiveZ</para>
		/// <para>ProductName</para>
		/// <para>RadianceBias</para>
		/// <para>RadianceGain</para>
		/// <para>ReflectanceBias</para>
		/// <para>RefelctanceGain</para>
		/// <para>Segmented</para>
		/// <para>SensorAzimuth</para>
		/// <para>SensorElevation</para>
		/// <para>SensorName</para>
		/// <para>SolarIrradiance</para>
		/// <para>SourceBandIndex</para>
		/// <para>StdPressure</para>
		/// <para>StdPressure_Max</para>
		/// <para>StdTemperature</para>
		/// <para>StdTemperature_Max</para>
		/// <para>StdTime</para>
		/// <para>StdTime_Max</para>
		/// <para>StdZ</para>
		/// <para>StdZ_max</para>
		/// <para>SunAzimuth</para>
		/// <para>SunElevation</para>
		/// <para>ThermalConstant_K1</para>
		/// <para>ThermalConstant_K2</para>
		/// <para>Variable</para>
		/// <para>VerticalAccuracy</para>
		/// <para>WavelengthMin</para>
		/// <para>WavelengthMax</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? KeyProperties { get; set; }

		/// <summary>
		/// <para>Updated Raster Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object? OutRaster { get; set; }

		/// <summary>
		/// <para>Multidimensional information</para>
		/// <para>栅格数据集的维度信息。 设置维度信息会将无维度栅格转换为多维栅格。</para>
		/// <para>如果维度为时间，则维度名称必须为 StdTime。 时间的格式为年-月-日 (2021-10-01) 或年-月-日 T 时-分-秒 (2021-10-01T01:00:00)。</para>
		/// <para>定义一个既有时间又有高程的变量，先添加时间变量；然后添加与 z 维度相同的变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? MultidimensionalInfo { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetRasterProperties SetEnviroment(object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Data Source Type</para>
		/// </summary>
		public enum DataTypeEnum 
		{
			/// <summary>
			/// <para>通用—镶嵌数据集没有指定的数据类型。</para>
			/// </summary>
			[GPValue("GENERIC")]
			[Description("通用")]
			Generic,

			/// <summary>
			/// <para>高程—镶嵌数据集包含高程数据。</para>
			/// </summary>
			[GPValue("ELEVATION")]
			[Description("高程")]
			Elevation,

			/// <summary>
			/// <para>专题—镶嵌数据集包含具有离散值的专题数据，例如土地覆被。</para>
			/// </summary>
			[GPValue("THEMATIC")]
			[Description("专题")]
			Thematic,

			/// <summary>
			/// <para>已处理—已对镶嵌数据集进行了色彩校正。</para>
			/// </summary>
			[GPValue("PROCESSED")]
			[Description("已处理")]
			Processed,

			/// <summary>
			/// <para>科学—数据具有科学信息，并且在默认情况下将通过从蓝到红的色带来显示。</para>
			/// </summary>
			[GPValue("SCIENTIFIC")]
			[Description("科学")]
			Scientific,

			/// <summary>
			/// <para>矢量 UV—此数据是包含矢量字段数据 U 和 V 分量的双波段栅格。</para>
			/// </summary>
			[GPValue("VECTOR_UV")]
			[Description("矢量 UV")]
			Vector_UV,

			/// <summary>
			/// <para>量级和方向—此数据是包含矢量字段数据量级和方向的双波段栅格。</para>
			/// </summary>
			[GPValue("VECTOR_MAGDIR")]
			[Description("量级和方向")]
			Magnitude_and_Direction,

		}

#endregion
	}
}
