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
	/// <para>Add Spatial Index</para>
	/// <para>添加空间索引</para>
	/// <para>将空间索引添加到 shapefile、文件地理数据库、移动地理数据库或企业级地理数据库要素类中。使用此工具可将空间索引添加到尚无空间索引的 shapefile 或要素类或者重新创建现有空间索引。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddSpatialIndex : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要添加或重构空间索引的企业级地理数据库要素类、文件地理数据库要素类、移动地理数据库要素类或 shapefile。</para>
		/// </param>
		public AddSpatialIndex(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加空间索引</para>
		/// </summary>
		public override string DisplayName() => "添加空间索引";

		/// <summary>
		/// <para>Tool Name : AddSpatialIndex</para>
		/// </summary>
		public override string ToolName() => "AddSpatialIndex";

		/// <summary>
		/// <para>Tool Excute Name : management.AddSpatialIndex</para>
		/// </summary>
		public override string ExcuteName() => "management.AddSpatialIndex";

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
		public override object[] Parameters() => new object[] { InFeatures, SpatialGrid1!, SpatialGrid2!, SpatialGrid3!, OutFeatureClass! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要添加或重构空间索引的企业级地理数据库要素类、文件地理数据库要素类、移动地理数据库要素类或 shapefile。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Spatial Grid 1</para>
		/// <para>已在 ArcGIS Pro 中弃用此参数。将忽略您输入的任何值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SpatialGrid1 { get; set; } = "0";

		/// <summary>
		/// <para>Spatial Grid 2</para>
		/// <para>已在 ArcGIS Pro 中弃用此参数。将忽略您输入的任何值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SpatialGrid2 { get; set; } = "0";

		/// <summary>
		/// <para>Spatial Grid 3</para>
		/// <para>已在 ArcGIS Pro 中弃用此参数。将忽略您输入的任何值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SpatialGrid3 { get; set; } = "0";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddSpatialIndex SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
