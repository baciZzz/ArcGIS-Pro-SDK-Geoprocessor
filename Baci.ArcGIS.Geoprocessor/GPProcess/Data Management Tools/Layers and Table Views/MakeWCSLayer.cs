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
	/// <para>Make WCS Layer</para>
	/// <para>Make WCS Layer</para>
	/// <para>Creates a temporary raster layer from a WCS service.</para>
	/// </summary>
	public class MakeWCSLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWcsCoverage">
		/// <para>Input WCS Coverage</para>
		/// <para>Browse to the input WCS service. This tool can also accept a URL that references the WCS service.</para>
		/// <para>If a WCS server URL is used, the URL should include the coverage name and version information. If only the URL is entered, the tool will automatically take the first coverage and use the default version (1.0.0) to create the WCS layer.</para>
		/// <para>An example of a URL that includes the coverage name and version is http://ServerName/arcgis/services/serviceName/ImageServer/WCSServer?coverage=rasterDRGs&amp;version=1.1.1.</para>
		/// <para>In this example, http://ServerName/arcgis/services/serviceName/ImageServer/WCSServer? is the URL. The coverage specified is coverage=rasterDRGs, and the version is &amp;version=1.1.1.</para>
		/// <para>To get the coverage names on a WCS server, use the WCS GetCapabilities request. An example of WCS request is http://ServerName/arcgis/services/serviceName/ImageServer/WCSServer?request=getcapabilities&amp;service=wcs.</para>
		/// </param>
		/// <param name="OutWcsLayer">
		/// <para>Output WCS Layer</para>
		/// <para>The name of the output WCS layer.</para>
		/// </param>
		public MakeWCSLayer(object InWcsCoverage, object OutWcsLayer)
		{
			this.InWcsCoverage = InWcsCoverage;
			this.OutWcsLayer = OutWcsLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Make WCS Layer</para>
		/// </summary>
		public override string DisplayName() => "Make WCS Layer";

		/// <summary>
		/// <para>Tool Name : MakeWCSLayer</para>
		/// </summary>
		public override string ToolName() => "MakeWCSLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeWCSLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.MakeWCSLayer";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWcsCoverage, OutWcsLayer, Template!, BandIndex! };

		/// <summary>
		/// <para>Input WCS Coverage</para>
		/// <para>Browse to the input WCS service. This tool can also accept a URL that references the WCS service.</para>
		/// <para>If a WCS server URL is used, the URL should include the coverage name and version information. If only the URL is entered, the tool will automatically take the first coverage and use the default version (1.0.0) to create the WCS layer.</para>
		/// <para>An example of a URL that includes the coverage name and version is http://ServerName/arcgis/services/serviceName/ImageServer/WCSServer?coverage=rasterDRGs&amp;version=1.1.1.</para>
		/// <para>In this example, http://ServerName/arcgis/services/serviceName/ImageServer/WCSServer? is the URL. The coverage specified is coverage=rasterDRGs, and the version is &amp;version=1.1.1.</para>
		/// <para>To get the coverage names on a WCS server, use the WCS GetCapabilities request. An example of WCS request is http://ServerName/arcgis/services/serviceName/ImageServer/WCSServer?request=getcapabilities&amp;service=wcs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InWcsCoverage { get; set; }

		/// <summary>
		/// <para>Output WCS Layer</para>
		/// <para>The name of the output WCS layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object OutWcsLayer { get; set; }

		/// <summary>
		/// <para>Template Extent</para>
		/// <para>The output extent of the WCS layer.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Current Display Extent—The extent is equal to the data frame or visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? Template { get; set; }

		/// <summary>
		/// <para>Bands</para>
		/// <para>The bands that will be exported for the layer. If no bands are specified, all the bands will be used in the output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? BandIndex { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeWCSLayer SetEnviroment(object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

	}
}
