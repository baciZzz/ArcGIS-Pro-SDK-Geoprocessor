using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Skyline Graph</para>
	/// <para>天际线图</para>
	/// <para>计算天空的可见性，并选择性地生成表和极线图。</para>
	/// </summary>
	public class SkylineGraph : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InObserverPointFeatures">
		/// <para>Input Observer Point Features</para>
		/// <para>包含一个或多个观察点的输入要素。</para>
		/// </param>
		/// <param name="InLineFeatures">
		/// <para>Input Line Features</para>
		/// <para>表示天际线的线要素。</para>
		/// </param>
		public SkylineGraph(object InObserverPointFeatures, object InLineFeatures)
		{
			this.InObserverPointFeatures = InObserverPointFeatures;
			this.InLineFeatures = InLineFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 天际线图</para>
		/// </summary>
		public override string DisplayName() => "天际线图";

		/// <summary>
		/// <para>Tool Name : SkylineGraph</para>
		/// </summary>
		public override string ToolName() => "SkylineGraph";

		/// <summary>
		/// <para>Tool Excute Name : 3d.SkylineGraph</para>
		/// </summary>
		public override string ExcuteName() => "3d.SkylineGraph";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InObserverPointFeatures, InLineFeatures, BaseVisibilityAngle, AdditionalFields, OutAnglesTable, OutGraph, OutVisibilityRatio };

		/// <summary>
		/// <para>Input Observer Point Features</para>
		/// <para>包含一个或多个观察点的输入要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InObserverPointFeatures { get; set; }

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>表示天际线的线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLineFeatures { get; set; }

		/// <summary>
		/// <para>Base  Visibility Angle</para>
		/// <para>用作计算可见天空百分比的基线的垂直角。0 表示水平，90 表示竖直向上；-90 表示竖直向下。默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object BaseVisibilityAngle { get; set; } = "0";

		/// <summary>
		/// <para>Additional Fields</para>
		/// <para>指定是否有附加字段添加到角度表中。</para>
		/// <para>未选中 - 不添加附加字段。这是默认设置。</para>
		/// <para>已选中 - 将添加附加字段。</para>
		/// <para><see cref="AdditionalFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AdditionalFields { get; set; } = "false";

		/// <summary>
		/// <para>Output Angles Table</para>
		/// <para>创建用于输出角度的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object OutAnglesTable { get; set; }

		/// <summary>
		/// <para>Output Graph Name</para>
		/// <para>不支持此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGraph()]
		public object OutGraph { get; set; }

		/// <summary>
		/// <para>Visibility Ratio</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object OutVisibilityRatio { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SkylineGraph SetEnviroment(object extent = null , object geographicTransformations = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Additional Fields</para>
		/// </summary>
		public enum AdditionalFieldsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADDITIONAL_FIELDS")]
			ADDITIONAL_FIELDS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ADDITIONAL_FIELDS")]
			NO_ADDITIONAL_FIELDS,

		}

#endregion
	}
}
