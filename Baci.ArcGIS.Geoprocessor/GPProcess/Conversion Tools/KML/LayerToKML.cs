using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>Layer To KML</para>
	/// <para>Converts a feature or raster layer  into a KML file containing a translation of Esri geometries and symbology. This file is compressed using ZIP compression, has a .kmz extension, and can be read by any KML client including ArcGIS Earth, ArcGlobe, and Google Earth.</para>
	/// </summary>
	public class LayerToKML : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Layer">
		/// <para>Layer</para>
		/// <para>The feature or raster layer or layer file (.lyrx) to be converted to KML.</para>
		/// </param>
		/// <param name="OutKmzFile">
		/// <para>Output File</para>
		/// <para>The output KML file. This file is compressed and has a .kmz extension. It can be read by any KML client including ArcGIS Earth, ArcGlobe, and Google Earth.</para>
		/// </param>
		public LayerToKML(object Layer, object OutKmzFile)
		{
			this.Layer = Layer;
			this.OutKmzFile = OutKmzFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Layer To KML</para>
		/// </summary>
		public override string DisplayName => "Layer To KML";

		/// <summary>
		/// <para>Tool Name : LayerToKML</para>
		/// </summary>
		public override string ToolName => "LayerToKML";

		/// <summary>
		/// <para>Tool Excute Name : conversion.LayerToKML</para>
		/// </summary>
		public override string ExcuteName => "conversion.LayerToKML";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "maintainAttachments", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Layer, OutKmzFile, LayerOutputScale, IsComposite, BoundaryBoxExtent, ImageSize, DpiOfClient, IgnoreZvalue };

		/// <summary>
		/// <para>Layer</para>
		/// <para>The feature or raster layer or layer file (.lyrx) to be converted to KML.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Layer { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>The output KML file. This file is compressed and has a .kmz extension. It can be read by any KML client including ArcGIS Earth, ArcGlobe, and Google Earth.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutKmzFile { get; set; }

		/// <summary>
		/// <para>Layer Output Scale</para>
		/// <para>For raster layers, a value of 0 can be used to create one untiled output image. If a value greater than or equal to 1 is used, it will determine the output resolution of the raster. This parameter has no effect on layers that are not raster layers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object LayerOutputScale { get; set; } = "0";

		/// <summary>
		/// <para>Return single composite image</para>
		/// <para>Specifies whether the output will be a single composite image. If your layer is a raster, you can choose either option for this parameter without any visual difference.</para>
		/// <para>Checked—The output KML file will be a single composite image representing the raster or vector features in the source layer. The raster is draped over the terrain as a KML GroundOverlay. Use this option to reduce the size of the output KMZ file. When this option is used, individual features and layers in the KML will not be selectable.</para>
		/// <para>Unchecked—If your layer has vector features, they will be preserved as KML vectors.</para>
		/// <para><see cref="IsCompositeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Data Content Properties")]
		public object IsComposite { get; set; } = "false";

		/// <summary>
		/// <para>Extent to Export</para>
		/// <para>The geographic extent of the area to be exported. Either define the extent box (in the WGS84 coordinate system) or choose a layer or dataset that defines an extent.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Current Display Extent—The extent is equal to the data frame or visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Extent Properties")]
		public object BoundaryBoxExtent { get; set; }

		/// <summary>
		/// <para>Size of returned image (pixels)</para>
		/// <para>The size of the tiles for raster layers if the Layer Output Scale parameter value is set to a value greater than or equal to 1. This parameter has no effect on layers that are not raster layers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Output Image Properties")]
		public object ImageSize { get; set; } = "1024";

		/// <summary>
		/// <para>DPI of output image</para>
		/// <para>The device resolution for KML output when the Return single composite image parameter is checked. This parameter is used with the Size of returned image (pixels) parameter to control output image resolution.</para>
		/// <para>This parameter does not provide the ability to resample source rasters. Any input rasters will have a snapshot taken and included in the KML output as a simple .png image.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Output Image Properties")]
		public object DpiOfClient { get; set; } = "96";

		/// <summary>
		/// <para>Clamped features to ground</para>
		/// <para>Specifies whether to override the z-values of the input features.</para>
		/// <para>Checked—The z-values of the features will be overridden and draped over the terrain. This setting is used for features that do not have z-values. This is the default.</para>
		/// <para>Unchecked—The z-values of the features will be respected. The features will be drawn inside KML clients relative to sea level.</para>
		/// <para><see cref="IgnoreZvalueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IgnoreZvalue { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LayerToKML SetEnviroment(object extent = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Return single composite image</para>
		/// </summary>
		public enum IsCompositeEnum 
		{
			/// <summary>
			/// <para>Checked—The output KML file will be a single composite image representing the raster or vector features in the source layer. The raster is draped over the terrain as a KML GroundOverlay. Use this option to reduce the size of the output KMZ file. When this option is used, individual features and layers in the KML will not be selectable.</para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPOSITE")]
			COMPOSITE,

			/// <summary>
			/// <para>Unchecked—If your layer has vector features, they will be preserved as KML vectors.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_COMPOSITE")]
			NO_COMPOSITE,

		}

		/// <summary>
		/// <para>Clamped features to ground</para>
		/// </summary>
		public enum IgnoreZvalueEnum 
		{
			/// <summary>
			/// <para>Checked—The z-values of the features will be overridden and draped over the terrain. This setting is used for features that do not have z-values. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLAMPED_TO_GROUND")]
			CLAMPED_TO_GROUND,

			/// <summary>
			/// <para>Unchecked—The z-values of the features will be respected. The features will be drawn inside KML clients relative to sea level.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ABSOLUTE")]
			ABSOLUTE,

		}

#endregion
	}
}
