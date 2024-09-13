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
	/// <para>Single Output Map Algebra</para>
	/// <para>Single Output Map Algebra</para>
	/// <para>Execute a Grid's map algebra statement to produce a raster.</para>
	/// </summary>
	[Obsolete()]
	public class SingleOutputMapAlgebra : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="ExpressionString">
		/// <para>expression_string</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>out_raster</para>
		/// </param>
		public SingleOutputMapAlgebra(object ExpressionString, object OutRaster)
		{
			this.ExpressionString = ExpressionString;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Single Output Map Algebra</para>
		/// </summary>
		public override string DisplayName() => "Single Output Map Algebra";

		/// <summary>
		/// <para>Tool Name : SingleOutputMapAlgebra</para>
		/// </summary>
		public override string ToolName() => "SingleOutputMapAlgebra";

		/// <summary>
		/// <para>Tool Excute Name : sa.SingleOutputMapAlgebra</para>
		/// </summary>
		public override string ExcuteName() => "sa.SingleOutputMapAlgebra";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { ExpressionString, OutRaster, InData };

		/// <summary>
		/// <para>expression_string</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAMapAlgebraExp()]
		public object ExpressionString { get; set; }

		/// <summary>
		/// <para>out_raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>in_data</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "GPRasterFormulated", "DEFeatureClass", "GPFeatureLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InData { get; set; }

	}
}
