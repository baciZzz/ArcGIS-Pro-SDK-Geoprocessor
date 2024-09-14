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
	/// <para>Add 3D Formats To Multipatch</para>
	/// <para>将 3D 格式添加到多面体</para>
	/// <para>通过链接要素类与一种或多种 3D 模型格式，将多面体转换为 3D 对象要素图层。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class Add3DFormats : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>将转换为 3D 对象要素图层的输入地理数据库多面体要素。</para>
		/// </param>
		public Add3DFormats(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 将 3D 格式添加到多面体</para>
		/// </summary>
		public override string DisplayName() => "将 3D 格式添加到多面体";

		/// <summary>
		/// <para>Tool Name : Add3DFormats</para>
		/// </summary>
		public override string ToolName() => "Add3DFormats";

		/// <summary>
		/// <para>Tool Excute Name : management.Add3DFormats</para>
		/// </summary>
		public override string ExcuteName() => "management.Add3DFormats";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, MultipatchMaterials!, Formats!, UpdatedFeatures! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将转换为 3D 对象要素图层的输入地理数据库多面体要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Use multipatch materials</para>
		/// <para>指定是使用关联 3D 模型中的材料信息还是随多面体一起存储的纹理和颜色信息来可视化多面体几何。</para>
		/// <para>选中 - 将使用与 3D 模型关联的纹理、颜色、效果和材料来可视化多面体几何。 这是默认设置。</para>
		/// <para>未选中 - 将使用为多面体定义的纹理和颜色可视化多面体几何。</para>
		/// <para><see cref="MultipatchMaterialsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MultipatchMaterials { get; set; } = "true";

		/// <summary>
		/// <para>3D Formats to Add</para>
		/// <para>指定将与多面体要素关联的 3D 格式。 将为每个选定格式复制所有输入要素。 可用选项取决于计算机上安装的编解码器。</para>
		/// <para>Collada (.dae)—将添加 COLLADA 格式。</para>
		/// <para>Autodesk (.fbx)—将添加 Autodesk FilmBox 格式。</para>
		/// <para>Khronos Group glTF json (.gltf)—将添加 JSON 图形库传输格式。</para>
		/// <para>Khronos Group glTF 二进制 (.glb)—将添加二进制图形库传输格式。</para>
		/// <para>Wavefront (.obj)—将添加 Wavefront 格式。</para>
		/// <para>Autodesk Drawing (.dwg)—将添加 DWG 格式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Formats { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? UpdatedFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Add3DFormats SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Use multipatch materials</para>
		/// </summary>
		public enum MultipatchMaterialsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MULTIPATCH_WITH_MATERIALS")]
			MULTIPATCH_WITH_MATERIALS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("MULTIPATCH_WITHOUT_MATERIALS")]
			MULTIPATCH_WITHOUT_MATERIALS,

		}

#endregion
	}
}
