using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.MaritimeTools
{
	/// <summary>
	/// <para>Smooth Bathymetric TIN</para>
	/// <para>Smooth Bathymetric TIN</para>
	/// <para>Smooths a triangulated irregular network (TIN) dataset in a manner that strictly preserves a shallow bias.</para>
	/// </summary>
	public class SmoothBathymetricTIN : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin">
		/// <para>Input TIN</para>
		/// <para>The input TIN that will be smoothed with a shallow bias.</para>
		/// </param>
		/// <param name="OutTin">
		/// <para>Output TIN</para>
		/// <para>The output smoothed TIN.</para>
		/// </param>
		/// <param name="DepthDirection">
		/// <para>Depth Direction</para>
		/// <para>Specifies how the depth will be captured in the input TIN.</para>
		/// <para>Positive Up—The depth will be captured in the input TIN. This is default.</para>
		/// <para>Positive Down—The downward depth will be captured in the input TIN.</para>
		/// <para><see cref="DepthDirectionEnum"/></para>
		/// </param>
		/// <param name="SmoothingIterations">
		/// <para>Smoothing Iterations</para>
		/// <para>The number of smoothing passes that will be performed over the TIN.</para>
		/// </param>
		public SmoothBathymetricTIN(object InTin, object OutTin, object DepthDirection, object SmoothingIterations)
		{
			this.InTin = InTin;
			this.OutTin = OutTin;
			this.DepthDirection = DepthDirection;
			this.SmoothingIterations = SmoothingIterations;
		}

		/// <summary>
		/// <para>Tool Display Name : Smooth Bathymetric TIN</para>
		/// </summary>
		public override string DisplayName() => "Smooth Bathymetric TIN";

		/// <summary>
		/// <para>Tool Name : SmoothBathymetricTIN</para>
		/// </summary>
		public override string ToolName() => "SmoothBathymetricTIN";

		/// <summary>
		/// <para>Tool Excute Name : maritime.SmoothBathymetricTIN</para>
		/// </summary>
		public override string ExcuteName() => "maritime.SmoothBathymetricTIN";

		/// <summary>
		/// <para>Toolbox Display Name : Maritime Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Maritime Tools";

		/// <summary>
		/// <para>Toolbox Alise : maritime</para>
		/// </summary>
		public override string ToolboxAlise() => "maritime";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTin, OutTin, DepthDirection, SmoothingIterations };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>The input TIN that will be smoothed with a shallow bias.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin { get; set; }

		/// <summary>
		/// <para>Output TIN</para>
		/// <para>The output smoothed TIN.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETin()]
		public object OutTin { get; set; }

		/// <summary>
		/// <para>Depth Direction</para>
		/// <para>Specifies how the depth will be captured in the input TIN.</para>
		/// <para>Positive Up—The depth will be captured in the input TIN. This is default.</para>
		/// <para>Positive Down—The downward depth will be captured in the input TIN.</para>
		/// <para><see cref="DepthDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DepthDirection { get; set; } = "POSITIVE_UP";

		/// <summary>
		/// <para>Smoothing Iterations</para>
		/// <para>The number of smoothing passes that will be performed over the TIN.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object SmoothingIterations { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Depth Direction</para>
		/// </summary>
		public enum DepthDirectionEnum 
		{
			/// <summary>
			/// <para>Positive Up—The depth will be captured in the input TIN. This is default.</para>
			/// </summary>
			[GPValue("POSITIVE_UP")]
			[Description("Positive Up")]
			Positive_Up,

			/// <summary>
			/// <para>Positive Down—The downward depth will be captured in the input TIN.</para>
			/// </summary>
			[GPValue("POSITIVE_DOWN")]
			[Description("Positive Down")]
			Positive_Down,

		}

#endregion
	}
}
