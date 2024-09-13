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
	/// <para>Multipatch Footprint</para>
	/// <para>多面体覆盖区</para>
	/// <para>创建多边形覆盖区用以表示多面体要素的二维区域。</para>
	/// </summary>
	public class MultiPatchFootprint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>将要生成覆盖区的多面体要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>生成的覆盖区面要素类。</para>
		/// </param>
		public MultiPatchFootprint(object InFeatureClass, object OutFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 多面体覆盖区</para>
		/// </summary>
		public override string DisplayName() => "多面体覆盖区";

		/// <summary>
		/// <para>Tool Name : MultiPatchFootprint</para>
		/// </summary>
		public override string ToolName() => "MultiPatchFootprint";

		/// <summary>
		/// <para>Tool Excute Name : 3d.MultiPatchFootprint</para>
		/// </summary>
		public override string ExcuteName() => "3d.MultiPatchFootprint";

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
		public override string[] ValidEnvironments() => new string[] { "XYResolution", "XYTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureClass, OutFeatureClass, GroupField };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>将要生成覆盖区的多面体要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>生成的覆盖区面要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Group Field</para>
		/// <para>该字段用于合并多面体要素，以便构成同一覆盖区面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object GroupField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MultiPatchFootprint SetEnviroment(object XYResolution = null , object XYTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(XYResolution: XYResolution, XYTolerance: XYTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

	}
}
