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
	/// <para>Validate Topology</para>
	/// <para>拓扑验证</para>
	/// <para>验证地理数据库拓扑。</para>
	/// </summary>
	public class ValidateTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTopology">
		/// <para>Input Topology</para>
		/// <para>要验证的地理数据库拓扑。</para>
		/// </param>
		public ValidateTopology(object InTopology)
		{
			this.InTopology = InTopology;
		}

		/// <summary>
		/// <para>Tool Display Name : 拓扑验证</para>
		/// </summary>
		public override string DisplayName() => "拓扑验证";

		/// <summary>
		/// <para>Tool Name : ValidateTopology</para>
		/// </summary>
		public override string ToolName() => "ValidateTopology";

		/// <summary>
		/// <para>Tool Excute Name : management.ValidateTopology</para>
		/// </summary>
		public override string ExcuteName() => "management.ValidateTopology";

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
		public override object[] Parameters() => new object[] { InTopology, VisibleExtent, OutTopology };

		/// <summary>
		/// <para>Input Topology</para>
		/// <para>要验证的地理数据库拓扑。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTopologyLayer()]
		public object InTopology { get; set; }

		/// <summary>
		/// <para>Visible Extent</para>
		/// <para>指定是将验证地图的当前可见范围，还是拓扑的全图范围。如果工具是在 Python 窗口或 Python 脚本中运行，则不管此参数如何设置都将验证拓扑的整个范围。</para>
		/// <para>选中 - 仅验证当前可见范围。</para>
		/// <para>未选中 - 验证拓扑的整个范围。这是默认设置。</para>
		/// <para><see cref="VisibleExtentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object VisibleExtent { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Topology</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTopologyLayer()]
		public object OutTopology { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ValidateTopology SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Visible Extent</para>
		/// </summary>
		public enum VisibleExtentEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("Visible_Extent")]
			Visible_Extent,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("Full_Extent")]
			Full_Extent,

		}

#endregion
	}
}
