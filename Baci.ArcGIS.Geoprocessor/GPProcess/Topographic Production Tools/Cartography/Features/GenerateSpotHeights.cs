using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Generate Spot Heights</para>
	/// <para>Creates elevation point features based on contour tops and depressions. Elevation points are created in each top and depression. Point height values are populated based on a digital elevation model.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class GenerateSpotHeights : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InContourFeatures">
		/// <para>Input Contours</para>
		/// <para>The contours from which spot heights will be computed.</para>
		/// </param>
		/// <param name="InRaster">
		/// <para>Input Raster(s)</para>
		/// <para>The rasters used to derive the highest or lowest elevations in contour tops or depressions.</para>
		/// </param>
		/// <param name="TargetSpotFeatures">
		/// <para>Target Spot Features</para>
		/// <para>An existing point feature layer or feature class in which spot heights will be created.</para>
		/// </param>
		/// <param name="ContourHeightField">
		/// <para>Contour Height Field</para>
		/// <para>The field in the input contours that contains elevation values. The field type must be numeric.</para>
		/// </param>
		/// <param name="SpotHeightField">
		/// <para>Spot Height Field</para>
		/// <para>The field in the output spot heights to which elevation values will be written.</para>
		/// </param>
		public GenerateSpotHeights(object InContourFeatures, object InRaster, object TargetSpotFeatures, object ContourHeightField, object SpotHeightField)
		{
			this.InContourFeatures = InContourFeatures;
			this.InRaster = InRaster;
			this.TargetSpotFeatures = TargetSpotFeatures;
			this.ContourHeightField = ContourHeightField;
			this.SpotHeightField = SpotHeightField;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Spot Heights</para>
		/// </summary>
		public override string DisplayName => "Generate Spot Heights";

		/// <summary>
		/// <para>Tool Name : GenerateSpotHeights</para>
		/// </summary>
		public override string ToolName => "GenerateSpotHeights";

		/// <summary>
		/// <para>Tool Excute Name : topographic.GenerateSpotHeights</para>
		/// </summary>
		public override string ExcuteName => "topographic.GenerateSpotHeights";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InContourFeatures, InRaster, TargetSpotFeatures, ContourHeightField, SpotHeightField, SpotHeightSubtype!, AreaOfInterest!, UpdatedSpotFeatures!, Scale!, ZFactor! };

		/// <summary>
		/// <para>Input Contours</para>
		/// <para>The contours from which spot heights will be computed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InContourFeatures { get; set; }

		/// <summary>
		/// <para>Input Raster(s)</para>
		/// <para>The rasters used to derive the highest or lowest elevations in contour tops or depressions.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Target Spot Features</para>
		/// <para>An existing point feature layer or feature class in which spot heights will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object TargetSpotFeatures { get; set; }

		/// <summary>
		/// <para>Contour Height Field</para>
		/// <para>The field in the input contours that contains elevation values. The field type must be numeric.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object ContourHeightField { get; set; }

		/// <summary>
		/// <para>Spot Height Field</para>
		/// <para>The field in the output spot heights to which elevation values will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object SpotHeightField { get; set; }

		/// <summary>
		/// <para>Spot Height Subtype</para>
		/// <para>The spot height subtype value to be assigned to new spot height features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? SpotHeightSubtype { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>The extent where spot heights will be created. The area of interest (AOI) is the outer extent of all selected polygons in the feature layer. If none are selected, the extent of the raster will be used. This parameter does not accept point layers as valid input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object? AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Updated Spot Heights</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedSpotFeatures { get; set; }

		/// <summary>
		/// <para>Map Scale</para>
		/// <para>Specifies the scale that will be used to optimize spot heights (the scale of the cartographic product that will be printed). Setting a scale will set the default of the Z Factor parameter to a value that is appropriate for the scale value.</para>
		/// <para>1:5,000—The 1:5,000 cartographic product scale will be used.</para>
		/// <para>1:10,000—The 1:10,000 cartographic product scale will be used.</para>
		/// <para>1:12,500—The 1:12,500 cartographic product scale will be used.</para>
		/// <para>1:25,000—The 1:25,000 cartographic product scale will be used.</para>
		/// <para>1:50,000—The 1:50,000 cartographic product scale will be used. This is the default.</para>
		/// <para>1:100,000—The 1:100,000 cartographic product scale will be used.</para>
		/// <para>1:250,000—The 1:250,000 cartographic product scale will be used.</para>
		/// <para>1:500,000—The 1:500,000 cartographic product scale will be used.</para>
		/// <para>1:1,000,000—The 1:1,000,000 cartographic product scale will be used.</para>
		/// <para><see cref="ScaleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Scale { get; set; }

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>The unit conversion factor that will be used when generating spot heights. The default is 1.</para>
		/// <para>The spot heights are generated based on the z-values in the input raster, which are often measured in units of meters or feet. With the default value of 1, the spot heights will be in the same units as the z-values of the input raster. To create spot heights in a unit other than that of the z-values, set an appropriate value for the z-factor. It is not necessary that the ground x,y and surface z-units be consistent for this tool.</para>
		/// <para>For example, if the elevation values in the input raster are in feet, but you want the spot heights to be generated in meters, set the z-factor to 0.3048 (1 foot = 0.3048 meters).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Elevation Values")]
		public object? ZFactor { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Map Scale</para>
		/// </summary>
		public enum ScaleEnum 
		{
			/// <summary>
			/// <para>1:5,000—The 1:5,000 cartographic product scale will be used.</para>
			/// </summary>
			[GPValue("1:5,000")]
			[Description("1:5,000")]
			_1_5_000,

			/// <summary>
			/// <para>1:10,000—The 1:10,000 cartographic product scale will be used.</para>
			/// </summary>
			[GPValue("1:10,000")]
			[Description("1:10,000")]
			_1_10_000,

			/// <summary>
			/// <para>1:12,500—The 1:12,500 cartographic product scale will be used.</para>
			/// </summary>
			[GPValue("1:12,500")]
			[Description("1:12,500")]
			_1_12_500,

			/// <summary>
			/// <para>1:25,000—The 1:25,000 cartographic product scale will be used.</para>
			/// </summary>
			[GPValue("1:25,000")]
			[Description("1:25,000")]
			_1_25_000,

			/// <summary>
			/// <para>1:50,000—The 1:50,000 cartographic product scale will be used. This is the default.</para>
			/// </summary>
			[GPValue("1:50,000")]
			[Description("1:50,000")]
			_1_50_000,

			/// <summary>
			/// <para>1:100,000—The 1:100,000 cartographic product scale will be used.</para>
			/// </summary>
			[GPValue("1:100,000")]
			[Description("1:100,000")]
			_1_100_000,

			/// <summary>
			/// <para>1:250,000—The 1:250,000 cartographic product scale will be used.</para>
			/// </summary>
			[GPValue("1:250,000")]
			[Description("1:250,000")]
			_1_250_000,

			/// <summary>
			/// <para>1:500,000—The 1:500,000 cartographic product scale will be used.</para>
			/// </summary>
			[GPValue("1:500,000")]
			[Description("1:500,000")]
			_1_500_000,

			/// <summary>
			/// <para>1:1,000,000—The 1:1,000,000 cartographic product scale will be used.</para>
			/// </summary>
			[GPValue("1:1,000,000")]
			[Description("1:1,000,000")]
			_1_1_000_000,

		}

#endregion
	}
}
