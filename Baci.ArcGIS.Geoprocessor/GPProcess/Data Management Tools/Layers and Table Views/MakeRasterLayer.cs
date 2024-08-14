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
	/// <para>Make Raster Layer</para>
	/// <para>Creates a raster layer from an input raster dataset or layer file. The layer created by the tool is temporary and will not persist after the session ends unless the layer is saved to disk or the map document is saved.</para>
	/// </summary>
	public class MakeRasterLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The path and name of the input raster dataset.</para>
		/// <para>You can use a raster layer from a GeoPackage as the input. To reference a raster within a GeoPackage, type the name of the path, followed by the name of the GeoPackage and the name of the raster. For example, c:\data\sample.gpkg\raster_tile would be your input raster, where sample.gpkg is the name of the GeoPackage and raster_tile is the raster dataset within the package.</para>
		/// </param>
		/// <param name="OutRasterlayer">
		/// <para>Output raster layer name</para>
		/// <para>The name of the layer to create.</para>
		/// </param>
		public MakeRasterLayer(object InRaster, object OutRasterlayer)
		{
			this.InRaster = InRaster;
			this.OutRasterlayer = OutRasterlayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Raster Layer</para>
		/// </summary>
		public override string DisplayName => "Make Raster Layer";

		/// <summary>
		/// <para>Tool Name : MakeRasterLayer</para>
		/// </summary>
		public override string ToolName => "MakeRasterLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeRasterLayer</para>
		/// </summary>
		public override string ExcuteName => "management.MakeRasterLayer";

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
		public override string[] ValidEnvironments => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRaster, OutRasterlayer, WhereClause, Envelope, BandIndex };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The path and name of the input raster dataset.</para>
		/// <para>You can use a raster layer from a GeoPackage as the input. To reference a raster within a GeoPackage, type the name of the path, followed by the name of the GeoPackage and the name of the raster. For example, c:\data\sample.gpkg\raster_tile would be your input raster, where sample.gpkg is the name of the GeoPackage and raster_tile is the raster dataset within the package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster layer name</para>
		/// <para>The name of the layer to create.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object OutRasterlayer { get; set; }

		/// <summary>
		/// <para>Where clause</para>
		/// <para>Using SQL, you can define a query or use the Query Builder to build a query.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Envelope</para>
		/// <para>The output extent can be specified by defining the four coordinates or by using the extent of an existing layer.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Current Display Extent—The extent is equal to the data frame or visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object Envelope { get; set; }

		/// <summary>
		/// <para>Bands</para>
		/// <para>Choose which bands to export for the layer. If no bands are specified, all the bands will be used in the output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object BandIndex { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeRasterLayer SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
