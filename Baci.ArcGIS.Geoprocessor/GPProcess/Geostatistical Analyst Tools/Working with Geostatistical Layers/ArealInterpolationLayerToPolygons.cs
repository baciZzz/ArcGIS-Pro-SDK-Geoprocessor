using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>Areal Interpolation Layer To Polygons</para>
	/// <para>面插值图层到面</para>
	/// <para>将面插值图层的预测值重新聚合为一组新面。</para>
	/// </summary>
	public class ArealInterpolationLayerToPolygons : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InArealInterpolationLayer">
		/// <para>Input areal interpolation geostatistical layer</para>
		/// <para>由面插值模型生成的输入地统计图层。</para>
		/// </param>
		/// <param name="InPolygonFeatures">
		/// <para>Input polygon features</para>
		/// <para>预测和标准误差进行聚合的面。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output polygon feature class</para>
		/// <para>包含对新面聚合的预测和标准误差的输出要素类。</para>
		/// </param>
		public ArealInterpolationLayerToPolygons(object InArealInterpolationLayer, object InPolygonFeatures, object OutFeatureClass)
		{
			this.InArealInterpolationLayer = InArealInterpolationLayer;
			this.InPolygonFeatures = InPolygonFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 面插值图层到面</para>
		/// </summary>
		public override string DisplayName() => "面插值图层到面";

		/// <summary>
		/// <para>Tool Name : ArealInterpolationLayerToPolygons</para>
		/// </summary>
		public override string ToolName() => "ArealInterpolationLayerToPolygons";

		/// <summary>
		/// <para>Tool Excute Name : ga.ArealInterpolationLayerToPolygons</para>
		/// </summary>
		public override string ExcuteName() => "ga.ArealInterpolationLayerToPolygons";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise() => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InArealInterpolationLayer, InPolygonFeatures, OutFeatureClass, AppendAllFields };

		/// <summary>
		/// <para>Input areal interpolation geostatistical layer</para>
		/// <para>由面插值模型生成的输入地统计图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object InArealInterpolationLayer { get; set; }

		/// <summary>
		/// <para>Input polygon features</para>
		/// <para>预测和标准误差进行聚合的面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InPolygonFeatures { get; set; }

		/// <summary>
		/// <para>Output polygon feature class</para>
		/// <para>包含对新面聚合的预测和标准误差的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Append all fields from input features</para>
		/// <para>确定是否所有字段都将从输入要素复制到输出要素类。</para>
		/// <para>选中 - 输入要素的所有字段都将复制到输出要素类。这是默认设置。</para>
		/// <para>未选中 - 仅复制要素 ID 值，并在输出要素类中将其命名为 Source_ID。</para>
		/// <para><see cref="AppendAllFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AppendAllFields { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ArealInterpolationLayerToPolygons SetEnviroment(object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Append all fields from input features</para>
		/// </summary>
		public enum AppendAllFieldsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL")]
			ALL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("FID_ONLY")]
			FID_ONLY,

		}

#endregion
	}
}
