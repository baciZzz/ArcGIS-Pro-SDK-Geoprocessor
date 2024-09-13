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
	/// <para>Define Projection</para>
	/// <para>定义投影</para>
	/// <para>覆盖与数据集一同存储的坐标系信息（地图投影和基准面）。此工具用于坐标系未知或定义错误的数据集。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class DefineProjection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset or Feature Class</para>
		/// <para>要定义投影的数据集或要素类。</para>
		/// </param>
		/// <param name="CoorSystem">
		/// <para>Coordinate System</para>
		/// <para>要应用于输入的坐标系。默认值将基于“输出坐标系”环境设置进行设定。</para>
		/// </param>
		public DefineProjection(object InDataset, object CoorSystem)
		{
			this.InDataset = InDataset;
			this.CoorSystem = CoorSystem;
		}

		/// <summary>
		/// <para>Tool Display Name : 定义投影</para>
		/// </summary>
		public override string DisplayName() => "定义投影";

		/// <summary>
		/// <para>Tool Name : DefineProjection</para>
		/// </summary>
		public override string ToolName() => "DefineProjection";

		/// <summary>
		/// <para>Tool Excute Name : management.DefineProjection</para>
		/// </summary>
		public override string ExcuteName() => "management.DefineProjection";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, CoorSystem, OutDataset };

		/// <summary>
		/// <para>Input Dataset or Feature Class</para>
		/// <para>要定义投影的数据集或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>要应用于输入的坐标系。默认值将基于“输出坐标系”环境设置进行设定。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCoordinateSystem()]
		public object CoorSystem { get; set; }

		/// <summary>
		/// <para>Update Input Dataset or Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DefineProjection SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
