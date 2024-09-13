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
	/// <para>Change Terrain Resolution Bounds</para>
	/// <para>更改 Terrain 分辨率界限</para>
	/// <para>更改要素类在给定 terrain 数据集中强制所处的金字塔等级。</para>
	/// </summary>
	public class ChangeTerrainResolutionBounds : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// <para>待处理的 terrain 数据集。</para>
		/// </param>
		/// <param name="FeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>金字塔等级分辨率将被修改的 terrain 引用的要素类。</para>
		/// </param>
		public ChangeTerrainResolutionBounds(object InTerrain, object FeatureClass)
		{
			this.InTerrain = InTerrain;
			this.FeatureClass = FeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 更改 Terrain 分辨率界限</para>
		/// </summary>
		public override string DisplayName() => "更改 Terrain 分辨率界限";

		/// <summary>
		/// <para>Tool Name : ChangeTerrainResolutionBounds</para>
		/// </summary>
		public override string ToolName() => "ChangeTerrainResolutionBounds";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ChangeTerrainResolutionBounds</para>
		/// </summary>
		public override string ExcuteName() => "3d.ChangeTerrainResolutionBounds";

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
		public override object[] Parameters() => new object[] { InTerrain, FeatureClass, LowerPyramidResolution, UpperPyramidResolution, Overview, DerivedOutTerrain };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>待处理的 terrain 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>金字塔等级分辨率将被修改的 terrain 引用的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FeatureClass { get; set; }

		/// <summary>
		/// <para>Lower Pyramid Resolution</para>
		/// <para>所选要素类的新金字塔等级分辨率下限。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object LowerPyramidResolution { get; set; }

		/// <summary>
		/// <para>Upper Pyramid Resolution</para>
		/// <para>所选要素类的新金字塔等级分辨率上限。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object UpperPyramidResolution { get; set; }

		/// <summary>
		/// <para>Contributes to Overview</para>
		/// <para>指定要素类是否参与 terrain 数据集的概视图。</para>
		/// <para>选中 - 在 terrain 数据集的概视图显示中强制显示要素类。这是默认设置。</para>
		/// <para>未选中 - 在 terrain 数据集的概视图显示中忽略要素类。</para>
		/// <para><see cref="OverviewEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Overview { get; set; } = "true";

		/// <summary>
		/// <para>Updated Input Terrain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTerrainLayer()]
		public object DerivedOutTerrain { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ChangeTerrainResolutionBounds SetEnviroment(int? autoCommit = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Contributes to Overview</para>
		/// </summary>
		public enum OverviewEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERVIEW")]
			OVERVIEW,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_OVERVIEW")]
			NO_OVERVIEW,

		}

#endregion
	}
}
