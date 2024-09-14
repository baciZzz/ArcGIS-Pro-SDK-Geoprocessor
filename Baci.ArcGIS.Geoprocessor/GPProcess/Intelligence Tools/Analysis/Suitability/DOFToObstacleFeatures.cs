using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>DOF To Obstacle Features</para>
	/// <para>DOF 至障碍物要素</para>
	/// <para>将美国联邦航空管理局 (FAA) 数字障碍文件 (DOF) 转换为障碍点和障碍物缓冲区要素。</para>
	/// </summary>
	public class DOFToObstacleFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>要转换为障碍物要素的输入 DOF 表。</para>
		/// </param>
		/// <param name="OutObstacleFeatures">
		/// <para>Output Obstacle Features</para>
		/// <para>使用输入表创建的点障碍物要素。</para>
		/// </param>
		/// <param name="OutObstacleBuffers">
		/// <para>Output Obstacle Buffers</para>
		/// <para>创建的距离缓冲区是输入表中 AGL 字段值的 10 倍。</para>
		/// </param>
		public DOFToObstacleFeatures(object InTable, object OutObstacleFeatures, object OutObstacleBuffers)
		{
			this.InTable = InTable;
			this.OutObstacleFeatures = OutObstacleFeatures;
			this.OutObstacleBuffers = OutObstacleBuffers;
		}

		/// <summary>
		/// <para>Tool Display Name : DOF 至障碍物要素</para>
		/// </summary>
		public override string DisplayName() => "DOF 至障碍物要素";

		/// <summary>
		/// <para>Tool Name : DOFToObstacleFeatures</para>
		/// </summary>
		public override string ToolName() => "DOFToObstacleFeatures";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.DOFToObstacleFeatures</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.DOFToObstacleFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise() => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, OutObstacleFeatures, OutObstacleBuffers, ClipFeatures };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>要转换为障碍物要素的输入 DOF 表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Obstacle Features</para>
		/// <para>使用输入表创建的点障碍物要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutObstacleFeatures { get; set; }

		/// <summary>
		/// <para>Output Obstacle Buffers</para>
		/// <para>创建的距离缓冲区是输入表中 AGL 字段值的 10 倍。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutObstacleBuffers { get; set; }

		/// <summary>
		/// <para>Clip Features</para>
		/// <para>要从输入表中裁剪的区域。 将仅创建和缓冲此区域内的障碍物。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object ClipFeatures { get; set; }

	}
}
