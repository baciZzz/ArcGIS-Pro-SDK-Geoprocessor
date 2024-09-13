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
	/// <para>Generate Obstacle Features</para>
	/// <para>生成障碍物要素</para>
	/// <para>将具有高度字段的要素转换为 3D 障碍物要素和障碍物限制缓冲区，以用于评估直升机降落区。</para>
	/// </summary>
	public class GenerateObstacleFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>用于创建障碍物要素的输入源要素。</para>
		/// </param>
		/// <param name="HeightField">
		/// <para>Height Field</para>
		/// <para>包含高度值的输入要素中的字段。 字段类型可以是数字或文本。 如果使用文本字段，则字段值必须为数字。</para>
		/// </param>
		/// <param name="OutObstacleFeatures">
		/// <para>Output Obstacle Features</para>
		/// <para>输出 3D 障碍物要素。</para>
		/// </param>
		/// <param name="OutObstacleBuffers">
		/// <para>Output Obstacle Buffers</para>
		/// <para>输出障碍物缓冲区要素</para>
		/// </param>
		public GenerateObstacleFeatures(object InFeatures, object HeightField, object OutObstacleFeatures, object OutObstacleBuffers)
		{
			this.InFeatures = InFeatures;
			this.HeightField = HeightField;
			this.OutObstacleFeatures = OutObstacleFeatures;
			this.OutObstacleBuffers = OutObstacleBuffers;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成障碍物要素</para>
		/// </summary>
		public override string DisplayName() => "生成障碍物要素";

		/// <summary>
		/// <para>Tool Name : GenerateObstacleFeatures</para>
		/// </summary>
		public override string ToolName() => "GenerateObstacleFeatures";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.GenerateObstacleFeatures</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.GenerateObstacleFeatures";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, HeightField, OutObstacleFeatures, OutObstacleBuffers, ClipFeatures! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>用于创建障碍物要素的输入源要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Height Field</para>
		/// <para>包含高度值的输入要素中的字段。 字段类型可以是数字或文本。 如果使用文本字段，则字段值必须为数字。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Double", "Text")]
		public object HeightField { get; set; }

		/// <summary>
		/// <para>Output Obstacle Features</para>
		/// <para>输出 3D 障碍物要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutObstacleFeatures { get; set; }

		/// <summary>
		/// <para>Output Obstacle Buffers</para>
		/// <para>输出障碍物缓冲区要素</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutObstacleBuffers { get; set; }

		/// <summary>
		/// <para>Clip Features</para>
		/// <para>用于裁剪输出障碍物要素的区域。 将仅处理位于裁剪要素范围内的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object? ClipFeatures { get; set; }

	}
}
