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
	/// <para>按邻域查找 LAS 点</para>
	/// <para>用于标识已启用 z 值要素的三维邻域内的 LAS 点，并提供重新分类这些点的选项。</para>
	/// </summary>
	public class LocateLasPointsByProximity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input 3D Features</para>
		/// <para>将使用其邻域识别 LAS 点的 3D 点、线、面或多面体要素。</para>
		/// </param>
		public LocateLasPointsByProximity(object InLasDataset, object InFeatures)
		{
			this.InLasDataset = InLasDataset;
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 按邻域查找 LAS 点</para>
		/// </summary>
		public override string DisplayName() => "按邻域查找 LAS 点";

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
		/// <para>待处理的 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Input 3D Features</para>
		/// <para>将使用其邻域识别 LAS 点的 3D 点、线、面或多面体要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain(Has_Z = true, Include_Z = true)]
		[GeometryType("Point", "Polyline", "Polygon", "MultiPatch")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>用于评估输入要素周围是否存在 LAS 点的距离，可使用线性距离或输入要素属性表中的数值字段提供。 如果搜索半径从单位为未知的字段或线性距离中获得，则将使用输入要素 XY 空间参考的线性单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object SearchRadius { get; set; } = "1 Meters";

		/// <summary>
		/// <para>Count Field</para>
		/// <para>该字段名称将添加到输入要素的属性表中，并将使用每个要素邻域中的 LAS 点数进行填充。 默认字段名称为 COUNT。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object CountField { get; set; } = "COUNT";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>表示输入要素指定邻域中检测到的 LAS 点的点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Output Geometry Type</para>
		/// <para>指定输出点要素的几何，这些点要素表示输入要素指定邻域中找到的 LAS 点。</para>
		/// <para>多点—每一行中都将具有多个点的多点要素。</para>
		/// <para>点—每个识别的 LAS 点都具有唯一行的单点要素。</para>
		/// <para><see cref="GeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Geometry { get; set; } = "MULTIPOINT";

		/// <summary>
		/// <para>New Class Code</para>
		/// <para>用于对在输入要素搜索半径内发现的点进行重分类的类代码值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object ClassCode { get; set; }

		/// <summary>
		/// <para>Compute statistics</para>
		/// <para>指定是否将计算 LAS 数据集引用的 .las 文件的统计数据。 计算统计数据时会为每个 .las 文件提供一个空间索引，从而提高了分析和显示性能。 统计数据还可通过将 LAS 属性（例如分类代码和返回信息）显示限制为 .las 文件中存在的值来提升过滤和符号系统体验。</para>
		/// <para>选中 - 将计算统计数据。 这是默认设置。</para>
		/// <para>未选中 - 不计算统计数据。</para>
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
		/// <para>指定修改类代码后，LAS 数据集金字塔是否会更新。</para>
		/// <para>选中 - LAS 数据集金字塔将更新。 这是默认设置。</para>
		/// <para>未选中 - LAS 数据集金字塔不会更新。</para>
		/// <para><see cref="UpdatePyramidEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UpdatePyramid { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LocateLasPointsByProximity SetEnviroment(object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object workspace = null)
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
			/// <para>多点—每一行中都将具有多个点的多点要素。</para>
			/// </summary>
			[GPValue("MULTIPOINT")]
			[Description("多点")]
			Multipoint,

			/// <summary>
			/// <para>点—每个识别的 LAS 点都具有唯一行的单点要素。</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("点")]
			Point,

		}

		/// <summary>
		/// <para>Compute statistics</para>
		/// </summary>
		public enum ComputeStatsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPUTE_STATS")]
			COMPUTE_STATS,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_PYRAMID")]
			UPDATE_PYRAMID,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_UPDATE_PYRAMID")]
			NO_UPDATE_PYRAMID,

		}

#endregion
	}
}
