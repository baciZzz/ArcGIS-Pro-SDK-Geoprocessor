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
	/// <para>Enable Stationing Fields</para>
	/// <para>启用定点字段</para>
	/// <para>启用或修改定点字段，这样您可以管理已注册 LRS 事件的参考信息。</para>
	/// </summary>
	public class EnableStationingFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>Event Feature Class</para>
		/// <para>已注册到 LRS 的现有事件要素类或要素图层。</para>
		/// </param>
		public EnableStationingFields(object InFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 启用定点字段</para>
		/// </summary>
		public override string DisplayName() => "启用定点字段";

		/// <summary>
		/// <para>Tool Name : EnableStationingFields</para>
		/// </summary>
		public override string ToolName() => "EnableStationingFields";

		/// <summary>
		/// <para>Tool Excute Name : locref.EnableStationingFields</para>
		/// </summary>
		public override string ExcuteName() => "locref.EnableStationingFields";

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
		public override object[] Parameters() => new object[] { InFeatureClass, StationField!, BackStationField!, StationDirectionField!, StationMeasureUnits!, DecreasingStationValues!, OutFeatureClass! };

		/// <summary>
		/// <para>Event Feature Class</para>
		/// <para>已注册到 LRS 的现有事件要素类或要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Station Field</para>
		/// <para>将用作起始参考站点的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? StationField { get; set; }

		/// <summary>
		/// <para>Back Station Field</para>
		/// <para>将用作后站的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? BackStationField { get; set; }

		/// <summary>
		/// <para>Station Value Direction Field</para>
		/// <para>用于指示增加站点的方向的字段，朝着或者远离路径的校准方向增加。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? StationDirectionField { get; set; }

		/// <summary>
		/// <para>Station Measure Units</para>
		/// <para>指定将用于定点的测量单位。</para>
		/// <para>英里(美制测量)—测量单位为英里。 这是默认设置。</para>
		/// <para>英寸(美制测量)—测量单位为英寸。</para>
		/// <para>英尺(美制测量)—测量单位为英尺。</para>
		/// <para>码(美制测量)—测量单位为码。</para>
		/// <para>海里(美制测量)—测量单位为海里。</para>
		/// <para>英尺(国际)—测量单位为国际英尺。</para>
		/// <para>毫米—测量单位为毫米。</para>
		/// <para>厘米—测量单位为厘米。</para>
		/// <para>米—测量单位为米。</para>
		/// <para>千米—测量单位为千米。</para>
		/// <para>分米—测量单位为分米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StationMeasureUnits { get; set; }

		/// <summary>
		/// <para>Decreasing Station Values</para>
		/// <para>用户提供的逗号分隔列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DecreasingStationValues { get; set; }

		/// <summary>
		/// <para>Output Event Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

	}
}
