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
	/// <para>Skyline Barrier</para>
	/// <para>Generates a multipatch feature class representing a skyline barrier or shadow volume.</para>
	/// </summary>
	public class SkylineBarrier : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InObserverPointFeatures">
		/// <para>Input Observer Point Features</para>
		/// <para>The point feature class containing the observer points.</para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input line feature class which represents the skylines, or the input multipatch feature class which represents the silhouettes.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output  Feature Class</para>
		/// <para>The output feature class into which the skyline barrier or shadow volume is placed.</para>
		/// </param>
		public SkylineBarrier(object InObserverPointFeatures, object InFeatures, object OutFeatureClass)
		{
			this.InObserverPointFeatures = InObserverPointFeatures;
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Skyline Barrier</para>
		/// </summary>
		public override string DisplayName => "Skyline Barrier";

		/// <summary>
		/// <para>Tool Name : SkylineBarrier</para>
		/// </summary>
		public override string ToolName => "SkylineBarrier";

		/// <summary>
		/// <para>Tool Excute Name : 3d.SkylineBarrier</para>
		/// </summary>
		public override string ExcuteName => "3d.SkylineBarrier";

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
		public override string[] ValidEnvironments => new string[] { "XYDomain", "ZDomain", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InObserverPointFeatures, InFeatures, OutFeatureClass, MinRadiusValueOrField, MaxRadiusValueOrField, Closed, BaseElevation, ProjectToPlane };

		/// <summary>
		/// <para>Input Observer Point Features</para>
		/// <para>The point feature class containing the observer points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InObserverPointFeatures { get; set; }

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input line feature class which represents the skylines, or the input multipatch feature class which represents the silhouettes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "MultiPatch")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output  Feature Class</para>
		/// <para>The output feature class into which the skyline barrier or shadow volume is placed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Minimum Radius</para>
		/// <para>The minimum radius to which triangle edges should be extended from the observer point. The default is 0, meaning no minimum.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object MinRadiusValueOrField { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Maximum Radius</para>
		/// <para>The maximum radius to which triangle edges should be extended from the observer point. The default is 0, meaning no maximum.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object MaxRadiusValueOrField { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Closed</para>
		/// <para>Whether to close the skyline barrier with a skirt and a base so that the resulting multipatch will appear to be a solid.</para>
		/// <para>Unchecked—No skirt or base is added to the multipatch; just the multipatch representing the surface going from the observer to the skyline is represented. This is the default.</para>
		/// <para>Checked— A skirt and a base are added to the multipatch so as to form what appears to be a closed solid.</para>
		/// <para><see cref="ClosedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Closed { get; set; } = "false";

		/// <summary>
		/// <para>Base Elevation</para>
		/// <para>The elevation of the base of the closed multipatch; it is ignored if the barrier is not to be closed. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object BaseElevation { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Project to Plane</para>
		/// <para>Whether the front (nearer to the observer) and back (farther from the observer) ends of the barrier should each be projected onto a vertical plane. This is typically checked (turned on) in order to create a shadow volume.</para>
		/// <para>Unchecked—The barrier will extend from the observer point to the skyline (or nearer or farther if nonzero values are provided for minimum and maximum radius). This is the default.</para>
		/// <para>Checked—The barrier will extend from a vertical plane to a vertical plane.</para>
		/// <para><see cref="ProjectToPlaneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ProjectToPlane { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SkylineBarrier SetEnviroment(object XYDomain = null , object ZDomain = null , int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, ZDomain: ZDomain, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Closed</para>
		/// </summary>
		public enum ClosedEnum 
		{
			/// <summary>
			/// <para>Checked— A skirt and a base are added to the multipatch so as to form what appears to be a closed solid.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLOSED")]
			CLOSED,

			/// <summary>
			/// <para>Unchecked—No skirt or base is added to the multipatch; just the multipatch representing the surface going from the observer to the skyline is represented. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CLOSED")]
			NO_CLOSED,

		}

		/// <summary>
		/// <para>Project to Plane</para>
		/// </summary>
		public enum ProjectToPlaneEnum 
		{
			/// <summary>
			/// <para>Checked—The barrier will extend from a vertical plane to a vertical plane.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PROJECT_TO_PLANE")]
			PROJECT_TO_PLANE,

			/// <summary>
			/// <para>Unchecked—The barrier will extend from the observer point to the skyline (or nearer or farther if nonzero values are provided for minimum and maximum radius). This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PROJECT_TO_PLANE")]
			NO_PROJECT_TO_PLANE,

		}

#endregion
	}
}
