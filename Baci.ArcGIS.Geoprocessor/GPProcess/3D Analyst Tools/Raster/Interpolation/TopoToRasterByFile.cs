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
	/// <para>Topo to Raster by File</para>
	/// <para>Interpolates a hydrologically correct raster surface from point, line, and polygon data using parameters specified in a file.</para>
	/// </summary>
	public class TopoToRasterByFile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParameterFile">
		/// <para>Input parameter file</para>
		/// <para>The input ASCII text file containing the inputs and parameters to use for the interpolation.</para>
		/// <para>The file is typically created from a previous run of Topo to Raster with the optional output parameter file specified.</para>
		/// <para>In order to test the outcome of changing the parameters, it is easier to make edits to this file and rerun the interpolation than to correctly issue the Topo to Raster tool each time.</para>
		/// </param>
		/// <param name="OutSurfaceRaster">
		/// <para>Output surface raster</para>
		/// <para>The output interpolated surface raster.</para>
		/// <para>It is always a floating-point raster.</para>
		/// </param>
		public TopoToRasterByFile(object InParameterFile, object OutSurfaceRaster)
		{
			this.InParameterFile = InParameterFile;
			this.OutSurfaceRaster = OutSurfaceRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Topo to Raster by File</para>
		/// </summary>
		public override string DisplayName => "Topo to Raster by File";

		/// <summary>
		/// <para>Tool Name : TopoToRasterByFile</para>
		/// </summary>
		public override string ToolName => "TopoToRasterByFile";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TopoToRasterByFile</para>
		/// </summary>
		public override string ExcuteName => "3d.TopoToRasterByFile";

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
		public override string[] ValidEnvironments => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "maintainSpatialIndex", "mask", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "snapRaster", "tileSize", "transferDomains", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InParameterFile, OutSurfaceRaster, OutStreamFeatures!, OutSinkFeatures!, OutResidualFeature!, OutStreamCliffErrorFeature!, OutContourErrorFeature! };

		/// <summary>
		/// <para>Input parameter file</para>
		/// <para>The input ASCII text file containing the inputs and parameters to use for the interpolation.</para>
		/// <para>The file is typically created from a previous run of Topo to Raster with the optional output parameter file specified.</para>
		/// <para>In order to test the outcome of changing the parameters, it is easier to make edits to this file and rerun the interpolation than to correctly issue the Topo to Raster tool each time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object InParameterFile { get; set; }

		/// <summary>
		/// <para>Output surface raster</para>
		/// <para>The output interpolated surface raster.</para>
		/// <para>It is always a floating-point raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Output stream polyline features</para>
		/// <para>Output feature class of stream polyline features.</para>
		/// <para>The polyline features are coded as follows:</para>
		/// <para>1. Input stream line not over cliff.</para>
		/// <para>2. Input stream line over cliff (waterfall).</para>
		/// <para>3. Drainage enforcement clearing a spurious sink.</para>
		/// <para>4. Stream line determined from contour corner.</para>
		/// <para>5. Ridge line determined from contour corner.</para>
		/// <para>6. Code not used.</para>
		/// <para>7. Data stream line side conditions.</para>
		/// <para>8. Code not used.</para>
		/// <para>9. Line indicating large elevation data clearance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutStreamFeatures { get; set; }

		/// <summary>
		/// <para>Output remaining sink point features</para>
		/// <para>Output feature class of remaining sink point features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutSinkFeatures { get; set; }

		/// <summary>
		/// <para>Output residual point features</para>
		/// <para>The output point feature class of all the large elevation residuals as scaled by the local discretisation error.</para>
		/// <para>All the scaled residuals larger than 10 should be inspected for possible errors in input elevation and stream data. Large-scaled residuals indicate conflicts between input elevation data and streamline data. These may also be associated with poor automatic drainage enforcements. These conflicts can be remedied by providing additional streamline and/or point elevation data after first checking and correcting errors in existing input data. Large unscaled residuals usually indicate input elevation errors.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutResidualFeature { get; set; }

		/// <summary>
		/// <para>Output stream and cliff error point features</para>
		/// <para>The output point feature class of locations where possible stream and cliff errors occur.</para>
		/// <para>The locations where the streams have closed loops, distributaries, and streams over cliffs can be identified from the point feature class. Cliffs with neighboring cells that are inconsistent with the high and low sides of the cliff are also indicated. This can be a good indicator of cliffs with incorrect direction.</para>
		/// <para>Points are coded as follows:</para>
		/// <para>1. True circuit in data streamline network.</para>
		/// <para>2. Circuit in stream network as encoded on the out raster.</para>
		/// <para>3. Circuit in stream network via connecting lakes.</para>
		/// <para>4. Distributaries point.</para>
		/// <para>5. Stream over a cliff (waterfall).</para>
		/// <para>6. Points indicating multiple stream outflows from lakes.</para>
		/// <para>7. Code not used.</para>
		/// <para>8. Points beside cliffs with heights inconsistent with cliff direction.</para>
		/// <para>9. Code not used.</para>
		/// <para>10. Circular distributary removed.</para>
		/// <para>11. Distributary with no inflowing stream.</para>
		/// <para>12. Rasterized distributary in output cell different to where the data stream line distributary occurs.</para>
		/// <para>13. Error processing side conditions—an indicator of very complex streamline data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutStreamCliffErrorFeature { get; set; }

		/// <summary>
		/// <para>Output contour  error point features</para>
		/// <para>The output point feature class of possible errors pertaining to the input contour data.</para>
		/// <para>Contours with bias in height exceeding five times the standard deviation of the contour values as represented on the output raster are reported to this feature class. Contours that join other contours with a different elevation are flagged in this feature class by the code 1; this is a sure sign of a contour label error.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutContourErrorFeature { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TopoToRasterByFile SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , bool? maintainSpatialIndex = null , object? mask = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , bool? transferDomains = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainSpatialIndex: maintainSpatialIndex, mask: mask, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, transferDomains: transferDomains, workspace: workspace);
			return this;
		}

	}
}
