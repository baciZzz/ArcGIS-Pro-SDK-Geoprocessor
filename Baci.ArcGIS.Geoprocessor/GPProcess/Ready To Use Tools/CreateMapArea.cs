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
	/// <para>ServerTool</para>
	/// <para></para>
	/// </summary>
	public class CreateMapArea : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Mapitemid">
		/// <para>Map Item ID</para>
		/// </param>
		public CreateMapArea(object Mapitemid)
		{
			this.Mapitemid = Mapitemid;
		}

		/// <summary>
		/// <para>Tool Display Name : ServerTool</para>
		/// </summary>
		public override string DisplayName => "ServerTool";

		/// <summary>
		/// <para>Tool Name : CreateMapArea</para>
		/// </summary>
		public override string ToolName => "CreateMapArea";

		/// <summary>
		/// <para>Tool Excute Name : agolservices.CreateMapArea</para>
		/// </summary>
		public override string ExcuteName => "agolservices.CreateMapArea";

		/// <summary>
		/// <para>Toolbox Display Name : Ready To Use Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Ready To Use Tools";

		/// <summary>
		/// <para>Toolbox Alise : agolservices</para>
		/// </summary>
		public override string ToolboxAlise => "agolservices";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Mapitemid, Bookmark, Extent, Areatype, Area, Outputname, Mapareaitemid };

		/// <summary>
		/// <para>Map Item ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Mapitemid { get; set; }

		/// <summary>
		/// <para>Map Bookmark</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Bookmark { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Area Type</para>
		/// <para><see cref="AreatypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Areatype { get; set; } = "BOOKMARK";

		/// <summary>
		/// <para>Area</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Area { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Map Area Item ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object Mapareaitemid { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Area Type</para>
		/// </summary>
		public enum AreatypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("BOOKMARK")]
			[Description("BOOKMARK")]
			BOOKMARK,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("ENVELOPE")]
			[Description("ENVELOPE")]
			ENVELOPE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("POLYGON")]
			POLYGON,

		}

#endregion
	}
}
