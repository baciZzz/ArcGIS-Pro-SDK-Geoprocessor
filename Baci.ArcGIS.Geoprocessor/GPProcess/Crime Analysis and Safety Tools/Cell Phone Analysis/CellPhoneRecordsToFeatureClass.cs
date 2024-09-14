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
	/// <para>Cell Phone Records To Feature Class</para>
	/// <para>手机记录转要素类</para>
	/// <para>用于从无线网络提供商处导入手机记录，并将这些记录与蜂窝基站记录转要素类工具根据标识符字段生成的蜂窝基站和扇区要素类相关联。</para>
	/// </summary>
	public class CellPhoneRecordsToFeatureClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Phone Records Table</para>
		/// <para>输入表，其中包含无线网络提供商提供的呼叫记录或电话数据事件记录。</para>
		/// </param>
		/// <param name="InSiteFeatures">
		/// <para>Input Cell Site Points</para>
		/// <para>要素类，其中包含蜂窝基站记录转要素类工具生成的蜂窝基站点。</para>
		/// </param>
		/// <param name="InSectorFeatures">
		/// <para>Input Cell Site Sectors</para>
		/// <para>要素类，其中包含蜂窝基站记录转要素类工具生成的蜂窝基站扇区。</para>
		/// </param>
		/// <param name="OutSiteFeatureClass">
		/// <para>Output Phone Record Site Points</para>
		/// <para>包含电话记录基站点的点要素类。</para>
		/// <para>将为链接到蜂窝基站点的每条电话记录生成一个点。</para>
		/// </param>
		/// <param name="OutSectorFeatureClass">
		/// <para>Output Phone Record Sectors</para>
		/// <para>包含电话记录扇区的面要素类。</para>
		/// <para>将为链接到蜂窝基站扇区的每条电话记录生成一个扇区面。</para>
		/// </param>
		/// <param name="IdFields">
		/// <para>Cell Sector ID Fields</para>
		/// <para>指定唯一 ID 字段类型以及将添加到输出要素的字段。</para>
		/// <para>当输入电话记录表参数值具有所有蜂窝扇区天线的唯一标识符时，使用唯一 ID类型。 当输入电话记录表参数值不包含所有蜂窝扇区天线的通用唯一标识符时，请结合使用其他 ID 类型值。</para>
		/// <para>&lt;para/&gt;</para>
		/// <para>ID 类型 - 要包含在输出要素类中的字段名称。</para>
		/// <para>字段 - 用于唯一标识蜂窝扇区天线的字段名称。这些将被添加至输出要素类中。</para>
		/// <para>ID 类型选项如下：</para>
		/// <para>唯一 ID - 用于唯一标识蜂窝扇区天线</para>
		/// <para>站点 ID - 用于唯一表示蜂窝基站</para>
		/// <para>扇区 ID - 用于唯一标识蜂窝扇区</para>
		/// <para>交换机 ID - 用于唯一标识无线网络交换机</para>
		/// <para>LAC ID - 用于唯一标识位置区号</para>
		/// <para>Cascade ID - 用于唯一标识无线网络 Cascade 中的扇区</para>
		/// <para>蜂窝 ID - 用于标识位置区号中的扇区</para>
		/// </param>
		/// <param name="SubscriberField">
		/// <para>Subscriber ID Field</para>
		/// <para>输入表中的字段，该输入表包含订阅者的电话号码或标识符。</para>
		/// </param>
		public CellPhoneRecordsToFeatureClass(object InTable, object InSiteFeatures, object InSectorFeatures, object OutSiteFeatureClass, object OutSectorFeatureClass, object IdFields, object SubscriberField)
		{
			this.InTable = InTable;
			this.InSiteFeatures = InSiteFeatures;
			this.InSectorFeatures = InSectorFeatures;
			this.OutSiteFeatureClass = OutSiteFeatureClass;
			this.OutSectorFeatureClass = OutSectorFeatureClass;
			this.IdFields = IdFields;
			this.SubscriberField = SubscriberField;
		}

		/// <summary>
		/// <para>Tool Display Name : 手机记录转要素类</para>
		/// </summary>
		public override string DisplayName() => "手机记录转要素类";

		/// <summary>
		/// <para>Tool Name : CellPhoneRecordsToFeatureClass</para>
		/// </summary>
		public override string ToolName() => "CellPhoneRecordsToFeatureClass";

		/// <summary>
		/// <para>Tool Excute Name : ca.CellPhoneRecordsToFeatureClass</para>
		/// </summary>
		public override string ExcuteName() => "ca.CellPhoneRecordsToFeatureClass";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "maintainAttachments", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, InSiteFeatures, InSectorFeatures, OutSiteFeatureClass, OutSectorFeatureClass, IdFields, SubscriberField, DestinationField, AdditionalIdFields, StartTimeField, DurationField, EndTimeField, ConvertUtc, LocationXField, LocationYField, LocationCoordinateSystem, OutCallPoints };

		/// <summary>
		/// <para>Input Phone Records Table</para>
		/// <para>输入表，其中包含无线网络提供商提供的呼叫记录或电话数据事件记录。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Input Cell Site Points</para>
		/// <para>要素类，其中包含蜂窝基站记录转要素类工具生成的蜂窝基站点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InSiteFeatures { get; set; }

		/// <summary>
		/// <para>Input Cell Site Sectors</para>
		/// <para>要素类，其中包含蜂窝基站记录转要素类工具生成的蜂窝基站扇区。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InSectorFeatures { get; set; }

		/// <summary>
		/// <para>Output Phone Record Site Points</para>
		/// <para>包含电话记录基站点的点要素类。</para>
		/// <para>将为链接到蜂窝基站点的每条电话记录生成一个点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutSiteFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Phone Record Sectors</para>
		/// <para>包含电话记录扇区的面要素类。</para>
		/// <para>将为链接到蜂窝基站扇区的每条电话记录生成一个扇区面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutSectorFeatureClass { get; set; }

		/// <summary>
		/// <para>Cell Sector ID Fields</para>
		/// <para>指定唯一 ID 字段类型以及将添加到输出要素的字段。</para>
		/// <para>当输入电话记录表参数值具有所有蜂窝扇区天线的唯一标识符时，使用唯一 ID类型。 当输入电话记录表参数值不包含所有蜂窝扇区天线的通用唯一标识符时，请结合使用其他 ID 类型值。</para>
		/// <para>&lt;para/&gt;</para>
		/// <para>ID 类型 - 要包含在输出要素类中的字段名称。</para>
		/// <para>字段 - 用于唯一标识蜂窝扇区天线的字段名称。这些将被添加至输出要素类中。</para>
		/// <para>ID 类型选项如下：</para>
		/// <para>唯一 ID - 用于唯一标识蜂窝扇区天线</para>
		/// <para>站点 ID - 用于唯一表示蜂窝基站</para>
		/// <para>扇区 ID - 用于唯一标识蜂窝扇区</para>
		/// <para>交换机 ID - 用于唯一标识无线网络交换机</para>
		/// <para>LAC ID - 用于唯一标识位置区号</para>
		/// <para>Cascade ID - 用于唯一标识无线网络 Cascade 中的扇区</para>
		/// <para>蜂窝 ID - 用于标识位置区号中的扇区</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object IdFields { get; set; }

		/// <summary>
		/// <para>Subscriber ID Field</para>
		/// <para>输入表中的字段，该输入表包含订阅者的电话号码或标识符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object SubscriberField { get; set; }

		/// <summary>
		/// <para>Destination Phone Number Field</para>
		/// <para>输入表中的字段，该输入表包含被呼叫者的电话号码或标识符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object DestinationField { get; set; }

		/// <summary>
		/// <para>Additional Cell Sector ID Fields</para>
		/// <para>指定附加唯一 ID 字段类型以及将添加到输出要素的字段。</para>
		/// <para>当输入电话记录表参数值具有所有蜂窝扇区天线的唯一标识符时，使用唯一 ID类型。 当输入电话记录表参数值不包含所有蜂窝扇区天线的通用唯一标识符时，请结合使用其他 ID 类型值。</para>
		/// <para>ID 类型 - 要包含在输出要素类中的字段名称。</para>
		/// <para>字段 - 用于唯一标识蜂窝扇区天线的字段名称。这些将被添加至输出要素类中。</para>
		/// <para>ID 类型选项如下：</para>
		/// <para>唯一 ID - 用于唯一标识蜂窝扇区天线</para>
		/// <para>站点 ID - 用于唯一表示蜂窝基站</para>
		/// <para>扇区 ID - 用于唯一标识蜂窝扇区</para>
		/// <para>交换机 ID - 用于唯一标识无线网络交换机</para>
		/// <para>LAC ID - 用于唯一标识位置区号</para>
		/// <para>Cascade ID - 用于唯一标识无线网络 Cascade 中的扇区</para>
		/// <para>蜂窝 ID - 用于标识位置区号中的扇区</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object AdditionalIdFields { get; set; }

		/// <summary>
		/// <para>Start Date and Time Field</para>
		/// <para>输入表中的字段，该输入表包含电话呼叫或数据事件的起始日期和时间字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Call Duration Information")]
		public object StartTimeField { get; set; }

		/// <summary>
		/// <para>Duration Field</para>
		/// <para>输入表中的字段，该输入表包含电话通话时长，以秒为单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[Category("Call Duration Information")]
		public object DurationField { get; set; }

		/// <summary>
		/// <para>End Date and Time Field</para>
		/// <para>输入表中的字段，该输入表包含电话呼叫或数据事件的结束日期和时间字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Call Duration Information")]
		public object EndTimeField { get; set; }

		/// <summary>
		/// <para>Convert UTC Dates to Local Time Zone</para>
		/// <para>指定将输入记录的起始及结束日期和时间转换为本地系统的时区，还是保留为协调世界时间 (UTC)。</para>
		/// <para>选中 - 输入记录的起始及结束日期和时间将从 UTC 转换为本地系统的时区。</para>
		/// <para>未选中 - 起始及结束日期和时间将不会进行转换。 这是默认设置。</para>
		/// <para><see cref="ConvertUtcEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Call Duration Information")]
		public object ConvertUtc { get; set; } = "false";

		/// <summary>
		/// <para>Estimated Phone Location X Field</para>
		/// <para>输入表中的字段，该输入表包含无线网络提供商提供的估计电话位置的 x 坐标。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[Category("Estimated Phone Location Output Options")]
		public object LocationXField { get; set; }

		/// <summary>
		/// <para>Estimated Phone Location Y Field</para>
		/// <para>输入表中的字段，该输入表包含无线网络提供商提供的估计电话位置的 y 坐标。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[Category("Estimated Phone Location Output Options")]
		public object LocationYField { get; set; }

		/// <summary>
		/// <para>Estimated Phone Location Coordinate System</para>
		/// <para>x,y 坐标的估计电话位置坐标系。 默认坐标系为 WGS84。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		[Category("Estimated Phone Location Output Options")]
		public object LocationCoordinateSystem { get; set; } = "GEOGCS[\"GCS_WGS_1984\",DATUM[\"D_WGS_1984\",SPHEROID[\"WGS_1984\",6378137.0,298.257223563]],PRIMEM[\"Greenwich\",0.0],UNIT[\"Degree\",0.0174532925199433]]";

		/// <summary>
		/// <para>Output Estimated Call Points</para>
		/// <para>点要素类，其中包含无线网络提供商提供的估计呼叫位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Estimated Phone Location Output Options")]
		public object OutCallPoints { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CellPhoneRecordsToFeatureClass SetEnviroment(object MDomain = null, object MResolution = null, object MTolerance = null, object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, bool? qualifiedFieldNames = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Convert UTC Dates to Local Time Zone</para>
		/// </summary>
		public enum ConvertUtcEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CONVERT")]
			CONVERT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CONVERT")]
			NO_CONVERT,

		}

#endregion
	}
}
