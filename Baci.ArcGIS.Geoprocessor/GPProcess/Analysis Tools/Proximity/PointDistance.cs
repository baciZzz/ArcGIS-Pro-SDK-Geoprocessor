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
	/// <para>Point Distance</para>
	/// <para>点距离</para>
	/// <para>在某一指定搜索半径范围内，确定输入点要素与邻近要素中所有点之间的距离。</para>
	/// </summary>
	[Obsolete()]
	public class PointDistance : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>计算点要素与邻近要素之间的距离时作为起点的点要素。</para>
		/// </param>
		/// <param name="NearFeatures">
		/// <para>Near Features</para>
		/// <para>计算输入要素与点之间的距离时作为终点的点。 可通过为输入要素和邻近要素指定同一要素类或图层来确定同一要素类或图层范围内各点之间的距离。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>包含输入要素列表和搜索半径内所有邻近要素相关信息的表。 如果未指定搜索半径，则计算所有输入要素与所有邻近要素之间的距离。</para>
		/// </param>
		public PointDistance(object InFeatures, object NearFeatures, object OutTable)
		{
			this.InFeatures = InFeatures;
			this.NearFeatures = NearFeatures;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 点距离</para>
		/// </summary>
		public override string DisplayName() => "点距离";

		/// <summary>
		/// <para>Tool Name : PointDistance</para>
		/// </summary>
		public override string ToolName() => "PointDistance";

		/// <summary>
		/// <para>Tool Excute Name : analysis.PointDistance</para>
		/// </summary>
		public override string ExcuteName() => "analysis.PointDistance";

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
		public override object[] Parameters() => new object[] { InFeatures, NearFeatures, OutTable, SearchRadius! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>计算点要素与邻近要素之间的距离时作为起点的点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Multipoint", "Point")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Near Features</para>
		/// <para>计算输入要素与点之间的距离时作为终点的点。 可通过为输入要素和邻近要素指定同一要素类或图层来确定同一要素类或图层范围内各点之间的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Multipoint", "Point")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object NearFeatures { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>包含输入要素列表和搜索半径内所有邻近要素相关信息的表。 如果未指定搜索半径，则计算所有输入要素与所有邻近要素之间的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>指定用于搜索候选邻近要素的半径。 将考虑此半径中的邻近要素来计算最近的要素。 如果未指定值（即使用默认（空）半径），则在计算中考虑所有邻近要素。 搜索半径的单位默认为输入要素的单位。 可以将单位更改为任何其他单位。 但是，这对输出 DISTANCE 字段的单位不会产生任何影响，后者基于输入要素的坐标系单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SearchRadius { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PointDistance SetEnviroment(object? extent = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
