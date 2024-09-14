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
	/// <para>Terrain To Points</para>
	/// <para>Terrain 转点</para>
	/// <para>将 terrain 数据集转换为一个新的点或多点要素类。</para>
	/// </summary>
	public class TerrainToPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// <para>待处理的 terrain 数据集。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </param>
		public TerrainToPoints(object InTerrain, object OutFeatureClass)
		{
			this.InTerrain = InTerrain;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Terrain 转点</para>
		/// </summary>
		public override string DisplayName() => "Terrain 转点";

		/// <summary>
		/// <para>Tool Name : TerrainToPoints</para>
		/// </summary>
		public override string ToolName() => "TerrainToPoints";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TerrainToPoints</para>
		/// </summary>
		public override string ExcuteName() => "3d.TerrainToPoints";

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
		public override string[] ValidEnvironments() => new string[] { "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTerrain, OutFeatureClass, PyramidLevelResolution, SourceEmbeddedFeatureClass, OutGeometryType };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>待处理的 terrain 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Pyramid Level Resolution</para>
		/// <para>将使用 terrain 金字塔等级的 z 容差或窗口大小分辨率。 默认值为 0，或全分辨率。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Input Embedded Feature Class</para>
		/// <para>要导出的 terrain 数据集嵌入点的名称。如果指定一个嵌入要素，则只有来自该要素的点会写入到输出。否则，将会导出参与 terrain 的所有数据源中的全部点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SourceEmbeddedFeatureClass { get; set; } = "<NONE>";

		/// <summary>
		/// <para>Output Feature Class Type</para>
		/// <para>输出要素类的几何。</para>
		/// <para>多点—输出点要素将被写入一个多点要素类。这是默认设置。</para>
		/// <para>点—输出点要素将被写入一个点要素类。</para>
		/// <para><see cref="OutGeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutGeometryType { get; set; } = "MULTIPOINT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TerrainToPoints SetEnviroment(object XYResolution = null, object XYTolerance = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Feature Class Type</para>
		/// </summary>
		public enum OutGeometryTypeEnum 
		{
			/// <summary>
			/// <para>多点—输出点要素将被写入一个多点要素类。这是默认设置。</para>
			/// </summary>
			[GPValue("MULTIPOINT")]
			[Description("多点")]
			Multipoint,

			/// <summary>
			/// <para>点—输出点要素将被写入一个点要素类。</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("点")]
			Point,

		}

#endregion
	}
}
