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
	/// <para>Geodetic Densify</para>
	/// <para>测地线增密</para>
	/// <para>通过将输入要素线段替换为近似的增密测地线线段来创建新要素。可以构建四种类型的测地线线段：测地线、大椭圆、等角航线以及法向截面。</para>
	/// </summary>
	public class GeodeticDensify : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入线或面要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含增密测地线要素的输出要素类。</para>
		/// </param>
		/// <param name="GeodeticType">
		/// <para>Geodetic Type</para>
		/// <para>指定要构造的测地线线段的类型。在与输入数据坐标系相关的椭圆体上执行测地线计算。</para>
		/// <para>测地线—椭球体（椭圆体）上两点间的最短距离。</para>
		/// <para>等角航线—连接两点的相等方位角的线（从一个极点）。</para>
		/// <para>大椭圆— 由平面相交得出的线包含椭球体中心以及这两个点。</para>
		/// <para>法向截面—由平面相交得出的线包含椭球体中心且在第一个点处与表面垂直。</para>
		/// <para><see cref="GeodeticTypeEnum"/></para>
		/// </param>
		public GeodeticDensify(object InFeatures, object OutFeatureClass, object GeodeticType)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.GeodeticType = GeodeticType;
		}

		/// <summary>
		/// <para>Tool Display Name : 测地线增密</para>
		/// </summary>
		public override string DisplayName() => "测地线增密";

		/// <summary>
		/// <para>Tool Name : GeodeticDensify</para>
		/// </summary>
		public override string ToolName() => "GeodeticDensify";

		/// <summary>
		/// <para>Tool Excute Name : management.GeodeticDensify</para>
		/// </summary>
		public override string ExcuteName() => "management.GeodeticDensify";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, GeodeticType, Distance! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入线或面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含增密测地线要素的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Geodetic Type</para>
		/// <para>指定要构造的测地线线段的类型。在与输入数据坐标系相关的椭圆体上执行测地线计算。</para>
		/// <para>测地线—椭球体（椭圆体）上两点间的最短距离。</para>
		/// <para>等角航线—连接两点的相等方位角的线（从一个极点）。</para>
		/// <para>大椭圆— 由平面相交得出的线包含椭球体中心以及这两个点。</para>
		/// <para>法向截面—由平面相交得出的线包含椭球体中心且在第一个点处与表面垂直。</para>
		/// <para><see cref="GeodeticTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GeodeticType { get; set; } = "GEODESIC";

		/// <summary>
		/// <para>Distance</para>
		/// <para>沿输出测地线线段的折点间的距离。默认值为 50 千米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? Distance { get; set; } = "50 Kilometers";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GeodeticDensify SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Geodetic Type</para>
		/// </summary>
		public enum GeodeticTypeEnum 
		{
			/// <summary>
			/// <para>测地线—椭球体（椭圆体）上两点间的最短距离。</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("测地线")]
			Geodesic,

			/// <summary>
			/// <para>等角航线—连接两点的相等方位角的线（从一个极点）。</para>
			/// </summary>
			[GPValue("LOXODROME")]
			[Description("等角航线")]
			Loxodrome,

			/// <summary>
			/// <para>大椭圆— 由平面相交得出的线包含椭球体中心以及这两个点。</para>
			/// </summary>
			[GPValue("GREAT_ELLIPTIC")]
			[Description("大椭圆")]
			Great_elliptic,

			/// <summary>
			/// <para>法向截面—由平面相交得出的线包含椭球体中心且在第一个点处与表面垂直。</para>
			/// </summary>
			[GPValue("NORMAL_SECTION")]
			[Description("法向截面")]
			Normal_section,

		}

#endregion
	}
}
