using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IndoorsTools
{
	/// <summary>
	/// <para>Import Floorplans To Indoors Geodatabase</para>
	/// <para>将楼层平面图导入 Indoors 地理数据库</para>
	/// <para>将楼层平面图从 CAD 文件导入到符合 ArcGIS Indoors 信息模型的室内数据集中。 可使用该工具的输出创建楼层感知型场景，以用于楼层感知型应用程序，以及生成用于路由的室内网络。</para>
	/// </summary>
	public class ImportFloorplansToIndoorsGDB : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeodatabase">
		/// <para>Input Geodatabase</para>
		/// <para>将载入楼层平面图数据的地理数据库（文件或企业级）。</para>
		/// </param>
		/// <param name="InExcelTemplate">
		/// <para>Input Excel Template File</para>
		/// <para>包含输入和配置参数的 Excel 电子表格（.xls 或 .xlsx 文件）。</para>
		/// </param>
		/// <param name="UniqueidDelimiter">
		/// <para>Unique ID Delimiter</para>
		/// <para>指定将按 Indoors 模型等级分隔键值的分隔符。</para>
		/// <para>句点—该 ID 将包含以句点分隔的键值。 这是默认设置。</para>
		/// <para>连字符—该 ID 将包含以连字符分隔的键值。</para>
		/// <para>下划线—该 ID 将包含以下划线分隔的键值。</para>
		/// <para><see cref="UniqueidDelimiterEnum"/></para>
		/// </param>
		public ImportFloorplansToIndoorsGDB(object InGeodatabase, object InExcelTemplate, object UniqueidDelimiter)
		{
			this.InGeodatabase = InGeodatabase;
			this.InExcelTemplate = InExcelTemplate;
			this.UniqueidDelimiter = UniqueidDelimiter;
		}

		/// <summary>
		/// <para>Tool Display Name : 将楼层平面图导入 Indoors 地理数据库</para>
		/// </summary>
		public override string DisplayName() => "将楼层平面图导入 Indoors 地理数据库";

		/// <summary>
		/// <para>Tool Name : ImportFloorplansToIndoorsGDB</para>
		/// </summary>
		public override string ToolName() => "ImportFloorplansToIndoorsGDB";

		/// <summary>
		/// <para>Tool Excute Name : indoors.ImportFloorplansToIndoorsGDB</para>
		/// </summary>
		public override string ExcuteName() => "indoors.ImportFloorplansToIndoorsGDB";

		/// <summary>
		/// <para>Toolbox Display Name : Indoors Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Indoors Tools";

		/// <summary>
		/// <para>Toolbox Alise : indoors</para>
		/// </summary>
		public override string ToolboxAlise() => "indoors";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGeodatabase, InExcelTemplate, UniqueidDelimiter, SliverThreshold, DoorCloseBuffer, UpdatedGdb, AreaUnitOfMeasure };

		/// <summary>
		/// <para>Input Geodatabase</para>
		/// <para>将载入楼层平面图数据的地理数据库（文件或企业级）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InGeodatabase { get; set; }

		/// <summary>
		/// <para>Input Excel Template File</para>
		/// <para>包含输入和配置参数的 Excel 电子表格（.xls 或 .xlsx 文件）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xls", "xlsx")]
		public object InExcelTemplate { get; set; }

		/// <summary>
		/// <para>Unique ID Delimiter</para>
		/// <para>指定将按 Indoors 模型等级分隔键值的分隔符。</para>
		/// <para>句点—该 ID 将包含以句点分隔的键值。 这是默认设置。</para>
		/// <para>连字符—该 ID 将包含以连字符分隔的键值。</para>
		/// <para>下划线—该 ID 将包含以下划线分隔的键值。</para>
		/// <para><see cref="UniqueidDelimiterEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object UniqueidDelimiter { get; set; } = "PERIOD";

		/// <summary>
		/// <para>Sliver Threshold</para>
		/// <para>定义狭长面的周长与面积之比。 可在导入单位面时使用，以提高导入数据的质量。 确定为狭长面的单位面将置于位于 ArcGIS Pro 工程的临时文件夹中的检查地理数据库中。 默认值为 2。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object SliverThreshold { get; set; } = "2";

		/// <summary>
		/// <para>Door Close Buffer</para>
		/// <para>该工具以门为原点搜索的距离（以英寸为单位），以查找并捕捉到最近的墙壁。 当在输入 Excel 模板文件中将 CLOSE_DOORS 列设置为 Y 时，将使用此参数。 默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPCodedValueDomain()]
		public object DoorCloseBuffer { get; set; } = "0";

		/// <summary>
		/// <para>Updated Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object UpdatedGdb { get; set; }

		/// <summary>
		/// <para>Area Unit of Measure</para>
		/// <para>在导入楼层平面图时，指定将用于计算区域字段的面积的测量单位。</para>
		/// <para>平方英尺—将以平方英尺为单位来定义面积。 这是默认设置。</para>
		/// <para>平方米—将以平方米为单位来定义面积。</para>
		/// <para><see cref="AreaUnitOfMeasureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AreaUnitOfMeasure { get; set; } = "SQUARE_FEET";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportFloorplansToIndoorsGDB SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Unique ID Delimiter</para>
		/// </summary>
		public enum UniqueidDelimiterEnum 
		{
			/// <summary>
			/// <para>句点—该 ID 将包含以句点分隔的键值。 这是默认设置。</para>
			/// </summary>
			[GPValue("PERIOD")]
			[Description("句点")]
			Period,

			/// <summary>
			/// <para>连字符—该 ID 将包含以连字符分隔的键值。</para>
			/// </summary>
			[GPValue("HYPHEN")]
			[Description("连字符")]
			Hyphen,

			/// <summary>
			/// <para>下划线—该 ID 将包含以下划线分隔的键值。</para>
			/// </summary>
			[GPValue("UNDERSCORE")]
			[Description("下划线")]
			Underscore,

		}

		/// <summary>
		/// <para>Area Unit of Measure</para>
		/// </summary>
		public enum AreaUnitOfMeasureEnum 
		{
			/// <summary>
			/// <para>平方英尺—将以平方英尺为单位来定义面积。 这是默认设置。</para>
			/// </summary>
			[GPValue("SQUARE_FEET")]
			[Description("平方英尺")]
			Square_Feet,

			/// <summary>
			/// <para>平方米—将以平方米为单位来定义面积。</para>
			/// </summary>
			[GPValue("SQUARE_METERS")]
			[Description("平方米")]
			Square_Meters,

		}

#endregion
	}
}
