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
	/// <para>Calculate UTM Zone</para>
	/// <para>计算 UTM 带</para>
	/// <para>根据中心点计算每个要素的 UTM 带，并在指定字段中存储该空间参考字符串。该字段可与空间地图系列结合使用，以将空间参考更新为每个地图的正确 UTM 带。</para>
	/// </summary>
	public class CalculateUTMZone : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入要素图层。</para>
		/// </param>
		/// <param name="InField">
		/// <para>UTM Zone Field</para>
		/// <para>用于存储坐标系的空间参考字符串的字符串字段。字段应具有足够的长度（大于 600 个字符）来保存空间参考字符串。</para>
		/// </param>
		public CalculateUTMZone(object InFeatures, object InField)
		{
			this.InFeatures = InFeatures;
			this.InField = InField;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算 UTM 带</para>
		/// </summary>
		public override string DisplayName() => "计算 UTM 带";

		/// <summary>
		/// <para>Tool Name : CalculateUTMZone</para>
		/// </summary>
		public override string ToolName() => "CalculateUTMZone";

		/// <summary>
		/// <para>Tool Excute Name : cartography.CalculateUTMZone</para>
		/// </summary>
		public override string ExcuteName() => "cartography.CalculateUTMZone";

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
		public override object[] Parameters() => new object[] { InFeatures, InField, OutFeatures! };

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
		/// <para>UTM Zone Field</para>
		/// <para>用于存储坐标系的空间参考字符串的字符串字段。字段应具有足够的长度（大于 600 个字符）来保存空间参考字符串。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object InField { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateUTMZone SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
