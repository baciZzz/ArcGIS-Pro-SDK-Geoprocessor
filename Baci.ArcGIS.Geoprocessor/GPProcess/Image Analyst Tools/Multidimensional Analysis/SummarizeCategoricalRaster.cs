using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ImageAnalystTools
{
	/// <summary>
	/// <para>Summarize Categorical Raster</para>
	/// <para>汇总分类栅格</para>
	/// <para>用于生成一个表，其中包含输入分类栅格的每个剖切片中，每个类的像素计数。</para>
	/// </summary>
	public class SummarizeCategoricalRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Categorical Raster</para>
		/// <para>输入多维分类栅格。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Summary Table</para>
		/// <para>输出汇总表。支持地理数据库、数据库、文本、Microsoft Excel 和逗号分隔值 (CSV) 表。</para>
		/// </param>
		public SummarizeCategoricalRaster(object InRaster, object OutTable)
		{
			this.InRaster = InRaster;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 汇总分类栅格</para>
		/// </summary>
		public override string DisplayName() => "汇总分类栅格";

		/// <summary>
		/// <para>Tool Name : SummarizeCategoricalRaster</para>
		/// </summary>
		public override string ToolName() => "SummarizeCategoricalRaster";

		/// <summary>
		/// <para>Tool Excute Name : ia.SummarizeCategoricalRaster</para>
		/// </summary>
		public override string ExcuteName() => "ia.SummarizeCategoricalRaster";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise() => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutTable, Dimension!, Aoi!, AoiIdField! };

		/// <summary>
		/// <para>Input Categorical Raster</para>
		/// <para>输入多维分类栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Summary Table</para>
		/// <para>输出汇总表。支持地理数据库、数据库、文本、Microsoft Excel 和逗号分隔值 (CSV) 表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Dimension</para>
		/// <para>用于汇总的输入维度。如果存在多个维度，并且未指定任何值，则将使用维度值的所有组合来汇总所有切片。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Dimension { get; set; }

		/// <summary>
		/// <para>Area Of Interest</para>
		/// <para>包含要在计算每个类别的像素计数时使用的一个或多个感兴趣区域的面要素图层。如果未指定感兴趣区域，则整个栅格数据集将包含在分析中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object? Aoi { get; set; }

		/// <summary>
		/// <para>Area Of Interest ID Field</para>
		/// <para>面要素图层中用于定义每个感兴趣区域的字段。支持文本和整数字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object? AoiIdField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SummarizeCategoricalRaster SetEnviroment(object? extent = null)
		{
			base.SetEnv(extent: extent);
			return this;
		}

	}
}
