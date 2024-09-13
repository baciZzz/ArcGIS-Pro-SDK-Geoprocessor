using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.WorkflowManagerTools
{
	/// <summary>
	/// <para>Get Job AOI</para>
	/// <para>获取作业 AOI</para>
	/// <para>获取作业的感兴趣位置 (LOI) 作为要素图层。输出图层具有表示作业感兴趣区 (AOI) 的面或表示作业感兴趣点 (POI) 的点。</para>
	/// </summary>
	public class GetJobAOI : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputJobid">
		/// <para>Input Job ID</para>
		/// <para>要检索 AOI 的作业的 ID。</para>
		/// </param>
		/// <param name="AoiLayer">
		/// <para>AOI Layer</para>
		/// <para>检索到的感兴趣位置的图层名称。输出图层具有表示作业感兴趣区 (AOI) 的面或表示作业感兴趣点 (POI) 的点。</para>
		/// </param>
		public GetJobAOI(object InputJobid, object AoiLayer)
		{
			this.InputJobid = InputJobid;
			this.AoiLayer = AoiLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 获取作业 AOI</para>
		/// </summary>
		public override string DisplayName() => "获取作业 AOI";

		/// <summary>
		/// <para>Tool Name : GetJobAOI</para>
		/// </summary>
		public override string ToolName() => "GetJobAOI";

		/// <summary>
		/// <para>Tool Excute Name : wmx.GetJobAOI</para>
		/// </summary>
		public override string ExcuteName() => "wmx.GetJobAOI";

		/// <summary>
		/// <para>Toolbox Display Name : Workflow Manager Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Workflow Manager Tools";

		/// <summary>
		/// <para>Toolbox Alise : wmx</para>
		/// </summary>
		public override string ToolboxAlise() => "wmx";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputJobid, AoiLayer, InputDatabasepath! };

		/// <summary>
		/// <para>Input Job ID</para>
		/// <para>要检索 AOI 的作业的 ID。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InputJobid { get; set; }

		/// <summary>
		/// <para>AOI Layer</para>
		/// <para>检索到的感兴趣位置的图层名称。输出图层具有表示作业感兴趣区 (AOI) 的面或表示作业感兴趣点 (POI) 的点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object AoiLayer { get; set; }

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>输入作业的 Workflow Manager (Classic) 数据库连接文件。如果未指定连接文件，将使用项目中当前默认的 Workflow Manager (Classic) 数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object? InputDatabasepath { get; set; }

	}
}
