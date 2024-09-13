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
	/// <para>Create Spatial Reference</para>
	/// <para>创建空间参考</para>
	/// <para>创建用于 模型构建器 的空间参考。</para>
	/// </summary>
	public class CreateSpatialReference : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		public CreateSpatialReference()
		{
		}

		/// <summary>
		/// <para>Tool Display Name : 创建空间参考</para>
		/// </summary>
		public override string DisplayName() => "创建空间参考";

		/// <summary>
		/// <para>Tool Name : CreateSpatialReference</para>
		/// </summary>
		public override string ToolName() => "CreateSpatialReference";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateSpatialReference</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateSpatialReference";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { SpatialReference!, SpatialReferenceTemplate!, XyDomain!, ZDomain!, MDomain!, Template!, ExpandRatio!, OutSpatialReference! };

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>要创建的空间参考的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Spatial Reference Template</para>
		/// <para>要用作模板的要素类或图层，用于设置空间参考的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? SpatialReferenceTemplate { get; set; }

		/// <summary>
		/// <para>XY Domain</para>
		/// <para>允许的 x,y 坐标的坐标范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEnvelope()]
		public object? XyDomain { get; set; }

		/// <summary>
		/// <para>Z Domain (min max)</para>
		/// <para>允许的 z 值的坐标范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ZDomain { get; set; }

		/// <summary>
		/// <para>M Domain (min max)</para>
		/// <para>允许的 m 值的坐标范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? MDomain { get; set; }

		/// <summary>
		/// <para>Template XYDomains</para>
		/// <para>可用于定义 XY 值域的要素类或图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Template { get; set; }

		/// <summary>
		/// <para>Grow XYDomain By Percentage</para>
		/// <para>展开 XY 值域时使用的百分比。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ExpandRatio { get; set; } = "0";

		/// <summary>
		/// <para>Output Spatial Reference</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPSpatialReference()]
		public object? OutSpatialReference { get; set; }

	}
}
