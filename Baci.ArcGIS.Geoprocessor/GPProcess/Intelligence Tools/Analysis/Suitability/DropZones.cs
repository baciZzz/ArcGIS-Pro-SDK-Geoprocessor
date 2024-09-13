using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>Drop Zone Suitability</para>
	/// <para>Drop Zone Suitability</para>
	/// <para>Identifies drop zone locations suitable for parachuting equipment or personnel within a designated area of interest given slope and vegetation data.</para>
	/// </summary>
	public class DropZones : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSlopeRaster">
		/// <para>Input Percent Slope Raster</para>
		/// <para>The slope raster percentage used to determine the slope component of DZ suitability.</para>
		/// </param>
		/// <param name="InVegetationFeatures">
		/// <para>Input Combined Vegetation Features</para>
		/// <para>The features that define the combined vegetation and land cover types. These features will be used to find areas with suitable vegetation coverage for DZs.</para>
		/// </param>
		/// <param name="ClipFeatures">
		/// <para>Clip Features</para>
		/// <para>The area within which suitable DZs will be found.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class showing terrain suitability for DZs.</para>
		/// </param>
		public DropZones(object InSlopeRaster, object InVegetationFeatures, object ClipFeatures, object OutFeatureClass)
		{
			this.InSlopeRaster = InSlopeRaster;
			this.InVegetationFeatures = InVegetationFeatures;
			this.ClipFeatures = ClipFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Drop Zone Suitability</para>
		/// </summary>
		public override string DisplayName() => "Drop Zone Suitability";

		/// <summary>
		/// <para>Tool Name : DropZones</para>
		/// </summary>
		public override string ToolName() => "DropZones";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.DropZones</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.DropZones";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise() => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSlopeRaster, InVegetationFeatures, ClipFeatures, OutFeatureClass };

		/// <summary>
		/// <para>Input Percent Slope Raster</para>
		/// <para>The slope raster percentage used to determine the slope component of DZ suitability.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InSlopeRaster { get; set; }

		/// <summary>
		/// <para>Input Combined Vegetation Features</para>
		/// <para>The features that define the combined vegetation and land cover types. These features will be used to find areas with suitable vegetation coverage for DZs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InVegetationFeatures { get; set; }

		/// <summary>
		/// <para>Clip Features</para>
		/// <para>The area within which suitable DZs will be found.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object ClipFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class showing terrain suitability for DZs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

	}
}
