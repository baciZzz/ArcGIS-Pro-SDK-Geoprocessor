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
	/// <para>Multipatch To Collada</para>
	/// <para>多面体转 Collada</para>
	/// <para>将一个或多个多面体要素转换为 COLLADA (.dae) 文件及其引用的纹理图像文件的集合并将此集合存储在输出文件夹中。输入可以是图层或要素类。</para>
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
		/// <para>Output Collada Folder</para>
		/// <para>放置输出 COLLADA 文件和纹理图像文件的目标文件夹。</para>
		/// </param>
		public MultipatchToCollada(object InFeatures, object OutputFolder)
		{
			this.InFeatures = InFeatures;
			this.OutputFolder = OutputFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : 多面体转 Collada</para>
		/// </summary>
		public override string DisplayName() => "多面体转 Collada";

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
		public override object[] Parameters() => new object[] { InFeatures, OutputFolder, PrependSource, FieldName };

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
		/// <para>Output Collada Folder</para>
		/// <para>放置输出 COLLADA 文件和纹理图像文件的目标文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Prepend Source Name</para>
		/// <para>将源要素图层的名称添加为输出 COLLADA 文件的文件名的前缀。</para>
		/// <para>选中 - 添加文件名前缀。</para>
		/// <para>不选中 - 不添加文件名前缀。这是默认设置。</para>
		/// <para><see cref="PrependSourceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object PrependSource { get; set; } = "false";

		/// <summary>
		/// <para>Use Field Name</para>
		/// <para>用作每个导出的要素的输出 COLLADA 文件名的要素属性。如果未指定字段，则使用要素的“对象 ID”。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("OID", "Text", "Short", "Long")]
		public object FieldName { get; set; }

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

#endregion
	}
}
