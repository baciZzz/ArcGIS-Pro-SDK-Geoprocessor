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
	/// <para>LAS Building Multipatch</para>
	/// <para>LAS Building Multipatch</para>
	/// <para>Creates building models derived from rooftop points captured in lidar data.</para>
	/// </summary>
	public class LasBuildingMultipatch : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset containing the points that will define the building rooftop.</para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The polygon features that define the building footprint.</para>
		/// </param>
		/// <param name="Ground">
		/// <para>Ground Height</para>
		/// <para>The source of ground height values can be either a numeric field in the building footprint attribute table or a raster or TIN surface. A field-based ground source will be processed faster than a surface-based ground source.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Multipatch Feature Class</para>
		/// <para>The multipatch feature class that will store the output building models.</para>
		/// </param>
		public LasBuildingMultipatch(object InLasDataset, object InFeatures, object Ground, object OutFeatureClass)
		{
			this.InLasDataset = InLasDataset;
			this.InFeatures = InFeatures;
			this.Ground = Ground;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : LAS Building Multipatch</para>
		/// </summary>
		public override string DisplayName() => "LAS Building Multipatch";

		/// <summary>
		/// <para>Tool Name : LasBuildingMultipatch</para>
		/// </summary>
		public override string ToolName() => "LasBuildingMultipatch";

		/// <summary>
		/// <para>Tool Excute Name : 3d.LasBuildingMultipatch</para>
		/// </summary>
		public override string ExcuteName() => "3d.LasBuildingMultipatch";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, InFeatures, Ground, OutFeatureClass, PointSelection!, Simplification!, SamplingResolution! };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset containing the points that will define the building rooftop.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The polygon features that define the building footprint.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Ground Height</para>
		/// <para>The source of ground height values can be either a numeric field in the building footprint attribute table or a raster or TIN surface. A field-based ground source will be processed faster than a surface-based ground source.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Ground { get; set; }

		/// <summary>
		/// <para>Output Multipatch Feature Class</para>
		/// <para>The multipatch feature class that will store the output building models.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>LAS Rooftop Point Selection</para>
		/// <para>Specifies the LAS points that will be used to define the building rooftop.</para>
		/// <para>Building Classified Points—LAS points assigned a class code value of 6 will be used. This is the default.</para>
		/// <para>Layer Filtered Points—LAS points that are filtered by the input layer will be used.</para>
		/// <para>All Points—All LAS points that overlay the building footprint will be used.</para>
		/// <para><see cref="PointSelectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PointSelection { get; set; } = "BUILDING_CLASSIFIED_POINTS";

		/// <summary>
		/// <para>Simplification Tolerance</para>
		/// <para>A z-tolerance value that will be used to simplify the rooftop geometry. This value defines the maximum deviation of the output rooftop model from the TIN surface created using the LAS points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object? Simplification { get; set; }

		/// <summary>
		/// <para>Sampling Resolution</para>
		/// <para>The binning size used to thin the point cloud prior to constructing the rooftop surface.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object? SamplingResolution { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LasBuildingMultipatch SetEnviroment(object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>LAS Rooftop Point Selection</para>
		/// </summary>
		public enum PointSelectionEnum 
		{
			/// <summary>
			/// <para>Building Classified Points—LAS points assigned a class code value of 6 will be used. This is the default.</para>
			/// </summary>
			[GPValue("BUILDING_CLASSIFIED_POINTS")]
			[Description("Building Classified Points")]
			Building_Classified_Points,

			/// <summary>
			/// <para>Layer Filtered Points—LAS points that are filtered by the input layer will be used.</para>
			/// </summary>
			[GPValue("LAYER_FILTERED_POINTS")]
			[Description("Layer Filtered Points")]
			Layer_Filtered_Points,

			/// <summary>
			/// <para>All Points—All LAS points that overlay the building footprint will be used.</para>
			/// </summary>
			[GPValue("ALL_POINTS")]
			[Description("All Points")]
			All_Points,

		}

#endregion
	}
}
