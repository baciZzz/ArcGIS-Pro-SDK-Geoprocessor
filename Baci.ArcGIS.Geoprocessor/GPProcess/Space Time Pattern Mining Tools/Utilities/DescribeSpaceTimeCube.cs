using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpaceTimePatternMiningTools
{
	/// <summary>
	/// <para>Describe Space Time Cube</para>
	/// <para>描述时空立方体</para>
	/// <para>汇总时空立方体的内容和特征。 该工具描述了时空立方体的时间和空间范围、时空立方体中的变量、对每个变量执行的分析以及每个变量可用的 2D 和 3D 显示主题。</para>
	/// </summary>
	public class DescribeSpaceTimeCube : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCube">
		/// <para>Input Space Time Cube</para>
		/// <para>要描述的时空立方体。 时空立方体具有 .nc 文件扩展名，是使用时空模式挖掘工具箱中的各种工具创建的。</para>
		/// </param>
		public DescribeSpaceTimeCube(object InCube)
		{
			this.InCube = InCube;
		}

		/// <summary>
		/// <para>Tool Display Name : 描述时空立方体</para>
		/// </summary>
		public override string DisplayName() => "描述时空立方体";

		/// <summary>
		/// <para>Tool Name : DescribeSpaceTimeCube</para>
		/// </summary>
		public override string ToolName() => "DescribeSpaceTimeCube";

		/// <summary>
		/// <para>Tool Excute Name : stpm.DescribeSpaceTimeCube</para>
		/// </summary>
		public override string ExcuteName() => "stpm.DescribeSpaceTimeCube";

		/// <summary>
		/// <para>Toolbox Display Name : Space Time Pattern Mining Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Space Time Pattern Mining Tools";

		/// <summary>
		/// <para>Toolbox Alise : stpm</para>
		/// </summary>
		public override string ToolboxAlise() => "stpm";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCube, OutCharacteristicsTable!, OutSpatialExtent! };

		/// <summary>
		/// <para>Input Space Time Cube</para>
		/// <para>要描述的时空立方体。 时空立方体具有 .nc 文件扩展名，是使用时空模式挖掘工具箱中的各种工具创建的。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object InCube { get; set; }

		/// <summary>
		/// <para>Output Characteristics Table</para>
		/// <para>包含有关输入时空立方体的汇总信息的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutCharacteristicsTable { get; set; }

		/// <summary>
		/// <para>Output Spatial Extent Features</para>
		/// <para>此要素类中包含一个表示输入时空立方体空间范围的矩形。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutSpatialExtent { get; set; }

	}
}
