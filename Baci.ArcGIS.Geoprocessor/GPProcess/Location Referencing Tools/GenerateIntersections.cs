using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LocationReferencingTools
{
	/// <summary>
	/// <para>Generate Intersections</para>
	/// <para>生成交叉点</para>
	/// <para>生成新的交叉点并更新现有交叉点。</para>
	/// </summary>
	public class GenerateIntersections : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InIntersectionFeatureClass">
		/// <para>Intersection Feature Class</para>
		/// <para>输入 LRS 交叉点要素类或图层。</para>
		/// </param>
		public GenerateIntersections(object InIntersectionFeatureClass)
		{
			this.InIntersectionFeatureClass = InIntersectionFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成交叉点</para>
		/// </summary>
		public override string DisplayName() => "生成交叉点";

		/// <summary>
		/// <para>Tool Name : GenerateIntersections</para>
		/// </summary>
		public override string ToolName() => "GenerateIntersections";

		/// <summary>
		/// <para>Tool Excute Name : locref.GenerateIntersections</para>
		/// </summary>
		public override string ExcuteName() => "locref.GenerateIntersections";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise() => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InIntersectionFeatureClass, InNetworkLayer!, StartDate!, EditedByCurrentUser!, OutIntersectionFeatureClass!, OutDetailsFile! };

		/// <summary>
		/// <para>Intersection Feature Class</para>
		/// <para>输入 LRS 交叉点要素类或图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InIntersectionFeatureClass { get; set; }

		/// <summary>
		/// <para>Network Layer</para>
		/// <para>输入 LRS 网络要素类或图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object? InNetworkLayer { get; set; }

		/// <summary>
		/// <para>Start Date</para>
		/// <para>过滤在特定日期之后被编辑的路径，以生成交叉点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? StartDate { get; set; }

		/// <summary>
		/// <para>Only use routes edited by current user</para>
		/// <para>指定是否只为当前用户编辑和锁的路径生成交叉点。</para>
		/// <para>选中 - 仅为当前用户编辑的路径生成交叉点。 这是默认设置。</para>
		/// <para>未选中 - 将为所有已编辑的路径生成交叉点。</para>
		/// <para><see cref="EditedByCurrentUserEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? EditedByCurrentUser { get; set; } = "true";

		/// <summary>
		/// <para>Updated Intersection Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutIntersectionFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Details File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object? OutDetailsFile { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Only use routes edited by current user</para>
		/// </summary>
		public enum EditedByCurrentUserEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CURRENT_USER")]
			CURRENT_USER,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL_USERS")]
			ALL_USERS,

		}

#endregion
	}
}
