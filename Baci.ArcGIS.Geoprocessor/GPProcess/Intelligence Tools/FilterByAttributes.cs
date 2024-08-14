using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>Filter By Attributes</para>
	/// <para>Find features that match an attribute query.</para>
	/// </summary>
	[Obsolete()]
	public class FilterByAttributes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// </param>
		/// <param name="InputSearchExpression">
		/// <para>Input Search Expression</para>
		/// </param>
		public FilterByAttributes(object InputFeatures, object InputSearchExpression)
		{
			this.InputFeatures = InputFeatures;
			this.InputSearchExpression = InputSearchExpression;
		}

		/// <summary>
		/// <para>Tool Display Name : Filter By Attributes</para>
		/// </summary>
		public override string DisplayName => "Filter By Attributes";

		/// <summary>
		/// <para>Tool Name : FilterByAttributes</para>
		/// </summary>
		public override string ToolName => "FilterByAttributes";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.FilterByAttributes</para>
		/// </summary>
		public override string ExcuteName => "intelligence.FilterByAttributes";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputFeatures, InputSearchExpression, OutputIdList };

		/// <summary>
		/// <para>Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Input Search Expression</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSQLExpression()]
		public object InputSearchExpression { get; set; }

		/// <summary>
		/// <para>Output OIDs</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutputIdList { get; set; }

	}
}
