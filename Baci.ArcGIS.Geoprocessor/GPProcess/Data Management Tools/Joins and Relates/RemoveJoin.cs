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
	/// <para>Remove Join</para>
	/// <para>Remove Join</para>
	/// <para>Removes a join from a feature layer or table view.</para>
	/// </summary>
	public class RemoveJoin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayerOrView">
		/// <para>Layer Name or Table View</para>
		/// <para>The layer or table view from which the join will be removed.</para>
		/// </param>
		public RemoveJoin(object InLayerOrView)
		{
			this.InLayerOrView = InLayerOrView;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Join</para>
		/// </summary>
		public override string DisplayName() => "Remove Join";

		/// <summary>
		/// <para>Tool Name : RemoveJoin</para>
		/// </summary>
		public override string ToolName() => "RemoveJoin";

		/// <summary>
		/// <para>Tool Excute Name : management.RemoveJoin</para>
		/// </summary>
		public override string ExcuteName() => "management.RemoveJoin";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLayerOrView, JoinName!, OutLayerOrView! };

		/// <summary>
		/// <para>Layer Name or Table View</para>
		/// <para>The layer or table view from which the join will be removed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPLayersAndTablesDomain(MustHaveJoins = true)]
		public object InLayerOrView { get; set; }

		/// <summary>
		/// <para>Join</para>
		/// <para>The join to be removed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? JoinName { get; set; }

		/// <summary>
		/// <para>Layer With Join Removed</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutLayerOrView { get; set; }

	}
}
