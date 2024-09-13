using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>Calculate Z-value</para>
	/// <para>计算 Z 值</para>
	/// <para>在地统计图层中使用插值模型预测单个位置的值。</para>
	/// </summary>
	public class GACalculateZValue : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeostatLayer">
		/// <para>Input geostatistical layer</para>
		/// <para>要分析的地统计图层。</para>
		/// </param>
		/// <param name="PointCoord">
		/// <para>Input point</para>
		/// <para>需要计算 Z 值点的 x,y 坐标。</para>
		/// </param>
		public GACalculateZValue(object InGeostatLayer, object PointCoord)
		{
			this.InGeostatLayer = InGeostatLayer;
			this.PointCoord = PointCoord;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算 Z 值</para>
		/// </summary>
		public override string DisplayName() => "计算 Z 值";

		/// <summary>
		/// <para>Tool Name : GACalculateZValue</para>
		/// </summary>
		public override string ToolName() => "GACalculateZValue";

		/// <summary>
		/// <para>Tool Excute Name : ga.GACalculateZValue</para>
		/// </summary>
		public override string ExcuteName() => "ga.GACalculateZValue";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise() => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGeostatLayer, PointCoord, OutZValue };

		/// <summary>
		/// <para>Input geostatistical layer</para>
		/// <para>要分析的地统计图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object InGeostatLayer { get; set; }

		/// <summary>
		/// <para>Input point</para>
		/// <para>需要计算 Z 值点的 x,y 坐标。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPPoint()]
		public object PointCoord { get; set; }

		/// <summary>
		/// <para>Output Z-value</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object OutZValue { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GACalculateZValue SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
