using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.StandardFeatureAnalysisTools
{
	/// <summary>
	/// <para>Dissolve Boundaries</para>
	/// <para>Dissolve Boundaries</para>
	/// <para>Finds polygons that overlap or share a common boundary and merges them together to form a single polygon.</para>
	/// </summary>
	public class DissolveBoundaries : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputlayer">
		/// <para>Input Layer</para>
		/// <para>The layer containing polygon features that will be dissolved or combined.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the output layer to create on your portal.</para>
		/// </param>
		public DissolveBoundaries(object Inputlayer, object Outputname)
		{
			this.Inputlayer = Inputlayer;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : Dissolve Boundaries</para>
		/// </summary>
		public override string DisplayName() => "Dissolve Boundaries";

		/// <summary>
		/// <para>Tool Name : DissolveBoundaries</para>
		/// </summary>
		public override string ToolName() => "DissolveBoundaries";

		/// <summary>
		/// <para>Tool Excute Name : sfa.DissolveBoundaries</para>
		/// </summary>
		public override string ExcuteName() => "sfa.DissolveBoundaries";

		/// <summary>
		/// <para>Toolbox Display Name : Standard Feature Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Standard Feature Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : sfa</para>
		/// </summary>
		public override string ToolboxAlise() => "sfa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputlayer, Outputname, Dissolvefields, Summaryfields, Output };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The layer containing polygon features that will be dissolved or combined.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Inputlayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output layer to create on your portal.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Dissolve Fields</para>
		/// <para>One or more fields from the input layer that control which polygons are merged. If you don&apos;t supply dissolve fields, polygons that share a common border (that is, they are adjacent) or polygon areas that overlap will be dissolved into one polygon.</para>
		/// <para>If you do supply fields, polygons that share a common border and contain the same value in one or more fields will be dissolved. For example, if you have a layer of counties and each county has a State_Name attribute, you can dissolve boundaries using the State_Name attribute. Adjacent counties will be merged together if they have the same value for State_Name. The end result is a layer of state boundaries. If two or more fields are specified, the values in these fields must be the same for the boundary to be dissolved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object Dissolvefields { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>A list of field names and statistical summary type that you wish to calculate for all points within each polygon. The count of points within each polygon is always returned. The following statistic types are supported:</para>
		/// <para>Sum—The total value.</para>
		/// <para>Minimum—The smallest value.</para>
		/// <para>Max—The largest value.</para>
		/// <para>Mean—The average or mean value.</para>
		/// <para>Standard deviation—The standard deviation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Summaryfields { get; set; }

		/// <summary>
		/// <para>Output</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DissolveBoundaries SetEnviroment(object extent = null)
		{
			base.SetEnv(extent: extent);
			return this;
		}

	}
}
