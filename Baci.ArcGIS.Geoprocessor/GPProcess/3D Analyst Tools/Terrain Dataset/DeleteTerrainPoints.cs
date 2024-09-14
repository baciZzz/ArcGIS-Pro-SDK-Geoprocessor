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
	/// <para>Delete Terrain Points</para>
	/// <para>删除 Terrain 点</para>
	/// <para>从参与 terrain 数据集的一个或多个要素中删除指定的感兴趣区域内的点。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class DeleteTerrainPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// <para>待处理的 terrain 数据集。</para>
		/// </param>
		/// <param name="DataSource">
		/// <para>Input Terrain Data Source</para>
		/// <para>点将被移除的一个或多个要素类。</para>
		/// </param>
		/// <param name="PolygonFeaturesOrExtent">
		/// <para>Area of Interest</para>
		/// <para>指定要从中移除点的区域。可使用面要素类或范围。</para>
		/// </param>
		public DeleteTerrainPoints(object InTerrain, object DataSource, object PolygonFeaturesOrExtent)
		{
			this.InTerrain = InTerrain;
			this.DataSource = DataSource;
			this.PolygonFeaturesOrExtent = PolygonFeaturesOrExtent;
		}

		/// <summary>
		/// <para>Tool Display Name : 删除 Terrain 点</para>
		/// </summary>
		public override string DisplayName() => "删除 Terrain 点";

		/// <summary>
		/// <para>Tool Name : DeleteTerrainPoints</para>
		/// </summary>
		public override string ToolName() => "DeleteTerrainPoints";

		/// <summary>
		/// <para>Tool Excute Name : 3d.DeleteTerrainPoints</para>
		/// </summary>
		public override string ExcuteName() => "3d.DeleteTerrainPoints";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTerrain, DataSource, PolygonFeaturesOrExtent, DerivedOutTerrain! };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>待处理的 terrain 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Input Terrain Data Source</para>
		/// <para>点将被移除的一个或多个要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object DataSource { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>指定要从中移除点的区域。可使用面要素类或范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object PolygonFeaturesOrExtent { get; set; }

		/// <summary>
		/// <para>Updated Input Terrain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTerrainLayer()]
		public object? DerivedOutTerrain { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeleteTerrainPoints SetEnviroment(int? autoCommit = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
