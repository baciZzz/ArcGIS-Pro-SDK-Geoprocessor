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
	/// <para>Disable COGO</para>
	/// <para>禁用 COGO</para>
	/// <para>可禁用线要素类上的 COGO 并移除 COGO 字段和启用了 COGO 的标注和符号系统。可删除 COGO 字段。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class DisableCOGO : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLineFeatures">
		/// <para>Input Line Features</para>
		/// <para>将禁用 COGO 的线要素类。</para>
		/// </param>
		public DisableCOGO(object InLineFeatures)
		{
			this.InLineFeatures = InLineFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 禁用 COGO</para>
		/// </summary>
		public override string DisplayName() => "禁用 COGO";

		/// <summary>
		/// <para>Tool Name : DisableCOGO</para>
		/// </summary>
		public override string ToolName() => "DisableCOGO";

		/// <summary>
		/// <para>Tool Excute Name : management.DisableCOGO</para>
		/// </summary>
		public override string ExcuteName() => "management.DisableCOGO";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLineFeatures, UpdatedLineFeatures };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>将禁用 COGO 的线要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLineFeatures { get; set; }

		/// <summary>
		/// <para>Updated Input Line features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object UpdatedLineFeatures { get; set; }

	}
}
