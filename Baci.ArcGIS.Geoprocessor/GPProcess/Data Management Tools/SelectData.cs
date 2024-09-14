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
	/// <para>Select Data</para>
	/// <para>选择数据</para>
	/// <para>选择数据工具在父数据元素（如文件夹、地理数据库、要素数据集或 coverage）中选择数据。</para>
	/// </summary>
	[Obsolete()]
	public class SelectData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataelement">
		/// <para>Input Data Element</para>
		/// <para>输入数据元素可以为文件夹、地理数据库或要素数据集。</para>
		/// </param>
		public SelectData(object InDataelement)
		{
			this.InDataelement = InDataelement;
		}

		/// <summary>
		/// <para>Tool Display Name : 选择数据</para>
		/// </summary>
		public override string DisplayName() => "选择数据";

		/// <summary>
		/// <para>Tool Name : SelectData</para>
		/// </summary>
		public override string ToolName() => "SelectData";

		/// <summary>
		/// <para>Tool Excute Name : management.SelectData</para>
		/// </summary>
		public override string ExcuteName() => "management.SelectData";

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
		public override object[] Parameters() => new object[] { InDataelement, OutDataelement!, OutDataelementDerived! };

		/// <summary>
		/// <para>Input Data Element</para>
		/// <para>输入数据元素可以为文件夹、地理数据库或要素数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataelement { get; set; }

		/// <summary>
		/// <para>Child Data Element</para>
		/// <para>子数据元素包含在输入数据元素中。指定输入数据元素后，子数据元素控件将包含一个下拉列表，列出输入数据元素中包含的数据元素。例如，如果输入为要素数据集，则要素数据集中的所有要素类都将包括在下拉列表中。可从此列表中选择单个元素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OutDataelement { get; set; }

		/// <summary>
		/// <para>Child  Data Element</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutDataelementDerived { get; set; }

	}
}
