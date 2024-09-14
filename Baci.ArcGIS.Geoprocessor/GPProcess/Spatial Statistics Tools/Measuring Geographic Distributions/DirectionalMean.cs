using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools
{
	/// <summary>
	/// <para>Linear Directional Mean</para>
	/// <para>线性方向平均值</para>
	/// <para>识别一组线的平均方向、长度和地理中心。</para>
	/// </summary>
	public class DirectionalMean : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>包含将进行平均方向计算的矢量的要素类。</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将包含用于表示输入要素类的平均方向的要素的线要素类。</para>
		/// </param>
		/// <param name="OrientationOnly">
		/// <para>Orientation Only</para>
		/// <para>指定是否在分析中包括方向（起始结点和终止结点）信息。</para>
		/// <para>选中 - 将忽略起始结点和终止结点信息。</para>
		/// <para>未选中 - 将在计算平均值时使用起始结点和终止结点。这是默认设置。</para>
		/// <para><see cref="OrientationOnlyEnum"/></para>
		/// </param>
		public DirectionalMean(object InputFeatureClass, object OutputFeatureClass, object OrientationOnly)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.OutputFeatureClass = OutputFeatureClass;
			this.OrientationOnly = OrientationOnly;
		}

		/// <summary>
		/// <para>Tool Display Name : 线性方向平均值</para>
		/// </summary>
		public override string DisplayName() => "线性方向平均值";

		/// <summary>
		/// <para>Tool Name : DirectionalMean</para>
		/// </summary>
		public override string ToolName() => "DirectionalMean";

		/// <summary>
		/// <para>Tool Excute Name : stats.DirectionalMean</para>
		/// </summary>
		public override string ExcuteName() => "stats.DirectionalMean";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise() => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatureClass, OutputFeatureClass, OrientationOnly, CaseField! };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>包含将进行平均方向计算的矢量的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将包含用于表示输入要素类的平均方向的要素的线要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Orientation Only</para>
		/// <para>指定是否在分析中包括方向（起始结点和终止结点）信息。</para>
		/// <para>选中 - 将忽略起始结点和终止结点信息。</para>
		/// <para>未选中 - 将在计算平均值时使用起始结点和终止结点。这是默认设置。</para>
		/// <para><see cref="OrientationOnlyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object OrientationOnly { get; set; } = "false";

		/// <summary>
		/// <para>Case Field</para>
		/// <para>用于对要素进行分组以独立计算方向平均值的字段。案例分组字段可以为整型、日期型或字符串型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "Date")]
		public object? CaseField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DirectionalMean SetEnviroment(double? MResolution = null, double? MTolerance = null, object? XYResolution = null, object? XYTolerance = null, object? ZResolution = null, object? ZTolerance = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null, bool? qualifiedFieldNames = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Orientation Only</para>
		/// </summary>
		public enum OrientationOnlyEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ORIENTATION_ONLY")]
			ORIENTATION_ONLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DIRECTION")]
			DIRECTION,

		}

#endregion
	}
}
