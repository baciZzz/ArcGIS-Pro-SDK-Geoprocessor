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
	/// <para>Outside Boundary</para>
	/// <para>Outside Boundary</para>
	/// <para>Entities outside given boundary.</para>
	/// </summary>
	[Obsolete()]
	public class OutsideBoundary : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputPointFeatures">
		/// <para>Input Points</para>
		/// </param>
		/// <param name="InputAreaFeatures">
		/// <para>Input Area</para>
		/// </param>
		public OutsideBoundary(object InputPointFeatures, object InputAreaFeatures)
		{
			this.InputPointFeatures = InputPointFeatures;
			this.InputAreaFeatures = InputAreaFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Outside Boundary</para>
		/// </summary>
		public override string DisplayName() => "Outside Boundary";

		/// <summary>
		/// <para>Tool Name : OutsideBoundary</para>
		/// </summary>
		public override string ToolName() => "OutsideBoundary";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.OutsideBoundary</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.OutsideBoundary";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise() => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputPointFeatures, InputAreaFeatures, InputSearchExpression!, InputAreaExpression!, OutputIdList! };

		/// <summary>
		/// <para>Input Points</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InputPointFeatures { get; set; }

		/// <summary>
		/// <para>Input Area</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InputAreaFeatures { get; set; }

		/// <summary>
		/// <para>Input Search Expression</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? InputSearchExpression { get; set; }

		/// <summary>
		/// <para>Input Area Expression</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? InputAreaExpression { get; set; }

		/// <summary>
		/// <para>Output OIDs</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutputIdList { get; set; }

	}
}
