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
	/// <para>Build Terrain</para>
	/// <para>构建 Terrain</para>
	/// <para>执行分析和显示 terrain 数据集时所需的任务。</para>
	/// </summary>
	public class BuildTerrain : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// <para>待处理的 terrain 数据集。</para>
		/// </param>
		public BuildTerrain(object InTerrain)
		{
			this.InTerrain = InTerrain;
		}

		/// <summary>
		/// <para>Tool Display Name : 构建 Terrain</para>
		/// </summary>
		public override string DisplayName() => "构建 Terrain";

		/// <summary>
		/// <para>Tool Name : BuildTerrain</para>
		/// </summary>
		public override string ToolName() => "BuildTerrain";

		/// <summary>
		/// <para>Tool Excute Name : 3d.BuildTerrain</para>
		/// </summary>
		public override string ExcuteName() => "3d.BuildTerrain";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTerrain, UpdateExtent, DerivedOutTerrain };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>待处理的 terrain 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Update Extent</para>
		/// <para>当数据区域在编辑过程中变小时，将重新计算基于窗口大小的 terrain 数据集的数据范围。如果数据范围增加，或者 terrain 数据集是基于 z 容差的，则无需使用此命令。它会扫描所有 terrain 数据以确定新范围。</para>
		/// <para>保持范围— 将不会重新计算 terrain 数据集的范围。这是默认设置。</para>
		/// <para>更新范围— 将会重新计算 terrain 数据集的范围。</para>
		/// <para><see cref="UpdateExtentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object UpdateExtent { get; set; } = "NO_UPDATE_EXTENT";

		/// <summary>
		/// <para>Updated Input Terrain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTerrainLayer()]
		public object DerivedOutTerrain { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BuildTerrain SetEnviroment(int? autoCommit = null , object extent = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Update Extent</para>
		/// </summary>
		public enum UpdateExtentEnum 
		{
			/// <summary>
			/// <para>保持范围— 将不会重新计算 terrain 数据集的范围。这是默认设置。</para>
			/// </summary>
			[GPValue("NO_UPDATE_EXTENT")]
			[Description("保持范围")]
			Maintain_Extent,

			/// <summary>
			/// <para>更新范围— 将会重新计算 terrain 数据集的范围。</para>
			/// </summary>
			[GPValue("UPDATE_EXTENT")]
			[Description("更新范围")]
			Update_Extent,

		}

#endregion
	}
}
