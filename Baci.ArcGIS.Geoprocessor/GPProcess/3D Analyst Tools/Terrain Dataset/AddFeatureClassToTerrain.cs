using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Add Feature Class To Terrain</para>
	/// <para>向 Terrain 添加要素类</para>
	/// <para>向 terrain 数据集中添加一个或多个要素类。</para>
	/// </summary>
	public class AddFeatureClassToTerrain : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// <para>要向其中添加要素类的 terrain。terrain 数据集必须已创建一个或多个金字塔等级。</para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input Feature Class</para>
		/// <para>识别要向 terrain 中添加的要素。每个要素必须与 terrain 位于同一要素数据集中，并且必须已通过下列属性定义其角色：</para>
		/// <para>Input Features—要添加至 terrain 的要素类的名称。</para>
		/// <para>Height Field—包含要素高度信息的字段。可指定任意数值字段，启用 z 值的要素也可以选择几何字段。如果选择 &lt;无&gt; 选项，则将依据表面进行 z 值插值。</para>
		/// <para>Type—定义要素如何构成 terrain 的表面要素类型。离散多点表示提供 z 测量值的要素；隔断线表示具有已知 z 测量值的线状要素；以及多个面类型。基于隔断线和面的要素类型还使用限定词硬和软来定义导出至栅格时要素边缘周边的插值行为。软要素表示坡度平缓变化，而硬要素表示明显中断。</para>
		/// <para>Group—定义每个构成要素的组。未指定以不同细节层次表示相同地理要素的隔断线和面表面要素将在某些比例范围进行显示。以不同细节层次表示相同地理要素的数据则可通过分配相同数值的方式进行分组。例如，为同一组分配两个边界要素，其中一个为高细节层次，而另一个为低细节层次，这样可以确保在其相关联的显示比例范围中不出现叠置。</para>
		/// <para>Min/Max Resolution—定义金字塔分辨率范围，要素将在 terrain 中强制以该范围内的分辨率显示。离散多点必须使用值的最小和最大范围。</para>
		/// <para>Overview—指示是否将要素强制为 terrain 数据集的最粗略表达。要最大限度地提高显示性能，请确保概貌中表示的要素类包含简化几何。仅对除离散多点之外的要素类型有效。</para>
		/// <para>Embed—将该选项设置为 TRUE 表示会将源要素复制到将由 terrain 引用且仅对 terrain 可用的隐藏要素类。无法直接查看嵌入式要素，因为嵌入式要素只能通过 terrain 工具访问。仅对多点要素有效。</para>
		/// <para>Embed Name—嵌入的要素类的名称。仅当要嵌入要素时适用。</para>
		/// <para>Embed Fields—指定将保留在嵌入式要素类中的 BLOB 字段属性。这些属性可用于符号化 terrain。可通过 LAS 转多点工具将 LAS 属性存储在多点要素的 BLOB 字段中。</para>
		/// <para>Anchor—指定是否将点要素类在所有 terrain 金字塔等级内锚定。锚点将不会被过滤或稀疏化掉，以确保其存在于 terrain 表面中。此选项只适用于单点要素类。</para>
		/// </param>
		public AddFeatureClassToTerrain(object InTerrain, object InFeatures)
		{
			this.InTerrain = InTerrain;
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 向 Terrain 添加要素类</para>
		/// </summary>
		public override string DisplayName() => "向 Terrain 添加要素类";

		/// <summary>
		/// <para>Tool Name : AddFeatureClassToTerrain</para>
		/// </summary>
		public override string ToolName() => "AddFeatureClassToTerrain";

		/// <summary>
		/// <para>Tool Excute Name : 3d.AddFeatureClassToTerrain</para>
		/// </summary>
		public override string ExcuteName() => "3d.AddFeatureClassToTerrain";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTerrain, InFeatures, DerivedOutTerrain! };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>要向其中添加要素类的 terrain。terrain 数据集必须已创建一个或多个金字塔等级。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>识别要向 terrain 中添加的要素。每个要素必须与 terrain 位于同一要素数据集中，并且必须已通过下列属性定义其角色：</para>
		/// <para>Input Features—要添加至 terrain 的要素类的名称。</para>
		/// <para>Height Field—包含要素高度信息的字段。可指定任意数值字段，启用 z 值的要素也可以选择几何字段。如果选择 &lt;无&gt; 选项，则将依据表面进行 z 值插值。</para>
		/// <para>Type—定义要素如何构成 terrain 的表面要素类型。离散多点表示提供 z 测量值的要素；隔断线表示具有已知 z 测量值的线状要素；以及多个面类型。基于隔断线和面的要素类型还使用限定词硬和软来定义导出至栅格时要素边缘周边的插值行为。软要素表示坡度平缓变化，而硬要素表示明显中断。</para>
		/// <para>Group—定义每个构成要素的组。未指定以不同细节层次表示相同地理要素的隔断线和面表面要素将在某些比例范围进行显示。以不同细节层次表示相同地理要素的数据则可通过分配相同数值的方式进行分组。例如，为同一组分配两个边界要素，其中一个为高细节层次，而另一个为低细节层次，这样可以确保在其相关联的显示比例范围中不出现叠置。</para>
		/// <para>Min/Max Resolution—定义金字塔分辨率范围，要素将在 terrain 中强制以该范围内的分辨率显示。离散多点必须使用值的最小和最大范围。</para>
		/// <para>Overview—指示是否将要素强制为 terrain 数据集的最粗略表达。要最大限度地提高显示性能，请确保概貌中表示的要素类包含简化几何。仅对除离散多点之外的要素类型有效。</para>
		/// <para>Embed—将该选项设置为 TRUE 表示会将源要素复制到将由 terrain 引用且仅对 terrain 可用的隐藏要素类。无法直接查看嵌入式要素，因为嵌入式要素只能通过 terrain 工具访问。仅对多点要素有效。</para>
		/// <para>Embed Name—嵌入的要素类的名称。仅当要嵌入要素时适用。</para>
		/// <para>Embed Fields—指定将保留在嵌入式要素类中的 BLOB 字段属性。这些属性可用于符号化 terrain。可通过 LAS 转多点工具将 LAS 属性存储在多点要素的 BLOB 字段中。</para>
		/// <para>Anchor—指定是否将点要素类在所有 terrain 金字塔等级内锚定。锚点将不会被过滤或稀疏化掉，以确保其存在于 terrain 表面中。此选项只适用于单点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Updated Input Terrain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTerrainLayer()]
		public object? DerivedOutTerrain { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddFeatureClassToTerrain SetEnviroment(int? autoCommit = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

	}
}
