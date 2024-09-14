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
	/// <para>将图层符号系统与样式匹配</para>
	/// <para>可将输入字段或表达式字符串与输入样式中的符号名称进行匹配，从而根据输入字段或表达式为输入图层创建唯一值符号系统。</para>
	/// </summary>
	public class MatchLayerSymbologyToAStyle : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayer">
		/// <para>Input Layer</para>
		/// <para>匹配符号作为唯一值符号类应用于其上的输入图层或图层文件。输入图层可以包含点、线、面、多点或多面体符号系统。图层上的现有符号系统将被覆盖。</para>
		/// </param>
		/// <param name="MatchValues">
		/// <para>Match Values (Field or Expression)</para>
		/// <para>用于符号化输入图层的字段或表达式。字段值或结果表达式值与指定样式的符号名称相匹配，以将符号分配给结果符号类。</para>
		/// </param>
		/// <param name="InStyle">
		/// <para>Style</para>
		/// <para>包含名称与字段或表达式值相匹配的符号的样式。</para>
		/// </param>
		public MatchLayerSymbologyToAStyle(object InLayer, object MatchValues, object InStyle)
		{
			this.InLayer = InLayer;
			this.MatchValues = MatchValues;
			this.InStyle = InStyle;
		}

		/// <summary>
		/// <para>Tool Display Name : 将图层符号系统与样式匹配</para>
		/// </summary>
		public override string DisplayName() => "将图层符号系统与样式匹配";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLayer, MatchValues, InStyle, OutLayer };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>匹配符号作为唯一值符号类应用于其上的输入图层或图层文件。输入图层可以包含点、线、面、多点或多面体符号系统。图层上的现有符号系统将被覆盖。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InLayer { get; set; }

		/// <summary>
		/// <para>Match Values (Field or Expression)</para>
		/// <para>用于符号化输入图层的字段或表达式。字段值或结果表达式值与指定样式的符号名称相匹配，以将符号分配给结果符号类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCalculatorExpression()]
		public object MatchValues { get; set; }

		/// <summary>
		/// <para>Style</para>
		/// <para>包含名称与字段或表达式值相匹配的符号的样式。</para>
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
		public object OutLayer { get; set; }

	}
}
