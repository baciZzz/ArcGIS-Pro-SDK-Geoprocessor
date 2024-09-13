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
	/// <para>Find Highest Or Lowest Point</para>
	/// <para>查找最高点或最低点</para>
	/// <para>用于在定义区域内查找输入表面的最高点或最低点。</para>
	/// </summary>
	public class FindHighestLowestPoint : AbstractGPProcess
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
		/// <para>包含输出最高点或最低点的要素类。</para>
		/// </param>
		/// <param name="HighLowOperationType">
		/// <para>Highest or Lowest Point</para>
		/// <para>用于指定该工具将执行的操作类型。</para>
		/// <para>最高点—将找到最高点。这是默认设置。</para>
		/// <para>最低点—将找到最低点。</para>
		/// <para><see cref="HighLowOperationTypeEnum"/></para>
		/// </param>
		public FindHighestLowestPoint(object InSurface, object OutFeatureClass, object HighLowOperationType)
		{
			this.InSurface = InSurface;
			this.OutFeatureClass = OutFeatureClass;
			this.HighLowOperationType = HighLowOperationType;
		}

		/// <summary>
		/// <para>Tool Display Name : 查找最高点或最低点</para>
		/// </summary>
		public override string DisplayName() => "查找最高点或最低点";

		/// <summary>
		/// <para>Tool Name : FindHighestLowestPoint</para>
		/// </summary>
		public override string ToolName() => "FindHighestLowestPoint";

		/// <summary>
		/// <para>Tool Excute Name : defense.FindHighestLowestPoint</para>
		/// </summary>
		public override string ExcuteName() => "defense.FindHighestLowestPoint";

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
		public override object[] Parameters() => new object[] { InSurface, OutFeatureClass, HighLowOperationType, InFeature };

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>输入高程栅格表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含输出最高点或最低点的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Highest or Lowest Point</para>
		/// <para>用于指定该工具将执行的操作类型。</para>
		/// <para>最高点—将找到最高点。这是默认设置。</para>
		/// <para>最低点—将找到最低点。</para>
		/// <para><see cref="HighLowOperationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object HighLowOperationType { get; set; } = "HIGHEST";

		/// <summary>
		/// <para>Input Area</para>
		/// <para>将在其中查找最高点或最低点的输入面要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InFeature { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindHighestLowestPoint SetEnviroment(object extent = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Highest or Lowest Point</para>
		/// </summary>
		public enum HighLowOperationTypeEnum 
		{
			/// <summary>
			/// <para>最高点—将找到最高点。这是默认设置。</para>
			/// </summary>
			[GPValue("HIGHEST")]
			[Description("最高点")]
			Highest_points,

			/// <summary>
			/// <para>最低点—将找到最低点。</para>
			/// </summary>
			[GPValue("LOWEST")]
			[Description("最低点")]
			Lowest_points,

		}

#endregion
	}
}
