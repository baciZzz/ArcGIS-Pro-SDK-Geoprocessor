using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Add Fields (multiple)</para>
	/// <para>Adds new fields to a table, feature class, or raster.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input table where the fields will be added. The fields will be added to the existing input table and will not create a new output table.</para>
		/// <para>Fields can be added to feature classes in geodatabases, shapefiles, coverages, stand-alone tables, raster catalogs, rasters with attribute tables, and layers.</para>
		/// </param>
		public AddFields(object InTable)
		{
			this.InTable = InTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Fields (multiple)</para>
		/// </summary>
		public override string DisplayName => "Add Fields (multiple)";

		/// <summary>
		/// <para>Tool Name : AddFields</para>
		/// </summary>
		public override string ToolName => "AddFields";

		/// <summary>
		/// <para>Tool Excute Name : management.AddFields</para>
		/// </summary>
		public override string ExcuteName => "management.AddFields";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, FieldDescription!, OutTable!, Template! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input table where the fields will be added. The fields will be added to the existing input table and will not create a new output table.</para>
		/// <para>Fields can be added to feature classes in geodatabases, shapefiles, coverages, stand-alone tables, raster catalogs, rasters with attribute tables, and layers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPTablesDomain()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Properties</para>
		/// <para>The fields and their properties that will be added to the input table.</para>
		/// <para>Field Name—The name of the field that will be added to the input table.</para>
		/// <para>Field Type—The type of the new field.</para>
		/// <para>Field Alias—The alternate name given to the field name. This is used to give more descriptive names to cryptic field names. This value only applies to geodatabases.</para>
		/// <para>Field Length—The length of the field being added. This sets the maximum number of allowable characters for each record of the field. This option is only applicable to fields of type text; the default length is 255.</para>
		/// <para>Default Value—The default value of the field.</para>
		/// <para>Field Domain—The geodatabase domain that will be assigned to the field.</para>
		/// <para>Available field types are as follows:</para>
		/// <para>Text—The field type will be text. Text fields support a string of characters.</para>
		/// <para>Float (32-bit floating point)—The field type will be float. Float fields support fractional numbers between -3.4E38 and 1.2E38.</para>
		/// <para>Double (64-bit floating point)—The field type will be double. Double fields support fractional numbers between -2.2E308 and 1.8E308.</para>
		/// <para>Short (16-bit integer)—The field type will be short. Short fields support whole numbers between -32,768 and 32,767.</para>
		/// <para>Long (32-bit integer)—The field type will be long. Long fields support whole numbers between -2,147,483,648 and 2,147,483,647.</para>
		/// <para>Date—The field type will be date. Date fields support date and time values.</para>
		/// <para>Blob (binary data)—The field type will be BLOB. BLOB fields support data stored as a long sequence of binary numbers. You need a custom loader or viewer or a third-party application to load items into a BLOB field or view the contents of a BLOB field.</para>
		/// <para>Raster imagery—The field type will be raster. Raster fields can store raster data in or alongside the geodatabase. All ArcGIS software-supported raster dataset formats can be stored, but it is recommended that only small images be used.</para>
		/// <para>GUID (globally unique identifier)—The field type will be GUID. GUID fields store registry-style strings consisting of 36 characters enclosed in curly brackets.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? FieldDescription { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Template Tables</para>
		/// <para>The feature classes or tables that will be used as a template to define the attribute fields to add.</para>
		/// <para>Fields from the inputs specified with this parameter will be added to the Input Table value in addition to any fields specified by the Field Properties parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Template { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddFields SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
