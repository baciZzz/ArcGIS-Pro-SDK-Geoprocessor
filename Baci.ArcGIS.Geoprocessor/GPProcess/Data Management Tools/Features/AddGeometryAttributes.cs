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
	/// <para>Add Geometry Attributes</para>
	/// <para>添加几何属性</para>
	/// <para>向表示各要素空间或几何特性和位置的输入要素添加新的属性字段，如长度或面积或 x、y、z 和 m 坐标。</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.DataManagementTools.CalculateGeometryAttributes"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[Obsolete()]
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.DataManagementTools.CalculateGeometryAttributes))]
	public class AddGeometryAttributes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>将向输入要素添加新的属性字段以存储各种属性，如长度、面积或 x、y、z 和 m 坐标。</para>
		/// </param>
		/// <param name="GeometryProperties">
		/// <para>Geometry Properties</para>
		/// <para>指定将在新属性字段中进行计算的几何属性或形状属性。</para>
		/// <para>面积—将添加用于存储各个面要素面积的属性。</para>
		/// <para>测地线面积—将添加属性以存储各个面要素的形状不变的测地线面积。</para>
		/// <para>质心坐标—将添加属性以存储每个要素的质心坐标。</para>
		/// <para>中心点坐标—将添加用于存储各个要素内或要素上中心点坐标的属性。</para>
		/// <para>范围坐标—将添加属性以存储各个要素的范围坐标。</para>
		/// <para>长度—将添加用于存储各个线要素长度的属性。</para>
		/// <para>测地线长度—将添加属性以存储各个线要素的形状不变的测地线长度。</para>
		/// <para>3D 长度—将添加用于存储各个线要素 3D 长度的属性。</para>
		/// <para>线方位角—将添加用于存储各个线要素线段起始-结束方位角的属性。 值范围介于 0 至 360 之间，其中 0 表示北，90 表示东，180 表示南，270 表示西。</para>
		/// <para>线起点、中点和终点坐标—将添加用于存储各个要素起点、中点和终点坐标的属性。</para>
		/// <para>部分数量—将添加用于存储包含各个要素的部分数量的属性。</para>
		/// <para>周长—将添加用于存储各个面要素周长或边界长度的属性。</para>
		/// <para>测地线周长—将添加属性以存储各个面要素周长或边界的形状不变的测地线长度。</para>
		/// <para>折点数量—将添加用于存储包含各个要素的点或折点数量的属性。</para>
		/// <para>点 x、y、z 和 m 坐标—将添加用于存储各个点要素 x、y、z 和 m 坐标的属性。</para>
		/// </param>
		public AddGeometryAttributes(object InputFeatures, object GeometryProperties)
		{
			this.InputFeatures = InputFeatures;
			this.GeometryProperties = GeometryProperties;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加几何属性</para>
		/// </summary>
		public override string DisplayName() => "添加几何属性";

		/// <summary>
		/// <para>Tool Name : AddGeometryAttributes</para>
		/// </summary>
		public override string ToolName() => "AddGeometryAttributes";

		/// <summary>
		/// <para>Tool Excute Name : management.AddGeometryAttributes</para>
		/// </summary>
		public override string ExcuteName() => "management.AddGeometryAttributes";

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
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatures, GeometryProperties, LengthUnit!, AreaUnit!, CoordinateSystem!, ModifiedInputFeatures! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将向输入要素添加新的属性字段以存储各种属性，如长度、面积或 x、y、z 和 m 坐标。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Geometry Properties</para>
		/// <para>指定将在新属性字段中进行计算的几何属性或形状属性。</para>
		/// <para>面积—将添加用于存储各个面要素面积的属性。</para>
		/// <para>测地线面积—将添加属性以存储各个面要素的形状不变的测地线面积。</para>
		/// <para>质心坐标—将添加属性以存储每个要素的质心坐标。</para>
		/// <para>中心点坐标—将添加用于存储各个要素内或要素上中心点坐标的属性。</para>
		/// <para>范围坐标—将添加属性以存储各个要素的范围坐标。</para>
		/// <para>长度—将添加用于存储各个线要素长度的属性。</para>
		/// <para>测地线长度—将添加属性以存储各个线要素的形状不变的测地线长度。</para>
		/// <para>3D 长度—将添加用于存储各个线要素 3D 长度的属性。</para>
		/// <para>线方位角—将添加用于存储各个线要素线段起始-结束方位角的属性。 值范围介于 0 至 360 之间，其中 0 表示北，90 表示东，180 表示南，270 表示西。</para>
		/// <para>线起点、中点和终点坐标—将添加用于存储各个要素起点、中点和终点坐标的属性。</para>
		/// <para>部分数量—将添加用于存储包含各个要素的部分数量的属性。</para>
		/// <para>周长—将添加用于存储各个面要素周长或边界长度的属性。</para>
		/// <para>测地线周长—将添加属性以存储各个面要素周长或边界的形状不变的测地线长度。</para>
		/// <para>折点数量—将添加用于存储包含各个要素的点或折点数量的属性。</para>
		/// <para>点 x、y、z 和 m 坐标—将添加用于存储各个点要素 x、y、z 和 m 坐标的属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object GeometryProperties { get; set; }

		/// <summary>
		/// <para>Length Unit</para>
		/// <para>指定计算长度时将采用的单位。</para>
		/// <para>英尺（美国）—长度单位为英尺（美国）</para>
		/// <para>米—长度单位为米</para>
		/// <para>千米—长度单位为千米</para>
		/// <para>英里（美国）—长度单位为英里（美国）</para>
		/// <para>海里（美国）—长度单位为海里（美国）</para>
		/// <para>码（美国）—长度单位为码（美国）</para>
		/// <para><see cref="LengthUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LengthUnit { get; set; }

		/// <summary>
		/// <para>Area Unit</para>
		/// <para>指定计算面积时将采用的单位。</para>
		/// <para>英亩—面积单位为英亩</para>
		/// <para>公顷—面积单位为公顷</para>
		/// <para>平方英里（美国）—面积单位为平方英里（美国）</para>
		/// <para>平方千米—面积单位为平方千米</para>
		/// <para>平方米—面积单位为平方米</para>
		/// <para>平方英尺（美国）—面积单位为平方英尺（美国）</para>
		/// <para>平方码（美国）—面积单位为平方码（美国）</para>
		/// <para>平方海里（美国）—面积单位为平方海里（美国）</para>
		/// <para><see cref="AreaUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? AreaUnit { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>用于计算坐标、长度和面积的坐标系。 默认使用输入要素的坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object? CoordinateSystem { get; set; }

		/// <summary>
		/// <para>Modified Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? ModifiedInputFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddGeometryAttributes SetEnviroment(object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Length Unit</para>
		/// </summary>
		public enum LengthUnitEnum 
		{
			/// <summary>
			/// <para>英尺（美国）—长度单位为英尺（美国）</para>
			/// </summary>
			[GPValue("FEET_US")]
			[Description("英尺（美国）")]
			FEET_US,

			/// <summary>
			/// <para>米—长度单位为米</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para>千米—长度单位为千米</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("千米")]
			Kilometers,

			/// <summary>
			/// <para>英里（美国）—长度单位为英里（美国）</para>
			/// </summary>
			[GPValue("MILES_US")]
			[Description("英里（美国）")]
			MILES_US,

			/// <summary>
			/// <para>海里（美国）—长度单位为海里（美国）</para>
			/// </summary>
			[GPValue("NAUTICAL_MILES")]
			[Description("海里（美国）")]
			NAUTICAL_MILES,

			/// <summary>
			/// <para>码（美国）—长度单位为码（美国）</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("码（美国）")]
			YARDS,

		}

		/// <summary>
		/// <para>Area Unit</para>
		/// </summary>
		public enum AreaUnitEnum 
		{
			/// <summary>
			/// <para>英亩—面积单位为英亩</para>
			/// </summary>
			[GPValue("ACRES")]
			[Description("英亩")]
			Acres,

			/// <summary>
			/// <para>公顷—面积单位为公顷</para>
			/// </summary>
			[GPValue("HECTARES")]
			[Description("公顷")]
			Hectares,

			/// <summary>
			/// <para>平方英里（美国）—面积单位为平方英里（美国）</para>
			/// </summary>
			[GPValue("SQUARE_MILES_US")]
			[Description("平方英里（美国）")]
			SQUARE_MILES_US,

			/// <summary>
			/// <para>平方千米—面积单位为平方千米</para>
			/// </summary>
			[GPValue("SQUARE_KILOMETERS")]
			[Description("平方千米")]
			Square_kilometers,

			/// <summary>
			/// <para>平方米—面积单位为平方米</para>
			/// </summary>
			[GPValue("SQUARE_METERS")]
			[Description("平方米")]
			Square_meters,

			/// <summary>
			/// <para>平方英尺（美国）—面积单位为平方英尺（美国）</para>
			/// </summary>
			[GPValue("SQUARE_FEET_US")]
			[Description("平方英尺（美国）")]
			SQUARE_FEET_US,

			/// <summary>
			/// <para>平方码（美国）—面积单位为平方码（美国）</para>
			/// </summary>
			[GPValue("SQUARE_YARDS")]
			[Description("平方码（美国）")]
			SQUARE_YARDS,

			/// <summary>
			/// <para>平方海里（美国）—面积单位为平方海里（美国）</para>
			/// </summary>
			[GPValue("SQUARE_NAUTICAL_MILES")]
			[Description("平方海里（美国）")]
			SQUARE_NAUTICAL_MILES,

		}

#endregion
	}
}
