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
	/// <para>Enable COGO</para>
	/// <para>启用 COGO</para>
	/// <para>可启用线要素类上的 COGO 并将 COGO 字段和启用了 COGO 的标注添加到线要素类。 COGO 字段存储用于相对彼此创建线要素的尺寸。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class EnableCOGO : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLineFeatures">
		/// <para>Input Line Features</para>
		/// <para>将启用 COGO 的线要素类。</para>
		/// </param>
		public EnableCOGO(object InLineFeatures)
		{
			this.InLineFeatures = InLineFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 启用 COGO</para>
		/// </summary>
		public override string DisplayName() => "启用 COGO";

		/// <summary>
		/// <para>Tool Name : EnableCOGO</para>
		/// </summary>
		public override string ToolName() => "EnableCOGO";

		/// <summary>
		/// <para>Tool Excute Name : management.EnableCOGO</para>
		/// </summary>
		public override string ExcuteName() => "management.EnableCOGO";

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
		public override object[] Parameters() => new object[] { InLineFeatures, UpdatedLineFeatures };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>将启用 COGO 的线要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLineFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object UpdatedLineFeatures { get; set; }

	}
}
