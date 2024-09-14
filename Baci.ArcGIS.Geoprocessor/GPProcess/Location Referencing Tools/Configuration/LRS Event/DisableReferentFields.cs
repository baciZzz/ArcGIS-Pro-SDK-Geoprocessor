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
	/// <para>Disable Referent Fields</para>
	/// <para>禁用参考字段</para>
	/// <para>禁用现有线性参考系统 (LRS) 事件要素类或要素图层的参考字段。 它不会删除参考列；它将从 Lrs_Metadata 表中移除参考列信息。</para>
	/// </summary>
	public class DisableReferentFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>LRS Event Feature Class</para>
		/// <para>LRS 事件的输入要素类或要素图层。</para>
		/// </param>
		public DisableReferentFields(object InFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 禁用参考字段</para>
		/// </summary>
		public override string DisplayName() => "禁用参考字段";

		/// <summary>
		/// <para>Tool Name : DisableReferentFields</para>
		/// </summary>
		public override string ToolName() => "DisableReferentFields";

		/// <summary>
		/// <para>Tool Excute Name : locref.DisableReferentFields</para>
		/// </summary>
		public override string ExcuteName() => "locref.DisableReferentFields";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureClass, OutFeatureClass! };

		/// <summary>
		/// <para>LRS Event Feature Class</para>
		/// <para>LRS 事件的输入要素类或要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Updated LRS Event Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

	}
}
