using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.EditingTools
{
	/// <summary>
	/// <para>Snap</para>
	/// <para>捕捉</para>
	/// <para>移动点或折点，使其与其他要素的折点、边或端点精确重合。 可指定捕捉规则来控制是将输入折点捕捉到指定距离范围内的最近折点、边还是端点。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class Snap : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>折点将被捕捉到其他要素的折点、边或端点的输入要素。 输入要素可以是点、多点、线或面。</para>
		/// </param>
		/// <param name="SnapEnvironment">
		/// <para>Snap Environment</para>
		/// <para>输入包含要捕捉到的要素的要素类或要素图层。</para>
		/// <para>捕捉环境的组件如下：</para>
		/// <para>要素 - 要作为输入要素折点捕捉目标的要素。 这些要素可以是点、多点、线或面。</para>
		/// <para>类型 - 可作为输入要素折点捕捉目标的要素部分的类型。</para>
		/// <para>距离 - 输入要素折点被捕捉到此距离范围内的最近端点、折点或边。</para>
		/// <para>可用捕捉类型如下：</para>
		/// <para>端点 - 将输入要素折点捕捉到要素末端。</para>
		/// <para>折点 - 将输入要素折点捕捉到要素折点。</para>
		/// <para>边 - 将输入要素折点捕捉到要素边。</para>
		/// <para>如果所用距离未带单位（如，输入 10 而不是 10 米），则默认情况下将使用输入要素的坐标系的线性单位或角度单位。 如果输入要素使用投影坐标系，则将使用线性单位。</para>
		/// </param>
		public Snap(object InFeatures, object SnapEnvironment)
		{
			this.InFeatures = InFeatures;
			this.SnapEnvironment = SnapEnvironment;
		}

		/// <summary>
		/// <para>Tool Display Name : 捕捉</para>
		/// </summary>
		public override string DisplayName() => "捕捉";

		/// <summary>
		/// <para>Tool Name : 捕捉</para>
		/// </summary>
		public override string ToolName() => "捕捉";

		/// <summary>
		/// <para>Tool Excute Name : edit.Snap</para>
		/// </summary>
		public override string ExcuteName() => "edit.Snap";

		/// <summary>
		/// <para>Toolbox Display Name : Editing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Editing Tools";

		/// <summary>
		/// <para>Toolbox Alise : edit</para>
		/// </summary>
		public override string ToolboxAlise() => "edit";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, SnapEnvironment, OutFeatureClass };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>折点将被捕捉到其他要素的折点、边或端点的输入要素。 输入要素可以是点、多点、线或面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Snap Environment</para>
		/// <para>输入包含要捕捉到的要素的要素类或要素图层。</para>
		/// <para>捕捉环境的组件如下：</para>
		/// <para>要素 - 要作为输入要素折点捕捉目标的要素。 这些要素可以是点、多点、线或面。</para>
		/// <para>类型 - 可作为输入要素折点捕捉目标的要素部分的类型。</para>
		/// <para>距离 - 输入要素折点被捕捉到此距离范围内的最近端点、折点或边。</para>
		/// <para>可用捕捉类型如下：</para>
		/// <para>端点 - 将输入要素折点捕捉到要素末端。</para>
		/// <para>折点 - 将输入要素折点捕捉到要素折点。</para>
		/// <para>边 - 将输入要素折点捕捉到要素边。</para>
		/// <para>如果所用距离未带单位（如，输入 10 而不是 10 米），则默认情况下将使用输入要素的坐标系的线性单位或角度单位。 如果输入要素使用投影坐标系，则将使用线性单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object SnapEnvironment { get; set; }

		/// <summary>
		/// <para>Snapped Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Snap SetEnviroment(object extent = null , object workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

	}
}
