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
	/// <para>Generates a table containing the pixel count for each class, in each slice of an input categorical raster.</para>
	/// </summary>
	public class SummarizeCategoricalRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Categorical Raster</para>
		/// <para>The input multidimensional, categorical raster.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Summary Table</para>
		/// <para>The output summary table. Geodatabase, database, text, Microsoft Excel, and comma-separated value (CSV) tables are supported.</para>
		/// </param>
		public SummarizeCategoricalRaster(object InRaster, object OutTable)
		{
			this.InRaster = InRaster;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Summarize Categorical Raster</para>
		/// </summary>
		public override string DisplayName() => "Summarize Categorical Raster";

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
		public override object[] Parameters() => new object[] { InRaster, OutTable, Dimension, Aoi, AoiIdField };

		/// <summary>
		/// <para>Input Categorical Raster</para>
		/// <para>The input multidimensional, categorical raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Summary Table</para>
		/// <para>The output summary table. Geodatabase, database, text, Microsoft Excel, and comma-separated value (CSV) tables are supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Dimension</para>
		/// <para>The input dimension to use for the summary. If there is more than one dimension and no value is specified, all slices will be summarized using all combinations of dimension values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Dimension { get; set; }

		/// <summary>
		/// <para>Area Of Interest</para>
		/// <para>The polygon feature layer containing the area or areas of interest to use when calculating the pixel count per category. If no area of interest is specified, the entire raster dataset will be included in the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object Aoi { get; set; }

		/// <summary>
		/// <para>Area Of Interest ID Field</para>
		/// <para>The field in the polygon feature layer that defines each area of interest. Text and integer fields are supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object AoiIdField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SummarizeCategoricalRaster SetEnviroment(object extent = null )
		{
			base.SetEnv(extent: extent);
			return this;
		}

	}
}
