using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Update Multifile Feature Connection Dataset Properties</para>
	/// <para>更新多文件要素连接数据集属性</para>
	/// <para>更新多文件要素连接 (MFC) 数据集的属性。 此工具可以修改指定 MFC 数据集的字段、几何、时间和文件设置。</para>
	/// </summary>
	public class UpdateBDCDatasetProperties : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="BdcDataset">
		/// <para>Multifile Feature Connection Dataset</para>
		/// <para>将更新的 MFC 数据集。 根据源数据（shapefile、分隔文件、ORC 或 parquet 文件），编辑选项将有所不同。</para>
		/// </param>
		public UpdateBDCDatasetProperties(object BdcDataset)
		{
			this.BdcDataset = BdcDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 更新多文件要素连接数据集属性</para>
		/// </summary>
		public override string DisplayName() => "更新多文件要素连接数据集属性";

		/// <summary>
		/// <para>Tool Name : UpdateBDCDatasetProperties</para>
		/// </summary>
		public override string ToolName() => "UpdateBDCDatasetProperties";

		/// <summary>
		/// <para>Tool Excute Name : gapro.UpdateBDCDatasetProperties</para>
		/// </summary>
		public override string ExcuteName() => "gapro.UpdateBDCDatasetProperties";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise() => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { BdcDataset, Expression!, FieldProperties!, GeometryType!, SpatialReference!, GeometryFormatType!, GeometryField!, XField!, YField!, ZField!, TimeType!, TimeZone!, StartTimeFormat!, EndTimeFormat!, FileExtension!, FieldDelimiter!, RecordTerminator!, QuoteCharacter!, HasHeaderRow!, Encoding!, UpdatedBdc! };

		/// <summary>
		/// <para>Multifile Feature Connection Dataset</para>
		/// <para>将更新的 MFC 数据集。 根据源数据（shapefile、分隔文件、ORC 或 parquet 文件），编辑选项将有所不同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object BdcDataset { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>该表达式用于限制将在分析中使用的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		[Category("Definition Query")]
		public object? Expression { get; set; }

		/// <summary>
		/// <para>Field Properties</para>
		/// <para>指定将要修改的字段名称和属性。</para>
		/// <para>短整型—此字段类型将为短型。</para>
		/// <para>长整型—此字段类型将为长整型</para>
		/// <para>双精度—此字段类型将为双精度。</para>
		/// <para>浮点型—此字段类型将为浮点型。</para>
		/// <para>字符串—此字段类型将为字符串。</para>
		/// <para>日期—此字段类型将为日期类型。</para>
		/// <para>BLOB—此字段类型将为 BLOB。</para>
		/// <para>指定字段是可见还是隐藏。</para>
		/// <para>选中 - 这些字段将被设置为可见，并且可在地理处理工具中使用。 这是默认设置。</para>
		/// <para>未选中 - 这些字段将被隐藏，并且无法用作地理处理工具的输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Fields")]
		public object? FieldProperties { get; set; }

		/// <summary>
		/// <para>Geometry Type</para>
		/// <para>指定将用于在空间上表示数据集的几何类型。 无法为源自 shapefile 的数据集修改几何。</para>
		/// <para>点—该几何类型将为点。</para>
		/// <para>折线—该几何类型将为折线。</para>
		/// <para>面—该几何类型将为面。</para>
		/// <para>无—未指定任何几何类型。</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Geometry")]
		public object? GeometryType { get; set; }

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>WKID 值或 WKT 字符串将用于数据集的空间参考。 默认值为 WKID 4326 (WGS84)。 无法为源自 shapefile 的数据修改空间参考。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Geometry")]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Geometry Format Type</para>
		/// <para>指定几何的格式化方式。 无法为源自 shapefile 的数据修改几何。</para>
		/// <para>XYZ—两个或多个字段将代表x，y 和 z（可选）。</para>
		/// <para>WKT—几何将由熟知的文本字段中的单个字段表示。</para>
		/// <para>WKB—几何将由熟知的二进制字段中的单个字段表示。</para>
		/// <para>GeoJSON—几何将由 GeoJSON 格式的单个字段表示。</para>
		/// <para>EsriJSON—几何将由 EsriJSON 格式的单个字段表示。</para>
		/// <para>EsriShape—几何将由 EsriShape 格式的单个字段表示。</para>
		/// <para><see cref="GeometryFormatTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Geometry")]
		public object? GeometryFormatType { get; set; }

		/// <summary>
		/// <para>Geometry Field</para>
		/// <para>用于表示几何的单个字段。 当几何格式为 WKT、WKB、GeoJSON、EsriJSON 或 EsriShape 时，将使用此字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Geometry")]
		public object? GeometryField { get; set; }

		/// <summary>
		/// <para>X Field</para>
		/// <para>用于表示 x 位置的字段。 如果有多个表示 x 位置的字段，则需要手动修改 .mfc 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Geometry")]
		public object? XField { get; set; }

		/// <summary>
		/// <para>Y Field</para>
		/// <para>用于表示 y 位置的字段。 如果有多个表示 y 位置的字段，则需要手动修改 .mfc 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Geometry")]
		public object? YField { get; set; }

		/// <summary>
		/// <para>Z Field</para>
		/// <para>用于表示 z 位置的字段。 如果有多个表示 z 位置的字段，则需要手动修改 .mfc 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Geometry")]
		public object? ZField { get; set; }

		/// <summary>
		/// <para>Time Type</para>
		/// <para>指定将用于临时表示数据集的时间类型。</para>
		/// <para>间隔—时间类型将表示具有开始时间和结束时间的持续时间。</para>
		/// <para>即时—时间类型将表示时刻。</para>
		/// <para>无—未启用时间。</para>
		/// <para><see cref="TimeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Time")]
		public object? TimeType { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>数据集的时区。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Time")]
		public object? TimeZone { get; set; }

		/// <summary>
		/// <para>Start Time</para>
		/// <para>用于定义开始时间和时间格式的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Time")]
		public object? StartTimeFormat { get; set; }

		/// <summary>
		/// <para>End Time</para>
		/// <para>用于定义结束时间和时间格式的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Time")]
		public object? EndTimeFormat { get; set; }

		/// <summary>
		/// <para>File Extension</para>
		/// <para>源数据集的文件扩展名。 无法修改参数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("File")]
		public object? FileExtension { get; set; }

		/// <summary>
		/// <para>Field Delimiter</para>
		/// <para>源数据集中使用的字段分隔符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("File")]
		public object? FieldDelimiter { get; set; }

		/// <summary>
		/// <para>Record Terminator</para>
		/// <para>源数据集中使用的记录终止符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("File")]
		public object? RecordTerminator { get; set; }

		/// <summary>
		/// <para>Quote Character</para>
		/// <para>源数据集中使用的引号字符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("File")]
		public object? QuoteCharacter { get; set; }

		/// <summary>
		/// <para>Has Header Row</para>
		/// <para>指定源数据集中是否包含标题行。</para>
		/// <para>选中 - 源数据集中包含标题行。</para>
		/// <para>未选中 - 源数据集中不包含标题行。</para>
		/// <para><see cref="HasHeaderRowEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("File")]
		public object? HasHeaderRow { get; set; }

		/// <summary>
		/// <para>Encoding</para>
		/// <para>用于源数据集的编码类型。 默认将使用 UTF-8。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("File")]
		public object? Encoding { get; set; }

		/// <summary>
		/// <para>Updated MFC</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? UpdatedBdc { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Geometry Type</para>
		/// </summary>
		public enum GeometryTypeEnum 
		{
			/// <summary>
			/// <para>点—该几何类型将为点。</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("点")]
			Point,

			/// <summary>
			/// <para>折线—该几何类型将为折线。</para>
			/// </summary>
			[GPValue("LINE")]
			[Description("折线")]
			Polyline,

			/// <summary>
			/// <para>面—该几何类型将为面。</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("面")]
			Polygon,

			/// <summary>
			/// <para>无—未指定任何几何类型。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

		}

		/// <summary>
		/// <para>Geometry Format Type</para>
		/// </summary>
		public enum GeometryFormatTypeEnum 
		{
			/// <summary>
			/// <para>XYZ—两个或多个字段将代表x，y 和 z（可选）。</para>
			/// </summary>
			[GPValue("XYZ")]
			[Description("XYZ")]
			XYZ,

			/// <summary>
			/// <para>WKT—几何将由熟知的文本字段中的单个字段表示。</para>
			/// </summary>
			[GPValue("WKT")]
			[Description("WKT")]
			WKT,

			/// <summary>
			/// <para>WKB—几何将由熟知的二进制字段中的单个字段表示。</para>
			/// </summary>
			[GPValue("WKB")]
			[Description("WKB")]
			WKB,

			/// <summary>
			/// <para>GeoJSON—几何将由 GeoJSON 格式的单个字段表示。</para>
			/// </summary>
			[GPValue("GEOJSON")]
			[Description("GeoJSON")]
			GeoJSON,

			/// <summary>
			/// <para>EsriJSON—几何将由 EsriJSON 格式的单个字段表示。</para>
			/// </summary>
			[GPValue("ESRIJSON")]
			[Description("EsriJSON")]
			EsriJSON,

			/// <summary>
			/// <para>EsriShape—几何将由 EsriShape 格式的单个字段表示。</para>
			/// </summary>
			[GPValue("ESRISHAPE")]
			[Description("EsriShape")]
			EsriShape,

		}

		/// <summary>
		/// <para>Time Type</para>
		/// </summary>
		public enum TimeTypeEnum 
		{
			/// <summary>
			/// <para>即时—时间类型将表示时刻。</para>
			/// </summary>
			[GPValue("INSTANT")]
			[Description("即时")]
			Instant,

			/// <summary>
			/// <para>间隔—时间类型将表示具有开始时间和结束时间的持续时间。</para>
			/// </summary>
			[GPValue("INTERVAL")]
			[Description("间隔")]
			Interval,

			/// <summary>
			/// <para>无—未启用时间。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

		}

		/// <summary>
		/// <para>Has Header Row</para>
		/// </summary>
		public enum HasHeaderRowEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("HAS_HEADER")]
			HAS_HEADER,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_HEADER")]
			NO_HEADER,

		}

#endregion
	}
}
