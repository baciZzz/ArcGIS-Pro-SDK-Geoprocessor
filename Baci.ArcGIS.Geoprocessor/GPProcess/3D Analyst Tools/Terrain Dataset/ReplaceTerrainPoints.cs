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
	/// <para>Replace Terrain Points</para>
	/// <para>替换 Terrain 点</para>
	/// <para>可用来自指定要素类的点替换 terrain 数据集引用的点。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ReplaceTerrainPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// <para>待处理的 terrain 数据集。</para>
		/// </param>
		/// <param name="TerrainFeatureClass">
		/// <para>Input Terrain Data Source</para>
		/// <para>将替换某些点或全部点的 terrain 点要素类的名称。</para>
		/// </param>
		/// <param name="InPointFeatures">
		/// <para>Input Points</para>
		/// <para>用来替换 terrain 点要素的点或多点要素。</para>
		/// </param>
		public ReplaceTerrainPoints(object InTerrain, object TerrainFeatureClass, object InPointFeatures)
		{
			this.InTerrain = InTerrain;
			this.TerrainFeatureClass = TerrainFeatureClass;
			this.InPointFeatures = InPointFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 替换 Terrain 点</para>
		/// </summary>
		public override string DisplayName() => "替换 Terrain 点";

		/// <summary>
		/// <para>Tool Name : ReplaceTerrainPoints</para>
		/// </summary>
		public override string ToolName() => "ReplaceTerrainPoints";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ReplaceTerrainPoints</para>
		/// </summary>
		public override string ExcuteName() => "3d.ReplaceTerrainPoints";

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
		public override object[] Parameters() => new object[] { InTerrain, TerrainFeatureClass, InPointFeatures, PolygonFeaturesOrExtent, DerivedOutTerrain };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>待处理的 terrain 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Input Terrain Data Source</para>
		/// <para>将替换某些点或全部点的 terrain 点要素类的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TerrainFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Points</para>
		/// <para>用来替换 terrain 点要素的点或多点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>感兴趣的可选区域，可用于定义替换 terrain 点的区域的范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object PolygonFeaturesOrExtent { get; set; }

		/// <summary>
		/// <para>Updated Input Terrain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTerrainLayer()]
		public object DerivedOutTerrain { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ReplaceTerrainPoints SetEnviroment(int? autoCommit = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

	}
}
