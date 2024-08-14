using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Eliminate Polygon</para>
	/// <para>Eliminates a polygon by merging it with the polygon from the surrounding features that it shares the longest boundary with.</para>
	/// </summary>
	public class EliminatePolygon : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The feature layers that contain the polygons to be deleted.</para>
		/// </param>
		/// <param name="SurroundingFeatures">
		/// <para>Surrounding Features</para>
		/// <para>The polygon features that the Input Features are compared against. If the feature is smaller than the Minimum Area, it becomes part of the input features.</para>
		/// </param>
		public EliminatePolygon(object InFeatures, object SurroundingFeatures)
		{
			this.InFeatures = InFeatures;
			this.SurroundingFeatures = SurroundingFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Eliminate Polygon</para>
		/// </summary>
		public override string DisplayName => "Eliminate Polygon";

		/// <summary>
		/// <para>Tool Name : EliminatePolygon</para>
		/// </summary>
		public override string ToolName => "EliminatePolygon";

		/// <summary>
		/// <para>Tool Excute Name : topographic.EliminatePolygon</para>
		/// </summary>
		public override string ExcuteName => "topographic.EliminatePolygon";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, SurroundingFeatures, MinArea, UpdatedFeatures };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The feature layers that contain the polygons to be deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Surrounding Features</para>
		/// <para>The polygon features that the Input Features are compared against. If the feature is smaller than the Minimum Area, it becomes part of the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		public object SurroundingFeatures { get; set; }

		/// <summary>
		/// <para>Minimum Area</para>
		/// <para>Polygons smaller than the Minimum Area will be deleted. If the Minimum Area is left blank, all features or a selection set from the Input Features will be considered for elimination.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object MinArea { get; set; }

		/// <summary>
		/// <para>Updated Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object UpdatedFeatures { get; set; }

	}
}
