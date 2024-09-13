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
	/// <para>Add Feature Class To Topology</para>
	/// <para>向拓扑中添加要素类</para>
	/// <para>向拓扑中添加要素类。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddFeatureClassToTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTopology">
		/// <para>Input Topology</para>
		/// <para>要素类将参与的拓扑。</para>
		/// </param>
		/// <param name="InFeatureclass">
		/// <para>Input Feature class</para>
		/// <para>要向拓扑中添加的要素类。该要素类必须与拓扑处于同一要素数据集。</para>
		/// </param>
		/// <param name="XyRank">
		/// <para>XY Rank</para>
		/// <para>此要素类中的要素折点的关联位置精度与参与拓扑的其他要素类中要素折点的关联位置精度之间的相对等级。精度最高的要素类的等级应高于（数字较小，如 1）精度较低的要素类。</para>
		/// </param>
		/// <param name="ZRank">
		/// <para>Z Rank</para>
		/// <para>含 z 值的要素类已将每个折点的高程值嵌入几何。通过设置 z 等级，可影响使用所含 z 测量值精度较低的折点捕捉或聚类含精确 z 值的折点的方式。</para>
		/// </param>
		public AddFeatureClassToTopology(object InTopology, object InFeatureclass, object XyRank, object ZRank)
		{
			this.InTopology = InTopology;
			this.InFeatureclass = InFeatureclass;
			this.XyRank = XyRank;
			this.ZRank = ZRank;
		}

		/// <summary>
		/// <para>Tool Display Name : 向拓扑中添加要素类</para>
		/// </summary>
		public override string DisplayName() => "向拓扑中添加要素类";

		/// <summary>
		/// <para>Tool Name : AddFeatureClassToTopology</para>
		/// </summary>
		public override string ToolName() => "AddFeatureClassToTopology";

		/// <summary>
		/// <para>Tool Excute Name : management.AddFeatureClassToTopology</para>
		/// </summary>
		public override string ExcuteName() => "management.AddFeatureClassToTopology";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTopology, InFeatureclass, XyRank, ZRank, OutTopology! };

		/// <summary>
		/// <para>Input Topology</para>
		/// <para>要素类将参与的拓扑。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTopologyLayer()]
		public object InTopology { get; set; }

		/// <summary>
		/// <para>Input Feature class</para>
		/// <para>要向拓扑中添加的要素类。该要素类必须与拓扑处于同一要素数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatureclass { get; set; }

		/// <summary>
		/// <para>XY Rank</para>
		/// <para>此要素类中的要素折点的关联位置精度与参与拓扑的其他要素类中要素折点的关联位置精度之间的相对等级。精度最高的要素类的等级应高于（数字较小，如 1）精度较低的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object XyRank { get; set; } = "1";

		/// <summary>
		/// <para>Z Rank</para>
		/// <para>含 z 值的要素类已将每个折点的高程值嵌入几何。通过设置 z 等级，可影响使用所含 z 测量值精度较低的折点捕捉或聚类含精确 z 值的折点的方式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object ZRank { get; set; } = "1";

		/// <summary>
		/// <para>Updated Input Topology</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTopologyLayer()]
		public object? OutTopology { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddFeatureClassToTopology SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
