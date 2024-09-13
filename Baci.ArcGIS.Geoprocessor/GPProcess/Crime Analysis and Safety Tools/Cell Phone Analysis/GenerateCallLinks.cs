using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CrimeAnalysisandSafetyTools
{
	/// <summary>
	/// <para>Generate Call Links</para>
	/// <para>生成呼叫链接</para>
	/// <para>根据呼叫的开始日期和时间，使用蜂窝站点点或蜂窝站点天线扇区创建表示电话之间的呼叫链接的线要素。</para>
	/// </summary>
	public class GenerateCallLinks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPrimaryFeatures">
		/// <para>Input Primary Phone Record Site Points or Sectors</para>
		/// <para>从手机记录转要素类工具获得的主要电话或扇区的点要素类。</para>
		/// </param>
		/// <param name="InSecondaryFeatures">
		/// <para>Input Secondary Phone Record Site Points or Sectors</para>
		/// <para>从手机记录转要素类工具获得的次要电话或扇区的点要素类。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Call Link Lines</para>
		/// <para>表示不同位置的两个电话之间的呼叫链接的输出线要素。</para>
		/// </param>
		public GenerateCallLinks(object InPrimaryFeatures, object InSecondaryFeatures, object OutFeatureClass)
		{
			this.InPrimaryFeatures = InPrimaryFeatures;
			this.InSecondaryFeatures = InSecondaryFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成呼叫链接</para>
		/// </summary>
		public override string DisplayName() => "生成呼叫链接";

		/// <summary>
		/// <para>Tool Name : GenerateCallLinks</para>
		/// </summary>
		public override string ToolName() => "GenerateCallLinks";

		/// <summary>
		/// <para>Tool Excute Name : ca.GenerateCallLinks</para>
		/// </summary>
		public override string ExcuteName() => "ca.GenerateCallLinks";

		/// <summary>
		/// <para>Toolbox Display Name : Crime Analysis and Safety Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Crime Analysis and Safety Tools";

		/// <summary>
		/// <para>Toolbox Alise : ca</para>
		/// </summary>
		public override string ToolboxAlise() => "ca";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "maintainAttachments", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPrimaryFeatures, InSecondaryFeatures, OutFeatureClass, OutputType, PrimarySubscriberField, PrimaryDestinationField, PrimaryStartTimeField, SecondarySubscriberField, SecondaryDestinationField, SecondaryStartTimeField };

		/// <summary>
		/// <para>Input Primary Phone Record Site Points or Sectors</para>
		/// <para>从手机记录转要素类工具获得的主要电话或扇区的点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object InPrimaryFeatures { get; set; }

		/// <summary>
		/// <para>Input Secondary Phone Record Site Points or Sectors</para>
		/// <para>从手机记录转要素类工具获得的次要电话或扇区的点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object InSecondaryFeatures { get; set; }

		/// <summary>
		/// <para>Output Call Link Lines</para>
		/// <para>表示不同位置的两个电话之间的呼叫链接的输出线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Type</para>
		/// <para>指定如何分析和符号化两个电话之间的呼叫关系。</para>
		/// <para>汇总—将创建不同位置的两个电话之间总呼叫数的汇总记录。这是默认设置。</para>
		/// <para>详细信息—将创建不同位置的两个电话之间每次呼叫的单独记录。</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputType { get; set; } = "SUMMARY";

		/// <summary>
		/// <para>Primary Phone Subscriber ID Field</para>
		/// <para>主要电话订阅者的唯一 ID 字段，通常是电话号码。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object PrimarySubscriberField { get; set; }

		/// <summary>
		/// <para>Primary Phone Call Destination Field</para>
		/// <para>包含次要电话的电话号码的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object PrimaryDestinationField { get; set; }

		/// <summary>
		/// <para>Primary Phone Call Start Date and Time Field</para>
		/// <para>主要电话记录的开始日期和时间字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object PrimaryStartTimeField { get; set; }

		/// <summary>
		/// <para>Secondary Phone Subscriber ID Field</para>
		/// <para>次要电话订阅者的唯一 ID 字段，通常是电话号码。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object SecondarySubscriberField { get; set; }

		/// <summary>
		/// <para>Secondary Phone Destination Field</para>
		/// <para>包含主要电话的电话号码的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object SecondaryDestinationField { get; set; }

		/// <summary>
		/// <para>Secondary Phone Call Start Date and Time Field</para>
		/// <para>次要电话记录的开始日期和时间字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object SecondaryStartTimeField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateCallLinks SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , bool? qualifiedFieldNames = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Type</para>
		/// </summary>
		public enum OutputTypeEnum 
		{
			/// <summary>
			/// <para>汇总—将创建不同位置的两个电话之间总呼叫数的汇总记录。这是默认设置。</para>
			/// </summary>
			[GPValue("SUMMARY")]
			[Description("汇总")]
			Summary,

			/// <summary>
			/// <para>详细信息—将创建不同位置的两个电话之间每次呼叫的单独记录。</para>
			/// </summary>
			[GPValue("DETAIL")]
			[Description("详细信息")]
			Detail,

		}

#endregion
	}
}
