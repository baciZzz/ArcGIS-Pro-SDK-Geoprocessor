using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Dice</para>
	/// <para>切分</para>
	/// <para>根据指定的折点限制将要素细分为较小的要素。此工具旨在细分那些容易在绘制、分析、编辑和/或性能等方面产生问题且难以利用标准编辑工具和地理处理工具进行分割的超大型要素。除了其他工具因要素的大小问题而无法顺利完成细分的情况之外，此工具不能用于其他任何情况。</para>
	/// </summary>
	public class Dice : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入要素类或要素图层。几何类型必须为多点、线或面。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>切分要素的输出要素类。</para>
		/// </param>
		/// <param name="VertexLimit">
		/// <para>Vertex Limit</para>
		/// <para>几何超出此折点限制的要素将在写入输出要素类之前被细分。</para>
		/// </param>
		public Dice(object InFeatures, object OutFeatureClass, object VertexLimit)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.VertexLimit = VertexLimit;
		}

		/// <summary>
		/// <para>Tool Display Name : 切分</para>
		/// </summary>
		public override string DisplayName() => "切分";

		/// <summary>
		/// <para>Tool Name : 切分</para>
		/// </summary>
		public override string ToolName() => "切分";

		/// <summary>
		/// <para>Tool Excute Name : management.Dice</para>
		/// </summary>
		public override string ExcuteName() => "management.Dice";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "configKeyword", "qualifiedFieldNames" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, VertexLimit };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入要素类或要素图层。几何类型必须为多点、线或面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline", "Multipoint")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>切分要素的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Vertex Limit</para>
		/// <para>几何超出此折点限制的要素将在写入输出要素类之前被细分。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object VertexLimit { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Dice SetEnviroment(int? autoCommit = null , object? configKeyword = null , bool? qualifiedFieldNames = null )
		{
			base.SetEnv(autoCommit: autoCommit, configKeyword: configKeyword, qualifiedFieldNames: qualifiedFieldNames);
			return this;
		}

	}
}
