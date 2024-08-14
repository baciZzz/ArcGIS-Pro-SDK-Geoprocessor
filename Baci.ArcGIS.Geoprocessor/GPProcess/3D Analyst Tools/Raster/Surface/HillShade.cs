using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>HillShade</para>
	/// <para>Creates a shaded relief from a surface raster by considering the illumination source angle and shadows.</para>
	/// </summary>
	public class HillShade : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input surface raster.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output hillshade raster.</para>
		/// <para>The hillshade raster has an integer value range of 0 to 255.</para>
		/// </param>
		public HillShade(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : HillShade</para>
		/// </summary>
		public override string DisplayName => "HillShade";

		/// <summary>
		/// <para>Tool Name : HillShade</para>
		/// </summary>
		public override string ToolName => "HillShade";

		/// <summary>
		/// <para>Tool Excute Name : 3d.HillShade</para>
		/// </summary>
		public override string ExcuteName => "3d.HillShade";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRaster, OutRaster, Azimuth, Altitude, ModelShadows, ZFactor };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input surface raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output hillshade raster.</para>
		/// <para>The hillshade raster has an integer value range of 0 to 255.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Azimuth</para>
		/// <para>Azimuth angle of the light source.</para>
		/// <para>The azimuth is expressed in positive degrees from 0 to 360, measured clockwise from north.</para>
		/// <para>The default is 315 degrees.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object Azimuth { get; set; } = "315";

		/// <summary>
		/// <para>Altitude</para>
		/// <para>Altitude angle of the light source above the horizon.</para>
		/// <para>The altitude is expressed in positive degrees, with 0 degrees at the horizon and 90 degrees directly overhead.</para>
		/// <para>The default is 45 degrees.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object Altitude { get; set; } = "45";

		/// <summary>
		/// <para>Model shadows</para>
		/// <para>Type of shaded relief to be generated.</para>
		/// <para>Unchecked—The output raster only considers local illumination angles; the effects of shadows are not considered.The output values can range from 0 to 255, with 0 representing the darkest areas, and 255 the brightest. This is the default.</para>
		/// <para>Checked—The output shaded raster considers both local illumination angles and shadows.The output values range from 0 to 255, with 0 representing the shadow areas, and 255 the brightest.</para>
		/// <para><see cref="ModelShadowsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ModelShadows { get; set; } = "false";

		/// <summary>
		/// <para>Z factor</para>
		/// <para>The number of ground x,y units in one surface z-unit.</para>
		/// <para>The z-factor adjusts the units of measure for the z-units when they are different from the x,y units of the input surface. The z-values of the input surface are multiplied by the z-factor when calculating the final output surface.</para>
		/// <para>If the x,y units and z-units are in the same units of measure, the z-factor is 1. This is the default.</para>
		/// <para>If the x,y units and z-units are in different units of measure, the z-factor must be set to the appropriate factor or the results will be incorrect. For example, if the z-units are feet and the x,y units are meters, you would use a z-factor of 0.3048 to convert the z-units from feet to meters (1 foot = 0.3048 meter).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public HillShade SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Model shadows</para>
		/// </summary>
		public enum ModelShadowsEnum 
		{
			/// <summary>
			/// <para>Unchecked—The output raster only considers local illumination angles; the effects of shadows are not considered.The output values can range from 0 to 255, with 0 representing the darkest areas, and 255 the brightest. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SHADOWS")]
			NO_SHADOWS,

			/// <summary>
			/// <para>Checked—The output shaded raster considers both local illumination angles and shadows.The output values range from 0 to 255, with 0 representing the shadow areas, and 255 the brightest.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SHADOWS")]
			SHADOWS,

		}

#endregion
	}
}
