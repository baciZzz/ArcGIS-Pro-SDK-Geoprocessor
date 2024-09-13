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
	/// <para>Rebuild Address Locator</para>
	/// <para>Rebuild Address Locator</para>
	/// <para>Rebuilds an address locator to update the locator with the current reference data. Because a locator contains a snapshot of the reference data when it was created, it will not geocode addresses with the updated data  when the geometry and attributes of the reference data are changed.  To geocode addresses with the current version of the reference data, the  locator must be rebuilt if you want to update the changes in the locator.</para>
	/// </summary>
	public class RebuildAddressLocator : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InAddressLocator">
		/// <para>Input Address Locator</para>
		/// <para>The address locator to rebuild.</para>
		/// </param>
		public RebuildAddressLocator(object InAddressLocator)
		{
			this.InAddressLocator = InAddressLocator;
		}

		/// <summary>
		/// <para>Tool Display Name : Rebuild Address Locator</para>
		/// </summary>
		public override string DisplayName() => "Rebuild Address Locator";

		/// <summary>
		/// <para>Tool Name : RebuildAddressLocator</para>
		/// </summary>
		public override string ToolName() => "RebuildAddressLocator";

		/// <summary>
		/// <para>Tool Excute Name : geocoding.RebuildAddressLocator</para>
		/// </summary>
		public override string ExcuteName() => "geocoding.RebuildAddressLocator";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InAddressLocator, OutAddressLocator! };

		/// <summary>
		/// <para>Input Address Locator</para>
		/// <para>The address locator to rebuild.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEAddressLocator()]
		[GPLocatorsDomain()]
		public object InAddressLocator { get; set; }

		/// <summary>
		/// <para>Rebuilt Address Locator</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEAddressLocator()]
		public object? OutAddressLocator { get; set; }

	}
}
