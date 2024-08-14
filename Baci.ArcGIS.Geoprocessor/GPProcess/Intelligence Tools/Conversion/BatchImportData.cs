using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>Batch Import Data</para>
	/// <para>Imports KML, KMZ, shapefiles, Excel worksheets, tabular text files, GeoJSON, and GPX files to feature classes stored in a single geodatabase.</para>
	/// </summary>
	public class BatchImportData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input Data</para>
		/// <para>The folders containing the data files or the data files to convert to geodatabase feature classes.</para>
		/// </param>
		/// <param name="TargetGdb">
		/// <para>Target Geodatabase</para>
		/// <para>The target geodatabase where output feature classes will be stored.</para>
		/// </param>
		public BatchImportData(object InData, object TargetGdb)
		{
			this.InData = InData;
			this.TargetGdb = TargetGdb;
		}

		/// <summary>
		/// <para>Tool Display Name : Batch Import Data</para>
		/// </summary>
		public override string DisplayName => "Batch Import Data";

		/// <summary>
		/// <para>Tool Name : BatchImportData</para>
		/// </summary>
		public override string ToolName => "BatchImportData";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.BatchImportData</para>
		/// </summary>
		public override string ExcuteName => "intelligence.BatchImportData";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InData, TargetGdb, Filter!, IncludeSubFolders!, OutGeodatabase!, IncludeGroundoverlay! };

		/// <summary>
		/// <para>Input Data</para>
		/// <para>The folders containing the data files or the data files to convert to geodatabase feature classes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Target Geodatabase</para>
		/// <para>The target geodatabase where output feature classes will be stored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object TargetGdb { get; set; }

		/// <summary>
		/// <para>Filter</para>
		/// <para>Applies a filter to limit which files are imported from folders. The following wildcard characters for the filter work on the full path to the input data:Multiple patterns can be added to the filter by separating each pattern with the vertical bar or pipe delimiter (|). Pattern comparisons are not case sensitive, so using the *airport.shp, *AIRPORT.SHP, or *Airport.shp pattern, for example, will import the same shapefile.</para>
		/// <para>*—Match any character</para>
		/// <para>?—Match a single character</para>
		/// <para>[range]—Match a single character in the range</para>
		/// <para>[!range]—Match any character not in the range</para>
		/// <para>The following are filter examples:</para>
		/// <para>To import all shapefiles, use *.shp.</para>
		/// <para>To import all shapefiles and all .kml files, use *.shp|*.kml.</para>
		/// <para>To import all files that have airport in the file path or file name, use *airport*.</para>
		/// <para>To import all .geojson files that have airport in the file path or file name, use *airport*.geojson.</para>
		/// <para>To import all .kmz files that have airport appended with any two characters in the name, use *airport??.kmz.</para>
		/// <para>To import all files that have 1990 through 1997 in the file path or file name, use *199[0-7]*.</para>
		/// <para>To import all shapefiles that have the exact folder name airfacilities in their file path, use *\airfacilities\*.shp.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Input Data Options")]
		public object? Filter { get; set; }

		/// <summary>
		/// <para>Include Sub Folders</para>
		/// <para>Specifies whether subfolders will be recursively explored.</para>
		/// <para>Checked—All subfolders will be explored. This is the default.</para>
		/// <para>Unchecked—Only the top-level folder will be explored.</para>
		/// <para><see cref="IncludeSubFoldersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Input Data Options")]
		public object? IncludeSubFolders { get; set; } = "true";

		/// <summary>
		/// <para>Updated Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutGeodatabase { get; set; }

		/// <summary>
		/// <para>Include Ground Overlay</para>
		/// <para>Specifies whether KML or KMZ ground overlays (raster, air photos, and so on) will be included in the output.</para>
		/// <para>Use caution if the KMZ points to a service that serves raster imagery. The tool will attempt to translate the raster imagery at all available scales. This process may be lengthy and possibly overwhelm the service.</para>
		/// <para>Checked—Ground overlays will be included in the output. This is the default.</para>
		/// <para>Unchecked—Ground overlays will not be included in the output.</para>
		/// <para><see cref="IncludeGroundoverlayEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("KML/KMZ Options")]
		public object? IncludeGroundoverlay { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>Include Sub Folders</para>
		/// </summary>
		public enum IncludeSubFoldersEnum 
		{
			/// <summary>
			/// <para>Checked—All subfolders will be explored. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SUBFOLDERS")]
			SUBFOLDERS,

			/// <summary>
			/// <para>Unchecked—Only the top-level folder will be explored.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SUBFOLDERS")]
			NO_SUBFOLDERS,

		}

		/// <summary>
		/// <para>Include Ground Overlay</para>
		/// </summary>
		public enum IncludeGroundoverlayEnum 
		{
			/// <summary>
			/// <para>Checked—Ground overlays will be included in the output. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GROUNDOVERLAY")]
			GROUNDOVERLAY,

			/// <summary>
			/// <para>Unchecked—Ground overlays will not be included in the output.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_GROUNDOVERLAY")]
			NO_GROUNDOVERLAY,

		}

#endregion
	}
}
