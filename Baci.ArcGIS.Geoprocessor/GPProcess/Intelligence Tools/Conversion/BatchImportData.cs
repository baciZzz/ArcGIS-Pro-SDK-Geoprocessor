using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>Batch Import Data</para>
	/// <para>批量导入数据</para>
	/// <para>将 KML、KMZ、shapefile、Excel 工作表、表格文本文件、GeoJSON 和 GPX 文件导入存储在单个地理数据库中的要素类。</para>
	/// </summary>
	public class BatchImportData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input Data</para>
		/// <para>包含数据文件或要转换为地理数据库要素类的数据文件的目录。</para>
		/// </param>
		/// <param name="TargetGdb">
		/// <para>Target Geodatabase</para>
		/// <para>将存储输出要素类的目标地理数据库。</para>
		/// </param>
		public BatchImportData(object InData, object TargetGdb)
		{
			this.InData = InData;
			this.TargetGdb = TargetGdb;
		}

		/// <summary>
		/// <para>Tool Display Name : 批量导入数据</para>
		/// </summary>
		public override string DisplayName() => "批量导入数据";

		/// <summary>
		/// <para>Tool Name : BatchImportData</para>
		/// </summary>
		public override string ToolName() => "BatchImportData";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.BatchImportData</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.BatchImportData";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise() => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InData, TargetGdb, Filter!, IncludeSubFolders!, OutGeodatabase!, IncludeGroundoverlay! };

		/// <summary>
		/// <para>Input Data</para>
		/// <para>包含数据文件或要转换为地理数据库要素类的数据文件的目录。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Target Geodatabase</para>
		/// <para>将存储输出要素类的目标地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object TargetGdb { get; set; }

		/// <summary>
		/// <para>Filter</para>
		/// <para>应用过滤器以限制导入文件夹的文件。 过滤器的以下通配符适用于输入数据的完整路径：可以通过使用竖线或管道分隔符 (|) 将每个模式分隔开来，从而将多个模式添加到过滤器。 模式比较不区分大小写，因此如果使用 *airport.shp、*AIRPORT.SHP 或 *Airport.shp 模式将导入相同的 shapefile。</para>
		/// <para>* - 匹配任何字符</para>
		/// <para>? - 匹配单个字符</para>
		/// <para>[range] - 匹配范围内的单个字符</para>
		/// <para>[!range] - 匹配不再范围内的任意字符</para>
		/// <para>以下是过滤器示例：</para>
		/// <para>要导入所有 shapefile，请使用 *.shp。</para>
		/// <para>要导入所有 shapefile 和所有 .kml 文件，请使用 *.shp|*.kml。</para>
		/// <para>要导入文件路径或文件名中包含 airport 的所有文件，请使用 *airport*。</para>
		/// <para>要导入文件路径或文件名中包含 airport 的所有 .geojson 文件，请使用 *airport*.geojson。</para>
		/// <para>要导入名称中包含 airport 且其后追加有任意两个字符的所有 .kmz 文件，请使用 *airport??.kmz.</para>
		/// <para>要导入文件路径或文件名中包含 1990 到 1997 的所有文件，请使用 *199[0-7]*。</para>
		/// <para>要导入文件路径中包含确切文件名 airfacilities 的所有 shapefile，请使用 *\airfacilities\*.shp。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Input Data Options")]
		public object? Filter { get; set; }

		/// <summary>
		/// <para>Include Sub Folders</para>
		/// <para>指定是否递归搜索子文件夹。</para>
		/// <para>选中 - 浏览所有子文件夹。 这是默认设置。</para>
		/// <para>取消选中 - 仅浏览顶级文件夹。</para>
		/// <para><see cref="IncludeSubFoldersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Input Data Options")]
		public object? IncludeSubFolders { get; set; } = "true";

		/// <summary>
		/// <para>Updated Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutGeodatabase { get; set; }

		/// <summary>
		/// <para>Include Ground Overlay</para>
		/// <para>指定是否在输出中包含 KML 或 KMZ 地面叠加层（栅格、航空照片等）。</para>
		/// <para>KMZ 指向提供栅格影像的服务时，请谨慎使用。 该工具将尝试按所有可用比例转换栅格影像。 此过程也许会较漫长且可能超出服务能力范围。</para>
		/// <para>选中 - 将在输出中包含地面叠加层。 这是默认设置。</para>
		/// <para>未选中 - 地面叠加层不包括在输出中。</para>
		/// <para><see cref="IncludeGroundoverlayEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("KML/KMZ Options")]
		public object? IncludeGroundoverlay { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>Include Sub Folders</para>
		/// </summary>
		public enum IncludeSubFoldersEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SUBFOLDERS")]
			SUBFOLDERS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SUBFOLDERS")]
			NO_SUBFOLDERS,

		}

		/// <summary>
		/// <para>Include Ground Overlay</para>
		/// </summary>
		public enum IncludeGroundoverlayEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("GROUNDOVERLAY")]
			GROUNDOVERLAY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_GROUNDOVERLAY")]
			NO_GROUNDOVERLAY,

		}

#endregion
	}
}
