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
	/// <para>Calculate Polygon Main Angle</para>
	/// <para>计算面的主角度</para>
	/// <para>计算输入面要素的主角度并将所得值分配给要素类中的指定字段。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class CalculatePolygonMainAngle : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入面要素。</para>
		/// </param>
		/// <param name="AngleField">
		/// <para>Angle Field</para>
		/// <para>将使用面的主角度值进行更新的字段。</para>
		/// </param>
		public CalculatePolygonMainAngle(object InFeatures, object AngleField)
		{
			this.InFeatures = InFeatures;
			this.AngleField = AngleField;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算面的主角度</para>
		/// </summary>
		public override string DisplayName() => "计算面的主角度";

		/// <summary>
		/// <para>Tool Name : CalculatePolygonMainAngle</para>
		/// </summary>
		public override string ToolName() => "CalculatePolygonMainAngle";

		/// <summary>
		/// <para>Tool Excute Name : cartography.CalculatePolygonMainAngle</para>
		/// </summary>
		public override string ExcuteName() => "cartography.CalculatePolygonMainAngle";

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
		public override string[] ValidEnvironments() => new string[] { "cartographicCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, AngleField, OutFeatures!, RotationMethod! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Angle Field</para>
		/// <para>将使用面的主角度值进行更新的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long")]
		public object AngleField { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatures { get; set; }

		/// <summary>
		/// <para>Rotation Method</para>
		/// <para>控制旋转的方法和原点。</para>
		/// <para>地理—以正北方向作为起点，顺时针旋转的角度。</para>
		/// <para>算术—以正东方向作为起点，逆时针旋转的角度。</para>
		/// <para>图形—以正北方向作为起点，逆时针旋转的角度。这是默认设置。</para>
		/// <para><see cref="RotationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RotationMethod { get; set; } = "GRAPHIC";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculatePolygonMainAngle SetEnviroment(object? cartographicCoordinateSystem = null)
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Rotation Method</para>
		/// </summary>
		public enum RotationMethodEnum 
		{
			/// <summary>
			/// <para>地理—以正北方向作为起点，顺时针旋转的角度。</para>
			/// </summary>
			[GPValue("GEOGRAPHIC")]
			[Description("地理")]
			Geographic,

			/// <summary>
			/// <para>算术—以正东方向作为起点，逆时针旋转的角度。</para>
			/// </summary>
			[GPValue("ARITHMETIC")]
			[Description("算术")]
			Arithmetic,

			/// <summary>
			/// <para>图形—以正北方向作为起点，逆时针旋转的角度。这是默认设置。</para>
			/// </summary>
			[GPValue("GRAPHIC")]
			[Description("图形")]
			Graphic,

		}

#endregion
	}
}
