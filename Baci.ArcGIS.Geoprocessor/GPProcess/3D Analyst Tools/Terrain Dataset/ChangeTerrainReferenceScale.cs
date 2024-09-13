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
	/// <para>Change Terrain Reference Scale</para>
	/// <para>更改 Terrain 参考比例</para>
	/// <para>更改与 terrain 金字塔等级相关联的参考比例。</para>
	/// </summary>
	public class ChangeTerrainReferenceScale : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// <para>待处理的 terrain 数据集。</para>
		/// </param>
		/// <param name="OldRefscale">
		/// <para>Old Reference Scale</para>
		/// <para>现有金字塔等级的参考比例。</para>
		/// </param>
		/// <param name="NewRefscale">
		/// <para>New Reference Scale</para>
		/// <para>金字塔等级的新参考比例。</para>
		/// </param>
		public ChangeTerrainReferenceScale(object InTerrain, object OldRefscale, object NewRefscale)
		{
			this.InTerrain = InTerrain;
			this.OldRefscale = OldRefscale;
			this.NewRefscale = NewRefscale;
		}

		/// <summary>
		/// <para>Tool Display Name : 更改 Terrain 参考比例</para>
		/// </summary>
		public override string DisplayName() => "更改 Terrain 参考比例";

		/// <summary>
		/// <para>Tool Name : ChangeTerrainReferenceScale</para>
		/// </summary>
		public override string ToolName() => "ChangeTerrainReferenceScale";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ChangeTerrainReferenceScale</para>
		/// </summary>
		public override string ExcuteName() => "3d.ChangeTerrainReferenceScale";

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
		public override object[] Parameters() => new object[] { InTerrain, OldRefscale, NewRefscale, DerivedOutTerrain };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>待处理的 terrain 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Old Reference Scale</para>
		/// <para>现有金字塔等级的参考比例。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object OldRefscale { get; set; }

		/// <summary>
		/// <para>New Reference Scale</para>
		/// <para>金字塔等级的新参考比例。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NewRefscale { get; set; }

		/// <summary>
		/// <para>Updated Input Terrain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTerrainLayer()]
		public object DerivedOutTerrain { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ChangeTerrainReferenceScale SetEnviroment(int? autoCommit = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
