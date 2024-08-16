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
	/// <para>Sun Shadow Frequency</para>
	/// <para>Calculates the number of times a fixed position on a surface has its direct sight line to the sun obstructed by multipatch features.</para>
	/// </summary>
	public class SunShadowFrequency : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The multipatch features that will constitute the source of obstruction for sunlight.</para>
		/// </param>
		/// <param name="Ground">
		/// <para>Ground Surface</para>
		/// <para>The ground surface that will define the positions where sunlight obstruction will be evaluated.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Shadow Raster</para>
		/// <para>The output raster whose cell values reflect the number of times the corresponding ground height position was obstructed by the input features.</para>
		/// </param>
		public SunShadowFrequency(object InFeatures, object Ground, object OutRaster)
		{
			this.InFeatures = InFeatures;
			this.Ground = Ground;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Sun Shadow Frequency</para>
		/// </summary>
		public override string DisplayName => "Sun Shadow Frequency";

		/// <summary>
		/// <para>Tool Name : SunShadowFrequency</para>
		/// </summary>
		public override string ToolName => "SunShadowFrequency";

		/// <summary>
		/// <para>Tool Excute Name : 3d.SunShadowFrequency</para>
		/// </summary>
		public override string ExcuteName => "3d.SunShadowFrequency";

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
		public override string[] ValidEnvironments => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, Ground, OutRaster, CellSize, StartTime, EndTime, TimeInterval, TimeZone, Dst, MaxShadowLength };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The multipatch features that will constitute the source of obstruction for sunlight.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Ground Surface</para>
		/// <para>The ground surface that will define the positions where sunlight obstruction will be evaluated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object Ground { get; set; }

		/// <summary>
		/// <para>Output Shadow Raster</para>
		/// <para>The output raster whose cell values reflect the number of times the corresponding ground height position was obstructed by the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output Cell Size</para>
		/// <para>The cell size of the output raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object CellSize { get; set; } = "10 Feet";

		/// <summary>
		/// <para>Start Time</para>
		/// <para>The date and time sun position calculations will begin. The default value is the date and time the tool is initialized.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object StartTime { get; set; }

		/// <summary>
		/// <para>End Time</para>
		/// <para>The date and time sun position calculations will end.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object EndTime { get; set; }

		/// <summary>
		/// <para>Time Interval</para>
		/// <para>The interval that will be used to calculate sun positions from the start date and time to the end date and time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		public object TimeInterval { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>The time zone that corresponds with the specified input times used to determine the relative position of the sun. The list of available values is defined by the operating system but will default to the time zone of the current time on the computer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TimeZone { get; set; } = "Pacific_Standard_Time";

		/// <summary>
		/// <para>Adjusted for Daylight Saving Time</para>
		/// <para>Specifies whether the specified times will be adjusted for daylight saving time.</para>
		/// <para>Checked—The input times will be adjusted for daylight saving time.</para>
		/// <para>Unchecked—The input times will not be adjusted for daylight saving time. This is the default.</para>
		/// <para><see cref="DstEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Dst { get; set; } = "true";

		/// <summary>
		/// <para>Maximum Shadow Length</para>
		/// <para>The maximum distance that a shadow will be cast from an input feature during calculation. Consider defining this value when processing times where the sun position has a low altitude angle, as the resulting shadows will be long and potentially add unnecessary processing time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object MaxShadowLength { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SunShadowFrequency SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Adjusted for Daylight Saving Time</para>
		/// </summary>
		public enum DstEnum 
		{
			/// <summary>
			/// <para>Checked—The input times will be adjusted for daylight saving time.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DST")]
			DST,

			/// <summary>
			/// <para>Unchecked—The input times will not be adjusted for daylight saving time. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DST")]
			NO_DST,

		}

#endregion
	}
}
