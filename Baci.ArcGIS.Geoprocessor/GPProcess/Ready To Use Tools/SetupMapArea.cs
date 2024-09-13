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
	/// <para>ServerTool 8</para>
	/// <para>ServerTool 8</para>
	/// <para></para>
	/// </summary>
	public class SetupMapArea : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Mapareaitemid">
		/// <para>Map Area Item ID</para>
		/// </param>
		public SetupMapArea(object Mapareaitemid)
		{
			this.Mapareaitemid = Mapareaitemid;
		}

		/// <summary>
		/// <para>Tool Display Name : ServerTool 8</para>
		/// </summary>
		public override string DisplayName() => "ServerTool 8";

		/// <summary>
		/// <para>Tool Name : SetupMapArea</para>
		/// </summary>
		public override string ToolName() => "SetupMapArea";

		/// <summary>
		/// <para>Tool Excute Name : agolservices.SetupMapArea</para>
		/// </summary>
		public override string ExcuteName() => "agolservices.SetupMapArea";

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
		public override object[] Parameters() => new object[] { Mapareaitemid, Maplayerstoignore, Tileservices, Featureservices, Packages };

		/// <summary>
		/// <para>Map Area Item ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Mapareaitemid { get; set; }

		/// <summary>
		/// <para>Map layers to ignore</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Maplayerstoignore { get; set; }

		/// <summary>
		/// <para>Tile Services</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Tileservices { get; set; }

		/// <summary>
		/// <para>Feature Services</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Featureservices { get; set; }

		/// <summary>
		/// <para>Packages</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object Packages { get; set; }

	}
}
