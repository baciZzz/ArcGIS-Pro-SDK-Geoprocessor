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
	/// <para>Package Layer</para>
	/// <para>打包图层</para>
	/// <para>对一个或多个图层以及所有引用的数据源进行打包以创建单个的压缩 .lpkx 文件。</para>
	/// </summary>
	public class PackageLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayer">
		/// <para>Input Layer</para>
		/// <para>要打包的图层。</para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>要创建的输出包文件 (.lpkx) 的位置和名称。</para>
		/// </param>
		public PackageLayer(object InLayer, object OutputFile)
		{
			this.InLayer = InLayer;
			this.OutputFile = OutputFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 打包图层</para>
		/// </summary>
		public override string DisplayName() => "打包图层";

		/// <summary>
		/// <para>Tool Name : PackageLayer</para>
		/// </summary>
		public override string ToolName() => "PackageLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.PackageLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.PackageLayer";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLayer, OutputFile, ConvertData, ConvertArcsdeData, Extent, ApplyExtentToArcsde, SchemaOnly, Version, AdditionalFiles, Summary, Tags, SelectRelatedRows };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>要打包的图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InLayer { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>要创建的输出包文件 (.lpkx) 的位置和名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("lpkx")]
		public object OutputFile { get; set; }

		/// <summary>
		/// <para>Convert data to file geodatabase</para>
		/// <para>指定输入图层是转换为文件地理数据库还是保留原始格式。</para>
		/// <para>选中 - 所有数据将转换为文件地理数据库。此选项不适用于企业级地理数据库数据源。要包括企业级地理数据库数据，请选中包括企业级地理数据库数据，而不是仅引用该数据参数。</para>
		/// <para>未选中 - 保留数据格式（如有可能）。这是默认设置。</para>
		/// <para><see cref="ConvertDataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ConvertData { get; set; } = "false";

		/// <summary>
		/// <para>Include Enterprise Geodatabase data instead of referencing the data</para>
		/// <para>指定是将输入企业级地理数据库图层转换为文件地理数据库，还是保留其原始格式。</para>
		/// <para>选中 - 所有企业级地理数据库数据源都将转换为文件地理数据库。这是默认设置。</para>
		/// <para>未选中 - 将保留所有企业级地理数据库数据源，并在生成的包中对其进行引用。</para>
		/// <para><see cref="ConvertArcsdeDataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ConvertArcsdeData { get; set; } = "true";

		/// <summary>
		/// <para>Extent</para>
		/// <para>指定用于选择或裁剪要素的范围。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>输入的并集 - 该范围将基于所有输入的最大范围。</para>
		/// <para>输入的交集 - 该范围将基于所有输入共用的最小区域。</para>
		/// <para>当前显示范围 - 该范围与可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Apply Extent only to enterprise geodatabase layers</para>
		/// <para>指定是将指定范围应用到所有图层，还是仅应用到企业级地理数据库图层。</para>
		/// <para>未选中 - 范围将应用到所有图层。这是默认设置。</para>
		/// <para>选中 - 范围将仅应用到企业级地理数据库图层。</para>
		/// <para><see cref="ApplyExtentToArcsdeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ApplyExtentToArcsde { get; set; } = "false";

		/// <summary>
		/// <para>Schema only</para>
		/// <para>指定是否仅合并或打包输入图层的方案。</para>
		/// <para>未选中 - 输入图层的所有要素和记录都将包括在合并文件夹或包中。这是默认设置。</para>
		/// <para>选中 - 仅合并或打包输入图层的方案。输出文件夹中将不合并或打包任何要素或记录。</para>
		/// <para><see cref="SchemaOnlyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SchemaOnly { get; set; } = "false";

		/// <summary>
		/// <para>Package version</para>
		/// <para>指定将在结果包中创建的地理数据库版本。指定版本可实现与之前版本的 ArcGIS 共享包，并可支持向后兼容。保存为之前版本的包可能会丢失仅适用于较新版本的属性。</para>
		/// <para>所有版本— 包中将包含与所有版本（ArcGIS Pro 1.2 和更高版本）均兼容的地理数据库和图层文件。</para>
		/// <para>当前版本— 包中将包含与当前版本兼容的地理数据库和图层文件。</para>
		/// <para>2.x—包中将包含与 2.0 和更高版本均兼容的地理数据库和图层文件。</para>
		/// <para>1.2—包中将包含与 1.2 和更高版本均兼容的地理数据库和图层文件。</para>
		/// <para><see cref="VersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Version { get; set; } = "ALL";

		/// <summary>
		/// <para>Additional Files</para>
		/// <para>将附加文件添加到包中。诸如 .doc、.txt、.pdf 等附加文件可用于提供有关打包内容和目的的详细信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object AdditionalFiles { get; set; }

		/// <summary>
		/// <para>Summary</para>
		/// <para>将摘要信息添加到包的属性中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Summary { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>将标签信息添加到包的属性中。可以添加多个标签，标签之间用逗号或分号进行分隔。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Tags { get; set; }

		/// <summary>
		/// <para>Keep only the rows which are related to features within the extent</para>
		/// <para>指定是否将指定的范围应用至相关数据源。</para>
		/// <para>未选中 - 相关的数据源将全部合并。这是默认设置。</para>
		/// <para>选中 - 仅合并指定范围内与记录对应的相关数据。</para>
		/// <para><see cref="SelectRelatedRowsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SelectRelatedRows { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PackageLayer SetEnviroment(object extent = null , object workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Convert data to file geodatabase</para>
		/// </summary>
		public enum ConvertDataEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CONVERT")]
			CONVERT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("PRESERVE")]
			PRESERVE,

		}

		/// <summary>
		/// <para>Include Enterprise Geodatabase data instead of referencing the data</para>
		/// </summary>
		public enum ConvertArcsdeDataEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CONVERT_ARCSDE")]
			CONVERT_ARCSDE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("PRESERVE_ARCSDE")]
			PRESERVE_ARCSDE,

		}

		/// <summary>
		/// <para>Apply Extent only to enterprise geodatabase layers</para>
		/// </summary>
		public enum ApplyExtentToArcsdeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ARCSDE_ONLY")]
			ARCSDE_ONLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL")]
			ALL,

		}

		/// <summary>
		/// <para>Schema only</para>
		/// </summary>
		public enum SchemaOnlyEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SCHEMA_ONLY")]
			SCHEMA_ONLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL")]
			ALL,

		}

		/// <summary>
		/// <para>Package version</para>
		/// </summary>
		public enum VersionEnum 
		{
			/// <summary>
			/// <para>所有版本— 包中将包含与所有版本（ArcGIS Pro 1.2 和更高版本）均兼容的地理数据库和图层文件。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有版本")]
			All_versions,

			/// <summary>
			/// <para>当前版本— 包中将包含与当前版本兼容的地理数据库和图层文件。</para>
			/// </summary>
			[GPValue("CURRENT")]
			[Description("当前版本")]
			Current_version,

			/// <summary>
			/// <para>1.2—包中将包含与 1.2 和更高版本均兼容的地理数据库和图层文件。</para>
			/// </summary>
			[GPValue("1.2")]
			[Description("1.2")]
			_12,

			/// <summary>
			/// <para>2.x—包中将包含与 2.0 和更高版本均兼容的地理数据库和图层文件。</para>
			/// </summary>
			[GPValue("2.x")]
			[Description("2.x")]
			_2x,

		}

		/// <summary>
		/// <para>Keep only the rows which are related to features within the extent</para>
		/// </summary>
		public enum SelectRelatedRowsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_ONLY_RELATED_ROWS")]
			KEEP_ONLY_RELATED_ROWS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_ALL_RELATED_ROWS")]
			KEEP_ALL_RELATED_ROWS,

		}

#endregion
	}
}
