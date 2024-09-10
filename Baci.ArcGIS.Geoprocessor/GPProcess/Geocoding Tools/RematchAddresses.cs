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
	/// <para>Rematches addresses in a geocoded feature class.</para>
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
		/// <para>The geocoded feature class to be rematched.</para>
		/// </param>
		public RematchAddresses(object InGeocodedFeatureClass)
		{
			this.InGeocodedFeatureClass = InGeocodedFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Rematch Addresses</para>
		/// </summary>
		public override string DisplayName() => "Rematch Addresses";

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
		/// <para>The geocoded feature class to be rematched.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object InGeocodedFeatureClass { get; set; }

		/// <summary>
		/// <para>Where Clause</para>
		/// <para>An SQL expression used to select a subset of features.</para>
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
