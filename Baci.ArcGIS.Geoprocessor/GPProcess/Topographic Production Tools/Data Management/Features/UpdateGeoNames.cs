using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Update GeoNames</para>
	/// <para>Updates the name field on input features based on the information from GeoNames_FeaturesP and GEONAMES_TABLE.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class UpdateGeoNames : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input features that will be updated. Each Input Features value should have field names matching the values specified for the Named Feature ID Field, Name ID Field, and Name Field parameters.</para>
		/// </param>
		/// <param name="InGeonamesFeatures">
		/// <para>GeoNames Features</para>
		/// <para>The input GeoNames features that identify unique named feature locations.</para>
		/// </param>
		/// <param name="InGeonamesTable">
		/// <para>GeoNames Table</para>
		/// <para>A table containing name records related to the input GeoNames features.</para>
		/// </param>
		/// <param name="NamedFeatureIdField">
		/// <para>Named Feature ID Field</para>
		/// <para>The field storing GeoNames named feature identifier values. These values should not be null or empty on the input features.</para>
		/// </param>
		/// <param name="NameIdField">
		/// <para>Name ID Field</para>
		/// <para>The field to store GeoNames name identifier values.</para>
		/// </param>
		/// <param name="NameField">
		/// <para>Name Field</para>
		/// <para>The field to store GeoNames name values.</para>
		/// </param>
		public UpdateGeoNames(object InFeatures, object InGeonamesFeatures, object InGeonamesTable, object NamedFeatureIdField, object NameIdField, object NameField)
		{
			this.InFeatures = InFeatures;
			this.InGeonamesFeatures = InGeonamesFeatures;
			this.InGeonamesTable = InGeonamesTable;
			this.NamedFeatureIdField = NamedFeatureIdField;
			this.NameIdField = NameIdField;
			this.NameField = NameField;
		}

		/// <summary>
		/// <para>Tool Display Name : Update GeoNames</para>
		/// </summary>
		public override string DisplayName => "Update GeoNames";

		/// <summary>
		/// <para>Tool Name : UpdateGeoNames</para>
		/// </summary>
		public override string ToolName => "UpdateGeoNames";

		/// <summary>
		/// <para>Tool Excute Name : topographic.UpdateGeoNames</para>
		/// </summary>
		public override string ExcuteName => "topographic.UpdateGeoNames";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, InGeonamesFeatures, InGeonamesTable, NamedFeatureIdField, NameIdField, NameField, OutFeatures! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features that will be updated. Each Input Features value should have field names matching the values specified for the Named Feature ID Field, Name ID Field, and Name Field parameters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>GeoNames Features</para>
		/// <para>The input GeoNames features that identify unique named feature locations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InGeonamesFeatures { get; set; }

		/// <summary>
		/// <para>GeoNames Table</para>
		/// <para>A table containing name records related to the input GeoNames features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InGeonamesTable { get; set; }

		/// <summary>
		/// <para>Named Feature ID Field</para>
		/// <para>The field storing GeoNames named feature identifier values. These values should not be null or empty on the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object NamedFeatureIdField { get; set; }

		/// <summary>
		/// <para>Name ID Field</para>
		/// <para>The field to store GeoNames name identifier values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object NameIdField { get; set; }

		/// <summary>
		/// <para>Name Field</para>
		/// <para>The field to store GeoNames name values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object NameField { get; set; }

		/// <summary>
		/// <para>Updated Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutFeatures { get; set; }

	}
}
