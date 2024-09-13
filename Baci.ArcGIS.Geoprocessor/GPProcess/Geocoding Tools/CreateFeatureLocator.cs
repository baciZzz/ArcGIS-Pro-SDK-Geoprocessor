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
	/// <para>Create Feature Locator</para>
	/// <para>Create Feature Locator</para>
	/// <para>Creates a locator using reference data that contains a unique name or value for every feature stored in a single field. A locator created with this tool has broad applications. It can be used to search for names or unique attributes of your features, such as water meters, short place names, cell towers, or alphanumeric strings used to identify locations (for example, N1N115).</para>
	/// </summary>
	public class CreateFeatureLocator : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The reference data feature class or feature layer that will be used to create the locator.</para>
		/// <para>Feature classes represented as services are supported data types for use as reference data.</para>
		/// <para>When a definition query is defined for the reference data or there are selected features, only the queried and selected features are included when the locator is created.</para>
		/// <para>When creating a locator with reference data that contains millions of features, you must have at least three to four times the size of the data in free disk space on the drive containing your temp directory, as files used to build the locator are written to this location before the locator is copied to the output location. If you do not have enough disk space, the tool will fail when it runs out of space. Also, when creating large locators, your machine must have enough RAM to handle large memory-intensive processes.</para>
		/// </param>
		/// <param name="SearchFields">
		/// <para>Search Fields</para>
		/// <para>Maps the reference data field to the field used for search in the Input Features parameter. Fields with an asterisk (*) next to their names are required. The selected field will be indexed and used for search.</para>
		/// </param>
		/// <param name="OutputLocator">
		/// <para>Output Locator</para>
		/// <para>The output locator file to be created in a file folder. Once the locator is created, additional properties and options can be modified in the locator's settings.</para>
		/// </param>
		public CreateFeatureLocator(object InFeatures, object SearchFields, object OutputLocator)
		{
			this.InFeatures = InFeatures;
			this.SearchFields = SearchFields;
			this.OutputLocator = OutputLocator;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Feature Locator</para>
		/// </summary>
		public override string DisplayName() => "Create Feature Locator";

		/// <summary>
		/// <para>Tool Name : CreateFeatureLocator</para>
		/// </summary>
		public override string ToolName() => "CreateFeatureLocator";

		/// <summary>
		/// <para>Tool Excute Name : geocoding.CreateFeatureLocator</para>
		/// </summary>
		public override string ExcuteName() => "geocoding.CreateFeatureLocator";

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
		public override object[] Parameters() => new object[] { InFeatures, SearchFields, OutputLocator, LocatorFields! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The reference data feature class or feature layer that will be used to create the locator.</para>
		/// <para>Feature classes represented as services are supported data types for use as reference data.</para>
		/// <para>When a definition query is defined for the reference data or there are selected features, only the queried and selected features are included when the locator is created.</para>
		/// <para>When creating a locator with reference data that contains millions of features, you must have at least three to four times the size of the data in free disk space on the drive containing your temp directory, as files used to build the locator are written to this location before the locator is copied to the output location. If you do not have enough disk space, the tool will fail when it runs out of space. Also, when creating large locators, your machine must have enough RAM to handle large memory-intensive processes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Search Fields</para>
		/// <para>Maps the reference data field to the field used for search in the Input Features parameter. Fields with an asterisk (*) next to their names are required. The selected field will be indexed and used for search.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFieldInfo()]
		[xmlserialize(Xml = "<GPFieldInfoDomain xsi:type='typens:GPFieldInfoDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/3.0.0'><GPCodedValueDomain xsi:type='typens:GPCodedValueDomain'><GPDomainPropertiesArray xsi:type='typens:ArrayOfGPCodedValueDomainProperty'><GPCodedValueDomainProperty xsi:type='typens:GPCodedValueDomainProperty'><Name>&lt;None&gt;</Name><Value xsi:type='typens:Field'><Name>&lt;None&gt;</Name><Type>esriFieldTypeInteger</Type><IsNullable>true</IsNullable><Length>0</Length><Precision>0</Precision><Scale>0</Scale></Value></GPCodedValueDomainProperty></GPDomainPropertiesArray></GPCodedValueDomain></GPFieldInfoDomain>")]
		public object SearchFields { get; set; } = "*Name <None> VISIBLE NONE";

		/// <summary>
		/// <para>Output Locator</para>
		/// <para>The output locator file to be created in a file folder. Once the locator is created, additional properties and options can be modified in the locator's settings.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEAddressLocator()]
		public object OutputLocator { get; set; }

		/// <summary>
		/// <para>Additional Locator Fields</para>
		/// <para>Maps additional fields for extent and rank if they exist in the data. The Rank field is used to sort results for ambiguous queries or candidates with the same name and score. The extent fields help set the map extent for displaying geocoded results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldInfo()]
		[xmlserialize(Xml = "<GPFieldInfoDomain xsi:type='typens:GPFieldInfoDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/3.0.0'><GPCodedValueDomain xsi:type='typens:GPCodedValueDomain'><GPDomainPropertiesArray xsi:type='typens:ArrayOfGPCodedValueDomainProperty'><GPCodedValueDomainProperty xsi:type='typens:GPCodedValueDomainProperty'><Name>&lt;None&gt;</Name><Value xsi:type='typens:Field'><Name>&lt;None&gt;</Name><Type>esriFieldTypeInteger</Type><IsNullable>true</IsNullable><Length>0</Length><Precision>0</Precision><Scale>0</Scale></Value></GPCodedValueDomainProperty></GPDomainPropertiesArray></GPCodedValueDomain></GPFieldInfoDomain>")]
		[Category("Optional parameters")]
		public object? LocatorFields { get; set; } = "Rank <None> VISIBLE NONE;'Min X' <None> VISIBLE NONE;'Max X' <None> VISIBLE NONE;'Min Y' <None> VISIBLE NONE;'Max Y' <None> VISIBLE NONE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateFeatureLocator SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
