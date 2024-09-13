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
	/// <para>查找局部山峰或山谷</para>
	/// <para>用于在定义区域内查找局部山峰或山谷。</para>
	/// </summary>
	public class FindLocalPeaksValleys : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>输入高程栅格表面。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含局部山峰或山谷的输出点要素类。</para>
		/// </param>
		/// <param name="PeakValleyOpType">
		/// <para>Peaks or Valleys</para>
		/// <para>用于指定该工具将执行的操作类型。</para>
		/// <para>局部山峰—将找到局部山峰。 这是默认设置。</para>
		/// <para>局部山谷—将找到局部山谷。</para>
		/// <para><see cref="PeakValleyOpTypeEnum"/></para>
		/// </param>
		/// <param name="NumPeaksValleys">
		/// <para>Number of Peaks or Valleys</para>
		/// <para>要查找的山峰或山谷的数量。</para>
		/// </param>
		public FindLocalPeaksValleys(object InSurface, object OutFeatureClass, object PeakValleyOpType, object NumPeaksValleys)
		{
			this.InSurface = InSurface;
			this.OutFeatureClass = OutFeatureClass;
			this.PeakValleyOpType = PeakValleyOpType;
			this.NumPeaksValleys = NumPeaksValleys;
		}

		/// <summary>
		/// <para>Tool Display Name : 查找局部山峰或山谷</para>
		/// </summary>
		public override string DisplayName() => "查找局部山峰或山谷";

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
		/// <para>输入高程栅格表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含局部山峰或山谷的输出点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Peaks or Valleys</para>
		/// <para>用于指定该工具将执行的操作类型。</para>
		/// <para>局部山峰—将找到局部山峰。 这是默认设置。</para>
		/// <para>局部山谷—将找到局部山谷。</para>
		/// <para><see cref="PeakValleyOpTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PeakValleyOpType { get; set; } = "PEAKS";

		/// <summary>
		/// <para>Number of Peaks or Valleys</para>
		/// <para>要查找的山峰或山谷的数量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumPeaksValleys { get; set; } = "10";

		/// <summary>
		/// <para>Input Area</para>
		/// <para>将在其中查找局部山峰或山谷的输入面要素类。</para>
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
			/// <para>局部山峰—将找到局部山峰。 这是默认设置。</para>
			/// </summary>
			[GPValue("PEAKS")]
			[Description("局部山峰")]
			Local_peaks,

			/// <summary>
			/// <para>局部山谷—将找到局部山谷。</para>
			/// </summary>
			[GPValue("VALLEYS")]
			[Description("局部山谷")]
			Local_valleys,

		}

#endregion
	}
}
