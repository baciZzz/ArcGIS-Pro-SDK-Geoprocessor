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
	/// <para>Collapse Hydro Polygon</para>
	/// <para>折叠水文面</para>
	/// <para>根据折叠宽度将水文面折叠或部分折叠到中心线。</para>
	/// </summary>
	public class CollapseHydroPolygon : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Hydro Polygon Features</para>
		/// <para>包含水文面的一个或多个要素图层。</para>
		/// </param>
		/// <param name="OutLineFeatureClass">
		/// <para>Output Line Feature Class</para>
		/// <para>包含折叠面中心线的线要素类。 它包含所有输入面（包括为折叠的面）的中心线。 该要素类具有 COLLAPSED 属性，用于指定中心线要素是否表示折叠面。</para>
		/// </param>
		public CollapseHydroPolygon(object InFeatures, object OutLineFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutLineFeatureClass = OutLineFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 折叠水文面</para>
		/// </summary>
		public override string DisplayName() => "折叠水文面";

		/// <summary>
		/// <para>Tool Name : CollapseHydroPolygon</para>
		/// </summary>
		public override string ToolName() => "CollapseHydroPolygon";

		/// <summary>
		/// <para>Tool Excute Name : cartography.CollapseHydroPolygon</para>
		/// </summary>
		public override string ExcuteName() => "cartography.CollapseHydroPolygon";

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
		public override string[] ValidEnvironments() => new string[] { "cartographicPartitions" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutLineFeatureClass, MergeAdjacentInputPolygons!, ConnectingFeatures!, CollapseWidth!, CollapseWidthTolerance!, MinimumLength!, TaperLengthPercentage!, OutPolyFeatureClass!, InPolyDecodeIdTable!, InLineDecodeIdTable! };

		/// <summary>
		/// <para>Input Hydro Polygon Features</para>
		/// <para>包含水文面的一个或多个要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Line Feature Class</para>
		/// <para>包含折叠面中心线的线要素类。 它包含所有输入面（包括为折叠的面）的中心线。 该要素类具有 COLLAPSED 属性，用于指定中心线要素是否表示折叠面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object OutLineFeatureClass { get; set; }

		/// <summary>
		/// <para>Merge Adjacent Input Polygons</para>
		/// <para>指定在计算中心线之前是否合并相邻输入面。</para>
		/// <para>选中 - 在计算中心线之前将合并相邻输入面。 这是默认设置。</para>
		/// <para>未选中 - 将根据未合并的输入水文面计算中心线。</para>
		/// <para><see cref="MergeAdjacentInputPolygonsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MergeAdjacentInputPolygons { get; set; } = "true";

		/// <summary>
		/// <para>Connecting Hydro Line Features</para>
		/// <para>连接到要折叠的输入水文面的输入水文线要素。 将创建线要素以保持这些连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object? ConnectingFeatures { get; set; }

		/// <summary>
		/// <para>Collapse Width</para>
		/// <para>要考虑折叠的输入水文面的阈值宽度。 所有低于指定宽度的面都将被折叠。 默认值为 0，这将折叠所有要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? CollapseWidth { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Collapse Width Tolerance (%)</para>
		/// <para>将分析其中要素的百分比容差，并且在确定是否折叠要素时将考虑周围环境。 这是为了最大限度地减少折叠内的振荡。 默认值为 20%。 仅当已指定折叠宽度参数值时才应用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? CollapseWidthTolerance { get; set; } = "20";

		/// <summary>
		/// <para>Minimum Length</para>
		/// <para>在输出面要素类中保留面所需的最小长度。 最小长度基于为面创建的中心线的长度。 如果面的中心线长于折叠宽度但短于最小长度，则该面将不会包含在输出面要素类中。 默认值为 0。 仅当已指定折叠宽度参数值时才应用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? MinimumLength { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Taper Length Percentage</para>
		/// <para>输出面要素类和输出线要素类中的面之间的连接长度将锥化。 此参数将锥形长度指定为连接位置处宽度的百分比。 如锥形长度百分比值为 0，则不会锥化。 默认值为 50。仅当已指定折叠宽度参数值时才应用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? TaperLengthPercentage { get; set; } = "50";

		/// <summary>
		/// <para>Output Polygon Feature Class</para>
		/// <para>此面要素类包含未折叠的输入水文面部分。 仅当已指定折叠宽度参数值时才应用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object? OutPolyFeatureClass { get; set; }

		/// <summary>
		/// <para>InPoly Decode ID Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? InPolyDecodeIdTable { get; set; }

		/// <summary>
		/// <para>InLine Decode ID Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? InLineDecodeIdTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CollapseHydroPolygon SetEnviroment(object? cartographicPartitions = null )
		{
			base.SetEnv(cartographicPartitions: cartographicPartitions);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Merge Adjacent Input Polygons</para>
		/// </summary>
		public enum MergeAdjacentInputPolygonsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MERGE_ADJACENT")]
			MERGE_ADJACENT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MERGE")]
			NO_MERGE,

		}

#endregion
	}
}
