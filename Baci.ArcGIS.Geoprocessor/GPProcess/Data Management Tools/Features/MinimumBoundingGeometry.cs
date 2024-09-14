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
	/// <para>Minimum Bounding Geometry</para>
	/// <para>最小边界几何</para>
	/// <para>创建包含若干面的要素类，用以表示封闭单个输入要素或成组的输入要素指定的最小边界几何。</para>
	/// </summary>
	public class MinimumBoundingGeometry : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>点、多点、线、面或多面体等输入要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>输出面要素类。</para>
		/// </param>
		public MinimumBoundingGeometry(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 最小边界几何</para>
		/// </summary>
		public override string DisplayName() => "最小边界几何";

		/// <summary>
		/// <para>Tool Name : MinimumBoundingGeometry</para>
		/// </summary>
		public override string ToolName() => "MinimumBoundingGeometry";

		/// <summary>
		/// <para>Tool Excute Name : management.MinimumBoundingGeometry</para>
		/// </summary>
		public override string ExcuteName() => "management.MinimumBoundingGeometry";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, GeometryType!, GroupOption!, GroupField!, MbgFieldsOption! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>点、多点、线、面或多面体等输入要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polyline", "Polygon", "MultiPatch")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出面要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Geometry Type</para>
		/// <para>指定输出面代表何种类型的最小边界几何。</para>
		/// <para>按面积矩形—封闭某输入要素的面积最小的矩形。 这是默认设置。</para>
		/// <para>按宽度矩形—封闭某输入要素的宽度最小的矩形。</para>
		/// <para>凸包—封闭某输入要素的最小凸面。</para>
		/// <para>圆形—封闭某输入要素包络矩形的最小圆形。</para>
		/// <para>包络矩形—输入要素的包络矩形。</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? GeometryType { get; set; } = "RECTANGLE_BY_AREA";

		/// <summary>
		/// <para>Group Option</para>
		/// <para>指定如何对输入要素进行分组；每组都会通过一个输出面来封闭。</para>
		/// <para>无—输入要素不会被分组。 这是默认设置。 此选项不适用于点输入数据。</para>
		/// <para>全部—所有输入要素将视为位于一个组中。</para>
		/// <para>列表—根据指定字段的公共值或分组字段参数中的字段对输入要素进行分组。</para>
		/// <para><see cref="GroupOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? GroupOption { get; set; } = "NONE";

		/// <summary>
		/// <para>Group Field(s)</para>
		/// <para>将 List 指定为组选项时用于对要素进行分组的输入要素的字段（一个或多个）。 对于 List 选项，至少需要一个分组字段。 指定字段（一个或多个）的值相同的所有要素均将视为位于一个组中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		[ExcludeField("SHAPE_Length", "SHAPE_Area")]
		public object? GroupField { get; set; }

		/// <summary>
		/// <para>Add geometry characteristics as attributes to output</para>
		/// <para>指定在输出要素类中是添加几何属性还是忽略几何属性。</para>
		/// <para>未选中 - 在输出要素类中忽略几何属性。 这是默认设置。</para>
		/// <para>选中 - 在输出要素类中添加几何属性。</para>
		/// <para><see cref="MbgFieldsOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MbgFieldsOption { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MinimumBoundingGeometry SetEnviroment(object? MDomain = null, double? MResolution = null, double? MTolerance = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, object? extent = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Geometry Type</para>
		/// </summary>
		public enum GeometryTypeEnum 
		{
			/// <summary>
			/// <para>按面积矩形—封闭某输入要素的面积最小的矩形。 这是默认设置。</para>
			/// </summary>
			[GPValue("RECTANGLE_BY_AREA")]
			[Description("按面积矩形")]
			Rectangle_by_area,

			/// <summary>
			/// <para>按宽度矩形—封闭某输入要素的宽度最小的矩形。</para>
			/// </summary>
			[GPValue("RECTANGLE_BY_WIDTH")]
			[Description("按宽度矩形")]
			Rectangle_by_width,

			/// <summary>
			/// <para>凸包—封闭某输入要素的最小凸面。</para>
			/// </summary>
			[GPValue("CONVEX_HULL")]
			[Description("凸包")]
			Convex_hull,

			/// <summary>
			/// <para>圆形—封闭某输入要素包络矩形的最小圆形。</para>
			/// </summary>
			[GPValue("CIRCLE")]
			[Description("圆形")]
			Circle,

			/// <summary>
			/// <para>包络矩形—输入要素的包络矩形。</para>
			/// </summary>
			[GPValue("ENVELOPE")]
			[Description("包络矩形")]
			Envelope,

		}

		/// <summary>
		/// <para>Group Option</para>
		/// </summary>
		public enum GroupOptionEnum 
		{
			/// <summary>
			/// <para>无—输入要素不会被分组。 这是默认设置。 此选项不适用于点输入数据。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>全部—所有输入要素将视为位于一个组中。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("全部")]
			All,

			/// <summary>
			/// <para>列表—根据指定字段的公共值或分组字段参数中的字段对输入要素进行分组。</para>
			/// </summary>
			[GPValue("LIST")]
			[Description("列表")]
			List,

		}

		/// <summary>
		/// <para>Add geometry characteristics as attributes to output</para>
		/// </summary>
		public enum MbgFieldsOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MBG_FIELDS")]
			MBG_FIELDS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MBG_FIELDS")]
			NO_MBG_FIELDS,

		}

#endregion
	}
}
