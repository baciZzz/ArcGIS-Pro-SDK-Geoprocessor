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
	/// <para>Create Vector Tile Package</para>
	/// <para>Generates vector tiles from a map or basemap and packages the tiles in a single .vtpk file.</para>
	/// </summary>
	public class CreateVectorTilePackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Input Map</para>
		/// <para>The map from which tiles are generated and packaged. The input map must have metadata description and tags.</para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>The output vector tile package. The file extension of the package is .vtpk.</para>
		/// </param>
		/// <param name="ServiceType">
		/// <para>Package for ArcGIS Online | Bing Maps | Google Maps</para>
		/// <para>Determines whether the tiling scheme will be generated from an existing map service or if map tiles will be generated for ArcGIS Online, Bing Maps, and Google Maps.</para>
		/// <para>Checked—The ArcGIS Online/Bing Maps/Google Maps tiling scheme is used. The ArcGIS Online/Bing Maps/Google Maps tiling scheme allows you to overlay your cache tiles with tiles from these online mapping services. ArcGIS Pro includes this tiling scheme as a built-in option when loading a tiling scheme. When you choose this tiling scheme, the data frame of your source map must use the WGS 1984 Web Mercator (Auxiliary Sphere) projected coordinate system. This is the default.</para>
		/// <para>Unchecked—Tiling scheme from an existing vector tile service will be used. Only tiling schemes with scales that double in progression through levels and have 512-by-512 tile size are supported. You must specify a vector tile service or tiling scheme file in the tiling_scheme parameter.</para>
		/// <para><see cref="ServiceTypeEnum"/></para>
		/// </param>
		/// <param name="MinCachedScale">
		/// <para>Minimum Cached Scale</para>
		/// <para>The minimum (smallest) scale at which tiles are generated. This does not have to be the smallest scale in your tiling scheme. The minimum cached scale determines which scales are used to generate cache.</para>
		/// </param>
		/// <param name="MaxCachedScale">
		/// <para>Maximum Cached Scale</para>
		/// <para>The maximum (largest) scale at which tiles are generated. This does not have to be the largest scale in your tiling scheme. The maximum cached scale determines which scales are used to generate cache.</para>
		/// </param>
		public CreateVectorTilePackage(object InMap, object OutputFile, object ServiceType, object MinCachedScale, object MaxCachedScale)
		{
			this.InMap = InMap;
			this.OutputFile = OutputFile;
			this.ServiceType = ServiceType;
			this.MinCachedScale = MinCachedScale;
			this.MaxCachedScale = MaxCachedScale;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Vector Tile Package</para>
		/// </summary>
		public override string DisplayName => "Create Vector Tile Package";

		/// <summary>
		/// <para>Tool Name : CreateVectorTilePackage</para>
		/// </summary>
		public override string ToolName => "CreateVectorTilePackage";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateVectorTilePackage</para>
		/// </summary>
		public override string ExcuteName => "management.CreateVectorTilePackage";

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
		public override object[] Parameters => new object[] { InMap, OutputFile, ServiceType, TilingScheme, TileStructure, MinCachedScale, MaxCachedScale, IndexPolygons, Summary, Tags };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>The map from which tiles are generated and packaged. The input map must have metadata description and tags.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>The output vector tile package. The file extension of the package is .vtpk.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutputFile { get; set; }

		/// <summary>
		/// <para>Package for ArcGIS Online | Bing Maps | Google Maps</para>
		/// <para>Determines whether the tiling scheme will be generated from an existing map service or if map tiles will be generated for ArcGIS Online, Bing Maps, and Google Maps.</para>
		/// <para>Checked—The ArcGIS Online/Bing Maps/Google Maps tiling scheme is used. The ArcGIS Online/Bing Maps/Google Maps tiling scheme allows you to overlay your cache tiles with tiles from these online mapping services. ArcGIS Pro includes this tiling scheme as a built-in option when loading a tiling scheme. When you choose this tiling scheme, the data frame of your source map must use the WGS 1984 Web Mercator (Auxiliary Sphere) projected coordinate system. This is the default.</para>
		/// <para>Unchecked—Tiling scheme from an existing vector tile service will be used. Only tiling schemes with scales that double in progression through levels and have 512-by-512 tile size are supported. You must specify a vector tile service or tiling scheme file in the tiling_scheme parameter.</para>
		/// <para><see cref="ServiceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ServiceType { get; set; } = "true";

		/// <summary>
		/// <para>Tiling scheme</para>
		/// <para>A vector tile service or tiling scheme file to be used if the Package for ArcGIS Online | Bing Maps | Google Maps parameter is unchecked. The tiling scheme tile size must be 512 by 512 and must have consecutive scales in a ratio of two.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object TilingScheme { get; set; }

		/// <summary>
		/// <para>Tiling Format</para>
		/// <para>Specifies whether the tile generation structure is optimized with an indexed structure or as a flat array of all tiles at all levels of detail. The optimized indexed structure is the default and results in a smaller cache.</para>
		/// <para>Indexed—Produce tiles based on an index of feature density that optimizes the tile generation and file sizes. This is the default.</para>
		/// <para>Flat—Produce regular tiles for each level of detail without regard to feature density. This cache is larger than that produced with an indexed structure.</para>
		/// <para><see cref="TileStructureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TileStructure { get; set; } = "INDEXED";

		/// <summary>
		/// <para>Minimum Cached Scale</para>
		/// <para>The minimum (smallest) scale at which tiles are generated. This does not have to be the smallest scale in your tiling scheme. The minimum cached scale determines which scales are used to generate cache.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		[GPCodedValueDomain()]
		public object MinCachedScale { get; set; }

		/// <summary>
		/// <para>Maximum Cached Scale</para>
		/// <para>The maximum (largest) scale at which tiles are generated. This does not have to be the largest scale in your tiling scheme. The maximum cached scale determines which scales are used to generate cache.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		[GPCodedValueDomain()]
		public object MaxCachedScale { get; set; }

		/// <summary>
		/// <para>Index Polygons</para>
		/// <para>Specifies a pregenerated index of tiles based on feature density, applicable only when the Tiling Format parameter is Indexed. Use the Create Vector Tile Index tool to create index polygons. If no index polygons are specified in this parameter, optimized index polygons are generated during processing to aid in tile creation, but they are not saved or output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object IndexPolygons { get; set; }

		/// <summary>
		/// <para>Summary</para>
		/// <para>Adds summary information to properties of the output vector tile package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Summary { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>Adds tag information to the properties of the output vector tile package. Separate multiple tags with commas or semicolons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Tags { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Package for ArcGIS Online | Bing Maps | Google Maps</para>
		/// </summary>
		public enum ServiceTypeEnum 
		{
			/// <summary>
			/// <para>Checked—The ArcGIS Online/Bing Maps/Google Maps tiling scheme is used. The ArcGIS Online/Bing Maps/Google Maps tiling scheme allows you to overlay your cache tiles with tiles from these online mapping services. ArcGIS Pro includes this tiling scheme as a built-in option when loading a tiling scheme. When you choose this tiling scheme, the data frame of your source map must use the WGS 1984 Web Mercator (Auxiliary Sphere) projected coordinate system. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ONLINE")]
			ONLINE,

			/// <summary>
			/// <para>Unchecked—Tiling scheme from an existing vector tile service will be used. Only tiling schemes with scales that double in progression through levels and have 512-by-512 tile size are supported. You must specify a vector tile service or tiling scheme file in the tiling_scheme parameter.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXISTING")]
			EXISTING,

		}

		/// <summary>
		/// <para>Tiling Format</para>
		/// </summary>
		public enum TileStructureEnum 
		{
			/// <summary>
			/// <para>Indexed—Produce tiles based on an index of feature density that optimizes the tile generation and file sizes. This is the default.</para>
			/// </summary>
			[GPValue("INDEXED")]
			[Description("Indexed")]
			Indexed,

			/// <summary>
			/// <para>Flat—Produce regular tiles for each level of detail without regard to feature density. This cache is larger than that produced with an indexed structure.</para>
			/// </summary>
			[GPValue("FLAT")]
			[Description("Flat")]
			Flat,

		}

#endregion
	}
}
