using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CartographyTools
{
	/// <summary>
	/// <para>Calculate Central Meridian And Parallels</para>
	/// <para>计算中央经线和纬线</para>
	/// <para>基于要素范围的中心点计算中央经线和标准纬线（可选）；将此坐标系作为空间参考字符串存储到指定的文本字段中，并对要素集或要素子集重复此操作。此字段可与空间地图系列结合使用，以更新每个页面的数据框坐标系。</para>
	/// </summary>
	public class CalculateCentralMeridianAndParallels : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入要素图层。</para>
		/// </param>
		/// <param name="InField">
		/// <para>Coordinate System Field</para>
		/// <para>系统将存储坐标系字符串所在的文本字段。</para>
		/// </param>
		public CalculateCentralMeridianAndParallels(object InFeatures, object InField)
		{
			this.InFeatures = InFeatures;
			this.InField = InField;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算中央经线和纬线</para>
		/// </summary>
		public override string DisplayName() => "计算中央经线和纬线";

		/// <summary>
		/// <para>Tool Name : CalculateCentralMeridianAndParallels</para>
		/// </summary>
		public override string ToolName() => "CalculateCentralMeridianAndParallels";

		/// <summary>
		/// <para>Tool Excute Name : cartography.CalculateCentralMeridianAndParallels</para>
		/// </summary>
		public override string ExcuteName() => "cartography.CalculateCentralMeridianAndParallels";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise() => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, InField, StandardOffset, OutFeatures };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Coordinate System Field</para>
		/// <para>系统将存储坐标系字符串所在的文本字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object InField { get; set; }

		/// <summary>
		/// <para>Standard Parallel Offset</para>
		/// <para>输入要素的高度百分比，用于计算标准纬线偏离输入要素中心纬度的量。默认值为 25% 或 0.25。可接受的输入为负值和大于 1 的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object StandardOffset { get; set; } = "0.25";

		/// <summary>
		/// <para>Output Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateCentralMeridianAndParallels SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
