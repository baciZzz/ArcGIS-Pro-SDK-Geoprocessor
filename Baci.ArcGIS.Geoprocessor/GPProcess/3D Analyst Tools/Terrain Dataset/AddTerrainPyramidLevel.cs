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
	/// <para>Add Terrain Pyramid Level</para>
	/// <para>添加 Terrain 金字塔等级</para>
	/// <para>向现有 terrain 数据集添加一个或多个金字塔等级。</para>
	/// </summary>
	public class AddTerrainPyramidLevel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// <para>待处理的 terrain 数据集。</para>
		/// </param>
		/// <param name="PyramidLevelDefinition">
		/// <para>Pyramid Levels Definition</para>
		/// <para>将要添加到 terrain 中的各个金字塔等级的 z 容差或窗口大小以及关联的参考比例。输入的每个金字塔等级包括一对金字塔等级分辨率和参考比例，并以空格分隔（例如，“20 24000”表示窗口大小为 20，参考比例为 1:24000，或者“1.5 10000”表示 z 容差为 1.5，参考比例为 1:10000）。金字塔等级分辨率可以浮点值形式提供，而参考比例必须以整数形式输入。</para>
		/// <para>z 容差值表示处于全分辨率下时可能出现的距 terrain 高程的最大偏差；而窗口大小值定义稀疏化高程点所用的 terrain 分块区域，稀疏化高程点即基于创建 terrain 过程中定义的窗口大小方法从分块区域选择一个或两个点。参考比例表示强制显示金字塔等级所使用的最大地图比例。以大于此值的比例显示 terrain 时，将显示下一个最高的金字塔等级。</para>
		/// </param>
		public AddTerrainPyramidLevel(object InTerrain, object PyramidLevelDefinition)
		{
			this.InTerrain = InTerrain;
			this.PyramidLevelDefinition = PyramidLevelDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加 Terrain 金字塔等级</para>
		/// </summary>
		public override string DisplayName() => "添加 Terrain 金字塔等级";

		/// <summary>
		/// <para>Tool Name : AddTerrainPyramidLevel</para>
		/// </summary>
		public override string ToolName() => "AddTerrainPyramidLevel";

		/// <summary>
		/// <para>Tool Excute Name : 3d.AddTerrainPyramidLevel</para>
		/// </summary>
		public override string ExcuteName() => "3d.AddTerrainPyramidLevel";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTerrain, PyramidType!, PyramidLevelDefinition, DerivedOutTerrain! };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>待处理的 terrain 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Pyramid Type</para>
		/// <para>terrain 数据集使用的金字塔类型。ArcGIS 9.3 及更高版本中不使用此参数，因为此参数的用途是确保向后兼容使用 ArcGIS 9.2 编写的脚本和模型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? PyramidType { get; set; }

		/// <summary>
		/// <para>Pyramid Levels Definition</para>
		/// <para>将要添加到 terrain 中的各个金字塔等级的 z 容差或窗口大小以及关联的参考比例。输入的每个金字塔等级包括一对金字塔等级分辨率和参考比例，并以空格分隔（例如，“20 24000”表示窗口大小为 20，参考比例为 1:24000，或者“1.5 10000”表示 z 容差为 1.5，参考比例为 1:10000）。金字塔等级分辨率可以浮点值形式提供，而参考比例必须以整数形式输入。</para>
		/// <para>z 容差值表示处于全分辨率下时可能出现的距 terrain 高程的最大偏差；而窗口大小值定义稀疏化高程点所用的 terrain 分块区域，稀疏化高程点即基于创建 terrain 过程中定义的窗口大小方法从分块区域选择一个或两个点。参考比例表示强制显示金字塔等级所使用的最大地图比例。以大于此值的比例显示 terrain 时，将显示下一个最高的金字塔等级。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object PyramidLevelDefinition { get; set; }

		/// <summary>
		/// <para>Updated Input Terrain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTerrainLayer()]
		public object? DerivedOutTerrain { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddTerrainPyramidLevel SetEnviroment(int? autoCommit = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

	}
}
