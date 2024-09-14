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
	/// <para>Append Terrain Points</para>
	/// <para>追加 Terrain 点</para>
	/// <para>向 terrain 数据集引用的点要素追加点。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AppendTerrainPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// <para>待处理的 terrain 数据集。</para>
		/// </param>
		/// <param name="TerrainFeatureClass">
		/// <para>Input Terrain Data Source</para>
		/// <para>要添加点或多点的 terrain 数据集的构成要素类。</para>
		/// </param>
		/// <param name="InPointFeatures">
		/// <para>Input Points</para>
		/// <para>要添加为 terrain 数据集的附加数据源的点或多点的要素类。</para>
		/// </param>
		public AppendTerrainPoints(object InTerrain, object TerrainFeatureClass, object InPointFeatures)
		{
			this.InTerrain = InTerrain;
			this.TerrainFeatureClass = TerrainFeatureClass;
			this.InPointFeatures = InPointFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 追加 Terrain 点</para>
		/// </summary>
		public override string DisplayName() => "追加 Terrain 点";

		/// <summary>
		/// <para>Tool Name : AppendTerrainPoints</para>
		/// </summary>
		public override string ToolName() => "AppendTerrainPoints";

		/// <summary>
		/// <para>Tool Excute Name : 3d.AppendTerrainPoints</para>
		/// </summary>
		public override string ExcuteName() => "3d.AppendTerrainPoints";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTerrain, TerrainFeatureClass, InPointFeatures, PolygonFeaturesOrExtent!, DerivedOutTerrain! };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>待处理的 terrain 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Input Terrain Data Source</para>
		/// <para>要添加点或多点的 terrain 数据集的构成要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TerrainFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Points</para>
		/// <para>要添加为 terrain 数据集的附加数据源的点或多点的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>指定用于定义要添加点要素的区域的面要素类或范围值。默认情况下此参数为空，这样输入要素类的所有点都将被加载到 terrain 要素中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? PolygonFeaturesOrExtent { get; set; }

		/// <summary>
		/// <para>Updated Input Terrain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTerrainLayer()]
		public object? DerivedOutTerrain { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AppendTerrainPoints SetEnviroment(int? autoCommit = null, object? extent = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
