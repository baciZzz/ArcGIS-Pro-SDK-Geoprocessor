using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ReadyToUseTools
{
	/// <summary>
	/// <para>ServerTool 7</para>
	/// <para></para>
	/// </summary>
	public class RefreshMapAreaPackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Packages">
		/// <para>List of packages to update</para>
		/// </param>
		public RefreshMapAreaPackage(object Packages)
		{
			this.Packages = Packages;
		}

		/// <summary>
		/// <para>Tool Display Name : ServerTool 7</para>
		/// </summary>
		public override string DisplayName() => "ServerTool 7";

		/// <summary>
		/// <para>Tool Name : RefreshMapAreaPackage</para>
		/// </summary>
		public override string ToolName() => "RefreshMapAreaPackage";

		/// <summary>
		/// <para>Tool Excute Name : agolservices.RefreshMapAreaPackage</para>
		/// </summary>
		public override string ExcuteName() => "agolservices.RefreshMapAreaPackage";

		/// <summary>
		/// <para>Toolbox Display Name : Ready To Use Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Ready To Use Tools";

		/// <summary>
		/// <para>Toolbox Alise : agolservices</para>
		/// </summary>
		public override string ToolboxAlise() => "agolservices";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Packages, Result };

		/// <summary>
		/// <para>List of packages to update</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Packages { get; set; }

		/// <summary>
		/// <para>Update result</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object Result { get; set; }

	}
}
