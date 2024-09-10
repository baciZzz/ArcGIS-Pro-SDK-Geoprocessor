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
	/// <para>Create Locator</para>
	/// <para>Creates a locator that can find the location of an address or a place, convert a table of addresses or places to a collection of point features, or identify the address of a point location.</para>
	/// </summary>
	public class CreateLocator : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="CountryCode">
		/// <para>Country or Region</para>
		/// <para>Specifies where country-specific geocoding logic will be applied to the reference data for the locator.</para>
		/// <para>The default is the regional setting of the operating system. It can be specified by selecting &lt;As defined in data&gt; from the list and mapping a value from the data in the field mapping, or it can be applied to the entire dataset by selecting one from the list.</para>
		/// <para>It provides a country template containing the expected field names that display in the Field Mapping parameter for the specified country of the locator to be created.</para>
		/// <para>&lt;As defined in data&gt;—Three-character country code value defined in the reference data for each feature</para>
		/// <para>American Samoa—American Samoa</para>
		/// <para>Australia—Australia</para>
		/// <para>Austria—Austria</para>
		/// <para>Belgium—Belgium</para>
		/// <para>Canada—Canada</para>
		/// <para>Switzerland— Switzerland</para>
		/// <para>Germany—Germany</para>
		/// <para>Spain—Spain</para>
		/// <para>France—France</para>
		/// <para>Great Britain—Great Britain</para>
		/// <para>Guam—Guam</para>
		/// <para>Northern Mariana Islands—Northern Mariana Islands</para>
		/// <para>Netherlands— Netherlands</para>
		/// <para>Puerto Rico—Puerto Rico</para>
		/// <para>U.S. Virgin Islands—U.S. Virgin Islands</para>
		/// <para>United States—United States</para>
		/// <para>Minor Outlying Islands of the United States— Minor Outlying Islands of the United States</para>
		/// </param>
		/// <param name="PrimaryReferenceData">
		/// <para>Primary Table(s)</para>
		/// <para>The reference data feature classes and their roles that will be used to create the locator. Only one primary table can be used per role.</para>
		/// <para>Feature classes represented as services are supported data types for use as primary reference data.</para>
		/// <para>When a definition query is defined for the primary reference data or there are selected features, only the queried and selected features will be included when the locator is created.</para>
		/// <para>When creating a locator with reference data that contains millions of features, you must have at least three to four times the size of the data in free disk space on the drive containing your temp directory, as files used to build the locator are written to this location before the locator is copied to the output location. If you do not have enough disk space, the tool will fail when it runs out of space. Also, when creating large locators, your machine must have enough RAM to handle large memory-intensive processes.</para>
		/// </param>
		/// <param name="FieldMapping">
		/// <para>Field Mapping</para>
		/// <para>The mapping of primary reference dataset fields to the fields supported by the locator role. Fields with an asterisk (*) next to their names are required by the locator role. Map the relevant fields for each table from the Primary Table(s) parameter.</para>
		/// <para>If you are using an alternate name table, map Join ID in Primary Table(s).</para>
		/// <para>To add custom output fields, type the name of the fields in the Custom Output Fields parameter. The new fields will be added to the Field Mapping parameter. You can then select the fields from the Primary Table(s) parameter that contain the additional values to be included in the geocode output.</para>
		/// </param>
		/// <param name="OutLocator">
		/// <para>Output Locator</para>
		/// <para>The output address locator file.</para>
		/// </param>
		/// <param name="LanguageCode">
		/// <para>Language Code</para>
		/// <para>Specifies where language-specific geocoding logic will be applied to the reference data for the locator.</para>
		/// <para>If a language code field exists in the primary reference data, providing a language code can improve the results of the geocoding.</para>
		/// <para>It can be specified by selecting &lt;As defined in data&gt; from the list and mapping a value from the primary reference data in the field mapping, or it can be applied to the entire dataset by selecting a language from the list.</para>
		/// <para>&lt;As defined in data&gt;—Three-character language code value defined in the reference data for each feature</para>
		/// <para>Basque—Basque</para>
		/// <para>Catalan—Catalan</para>
		/// <para>Dutch— Dutch</para>
		/// <para>English—English</para>
		/// <para>French—French</para>
		/// <para>German—German</para>
		/// <para>Galician—Galician</para>
		/// <para>Italian— Italian</para>
		/// <para>Spanish—Spanish</para>
		/// <para><see cref="LanguageCodeEnum"/></para>
		/// </param>
		public CreateLocator(object CountryCode, object PrimaryReferenceData, object FieldMapping, object OutLocator, object LanguageCode)
		{
			this.CountryCode = CountryCode;
			this.PrimaryReferenceData = PrimaryReferenceData;
			this.FieldMapping = FieldMapping;
			this.OutLocator = OutLocator;
			this.LanguageCode = LanguageCode;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Locator</para>
		/// </summary>
		public override string DisplayName() => "Create Locator";

		/// <summary>
		/// <para>Tool Name : CreateLocator</para>
		/// </summary>
		public override string ToolName() => "CreateLocator";

		/// <summary>
		/// <para>Tool Excute Name : geocoding.CreateLocator</para>
		/// </summary>
		public override string ExcuteName() => "geocoding.CreateLocator";

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
		public override object[] Parameters() => new object[] { CountryCode, PrimaryReferenceData, FieldMapping, OutLocator, LanguageCode, AlternatenameTables, AlternateFieldMapping, CustomOutputFields, PrecisionType };

		/// <summary>
		/// <para>Country or Region</para>
		/// <para>Specifies where country-specific geocoding logic will be applied to the reference data for the locator.</para>
		/// <para>The default is the regional setting of the operating system. It can be specified by selecting &lt;As defined in data&gt; from the list and mapping a value from the data in the field mapping, or it can be applied to the entire dataset by selecting one from the list.</para>
		/// <para>It provides a country template containing the expected field names that display in the Field Mapping parameter for the specified country of the locator to be created.</para>
		/// <para>&lt;As defined in data&gt;—Three-character country code value defined in the reference data for each feature</para>
		/// <para>American Samoa—American Samoa</para>
		/// <para>Australia—Australia</para>
		/// <para>Austria—Austria</para>
		/// <para>Belgium—Belgium</para>
		/// <para>Canada—Canada</para>
		/// <para>Switzerland— Switzerland</para>
		/// <para>Germany—Germany</para>
		/// <para>Spain—Spain</para>
		/// <para>France—France</para>
		/// <para>Great Britain—Great Britain</para>
		/// <para>Guam—Guam</para>
		/// <para>Northern Mariana Islands—Northern Mariana Islands</para>
		/// <para>Netherlands— Netherlands</para>
		/// <para>Puerto Rico—Puerto Rico</para>
		/// <para>U.S. Virgin Islands—U.S. Virgin Islands</para>
		/// <para>United States—United States</para>
		/// <para>Minor Outlying Islands of the United States— Minor Outlying Islands of the United States</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CountryCode { get; set; } = "USA";

		/// <summary>
		/// <para>Primary Table(s)</para>
		/// <para>The reference data feature classes and their roles that will be used to create the locator. Only one primary table can be used per role.</para>
		/// <para>Feature classes represented as services are supported data types for use as primary reference data.</para>
		/// <para>When a definition query is defined for the primary reference data or there are selected features, only the queried and selected features will be included when the locator is created.</para>
		/// <para>When creating a locator with reference data that contains millions of features, you must have at least three to four times the size of the data in free disk space on the drive containing your temp directory, as files used to build the locator are written to this location before the locator is copied to the output location. If you do not have enough disk space, the tool will fail when it runs out of space. Also, when creating large locators, your machine must have enough RAM to handle large memory-intensive processes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object PrimaryReferenceData { get; set; }

		/// <summary>
		/// <para>Field Mapping</para>
		/// <para>The mapping of primary reference dataset fields to the fields supported by the locator role. Fields with an asterisk (*) next to their names are required by the locator role. Map the relevant fields for each table from the Primary Table(s) parameter.</para>
		/// <para>If you are using an alternate name table, map Join ID in Primary Table(s).</para>
		/// <para>To add custom output fields, type the name of the fields in the Custom Output Fields parameter. The new fields will be added to the Field Mapping parameter. You can then select the fields from the Primary Table(s) parameter that contain the additional values to be included in the geocode output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object FieldMapping { get; set; }

		/// <summary>
		/// <para>Output Locator</para>
		/// <para>The output address locator file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEAddressLocator()]
		public object OutLocator { get; set; }

		/// <summary>
		/// <para>Language Code</para>
		/// <para>Specifies where language-specific geocoding logic will be applied to the reference data for the locator.</para>
		/// <para>If a language code field exists in the primary reference data, providing a language code can improve the results of the geocoding.</para>
		/// <para>It can be specified by selecting &lt;As defined in data&gt; from the list and mapping a value from the primary reference data in the field mapping, or it can be applied to the entire dataset by selecting a language from the list.</para>
		/// <para>&lt;As defined in data&gt;—Three-character language code value defined in the reference data for each feature</para>
		/// <para>Basque—Basque</para>
		/// <para>Catalan—Catalan</para>
		/// <para>Dutch— Dutch</para>
		/// <para>English—English</para>
		/// <para>French—French</para>
		/// <para>German—German</para>
		/// <para>Galician—Galician</para>
		/// <para>Italian— Italian</para>
		/// <para>Spanish—Spanish</para>
		/// <para><see cref="LanguageCodeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LanguageCode { get; set; }

		/// <summary>
		/// <para>Alternate Name Tables</para>
		/// <para>The tables that contain alternate names for the features in the primary role tables.</para>
		/// <para>Tables represented as services are supported data types for use as alternate name tables.</para>
		/// <para>When a definition query is defined for the alternate name table or there are selected records, only the queried and selected records will be included when the locator is created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Optional parameters")]
		public object AlternatenameTables { get; set; }

		/// <summary>
		/// <para>Alternate Data Field Mapping</para>
		/// <para>Maps alternate name table fields to the alternate data fields supported by the locator role. Fields with an asterisk (*) next to their names are required by the locator role. Map the relevant fields for each table in Alternate Name Tables.</para>
		/// <para>If the data is normalized and the primary table does not contain city name values but the alternate name table does, the Primary Name Indicator field can be mapped to a field in the alternate name table that contains a value that indicates whether the record is the primary field (for example, true/false or Yes/No). If this field is not mapped, the first record in the alternate name table will be used as the primary value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Optional parameters")]
		public object AlternateFieldMapping { get; set; }

		/// <summary>
		/// <para>Custom Output Fields</para>
		/// <para>Adds output fields to the geocode result. The values specified for this parameter will define the names of the output fields that will be returned by the geocode result; however, each new field must be mapped to a field in the reference data. This new output field will apply for all roles that were used in the locator. If the locator role has a left and right side, _left and _right will be appended to the end of the field name. The maximum number of fields supported in the locator is 50.</para>
		/// <para>Do the following to add custom output fields to the locator for use in the geocode result:</para>
		/// <para>Type the names of the custom output fields. The custom output field names will be added to the field mapping.</para>
		/// <para>Select the field in the reference data that contains the additional values to be included in the geocode output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Optional parameters")]
		public object CustomOutputFields { get; set; }

		/// <summary>
		/// <para>Precision Type</para>
		/// <para>Specifies the precision of the locator.</para>
		/// <para>Locators created with Global Extra High or Local Extra High precision can be used in ArcGIS Pro 2.6 or later and Enterprise 10.8.1 or later.</para>
		/// <para>Global Extra High— The precision is approximately 1cm, which is consistent globally.</para>
		/// <para>Global High— The precision is approximately 0.5m, which is consistent globally. This is the default.</para>
		/// <para>Local Extra High— Increased precision is used for local areas.</para>
		/// <para><see cref="PrecisionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Optional parameters")]
		public object PrecisionType { get; set; } = "GLOBAL_HIGH";

		#region InnerClass

		/// <summary>
		/// <para>Language Code</para>
		/// </summary>
		public enum LanguageCodeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("AS_DEFINED_IN_DATA")]
			[Description("<As defined in data>")]
			AS_DEFINED_IN_DATA,

			/// <summary>
			/// <para>Basque—Basque</para>
			/// </summary>
			[GPValue("BAQ")]
			[Description("Basque")]
			Basque,

			/// <summary>
			/// <para>Catalan—Catalan</para>
			/// </summary>
			[GPValue("CAT")]
			[Description("Catalan")]
			Catalan,

			/// <summary>
			/// <para>Dutch— Dutch</para>
			/// </summary>
			[GPValue("DUT")]
			[Description("Dutch")]
			Dutch,

			/// <summary>
			/// <para>English—English</para>
			/// </summary>
			[GPValue("ENG")]
			[Description("English")]
			English,

			/// <summary>
			/// <para>French—French</para>
			/// </summary>
			[GPValue("FRE")]
			[Description("French")]
			French,

			/// <summary>
			/// <para>German—German</para>
			/// </summary>
			[GPValue("GER")]
			[Description("German")]
			German,

			/// <summary>
			/// <para>Galician—Galician</para>
			/// </summary>
			[GPValue("GLG")]
			[Description("Galician")]
			Galician,

			/// <summary>
			/// <para>Italian— Italian</para>
			/// </summary>
			[GPValue("ITA")]
			[Description("Italian")]
			Italian,

			/// <summary>
			/// <para>Spanish—Spanish</para>
			/// </summary>
			[GPValue("SPA")]
			[Description("Spanish")]
			Spanish,

		}

		/// <summary>
		/// <para>Precision Type</para>
		/// </summary>
		public enum PrecisionTypeEnum 
		{
			/// <summary>
			/// <para>Global High— The precision is approximately 0.5m, which is consistent globally. This is the default.</para>
			/// </summary>
			[GPValue("GLOBAL_HIGH")]
			[Description("Global High")]
			Global_High,

			/// <summary>
			/// <para>Global Extra High— The precision is approximately 1cm, which is consistent globally.</para>
			/// </summary>
			[GPValue("GLOBAL_EXTRA_HIGH")]
			[Description("Global Extra High")]
			Global_Extra_High,

			/// <summary>
			/// <para>Local Extra High— Increased precision is used for local areas.</para>
			/// </summary>
			[GPValue("LOCAL_EXTRA_HIGH")]
			[Description("Local Extra High")]
			Local_Extra_High,

		}

#endregion
	}
}
