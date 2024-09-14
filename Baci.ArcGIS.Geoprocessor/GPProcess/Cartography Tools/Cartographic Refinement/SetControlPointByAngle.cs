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
	/// <para>Set Control Point By Angle</para>
	/// <para>按角度设置控制点</para>
	/// <para>在沿线或面轮廓且由线的方向变化而生成的角度小于或等于指定的最大角度的顶点处放置控制点。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class SetControlPointByAngle : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>包含线或面要素的要素图层。</para>
		/// </param>
		/// <param name="MaximumAngle">
		/// <para>Maximum Angle (decimal degrees)</para>
		/// <para>此角度用于确定是否将沿线或面轮廓的顶点设置为控制点。 角度值必须大于零且小于 180 十进制度。</para>
		/// </param>
		public SetControlPointByAngle(object InFeatures, object MaximumAngle)
		{
			this.InFeatures = InFeatures;
			this.MaximumAngle = MaximumAngle;
		}

		/// <summary>
		/// <para>Tool Display Name : 按角度设置控制点</para>
		/// </summary>
		public override string DisplayName() => "按角度设置控制点";

		/// <summary>
		/// <para>Tool Name : SetControlPointByAngle</para>
		/// </summary>
		public override string ToolName() => "SetControlPointByAngle";

		/// <summary>
		/// <para>Tool Excute Name : cartography.SetControlPointByAngle</para>
		/// </summary>
		public override string ExcuteName() => "cartography.SetControlPointByAngle";

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
		public override object[] Parameters() => new object[] { InFeatures, MaximumAngle, OutRepresentations! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>包含线或面要素的要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Maximum Angle (decimal degrees)</para>
		/// <para>此角度用于确定是否将沿线或面轮廓的顶点设置为控制点。 角度值必须大于零且小于 180 十进制度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object MaximumAngle { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLayer()]
		public object? OutRepresentations { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetControlPointByAngle SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
