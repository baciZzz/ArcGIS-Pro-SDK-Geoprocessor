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
	/// <para>Terrain To TIN</para>
	/// <para>Terrain 转 TIN</para>
	/// <para>可将 terrain 数据集转换为不规则三角网 (TIN) 数据集。</para>
	/// </summary>
	public class TerrainToTin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// <para>待处理的 terrain 数据集。</para>
		/// </param>
		/// <param name="OutTin">
		/// <para>Output TIN</para>
		/// <para>将要生成的 TIN 数据集。</para>
		/// </param>
		public TerrainToTin(object InTerrain, object OutTin)
		{
			this.InTerrain = InTerrain;
			this.OutTin = OutTin;
		}

		/// <summary>
		/// <para>Tool Display Name : Terrain 转 TIN</para>
		/// </summary>
		public override string DisplayName() => "Terrain 转 TIN";

		/// <summary>
		/// <para>Tool Name : TerrainToTin</para>
		/// </summary>
		public override string ToolName() => "TerrainToTin";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TerrainToTin</para>
		/// </summary>
		public override string ExcuteName() => "3d.TerrainToTin";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "terrainMemoryUsage", "tinSaveVersion", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTerrain, OutTin, PyramidLevelResolution!, MaxNodes!, ClipToExtent! };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>待处理的 terrain 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Output TIN</para>
		/// <para>将要生成的 TIN 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETin()]
		public object OutTin { get; set; }

		/// <summary>
		/// <para>Pyramid Level Resolution</para>
		/// <para>将使用 terrain 金字塔等级的 z 容差或窗口大小分辨率。 默认值为 0，或全分辨率。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Maximum Number of Nodes</para>
		/// <para>输出 TIN 中允许的结点的最大数量。如果分析范围和金字塔等级会产生超出该大小的 TIN，则该工具将返回错误。默认值为 5 百万。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaxNodes { get; set; } = "5000000";

		/// <summary>
		/// <para>Clip to Extent</para>
		/// <para>指定是否根据分析范围裁剪生成的 TIN。仅当定义了分析范围并且分析范围小于输入 terrain 范围时，该选项才有效。</para>
		/// <para>选中 - 根据分析范围裁剪输出 TIN。这是默认设置。</para>
		/// <para>未选中 - 不根据分析范围裁剪输出 TIN。</para>
		/// <para><see cref="ClipToExtentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ClipToExtent { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TerrainToTin SetEnviroment(object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, bool? terrainMemoryUsage = null, object? tinSaveVersion = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, terrainMemoryUsage: terrainMemoryUsage, tinSaveVersion: tinSaveVersion, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Clip to Extent</para>
		/// </summary>
		public enum ClipToExtentEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CLIP")]
			CLIP,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CLIP")]
			NO_CLIP,

		}

#endregion
	}
}
