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
	/// <para>Distance From Points</para>
	/// <para>Find like entities within distance from an location.</para>
	/// </summary>
	[Obsolete()]
	public class DistanceFromPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputPointFeatures">
		/// <para>Input Points</para>
		/// </param>
		/// <param name="SourcePointFeatures">
		/// <para>Source Points</para>
		/// </param>
		/// <param name="InputSearchDistance">
		/// <para>Distance</para>
		/// </param>
		public DistanceFromPoints(object InputPointFeatures, object SourcePointFeatures, object InputSearchDistance)
		{
			this.InputPointFeatures = InputPointFeatures;
			this.SourcePointFeatures = SourcePointFeatures;
			this.InputSearchDistance = InputSearchDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : Distance From Points</para>
		/// </summary>
		public override string DisplayName => "Distance From Points";

		/// <summary>
		/// <para>Tool Name : DistanceFromPoints</para>
		/// </summary>
		public override string ToolName => "DistanceFromPoints";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.DistanceFromPoints</para>
		/// </summary>
		public override string ExcuteName => "intelligence.DistanceFromPoints";

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
		public override object[] Parameters => new object[] { InputPointFeatures, SourcePointFeatures, InputSearchDistance, InputSearchExpression, OutputIdList };

		/// <summary>
		/// <para>Input Points</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InputPointFeatures { get; set; }

		/// <summary>
		/// <para>Source Points</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object SourcePointFeatures { get; set; }

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
		public object InputSearchExpression { get; set; }

		/// <summary>
		/// <para>Output OIDs</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutputIdList { get; set; }

	}
}
