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
	/// <para>Make Feature Layer</para>
	/// <para>创建要素图层</para>
	/// <para>根据输入要素类或图层文件创建要素图层。该工具创建的图层是临时图层，如果不将此图层保存到磁盘或保存地图文档，该图层在会话结束后将不会继续存在。</para>
	/// </summary>
	public class MakeFeatureLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>用于创建新图层的输入要素类或图层。复杂要素类（如注记和尺寸）不是此工具的有效输入。</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output Layer</para>
		/// <para>要创建的要素图层的名称。新创建的图层可用作任何可接受要素图层作为输入的地理处理工具的输入。</para>
		/// </param>
		public MakeFeatureLayer(object InFeatures, object OutLayer)
		{
			this.InFeatures = InFeatures;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建要素图层</para>
		/// </summary>
		public override string DisplayName() => "创建要素图层";

		/// <summary>
		/// <para>Tool Name : MakeFeatureLayer</para>
		/// </summary>
		public override string ToolName() => "MakeFeatureLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeFeatureLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.MakeFeatureLayer";

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
		public override object[] Parameters() => new object[] { InFeatures, OutLayer, WhereClause, Workspace, FieldInfo };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>用于创建新图层的输入要素类或图层。复杂要素类（如注记和尺寸）不是此工具的有效输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// <para>要创建的要素图层的名称。新创建的图层可用作任何可接受要素图层作为输入的地理处理工具的输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>用于选择要素子集的 SQL 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Workspace or Feature Dataset</para>
		/// <para>用于验证字段名的输入工作空间。如果输入是地理数据库表，而输出工作空间是 dBASE 表，则字段名可能会被截断，这是由于 dBASE 字段名最多只能具有十个字符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object Workspace { get; set; }

		/// <summary>
		/// <para>Field Info</para>
		/// <para>可用于查看和隐藏输出图层中的一部分字段。可以指定分割策略。有关详细信息，请参阅用法。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldInfo()]
		public object FieldInfo { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeFeatureLayer SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
