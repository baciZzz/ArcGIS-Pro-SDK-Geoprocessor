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
	/// <para>Slice</para>
	/// <para>Slices or reclassifies the range of values of the input cells into zones of equal interval or equal area, or by natural breaks.</para>
	/// </summary>
	public class Slice : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster to be reclassified.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output reclassified raster.</para>
		/// <para>The output will always be of integer type.</para>
		/// </param>
		/// <param name="NumberZones">
		/// <para>Number of output zones</para>
		/// <para>The number of zones to reclassify the input raster into.</para>
		/// <para>When the slice method is Equal area, the output raster will have the defined number of zones, with a similar number of cells in each.</para>
		/// <para>When Equal interval is used, the output raster will have the defined number of zones, each containing equal value ranges on the output raster.</para>
		/// <para>When Natural breaks is used, the output raster will have the defined number of zones, with the number of cells in each determined by the class breaks.</para>
		/// </param>
		public Slice(object InRaster, object OutRaster, object NumberZones)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
			this.NumberZones = NumberZones;
		}

		/// <summary>
		/// <para>Tool Display Name : Slice</para>
		/// </summary>
		public override string DisplayName => "Slice";

		/// <summary>
		/// <para>Tool Name : Slice</para>
		/// </summary>
		public override string ToolName => "Slice";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Slice</para>
		/// </summary>
		public override string ExcuteName => "3d.Slice";

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
		public override object[] Parameters => new object[] { InRaster, OutRaster, NumberZones, SliceType, BaseOutputZone };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input raster to be reclassified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output reclassified raster.</para>
		/// <para>The output will always be of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Number of output zones</para>
		/// <para>The number of zones to reclassify the input raster into.</para>
		/// <para>When the slice method is Equal area, the output raster will have the defined number of zones, with a similar number of cells in each.</para>
		/// <para>When Equal interval is used, the output raster will have the defined number of zones, each containing equal value ranges on the output raster.</para>
		/// <para>When Natural breaks is used, the output raster will have the defined number of zones, with the number of cells in each determined by the class breaks.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPNumericDomain()]
		public object NumberZones { get; set; }

		/// <summary>
		/// <para>Slice method</para>
		/// <para>The manner in which to slice the values in the input raster.</para>
		/// <para>Equal interval—Determines the range of the input values and divides the range into the specified number of output zones. Each zone on the sliced output raster has the potential of having input cell values that have the same range from the extremes. This is the default.</para>
		/// <para>Equal area—Specifies that the input values will be divided into the specified number of output zones, with each zone having a similar number of cells. Each zone will represent a similar amount of area.</para>
		/// <para>Natural breaks—Specifies that the classes will be based on natural groupings inherent in the data. Break points are identified by choosing the class breaks that best group similar values and that maximize the differences between classes. The cell values are divided into classes whose boundaries are set when there are relatively big jumps in the data values.</para>
		/// <para><see cref="SliceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SliceType { get; set; } = "EQUAL_INTERVAL";

		/// <summary>
		/// <para>Base zone for output</para>
		/// <para>Defines the lowest zone value on the output raster dataset.</para>
		/// <para>The default value is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object BaseOutputZone { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Slice SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Slice method</para>
		/// </summary>
		public enum SliceTypeEnum 
		{
			/// <summary>
			/// <para>Equal interval—Determines the range of the input values and divides the range into the specified number of output zones. Each zone on the sliced output raster has the potential of having input cell values that have the same range from the extremes. This is the default.</para>
			/// </summary>
			[GPValue("EQUAL_INTERVAL")]
			[Description("Equal interval")]
			Equal_interval,

			/// <summary>
			/// <para>Equal area—Specifies that the input values will be divided into the specified number of output zones, with each zone having a similar number of cells. Each zone will represent a similar amount of area.</para>
			/// </summary>
			[GPValue("EQUAL_AREA")]
			[Description("Equal area")]
			Equal_area,

			/// <summary>
			/// <para>Natural breaks—Specifies that the classes will be based on natural groupings inherent in the data. Break points are identified by choosing the class breaks that best group similar values and that maximize the differences between classes. The cell values are divided into classes whose boundaries are set when there are relatively big jumps in the data values.</para>
			/// </summary>
			[GPValue("NATURAL_BREAKS")]
			[Description("Natural breaks")]
			Natural_breaks,

		}

#endregion
	}
}
