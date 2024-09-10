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
	/// <para>Make Image Server Layer</para>
	/// <para>Creates a temporary raster layer from an image service. The layer that is created will not persist after the session ends unless the document is saved.</para>
	/// </summary>
	public class MakeImageServerLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InImageService">
		/// <para>Input Image Service</para>
		/// <para>The name of the input image service or the SOAP URL that references the image service. Browse to or type the input image service. This tool can also accept a SOAP URL that references the image service.</para>
		/// <para>An example of using the image service name called ProjectX is: C:\MyProject\ServerConnection.ags\ProjectX.ImageServer.</para>
		/// <para>An example of a URL is http://AGSServer:8399/arcgis/services/ISName/ImageServer.</para>
		/// </param>
		/// <param name="OutImageserverLayer">
		/// <para>Output Image Server Layer</para>
		/// <para>The name of the output image layer.</para>
		/// </param>
		public MakeImageServerLayer(object InImageService, object OutImageserverLayer)
		{
			this.InImageService = InImageService;
			this.OutImageserverLayer = OutImageserverLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Image Server Layer</para>
		/// </summary>
		public override string DisplayName() => "Make Image Server Layer";

		/// <summary>
		/// <para>Tool Name : MakeImageServerLayer</para>
		/// </summary>
		public override string ToolName() => "MakeImageServerLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeImageServerLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.MakeImageServerLayer";

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
		public override object[] Parameters() => new object[] { InImageService, OutImageserverLayer, Template, BandIndex, MosaicMethod, OrderField, OrderBaseValue, LockRasterid, CellSize, WhereClause, ProcessingTemplate };

		/// <summary>
		/// <para>Input Image Service</para>
		/// <para>The name of the input image service or the SOAP URL that references the image service. Browse to or type the input image service. This tool can also accept a SOAP URL that references the image service.</para>
		/// <para>An example of using the image service name called ProjectX is: C:\MyProject\ServerConnection.ags\ProjectX.ImageServer.</para>
		/// <para>An example of a URL is http://AGSServer:8399/arcgis/services/ISName/ImageServer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InImageService { get; set; }

		/// <summary>
		/// <para>Output Image Server Layer</para>
		/// <para>The name of the output image layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object OutImageserverLayer { get; set; }

		/// <summary>
		/// <para>Template Extent</para>
		/// <para>The output extent of the image layer.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Current Display Extent—The extent is equal to the data frame or visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object Template { get; set; }

		/// <summary>
		/// <para>Bands</para>
		/// <para>Choose which bands to export for the layer. If no bands are specified, all the bands will be used in the output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object BandIndex { get; set; }

		/// <summary>
		/// <para>Mosaic Method</para>
		/// <para>The mosaic method defines how the mosaic is created from different rasters.</para>
		/// <para>Seamline—Smooth transitions between images using seamlines.</para>
		/// <para>Northwest—Display imagery that is closest to the northwest corner of the mosaic dataset boundary.</para>
		/// <para>Center—Display imagery that is closest to the center of the screen.</para>
		/// <para>Lock raster—Select specific raster datasets to display.</para>
		/// <para>By attribute—Display and prioritize imagery based on a field in the attribute table.</para>
		/// <para>Nadir—Display the rasters with viewing angles closest to zero.</para>
		/// <para>Viewpoint—Display imagery that is closest to a selected viewing angle.</para>
		/// <para>None—Order rasters based on the ObjectID in the mosaic dataset attribute table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Mosaic Properties")]
		public object MosaicMethod { get; set; }

		/// <summary>
		/// <para>Order Field</para>
		/// <para>The default field to use to order the rasters when the mosaic method is By_Attribute. The list of fields is defined as those in the service table that are of type metadata and are integer (for example, the values can represent dates or cloud cover percentage).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Mosaic Properties")]
		public object OrderField { get; set; }

		/// <summary>
		/// <para>Order Base Value</para>
		/// <para>The images are sorted based on the difference between this input value and the attribute value in the specified field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Mosaic Properties")]
		public object OrderBaseValue { get; set; }

		/// <summary>
		/// <para>Lock Raster ID</para>
		/// <para>The raster ID or raster name to which the service should be locked, such that only the specified rasters are displayed. If left blank (undefined), it will be similar to the system default. Multiple IDs can be defined as a semicolon-delimited list.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Mosaic Properties")]
		public object LockRasterid { get; set; }

		/// <summary>
		/// <para>Output Cell Size</para>
		/// <para>The cell size for the output image service layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>Using SQL, you can define a query or use the Query Builder to build a query.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Processing Template</para>
		/// <para>The raster function processing template that can be applied on the output image service layer.</para>
		/// <para>None—No processing template.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ProcessingTemplate { get; set; } = "None";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeImageServerLayer SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

	}
}
