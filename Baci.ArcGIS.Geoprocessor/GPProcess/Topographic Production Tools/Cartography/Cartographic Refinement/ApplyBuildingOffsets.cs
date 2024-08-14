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
	/// <para>Apply Building Offsets</para>
	/// <para>Aligns, moves, and hides building or bridge marker symbols based on product specification rules defined in an .xml file.</para>
	/// </summary>
	public class ApplyBuildingOffsets : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Input Map</para>
		/// <para>The input map that contains the layers with proper symbology. This can be a map in the application or an .mapx file on disk.</para>
		/// </param>
		/// <param name="RuleFile">
		/// <para>Rule File</para>
		/// <para>An .xml file containing the offset rules that define how features will be aligned and refined in case of any conflict.</para>
		/// </param>
		public ApplyBuildingOffsets(object InMap, object RuleFile)
		{
			this.InMap = InMap;
			this.RuleFile = RuleFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Apply Building Offsets</para>
		/// </summary>
		public override string DisplayName => "Apply Building Offsets";

		/// <summary>
		/// <para>Tool Name : ApplyBuildingOffsets</para>
		/// </summary>
		public override string ToolName => "ApplyBuildingOffsets";

		/// <summary>
		/// <para>Tool Excute Name : topographic.ApplyBuildingOffsets</para>
		/// </summary>
		public override string ExcuteName => "topographic.ApplyBuildingOffsets";

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
		public override object[] Parameters => new object[] { InMap, RuleFile, UpdatedMap };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>The input map that contains the layers with proper symbology. This can be a map in the application or an .mapx file on disk.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Rule File</para>
		/// <para>An .xml file containing the offset rules that define how features will be aligned and refined in case of any conflict.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object RuleFile { get; set; }

		/// <summary>
		/// <para>Updated Map</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMap()]
		public object UpdatedMap { get; set; }

	}
}
