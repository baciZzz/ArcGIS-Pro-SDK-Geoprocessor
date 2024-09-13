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
	/// <para>Add Z Information</para>
	/// <para>添加 Z 信息</para>
	/// <para>添加关于具有 Z 值的要素类中的要素的高程属性的信息。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddZInformation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>Input Features</para>
		/// <para>待处理的输入要素。</para>
		/// </param>
		/// <param name="OutProperty">
		/// <para>Output Property</para>
		/// <para>将添加到输入要素类属性表中的 Z 属性。可用选项如下：</para>
		/// <para>Spot Z—单点要素的高程点。</para>
		/// <para>点计数—每个多点要素中的点数。</para>
		/// <para>最低 Z 值—每个多点、折线、面或多面体要素中找到的最低 Z 值。</para>
		/// <para>最高 Z 值—每个多点、折线、面或多面体要素中找到的最高 Z 值。</para>
		/// <para>Z 平均值—每个多点、折线、面或多面体要素中找到的平均 Z 值。</para>
		/// <para>三维长度—每个折线或面要素的三维长度。</para>
		/// <para>表面面积—多面体要素表面的总面积。</para>
		/// <para>折点数—每个折线或面要素的折点总数。</para>
		/// <para>最低坡度—针对每个折线、面或多面体要素计算的最低坡度值。</para>
		/// <para>最高坡度—针对每个折线、面或多面体要素计算的最高坡度值。</para>
		/// <para>平均坡度—针对每个折线、面或多面体要素计算的平均坡度值。</para>
		/// <para>体积—由每个多面体要素闭合起来的空间的体积。</para>
		/// </param>
		public AddZInformation(object InFeatureClass, object OutProperty)
		{
			this.InFeatureClass = InFeatureClass;
			this.OutProperty = OutProperty;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加 Z 信息</para>
		/// </summary>
		public override string DisplayName() => "添加 Z 信息";

		/// <summary>
		/// <para>Tool Name : AddZInformation</para>
		/// </summary>
		public override string ToolName() => "AddZInformation";

		/// <summary>
		/// <para>Tool Excute Name : 3d.AddZInformation</para>
		/// </summary>
		public override string ExcuteName() => "3d.AddZInformation";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureClass, OutProperty, NoiseFiltering, OutputFeatureClass };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>待处理的输入要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon", "Point", "Multipoint", "MultiPatch")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Property</para>
		/// <para>将添加到输入要素类属性表中的 Z 属性。可用选项如下：</para>
		/// <para>Spot Z—单点要素的高程点。</para>
		/// <para>点计数—每个多点要素中的点数。</para>
		/// <para>最低 Z 值—每个多点、折线、面或多面体要素中找到的最低 Z 值。</para>
		/// <para>最高 Z 值—每个多点、折线、面或多面体要素中找到的最高 Z 值。</para>
		/// <para>Z 平均值—每个多点、折线、面或多面体要素中找到的平均 Z 值。</para>
		/// <para>三维长度—每个折线或面要素的三维长度。</para>
		/// <para>表面面积—多面体要素表面的总面积。</para>
		/// <para>折点数—每个折线或面要素的折点总数。</para>
		/// <para>最低坡度—针对每个折线、面或多面体要素计算的最低坡度值。</para>
		/// <para>最高坡度—针对每个折线、面或多面体要素计算的最高坡度值。</para>
		/// <para>平均坡度—针对每个折线、面或多面体要素计算的平均坡度值。</para>
		/// <para>体积—由每个多面体要素闭合起来的空间的体积。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object OutProperty { get; set; }

		/// <summary>
		/// <para>Noise Filtering</para>
		/// <para>一个用于从生成的计算中排除部分要素的可选数值。当 3D 输入包含相对较小的要素（具有极端坡度值，可能会使统计结果产生偏差）时，这将十分有用。如果 3D 输入的线性单位为米时，指定值 0.001 将导致排除长度小于 0.001 米的线或面边。对于多面体要素，相同值将导致排除其面积小于 0.001 平方米的子部分。此参数不适用于点和多点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object NoiseFiltering { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddZInformation SetEnviroment(int? autoCommit = null , object extent = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, extent: extent, workspace: workspace);
			return this;
		}

	}
}
