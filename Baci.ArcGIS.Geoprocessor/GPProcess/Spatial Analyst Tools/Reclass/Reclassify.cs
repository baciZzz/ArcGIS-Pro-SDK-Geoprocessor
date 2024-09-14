using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Reclassify</para>
	/// <para>重分类</para>
	/// <para>重分类（或更改）栅格中的值。</para>
	/// </summary>
	public class Reclassify : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>要进行重分类的输入栅格。</para>
		/// </param>
		/// <param name="ReclassField">
		/// <para>Reclass field</para>
		/// <para>表示要进行重分类的值的字段。</para>
		/// </param>
		/// <param name="Remap">
		/// <para>Reclassification</para>
		/// <para>用于定义值的重分类方式的重映射表。 使用该表，其选项如下所示：</para>
		/// <para>可将输入栅格的值分类为值范围或单个值。 该表将分别以开始值、结束值或单个唯一值进行显示。 如果输入是内容中的图层，它将导入符号系统的唯一值或分类中断。</para>
		/// <para>指定将在输出栅格中分配的新值。 只支持整数值。</para>
		/// <para>使用分类或唯一选项根据输入栅格中的值生成重映射表。 分类选项将打开一个对话框，并允许您根据其中一种数据分类方法和类数量指定一种方法。 唯一选项将使用输入数据集中的唯一值来填充重映射表。</para>
		/// <para>对新值取反选项对新值列表反向排序（例如 1,2,3 重排序为 3,2,1）。</para>
		/// <para>如果要对表进行修改，可以在表的空白单元格中进行输入以添加新条目，然后按 Enter 键。 此操作将验证新条目并为后续输入创建一个新的空行。 要删除行，可以选中一行或多行，然后按 Delete 键。</para>
		/// <para>使用加载选项和保存选项可以保存重映射以供日后使用，并可将其用于其他输入数据或用于快速重复某一分析。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出重分类栅格。</para>
		/// <para>输出将始终为整型。</para>
		/// </param>
		public Reclassify(object InRaster, object ReclassField, object Remap, object OutRaster)
		{
			this.InRaster = InRaster;
			this.ReclassField = ReclassField;
			this.Remap = Remap;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 重分类</para>
		/// </summary>
		public override string DisplayName() => "重分类";

		/// <summary>
		/// <para>Tool Name : 重分类</para>
		/// </summary>
		public override string ToolName() => "重分类";

		/// <summary>
		/// <para>Tool Excute Name : sa.Reclassify</para>
		/// </summary>
		public override string ExcuteName() => "sa.Reclassify";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, ReclassField, Remap, OutRaster, MissingValues };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>要进行重分类的输入栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Reclass field</para>
		/// <para>表示要进行重分类的值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain(GUID = "{4B6CA858-5716-4AC3-A2EE-70EE2D29C1BD}", UseRasterFields = true)]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object ReclassField { get; set; }

		/// <summary>
		/// <para>Reclassification</para>
		/// <para>用于定义值的重分类方式的重映射表。 使用该表，其选项如下所示：</para>
		/// <para>可将输入栅格的值分类为值范围或单个值。 该表将分别以开始值、结束值或单个唯一值进行显示。 如果输入是内容中的图层，它将导入符号系统的唯一值或分类中断。</para>
		/// <para>指定将在输出栅格中分配的新值。 只支持整数值。</para>
		/// <para>使用分类或唯一选项根据输入栅格中的值生成重映射表。 分类选项将打开一个对话框，并允许您根据其中一种数据分类方法和类数量指定一种方法。 唯一选项将使用输入数据集中的唯一值来填充重映射表。</para>
		/// <para>对新值取反选项对新值列表反向排序（例如 1,2,3 重排序为 3,2,1）。</para>
		/// <para>如果要对表进行修改，可以在表的空白单元格中进行输入以添加新条目，然后按 Enter 键。 此操作将验证新条目并为后续输入创建一个新的空行。 要删除行，可以选中一行或多行，然后按 Delete 键。</para>
		/// <para>使用加载选项和保存选项可以保存重映射以供日后使用，并可将其用于其他输入数据或用于快速重复某一分析。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSARemap()]
		[GPSARemapDomain()]
		[RemapType("Number", "String", "None")]
		public object Remap { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出重分类栅格。</para>
		/// <para>输出将始终为整型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Change missing values to NoData</para>
		/// <para>指示重分类表中的缺失值是保持不变还是映射为 NoData。</para>
		/// <para>未选中 - 表明如果输入栅格的任何像元位置含有未在重映射表中出现或重分类的值，则该值应保持不变，并且应写入输出栅格中的相应位置。 这是默认设置。</para>
		/// <para>选中 - 表明如果输入栅格的任何像元位置含有未在重映射表中出现或重分类的值，则该值将在输出栅格中的相应位置被重分类为 NoData。</para>
		/// <para><see cref="MissingValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MissingValues { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Reclassify SetEnviroment(int? autoCommit = null, object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Change missing values to NoData</para>
		/// </summary>
		public enum MissingValuesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DATA")]
			DATA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("NODATA")]
			NODATA,

		}

#endregion
	}
}
