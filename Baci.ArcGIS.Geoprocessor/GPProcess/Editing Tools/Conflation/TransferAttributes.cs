using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.EditingTools
{
	/// <summary>
	/// <para>Transfer Attributes</para>
	/// <para>Transfer Attributes</para>
	/// <para>Finds where the source line features spatially match the target line features and transfers specified attributes from source features to matched target features.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class TransferAttributes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="SourceFeatures">
		/// <para>Source Features</para>
		/// <para>Line features from which to transfer attributes.</para>
		/// </param>
		/// <param name="TargetFeatures">
		/// <para>Target Features</para>
		/// <para>Line features to which to transfer attributes. The specified transfer fields are added to the target features.</para>
		/// </param>
		/// <param name="TransferFields">
		/// <para>Transfer Field(s)</para>
		/// <para>List of source fields to be transferred to target features. At least one field must be specified.</para>
		/// </param>
		/// <param name="SearchDistance">
		/// <para>Search Distance</para>
		/// <para>The distance used to search for match candidates. A distance must be specified and it must be greater than zero. You can choose a preferred unit; the default is the feature unit.</para>
		/// </param>
		public TransferAttributes(object SourceFeatures, object TargetFeatures, object TransferFields, object SearchDistance)
		{
			this.SourceFeatures = SourceFeatures;
			this.TargetFeatures = TargetFeatures;
			this.TransferFields = TransferFields;
			this.SearchDistance = SearchDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : Transfer Attributes</para>
		/// </summary>
		public override string DisplayName() => "Transfer Attributes";

		/// <summary>
		/// <para>Tool Name : TransferAttributes</para>
		/// </summary>
		public override string ToolName() => "TransferAttributes";

		/// <summary>
		/// <para>Tool Excute Name : edit.TransferAttributes</para>
		/// </summary>
		public override string ExcuteName() => "edit.TransferAttributes";

		/// <summary>
		/// <para>Toolbox Display Name : Editing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Editing Tools";

		/// <summary>
		/// <para>Toolbox Alise : edit</para>
		/// </summary>
		public override string ToolboxAlise() => "edit";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { SourceFeatures, TargetFeatures, TransferFields, SearchDistance, MatchFields!, OutMatchTable!, OutFeatureClass!, TransferRuleFields! };

		/// <summary>
		/// <para>Source Features</para>
		/// <para>Line features from which to transfer attributes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object SourceFeatures { get; set; }

		/// <summary>
		/// <para>Target Features</para>
		/// <para>Line features to which to transfer attributes. The specified transfer fields are added to the target features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object TargetFeatures { get; set; }

		/// <summary>
		/// <para>Transfer Field(s)</para>
		/// <para>List of source fields to be transferred to target features. At least one field must be specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "Blob", "Raster", "XML", "GUID")]
		[ExcludeField("SHAPE_Length", "SHAPE_Area")]
		public object TransferFields { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The distance used to search for match candidates. A distance must be specified and it must be greater than zero. You can choose a preferred unit; the default is the feature unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; }

		/// <summary>
		/// <para>Match Fields</para>
		/// <para>Lists of fields from source and target features. If specified, each pair of fields are checked for match candidates to help determine the right match.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "Blob", "Raster", "XML", "GUID", "OID")]
		[ExcludeField("SHAPE_Length", "SHAPE_Area")]
		public object? MatchFields { get; set; }

		/// <summary>
		/// <para>Output Match Table</para>
		/// <para>The output table containing complete feature matching information.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutMatchTable { get; set; }

		/// <summary>
		/// <para>Updated Target Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Transfer Rule Field(s)</para>
		/// <para>Sets rules to control which source feature will be used to transfer attributes from when multiple source features matched target feature(s). The source feature to be used for the transfer is determined by the specified rule fields and the ruling values, which are ranked from high to low priority as they appear in the specified list. If no rules are set, the longest of the multiple matched source features will be used for the transfer.</para>
		/// <para>Available rule types are as follows:</para>
		/// <para>MIN—The minimum value for integer or date field. If for a date field, the most recent date.</para>
		/// <para>MAX—The maximum value for integer or date field. If for a date field, the oldest date.</para>
		/// <para>A text or integer value that may exist in your source features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? TransferRuleFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TransferAttributes SetEnviroment(object? extent = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

	}
}
