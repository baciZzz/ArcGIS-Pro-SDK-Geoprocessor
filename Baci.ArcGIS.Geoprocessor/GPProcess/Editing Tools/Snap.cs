using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.EditingTools
{
	/// <summary>
	/// <para>Snap</para>
	/// <para>Snap</para>
	/// <para>Moves points or vertices to coincide exactly with the vertices, edges, or end points of other features. Snapping rules can be specified to control whether the input vertices are snapped to the nearest vertex, edge, or endpoint within a specified distance.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class Snap : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input features with the vertices that will be snapped to the vertices, edges, or end points of other features. The input features can be points, multipoints, lines, or polygons.</para>
		/// </param>
		/// <param name="SnapEnvironment">
		/// <para>Snap Environment</para>
		/// <para>The feature classes or feature layers containing the features to snap to.</para>
		/// <para>The snapping environment components are as follows:</para>
		/// <para>Features—The features that the input features&apos; vertices will be snapped to. These features can be points, multipoints, lines, or polygons.</para>
		/// <para>Type—The type of feature part that the input features&apos; vertices can be snapped to.</para>
		/// <para>Distance—The distance within which the input features&apos; vertices will be snapped to the nearest end point, vertex, or edge.</para>
		/// <para>Available snapping types are as follows:</para>
		/// <para>End—Input feature vertices will be snapped to feature ends.</para>
		/// <para>Vertex—Input feature vertices will be snapped to feature vertices.</para>
		/// <para>Edge—Input feature vertices will be snapped to feature edges.</para>
		/// <para>If a distance is used without a unit (for example, 10 instead of 10 meters), the linear or angular unit from the input feature&apos;s coordinate system will be used as the default. If the input features have a projected coordinate system, its linear unit will be used.</para>
		/// </param>
		public Snap(object InFeatures, object SnapEnvironment)
		{
			this.InFeatures = InFeatures;
			this.SnapEnvironment = SnapEnvironment;
		}

		/// <summary>
		/// <para>Tool Display Name : Snap</para>
		/// </summary>
		public override string DisplayName() => "Snap";

		/// <summary>
		/// <para>Tool Name : Snap</para>
		/// </summary>
		public override string ToolName() => "Snap";

		/// <summary>
		/// <para>Tool Excute Name : edit.Snap</para>
		/// </summary>
		public override string ExcuteName() => "edit.Snap";

		/// <summary>
		/// <para>Toolbox Display Name : Editing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Editing Tools";

		/// <summary>
		/// <para>Toolbox Alise : edit</para>
		/// </summary>
		public override string ToolboxAlise() => "edit";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, SnapEnvironment, OutFeatureClass };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features with the vertices that will be snapped to the vertices, edges, or end points of other features. The input features can be points, multipoints, lines, or polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Snap Environment</para>
		/// <para>The feature classes or feature layers containing the features to snap to.</para>
		/// <para>The snapping environment components are as follows:</para>
		/// <para>Features—The features that the input features&apos; vertices will be snapped to. These features can be points, multipoints, lines, or polygons.</para>
		/// <para>Type—The type of feature part that the input features&apos; vertices can be snapped to.</para>
		/// <para>Distance—The distance within which the input features&apos; vertices will be snapped to the nearest end point, vertex, or edge.</para>
		/// <para>Available snapping types are as follows:</para>
		/// <para>End—Input feature vertices will be snapped to feature ends.</para>
		/// <para>Vertex—Input feature vertices will be snapped to feature vertices.</para>
		/// <para>Edge—Input feature vertices will be snapped to feature edges.</para>
		/// <para>If a distance is used without a unit (for example, 10 instead of 10 meters), the linear or angular unit from the input feature&apos;s coordinate system will be used as the default. If the input features have a projected coordinate system, its linear unit will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object SnapEnvironment { get; set; }

		/// <summary>
		/// <para>Snapped Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Snap SetEnviroment(object extent = null, object workspace = null)
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

	}
}
