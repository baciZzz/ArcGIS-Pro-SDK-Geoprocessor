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
	/// <para>Remove 3D Formats From Multipatch</para>
	/// <para>从多面体中移除 3D 格式</para>
	/// <para>移除 3D 对象要素图层引用的 3D 格式。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class Remove3DFormats : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>已转换为 3D 对象要素类的多面体要素类。</para>
		/// </param>
		public Remove3DFormats(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 从多面体中移除 3D 格式</para>
		/// </summary>
		public override string DisplayName() => "从多面体中移除 3D 格式";

		/// <summary>
		/// <para>Tool Name : Remove3DFormats</para>
		/// </summary>
		public override string ToolName() => "Remove3DFormats";

		/// <summary>
		/// <para>Tool Excute Name : management.Remove3DFormats</para>
		/// </summary>
		public override string ExcuteName() => "management.Remove3DFormats";

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
		public override object[] Parameters() => new object[] { InFeatures, MultipatchMaterials, Formats, UpdatedFeatures };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>已转换为 3D 对象要素类的多面体要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Use multipatch materials</para>
		/// <para>指定是使用关联 3D 模型中的材料信息还是随多面体一起存储的纹理和颜色信息来可视化多面体几何。</para>
		/// <para>选中 - 将使用与 3D 模型关联的纹理、颜色、效果和材料来可视化多面体几何。这是默认设置。</para>
		/// <para>未选中 - 将使用为多面体定义的纹理和颜色可视化多面体几何。</para>
		/// <para><see cref="MultipatchMaterialsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MultipatchMaterials { get; set; } = "true";

		/// <summary>
		/// <para>3D Formats to Remove</para>
		/// <para>指定将移除的、3D 对象要素图层引用的 3D 模型格式。只能指定已链接到输入要素的格式。</para>
		/// <para>Collada (.dae)—将移除 COLLADA 格式。</para>
		/// <para>Autodesk (.fbx)—将移除 Autodesk FilmBox 格式。</para>
		/// <para>Khronos Group glTF json (.gltf)—将移除 JSON 图形库传输格式。</para>
		/// <para>Khronos Group glTF 二进制 (.glb)—将移除二进制图形库传输格式。</para>
		/// <para>Wavefront (.obj)—将移除 Wavefront 格式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Formats { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object UpdatedFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Remove3DFormats SetEnviroment(object workspace = null )
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
