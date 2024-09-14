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
	/// <para>Difference 3D</para>
	/// <para>3D 差异</para>
	/// <para>消除目标要素类中部分与减法要素类中闭合的多面体要素体积重叠的多面体要素。</para>
	/// </summary>
	public class Difference3D : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeaturesMinuend">
		/// <para>Input Features</para>
		/// <para>通过减数要素移除其要素的多面体要素。</para>
		/// </param>
		/// <param name="InFeaturesSubtrahend">
		/// <para>Subtract Features</para>
		/// <para>将从输入中减去的多面体要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将包含所生成要素的输出多面体要素类。</para>
		/// </param>
		public Difference3D(object InFeaturesMinuend, object InFeaturesSubtrahend, object OutFeatureClass)
		{
			this.InFeaturesMinuend = InFeaturesMinuend;
			this.InFeaturesSubtrahend = InFeaturesSubtrahend;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 3D 差异</para>
		/// </summary>
		public override string DisplayName() => "3D 差异";

		/// <summary>
		/// <para>Tool Name : Difference3D</para>
		/// </summary>
		public override string ToolName() => "Difference3D";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Difference3D</para>
		/// </summary>
		public override string ExcuteName() => "3d.Difference3D";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "ZDomain", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeaturesMinuend, InFeaturesSubtrahend, OutFeatureClass, OutTable! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>通过减数要素移除其要素的多面体要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object InFeaturesMinuend { get; set; }

		/// <summary>
		/// <para>Subtract Features</para>
		/// <para>将从输入中减去的多面体要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object InFeaturesSubtrahend { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将包含所生成要素的输出多面体要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>可选表，存储有关输入要素和差异输出之间关系的信息。此表中会显示下列字段：</para>
		/// <para>Output_ID - 输出要素的 ID。</para>
		/// <para>Minuend_ID - 输入要素的 ID。</para>
		/// <para>Subtrahend - 减法要素的 ID。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Difference3D SetEnviroment(object? XYDomain = null, object? ZDomain = null, int? autoCommit = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, ZDomain: ZDomain, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

	}
}
