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
	/// <para>Disable Derived Measure Fields</para>
	/// <para>禁用派生的测量字段</para>
	/// <para>禁用用于存储派生网络路径 ID、路径名称和测量字段的字段。</para>
	/// </summary>
	public class DisableDerivedMeasureFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>LRS Event Feature Class</para>
		/// <para>已注册到 LRS 的现有事件要素类或要素图层。</para>
		/// </param>
		public DisableDerivedMeasureFields(object InFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 禁用派生的测量字段</para>
		/// </summary>
		public override string DisplayName() => "禁用派生的测量字段";

		/// <summary>
		/// <para>Tool Name : DisableDerivedMeasureFields</para>
		/// </summary>
		public override string ToolName() => "DisableDerivedMeasureFields";

		/// <summary>
		/// <para>Tool Excute Name : locref.DisableDerivedMeasureFields</para>
		/// </summary>
		public override string ExcuteName() => "locref.DisableDerivedMeasureFields";

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
		public override object[] Parameters() => new object[] { InFeatureClass, OutFeatureClass! };

		/// <summary>
		/// <para>LRS Event Feature Class</para>
		/// <para>已注册到 LRS 的现有事件要素类或要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Updated Input Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

	}
}
