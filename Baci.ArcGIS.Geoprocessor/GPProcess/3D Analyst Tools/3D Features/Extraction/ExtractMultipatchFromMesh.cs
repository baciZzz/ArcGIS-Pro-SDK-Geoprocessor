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
	/// <para>Extract Multipatch From Mesh</para>
	/// <para>从网格中提取多面体</para>
	/// <para>用于从与面重叠的集成网格的一部分创建多面体要素。</para>
	/// </summary>
	public class ExtractMultipatchFromMesh : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="SourceMesh">
		/// <para>Source Integrated Mesh</para>
		/// <para>将要处理的集成式网格。</para>
		/// </param>
		/// <param name="FootprintFeatures">
		/// <para>Footprint Features</para>
		/// <para>此面要素用于定义将被裁剪的区域。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Multipatch Feature Class</para>
		/// <para>将由此工具生成的多面体要素类。</para>
		/// </param>
		public ExtractMultipatchFromMesh(object SourceMesh, object FootprintFeatures, object OutFeatureClass)
		{
			this.SourceMesh = SourceMesh;
			this.FootprintFeatures = FootprintFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 从网格中提取多面体</para>
		/// </summary>
		public override string DisplayName() => "从网格中提取多面体";

		/// <summary>
		/// <para>Tool Name : ExtractMultipatchFromMesh</para>
		/// </summary>
		public override string ToolName() => "ExtractMultipatchFromMesh";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ExtractMultipatchFromMesh</para>
		/// </summary>
		public override string ExcuteName() => "3d.ExtractMultipatchFromMesh";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { SourceMesh, FootprintFeatures, OutFeatureClass };

		/// <summary>
		/// <para>Source Integrated Mesh</para>
		/// <para>将要处理的集成式网格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object SourceMesh { get; set; }

		/// <summary>
		/// <para>Footprint Features</para>
		/// <para>此面要素用于定义将被裁剪的区域。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object FootprintFeatures { get; set; }

		/// <summary>
		/// <para>Output Multipatch Feature Class</para>
		/// <para>将由此工具生成的多面体要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractMultipatchFromMesh SetEnviroment(object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

	}
}
