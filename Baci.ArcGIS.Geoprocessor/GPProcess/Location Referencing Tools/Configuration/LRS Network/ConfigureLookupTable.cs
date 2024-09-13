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
	/// <para>Configure Lookup Table</para>
	/// <para>配置查找表</para>
	/// <para>为多字段路径 ID 中使用的一个或多个字段配置查找表。</para>
	/// </summary>
	public class ConfigureLookupTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>LRS Network Feature Class</para>
		/// <para>将在其中配置查找表的输入 LRS 网络要素类。 网络必须具有多字段路径 ID。</para>
		/// </param>
		/// <param name="LookupTable">
		/// <para>Lookup Table</para>
		/// <para>包含街道名称及其对应 GNIS 代码列表的表。 它可以是独立表或位于 SDE 中。</para>
		/// </param>
		/// <param name="FieldAppliedTo">
		/// <para>Field Applied To</para>
		/// <para>将在其中配置查找表的 LRS 网络中的路径 ID 字段。</para>
		/// </param>
		/// <param name="LookupKey">
		/// <para>Lookup Key</para>
		/// <para>查找表中的键字段。</para>
		/// </param>
		public ConfigureLookupTable(object InFeatureClass, object LookupTable, object FieldAppliedTo, object LookupKey)
		{
			this.InFeatureClass = InFeatureClass;
			this.LookupTable = LookupTable;
			this.FieldAppliedTo = FieldAppliedTo;
			this.LookupKey = LookupKey;
		}

		/// <summary>
		/// <para>Tool Display Name : 配置查找表</para>
		/// </summary>
		public override string DisplayName() => "配置查找表";

		/// <summary>
		/// <para>Tool Name : ConfigureLookupTable</para>
		/// </summary>
		public override string ToolName() => "ConfigureLookupTable";

		/// <summary>
		/// <para>Tool Excute Name : locref.ConfigureLookupTable</para>
		/// </summary>
		public override string ExcuteName() => "locref.ConfigureLookupTable";

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
		public override object[] Parameters() => new object[] { InFeatureClass, LookupTable, FieldAppliedTo, LookupKey, LookupDisplay!, AllowAnyLookupValue!, OutFeatureClass! };

		/// <summary>
		/// <para>LRS Network Feature Class</para>
		/// <para>将在其中配置查找表的输入 LRS 网络要素类。 网络必须具有多字段路径 ID。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Lookup Table</para>
		/// <para>包含街道名称及其对应 GNIS 代码列表的表。 它可以是独立表或位于 SDE 中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object LookupTable { get; set; }

		/// <summary>
		/// <para>Field Applied To</para>
		/// <para>将在其中配置查找表的 LRS 网络中的路径 ID 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FieldAppliedTo { get; set; }

		/// <summary>
		/// <para>Lookup Key</para>
		/// <para>查找表中的键字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LookupKey { get; set; }

		/// <summary>
		/// <para>Lookup Display</para>
		/// <para>查找表描述字段。 此字段将显示在多字段路径 ID 的文本框中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LookupDisplay { get; set; }

		/// <summary>
		/// <para>Allow any lookup value</para>
		/// <para>指定是否可以添加不在查找表中的值。 选中此选项时，无法配置查找显示参数。</para>
		/// <para>选中 - 允许在表中不存在值时配置值。</para>
		/// <para>未选中 - 不允许配置查找显示值。 这是默认设置。</para>
		/// <para><see cref="AllowAnyLookupValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AllowAnyLookupValue { get; set; } = "false";

		/// <summary>
		/// <para>Output Network Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConfigureLookupTable SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Allow any lookup value</para>
		/// </summary>
		public enum AllowAnyLookupValueEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ALLOW_ANY_VALUE")]
			ALLOW_ANY_VALUE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_ALLOW_ANY_VALUE")]
			DO_NOT_ALLOW_ANY_VALUE,

		}

#endregion
	}
}
