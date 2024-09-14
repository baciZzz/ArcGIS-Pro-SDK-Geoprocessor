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
	/// <para>Compare Areas</para>
	/// <para>比较区域</para>
	/// <para>用于比较多个已知感兴趣区域中的运动点轨迹。</para>
	/// </summary>
	public class CompareAreas : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input Point Features</para>
		/// <para>表示运动轨迹点的点要素。 可以启用图层的时间。</para>
		/// </param>
		/// <param name="InAreaFeatures">
		/// <para>Input Area Features</para>
		/// <para>表示感兴趣区域的面要素，用于标识唯一运动轨迹点标识符。 可以启用图层的时间。</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output Feature Class</para>
		/// <para>输出面要素类。 输出将包含输入面要素几何以及来自面要素名称字段和点要素名称字段参数的唯一标识符。</para>
		/// <para>如果输入点要素和输入面要素参数值均已启用时间，并且关系设置为位置和时间，则将仅返回与几何和时间跨度匹配的要素。</para>
		/// </param>
		/// <param name="PointIdField">
		/// <para>Point Features Name Field</para>
		/// <para>此字段包含运动轨迹点的唯一标识符。 该字段可以是数值型或字符串型字段。</para>
		/// </param>
		/// <param name="AreaIdField">
		/// <para>Area Features Name Field</para>
		/// <para>此字段包含感兴趣区域的唯一标识符。 该字段可以是数值型或字符串型字段。</para>
		/// </param>
		/// <param name="Relationship">
		/// <para>Relationship</para>
		/// <para>指定输入之间的关系。</para>
		/// <para>仅位置—点和面要素将基于空间共现进行评估。</para>
		/// <para>位置和时间—点和面要素将基于时空共现进行评估。</para>
		/// <para><see cref="RelationshipEnum"/></para>
		/// </param>
		public CompareAreas(object InPointFeatures, object InAreaFeatures, object OutFeatureclass, object PointIdField, object AreaIdField, object Relationship)
		{
			this.InPointFeatures = InPointFeatures;
			this.InAreaFeatures = InAreaFeatures;
			this.OutFeatureclass = OutFeatureclass;
			this.PointIdField = PointIdField;
			this.AreaIdField = AreaIdField;
			this.Relationship = Relationship;
		}

		/// <summary>
		/// <para>Tool Display Name : 比较区域</para>
		/// </summary>
		public override string DisplayName() => "比较区域";

		/// <summary>
		/// <para>Tool Name : CompareAreas</para>
		/// </summary>
		public override string ToolName() => "CompareAreas";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.CompareAreas</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.CompareAreas";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPointFeatures, InAreaFeatures, OutFeatureclass, PointIdField, AreaIdField, Relationship, TimeDifference };

		/// <summary>
		/// <para>Input Point Features</para>
		/// <para>表示运动轨迹点的点要素。 可以启用图层的时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Input Area Features</para>
		/// <para>表示感兴趣区域的面要素，用于标识唯一运动轨迹点标识符。 可以启用图层的时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InAreaFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出面要素类。 输出将包含输入面要素几何以及来自面要素名称字段和点要素名称字段参数的唯一标识符。</para>
		/// <para>如果输入点要素和输入面要素参数值均已启用时间，并且关系设置为位置和时间，则将仅返回与几何和时间跨度匹配的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>Point Features Name Field</para>
		/// <para>此字段包含运动轨迹点的唯一标识符。 该字段可以是数值型或字符串型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object PointIdField { get; set; }

		/// <summary>
		/// <para>Area Features Name Field</para>
		/// <para>此字段包含感兴趣区域的唯一标识符。 该字段可以是数值型或字符串型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object AreaIdField { get; set; }

		/// <summary>
		/// <para>Relationship</para>
		/// <para>指定输入之间的关系。</para>
		/// <para>仅位置—点和面要素将基于空间共现进行评估。</para>
		/// <para>位置和时间—点和面要素将基于时空共现进行评估。</para>
		/// <para><see cref="RelationshipEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Relationship { get; set; } = "LOCATION_ONLY";

		/// <summary>
		/// <para>Time Difference</para>
		/// <para>如果输入点要素和输入面要素参数值之间允许的时间在空间关系之前，则该时间视为无效。 当关系参数设置为位置和时间并且两个输入均已启用时间时，此参数处于活动状态。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		public object TimeDifference { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CompareAreas SetEnviroment(object extent = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Relationship</para>
		/// </summary>
		public enum RelationshipEnum 
		{
			/// <summary>
			/// <para>仅位置—点和面要素将基于空间共现进行评估。</para>
			/// </summary>
			[GPValue("LOCATION_ONLY")]
			[Description("仅位置")]
			Location_Only,

			/// <summary>
			/// <para>位置和时间—点和面要素将基于时空共现进行评估。</para>
			/// </summary>
			[GPValue("LOCATION_TIME")]
			[Description("位置和时间")]
			Location_and_Time,

		}

#endregion
	}
}
