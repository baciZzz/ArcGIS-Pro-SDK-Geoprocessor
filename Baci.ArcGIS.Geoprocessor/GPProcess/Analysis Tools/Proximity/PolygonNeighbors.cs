using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Polygon Neighbors</para>
	/// <para>面邻域</para>
	/// <para>根据面邻接（重叠、重合边或结点）创建统计数据表。</para>
	/// </summary>
	public class PolygonNeighbors : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入面要素。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>输出表。</para>
		/// </param>
		public PolygonNeighbors(object InFeatures, object OutTable)
		{
			this.InFeatures = InFeatures;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 面邻域</para>
		/// </summary>
		public override string DisplayName() => "面邻域";

		/// <summary>
		/// <para>Tool Name : PolygonNeighbors</para>
		/// </summary>
		public override string ToolName() => "PolygonNeighbors";

		/// <summary>
		/// <para>Tool Excute Name : analysis.PolygonNeighbors</para>
		/// </summary>
		public override string ExcuteName() => "analysis.PolygonNeighbors";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise() => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "extent", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutTable, InFields!, AreaOverlap!, BothSides!, ClusterTolerance!, OutLinearUnits!, OutAreaUnits! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>输出表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Report By Field(s)</para>
		/// <para>将使用一个或多个输入属性字段来确定唯一面或面组，并在输出中表示它们。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Date")]
		public object? InFields { get; set; }

		/// <summary>
		/// <para>Include area overlaps</para>
		/// <para>指定是否会在输出中分析和包括重叠区域关系。</para>
		/// <para>未选中 - 不会在输出中分析或包括重叠关系。 这是默认设置。</para>
		/// <para>选中 - 会在输出中分析和包括重叠关系。</para>
		/// <para><see cref="AreaOverlapEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AreaOverlap { get; set; } = "false";

		/// <summary>
		/// <para>Include both sides of neighbor relationship</para>
		/// <para>指定是否会在输出中包括邻域关系的两侧。</para>
		/// <para>选中 - 对于邻域面对，将同时包括两种邻域信息：一个面是源且另一个面是邻域，以及一个面是邻域且另一个面是源。 这是默认设置。</para>
		/// <para>未选中 - 对于邻域面对，仅包括一个面是源且另一个面是邻域的邻域信息。 不包括互反关系。</para>
		/// <para><see cref="BothSidesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? BothSides { get; set; } = "true";

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>在将两个坐标视为相同坐标之前它们之间的最小距离。 默认情况下，此为输入要素的 x,y 容差。</para>
		/// <para>更改此参数的值可能会导致出现故障或意外结果。 建议不要修改此参数。 已将其从工具对话框的视图中移除。 默认情况下，将使用输入要素类的空间参考 x,y 容差属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? ClusterTolerance { get; set; }

		/// <summary>
		/// <para>Output Linear Units</para>
		/// <para>指定将用于报告两个邻域面之间重合边的总长度的单位。 默认值为输入要素单位。</para>
		/// <para>未知—未知单位。</para>
		/// <para>英寸—将以英寸为单位。</para>
		/// <para>英尺—单位将为英尺。</para>
		/// <para>码—将以码为单位。</para>
		/// <para>英里—单位将为英里。</para>
		/// <para>海里—单位将为海里。</para>
		/// <para>毫米—将以毫米为单位。</para>
		/// <para>厘米—将以厘米为单位。</para>
		/// <para>分米—将以分米为单位。</para>
		/// <para>米—单位将为米。</para>
		/// <para>千米—单位将为公里。</para>
		/// <para>十进制度—单位将为十进制度。</para>
		/// <para>点—将以磅为单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutLinearUnits { get; set; } = "UNKNOWN";

		/// <summary>
		/// <para>Output Area Units</para>
		/// <para>指定将用于报告邻域面的区域重叠的单位。 默认值为输入要素单位。 只有选中了包括区域重叠参数时，此参数才处于活动状态。</para>
		/// <para>未知—未知单位。</para>
		/// <para>公亩—将以公亩为单位。</para>
		/// <para>英亩—将以英亩为单位。</para>
		/// <para>公顷—将以公顷为单位。</para>
		/// <para>平方英寸—将以平方英寸为单位。</para>
		/// <para>平方英尺—将以平方英尺为单位。</para>
		/// <para>平方码—将以平方码为单位。</para>
		/// <para>平方英里—将以平方英里为单位。</para>
		/// <para>平方毫米—将以平方毫米为单位。</para>
		/// <para>平方厘米—将以平方厘米为单位。</para>
		/// <para>平方分米—将以平方分米为单位。</para>
		/// <para>平方米—将以平方米为单位。</para>
		/// <para>平方千米—将以平方公里为单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutAreaUnits { get; set; } = "UNKNOWN";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PolygonNeighbors SetEnviroment(int? autoCommit = null , object? extent = null , bool? qualifiedFieldNames = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, extent: extent, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Include area overlaps</para>
		/// </summary>
		public enum AreaOverlapEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("AREA_OVERLAP")]
			AREA_OVERLAP,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_AREA_OVERLAP")]
			NO_AREA_OVERLAP,

		}

		/// <summary>
		/// <para>Include both sides of neighbor relationship</para>
		/// </summary>
		public enum BothSidesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("BOTH_SIDES")]
			BOTH_SIDES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_BOTH_SIDES")]
			NO_BOTH_SIDES,

		}

#endregion
	}
}
