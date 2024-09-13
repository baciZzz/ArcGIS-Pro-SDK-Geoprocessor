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
	/// <para>Calculate Grid Convergence Angle</para>
	/// <para>计算格网收敛角</para>
	/// <para>根据要素类中各要素的中心点计算偏离正北方向的旋转角度并将所得值填充到指定字段中。该字段可与空间地图系列结合使用，以将每幅地图旋转为正北方向。</para>
	/// </summary>
	public class CalculateGridConvergenceAngle : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入要素类（点、多点、线和面）。</para>
		/// </param>
		/// <param name="AngleField">
		/// <para>Angle Field</para>
		/// <para>将用计算所得的偏离正北方向的角度（以十进制度为单位）填充现有字段。</para>
		/// </param>
		public CalculateGridConvergenceAngle(object InFeatures, object AngleField)
		{
			this.InFeatures = InFeatures;
			this.AngleField = AngleField;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算格网收敛角</para>
		/// </summary>
		public override string DisplayName() => "计算格网收敛角";

		/// <summary>
		/// <para>Tool Name : CalculateGridConvergenceAngle</para>
		/// </summary>
		public override string ToolName() => "CalculateGridConvergenceAngle";

		/// <summary>
		/// <para>Tool Excute Name : cartography.CalculateGridConvergenceAngle</para>
		/// </summary>
		public override string ExcuteName() => "cartography.CalculateGridConvergenceAngle";

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
		public override string[] ValidEnvironments() => new string[] { "cartographicCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, AngleField, RotationMethod, CoordinateSysField, OutFeatures };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入要素类（点、多点、线和面）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Angle Field</para>
		/// <para>将用计算所得的偏离正北方向的角度（以十进制度为单位）填充现有字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long")]
		public object AngleField { get; set; }

		/// <summary>
		/// <para>Rotation Method</para>
		/// <para>指定用于计算旋转值的方法。</para>
		/// <para>地理—角度是以正北方向作为起点顺时针计算的。这是默认设置。</para>
		/// <para>算术—角度是以正东方向作为起点逆时针计算的。</para>
		/// <para>图形—角度是以正北方向作为起点逆时针计算的。</para>
		/// <para><see cref="RotationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RotationMethod { get; set; } = "GEOGRAPHIC";

		/// <summary>
		/// <para>Coordinate System Field</para>
		/// <para>该字段包含用于计算角度的投影坐标系的投影引擎字符串。各要素的角度计算均基于特定要素的投影坐标系的投影引擎字符串。在投影引擎字符串无效的情况下，该工具将使用在“制图”环境设置中指定的“制图”坐标系。默认设置为无，或不指定任何字段。如果未指定字段，将采用“制图”环境设置中指定的投影坐标系进行计算。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		[KeyField("NONE")]
		public object CoordinateSysField { get; set; } = "NONE";

		/// <summary>
		/// <para>Output Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateGridConvergenceAngle SetEnviroment(object cartographicCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Rotation Method</para>
		/// </summary>
		public enum RotationMethodEnum 
		{
			/// <summary>
			/// <para>地理—角度是以正北方向作为起点顺时针计算的。这是默认设置。</para>
			/// </summary>
			[GPValue("GEOGRAPHIC")]
			[Description("地理")]
			Geographic,

			/// <summary>
			/// <para>算术—角度是以正东方向作为起点逆时针计算的。</para>
			/// </summary>
			[GPValue("ARITHMETIC")]
			[Description("算术")]
			Arithmetic,

			/// <summary>
			/// <para>图形—角度是以正北方向作为起点逆时针计算的。</para>
			/// </summary>
			[GPValue("GRAPHIC")]
			[Description("图形")]
			Graphic,

		}

#endregion
	}
}
