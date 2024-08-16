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
	/// <para>Observer Points</para>
	/// <para>Identifies which observer points are visible from each raster surface location.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.Analyst3DTools.Viewshed2"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.Analyst3DTools.Viewshed2))]
	public class ObserverPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input surface raster.</para>
		/// </param>
		/// <param name="InObserverPointFeatures">
		/// <para>Input point observer features</para>
		/// <para>The point feature class that identifies the observer locations.</para>
		/// <para>The maximum number of points allowed is 16.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>The output identifies exactly which observer points are visible from each raster surface location.</para>
		/// </param>
		public ObserverPoints(object InRaster, object InObserverPointFeatures, object OutRaster)
		{
			this.InRaster = InRaster;
			this.InObserverPointFeatures = InObserverPointFeatures;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Observer Points</para>
		/// </summary>
		public override string DisplayName => "Observer Points";

		/// <summary>
		/// <para>Tool Name : ObserverPoints</para>
		/// </summary>
		public override string ToolName => "ObserverPoints";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ObserverPoints</para>
		/// </summary>
		public override string ExcuteName => "3d.ObserverPoints";

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
		public override object[] Parameters => new object[] { InRaster, InObserverPointFeatures, OutRaster, ZFactor, CurvatureCorrection, RefractivityCoefficient, OutAglRaster };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input surface raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = true)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Input point observer features</para>
		/// <para>The point feature class that identifies the observer locations.</para>
		/// <para>The maximum number of points allowed is 16.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer")]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		[GeometryType("Point", "Multipoint")]
		public object InObserverPointFeatures { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>The output identifies exactly which observer points are visible from each raster surface location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

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
		/// <para>Use earth curvature corrections</para>
		/// <para>Specifies whether correction for the earth&apos;s curvature will be applied.</para>
		/// <para>Unchecked—No curvature correction will be applied. This is the default.</para>
		/// <para>Checked—Curvature correction will be applied.</para>
		/// <para><see cref="CurvatureCorrectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CurvatureCorrection { get; set; } = "false";

		/// <summary>
		/// <para>Refractivity coefficient</para>
		/// <para>The coefficient of the refraction of visible light in air.</para>
		/// <para>The default value is 0.13.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object RefractivityCoefficient { get; set; } = "0.13";

		/// <summary>
		/// <para>Output above ground level raster</para>
		/// <para>The output above ground level (AGL) raster.</para>
		/// <para>The AGL result is a raster where each cell value is the minimum height that must be added to an otherwise nonvisible cell to make it visible by at least one observer.</para>
		/// <para>Cells that were already visible will have a value of 0 in this output raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutAglRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ObserverPoints SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Use earth curvature corrections</para>
		/// </summary>
		public enum CurvatureCorrectionEnum 
		{
			/// <summary>
			/// <para>Unchecked—No curvature correction will be applied. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("FLAT_EARTH")]
			FLAT_EARTH,

			/// <summary>
			/// <para>Checked—Curvature correction will be applied.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CURVED_EARTH")]
			CURVED_EARTH,

		}

#endregion
	}
}
