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
	/// <para>Import Tile Cache</para>
	/// <para>Import Tile Cache</para>
	/// <para>Imports tiles from an existing tile cache or a tile package. The target cache must have the same tiling scheme, spatial reference, and  storage format as the source tile cache.</para>
	/// </summary>
	public class ImportTileCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCacheTarget">
		/// <para>Target Tile Cache</para>
		/// <para>An existing tile cache to which the tiles will be imported.</para>
		/// </param>
		/// <param name="InCacheSource">
		/// <para>Source Tile Cache</para>
		/// <para>An existing tile cache or a tile package from which the tiles are imported.</para>
		/// </param>
		public ImportTileCache(object InCacheTarget, object InCacheSource)
		{
			this.InCacheTarget = InCacheTarget;
			this.InCacheSource = InCacheSource;
		}

		/// <summary>
		/// <para>Tool Display Name : Import Tile Cache</para>
		/// </summary>
		public override string DisplayName() => "Import Tile Cache";

		/// <summary>
		/// <para>Tool Name : ImportTileCache</para>
		/// </summary>
		public override string ToolName() => "ImportTileCache";

		/// <summary>
		/// <para>Tool Excute Name : management.ImportTileCache</para>
		/// </summary>
		public override string ExcuteName() => "management.ImportTileCache";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCacheTarget, InCacheSource, Scales, AreaOfInterest, Overwrite, OutTileCache };

		/// <summary>
		/// <para>Target Tile Cache</para>
		/// <para>An existing tile cache to which the tiles will be imported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InCacheTarget { get; set; }

		/// <summary>
		/// <para>Source Tile Cache</para>
		/// <para>An existing tile cache or a tile package from which the tiles are imported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InCacheSource { get; set; }

		/// <summary>
		/// <para>Scales [Pixel Size] (Estimated Disk Space)</para>
		/// <para>A list of scale levels at which tiles will be imported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Scales { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>An area of interest will spatially constrain where tiles are imported into the cache.</para>
		/// <para>This parameter is useful if you want to import tiles for irregularly shaped areas.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Overwrite Tiles</para>
		/// <para>Determines whether the images in the destination cache will be merged with the tiles from the originating cache or overwritten by them.</para>
		/// <para>Unchecked—When the tiles are imported, transparent pixels in the originating cache are ignored by default. This results in a merged or blended image in the destination cache. This is the default.</para>
		/// <para>Checked—The import replaces all pixels in the area of interest, effectively overwriting tiles in the destination cache with tiles from the originating cache.</para>
		/// <para><see cref="OverwriteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Overwrite { get; set; } = "false";

		/// <summary>
		/// <para>Updated Target Tile Cache</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object OutTileCache { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportTileCache SetEnviroment(object parallelProcessingFactor = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Overwrite Tiles</para>
		/// </summary>
		public enum OverwriteEnum 
		{
			/// <summary>
			/// <para>Checked—The import replaces all pixels in the area of interest, effectively overwriting tiles in the destination cache with tiles from the originating cache.</para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERWRITE")]
			OVERWRITE,

			/// <summary>
			/// <para>Unchecked—When the tiles are imported, transparent pixels in the originating cache are ignored by default. This results in a merged or blended image in the destination cache. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("MERGE")]
			MERGE,

		}

#endregion
	}
}
