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
	/// <para>Validates a geodatabase topology.</para>
	/// </summary>
	public class ValidateTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTopology">
		/// <para>Input Topology</para>
		/// <para>The geodatabase topology to be validated.</para>
		/// </param>
		public ValidateTopology(object InTopology)
		{
			this.InTopology = InTopology;
		}

		/// <summary>
		/// <para>Tool Display Name : Validate Topology</para>
		/// </summary>
		public override string DisplayName() => "Validate Topology";

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
		/// <para>The geodatabase topology to be validated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTopologyLayer()]
		public object InTopology { get; set; }

		/// <summary>
		/// <para>Visible Extent</para>
		/// <para>Specifies whether the current visible extent of the map or the full extent of the topology will be validated. If the tool is run in the Python window or in a Python script, the entire extent of the topology will be validated regardless of this parameter setting.</para>
		/// <para>Checked—Only the current visible extent will be validated</para>
		/// <para>Unchecked—The entire extent of the topology will be validated. This is the default.</para>
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
		public ValidateTopology SetEnviroment(object workspace = null )
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
			/// <para>Checked—Only the current visible extent will be validated</para>
			/// </summary>
			[GPValue("true")]
			[Description("Visible_Extent")]
			Visible_Extent,

			/// <summary>
			/// <para>Unchecked—The entire extent of the topology will be validated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("Full_Extent")]
			Full_Extent,

		}

#endregion
	}
}
