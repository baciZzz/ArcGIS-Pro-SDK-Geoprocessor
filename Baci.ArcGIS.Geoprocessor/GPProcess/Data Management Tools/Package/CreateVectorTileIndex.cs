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
	/// <para>Create Vector Tile Index</para>
	/// <para>Create Vector Tile Index</para>
	/// <para>Creates a multiscale mesh of polygons that can be used as index polygons when creating vector tile packages.</para>
	/// </summary>
	public class CreateVectorTileIndex : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Input Map</para>
		/// <para>The input map with the feature distribution and vertex density that dictate the size and arrangement of output polygons. The input map is typically one that you will subsequently use to create vector tiles using the Create Vector Tile Package tool.</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output Tile Feature Class</para>
		/// <para>The output polygon feature class of indexed tiles at each level of detail. Each tile encloses a manageable number of input vertices not exceeding the number specified by the Maximum Vertex Count parameter.</para>
		/// </param>
		/// <param name="ServiceType">
		/// <para>Package for ArcGIS Online | Bing Maps | Google Maps</para>
		/// <para>Specifies whether the tiling scheme will be generated from an existing map service or for ArcGIS Online, Bing Maps, and Google Maps.</para>
		/// <para>Checked—The ArcGIS Online/Bing Maps/Google Maps tiling scheme will be used. The ArcGIS Online/Bing Maps/Google Maps tiling scheme allows you to overlay your cache tiles with tiles from these online mapping services. ArcGIS Pro includes this tiling scheme as a built-in option when loading a tiling scheme. When you check this parameter, the data frame of your source map must use the WGS 1984 Web Mercator (Auxiliary Sphere) projected coordinate system. This is the default.</para>
		/// <para>Unchecked—The tiling scheme from an existing vector tile service will be used. Only tiling schemes with scales that double in progression through levels and have 512-by-512 tile size are supported. You must specify a vector tile service or tiling scheme file in the Tiling scheme parameter.</para>
		/// <para><see cref="ServiceTypeEnum"/></para>
		/// </param>
		public CreateVectorTileIndex(object InMap, object OutFeatureclass, object ServiceType)
		{
			this.InMap = InMap;
			this.OutFeatureclass = OutFeatureclass;
			this.ServiceType = ServiceType;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Vector Tile Index</para>
		/// </summary>
		public override string DisplayName() => "Create Vector Tile Index";

		/// <summary>
		/// <para>Tool Name : CreateVectorTileIndex</para>
		/// </summary>
		public override string ToolName() => "CreateVectorTileIndex";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateVectorTileIndex</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateVectorTileIndex";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMap, OutFeatureclass, ServiceType, TilingScheme, VertexCount };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>The input map with the feature distribution and vertex density that dictate the size and arrangement of output polygons. The input map is typically one that you will subsequently use to create vector tiles using the Create Vector Tile Package tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Output Tile Feature Class</para>
		/// <para>The output polygon feature class of indexed tiles at each level of detail. Each tile encloses a manageable number of input vertices not exceeding the number specified by the Maximum Vertex Count parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>Package for ArcGIS Online | Bing Maps | Google Maps</para>
		/// <para>Specifies whether the tiling scheme will be generated from an existing map service or for ArcGIS Online, Bing Maps, and Google Maps.</para>
		/// <para>Checked—The ArcGIS Online/Bing Maps/Google Maps tiling scheme will be used. The ArcGIS Online/Bing Maps/Google Maps tiling scheme allows you to overlay your cache tiles with tiles from these online mapping services. ArcGIS Pro includes this tiling scheme as a built-in option when loading a tiling scheme. When you check this parameter, the data frame of your source map must use the WGS 1984 Web Mercator (Auxiliary Sphere) projected coordinate system. This is the default.</para>
		/// <para>Unchecked—The tiling scheme from an existing vector tile service will be used. Only tiling schemes with scales that double in progression through levels and have 512-by-512 tile size are supported. You must specify a vector tile service or tiling scheme file in the Tiling scheme parameter.</para>
		/// <para><see cref="ServiceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ServiceType { get; set; } = "true";

		/// <summary>
		/// <para>Tiling scheme</para>
		/// <para>The vector tile service or tiling scheme file to be used if the Package for ArcGIS Online | Bing Maps | Google Maps parameter is not checked. The tiling scheme tile size must be 512 by 512 and must have consecutive scales in a ratio of two.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object TilingScheme { get; set; }

		/// <summary>
		/// <para>Maximum Vertex Count</para>
		/// <para>The ideal number of vertices from all visible layers to be enclosed by each polygon in the output feature class. The default value is the recommended count of 10,000 vertices.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object VertexCount { get; set; } = "10000";

		#region InnerClass

		/// <summary>
		/// <para>Package for ArcGIS Online | Bing Maps | Google Maps</para>
		/// </summary>
		public enum ServiceTypeEnum 
		{
			/// <summary>
			/// <para>Checked—The ArcGIS Online/Bing Maps/Google Maps tiling scheme will be used. The ArcGIS Online/Bing Maps/Google Maps tiling scheme allows you to overlay your cache tiles with tiles from these online mapping services. ArcGIS Pro includes this tiling scheme as a built-in option when loading a tiling scheme. When you check this parameter, the data frame of your source map must use the WGS 1984 Web Mercator (Auxiliary Sphere) projected coordinate system. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ONLINE")]
			ONLINE,

			/// <summary>
			/// <para>Unchecked—The tiling scheme from an existing vector tile service will be used. Only tiling schemes with scales that double in progression through levels and have 512-by-512 tile size are supported. You must specify a vector tile service or tiling scheme file in the Tiling scheme parameter.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXISTING")]
			EXISTING,

		}

#endregion
	}
}
