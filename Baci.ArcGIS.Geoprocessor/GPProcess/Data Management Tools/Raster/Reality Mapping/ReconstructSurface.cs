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
	/// <para>Reconstruct Surface</para>
	/// <para>Generates DSM orthophotos, 2.5D meshes, 3D meshes, and point clouds from adjusted imagery.</para>
	/// </summary>
	public class ReconstructSurface : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>The adjusted input mosaic dataset.</para>
		/// </param>
		/// <param name="ReconFolder">
		/// <para>Reconstruction Folder</para>
		/// <para>The output dataset folder.</para>
		/// </param>
		public ReconstructSurface(object InMosaicDataset, object ReconFolder)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.ReconFolder = ReconFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Reconstruct Surface</para>
		/// </summary>
		public override string DisplayName => "Reconstruct Surface";

		/// <summary>
		/// <para>Tool Name : ReconstructSurface</para>
		/// </summary>
		public override string ToolName => "ReconstructSurface";

		/// <summary>
		/// <para>Tool Excute Name : management.ReconstructSurface</para>
		/// </summary>
		public override string ExcuteName => "management.ReconstructSurface";

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
		public override string[] ValidEnvironments => new string[] { "extent", "processorType" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InMosaicDataset, ReconFolder, ReconOptions!, Scenario!, FwdOverlap!, SwdOverlap!, Quality!, Products!, CellSize!, Aoi!, WaterbodyFeatures!, CorrectionFeatures!, DerivedReconFolder };

		/// <summary>
		/// <para>Input Mosaic Dataset</para>
		/// <para>The adjusted input mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Reconstruction Folder</para>
		/// <para>The output dataset folder.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object ReconFolder { get; set; }

		/// <summary>
		/// <para>Reconstruction Options</para>
		/// <para>A .json file or JSON string that specifies the values for the tool parameters.</para>
		/// <para>If this parameter is specified, the properties of the .json file or JSON string will set the defaults for the remaining optional parameters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? ReconOptions { get; set; }

		/// <summary>
		/// <para>Scenario</para>
		/// <para>Specifies the type of imagery that will be used to generate the output products.</para>
		/// <para>Default—The input imagery will be defined as having been acquired with drones or terrestrial cameras.</para>
		/// <para>Aerial Nadir—The input imagery will be defined as having been acquired with large, photogrammetric camera systems.</para>
		/// <para>Aerial Oblique—The input imagery will be defined as having been acquired with oblique camera systems.</para>
		/// <para><see cref="ScenarioEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Scenario { get; set; }

		/// <summary>
		/// <para>Forward Overlap</para>
		/// <para>The forward (in-strip) overlap percentage that will be used between the images. The default is 60.</para>
		/// <para>This parameter is active when the Scenario parameter is set to Aerial Nadir.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain()]
		public object? FwdOverlap { get; set; }

		/// <summary>
		/// <para>Sideward Overlap</para>
		/// <para>The sideward (cross-strip) overlap percentage that will be used between the images. The default is 30.</para>
		/// <para>This parameter is active when the Scenario parameter is set to Aerial Nadir.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain()]
		public object? SwdOverlap { get; set; }

		/// <summary>
		/// <para>Quality</para>
		/// <para>Specifies the quality of the final product.</para>
		/// <para>Ultra—Input images will be used at their original (full) resolution.</para>
		/// <para>High—Input images will be downsampled two times.</para>
		/// <para>Medium—Input images will be downsampled four times.</para>
		/// <para>Low—Input images will be downsampled eight times.</para>
		/// <para><see cref="QualityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Quality { get; set; }

		/// <summary>
		/// <para>Products</para>
		/// <para>Specifies the products that will be generated.</para>
		/// <para>DSM—A digital surface model (DSM) will be generated. This product will be selected by default when the Scenario parameter is set to Aerial Nadir.</para>
		/// <para>True Ortho—The imagery will be orthorectified. This product will be selected by default when the Scenario parameter is set to Aerial Nadir.</para>
		/// <para>DSM Mesh—A DSM mesh will be generated. This product will be selected by default when the Scenario parameter is set to Aerial Nadir.</para>
		/// <para>Point Cloud—An image point cloud will be generated. This product will be selected by default when the Scenario parameter is set to Default or Aerial Oblique.</para>
		/// <para>Mesh—A 3D mesh will be generated. This product will be selected by default when the Scenario parameter is set to Default or Aerial Oblique.</para>
		/// <para><see cref="ProductsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? Products { get; set; }

		/// <summary>
		/// <para>Cell Size</para>
		/// <para>The cell size of the output product.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Advanced Options")]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>The area of interest that will be used to select images for processing. The area of interest can be computed automatically or defined using an input shapefile.</para>
		/// <para>If the value contains 3D geometries, the z-component will be ignored. If the value includes overlapping features, the union of these features will be computed.</para>
		/// <para>None—All images will be used in processing.</para>
		/// <para>Auto—The processing extent will be calculated automatically. This is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Advanced Options")]
		public object? Aoi { get; set; }

		/// <summary>
		/// <para>Waterbody Features</para>
		/// <para>A polygon that will define the extent of large water bodies. For the best results, use a 3D shapefile.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Advanced Options")]
		public object? WaterbodyFeatures { get; set; }

		/// <summary>
		/// <para>Correction Features</para>
		/// <para>A polygon that will define the extent of all surfaces that are not water bodies. The value must be a 3D shapefile.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Advanced Options")]
		public object? CorrectionFeatures { get; set; }

		/// <summary>
		/// <para>Updated Reconstruction Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object? DerivedReconFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ReconstructSurface SetEnviroment(object? extent = null , object? processorType = null )
		{
			base.SetEnv(extent: extent, processorType: processorType);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Scenario</para>
		/// </summary>
		public enum ScenarioEnum 
		{
			/// <summary>
			/// <para>Default—The input imagery will be defined as having been acquired with drones or terrestrial cameras.</para>
			/// </summary>
			[GPValue("DEFAULT")]
			[Description("Default")]
			Default,

			/// <summary>
			/// <para>Aerial Nadir—The input imagery will be defined as having been acquired with large, photogrammetric camera systems.</para>
			/// </summary>
			[GPValue("AERIAL_NADIR")]
			[Description("Aerial Nadir")]
			Aerial_Nadir,

			/// <summary>
			/// <para>Aerial Oblique—The input imagery will be defined as having been acquired with oblique camera systems.</para>
			/// </summary>
			[GPValue("AERIAL_OBLIQUE")]
			[Description("Aerial Oblique")]
			Aerial_Oblique,

		}

		/// <summary>
		/// <para>Quality</para>
		/// </summary>
		public enum QualityEnum 
		{
			/// <summary>
			/// <para>Ultra—Input images will be used at their original (full) resolution.</para>
			/// </summary>
			[GPValue("ULTRA")]
			[Description("Ultra")]
			Ultra,

			/// <summary>
			/// <para>High—Input images will be downsampled two times.</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("High")]
			High,

			/// <summary>
			/// <para>Medium—Input images will be downsampled four times.</para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("Medium")]
			Medium,

			/// <summary>
			/// <para>Low—Input images will be downsampled eight times.</para>
			/// </summary>
			[GPValue("LOW")]
			[Description("Low")]
			Low,

		}

		/// <summary>
		/// <para>Products</para>
		/// </summary>
		public enum ProductsEnum 
		{
			/// <summary>
			/// <para>DSM—A digital surface model (DSM) will be generated. This product will be selected by default when the Scenario parameter is set to Aerial Nadir.</para>
			/// </summary>
			[GPValue("DSM")]
			[Description("DSM")]
			DSM,

			/// <summary>
			/// <para>True Ortho—The imagery will be orthorectified. This product will be selected by default when the Scenario parameter is set to Aerial Nadir.</para>
			/// </summary>
			[GPValue("TRUE_ORTHO")]
			[Description("True Ortho")]
			True_Ortho,

			/// <summary>
			/// <para>DSM Mesh—A DSM mesh will be generated. This product will be selected by default when the Scenario parameter is set to Aerial Nadir.</para>
			/// </summary>
			[GPValue("DSM_MESH")]
			[Description("DSM Mesh")]
			DSM_Mesh,

			/// <summary>
			/// <para>Point Cloud—An image point cloud will be generated. This product will be selected by default when the Scenario parameter is set to Default or Aerial Oblique.</para>
			/// </summary>
			[GPValue("POINT_CLOUD")]
			[Description("Point Cloud")]
			Point_Cloud,

			/// <summary>
			/// <para>Mesh—A 3D mesh will be generated. This product will be selected by default when the Scenario parameter is set to Default or Aerial Oblique.</para>
			/// </summary>
			[GPValue("MESH")]
			[Description("Mesh")]
			Mesh,

		}

#endregion
	}
}
