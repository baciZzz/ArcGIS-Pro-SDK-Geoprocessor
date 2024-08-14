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
	/// <para>Split Address Into Components</para>
	/// <para>Splits street address information into address components and creates a table or feature class with the additional components added as unique fields.</para>
	/// </summary>
	public class SplitAddressIntoComponents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="CountryCode">
		/// <para>Country or Region</para>
		/// <para>Specifies which country addressing structure to use for splitting addresses into components.</para>
		/// <para>The default is the regional setting of the operating system.</para>
		/// <para>Australia—The country code will be Australia.</para>
		/// <para>Canada—The country code will be Canada.</para>
		/// <para>Germany—The country code will be Germany.</para>
		/// <para>Great Britain—The country code will be Great Britain.</para>
		/// <para>United States—The country code will be United States.</para>
		/// <para><see cref="CountryCodeEnum"/></para>
		/// </param>
		/// <param name="InAddressData">
		/// <para>Input Address Data</para>
		/// <para>The table or feature class containing street address information that will be split into individual address components.</para>
		/// <para>Zone information, such as city, neighborhood, subregion, and postal code, is not supported.</para>
		/// </param>
		/// <param name="InAddressFields">
		/// <para>Input Address Fields</para>
		/// <para>The field or fields in the input table or feature class that, when concatenated, will form the street address to be split. Zone information, such as city, neighborhood, subregion, and postal code, is not supported.</para>
		/// <para>The order in which the fields are selected is the order the fields will be concatenated.</para>
		/// </param>
		/// <param name="OutAddressData">
		/// <para>Output Address Data</para>
		/// <para>The output feature class or table that will contain the split street address data.</para>
		/// </param>
		public SplitAddressIntoComponents(object CountryCode, object InAddressData, object InAddressFields, object OutAddressData)
		{
			this.CountryCode = CountryCode;
			this.InAddressData = InAddressData;
			this.InAddressFields = InAddressFields;
			this.OutAddressData = OutAddressData;
		}

		/// <summary>
		/// <para>Tool Display Name : Split Address Into Components</para>
		/// </summary>
		public override string DisplayName => "Split Address Into Components";

		/// <summary>
		/// <para>Tool Name : SplitAddressIntoComponents</para>
		/// </summary>
		public override string ToolName => "SplitAddressIntoComponents";

		/// <summary>
		/// <para>Tool Excute Name : geocoding.SplitAddressIntoComponents</para>
		/// </summary>
		public override string ExcuteName => "geocoding.SplitAddressIntoComponents";

		/// <summary>
		/// <para>Toolbox Display Name : Geocoding Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Geocoding Tools";

		/// <summary>
		/// <para>Toolbox Alise : geocoding</para>
		/// </summary>
		public override string ToolboxAlise => "geocoding";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { CountryCode, InAddressData, InAddressFields, OutAddressData, InExceptions };

		/// <summary>
		/// <para>Country or Region</para>
		/// <para>Specifies which country addressing structure to use for splitting addresses into components.</para>
		/// <para>The default is the regional setting of the operating system.</para>
		/// <para>Australia—The country code will be Australia.</para>
		/// <para>Canada—The country code will be Canada.</para>
		/// <para>Germany—The country code will be Germany.</para>
		/// <para>Great Britain—The country code will be Great Britain.</para>
		/// <para>United States—The country code will be United States.</para>
		/// <para><see cref="CountryCodeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CountryCode { get; set; } = "USA";

		/// <summary>
		/// <para>Input Address Data</para>
		/// <para>The table or feature class containing street address information that will be split into individual address components.</para>
		/// <para>Zone information, such as city, neighborhood, subregion, and postal code, is not supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InAddressData { get; set; }

		/// <summary>
		/// <para>Input Address Fields</para>
		/// <para>The field or fields in the input table or feature class that, when concatenated, will form the street address to be split. Zone information, such as city, neighborhood, subregion, and postal code, is not supported.</para>
		/// <para>The order in which the fields are selected is the order the fields will be concatenated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InAddressFields { get; set; }

		/// <summary>
		/// <para>Output Address Data</para>
		/// <para>The output feature class or table that will contain the split street address data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEDatasetType()]
		public object OutAddressData { get; set; }

		/// <summary>
		/// <para>Exceptions File</para>
		/// <para>The table that contains street parsing exceptions.</para>
		/// <para>The table can be in any supported table format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object? InExceptions { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SplitAddressIntoComponents SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Country or Region</para>
		/// </summary>
		public enum CountryCodeEnum 
		{
			/// <summary>
			/// <para>Australia—The country code will be Australia.</para>
			/// </summary>
			[GPValue("AUS")]
			[Description("Australia")]
			Australia,

			/// <summary>
			/// <para>Canada—The country code will be Canada.</para>
			/// </summary>
			[GPValue("CAN")]
			[Description("Canada")]
			Canada,

			/// <summary>
			/// <para>Germany—The country code will be Germany.</para>
			/// </summary>
			[GPValue("DEU")]
			[Description("Germany")]
			Germany,

			/// <summary>
			/// <para>Great Britain—The country code will be Great Britain.</para>
			/// </summary>
			[GPValue("GBR")]
			[Description("Great Britain")]
			Great_Britain,

			/// <summary>
			/// <para>United States—The country code will be United States.</para>
			/// </summary>
			[GPValue("USA")]
			[Description("United States")]
			United_States,

		}

#endregion
	}
}
