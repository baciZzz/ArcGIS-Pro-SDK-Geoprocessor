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
	/// <para>Grid Index Features</para>
	/// <para>格网索引要素</para>
	/// <para>创建一个可用作索引的矩形面要素格网，以在空间地图系列中指定页面。可创建一个仅包含与另一要素图层相交的面要素的格网。</para>
	/// </summary>
	public class GridIndexFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>生成的面索引要素的要素类。</para>
		/// <para>输出要素类的坐标系按照以下方法确定：</para>
		/// <para>如果坐标系是通过输出坐标系环境指定的，则输出要素类将使用此坐标系。</para>
		/// <para>如果坐标系不是通过输出坐标系环境指定的，则输出要素类将使用活动地图（ArcGIS Pro 已打开）。</para>
		/// <para>如果坐标系不是通过输出坐标系环境指定的，并且没有活动地图（ArcGIS Pro 未打开），则输出要素类将使用第一个输入要素的坐标系。</para>
		/// <para>如果坐标系不是通过输出坐标系环境指定的，并且没有活动地图（ArcGIS Pro 未打开），也没有指定的输入要素，则输出要素类的坐标系将为未知。</para>
		/// </param>
		public GridIndexFeatures(object OutFeatureClass)
		{
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 格网索引要素</para>
		/// </summary>
		public override string DisplayName() => "格网索引要素";

		/// <summary>
		/// <para>Tool Name : GridIndexFeatures</para>
		/// </summary>
		public override string ToolName() => "GridIndexFeatures";

		/// <summary>
		/// <para>Tool Excute Name : cartography.GridIndexFeatures</para>
		/// </summary>
		public override string ExcuteName() => "cartography.GridIndexFeatures";

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
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutFeatureClass, InFeatures!, IntersectFeature!, UsePageUnit!, Scale!, PolygonWidth!, PolygonHeight!, OriginCoord!, NumberRows!, NumberColumns!, StartingPageNumber!, LabelFromOrigin! };

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>生成的面索引要素的要素类。</para>
		/// <para>输出要素类的坐标系按照以下方法确定：</para>
		/// <para>如果坐标系是通过输出坐标系环境指定的，则输出要素类将使用此坐标系。</para>
		/// <para>如果坐标系不是通过输出坐标系环境指定的，则输出要素类将使用活动地图（ArcGIS Pro 已打开）。</para>
		/// <para>如果坐标系不是通过输出坐标系环境指定的，并且没有活动地图（ArcGIS Pro 未打开），则输出要素类将使用第一个输入要素的坐标系。</para>
		/// <para>如果坐标系不是通过输出坐标系环境指定的，并且没有活动地图（ArcGIS Pro 未打开），也没有指定的输入要素，则输出要素类的坐标系将为未知。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入要素可用于定义将创建的面格网的范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? InFeatures { get; set; }

		/// <summary>
		/// <para>Generate Polygon Grid that intersects input feature layers or datasets</para>
		/// <para>指定是否将输出格网要素类限制为与输入要素图层或数据集相交的区域。输入要素的交集将用作创建索引要素。</para>
		/// <para>选中 - 将输出格网要素类限制为与输入要素图层或数据集相交的区域。当指定输入要素时，此为默认设置。</para>
		/// <para>未选中 - 将使用指定的坐标、行和列来创建输出格网要素类。</para>
		/// <para><see cref="IntersectFeatureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IntersectFeature { get; set; } = "false";

		/// <summary>
		/// <para>Use Page Unit and Scale</para>
		/// <para>指定索引面的大小输入是否使用页面单位。</para>
		/// <para>已选中 - 索引面的高度和宽度使用页面单位来计算。</para>
		/// <para>未选中 - 索引面的高度和宽度使用地图单位来计算。这是默认设置。</para>
		/// <para><see cref="UsePageUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? UsePageUnit { get; set; } = "false";

		/// <summary>
		/// <para>Map Scale</para>
		/// <para>地图比例。如果索引面的高度和宽度要使用页面单位来计算，则必须指定比例。如果该工具在活动 ArcGIS Pro 会话以外使用，则默认比例值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object? Scale { get; set; }

		/// <summary>
		/// <para>Polygon Width</para>
		/// <para>使用地图单位或页面单位指定的索引面的宽度。如果使用页面单位，则默认值为 1 英寸。如果使用地图单位，则默认值为 1 度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? PolygonWidth { get; set; } = "1 DecimalDegrees";

		/// <summary>
		/// <para>Polygon Height</para>
		/// <para>使用地图单位或页面单位指定的索引面的高度。如果使用页面单位，则默认值为 1 英寸。如果使用地图单位，则默认值为 1 度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? PolygonHeight { get; set; } = "1 DecimalDegrees";

		/// <summary>
		/// <para>Polygon Grid Origin Coordinate</para>
		/// <para>输出格网要素类的左下角原点的坐标值。如果输入要素已指定，则默认值由这些要素的范围的并集来确定。如果未指定输入要素，则默认坐标为 0 和 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		public object? OriginCoord { get; set; } = "0 0";

		/// <summary>
		/// <para>Number of Rows</para>
		/// <para>沿原点的 y 方向创建的行数。默认值为 10。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object? NumberRows { get; set; } = "10";

		/// <summary>
		/// <para>Number of Columns</para>
		/// <para>沿原点的 x 方向创建的列数。默认值为 10。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object? NumberColumns { get; set; } = "10";

		/// <summary>
		/// <para>Starting Page Number</para>
		/// <para>各格网索引要素将分配到连续的页码，起始页码需要指定。默认值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object? StartingPageNumber { get; set; } = "1";

		/// <summary>
		/// <para>Start labeling from the Origin</para>
		/// <para>指定页码（标注）的开始位置。</para>
		/// <para>选中 - 页码（标注）以输出格网左下角的面要素开头。</para>
		/// <para>未选中 - 页码（标注）以输出格网左上角的面要素开头。这是默认设置。</para>
		/// <para><see cref="LabelFromOriginEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? LabelFromOrigin { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GridIndexFeatures SetEnviroment(object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Generate Polygon Grid that intersects input feature layers or datasets</para>
		/// </summary>
		public enum IntersectFeatureEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INTERSECTFEATURE")]
			INTERSECTFEATURE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_INTERSECTFEATURE")]
			NO_INTERSECTFEATURE,

		}

		/// <summary>
		/// <para>Use Page Unit and Scale</para>
		/// </summary>
		public enum UsePageUnitEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("USEPAGEUNIT")]
			USEPAGEUNIT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_USEPAGEUNIT")]
			NO_USEPAGEUNIT,

		}

		/// <summary>
		/// <para>Start labeling from the Origin</para>
		/// </summary>
		public enum LabelFromOriginEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("LABELFROMORIGIN")]
			LABELFROMORIGIN,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_LABELFROMORIGIN")]
			NO_LABELFROMORIGIN,

		}

#endregion
	}
}
