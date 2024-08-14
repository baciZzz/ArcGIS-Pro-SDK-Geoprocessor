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
	/// <para>Import Mosaic Dataset Geometry</para>
	/// <para>Modifies the geometry for the footprints, boundary, or seamlines in a mosaic dataset to match those in a feature class.</para>
	/// </summary>
	public class ImportMosaicDatasetGeometry : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset whose geometries you want to edit.</para>
		/// </param>
		/// <param name="TargetFeatureclassType">
		/// <para>Target Feature Class</para>
		/// <para>The geometry that you want to change.</para>
		/// <para>Footprint—The footprint polygons in the mosaic dataset</para>
		/// <para>Seamline—The seamline polygons in the mosaic dataset</para>
		/// <para>Boundary—The boundary polygon in the mosaic dataset</para>
		/// <para><see cref="TargetFeatureclassTypeEnum"/></para>
		/// </param>
		/// <param name="TargetJoinField">
		/// <para>Target Join Field</para>
		/// <para>The field in the mosaic dataset to use as a basis for the join.</para>
		/// </param>
		/// <param name="InputFeatureclass">
		/// <para>Input Feature Class</para>
		/// <para>The feature class with the new geometry.</para>
		/// </param>
		/// <param name="InputJoinField">
		/// <para>Input Join Field</para>
		/// <para>The field in the Input Feature Class to use as a basis for the join.</para>
		/// <para>If the Input Feature Class has more than 1,000 records, add an index on this field by running the Add_Attribute_Index tool. If your mosaic dataset is very large and the join field is not indexed, the tool will take much longer to complete.</para>
		/// </param>
		public ImportMosaicDatasetGeometry(object InMosaicDataset, object TargetFeatureclassType, object TargetJoinField, object InputFeatureclass, object InputJoinField)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.TargetFeatureclassType = TargetFeatureclassType;
			this.TargetJoinField = TargetJoinField;
			this.InputFeatureclass = InputFeatureclass;
			this.InputJoinField = InputJoinField;
		}

		/// <summary>
		/// <para>Tool Display Name : Import Mosaic Dataset Geometry</para>
		/// </summary>
		public override string DisplayName => "Import Mosaic Dataset Geometry";

		/// <summary>
		/// <para>Tool Name : ImportMosaicDatasetGeometry</para>
		/// </summary>
		public override string ToolName => "ImportMosaicDatasetGeometry";

		/// <summary>
		/// <para>Tool Excute Name : management.ImportMosaicDatasetGeometry</para>
		/// </summary>
		public override string ExcuteName => "management.ImportMosaicDatasetGeometry";

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
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InMosaicDataset, TargetFeatureclassType, TargetJoinField, InputFeatureclass, InputJoinField, OutMosaicDataset! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset whose geometries you want to edit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Target Feature Class</para>
		/// <para>The geometry that you want to change.</para>
		/// <para>Footprint—The footprint polygons in the mosaic dataset</para>
		/// <para>Seamline—The seamline polygons in the mosaic dataset</para>
		/// <para>Boundary—The boundary polygon in the mosaic dataset</para>
		/// <para><see cref="TargetFeatureclassTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TargetFeatureclassType { get; set; }

		/// <summary>
		/// <para>Target Join Field</para>
		/// <para>The field in the mosaic dataset to use as a basis for the join.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object TargetJoinField { get; set; }

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>The feature class with the new geometry.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputFeatureclass { get; set; }

		/// <summary>
		/// <para>Input Join Field</para>
		/// <para>The field in the Input Feature Class to use as a basis for the join.</para>
		/// <para>If the Input Feature Class has more than 1,000 records, add an index on this field by running the Add_Attribute_Index tool. If your mosaic dataset is very large and the join field is not indexed, the tool will take much longer to complete.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object InputJoinField { get; set; }

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMosaicLayer()]
		public object? OutMosaicDataset { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Target Feature Class</para>
		/// </summary>
		public enum TargetFeatureclassTypeEnum 
		{
			/// <summary>
			/// <para>Footprint—The footprint polygons in the mosaic dataset</para>
			/// </summary>
			[GPValue("FOOTPRINT")]
			[Description("Footprint")]
			Footprint,

			/// <summary>
			/// <para>Seamline—The seamline polygons in the mosaic dataset</para>
			/// </summary>
			[GPValue("SEAMLINE")]
			[Description("Seamline")]
			Seamline,

			/// <summary>
			/// <para>Boundary—The boundary polygon in the mosaic dataset</para>
			/// </summary>
			[GPValue("BOUNDARY")]
			[Description("Boundary")]
			Boundary,

		}

#endregion
	}
}
