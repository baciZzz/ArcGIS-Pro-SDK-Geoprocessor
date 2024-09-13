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
	/// <para>Stack Profile</para>
	/// <para>重叠剖面</para>
	/// <para>创建表格和可选图表，用于说明一个或多个多面体、栅格、TIN 或 terrain 表面上的线要素的剖面。</para>
	/// </summary>
	public class StackProfile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLineFeatures">
		/// <para>Input Line Features</para>
		/// <para>将在表面输入上描绘剖面的线要素。</para>
		/// </param>
		/// <param name="ProfileTargets">
		/// <para>Profile Targets</para>
		/// <para>剖面的数据，可由多面体要素、栅格和三角化表面模型的任意组合组成。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>将存储与输入线相交的每个剖面目标的插值高度的输出表。</para>
		/// </param>
		public StackProfile(object InLineFeatures, object ProfileTargets, object OutTable)
		{
			this.InLineFeatures = InLineFeatures;
			this.ProfileTargets = ProfileTargets;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 重叠剖面</para>
		/// </summary>
		public override string DisplayName() => "重叠剖面";

		/// <summary>
		/// <para>Tool Name : StackProfile</para>
		/// </summary>
		public override string ToolName() => "StackProfile";

		/// <summary>
		/// <para>Tool Excute Name : 3d.StackProfile</para>
		/// </summary>
		public override string ExcuteName() => "3d.StackProfile";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLineFeatures, ProfileTargets, OutTable, OutGraph! };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>将在表面输入上描绘剖面的线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object InLineFeatures { get; set; }

		/// <summary>
		/// <para>Profile Targets</para>
		/// <para>剖面的数据，可由多面体要素、栅格和三角化表面模型的任意组合组成。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object ProfileTargets { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>将存储与输入线相交的每个剖面目标的插值高度的输出表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Output Graph Name</para>
		/// <para>Pro 中不支持输出图表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGraph()]
		public object? OutGraph { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public StackProfile SetEnviroment(object? extent = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

	}
}
