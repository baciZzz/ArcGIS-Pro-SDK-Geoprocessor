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
	/// <para>Feature To 3D By Time</para>
	/// <para>依据时间实现要素转 3D</para>
	/// <para>可使用输入要素中的日期值来创建 3D 要素类。</para>
	/// </summary>
	public class FeatureTo3DByTime : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>用于创建 3D 要素的要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>输出启用 z 值的要素类。</para>
		/// </param>
		/// <param name="DateField">
		/// <para>Date Field</para>
		/// <para>输入中的日期字段，将用于计算要素的拉伸。</para>
		/// </param>
		public FeatureTo3DByTime(object InFeatures, object OutFeatureClass, object DateField)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.DateField = DateField;
		}

		/// <summary>
		/// <para>Tool Display Name : 依据时间实现要素转 3D</para>
		/// </summary>
		public override string DisplayName() => "依据时间实现要素转 3D";

		/// <summary>
		/// <para>Tool Name : FeatureTo3DByTime</para>
		/// </summary>
		public override string ToolName() => "FeatureTo3DByTime";

		/// <summary>
		/// <para>Tool Excute Name : ca.FeatureTo3DByTime</para>
		/// </summary>
		public override string ExcuteName() => "ca.FeatureTo3DByTime";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "outputZValue", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, DateField, TimeZUnit!, BaseZ!, BaseDate! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>用于创建 3D 要素的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon", "Polyline")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出启用 z 值的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Date Field</para>
		/// <para>输入中的日期字段，将用于计算要素的拉伸。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object DateField { get; set; }

		/// <summary>
		/// <para>Time Z Interval and Unit</para>
		/// <para>时间间隔和单位，将由输出要素类中的一个垂直线性单位表示。</para>
		/// <para>例如，如果输出要素类具有以米为单位的垂直坐标系，并且此参数的值为 1 秒，则生成的要素类将具有经过拉伸的要素，其中 1 米高程等于 1 秒时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeZUnit { get; set; } = "1 Seconds";

		/// <summary>
		/// <para>Base z-value</para>
		/// <para>输出要素将开始拉伸的基础 z 值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? BaseZ { get; set; } = "0";

		/// <summary>
		/// <para>Base Date and Time</para>
		/// <para>时间拉伸将基于的日期和时间。</para>
		/// <para>如果未指定任何值，则将使用输入的最小日期值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? BaseDate { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeatureTo3DByTime SetEnviroment(object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, double? outputZValue = null, object? workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputZValue: outputZValue, workspace: workspace);
			return this;
		}

	}
}
