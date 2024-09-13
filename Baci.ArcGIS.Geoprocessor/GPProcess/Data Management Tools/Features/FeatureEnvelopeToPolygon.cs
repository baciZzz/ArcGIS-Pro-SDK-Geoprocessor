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
	/// <para>Feature Envelope To Polygon</para>
	/// <para>要素包络矩形转面</para>
	/// <para>创建一个包含面的要素类，每个面表示一个输入要素的包络矩形。</para>
	/// </summary>
	public class FeatureEnvelopeToPolygon : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入要素可以是多点、线、面或注记。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>输出面要素类。</para>
		/// </param>
		public FeatureEnvelopeToPolygon(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 要素包络矩形转面</para>
		/// </summary>
		public override string DisplayName() => "要素包络矩形转面";

		/// <summary>
		/// <para>Tool Name : FeatureEnvelopeToPolygon</para>
		/// </summary>
		public override string ToolName() => "FeatureEnvelopeToPolygon";

		/// <summary>
		/// <para>Tool Excute Name : management.FeatureEnvelopeToPolygon</para>
		/// </summary>
		public override string ExcuteName() => "management.FeatureEnvelopeToPolygon";

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
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, SingleEnvelope };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入要素可以是多点、线、面或注记。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Multipoint", "Polyline", "Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出面要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Create multipart features</para>
		/// <para>指定是否针对每个完整多部分要素使用一个包络矩形，或针对多部分要素的每一部分使用一个包络矩形。此参数仅影响多部分输入要素的结果。</para>
		/// <para>未选中 - 使用一个包含整个多部分要素的包络矩形；因此，生成的面将为单部分。这是默认设置。</para>
		/// <para>选中 - 针对多部分要素的每一部分使用一个包络矩形；所以生成的多部分要素的面将依然为多部分。</para>
		/// <para><see cref="SingleEnvelopeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SingleEnvelope { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeatureEnvelopeToPolygon SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , object extent = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Create multipart features</para>
		/// </summary>
		public enum SingleEnvelopeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MULTIPART")]
			MULTIPART,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("SINGLEPART")]
			SINGLEPART,

		}

#endregion
	}
}
