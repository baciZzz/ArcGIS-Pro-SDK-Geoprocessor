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
	/// <para>Modify Route ID Padding</para>
	/// <para>修改路径 ID 填充</para>
	/// <para>修改属于多字段路径 ID 的字段的填充、空值和长度属性。</para>
	/// </summary>
	public class ModifyRouteIdPadding : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>LRS Network Feature Class</para>
		/// <para>输入多字段路径 ID 网络图层，其中包含需要修改的填充、空值和长度值字段。</para>
		/// </param>
		/// <param name="RouteIdPadding">
		/// <para>Route ID Padding</para>
		/// <para>在此值表中指定了要修改的字段及其对应的填充、空值和长度值。</para>
		/// <para>Field—要修改的字段。</para>
		/// <para>Length—要修改的字段的长度值。 字段长度应介于 1 和数据库字段的长度之间。</para>
		/// <para>Variable Length—指定长度值是可变值还是固定值。</para>
		/// <para>Enable Padding—指定字段是否支持填充。</para>
		/// <para>Padding Character—字段的填充字符。 默认为空格。</para>
		/// <para>Padding Location—指定应将填充应用于字段值的位置。</para>
		/// <para>左侧 - 将填充字符添加到字段中值的左侧。 这是默认设置。</para>
		/// <para>右侧 - 将填充字符添加到字段中值的右侧。</para>
		/// <para>左侧和右侧 - 将填充字符添加到字段中值的左右两侧。</para>
		/// <para>Pad if Null—指定当字段具有空值时是否添加填充字符。</para>
		/// <para>Allow Null Values—指定字段是否支持空值。</para>
		/// </param>
		public ModifyRouteIdPadding(object InFeatureClass, object RouteIdPadding)
		{
			this.InFeatureClass = InFeatureClass;
			this.RouteIdPadding = RouteIdPadding;
		}

		/// <summary>
		/// <para>Tool Display Name : 修改路径 ID 填充</para>
		/// </summary>
		public override string DisplayName() => "修改路径 ID 填充";

		/// <summary>
		/// <para>Tool Name : ModifyRouteIdPadding</para>
		/// </summary>
		public override string ToolName() => "ModifyRouteIdPadding";

		/// <summary>
		/// <para>Tool Excute Name : locref.ModifyRouteIdPadding</para>
		/// </summary>
		public override string ExcuteName() => "locref.ModifyRouteIdPadding";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureClass, RouteIdPadding, OutFeatureClass! };

		/// <summary>
		/// <para>LRS Network Feature Class</para>
		/// <para>输入多字段路径 ID 网络图层，其中包含需要修改的填充、空值和长度值字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Route ID Padding</para>
		/// <para>在此值表中指定了要修改的字段及其对应的填充、空值和长度值。</para>
		/// <para>Field—要修改的字段。</para>
		/// <para>Length—要修改的字段的长度值。 字段长度应介于 1 和数据库字段的长度之间。</para>
		/// <para>Variable Length—指定长度值是可变值还是固定值。</para>
		/// <para>Enable Padding—指定字段是否支持填充。</para>
		/// <para>Padding Character—字段的填充字符。 默认为空格。</para>
		/// <para>Padding Location—指定应将填充应用于字段值的位置。</para>
		/// <para>左侧 - 将填充字符添加到字段中值的左侧。 这是默认设置。</para>
		/// <para>右侧 - 将填充字符添加到字段中值的右侧。</para>
		/// <para>左侧和右侧 - 将填充字符添加到字段中值的左右两侧。</para>
		/// <para>Pad if Null—指定当字段具有空值时是否添加填充字符。</para>
		/// <para>Allow Null Values—指定字段是否支持空值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object RouteIdPadding { get; set; }

		/// <summary>
		/// <para>Output Network Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ModifyRouteIdPadding SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
