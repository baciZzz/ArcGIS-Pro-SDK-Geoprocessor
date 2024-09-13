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
	/// <para>Cell Site Records To Feature Class</para>
	/// <para>蜂窝基站记录转要素类</para>
	/// <para>根据来自蜂窝基站点表的输入纬度、经度、方位角、波束宽度和半径信息，创建蜂窝基站点和扇区面。</para>
	/// </summary>
	public class CellSiteRecordsToFeatureClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Cell Site Table</para>
		/// <para>输入表包含由无线网络提供商提供的蜂窝基站信息。</para>
		/// </param>
		/// <param name="OutSiteFeatureClass">
		/// <para>Output Cell Site Points</para>
		/// <para>包含输出蜂窝基站点的要素类。</para>
		/// </param>
		/// <param name="OutSectorFeatureClass">
		/// <para>Output Cell Site Sectors</para>
		/// <para>包含输出蜂窝基站扇区的要素类。</para>
		/// </param>
		/// <param name="IdFields">
		/// <para>Cell Sector ID Fields</para>
		/// <para>指定唯一 ID 字段类型以及将添加到输出要素的字段。</para>
		/// <para>当输入蜂窝基站表参数包含所有蜂窝扇区天线的唯一标识符时，请使用唯一 ID 值。当输入蜂窝基站表参数不包含所有蜂窝扇区天线的通用唯一标识符时，请结合使用其他 ID 类型值。</para>
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
		/// <param name="XField">
		/// <para>X Field</para>
		/// <para>输入表中包含蜂窝基站的 X 坐标的字段。</para>
		/// </param>
		/// <param name="YField">
		/// <para>Y Field</para>
		/// <para>输入表中包含蜂窝基站的 Y 坐标的字段。</para>
		/// </param>
		/// <param name="InCoordinateSystem">
		/// <para>Input Coordinate System</para>
		/// <para>X 字段和 Y 字段参数中指定的坐标的坐标系。</para>
		/// </param>
		/// <param name="OutCoordinateSystem">
		/// <para>Output Projected Coordinate System</para>
		/// <para>输出基站和扇区的投影坐标系。</para>
		/// </param>
		public CellSiteRecordsToFeatureClass(object InTable, object OutSiteFeatureClass, object OutSectorFeatureClass, object IdFields, object XField, object YField, object InCoordinateSystem, object OutCoordinateSystem)
		{
			this.InTable = InTable;
			this.OutSiteFeatureClass = OutSiteFeatureClass;
			this.OutSectorFeatureClass = OutSectorFeatureClass;
			this.IdFields = IdFields;
			this.XField = XField;
			this.YField = YField;
			this.InCoordinateSystem = InCoordinateSystem;
			this.OutCoordinateSystem = OutCoordinateSystem;
		}

		/// <summary>
		/// <para>Tool Display Name : 蜂窝基站记录转要素类</para>
		/// </summary>
		public override string DisplayName() => "蜂窝基站记录转要素类";

		/// <summary>
		/// <para>Tool Name : CellSiteRecordsToFeatureClass</para>
		/// </summary>
		public override string ToolName() => "CellSiteRecordsToFeatureClass";

		/// <summary>
		/// <para>Tool Excute Name : ca.CellSiteRecordsToFeatureClass</para>
		/// </summary>
		public override string ExcuteName() => "ca.CellSiteRecordsToFeatureClass";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "maintainAttachments", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, OutSiteFeatureClass, OutSectorFeatureClass, IdFields, XField, YField, InCoordinateSystem, OutCoordinateSystem, AzimuthField, DefaultAzimuth, BeamwidthField, BeamwidthType, DefaultBeamwidth, RadiusField, RadiusUnit, DefaultRadiusLength };

		/// <summary>
		/// <para>Input Cell Site Table</para>
		/// <para>输入表包含由无线网络提供商提供的蜂窝基站信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Cell Site Points</para>
		/// <para>包含输出蜂窝基站点的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutSiteFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Cell Site Sectors</para>
		/// <para>包含输出蜂窝基站扇区的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutSectorFeatureClass { get; set; }

		/// <summary>
		/// <para>Cell Sector ID Fields</para>
		/// <para>指定唯一 ID 字段类型以及将添加到输出要素的字段。</para>
		/// <para>当输入蜂窝基站表参数包含所有蜂窝扇区天线的唯一标识符时，请使用唯一 ID 值。当输入蜂窝基站表参数不包含所有蜂窝扇区天线的通用唯一标识符时，请结合使用其他 ID 类型值。</para>
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
		/// <para>X Field</para>
		/// <para>输入表中包含蜂窝基站的 X 坐标的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object XField { get; set; }

		/// <summary>
		/// <para>Y Field</para>
		/// <para>输入表中包含蜂窝基站的 Y 坐标的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object YField { get; set; }

		/// <summary>
		/// <para>Input Coordinate System</para>
		/// <para>X 字段和 Y 字段参数中指定的坐标的坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCoordinateSystem()]
		public object InCoordinateSystem { get; set; } = "GEOGCS[\"GCS_WGS_1984\",DATUM[\"D_WGS_1984\",SPHEROID[\"WGS_1984\",6378137.0,298.257223563]],PRIMEM[\"Greenwich\",0.0],UNIT[\"Degree\",0.0174532925199433]]";

		/// <summary>
		/// <para>Output Projected Coordinate System</para>
		/// <para>输出基站和扇区的投影坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCoordinateSystem()]
		public object OutCoordinateSystem { get; set; }

		/// <summary>
		/// <para>Azimuth Field</para>
		/// <para>输入表中包含天线信号方向的字段（蜂窝扇区）。</para>
		/// <para>方位角字段值必须以 0 到 360 度之间的正度数表示，以北为基准方向按顺时针进行测量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "Float", "Double")]
		public object AzimuthField { get; set; }

		/// <summary>
		/// <para>Default Start Azimuth</para>
		/// <para>未指定方位角字段时所要使用的天线信号（蜂窝扇区）的起始方位角值。</para>
		/// <para>例如，如果三个蜂窝扇区位于同一位置，并且此参数设置为 0 度。第一扇区以 0 度的方位角生成，第二扇区以 120 度的方位角生成，而第三扇区则以 240 度的方位角生成。</para>
		/// <para>未指定方位角字段时，使用此参数。</para>
		/// <para>方位角值必须以 0 到 360 之间的正度数表示。默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 360)]
		public object DefaultAzimuth { get; set; } = "0";

		/// <summary>
		/// <para>Beamwidth Field</para>
		/// <para>输入表中包含天线信号（蜂窝扇区）的全部或一半波束宽度值（角度）的字段。</para>
		/// <para>波束宽度必须以 0 到 360 之间的正度数表示。将 360 用于全向天线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "Float", "Double")]
		public object BeamwidthField { get; set; }

		/// <summary>
		/// <para>Beamwidth Type</para>
		/// <para>指定输入像元类型表中表示的波束宽度值的类型。</para>
		/// <para>全部波束宽度—全部波束宽度将在输入中表示。这是默认设置。</para>
		/// <para>一半波束宽度—一半波束宽度将在输入中表示。</para>
		/// <para><see cref="BeamwidthTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BeamwidthType { get; set; } = "FULL_BEAMWIDTH";

		/// <summary>
		/// <para>Default Beamwidth</para>
		/// <para>未指定波束宽度字段时所要使用的天线信号（蜂窝扇区）的波束宽度（度）。</para>
		/// <para>默认值为 90 度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 360)]
		public object DefaultBeamwidth { get; set; } = "90";

		/// <summary>
		/// <para>Radius Field</para>
		/// <para>输入表中包含天线信号（蜂窝扇区）的半径长度（信号距离）的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "Float", "Double")]
		public object RadiusField { get; set; }

		/// <summary>
		/// <para>Radius Unit</para>
		/// <para>指定半径字段的线性测量单位。.</para>
		/// <para>千米—单位将为公里。</para>
		/// <para>米—单位将为米。</para>
		/// <para>英里—单位将为英里。这是默认设置。</para>
		/// <para>码—单位将为码。</para>
		/// <para>英尺—单位将为英尺。</para>
		/// <para><see cref="RadiusUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RadiusUnit { get; set; } = "MILES";

		/// <summary>
		/// <para>Default Radius Length</para>
		/// <para>未指定径向字段时要使用的天线信号（蜂窝扇区）的半径长度（信号距离）。</para>
		/// <para>默认值为 2。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object DefaultRadiusLength { get; set; } = "2";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CellSiteRecordsToFeatureClass SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , bool? qualifiedFieldNames = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Beamwidth Type</para>
		/// </summary>
		public enum BeamwidthTypeEnum 
		{
			/// <summary>
			/// <para>全部波束宽度—全部波束宽度将在输入中表示。这是默认设置。</para>
			/// </summary>
			[GPValue("FULL_BEAMWIDTH")]
			[Description("全部波束宽度")]
			Full_Beamwidth,

			/// <summary>
			/// <para>一半波束宽度—一半波束宽度将在输入中表示。</para>
			/// </summary>
			[GPValue("HALF_BEAMWIDTH")]
			[Description("一半波束宽度")]
			Half_Beamwidth,

		}

		/// <summary>
		/// <para>Radius Unit</para>
		/// </summary>
		public enum RadiusUnitEnum 
		{
			/// <summary>
			/// <para>千米—单位将为公里。</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("千米")]
			Kilometers,

			/// <summary>
			/// <para>米—单位将为米。</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para>英里—单位将为英里。这是默认设置。</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("英里")]
			Miles,

			/// <summary>
			/// <para>码—单位将为码。</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("码")]
			Yards,

			/// <summary>
			/// <para>英尺—单位将为英尺。</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("英尺")]
			Feet,

		}

#endregion
	}
}
