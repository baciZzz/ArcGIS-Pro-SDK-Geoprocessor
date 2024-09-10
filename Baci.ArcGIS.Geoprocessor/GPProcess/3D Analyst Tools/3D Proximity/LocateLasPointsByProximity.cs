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
	/// <para>Locate LAS Points By Proximity</para>
	/// <para>Identifies LAS points within the three-dimensional proximity of z-enabled features along with the option to reclassify those points.</para>
	/// </summary>
	public class LocateLasPointsByProximity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input 3D Features</para>
		/// <para>The 3D point, line, polygon, or multipatch features whose proximity will be used for identifying LAS points.</para>
		/// </param>
		public LocateLasPointsByProximity(object InLasDataset, object InFeatures)
		{
			this.InLasDataset = InLasDataset;
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Locate LAS Points By Proximity</para>
		/// </summary>
		public override string DisplayName() => "Locate LAS Points By Proximity";

		/// <summary>
		/// <para>Tool Name : LocateLasPointsByProximity</para>
		/// </summary>
		public override string ToolName() => "LocateLasPointsByProximity";

		/// <summary>
		/// <para>Tool Excute Name : 3d.LocateLasPointsByProximity</para>
		/// </summary>
		public override string ExcuteName() => "3d.LocateLasPointsByProximity";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, InFeatures, SearchRadius, CountField, OutFeatures, Geometry, ClassCode, ComputeStats, OutLasDataset, DerivedFeatures, UpdatePyramid };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Input 3D Features</para>
		/// <para>The 3D point, line, polygon, or multipatch features whose proximity will be used for identifying LAS points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain(Has_Z = true, Include_Z = true)]
		[GeometryType("Point", "Polyline", "Polygon", "MultiPatch")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>The distance around the input features that will be evaluated for the presence of LAS points, which can be provided as either a linear distance or a numeric field in the input feature's attribute table. If the search radius is derived from a field or a linear distance whose units are specified as Unknown, the linear unit of the input features' XY spatial reference is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object SearchRadius { get; set; } = "1 Meters";

		/// <summary>
		/// <para>Count Field</para>
		/// <para>The name of the field that will be added to the input feature's attribute table and populated with the number of LAS points in each feature's proximity. The default field name is COUNT.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object CountField { get; set; } = "COUNT";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The point features that represent the LAS points detected within the specified proximity of the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Output Geometry Type</para>
		/// <para>Specifies the geometry of the output point features that represent the LAS points found within the specified proximity of the input features.</para>
		/// <para>Multipoint—Multipoint features that will have multiple points in each row.</para>
		/// <para>Point—Single-point features that will have a unique row for each identified LAS point.</para>
		/// <para><see cref="GeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Geometry { get; set; } = "MULTIPOINT";

		/// <summary>
		/// <para>New Class Code</para>
		/// <para>The class code value that will be used to reclassify the points found within the search radius of the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object ClassCode { get; set; }

		/// <summary>
		/// <para>Compute statistics</para>
		/// <para>Specifies whether statistics will be computed for the .las files referenced by the LAS dataset. Computing statistics provides a spatial index for each .las file, which improves analysis and display performance. Statistics also enhance the filtering and symbology experience by limiting the display of LAS attributes, such as classification codes and return information, to values that are present in the .las file.</para>
		/// <para>Checked—Statistics will be computed. This is the default.</para>
		/// <para>Unchecked—Statistics will not be computed.</para>
		/// <para><see cref="ComputeStatsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ComputeStats { get; set; } = "true";

		/// <summary>
		/// <para>Updated Input LAS Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLasDatasetLayer()]
		public object OutLasDataset { get; set; }

		/// <summary>
		/// <para>Updated Input 3D Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object DerivedFeatures { get; set; }

		/// <summary>
		/// <para>Update pyramid</para>
		/// <para>Specifies whether the LAS dataset pyramid will be updated after the class codes are modified.</para>
		/// <para>Checked—The LAS dataset pyramid will be updated. This is the default.</para>
		/// <para>Unchecked—The LAS dataset pyramid will not be updated.</para>
		/// <para><see cref="UpdatePyramidEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UpdatePyramid { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LocateLasPointsByProximity SetEnviroment(object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Geometry Type</para>
		/// </summary>
		public enum GeometryEnum 
		{
			/// <summary>
			/// <para>Multipoint—Multipoint features that will have multiple points in each row.</para>
			/// </summary>
			[GPValue("MULTIPOINT")]
			[Description("Multipoint")]
			Multipoint,

			/// <summary>
			/// <para>Point—Single-point features that will have a unique row for each identified LAS point.</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("Point")]
			Point,

		}

		/// <summary>
		/// <para>Compute statistics</para>
		/// </summary>
		public enum ComputeStatsEnum 
		{
			/// <summary>
			/// <para>Checked—Statistics will be computed. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPUTE_STATS")]
			COMPUTE_STATS,

			/// <summary>
			/// <para>Unchecked—Statistics will not be computed.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_COMPUTE_STATS")]
			NO_COMPUTE_STATS,

		}

		/// <summary>
		/// <para>Update pyramid</para>
		/// </summary>
		public enum UpdatePyramidEnum 
		{
			/// <summary>
			/// <para>Checked—The LAS dataset pyramid will be updated. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_PYRAMID")]
			UPDATE_PYRAMID,

			/// <summary>
			/// <para>Unchecked—The LAS dataset pyramid will not be updated.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_UPDATE_PYRAMID")]
			NO_UPDATE_PYRAMID,

		}

#endregion
	}
}
