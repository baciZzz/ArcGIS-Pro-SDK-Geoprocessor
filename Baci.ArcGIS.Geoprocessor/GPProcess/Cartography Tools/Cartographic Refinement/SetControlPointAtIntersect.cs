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
	/// <para>Set Control Point At Intersect</para>
	/// <para>在相交处设置控制点</para>
	/// <para>此工具可在由一个或多个线要素或面要素共用的折点处创建控制点。 此工具通常用于同步相邻面上的边界符号系统。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class SetControlPointAtIntersect : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLineOrPolygonFeatures">
		/// <para>Input Features</para>
		/// <para>线或面要素图层。</para>
		/// </param>
		public SetControlPointAtIntersect(object InLineOrPolygonFeatures)
		{
			this.InLineOrPolygonFeatures = InLineOrPolygonFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 在相交处设置控制点</para>
		/// </summary>
		public override string DisplayName() => "在相交处设置控制点";

		/// <summary>
		/// <para>Tool Name : SetControlPointAtIntersect</para>
		/// </summary>
		public override string ToolName() => "SetControlPointAtIntersect";

		/// <summary>
		/// <para>Tool Excute Name : cartography.SetControlPointAtIntersect</para>
		/// </summary>
		public override string ExcuteName() => "cartography.SetControlPointAtIntersect";

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
		public override string[] ValidEnvironments() => new string[] { "cartographicPartitions" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLineOrPolygonFeatures, InFeatures!, OutRepresentations! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>线或面要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		public object InLineOrPolygonFeatures { get; set; }

		/// <summary>
		/// <para>Input Secondary Features</para>
		/// <para>具有与输入要素重叠的要素的线或面要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object? InFeatures { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutRepresentations { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetControlPointAtIntersect SetEnviroment(object? cartographicPartitions = null)
		{
			base.SetEnv(cartographicPartitions: cartographicPartitions);
			return this;
		}

	}
}
