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
	/// <para>Intervisibility</para>
	/// <para>通视性</para>
	/// <para>决定使用潜在障碍物并由 3D 要素和表面组合定义的视线可见性。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class Intervisibility : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="SightLines">
		/// <para>Sight Lines</para>
		/// <para>将对其可见性进行评估的 3D 视线。</para>
		/// </param>
		/// <param name="Obstructions">
		/// <para>Obstructions</para>
		/// <para>3D 要素、集成网格场景图层以及为视线提供潜在障碍物的表面。</para>
		/// </param>
		public Intervisibility(object SightLines, object Obstructions)
		{
			this.SightLines = SightLines;
			this.Obstructions = Obstructions;
		}

		/// <summary>
		/// <para>Tool Display Name : 通视性</para>
		/// </summary>
		public override string DisplayName() => "通视性";

		/// <summary>
		/// <para>Tool Name : 通视性</para>
		/// </summary>
		public override string ToolName() => "通视性";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Intervisibility</para>
		/// </summary>
		public override string ExcuteName() => "3d.Intervisibility";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { SightLines, Obstructions, VisibleField!, OutFeatureClass! };

		/// <summary>
		/// <para>Sight Lines</para>
		/// <para>将对其可见性进行评估的 3D 视线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object SightLines { get; set; }

		/// <summary>
		/// <para>Obstructions</para>
		/// <para>3D 要素、集成网格场景图层以及为视线提供潜在障碍物的表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object Obstructions { get; set; }

		/// <summary>
		/// <para>Visible Field Name</para>
		/// <para>要存储可见性结果的字段的名称。生成的值 0 表示视线的起点和终点相互不可见。值 1 表示视线的起点和终点相互可见。默认字段名称为 VISIBLE。如果字段已存在，则会覆盖该字段的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? VisibleField { get; set; } = "VISIBLE";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Intervisibility SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

	}
}
