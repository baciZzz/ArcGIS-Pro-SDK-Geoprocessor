using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CrimeAnalysisandSafetyTools
{
	/// <summary>
	/// <para>Update Features With Incident Records</para>
	/// <para>使用事件记录更新要素</para>
	/// <para>根据 x,y 坐标或街道地址将非空间表转换为点要素，并使用表中的新记录或更新记录信息更新现有数据集。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class UpdateFeaturesWithIncidentRecords : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>该表包含定义记录位置的 x 和 y 坐标或地址。</para>
		/// </param>
		/// <param name="TargetFeatures">
		/// <para>Target Features</para>
		/// <para>要更新的点要素类或要素图层。</para>
		/// </param>
		/// <param name="LocationType">
		/// <para>Location Type</para>
		/// <para>指定是使用 x,y 坐标还是地址创建要素。</para>
		/// <para>坐标—将使用输入记录的 x,y 坐标创建要素。</para>
		/// <para>地址—将通过定位器使用输入记录的地址创建要素。</para>
		/// <para><see cref="LocationTypeEnum"/></para>
		/// </param>
		public UpdateFeaturesWithIncidentRecords(object InTable, object TargetFeatures, object LocationType)
		{
			this.InTable = InTable;
			this.TargetFeatures = TargetFeatures;
			this.LocationType = LocationType;
		}

		/// <summary>
		/// <para>Tool Display Name : 使用事件记录更新要素</para>
		/// </summary>
		public override string DisplayName() => "使用事件记录更新要素";

		/// <summary>
		/// <para>Tool Name : UpdateFeaturesWithIncidentRecords</para>
		/// </summary>
		public override string ToolName() => "UpdateFeaturesWithIncidentRecords";

		/// <summary>
		/// <para>Tool Excute Name : ca.UpdateFeaturesWithIncidentRecords</para>
		/// </summary>
		public override string ExcuteName() => "ca.UpdateFeaturesWithIncidentRecords";

		/// <summary>
		/// <para>Toolbox Display Name : Crime Analysis and Safety Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Crime Analysis and Safety Tools";

		/// <summary>
		/// <para>Toolbox Alise : ca</para>
		/// </summary>
		public override string ToolboxAlise() => "ca";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, TargetFeatures, LocationType, XField, YField, CoordinateSystem, AddressLocator, AddressType, AddressFields, InvalidRecordsTable, WhereClause, UpdateTarget, MatchFields, InDateField, TargetDateField, UpdateMatching, UpdateGeometry, FieldMatchingType, FieldMapping, TimeFormat, UpdatedTargetFeatures };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>该表包含定义记录位置的 x 和 y 坐标或地址。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Target Features</para>
		/// <para>要更新的点要素类或要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object TargetFeatures { get; set; }

		/// <summary>
		/// <para>Location Type</para>
		/// <para>指定是使用 x,y 坐标还是地址创建要素。</para>
		/// <para>坐标—将使用输入记录的 x,y 坐标创建要素。</para>
		/// <para>地址—将通过定位器使用输入记录的地址创建要素。</para>
		/// <para><see cref="LocationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LocationType { get; set; } = "COORDINATES";

		/// <summary>
		/// <para>X Field</para>
		/// <para>输入表中包含 X 坐标（或经度）的字段。</para>
		/// <para>仅当位置类型参数设置为坐标时，此参数才会启用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object XField { get; set; }

		/// <summary>
		/// <para>Y Field</para>
		/// <para>输入表中包含 Y 坐标（或纬度）的字段。</para>
		/// <para>仅当位置类型参数设置为坐标时，此参数才会启用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object YField { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>x 和 y 坐标的坐标系。</para>
		/// <para>仅当位置类型参数设置为坐标时，此参数才会启用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object CoordinateSystem { get; set; } = "GEOGCS[\"GCS_WGS_1984\",DATUM[\"D_WGS_1984\",SPHEROID[\"WGS_1984\",6378137.0,298.257223563]],PRIMEM[\"Greenwich\",0.0],UNIT[\"Degree\",0.0174532925199433]]";

		/// <summary>
		/// <para>Address Locator</para>
		/// <para>要用于对地址表进行地理编码的地址定位器。</para>
		/// <para>当此参数设置为使用 ArcGIS World Geocoding Service 时，此操作可能会消耗配额。</para>
		/// <para>使用本地地址定位器时，可选择在定位器路径末尾的定位器名称后添加 .loc 扩展名。</para>
		/// <para>仅当位置类型参数设置为地址时，此参数才会启用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEAddressLocator()]
		public object AddressLocator { get; set; }

		/// <summary>
		/// <para>Address Type</para>
		/// <para>指定如何将地址定位器使用的地址字段映射到地址输入表中的字段。</para>
		/// <para>多个字段—地址将拆分为多个字段。</para>
		/// <para>单字段—地址将包含在一个字段中。</para>
		/// <para>如果完整地址储存在输入表的一个字段中，例如 303 Peachtree St NE, Atlanta, GA 30308，请选择单个字段。如果将常规美国地址的输入地址拆分成 Address、City、State 和 ZIP 等多个字段，请选择多个字段。</para>
		/// <para>仅当位置类型参数设置为地址时，此参数才会启用。</para>
		/// <para><see cref="AddressTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AddressType { get; set; } = "MULTI_FIELD_ADDRESS";

		/// <summary>
		/// <para>Address Fields</para>
		/// <para>与地址定位器的定位器地址字段对应的输入表字段。</para>
		/// <para>某些定位器支持多个输入地址字段，例如 Address、Address2 和 Address3。 在此情况下，可以将地址组件分为多个字段，然后在进行地理编码时将地址字段连接在一起。 例如，跨三个字段的 100、Main st 和 Apt 140，或者跨两个字段的 100 Main st 和 Apt 140，在进行地理编码时，都将成为 100 Main st Apt 140。</para>
		/// <para>如果不想将地址定位器所使用的可选输入地址字段映射到输入地址表中的字段，则将字段名称留空以指定不存在任何映射。</para>
		/// <para>仅当将位置选项参数设置为地址时，此参数才处于活动状态。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object AddressFields { get; set; }

		/// <summary>
		/// <para>Invalid Records Table</para>
		/// <para>包含无效记录和关联无效代码列表的输出表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object InvalidRecordsTable { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>用于选择输入数据集记录子集的 SQL 表达式。如果指定了多个输入数据集，将使用表达式对它们进行评估。如果没有与输入数据集表达式匹配的记录，将不会向目标追加该数据集的记录。</para>
		/// <para>有关 SQL 语法的详细信息，请参阅在 ArcGIS 中使用的查询表达式的 SQL 参考。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Update Existing Target Features</para>
		/// <para>指定是否将在目标要素参数中更新现有记录。</para>
		/// <para>选中 - 将在目标要素参数（如果存在）中更新输入表参数中的记录。</para>
		/// <para>未选中 - 输入表参数中的记录将追加到目标要素参数中。这是默认设置。</para>
		/// <para><see cref="UpdateTargetEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UpdateTarget { get; set; } = "false";

		/// <summary>
		/// <para>Match Fields</para>
		/// <para>用于确定输入表值和目标要素值之间的匹配项的一个或多个 ID 字段。</para>
		/// <para>仅当选中更新现有目标要素参数时，此参数才会启用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Define Record Update Matching")]
		public object MatchFields { get; set; }

		/// <summary>
		/// <para>Input Table Last Modified Date Field</para>
		/// <para>输入要素记录的上次修改日期。</para>
		/// <para>支持日期和字符串字段类型。</para>
		/// <para>仅当选中更新现有目标要素参数时，此参数才会启用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date", "Text", "Short", "Long", "Float", "Double")]
		[Category("Define Record Update Matching")]
		public object InDateField { get; set; }

		/// <summary>
		/// <para>Target Features Last Modified Date Field</para>
		/// <para>包含目标要素记录的上次修改日期的字段。</para>
		/// <para>该字段必须为日期字段类型。</para>
		/// <para>仅当选中更新现有目标要素参数时，此参数才会启用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Define Record Update Matching")]
		public object TargetDateField { get; set; }

		/// <summary>
		/// <para>Update Only Matching Features</para>
		/// <para>指定是仅更新现有记录还是更新现有记录并添加新记录。</para>
		/// <para>选中 - 仅更新现有记录。</para>
		/// <para>未选中 - 将更新现有记录并添加新记录。这是默认设置。</para>
		/// <para>仅当选中更新现有目标要素参数时，此参数才会处于活动状态。</para>
		/// <para><see cref="UpdateMatchingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Define Record Update Matching")]
		public object UpdateMatching { get; set; } = "false";

		/// <summary>
		/// <para>Update Geometry for Existing Features</para>
		/// <para>指定是否更新现有要素的几何。</para>
		/// <para>选中 - 如果输入表参数中的几何信息与目标要素参数的几何不同，将更新现有记录的几何。这是默认设置。</para>
		/// <para>未选中 - 不会更新现有记录的几何。</para>
		/// <para>仅当选中更新现有目标要素参数时，此参数才会启用。</para>
		/// <para><see cref="UpdateGeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Define Record Update Matching")]
		public object UpdateGeometry { get; set; } = "true";

		/// <summary>
		/// <para>Field Matching Type</para>
		/// <para>指定输入表的字段是否必须与目标要素的字段匹配才能追加数据。</para>
		/// <para>输入字段必须与目标字段匹配—输入数据集的字段与目标数据集的字段相匹配。将忽略不匹配的字段。这是默认设置</para>
		/// <para>使用字段映射协调字段差异—输入数据集的字段不需要与目标数据集的字段相匹配。不会将与目标数据集字段不匹配的输入数据集字段映射到目标数据集，除非在字段映射参数中显式设置了映射。</para>
		/// <para><see cref="FieldMatchingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Fields")]
		public object FieldMatchingType { get; set; } = "AUTOMATIC";

		/// <summary>
		/// <para>Field Map</para>
		/// <para>控制如何将输入表中的属性字段传输或映射到目标要素。</para>
		/// <para>仅当将字段匹配类型参数设置为使用字段映射协调字段差异时，此参数才处于活动状态。</para>
		/// <para>由于输入表值追加到的现有目标要素具有预定义字段，因此无法在字段映射中添加、移除或更改字段类型。但是，可以为每个输出字段设置合并规则。</para>
		/// <para>合并规则用于指定如何将两个或更多个输入字段的值合并或组合为一个输出值。有多种合并规则可用于确定如何用值填充输出字段。</para>
		/// <para>First - 使用输入字段的第一个值。</para>
		/// <para>Last - 使用输入字段的最后一个值。</para>
		/// <para>Join - 串连（连接）输入字段的值。</para>
		/// <para>Sum - 计算输入字段值的总和。</para>
		/// <para>Mean - 计算输入字段值的平均值。</para>
		/// <para>Median - 计算输入字段值的中值。</para>
		/// <para>Mode - 使用具有最高频率的值。</para>
		/// <para>Min - 使用所有输入字段值中的最小值。</para>
		/// <para>Max - 使用所有输入字段值中的最大值。</para>
		/// <para>Standard deviation - 对所有输入字段值使用标准差分类方法。</para>
		/// <para>Count - 查找计算中所包含的记录数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldMapping()]
		[Category("Fields")]
		public object FieldMapping { get; set; }

		/// <summary>
		/// <para>Time Format</para>
		/// <para>包含时间值的输入字段的格式。类型可以是短型、长型、浮点型、双精度、文本或日期。可从下拉列表中选择标准时间格式，也可以输入自定义格式。格式字符串区分大小写。</para>
		/// <para>如果时间字段的数据类型为日期，则不需要时间格式。</para>
		/// <para>如果时间字段的数据类型是数值（短整型、长整型、浮点型或双精度），将在下拉列表中提供标准数值时间格式。</para>
		/// <para>如果时间字段的数据类型是字符串，将在下拉列表中提供标准字符串时间格式。对于字符串字段来说，您也可以选择为其指定自定义时间格式。例如，可采用标准格式将时间值存储在字符串字段中，如 yyyy/MM/dd HH:mm:ss 或以自定义格式存储，如 dd/MM/yyyy HH:mm:ss。如果使用自定义格式，您还可以指定 a.m.、p.m. 指示符。以下列出了部分常用格式：</para>
		/// <para>yyyy - 年，以四位数表示。</para>
		/// <para>MM - 数字形式的月，且个位数有前导零。</para>
		/// <para>MMM - 月，以三个字母的缩略形式表示。</para>
		/// <para>dd - 数字形式的每月日期，且个位数有前导零。</para>
		/// <para>ddd - 星期，以三个字母的缩略形式表示。</para>
		/// <para>hh - 小时，且个位数小时具有前导零；12 小时制。</para>
		/// <para>HH - 小时，且个位数小时具有前导零；24 小时制。</para>
		/// <para>mm - 分钟，且个位数分钟有前导零。</para>
		/// <para>ss - 秒，且个位数秒有前导零。</para>
		/// <para>t - 单字符时间标记字符串，例如，A 或 P。</para>
		/// <para>tt - 多字符时间标记字符串，例如，AM 或 PM。</para>
		/// <para>unix_us - Unix 时间，以微秒为单位。</para>
		/// <para>unix_ms - Unix 时间，以毫秒为单位。</para>
		/// <para>unix_s - Unix 时间，以秒为单位。</para>
		/// <para>unix_hex - 以十六进制表示的 Unix 时间。</para>
		/// <para>仅当输入表上次修改日期参数值为文本字段且目标要素上次修改日期字段参数值为日期字段，或者字段映射参数输入值为文本字段且输出值为日期字段时，此参数才处于活动状态。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Define Record Update Matching")]
		public object TimeFormat { get; set; }

		/// <summary>
		/// <para>Updated Target Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object UpdatedTargetFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UpdateFeaturesWithIncidentRecords SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Location Type</para>
		/// </summary>
		public enum LocationTypeEnum 
		{
			/// <summary>
			/// <para>坐标—将使用输入记录的 x,y 坐标创建要素。</para>
			/// </summary>
			[GPValue("COORDINATES")]
			[Description("坐标")]
			Coordinates,

			/// <summary>
			/// <para>地址—将通过定位器使用输入记录的地址创建要素。</para>
			/// </summary>
			[GPValue("ADDRESSES")]
			[Description("地址")]
			Addresses,

		}

		/// <summary>
		/// <para>Address Type</para>
		/// </summary>
		public enum AddressTypeEnum 
		{
			/// <summary>
			/// <para>单字段—地址将包含在一个字段中。</para>
			/// </summary>
			[GPValue("SINGLE_FIELD_ADDRESS")]
			[Description("单字段")]
			Single_Field,

			/// <summary>
			/// <para>多个字段—地址将拆分为多个字段。</para>
			/// </summary>
			[GPValue("MULTI_FIELD_ADDRESS")]
			[Description("多个字段")]
			Multiple_Fields,

		}

		/// <summary>
		/// <para>Update Existing Target Features</para>
		/// </summary>
		public enum UpdateTargetEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE")]
			UPDATE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("APPEND")]
			APPEND,

		}

		/// <summary>
		/// <para>Update Only Matching Features</para>
		/// </summary>
		public enum UpdateMatchingEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_MATCHING_ONLY")]
			UPDATE_MATCHING_ONLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("UPSERT")]
			UPSERT,

		}

		/// <summary>
		/// <para>Update Geometry for Existing Features</para>
		/// </summary>
		public enum UpdateGeometryEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_GEOMETRY")]
			UPDATE_GEOMETRY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_GEOMETRY")]
			KEEP_GEOMETRY,

		}

		/// <summary>
		/// <para>Field Matching Type</para>
		/// </summary>
		public enum FieldMatchingTypeEnum 
		{
			/// <summary>
			/// <para>输入字段必须与目标字段匹配—输入数据集的字段与目标数据集的字段相匹配。将忽略不匹配的字段。这是默认设置</para>
			/// </summary>
			[GPValue("AUTOMATIC")]
			[Description("输入字段必须与目标字段匹配")]
			Input_fields_must_match_target_fields,

			/// <summary>
			/// <para>使用字段映射协调字段差异—输入数据集的字段不需要与目标数据集的字段相匹配。不会将与目标数据集字段不匹配的输入数据集字段映射到目标数据集，除非在字段映射参数中显式设置了映射。</para>
			/// </summary>
			[GPValue("FIELD_MAP")]
			[Description("使用字段映射协调字段差异")]
			Use_the_field_map_to_reconcile_field_differences,

		}

#endregion
	}
}
