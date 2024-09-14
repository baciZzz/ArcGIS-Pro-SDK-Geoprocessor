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
	/// <para>Remove Relate</para>
	/// <para>移除关联</para>
	/// <para>从要素图层或表视图中移除关联。</para>
	/// </summary>
	public class RemoveRelate : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayerOrView">
		/// <para>Layer Name or Table View</para>
		/// <para>要移除关联的图层或表视图。</para>
		/// </param>
		public RemoveRelate(object InLayerOrView)
		{
			this.InLayerOrView = InLayerOrView;
		}

		/// <summary>
		/// <para>Tool Display Name : 移除关联</para>
		/// </summary>
		public override string DisplayName() => "移除关联";

		/// <summary>
		/// <para>Tool Name : RemoveRelate</para>
		/// </summary>
		public override string ToolName() => "RemoveRelate";

		/// <summary>
		/// <para>Tool Excute Name : management.RemoveRelate</para>
		/// </summary>
		public override string ExcuteName() => "management.RemoveRelate";

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
		public override object[] Parameters() => new object[] { InLayerOrView, RelateName, OutLayerOrView };

		/// <summary>
		/// <para>Layer Name or Table View</para>
		/// <para>要移除关联的图层或表视图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPLayersAndTablesDomain(MustHaveRelates = true)]
		public object InLayerOrView { get; set; }

		/// <summary>
		/// <para>Relate Name</para>
		/// <para>要移除的关联的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object RelateName { get; set; }

		/// <summary>
		/// <para>Layer With Relate Removed</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutLayerOrView { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveRelate SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
