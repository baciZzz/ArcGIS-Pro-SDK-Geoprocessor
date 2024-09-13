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
	/// <para>Eliminate</para>
	/// <para>消除</para>
	/// <para>通过将面与具有最大面积或最长共享边界的相邻面合并来消除面。 消除通常用于移除叠加操作（例如执行相交和联合工具）所生成的小的狭长面。</para>
	/// </summary>
	public class Eliminate : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Layer</para>
		/// <para>包含要与邻近面合并的面的图层。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>待创建的要素类。</para>
		/// </param>
		public Eliminate(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 消除</para>
		/// </summary>
		public override string DisplayName() => "消除";

		/// <summary>
		/// <para>Tool Name : 消除</para>
		/// </summary>
		public override string ToolName() => "消除";

		/// <summary>
		/// <para>Tool Excute Name : management.Eliminate</para>
		/// </summary>
		public override string ExcuteName() => "management.Eliminate";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, Selection!, ExWhereClause!, ExFeatures! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>包含要与邻近面合并的面的图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>待创建的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Eliminating polygon by border</para>
		/// <para>指定所选面是否要与具有最长共享边界或最大面积的面合并。</para>
		/// <para>选中 - 所选面将与具有最长共享边界的邻近面合并。 这是默认设置。</para>
		/// <para>未选中 - 所选面将与具有最大面积的邻近面合并。</para>
		/// <para><see cref="SelectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Selection { get; set; } = "true";

		/// <summary>
		/// <para>Exclusion Expression</para>
		/// <para>将用于识别不会被更改的要素的 SQL 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? ExWhereClause { get; set; }

		/// <summary>
		/// <para>Exclusion Layer</para>
		/// <para>定义不会被消除的面边界（或部分）的输入折线、面要素类或图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object? ExFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Eliminate SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , bool? qualifiedFieldNames = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Eliminating polygon by border</para>
		/// </summary>
		public enum SelectionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("LENGTH")]
			LENGTH,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("AREA")]
			AREA,

		}

#endregion
	}
}
