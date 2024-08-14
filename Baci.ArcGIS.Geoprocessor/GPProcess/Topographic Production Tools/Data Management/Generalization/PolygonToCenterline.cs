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
	/// <para>Polygon To Centerline</para>
	/// <para>Creates centerlines from polygon features. This tool is useful for creating centerlines from hydrographic polygons for use at smaller scales.</para>
	/// </summary>
	public class PolygonToCenterline : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The polygon features that will be used to create the centerline.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class for the centerlines.</para>
		/// </param>
		public PolygonToCenterline(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Polygon To Centerline</para>
		/// </summary>
		public override string DisplayName => "Polygon To Centerline";

		/// <summary>
		/// <para>Tool Name : PolygonToCenterline</para>
		/// </summary>
		public override string ToolName => "PolygonToCenterline";

		/// <summary>
		/// <para>Tool Excute Name : topographic.PolygonToCenterline</para>
		/// </summary>
		public override string ExcuteName => "topographic.PolygonToCenterline";

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
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClass, ConnectingFeatures };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The polygon features that will be used to create the centerline.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class for the centerlines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Connecting Features</para>
		/// <para>The features to be used to ensure connectivity of the centerline with other features in a network. The centerline will link to the point or the shared boundary wherever a feature from a connecting feature class touches the input feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		public object ConnectingFeatures { get; set; }

	}
}
