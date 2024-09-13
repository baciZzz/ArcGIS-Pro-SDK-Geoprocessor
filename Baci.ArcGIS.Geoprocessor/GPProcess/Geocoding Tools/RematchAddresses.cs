using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeocodingTools
{
	/// <summary>
	/// <para>Rematch Addresses</para>
	/// <para>重新匹配地址</para>
	/// <para>重新匹配地理编码要素类中的地址。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RematchAddresses : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeocodedFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>要重新匹配的地理编码要素类。</para>
		/// </param>
		public RematchAddresses(object InGeocodedFeatureClass)
		{
			this.InGeocodedFeatureClass = InGeocodedFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 重新匹配地址</para>
		/// </summary>
		public override string DisplayName() => "重新匹配地址";

		/// <summary>
		/// <para>Tool Name : RematchAddresses</para>
		/// </summary>
		public override string ToolName() => "RematchAddresses";

		/// <summary>
		/// <para>Tool Excute Name : geocoding.RematchAddresses</para>
		/// </summary>
		public override string ExcuteName() => "geocoding.RematchAddresses";

		/// <summary>
		/// <para>Toolbox Display Name : Geocoding Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geocoding Tools";

		/// <summary>
		/// <para>Toolbox Alise : geocoding</para>
		/// </summary>
		public override string ToolboxAlise() => "geocoding";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGeocodedFeatureClass, InWhereClause, OutGeocodedFeatureClass };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>要重新匹配的地理编码要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object InGeocodedFeatureClass { get; set; }

		/// <summary>
		/// <para>Where Clause</para>
		/// <para>用于选择要素子集的 SQL 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object InWhereClause { get; set; }

		/// <summary>
		/// <para>Updated Input Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutGeocodedFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RematchAddresses SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
