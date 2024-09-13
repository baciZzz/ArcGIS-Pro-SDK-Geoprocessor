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
	/// <para>Convert Coordinate Notation</para>
	/// <para>转换坐标记法</para>
	/// <para>将一个或两个字段包含的坐标记法从一种注记格式转换为另一种注记格式。</para>
	/// </summary>
	public class ConvertCoordinateNotation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>输入表或文本文件。 点要素同样有效。</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output Feature Class</para>
		/// <para>输出点要素类。 属性表将包括输入表的所有字段以及以输出格式表示转换值的字段。</para>
		/// </param>
		/// <param name="XField">
		/// <para>X Field (Longitude)</para>
		/// <para>输入表中包含经度值的字段。</para>
		/// <para>对于输入坐标格式参数的 DD 2、DD 数字、DDM 2 和 DMS 2 选项，该字段为经度字段。</para>
		/// <para>对于 DD 1、DDM 1 和 DMS 1 选项，此字段包含单个字符串中的纬度值和经度值。</para>
		/// <para>对于 Gars、Georef、Georef 16、UTM 带、UTM 波段、USNG、USNG 16、MGRS 和 MGRS 16 选项，此字段在单个文本字段中包含一个字母数字记法。</para>
		/// </param>
		/// <param name="YField">
		/// <para>Y Field (Latitude)</para>
		/// <para>输入表中包含纬度值的字段。</para>
		/// <para>对于输入坐标格式参数的 DD 2、DD 数字、DDM 2 和 DMS 2 选项，该字段为纬度字段。</para>
		/// <para>选择其中一种单字符串格式时，此参数将处于非活动状态。</para>
		/// </param>
		/// <param name="InputCoordinateFormat">
		/// <para>Input Coordinate Format</para>
		/// <para>指定输入字段的坐标格式。</para>
		/// <para>DD 1—经度值和纬度值位于同一个字段。两个值之间用空格、逗号或斜线进行分隔。</para>
		/// <para>DD 2—经度值和纬度值位于两个不同的字段中。这是默认设置。</para>
		/// <para>DDM 1—经度值和纬度值位于同一个字段。两个值之间用空格、逗号或斜线进行分隔。</para>
		/// <para>DDM 2— 经度值和纬度值位于两个不同的字段中。</para>
		/// <para>DMS 1—经度值和纬度值位于同一个字段。两个值之间用空格、逗号或斜线进行分隔。</para>
		/// <para>DMS 2—经度值和纬度值位于两个不同的字段中。</para>
		/// <para>Gars—全球区域参考系。根据纬度和经度，该参考系将世界划分成大量的格网单元。</para>
		/// <para>Georef—世界地理参考系。一个基于格网的参考系统，将世界划分成 15 度的地图方格，然后再细分成更小的地图方格。</para>
		/// <para>Georef 16—世界地理参考系，精度为 16 位。</para>
		/// <para>UTM 带—UTM 带编号后的字母 N 或 S 仅用于指定北半球或南半球。</para>
		/// <para>UTM 波段—UTM 带编号后的字母用于指定 20 个纬度带之一。N 或 S 不用于指定半球。</para>
		/// <para>USNG—美国国家格网。与 MGRS 几乎完全相同，但其基准面采用的是北美洲基准面 1983 (NAD83)。</para>
		/// <para>USNG 16—美国国家格网，精度高于 16 位。</para>
		/// <para>MGRS—军事格网参考系。按照 UTM 坐标，将世界划分成 6 度的经度带和 20 个纬度带，但 MGRS 将这些格网区域进一步划分成更小的 100,000 米格网。这些 100,000 米的格网再被细分成 10,000 米、1,000 米、100 米、10 米 和 1 米格网。</para>
		/// <para>MGRS 16—军事格网参考系，精度为 16 位。</para>
		/// <para>Shape—仅在选择点要素图层作为输入时可用。每个点的坐标都用于定义输出格式。</para>
		/// <para>DD、DDM、DMS 和 UTM 也是有效关键字；可通过（在对话框中）直接输入或在脚本中传递值的方式来使用这些关键字。但是，带下划线和限定符的关键字包含更多有关字段值的信息。</para>
		/// </param>
		/// <param name="OutputCoordinateFormat">
		/// <para>Output Coordinate Format</para>
		/// <para>指定输入记法转换后的坐标格式。</para>
		/// <para>DD 1—经度值和纬度值位于同一个字段。两个值之间用空格、逗号或斜线进行分隔。</para>
		/// <para>DD 2—经度值和纬度值位于两个不同的字段中。</para>
		/// <para>DD 数字—经度值和纬度值位于两个不同的“双精度”类型字段中。 “西”部和“南”部的值以减号表示。</para>
		/// <para>DDM 1—经度值和纬度值位于同一个字段。两个值之间用空格、逗号或斜线进行分隔。</para>
		/// <para>DDM 2— 经度值和纬度值位于两个不同的字段中。</para>
		/// <para>DMS 1—经度值和纬度值位于同一个字段。两个值之间用空格、逗号或斜线进行分隔。</para>
		/// <para>DMS 2—经度值和纬度值位于两个不同的字段中。</para>
		/// <para>Gars—全球区域参考系。根据纬度和经度，该参考系将世界划分成大量的格网单元。</para>
		/// <para>Georef—世界地理参考系。一个基于格网的参考系统，将世界划分成 15 度的地图方格，然后再细分成更小的地图方格。</para>
		/// <para>Georef 16—世界地理参考系，精度为 16 位。</para>
		/// <para>UTM 带—UTM 带编号后的字母 N 或 S 仅用于指定北半球或南半球。</para>
		/// <para>UTM 波段—UTM 带编号后的字母用于指定 20 个纬度带之一。N 或 S 不用于指定半球。</para>
		/// <para>USNG—美国国家格网。与 MGRS 几乎完全相同，但其基准面采用的是北美洲基准面 1983 (NAD83)。</para>
		/// <para>USNG 16—美国国家格网，精度高于 16 位。</para>
		/// <para>MGRS—军事格网参考系。按照 UTM 坐标，将世界划分成 6 度的经度带和 20 个纬度带，但 MGRS 将这些格网区域进一步划分成更小的 100,000 米格网。这些 100,000 米的格网再被细分成 10,000 米、1,000 米、100 米、10 米 和 1 米格网。</para>
		/// <para>MGRS 16—军事格网参考系，精度为 16 位。</para>
		/// <para>DD、DDM、DMS 和 UTM 也是有效关键字；可通过（在对话框中）直接输入或在脚本中传递值的方式来使用这些关键字。但是，带下划线和限定符的关键字包含更多有关字段值的信息。</para>
		/// </param>
		public ConvertCoordinateNotation(object InTable, object OutFeatureclass, object XField, object YField, object InputCoordinateFormat, object OutputCoordinateFormat)
		{
			this.InTable = InTable;
			this.OutFeatureclass = OutFeatureclass;
			this.XField = XField;
			this.YField = YField;
			this.InputCoordinateFormat = InputCoordinateFormat;
			this.OutputCoordinateFormat = OutputCoordinateFormat;
		}

		/// <summary>
		/// <para>Tool Display Name : 转换坐标记法</para>
		/// </summary>
		public override string DisplayName() => "转换坐标记法";

		/// <summary>
		/// <para>Tool Name : ConvertCoordinateNotation</para>
		/// </summary>
		public override string ToolName() => "ConvertCoordinateNotation";

		/// <summary>
		/// <para>Tool Excute Name : management.ConvertCoordinateNotation</para>
		/// </summary>
		public override string ExcuteName() => "management.ConvertCoordinateNotation";

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
		public override string[] ValidEnvironments() => new string[] { "XYTolerance", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, OutFeatureclass, XField, YField, InputCoordinateFormat, OutputCoordinateFormat, IdField, SpatialReference, InCoorSystem, ExcludeInvalidRecords };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>输入表或文本文件。 点要素同样有效。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出点要素类。 属性表将包括输入表的所有字段以及以输出格式表示转换值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>X Field (Longitude)</para>
		/// <para>输入表中包含经度值的字段。</para>
		/// <para>对于输入坐标格式参数的 DD 2、DD 数字、DDM 2 和 DMS 2 选项，该字段为经度字段。</para>
		/// <para>对于 DD 1、DDM 1 和 DMS 1 选项，此字段包含单个字符串中的纬度值和经度值。</para>
		/// <para>对于 Gars、Georef、Georef 16、UTM 带、UTM 波段、USNG、USNG 16、MGRS 和 MGRS 16 选项，此字段在单个文本字段中包含一个字母数字记法。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long", "Text")]
		public object XField { get; set; }

		/// <summary>
		/// <para>Y Field (Latitude)</para>
		/// <para>输入表中包含纬度值的字段。</para>
		/// <para>对于输入坐标格式参数的 DD 2、DD 数字、DDM 2 和 DMS 2 选项，该字段为纬度字段。</para>
		/// <para>选择其中一种单字符串格式时，此参数将处于非活动状态。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long", "Text")]
		public object YField { get; set; }

		/// <summary>
		/// <para>Input Coordinate Format</para>
		/// <para>指定输入字段的坐标格式。</para>
		/// <para>DD 1—经度值和纬度值位于同一个字段。两个值之间用空格、逗号或斜线进行分隔。</para>
		/// <para>DD 2—经度值和纬度值位于两个不同的字段中。这是默认设置。</para>
		/// <para>DDM 1—经度值和纬度值位于同一个字段。两个值之间用空格、逗号或斜线进行分隔。</para>
		/// <para>DDM 2— 经度值和纬度值位于两个不同的字段中。</para>
		/// <para>DMS 1—经度值和纬度值位于同一个字段。两个值之间用空格、逗号或斜线进行分隔。</para>
		/// <para>DMS 2—经度值和纬度值位于两个不同的字段中。</para>
		/// <para>Gars—全球区域参考系。根据纬度和经度，该参考系将世界划分成大量的格网单元。</para>
		/// <para>Georef—世界地理参考系。一个基于格网的参考系统，将世界划分成 15 度的地图方格，然后再细分成更小的地图方格。</para>
		/// <para>Georef 16—世界地理参考系，精度为 16 位。</para>
		/// <para>UTM 带—UTM 带编号后的字母 N 或 S 仅用于指定北半球或南半球。</para>
		/// <para>UTM 波段—UTM 带编号后的字母用于指定 20 个纬度带之一。N 或 S 不用于指定半球。</para>
		/// <para>USNG—美国国家格网。与 MGRS 几乎完全相同，但其基准面采用的是北美洲基准面 1983 (NAD83)。</para>
		/// <para>USNG 16—美国国家格网，精度高于 16 位。</para>
		/// <para>MGRS—军事格网参考系。按照 UTM 坐标，将世界划分成 6 度的经度带和 20 个纬度带，但 MGRS 将这些格网区域进一步划分成更小的 100,000 米格网。这些 100,000 米的格网再被细分成 10,000 米、1,000 米、100 米、10 米 和 1 米格网。</para>
		/// <para>MGRS 16—军事格网参考系，精度为 16 位。</para>
		/// <para>Shape—仅在选择点要素图层作为输入时可用。每个点的坐标都用于定义输出格式。</para>
		/// <para>DD、DDM、DMS 和 UTM 也是有效关键字；可通过（在对话框中）直接输入或在脚本中传递值的方式来使用这些关键字。但是，带下划线和限定符的关键字包含更多有关字段值的信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InputCoordinateFormat { get; set; } = "DD_2";

		/// <summary>
		/// <para>Output Coordinate Format</para>
		/// <para>指定输入记法转换后的坐标格式。</para>
		/// <para>DD 1—经度值和纬度值位于同一个字段。两个值之间用空格、逗号或斜线进行分隔。</para>
		/// <para>DD 2—经度值和纬度值位于两个不同的字段中。</para>
		/// <para>DD 数字—经度值和纬度值位于两个不同的“双精度”类型字段中。 “西”部和“南”部的值以减号表示。</para>
		/// <para>DDM 1—经度值和纬度值位于同一个字段。两个值之间用空格、逗号或斜线进行分隔。</para>
		/// <para>DDM 2— 经度值和纬度值位于两个不同的字段中。</para>
		/// <para>DMS 1—经度值和纬度值位于同一个字段。两个值之间用空格、逗号或斜线进行分隔。</para>
		/// <para>DMS 2—经度值和纬度值位于两个不同的字段中。</para>
		/// <para>Gars—全球区域参考系。根据纬度和经度，该参考系将世界划分成大量的格网单元。</para>
		/// <para>Georef—世界地理参考系。一个基于格网的参考系统，将世界划分成 15 度的地图方格，然后再细分成更小的地图方格。</para>
		/// <para>Georef 16—世界地理参考系，精度为 16 位。</para>
		/// <para>UTM 带—UTM 带编号后的字母 N 或 S 仅用于指定北半球或南半球。</para>
		/// <para>UTM 波段—UTM 带编号后的字母用于指定 20 个纬度带之一。N 或 S 不用于指定半球。</para>
		/// <para>USNG—美国国家格网。与 MGRS 几乎完全相同，但其基准面采用的是北美洲基准面 1983 (NAD83)。</para>
		/// <para>USNG 16—美国国家格网，精度高于 16 位。</para>
		/// <para>MGRS—军事格网参考系。按照 UTM 坐标，将世界划分成 6 度的经度带和 20 个纬度带，但 MGRS 将这些格网区域进一步划分成更小的 100,000 米格网。这些 100,000 米的格网再被细分成 10,000 米、1,000 米、100 米、10 米 和 1 米格网。</para>
		/// <para>MGRS 16—军事格网参考系，精度为 16 位。</para>
		/// <para>DD、DDM、DMS 和 UTM 也是有效关键字；可通过（在对话框中）直接输入或在脚本中传递值的方式来使用这些关键字。但是，带下划线和限定符的关键字包含更多有关字段值的信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputCoordinateFormat { get; set; } = "DD_2";

		/// <summary>
		/// <para>ID</para>
		/// <para>由于所有字段都被传输到输出表，因此不再使用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long", "Text")]
		public object IdField { get; set; }

		/// <summary>
		/// <para>Output Coordinate System</para>
		/// <para>输出要素类的空间参考。 默认值为 GCS_WGS_1984。</para>
		/// <para>此工具将输出投影到指定的空间参考中。 如果输入坐标系和输出坐标系具有不同的基准面，则将根据输入坐标系和输出坐标系以及数据范围使用默认转换。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>Input Coordinate System</para>
		/// <para>输入数据的空间参考。 如果无法从输入表中获取输入空间参考，则将使用默认值 GCS_WGS_1984。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object InCoorSystem { get; set; }

		/// <summary>
		/// <para>Exclude records with invalid notation</para>
		/// <para>指定是否排除具有无效注记的记录。</para>
		/// <para>未选中 - 系统将排除无效记录，且仅会将有效记录转换为输出中的点。 这是默认设置。</para>
		/// <para>选中 - 有效记录将被转换为输出中的点，无效记录将作为空几何包括在内。</para>
		/// <para><see cref="ExcludeInvalidRecordsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExcludeInvalidRecords { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConvertCoordinateNotation SetEnviroment(object XYTolerance = null , object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(XYTolerance: XYTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Exclude records with invalid notation</para>
		/// </summary>
		public enum ExcludeInvalidRecordsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EXCLUDE_INVALID")]
			EXCLUDE_INVALID,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("INCLUDE_INVALID")]
			INCLUDE_INVALID,

		}

#endregion
	}
}
