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
	/// <para>Build Raster Attribute Table</para>
	/// <para>构建栅格属性表</para>
	/// <para>使用有关栅格数据集中各个类的信息创建或更新表。此方法主要用于离散数据。</para>
	/// </summary>
	public class BuildRasterAttributeTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>将向其添加表格的输入栅格数据集。如果像素类型为浮点型或双精度，此工具则不会运行。</para>
		/// </param>
		public BuildRasterAttributeTable(object InRaster)
		{
			this.InRaster = InRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 构建栅格属性表</para>
		/// </summary>
		public override string DisplayName() => "构建栅格属性表";

		/// <summary>
		/// <para>Tool Name : BuildRasterAttributeTable</para>
		/// </summary>
		public override string ToolName() => "BuildRasterAttributeTable";

		/// <summary>
		/// <para>Tool Excute Name : management.BuildRasterAttributeTable</para>
		/// </summary>
		public override string ExcuteName() => "management.BuildRasterAttributeTable";

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
		public override object[] Parameters() => new object[] { InRaster, Overwrite, OutRaster };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>将向其添加表格的输入栅格数据集。如果像素类型为浮点型或双精度，此工具则不会运行。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Overwrite</para>
		/// <para>指定现有表是否将被覆盖。</para>
		/// <para>未选中 - 现有的栅格属性表将不会被覆盖，所有编辑都将追加到当前表中。这是默认设置。</para>
		/// <para>选中 - 现有的栅格属性表将被覆盖，并将创建一个新的栅格属性表。</para>
		/// <para><see cref="OverwriteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Overwrite { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object OutRaster { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Overwrite</para>
		/// </summary>
		public enum OverwriteEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("覆盖")]
			Overwrite,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

#endregion
	}
}
