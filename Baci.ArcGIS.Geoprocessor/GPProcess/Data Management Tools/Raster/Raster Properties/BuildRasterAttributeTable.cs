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
	/// <para>将栅格属性表添加到栅格数据集或更新现有的数据集。 此方法主要用于离散数据。</para>
	/// </summary>
	public class BuildRasterAttributeTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>将向其添加表格的输入栅格数据集。 如果像素类型为浮点型或双精度，此工具则不会运行。</para>
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
		public override object[] Parameters() => new object[] { InRaster, Overwrite!, OutRaster!, ConvertColormap! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>将向其添加表格的输入栅格数据集。 如果像素类型为浮点型或双精度，此工具则不会运行。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Overwrite</para>
		/// <para>指定现有表是否将被覆盖。</para>
		/// <para>未选中 - 现有的栅格属性表将不会被覆盖，所有编辑都将追加到此表中。 这是默认设置。</para>
		/// <para>选中 - 现有的栅格属性表将被覆盖，并将创建一个新的栅格属性表。</para>
		/// <para><see cref="OverwriteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Overwrite { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? OutRaster { get; set; }

		/// <summary>
		/// <para>Convert colormap</para>
		/// <para>指定是否将色彩映射表转换为栅格属性表。 输出栅格属性表将具有包含色彩映射表中颜色值的 Red、Green 和 Blue 字段。 这些字段定义了相应类值的显示颜色。</para>
		/// <para>此参数仅在输入栅格参数值包含关联的色彩映射表时适用。</para>
		/// <para>选中 - 将色彩映射表转换为栅格属性表。</para>
		/// <para>未选中 - 不将色彩映射表转换为栅格属性表。 这是默认设置。</para>
		/// <para>转换色彩映射表—将色彩映射表转换为栅格属性表。</para>
		/// <para>无—不将色彩映射表转换为栅格属性表。 这是默认设置。</para>
		/// <para><see cref="ConvertColormapEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ConvertColormap { get; set; } = "false";

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

		/// <summary>
		/// <para>Convert colormap</para>
		/// </summary>
		public enum ConvertColormapEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ConvertColormap")]
			ConvertColormap,

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
