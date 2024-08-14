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
	/// <para>Distance From Boundary</para>
	/// <para>Entities within distance of given boundary.</para>
	/// </summary>
	[Obsolete()]
	public class WithinDistanceOfBoundary : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputPointFeatures">
		/// <para>Input Points</para>
		/// </param>
		/// <param name="InputAreaFeatures">
		/// <para>Input Areas</para>
		/// </param>
		/// <param name="InputDistance">
		/// <para>Distance</para>
		/// </param>
		public WithinDistanceOfBoundary(object InputPointFeatures, object InputAreaFeatures, object InputDistance)
		{
			this.InputPointFeatures = InputPointFeatures;
			this.InputAreaFeatures = InputAreaFeatures;
			this.InputDistance = InputDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : Distance From Boundary</para>
		/// </summary>
		public override string DisplayName => "Distance From Boundary";

		/// <summary>
		/// <para>Tool Name : WithinDistanceOfBoundary</para>
		/// </summary>
		public override string ToolName => "WithinDistanceOfBoundary";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.WithinDistanceOfBoundary</para>
		/// </summary>
		public override string ExcuteName => "intelligence.WithinDistanceOfBoundary";

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
		public override object[] Parameters => new object[] { InputPointFeatures, InputAreaFeatures, InputDistance, InputSearchExpression!, InputAreaExpression!, OutputIdList! };

		/// <summary>
		/// <para>Input Points</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InputPointFeatures { get; set; }

		/// <summary>
		/// <para>Input Areas</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InputAreaFeatures { get; set; }

		/// <summary>
		/// <para>Distance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object InputDistance { get; set; }

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
