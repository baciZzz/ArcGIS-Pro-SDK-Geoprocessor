using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DefenseTools
{
	/// <summary>
	/// <para>Find Local Peaks Or Valleys</para>
	/// <para>Find Local Peaks Or Valleys</para>
	/// <para>Finds  local peaks or valleys  within a defined area.</para>
	/// </summary>
	public class FindLocalPeaksValleys : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>The input elevation raster surface.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output point feature class containing the local peaks or valleys.</para>
		/// </param>
		/// <param name="PeakValleyOpType">
		/// <para>Peaks or Valleys</para>
		/// <para>Specifies the type of operation the tool will perform.</para>
		/// <para>Local peaks—Local peaks will be found. This is the default.</para>
		/// <para>Local valleys—Local valleys will be found.</para>
		/// <para><see cref="PeakValleyOpTypeEnum"/></para>
		/// </param>
		/// <param name="NumPeaksValleys">
		/// <para>Number of Peaks or Valleys</para>
		/// <para>The number of peaks or valleys to find.</para>
		/// </param>
		public FindLocalPeaksValleys(object InSurface, object OutFeatureClass, object PeakValleyOpType, object NumPeaksValleys)
		{
			this.InSurface = InSurface;
			this.OutFeatureClass = OutFeatureClass;
			this.PeakValleyOpType = PeakValleyOpType;
			this.NumPeaksValleys = NumPeaksValleys;
		}

		/// <summary>
		/// <para>Tool Display Name : Find Local Peaks Or Valleys</para>
		/// </summary>
		public override string DisplayName() => "Find Local Peaks Or Valleys";

		/// <summary>
		/// <para>Tool Name : FindLocalPeaksValleys</para>
		/// </summary>
		public override string ToolName() => "FindLocalPeaksValleys";

		/// <summary>
		/// <para>Tool Excute Name : defense.FindLocalPeaksValleys</para>
		/// </summary>
		public override string ExcuteName() => "defense.FindLocalPeaksValleys";

		/// <summary>
		/// <para>Toolbox Display Name : Defense Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Defense Tools";

		/// <summary>
		/// <para>Toolbox Alise : defense</para>
		/// </summary>
		public override string ToolboxAlise() => "defense";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSurface, OutFeatureClass, PeakValleyOpType, NumPeaksValleys, InFeature! };

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>The input elevation raster surface.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output point feature class containing the local peaks or valleys.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Peaks or Valleys</para>
		/// <para>Specifies the type of operation the tool will perform.</para>
		/// <para>Local peaks—Local peaks will be found. This is the default.</para>
		/// <para>Local valleys—Local valleys will be found.</para>
		/// <para><see cref="PeakValleyOpTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PeakValleyOpType { get; set; } = "PEAKS";

		/// <summary>
		/// <para>Number of Peaks or Valleys</para>
		/// <para>The number of peaks or valleys to find.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumPeaksValleys { get; set; } = "10";

		/// <summary>
		/// <para>Input Area</para>
		/// <para>The input polygon feature class in which the local peaks or valleys will be found.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object? InFeature { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindLocalPeaksValleys SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Peaks or Valleys</para>
		/// </summary>
		public enum PeakValleyOpTypeEnum 
		{
			/// <summary>
			/// <para>Local peaks—Local peaks will be found. This is the default.</para>
			/// </summary>
			[GPValue("PEAKS")]
			[Description("Local peaks")]
			Local_peaks,

			/// <summary>
			/// <para>Local valleys—Local valleys will be found.</para>
			/// </summary>
			[GPValue("VALLEYS")]
			[Description("Local valleys")]
			Local_valleys,

		}

#endregion
	}
}
