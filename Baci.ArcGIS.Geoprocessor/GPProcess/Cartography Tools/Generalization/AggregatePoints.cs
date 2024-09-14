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
	/// <para>Aggregate Points</para>
	/// <para>聚合点</para>
	/// <para>在邻近点要素聚类周围创建面要素。</para>
	/// </summary>
	public class AggregatePoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要进行邻近性和聚类评估的输入点要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>用来保存表示点聚类的面的要素类。</para>
		/// </param>
		/// <param name="AggregationDistance">
		/// <para>Aggregation Distance</para>
		/// <para>将进行聚类的两个点之间的距离。</para>
		/// </param>
		public AggregatePoints(object InFeatures, object OutFeatureClass, object AggregationDistance)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.AggregationDistance = AggregationDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : 聚合点</para>
		/// </summary>
		public override string DisplayName() => "聚合点";

		/// <summary>
		/// <para>Tool Name : AggregatePoints</para>
		/// </summary>
		public override string ToolName() => "AggregatePoints";

		/// <summary>
		/// <para>Tool Excute Name : cartography.AggregatePoints</para>
		/// </summary>
		public override string ExcuteName() => "cartography.AggregatePoints";

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
		public override string[] ValidEnvironments() => new string[] { "XYResolution", "extent", "outputZFlag", "outputZValue" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, AggregationDistance, OutTable };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要进行邻近性和聚类评估的输入点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>用来保存表示点聚类的面的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Aggregation Distance</para>
		/// <para>将进行聚类的两个点之间的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object AggregationDistance { get; set; }

		/// <summary>
		/// <para>Relationship Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object OutTable { get; set; } = "output_table";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AggregatePoints SetEnviroment(object XYResolution = null, object extent = null, object outputZFlag = null, object outputZValue = null)
		{
			base.SetEnv(XYResolution: XYResolution, extent: extent, outputZFlag: outputZFlag, outputZValue: outputZValue);
			return this;
		}

	}
}
