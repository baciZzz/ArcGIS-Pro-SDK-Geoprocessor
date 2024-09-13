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
	/// <para>重新构建地址定位器</para>
	/// <para>重新构建地址定位器以用当前参考数据更新定位器。 由于定位器在创建时便包含参考数据的快照，因此在更改参考数据的几何和属性时，地址定位器并不会使用更新后的数据对地址进行地理编码。 要使用最新的参考数据对地址进行地理编码，必须在需要更新定位器中的更改内容时重新构建定位器。</para>
	/// </summary>
	public class RebuildAddressLocator : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InAddressLocator">
		/// <para>Input Address Locator</para>
		/// <para>要重新构建的地址定位器。</para>
		/// </param>
		public RebuildAddressLocator(object InAddressLocator)
		{
			this.InAddressLocator = InAddressLocator;
		}

		/// <summary>
		/// <para>Tool Display Name : 重新构建地址定位器</para>
		/// </summary>
		public override string DisplayName() => "重新构建地址定位器";

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
		/// <para>要重新构建的地址定位器。</para>
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
