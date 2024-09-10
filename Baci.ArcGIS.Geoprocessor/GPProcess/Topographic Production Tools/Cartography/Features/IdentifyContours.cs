using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Identify Contours</para>
	/// <para>Identifies types of contours and applies hypsographic codes to input features.</para>
	/// </summary>
	public class IdentifyContours : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InContourFeatures">
		/// <para>Input Contours</para>
		/// <para>The input contours that will be updated with the specified contour codes.</para>
		/// </param>
		/// <param name="InRasters">
		/// <para>Input Rasters</para>
		/// <para>The rasters used to derive elevations of points inside contours to correctly identify the types of contours.</para>
		/// </param>
		/// <param name="ContourHeightField">
		/// <para>Contour Height field</para>
		/// <para>The field in the input contour feature class that contains elevation values. This field type must be numeric.</para>
		/// </param>
		/// <param name="ContourCodeField">
		/// <para>Contour Code field</para>
		/// <para>The field in the input contour feature class that will be updated with the appropriate domain code.</para>
		/// </param>
		public IdentifyContours(object InContourFeatures, object InRasters, object ContourHeightField, object ContourCodeField)
		{
			this.InContourFeatures = InContourFeatures;
			this.InRasters = InRasters;
			this.ContourHeightField = ContourHeightField;
			this.ContourCodeField = ContourCodeField;
		}

		/// <summary>
		/// <para>Tool Display Name : Identify Contours</para>
		/// </summary>
		public override string DisplayName() => "Identify Contours";

		/// <summary>
		/// <para>Tool Name : IdentifyContours</para>
		/// </summary>
		public override string ToolName() => "IdentifyContours";

		/// <summary>
		/// <para>Tool Excute Name : topographic.IdentifyContours</para>
		/// </summary>
		public override string ExcuteName() => "topographic.IdentifyContours";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise() => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InContourFeatures, InRasters, ContourHeightField, ContourCodeField, ContourIndexInterval, IndexCode, IntermediateCode, DepressionCode, DepressionIntermediateCode, UpdatedContourFeatures };

		/// <summary>
		/// <para>Input Contours</para>
		/// <para>The input contours that will be updated with the specified contour codes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InContourFeatures { get; set; }

		/// <summary>
		/// <para>Input Rasters</para>
		/// <para>The rasters used to derive elevations of points inside contours to correctly identify the types of contours.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InRasters { get; set; }

		/// <summary>
		/// <para>Contour Height field</para>
		/// <para>The field in the input contour feature class that contains elevation values. This field type must be numeric.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double", "Long", "Short")]
		public object ContourHeightField { get; set; }

		/// <summary>
		/// <para>Contour Code field</para>
		/// <para>The field in the input contour feature class that will be updated with the appropriate domain code.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short", "Text")]
		public object ContourCodeField { get; set; }

		/// <summary>
		/// <para>Contour Index Interval</para>
		/// <para>The interval or distance between index contour lines. The default is 100.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object ContourIndexInterval { get; set; } = "100";

		/// <summary>
		/// <para>Index Code</para>
		/// <para>The value used to populate the Contour Code field parameter when index contours are identified. The default is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object IndexCode { get; set; } = "1";

		/// <summary>
		/// <para>Intermediate Code</para>
		/// <para>The value used to populate the Contour Code field parameter when intermediate contours are identified. The default is 2.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object IntermediateCode { get; set; } = "2";

		/// <summary>
		/// <para>Depression Code</para>
		/// <para>The value used to populate the Contour Code field parameter when depression contours are identified. The default is 5.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DepressionCode { get; set; } = "5";

		/// <summary>
		/// <para>Depression Intermediate Code</para>
		/// <para>The value used to populate the Contour Code field parameter when depression intermediate contours are identified. The default is 6.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DepressionIntermediateCode { get; set; } = "6";

		/// <summary>
		/// <para>Updated Contours</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object UpdatedContourFeatures { get; set; }

	}
}
