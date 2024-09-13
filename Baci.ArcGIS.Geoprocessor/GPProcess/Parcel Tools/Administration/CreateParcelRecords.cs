using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ParcelTools
{
	/// <summary>
	/// <para>Create Parcel Records</para>
	/// <para>Create Parcel Records</para>
	/// <para>Creates parcel records for the input parcel fabric features  using a record name field or an expression.</para>
	/// </summary>
	public class CreateParcelRecords : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelFeatures">
		/// <para>Parcel Features</para>
		/// <para>The input parcel features that will be used to create parcel records. The input parcel features can be from a parcel fabric in a file, enterprise, or mobile geodatabase.</para>
		/// </param>
		public CreateParcelRecords(object InParcelFeatures)
		{
			this.InParcelFeatures = InParcelFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Parcel Records</para>
		/// </summary>
		public override string DisplayName() => "Create Parcel Records";

		/// <summary>
		/// <para>Tool Name : CreateParcelRecords</para>
		/// </summary>
		public override string ToolName() => "CreateParcelRecords";

		/// <summary>
		/// <para>Tool Excute Name : parcel.CreateParcelRecords</para>
		/// </summary>
		public override string ExcuteName() => "parcel.CreateParcelRecords";

		/// <summary>
		/// <para>Toolbox Display Name : Parcel Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Parcel Tools";

		/// <summary>
		/// <para>Toolbox Alise : parcel</para>
		/// </summary>
		public override string ToolboxAlise() => "parcel";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InParcelFeatures, RecordField!, OutRecordFeatureClass!, UpdatedParcelFabric!, RecordExpression!, RecordNameMethod! };

		/// <summary>
		/// <para>Parcel Features</para>
		/// <para>The input parcel features that will be used to create parcel records. The input parcel features can be from a parcel fabric in a file, enterprise, or mobile geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		public object InParcelFeatures { get; set; }

		/// <summary>
		/// <para>Record Field</para>
		/// <para>The attribute field that contains the record names. The attribute field must be a text field and must contain parcel record names that correspond to their associated parcel features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? RecordField { get; set; }

		/// <summary>
		/// <para>Output Records Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutRecordFeatureClass { get; set; }

		/// <summary>
		/// <para>Updated Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEParcelDataset()]
		public object? UpdatedParcelFabric { get; set; }

		/// <summary>
		/// <para>Record Expression</para>
		/// <para>An Arcade expression that uses fields, string operators, and mathematical operators to represent the record names. For example, the expression Left($feature.Name,4) extracts the first four characters from the parcel name field in the parcel fabric polygon feature class to create the record names.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCalculatorExpression()]
		public object? RecordExpression { get; set; }

		/// <summary>
		/// <para>Record Name Method</para>
		/// <para>Specifies the method that will be used to create parcel records.</para>
		/// <para>Field—Parcel records will be created using record names from a text field on the input parcel features. This is the default.</para>
		/// <para>Expression—Parcel records will be created using an Arcade expression.</para>
		/// <para><see cref="RecordNameMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RecordNameMethod { get; set; } = "FIELD";

		#region InnerClass

		/// <summary>
		/// <para>Record Name Method</para>
		/// </summary>
		public enum RecordNameMethodEnum 
		{
			/// <summary>
			/// <para>Field—Parcel records will be created using record names from a text field on the input parcel features. This is the default.</para>
			/// </summary>
			[GPValue("FIELD")]
			[Description("Field")]
			Field,

			/// <summary>
			/// <para>Expression—Parcel records will be created using an Arcade expression.</para>
			/// </summary>
			[GPValue("EXPRESSION")]
			[Description("Expression")]
			Expression,

		}

#endregion
	}
}
