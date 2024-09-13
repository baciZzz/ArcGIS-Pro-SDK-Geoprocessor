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
	/// <para>Distance From Line</para>
	/// <para>与线的距离</para>
	/// <para>Entities near or along linear features</para>
	/// </summary>
	[Obsolete()]
	public class WithinDistanceOfLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputPointFeatures">
		/// <para>Input Points</para>
		/// </param>
		/// <param name="InputLinearFeatures">
		/// <para>Input Lines</para>
		/// </param>
		/// <param name="InputDistance">
		/// <para>Distance</para>
		/// </param>
		public WithinDistanceOfLine(object InputPointFeatures, object InputLinearFeatures, object InputDistance)
		{
			this.InputPointFeatures = InputPointFeatures;
			this.InputLinearFeatures = InputLinearFeatures;
			this.InputDistance = InputDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : 与线的距离</para>
		/// </summary>
		public override string DisplayName() => "与线的距离";

		/// <summary>
		/// <para>Tool Name : WithinDistanceOfLine</para>
		/// </summary>
		public override string ToolName() => "WithinDistanceOfLine";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.WithinDistanceOfLine</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.WithinDistanceOfLine";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputPointFeatures, InputLinearFeatures, InputDistance, InputSearchExpression!, InputLinearExpression!, OutputIdList! };

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
		/// <para>Input Lines</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InputLinearFeatures { get; set; }

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
		/// <para>Input Line Expression</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? InputLinearExpression { get; set; }

		/// <summary>
		/// <para>Output OIDs</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutputIdList { get; set; }

	}
}
