using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>IDW</para>
	/// <para>Uses the measured values surrounding the prediction location  to predict a value for any unsampled location, based on the assumption that things that are close to one another are more alike than those that are farther apart.</para>
	/// </summary>
	public class IDW : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input features</para>
		/// <para>The input point features containing the z-values to be interpolated.</para>
		/// </param>
		/// <param name="ZField">
		/// <para>Z value field</para>
		/// <para>Field that holds a height or magnitude value for each point. This can be a numeric field or the Shape field if the input features contain z-values or m-values.</para>
		/// </param>
		public IDW(object InFeatures, object ZField)
		{
			this.InFeatures = InFeatures;
			this.ZField = ZField;
		}

		/// <summary>
		/// <para>Tool Display Name : IDW</para>
		/// </summary>
		public override string DisplayName => "IDW";

		/// <summary>
		/// <para>Tool Name : IDW</para>
		/// </summary>
		public override string ToolName => "IDW";

		/// <summary>
		/// <para>Tool Excute Name : ga.IDW</para>
		/// </summary>
		public override string ExcuteName => "ga.IDW";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cellSize", "coincidentPoints", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, ZField, OutGaLayer, OutRaster, CellSize, Power, SearchNeighborhood, WeightField };

		/// <summary>
		/// <para>Input features</para>
		/// <para>The input point features containing the z-values to be interpolated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Z value field</para>
		/// <para>Field that holds a height or magnitude value for each point. This can be a numeric field or the Shape field if the input features contain z-values or m-values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object ZField { get; set; }

		/// <summary>
		/// <para>Output geostatistical layer</para>
		/// <para>The geostatistical layer produced. This layer is required output only if no output raster is requested.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGALayer()]
		public object OutGaLayer { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster. This raster is required output only if no output geostatistical layer is requested.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>The cell size at which the output raster will be created.</para>
		/// <para>This value can be explicitly set in the Environments by the Cell Size parameter.</para>
		/// <para>If not set, it is the shorter of the width or the height of the extent of the input point features, in the input spatial reference, divided by 250.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain()]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Power</para>
		/// <para>The exponent of distance that controls the significance of surrounding points on the interpolated value. A higher power results in less influence from distant points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain()]
		public object Power { get; set; } = "2";

		/// <summary>
		/// <para>Search neighborhood</para>
		/// <para>Defines which surrounding points will be used to control the output. Standard is the default.</para>
		/// <para>Standard</para>
		/// <para>Major semiaxis—The major semiaxis value of the searching neighborhood.</para>
		/// <para>Minor semiaxis—The minor semiaxis value of the searching neighborhood.</para>
		/// <para>Angle—The angle of rotation for the axis (circle) or semimajor axis (ellipse) of the moving window.</para>
		/// <para>Max neighbors—The maximum number of neighbors that will be used to estimate the value at the unknown location.</para>
		/// <para>Min neighbors—The minimum number of neighbors that will be used to estimate the value at the unknown location.</para>
		/// <para>Sector Type—The geometry of the neighborhood.</para>
		/// <para>One sector—Single ellipse.</para>
		/// <para>Four sectors—Ellipse divided into four sectors.</para>
		/// <para>Four sectors shifted—Ellipse divided into four sectors and shifted 45 degrees.</para>
		/// <para>Eight sectors—Ellipse divided into eight sectors.</para>
		/// <para>Smooth</para>
		/// <para>Major semiaxis—The major semiaxis value of the searching neighborhood.</para>
		/// <para>Minor semiaxis—The minor semiaxis value of the searching neighborhood.</para>
		/// <para>Angle—The angle of rotation for the axis (circle) or semimajor axis (ellipse) of the moving window.</para>
		/// <para>Smoothing factor—The Smooth Interpolation option creates an outer ellipse and an inner ellipse at a distance equal to the Major Semiaxis multiplied by the Smoothing factor. The points that fall outside the smallest ellipse but inside the largest ellipse are weighted using a sigmoidal function with a value between zero and one.</para>
		/// <para>Standard Circular</para>
		/// <para>Radius—The length of the radius of the search circle.</para>
		/// <para>Angle—The angle of rotation for the axis (circle) or semimajor axis (ellipse) of the moving window.</para>
		/// <para>Max neighbors—The maximum number of neighbors that will be used to estimate the value at the unknown location.</para>
		/// <para>Min neighbors—The minimum number of neighbors that will be used to estimate the value at the unknown location.</para>
		/// <para>Sector Type—The geometry of the neighborhood.</para>
		/// <para>One sector—Single ellipse.</para>
		/// <para>Four sectors—Ellipse divided into four sectors.</para>
		/// <para>Four sectors shifted—Ellipse divided into four sectors and shifted 45 degrees.</para>
		/// <para>Eight sectors—Ellipse divided into eight sectors.</para>
		/// <para>Smooth Circular</para>
		/// <para>Radius—The length of the radius of the search circle.</para>
		/// <para>Smoothing factor—The Smooth Interpolation option creates an outer ellipse and an inner ellipse at a distance equal to the Major Semiaxis multiplied by the Smoothing factor. The points that fall outside the smallest ellipse but inside the largest ellipse are weighted using a sigmoidal function with a value between zero and one.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGASearchNeighborhood()]
		[GPGASearchNeighborhoodDomain()]
		public object SearchNeighborhood { get; set; } = "NBRTYPE=Standard S_MAJOR=nan S_MINOR=nan ANGLE=0 NBR_MAX=15 NBR_MIN=10 SECTOR_TYPE=ONE_SECTOR";

		/// <summary>
		/// <para>Weight field</para>
		/// <para>Used to emphasize an observation. The larger the weight, the more impact it has on the prediction. For coincident observations, assign the largest weight to the most reliable measurement.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object WeightField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public IDW SetEnviroment(object cellSize = null , object coincidentPoints = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, coincidentPoints: coincidentPoints, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

	}
}
