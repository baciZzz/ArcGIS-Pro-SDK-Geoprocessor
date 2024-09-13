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
	/// <para>Match Layer Symbology To A Style</para>
	/// <para>Match Layer Symbology To A Style</para>
	/// <para>Creates unique value symbology for the input layer based on the input field or expression by matching input field or expression strings to symbol names from the input style.</para>
	/// </summary>
	public class MatchLayerSymbologyToAStyle : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayer">
		/// <para>Input Layer</para>
		/// <para>The input layer or layer file to which matched symbols are applied as unique values symbol classes. The input layer can contain point, line, polygon, multipoint, or multipatch symbology. Existing symbology on the layer is overwritten.</para>
		/// </param>
		/// <param name="MatchValues">
		/// <para>Match Values (Field or Expression)</para>
		/// <para>The field or expression on which the input layer is symbolized. The field values or resultant expression values are matched to symbol names in the specified style to assign symbols to the resulting symbol classes.</para>
		/// </param>
		/// <param name="InStyle">
		/// <para>Style</para>
		/// <para>The style containing symbols with names matching the field or expression values.</para>
		/// </param>
		public MatchLayerSymbologyToAStyle(object InLayer, object MatchValues, object InStyle)
		{
			this.InLayer = InLayer;
			this.MatchValues = MatchValues;
			this.InStyle = InStyle;
		}

		/// <summary>
		/// <para>Tool Display Name : Match Layer Symbology To A Style</para>
		/// </summary>
		public override string DisplayName() => "Match Layer Symbology To A Style";

		/// <summary>
		/// <para>Tool Name : MatchLayerSymbologyToAStyle</para>
		/// </summary>
		public override string ToolName() => "MatchLayerSymbologyToAStyle";

		/// <summary>
		/// <para>Tool Excute Name : management.MatchLayerSymbologyToAStyle</para>
		/// </summary>
		public override string ExcuteName() => "management.MatchLayerSymbologyToAStyle";

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
		public override object[] Parameters() => new object[] { InLayer, MatchValues, InStyle, OutLayer! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The input layer or layer file to which matched symbols are applied as unique values symbol classes. The input layer can contain point, line, polygon, multipoint, or multipatch symbology. Existing symbology on the layer is overwritten.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InLayer { get; set; }

		/// <summary>
		/// <para>Match Values (Field or Expression)</para>
		/// <para>The field or expression on which the input layer is symbolized. The field values or resultant expression values are matched to symbol names in the specified style to assign symbols to the resulting symbol classes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCalculatorExpression()]
		public object MatchValues { get; set; }

		/// <summary>
		/// <para>Style</para>
		/// <para>The style containing symbols with names matching the field or expression values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InStyle { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutLayer { get; set; }

	}
}
