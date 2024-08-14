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
	/// <para>Point To Point</para>
	/// <para>Find like entities within a distance of each other.</para>
	/// </summary>
	[Obsolete()]
	public class PointToPoint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputPointFeatures">
		/// <para>Input Points</para>
		/// <para>The input point layer. These points are the similar points to be found within the search Distance.</para>
		/// </param>
		/// <param name="InputSearchDistance">
		/// <para>Distance</para>
		/// </param>
		public PointToPoint(object InputPointFeatures, object InputSearchDistance)
		{
			this.InputPointFeatures = InputPointFeatures;
			this.InputSearchDistance = InputSearchDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : Point To Point</para>
		/// </summary>
		public override string DisplayName => "Point To Point";

		/// <summary>
		/// <para>Tool Name : PointToPoint</para>
		/// </summary>
		public override string ToolName => "PointToPoint";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.PointToPoint</para>
		/// </summary>
		public override string ExcuteName => "intelligence.PointToPoint";

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
		public override object[] Parameters => new object[] { InputPointFeatures, InputSearchDistance, InputSearchExpression!, OutputIdList! };

		/// <summary>
		/// <para>Input Points</para>
		/// <para>The input point layer. These points are the similar points to be found within the search Distance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InputPointFeatures { get; set; }

		/// <summary>
		/// <para>Distance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object InputSearchDistance { get; set; }

		/// <summary>
		/// <para>Input Search Expression</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? InputSearchExpression { get; set; }

		/// <summary>
		/// <para>Output OIDs</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutputIdList { get; set; }

	}
}
