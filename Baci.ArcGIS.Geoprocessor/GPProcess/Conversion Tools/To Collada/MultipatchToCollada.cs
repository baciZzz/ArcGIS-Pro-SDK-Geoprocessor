using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>Multipatch To COLLADA</para>
	/// <para>多面体转 COLLADA</para>
	/// <para>用于将一个或多个多面体要素转换为输出文件夹中的 COLLADA 文件 (.dae) 和引用纹理影像文件的集合。</para>
	/// </summary>
	public class MultipatchToCollada : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Multipatch Features</para>
		/// <para>要导出的多面体要素。</para>
		/// </param>
		/// <param name="OutputFolder">
		/// <para>Output COLLADA Folder</para>
		/// <para>将放置输出 COLLADA 文件和纹理图像文件的目标文件夹。</para>
		/// </param>
		public MultipatchToCollada(object InFeatures, object OutputFolder)
		{
			this.InFeatures = InFeatures;
			this.OutputFolder = OutputFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : 多面体转 COLLADA</para>
		/// </summary>
		public override string DisplayName() => "多面体转 COLLADA";

		/// <summary>
		/// <para>Tool Name : MultipatchToCollada</para>
		/// </summary>
		public override string ToolName() => "MultipatchToCollada";

		/// <summary>
		/// <para>Tool Excute Name : conversion.MultipatchToCollada</para>
		/// </summary>
		public override string ExcuteName() => "conversion.MultipatchToCollada";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutputFolder, PrependSource!, FieldName!, ColladaVersion! };

		/// <summary>
		/// <para>Input Multipatch Features</para>
		/// <para>要导出的多面体要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output COLLADA Folder</para>
		/// <para>将放置输出 COLLADA 文件和纹理图像文件的目标文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Prepend Source Name</para>
		/// <para>指定是否在输出 COLLADA 文件的名称前面附加源要素图层的名称。</para>
		/// <para>选中 - 将在文件名前面附加源要素图层的名称。</para>
		/// <para>未选中 - 不会在文件名前面附加源要素图层的名称。 这是默认设置。</para>
		/// <para><see cref="PrependSourceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? PrependSource { get; set; } = "false";

		/// <summary>
		/// <para>Use Field Name</para>
		/// <para>将用作每个导出要素的输出 COLLADA 文件名称的要素属性。 如果未指定字段，将使用要素的对象 ID。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("OID", "Text", "Short", "Long")]
		public object? FieldName { get; set; }

		/// <summary>
		/// <para>COLLADA Version</para>
		/// <para>指定导出文件的目标 COLLADA 版本。</para>
		/// <para>1.5—文件将导出到 COLLADA 版本 1.5。 版本 1.5 支持添加地理配准信息和增强渲染功能。 这是默认设置。</para>
		/// <para>1.4—文件将导出到 COLLADA 版本 1.4。 版本 1.4 是可在许多设计相关的应用程序平台中使用的广泛支持的标准版本。 如果 COLLADA 文件将用于不支持版本 1.5 的系统，请选择此版本。</para>
		/// <para><see cref="ColladaVersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ColladaVersion { get; set; } = "1.5";

		#region InnerClass

		/// <summary>
		/// <para>Prepend Source Name</para>
		/// </summary>
		public enum PrependSourceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PREPEND_SOURCE_NAME")]
			PREPEND_SOURCE_NAME,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("PREPEND_NONE")]
			PREPEND_NONE,

		}

		/// <summary>
		/// <para>COLLADA Version</para>
		/// </summary>
		public enum ColladaVersionEnum 
		{
			/// <summary>
			/// <para>1.4—文件将导出到 COLLADA 版本 1.4。 版本 1.4 是可在许多设计相关的应用程序平台中使用的广泛支持的标准版本。 如果 COLLADA 文件将用于不支持版本 1.5 的系统，请选择此版本。</para>
			/// </summary>
			[GPValue("1.4")]
			[Description("1.4")]
			_14,

			/// <summary>
			/// <para>1.5—文件将导出到 COLLADA 版本 1.5。 版本 1.5 支持添加地理配准信息和增强渲染功能。 这是默认设置。</para>
			/// </summary>
			[GPValue("1.5")]
			[Description("1.5")]
			_15,

		}

#endregion
	}
}
