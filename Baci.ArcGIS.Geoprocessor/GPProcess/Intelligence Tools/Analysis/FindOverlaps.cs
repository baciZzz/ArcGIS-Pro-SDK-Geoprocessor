using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>Find Overlaps</para>
	/// <para>查找重叠</para>
	/// <para>用于查找要素类中的重叠区域并提供重叠数量的计数。</para>
	/// </summary>
	public class FindOverlaps : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>将计算其重叠的输入面要素。</para>
		/// </param>
		/// <param name="OutIntersection">
		/// <para>Output Intersections</para>
		/// <para>输出交集区域。</para>
		/// </param>
		/// <param name="OutCentroid">
		/// <para>Output Centroids</para>
		/// <para>输出交叉点要素的输出质心位置。</para>
		/// </param>
		public FindOverlaps(object InFeatures, object OutIntersection, object OutCentroid)
		{
			this.InFeatures = InFeatures;
			this.OutIntersection = OutIntersection;
			this.OutCentroid = OutCentroid;
		}

		/// <summary>
		/// <para>Tool Display Name : 查找重叠</para>
		/// </summary>
		public override string DisplayName() => "查找重叠";

		/// <summary>
		/// <para>Tool Name : FindOverlaps</para>
		/// </summary>
		public override string ToolName() => "FindOverlaps";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.FindOverlaps</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.FindOverlaps";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise() => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutIntersection, OutCentroid, GroupField! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将计算其重叠的输入面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Intersections</para>
		/// <para>输出交集区域。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object OutIntersection { get; set; }

		/// <summary>
		/// <para>Output Centroids</para>
		/// <para>输出交叉点要素的输出质心位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object OutCentroid { get; set; }

		/// <summary>
		/// <para>Group Field</para>
		/// <para>输入要素分组字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object? GroupField { get; set; }

	}
}
