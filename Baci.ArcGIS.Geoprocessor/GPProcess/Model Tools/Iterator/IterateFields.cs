using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ModelTools
{
	/// <summary>
	/// <para>Iterate Fields</para>
	/// <para>Iterates fields in a table.</para>
	/// </summary>
	public class IterateFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input table with fields to be iterated.</para>
		/// </param>
		public IterateFields(object InTable)
		{
			this.InTable = InTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Iterate Fields</para>
		/// </summary>
		public override string DisplayName => "Iterate Fields";

		/// <summary>
		/// <para>Tool Name : IterateFields</para>
		/// </summary>
		public override string ToolName => "IterateFields";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateFields</para>
		/// </summary>
		public override string ExcuteName => "mb.IterateFields";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, FieldType!, Wildcard!, InputFields!, OutputField!, OutputCount! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input table with fields to be iterated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPTablesDomain()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Type</para>
		/// <para>Specifies the field type used to filter the fields. If a field type is not specified, all fields of the supported field types will be iterated.</para>
		/// <para>Blob—BLOB fields will be iterated.</para>
		/// <para>Date—Date fields will be iterated.</para>
		/// <para>Double—Double fields will be iterated.</para>
		/// <para>Float—Float fields will be iterated.</para>
		/// <para>GUID—GUID fields will be iterated.</para>
		/// <para>Long—Long integer fields will be iterated.</para>
		/// <para>Raster—Raster fields will be iterated.</para>
		/// <para>Short—Short integer fields will be iterated.</para>
		/// <para>Text—Text fields will be iterated.</para>
		/// <para><see cref="FieldTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? FieldType { get; set; }

		/// <summary>
		/// <para>Wildcard</para>
		/// <para>Limits the fields that will be iterated. The wildcard works on both field names and field aliases and is a combination of * and other characters. For example, this parameter can be used to restrict iteration of input field names or field aliases starting with a certain character or word (for example, A* or Ari* or Land*, and so on). An asterisk is equivalent to searching for all the fields. If a wildcard is not specified, all inputs will be returned.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Wildcard { get; set; }

		/// <summary>
		/// <para>Field Names</para>
		/// <para>The list of fields that will be iterated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		public object? InputFields { get; set; }

		/// <summary>
		/// <para>Value</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[Field()]
		public object? OutputField { get; set; }

		/// <summary>
		/// <para>Count</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object? OutputCount { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Field Type</para>
		/// </summary>
		public enum FieldTypeEnum 
		{
			/// <summary>
			/// <para>Text—Text fields will be iterated.</para>
			/// </summary>
			[GPValue("TEXT")]
			[Description("Text")]
			Text,

			/// <summary>
			/// <para>Float—Float fields will be iterated.</para>
			/// </summary>
			[GPValue("FLOAT")]
			[Description("Float")]
			Float,

			/// <summary>
			/// <para>Double—Double fields will be iterated.</para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("Double")]
			Double,

			/// <summary>
			/// <para>Short—Short integer fields will be iterated.</para>
			/// </summary>
			[GPValue("SHORT")]
			[Description("Short")]
			Short,

			/// <summary>
			/// <para>Long—Long integer fields will be iterated.</para>
			/// </summary>
			[GPValue("LONG")]
			[Description("Long")]
			Long,

			/// <summary>
			/// <para>Date—Date fields will be iterated.</para>
			/// </summary>
			[GPValue("DATE")]
			[Description("Date")]
			Date,

			/// <summary>
			/// <para>Blob—BLOB fields will be iterated.</para>
			/// </summary>
			[GPValue("BLOB")]
			[Description("Blob")]
			Blob,

			/// <summary>
			/// <para>Raster—Raster fields will be iterated.</para>
			/// </summary>
			[GPValue("RASTER")]
			[Description("Raster")]
			Raster,

			/// <summary>
			/// <para>GUID—GUID fields will be iterated.</para>
			/// </summary>
			[GPValue("GUID")]
			[Description("GUID")]
			GUID,

		}

#endregion
	}
}
