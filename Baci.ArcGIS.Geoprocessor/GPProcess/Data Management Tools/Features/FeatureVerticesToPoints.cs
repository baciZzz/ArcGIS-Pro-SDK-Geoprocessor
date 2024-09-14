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
	/// <para>Feature Vertices To Points</para>
	/// <para>Feature Vertices To Points</para>
	/// <para>Creates a feature class containing points generated from specified vertices or locations of the input features.</para>
	/// </summary>
	public class FeatureVerticesToPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input features that can be line or polygon.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output point feature class.</para>
		/// </param>
		public FeatureVerticesToPoints(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Feature Vertices To Points</para>
		/// </summary>
		public override string DisplayName() => "Feature Vertices To Points";

		/// <summary>
		/// <para>Tool Name : FeatureVerticesToPoints</para>
		/// </summary>
		public override string ToolName() => "FeatureVerticesToPoints";

		/// <summary>
		/// <para>Tool Excute Name : management.FeatureVerticesToPoints</para>
		/// </summary>
		public override string ExcuteName() => "management.FeatureVerticesToPoints";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, PointLocation };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features that can be line or polygon.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output point feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Point Type</para>
		/// <para>Specifies where an output point will be created.</para>
		/// <para>All vertices—A point will be created at each input feature vertex. This is the default.</para>
		/// <para>Midpoint—A point will be created at the midpoint, not necessarily a vertex, of each input line or polygon boundary.</para>
		/// <para>Start vertex—A point will be created at the start point (first vertex) of each input feature.</para>
		/// <para>End vertex—A point will be created at the end point (last vertex) of each input feature.</para>
		/// <para>Both start and end vertex—Two points will be created, one at the start point and another at the endpoint of each input feature.</para>
		/// <para>Dangling vertex—A dangle point will be created for any start or end point of an input line, if that point is not connected to another line at any location along that line. This option does not apply to polygon input.</para>
		/// <para><see cref="PointLocationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PointLocation { get; set; } = "ALL";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeatureVerticesToPoints SetEnviroment(object MDomain = null, object MResolution = null, object MTolerance = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, object extent = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Point Type</para>
		/// </summary>
		public enum PointLocationEnum 
		{
			/// <summary>
			/// <para>All vertices—A point will be created at each input feature vertex. This is the default.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All vertices")]
			All_vertices,

			/// <summary>
			/// <para>Midpoint—A point will be created at the midpoint, not necessarily a vertex, of each input line or polygon boundary.</para>
			/// </summary>
			[GPValue("MID")]
			[Description("Midpoint")]
			Midpoint,

			/// <summary>
			/// <para>Start vertex—A point will be created at the start point (first vertex) of each input feature.</para>
			/// </summary>
			[GPValue("START")]
			[Description("Start vertex")]
			Start_vertex,

			/// <summary>
			/// <para>End vertex—A point will be created at the end point (last vertex) of each input feature.</para>
			/// </summary>
			[GPValue("END")]
			[Description("End vertex")]
			End_vertex,

			/// <summary>
			/// <para>Both start and end vertex—Two points will be created, one at the start point and another at the endpoint of each input feature.</para>
			/// </summary>
			[GPValue("BOTH_ENDS")]
			[Description("Both start and end vertex")]
			Both_start_and_end_vertex,

			/// <summary>
			/// <para>Dangling vertex—A dangle point will be created for any start or end point of an input line, if that point is not connected to another line at any location along that line. This option does not apply to polygon input.</para>
			/// </summary>
			[GPValue("DANGLE")]
			[Description("Dangling vertex")]
			Dangling_vertex,

		}

#endregion
	}
}
