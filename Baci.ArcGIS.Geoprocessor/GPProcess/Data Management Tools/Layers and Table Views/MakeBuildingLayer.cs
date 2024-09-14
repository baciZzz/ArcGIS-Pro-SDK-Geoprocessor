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
	/// <para>Make Building Layer</para>
	/// <para>创建建筑图层</para>
	/// <para>用于通过数据集（BIM 文件工作空间或地理数据库数据集，例如 BIM 文件转地理数据库工具的输出）创建复合建筑物图层。</para>
	/// </summary>
	public class MakeBuildingLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureDataset">
		/// <para>Input Feature Dataset</para>
		/// <para>创建新建筑物要素图层时将基于的输入数据集。 建筑图层将结构和符号系统分组在一起。</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output Layer</para>
		/// <para>将创建的要素图层的名称。 图层可用作任何接受要素图层作为输入的地理处理工具的输入。</para>
		/// </param>
		public MakeBuildingLayer(object InFeatureDataset, object OutLayer)
		{
			this.InFeatureDataset = InFeatureDataset;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建建筑图层</para>
		/// </summary>
		public override string DisplayName() => "创建建筑图层";

		/// <summary>
		/// <para>Tool Name : MakeBuildingLayer</para>
		/// </summary>
		public override string ToolName() => "MakeBuildingLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeBuildingLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.MakeBuildingLayer";

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
		public override object[] Parameters() => new object[] { InFeatureDataset, OutLayer };

		/// <summary>
		/// <para>Input Feature Dataset</para>
		/// <para>创建新建筑物要素图层时将基于的输入数据集。 建筑图层将结构和符号系统分组在一起。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object InFeatureDataset { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// <para>将创建的要素图层的名称。 图层可用作任何接受要素图层作为输入的地理处理工具的输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBuildingLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeBuildingLayer SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
