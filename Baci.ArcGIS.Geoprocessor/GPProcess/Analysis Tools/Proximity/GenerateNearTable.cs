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
	/// <para>Generate Near Table</para>
	/// <para>生成近邻表</para>
	/// <para>计算一个或多个要素类或图层中的要素间距离和其他邻近性信息。 与可修改输入的近邻分析工具不同，生成近邻表可将结果写入新的独立表中，并支持查找多个邻近要素。</para>
	/// </summary>
	public class GenerateNearTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入要素可以是点、折线、面或多点类型。</para>
		/// </param>
		/// <param name="NearFeatures">
		/// <para>Near Features</para>
		/// <para>一个或多个包含邻近要素候选项的要素类的图层。 邻近要素可以是点、折线、面或多点。 如果指定了多个图层或要素类，则名为 NEAR_FC 的字段将被添加到输入表中，并将存储含有找到的最近要素的源要素类的路径。 同一要素类或图层可同时用作输入要素和邻近要素。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>包含分析结果的输出表。</para>
		/// </param>
		public GenerateNearTable(object InFeatures, object NearFeatures, object OutTable)
		{
			this.InFeatures = InFeatures;
			this.NearFeatures = NearFeatures;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成近邻表</para>
		/// </summary>
		public override string DisplayName() => "生成近邻表";

		/// <summary>
		/// <para>Tool Name : GenerateNearTable</para>
		/// </summary>
		public override string ToolName() => "GenerateNearTable";

		/// <summary>
		/// <para>Tool Excute Name : analysis.GenerateNearTable</para>
		/// </summary>
		public override string ExcuteName() => "analysis.GenerateNearTable";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, NearFeatures, OutTable, SearchRadius, Location, Angle, Closest, ClosestCount, Method };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入要素可以是点、折线、面或多点类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Near Features</para>
		/// <para>一个或多个包含邻近要素候选项的要素类的图层。 邻近要素可以是点、折线、面或多点。 如果指定了多个图层或要素类，则名为 NEAR_FC 的字段将被添加到输入表中，并将存储含有找到的最近要素的源要素类的路径。 同一要素类或图层可同时用作输入要素和邻近要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object NearFeatures { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>包含分析结果的输出表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>用于搜索邻近要素的半径。 如果未指定任何值，则所有邻近要素都将是候选项。 如果输入了距离，但单位留空或设为未知，则将使用输入要素的坐标系的单位。 如果方法参数使用了测地线选项，则应使用线性单位（如公里或英里）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object SearchRadius { get; set; }

		/// <summary>
		/// <para>Location</para>
		/// <para>指定是否将输入要素的位置以及邻近要素的最近位置的 x 坐标和 y 坐标写入 FROM_X、FROM_Y、NEAR_X 和 NEAR_Y 字段。</para>
		/// <para>未选中 - 这些位置将不会被写入到输出表中。 这是默认设置。</para>
		/// <para>选中 - 位置将被写入到输出表中。</para>
		/// <para><see cref="LocationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Location { get; set; } = "false";

		/// <summary>
		/// <para>Angle</para>
		/// <para>指定是否计算邻近角并将其写入输出表的 NEAR_ANGLE 字段。 邻近角测量与直线（该直线连接输入要素与其最近要素的最近位置）方向之间的夹角。 在方法参数中使用平面方法时，角度在 -180° 到 180° 的范围内，0°代表东，90°代表北，180°（或 -180°）代表西，-90° 代表南。 使用测地线方法时，角度在 -180° 到 180° 的范围内，0° 代表北，90° 代表东，180°（或 -180°）代表南，-90° 代表西。</para>
		/// <para>未选中 - NEAR_ANGLE 不会添加到输出表中。 这是默认设置。</para>
		/// <para>选中 - NEAR_ANGLE 将被添加到输出表中。</para>
		/// <para><see cref="AngleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Angle { get; set; } = "false";

		/// <summary>
		/// <para>Find only closest feature</para>
		/// <para>指定仅返回最近要素或返回多个要素。</para>
		/// <para>选中 - 仅将最近的邻近要素写入输出表。 这是默认设置。</para>
		/// <para>未选中 - 多个邻近要素将被写入输出表（可在最接近匹配项的最大数量参数中指定上限）。</para>
		/// <para><see cref="ClosestEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Closest { get; set; } = "true";

		/// <summary>
		/// <para>Maximum number of closest matches</para>
		/// <para>限制对于每个输入要素报告的邻近要素的数量。 如果选中仅查找最近的要素，则此参数不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object ClosestCount { get; set; } = "0";

		/// <summary>
		/// <para>Method</para>
		/// <para>指定是使用椭球体上的最短路径（测地线）还是使用地平（平面）。 强烈建议将测地线方法和存储于不适用进行距离测量的坐标系（例如 Web 墨卡托和任何地理坐标系）中的数据，或任何覆盖较大地理区域的数据集结合使用。</para>
		/// <para>平面—在要素之间使用平面距离。 这是默认设置。</para>
		/// <para>测地线—在要素之间使用测地线距离。 这种方法考虑到椭球体的曲率，并可以正确处理日期变更线和两极附近的数据。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateNearTable SetEnviroment(object extent = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Location</para>
		/// </summary>
		public enum LocationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("LOCATION")]
			LOCATION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_LOCATION")]
			NO_LOCATION,

		}

		/// <summary>
		/// <para>Angle</para>
		/// </summary>
		public enum AngleEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ANGLE")]
			ANGLE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ANGLE")]
			NO_ANGLE,

		}

		/// <summary>
		/// <para>Find only closest feature</para>
		/// </summary>
		public enum ClosestEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CLOSEST")]
			CLOSEST,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL")]
			ALL,

		}

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>平面—在要素之间使用平面距离。 这是默认设置。</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("平面")]
			Planar,

			/// <summary>
			/// <para>测地线—在要素之间使用测地线距离。 这种方法考虑到椭球体的曲率，并可以正确处理日期变更线和两极附近的数据。</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("测地线")]
			Geodesic,

		}

#endregion
	}
}
