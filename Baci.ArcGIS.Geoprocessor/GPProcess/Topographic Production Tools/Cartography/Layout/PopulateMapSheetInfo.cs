using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Populate Map Sheet Info</para>
	/// <para>Populates text in graphic elements on a map layout.</para>
	/// </summary>
	public class PopulateMapSheetInfo : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayout">
		/// <para>Input Layout</para>
		/// <para>The input layout that contains graphic elements with tagged text strings to be updated.</para>
		/// </param>
		/// <param name="AreaOfInterest">
		/// <para>Area of Interest</para>
		/// <para>A feature layer with a selection set containing one AOI feature. This parameter only accepts only polygon features. The tool writes attribute values from this feature to tagged text strings in defense-specific graphic elements.</para>
		/// </param>
		/// <param name="LookupTable">
		/// <para>Lookup Table</para>
		/// <para>An input table that contains the Field_Name and DM_Tag fields.</para>
		/// </param>
		public PopulateMapSheetInfo(object InLayout, object AreaOfInterest, object LookupTable)
		{
			this.InLayout = InLayout;
			this.AreaOfInterest = AreaOfInterest;
			this.LookupTable = LookupTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Populate Map Sheet Info</para>
		/// </summary>
		public override string DisplayName => "Populate Map Sheet Info";

		/// <summary>
		/// <para>Tool Name : PopulateMapSheetInfo</para>
		/// </summary>
		public override string ToolName => "PopulateMapSheetInfo";

		/// <summary>
		/// <para>Tool Excute Name : topographic.PopulateMapSheetInfo</para>
		/// </summary>
		public override string ExcuteName => "topographic.PopulateMapSheetInfo";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InLayout, AreaOfInterest, LookupTable, UpdatedLayout };

		/// <summary>
		/// <para>Input Layout</para>
		/// <para>The input layout that contains graphic elements with tagged text strings to be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayout()]
		public object InLayout { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>A feature layer with a selection set containing one AOI feature. This parameter only accepts only polygon features. The tool writes attribute values from this feature to tagged text strings in defense-specific graphic elements.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Lookup Table</para>
		/// <para>An input table that contains the Field_Name and DM_Tag fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object LookupTable { get; set; }

		/// <summary>
		/// <para>Updated Layout</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLayout()]
		public object UpdatedLayout { get; set; }

	}
}
