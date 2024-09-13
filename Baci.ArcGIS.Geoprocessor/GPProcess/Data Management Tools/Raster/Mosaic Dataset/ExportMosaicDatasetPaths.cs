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
	/// <para>Export Mosaic Dataset Paths</para>
	/// <para>Export Mosaic Dataset Paths</para>
	/// <para>Creates a table of the file path for each item in a mosaic dataset. You can specify whether the table contains all the file paths or just the ones that are broken.</para>
	/// </summary>
	public class ExportMosaicDatasetPaths : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset containing the file paths to export.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>The table to create. The table can be a geodatabase table or a .dbf file.</para>
		/// <para>The SourceOID field in the output table is derived from the OID of the row in the original mosaic dataset table.</para>
		/// </param>
		public ExportMosaicDatasetPaths(object InMosaicDataset, object OutTable)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Mosaic Dataset Paths</para>
		/// </summary>
		public override string DisplayName() => "Export Mosaic Dataset Paths";

		/// <summary>
		/// <para>Tool Name : ExportMosaicDatasetPaths</para>
		/// </summary>
		public override string ToolName() => "ExportMosaicDatasetPaths";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportMosaicDatasetPaths</para>
		/// </summary>
		public override string ExcuteName() => "management.ExportMosaicDatasetPaths";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, OutTable, WhereClause!, ExportMode!, TypesOfPaths! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset containing the file paths to export.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The table to create. The table can be a geodatabase table or a .dbf file.</para>
		/// <para>The SourceOID field in the output table is derived from the OID of the row in the original mosaic dataset table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>An SQL expression to select specific rasters for export.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Export Mode</para>
		/// <para>Populate the table with either all of the paths, or only the broken paths.</para>
		/// <para>All paths—Export all paths to the table. This is the default.</para>
		/// <para>Broken paths only—Export only broken paths to the table.</para>
		/// <para><see cref="ExportModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ExportMode { get; set; } = "ALL";

		/// <summary>
		/// <para>Types of paths to export</para>
		/// <para>Choose to export file paths from only the source raster, only the cache, or both. The default is to export all path types.</para>
		/// <para>Raster—Export file paths from rasters.</para>
		/// <para>Item cache—Export file paths from item cache.</para>
		/// <para><see cref="TypesOfPathsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? TypesOfPaths { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportMosaicDatasetPaths SetEnviroment(object? configKeyword = null , object? extent = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Export Mode</para>
		/// </summary>
		public enum ExportModeEnum 
		{
			/// <summary>
			/// <para>All paths—Export all paths to the table. This is the default.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All paths")]
			All_paths,

			/// <summary>
			/// <para>Broken paths only—Export only broken paths to the table.</para>
			/// </summary>
			[GPValue("BROKEN")]
			[Description("Broken paths only")]
			Broken_paths_only,

		}

		/// <summary>
		/// <para>Types of paths to export</para>
		/// </summary>
		public enum TypesOfPathsEnum 
		{
			/// <summary>
			/// <para>Raster—Export file paths from rasters.</para>
			/// </summary>
			[GPValue("RASTER")]
			[Description("Raster")]
			Raster,

			/// <summary>
			/// <para>Item cache—Export file paths from item cache.</para>
			/// </summary>
			[GPValue("ITEM_CACHE")]
			[Description("Item cache")]
			Item_cache,

		}

#endregion
	}
}
