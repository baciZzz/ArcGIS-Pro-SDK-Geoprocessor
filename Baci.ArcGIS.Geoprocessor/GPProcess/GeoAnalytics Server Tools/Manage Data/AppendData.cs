using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsServerTools
{
	/// <summary>
	/// <para>Append Data</para>
	/// <para>追加数据</para>
	/// <para>用于将要素追加到现有托管图层。</para>
	/// </summary>
	public class AppendData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>将追加要素的托管要素图层。</para>
		/// </param>
		/// <param name="AppendLayer">
		/// <para>Append Layer</para>
		/// <para>包含要追加到输入图层的要素的图层。</para>
		/// </param>
		/// <param name="AppendMethod">
		/// <para>Append Method</para>
		/// <para>指定将追加图层的值追加到输入图层字段的方法。</para>
		/// <para>仅追加匹配字段—仅当输入图层字段在追加图层中具有匹配字段时，才会追加该输入图层字段。将为没有匹配的字段追加空值。</para>
		/// <para>追加匹配字段并解决差异—可以为输入图层字段追加具有相同名称和不同类型的追加图层字段，也可以追加由 Arcade 表达式计算得出的值。</para>
		/// <para><see cref="AppendMethodEnum"/></para>
		/// </param>
		public AppendData(object InputLayer, object AppendLayer, object AppendMethod)
		{
			this.InputLayer = InputLayer;
			this.AppendLayer = AppendLayer;
			this.AppendMethod = AppendMethod;
		}

		/// <summary>
		/// <para>Tool Display Name : 追加数据</para>
		/// </summary>
		public override string DisplayName() => "追加数据";

		/// <summary>
		/// <para>Tool Name : AppendData</para>
		/// </summary>
		public override string ToolName() => "AppendData";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.AppendData</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.AppendData";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise() => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, AppendLayer, AppendMethod, AppendFields, AppendExpressions, AppendResult };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>将追加要素的托管要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Append Layer</para>
		/// <para>包含要追加到输入图层的要素的图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		[GPTablesDomain()]
		[PortalType("DataStoreCatalogLayer")]
		public object AppendLayer { get; set; }

		/// <summary>
		/// <para>Append Method</para>
		/// <para>指定将追加图层的值追加到输入图层字段的方法。</para>
		/// <para>仅追加匹配字段—仅当输入图层字段在追加图层中具有匹配字段时，才会追加该输入图层字段。将为没有匹配的字段追加空值。</para>
		/// <para>追加匹配字段并解决差异—可以为输入图层字段追加具有相同名称和不同类型的追加图层字段，也可以追加由 Arcade 表达式计算得出的值。</para>
		/// <para><see cref="AppendMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AppendMethod { get; set; } = "MATCHING_ONLY";

		/// <summary>
		/// <para>Append Fields</para>
		/// <para>追加图层字段与要追加的输入图层字段具有相同的类型和不同的名称。选择要追加的输入字段，以及包含要追加的值的追加字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object AppendFields { get; set; }

		/// <summary>
		/// <para>Append Expressions</para>
		/// <para>用于计算输入字段的字段值的 Arcade 表达式。以 Arcade 格式写入表达式，其中可包括数学运算符和多个字段。</para>
		/// <para>选择要追加到的字段，然后为每个字段输入一个表达式，以计算要追加的值。如果将图层添加到地图中，则可以使用字段和助手来构建表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object AppendExpressions { get; set; }

		/// <summary>
		/// <para>Append Result</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object AppendResult { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AppendData SetEnviroment(object extent = null , object workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Append Method</para>
		/// </summary>
		public enum AppendMethodEnum 
		{
			/// <summary>
			/// <para>仅追加匹配字段—仅当输入图层字段在追加图层中具有匹配字段时，才会追加该输入图层字段。将为没有匹配的字段追加空值。</para>
			/// </summary>
			[GPValue("MATCHING_ONLY")]
			[Description("仅追加匹配字段")]
			Append_matching_fields_only,

			/// <summary>
			/// <para>追加匹配字段并解决差异—可以为输入图层字段追加具有相同名称和不同类型的追加图层字段，也可以追加由 Arcade 表达式计算得出的值。</para>
			/// </summary>
			[GPValue("FIELD_MAPPING")]
			[Description("追加匹配字段并解决差异")]
			Append_matching_fields_and_resolve_differences,

		}

#endregion
	}
}
