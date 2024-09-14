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
	/// <para>Export Mosaic Dataset Geometry</para>
	/// <para>Export Mosaic Dataset Geometry</para>
	/// <para>Creates a feature class showing the footprints, boundary, seamlines or spatial resolutions of a mosaic dataset.</para>
	/// </summary>
	public class ExportMosaicDatasetGeometry : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset that you want to export the geometry from.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>Name the feature class you are creating.</para>
		/// </param>
		public ExportMosaicDatasetGeometry(object InMosaicDataset, object OutFeatureClass)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Mosaic Dataset Geometry</para>
		/// </summary>
		public override string DisplayName() => "Export Mosaic Dataset Geometry";

		/// <summary>
		/// <para>Tool Name : ExportMosaicDatasetGeometry</para>
		/// </summary>
		public override string ToolName() => "ExportMosaicDatasetGeometry";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportMosaicDatasetGeometry</para>
		/// </summary>
		public override string ExcuteName() => "management.ExportMosaicDatasetGeometry";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, OutFeatureClass, WhereClause!, GeometryType! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset that you want to export the geometry from.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>Name the feature class you are creating.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>An SQL expression to export specific rasters in the mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Geometry Type</para>
		/// <para>The type of geometry to export.</para>
		/// <para>Footprint— Create a feature class showing the footprints of each image.</para>
		/// <para>Boundary— Create a feature class showing the boundary of the mosaic dataset.</para>
		/// <para>Seamline— Create a feature class showing the seamlines.</para>
		/// <para>Cell size level— Create a feature class based on cell size level of features in your mosaic dataset.</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? GeometryType { get; set; } = "FOOTPRINT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportMosaicDatasetGeometry SetEnviroment(object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Geometry Type</para>
		/// </summary>
		public enum GeometryTypeEnum 
		{
			/// <summary>
			/// <para>Footprint— Create a feature class showing the footprints of each image.</para>
			/// </summary>
			[GPValue("FOOTPRINT")]
			[Description("Footprint")]
			Footprint,

			/// <summary>
			/// <para>Boundary— Create a feature class showing the boundary of the mosaic dataset.</para>
			/// </summary>
			[GPValue("BOUNDARY")]
			[Description("Boundary")]
			Boundary,

			/// <summary>
			/// <para>Seamline— Create a feature class showing the seamlines.</para>
			/// </summary>
			[GPValue("SEAMLINE")]
			[Description("Seamline")]
			Seamline,

			/// <summary>
			/// <para>Cell size level— Create a feature class based on cell size level of features in your mosaic dataset.</para>
			/// </summary>
			[GPValue("LEVEL")]
			[Description("Cell size level")]
			Cell_size_level,

		}

#endregion
	}
}
