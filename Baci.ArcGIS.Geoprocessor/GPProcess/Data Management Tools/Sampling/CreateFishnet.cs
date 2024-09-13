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
	/// <para>Create Fishnet</para>
	/// <para>创建渔网</para>
	/// <para>创建由矩形像元组成的渔网。输出可以是折线或面要素。</para>
	/// </summary>
	public class CreateFishnet : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含由矩形像元组成的渔网的输出要素类。</para>
		/// </param>
		/// <param name="OriginCoord">
		/// <para>Fishnet Origin Coordinate</para>
		/// <para>渔网的起始枢轴点。</para>
		/// </param>
		/// <param name="YAxisCoord">
		/// <para>Y-Axis Coordinate</para>
		/// <para>Y 轴坐标用于定向渔网。按照原点坐标与 y 轴坐标的连线所定义的角度旋转渔网。</para>
		/// </param>
		/// <param name="CellWidth">
		/// <para>Cell Size Width</para>
		/// <para>确定每个单元的宽度。如果要使用行数参数值自动计算宽度，则请将该参数留空或将该值设置为零，这样在运行工具时便会自动计算宽度。</para>
		/// </param>
		/// <param name="CellHeight">
		/// <para>Cell Size Height</para>
		/// <para>确定每个单元的高度。如果要使用列数参数值自动计算高度，则请将该参数留空或将该值设置为零，这样在运行工具时便会自动计算高度。</para>
		/// </param>
		/// <param name="NumberRows">
		/// <para>Number of Rows</para>
		/// <para>确定渔网所含的行数。如果要使用像元宽度参数值自动计算行数，则请将该参数留空或将该值设置为零，这样在运行工具时便会自动计算行数。</para>
		/// </param>
		/// <param name="NumberColumns">
		/// <para>Number of Columns</para>
		/// <para>确定渔网所含的列数。如果要使用像元高度参数值自动计算列数，则将该参数留空或将该值设置为零，这样在运行工具时便会自动计算列数。</para>
		/// </param>
		public CreateFishnet(object OutFeatureClass, object OriginCoord, object YAxisCoord, object CellWidth, object CellHeight, object NumberRows, object NumberColumns)
		{
			this.OutFeatureClass = OutFeatureClass;
			this.OriginCoord = OriginCoord;
			this.YAxisCoord = YAxisCoord;
			this.CellWidth = CellWidth;
			this.CellHeight = CellHeight;
			this.NumberRows = NumberRows;
			this.NumberColumns = NumberColumns;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建渔网</para>
		/// </summary>
		public override string DisplayName() => "创建渔网";

		/// <summary>
		/// <para>Tool Name : CreateFishnet</para>
		/// </summary>
		public override string ToolName() => "CreateFishnet";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateFishnet</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateFishnet";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "XYDomain", "ZDomain", "configKeyword", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutFeatureClass, OriginCoord, YAxisCoord, CellWidth, CellHeight, NumberRows, NumberColumns, CornerCoord!, Labels!, Template!, GeometryType!, OutLabel! };

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含由矩形像元组成的渔网的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		[FeatureType("Simple")]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Fishnet Origin Coordinate</para>
		/// <para>渔网的起始枢轴点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPPoint()]
		public object OriginCoord { get; set; }

		/// <summary>
		/// <para>Y-Axis Coordinate</para>
		/// <para>Y 轴坐标用于定向渔网。按照原点坐标与 y 轴坐标的连线所定义的角度旋转渔网。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPPoint()]
		public object YAxisCoord { get; set; }

		/// <summary>
		/// <para>Cell Size Width</para>
		/// <para>确定每个单元的宽度。如果要使用行数参数值自动计算宽度，则请将该参数留空或将该值设置为零，这样在运行工具时便会自动计算宽度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object CellWidth { get; set; }

		/// <summary>
		/// <para>Cell Size Height</para>
		/// <para>确定每个单元的高度。如果要使用列数参数值自动计算高度，则请将该参数留空或将该值设置为零，这样在运行工具时便会自动计算高度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object CellHeight { get; set; }

		/// <summary>
		/// <para>Number of Rows</para>
		/// <para>确定渔网所含的行数。如果要使用像元宽度参数值自动计算行数，则请将该参数留空或将该值设置为零，这样在运行工具时便会自动计算行数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumberRows { get; set; }

		/// <summary>
		/// <para>Number of Columns</para>
		/// <para>确定渔网所含的列数。如果要使用像元高度参数值自动计算列数，则将该参数留空或将该值设置为零，这样在运行工具时便会自动计算列数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumberColumns { get; set; }

		/// <summary>
		/// <para>Opposite corner of Fishnet</para>
		/// <para>由 X 坐标和 Y 坐标值设置的渔网的对角。如果使用模板范围，则自动设置对角的值。如果已设置原点、Y 轴、像元大小以及行数和列数，则此参数将变为不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		public object? CornerCoord { get; set; }

		/// <summary>
		/// <para>Create Label Points</para>
		/// <para>指定是否创建包含在每个渔网像元中心标注点的点要素类。</para>
		/// <para>选中 - 创建带标注点的新要素类。这是默认设置。</para>
		/// <para>未选中 - 不创建标注点要素类。</para>
		/// <para><see cref="LabelsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Labels { get; set; } = "true";

		/// <summary>
		/// <para>Template Extent</para>
		/// <para>指定渔网的范围。可通过指定坐标或使用模板数据集来输入范围。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>当前显示范围 - 该范围与数据框或可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? Template { get; set; }

		/// <summary>
		/// <para>Geometry Type</para>
		/// <para>确定输出渔网像元是折线要素还是面要素。</para>
		/// <para>折线—输出是折线要素类。每个像元都由四个线要素定义。</para>
		/// <para>Polygon—输出是面要素类。每个像元都由一个面要素定义。</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? GeometryType { get; set; } = "POLYLINE";

		/// <summary>
		/// <para>Output Label Feature Class (Optional)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutLabel { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateFishnet SetEnviroment(object? MDomain = null , object? XYDomain = null , object? ZDomain = null , object? configKeyword = null , object? extent = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null )
		{
			base.SetEnv(MDomain: MDomain, XYDomain: XYDomain, ZDomain: ZDomain, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Create Label Points</para>
		/// </summary>
		public enum LabelsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("LABELS")]
			LABELS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_LABELS")]
			NO_LABELS,

		}

		/// <summary>
		/// <para>Geometry Type</para>
		/// </summary>
		public enum GeometryTypeEnum 
		{
			/// <summary>
			/// <para>折线—输出是折线要素类。每个像元都由四个线要素定义。</para>
			/// </summary>
			[GPValue("POLYLINE")]
			[Description("折线")]
			Polyline,

			/// <summary>
			/// <para>Polygon—输出是面要素类。每个像元都由一个面要素定义。</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("Polygon")]
			Polygon,

		}

#endregion
	}
}
