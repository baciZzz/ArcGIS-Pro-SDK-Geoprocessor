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
	/// <para>要素折点转点</para>
	/// <para>创建包含从输入要素的指定折点或位置生成的点的要素类。</para>
	/// </summary>
	public class FeatureVerticesToPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>线或面输入要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>输出点要素类。</para>
		/// </param>
		public FeatureVerticesToPoints(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 要素折点转点</para>
		/// </summary>
		public override string DisplayName() => "要素折点转点";

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
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, PointLocation! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>线或面输入要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Point Type</para>
		/// <para>指定输出点的创建位置。</para>
		/// <para>所有折点—在每个输入要素折点处创建一个点。 这是默认设置。</para>
		/// <para>中点—在每个输入线或面边界的中点（不一定是折点）处创建一个点。</para>
		/// <para>起始折点—在每个输入要素的起点（第一个折点）处创建一个点。</para>
		/// <para>端折点—在每个输入要素的终点（最后一个折点）处创建一个点。</para>
		/// <para>起始和终止折点—在每个输入要素的起始点和终点处各创建一个点，共创建两个点。</para>
		/// <para>悬挂折点—在输入线的起点或终点（如果该点不与另一条线的任何位置相连）创建一个悬挂点。 该选项不适用于面输入。</para>
		/// <para><see cref="PointLocationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PointLocation { get; set; } = "ALL";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeatureVerticesToPoints SetEnviroment(object? MDomain = null, double? MResolution = null, double? MTolerance = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, object? extent = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null, object? scratchWorkspace = null, object? workspace = null)
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
			/// <para>所有折点—在每个输入要素折点处创建一个点。 这是默认设置。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有折点")]
			All_vertices,

			/// <summary>
			/// <para>中点—在每个输入线或面边界的中点（不一定是折点）处创建一个点。</para>
			/// </summary>
			[GPValue("MID")]
			[Description("中点")]
			Midpoint,

			/// <summary>
			/// <para>起始折点—在每个输入要素的起点（第一个折点）处创建一个点。</para>
			/// </summary>
			[GPValue("START")]
			[Description("起始折点")]
			Start_vertex,

			/// <summary>
			/// <para>端折点—在每个输入要素的终点（最后一个折点）处创建一个点。</para>
			/// </summary>
			[GPValue("END")]
			[Description("端折点")]
			End_vertex,

			/// <summary>
			/// <para>起始和终止折点—在每个输入要素的起始点和终点处各创建一个点，共创建两个点。</para>
			/// </summary>
			[GPValue("BOTH_ENDS")]
			[Description("起始和终止折点")]
			Both_start_and_end_vertex,

			/// <summary>
			/// <para>悬挂折点—在输入线的起点或终点（如果该点不与另一条线的任何位置相连）创建一个悬挂点。 该选项不适用于面输入。</para>
			/// </summary>
			[GPValue("DANGLE")]
			[Description("悬挂折点")]
			Dangling_vertex,

		}

#endregion
	}
}
