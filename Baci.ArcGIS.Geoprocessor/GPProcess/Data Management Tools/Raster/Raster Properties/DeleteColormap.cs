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
	/// <para>Delete Colormap</para>
	/// <para>删除色彩映射表</para>
	/// <para>移除与栅格数据集相关的色彩映射表。</para>
	/// </summary>
	public class DeleteColormap : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>包含要移除的色彩映射表的栅格数据集。</para>
		/// </param>
		public DeleteColormap(object InRaster)
		{
			this.InRaster = InRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 删除色彩映射表</para>
		/// </summary>
		public override string DisplayName() => "删除色彩映射表";

		/// <summary>
		/// <para>Tool Name : DeleteColormap</para>
		/// </summary>
		public override string ToolName() => "DeleteColormap";

		/// <summary>
		/// <para>Tool Excute Name : management.DeleteColormap</para>
		/// </summary>
		public override string ExcuteName() => "management.DeleteColormap";

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
		public override object[] Parameters() => new object[] { InRaster, OutRaster };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>包含要移除的色彩映射表的栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Updated Input Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object OutRaster { get; set; }

	}
}
