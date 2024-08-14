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
	/// <para>Split Line at Point</para>
	/// <para>Splits line features based on intersection or proximity to point features.</para>
	/// </summary>
	public class SplitLineAtPoint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input line features to be split.</para>
		/// </param>
		/// <param name="PointFeatures">
		/// <para>Point Features</para>
		/// <para>The input point features whose locations will be used to split the input lines.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class that will contain the split lines.</para>
		/// </param>
		public SplitLineAtPoint(object InFeatures, object PointFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.PointFeatures = PointFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Split Line at Point</para>
		/// </summary>
		public override string DisplayName => "Split Line at Point";

		/// <summary>
		/// <para>Tool Name : SplitLineAtPoint</para>
		/// </summary>
		public override string ToolName => "SplitLineAtPoint";

		/// <summary>
		/// <para>Tool Excute Name : management.SplitLineAtPoint</para>
		/// </summary>
		public override string ExcuteName => "management.SplitLineAtPoint";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "MDomain", "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, PointFeatures, OutFeatureClass, SearchRadius! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input line features to be split.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Point Features</para>
		/// <para>The input point features whose locations will be used to split the input lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object PointFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class that will contain the split lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>The distance that will be used to split lines by their proximity to point features. Points within the search distance to an input line will be used to split those lines at the nearest location to the point along the line segment.</para>
		/// <para>If this parameter is not specified, the single nearest point will be used to split the line feature. If a radius is specified, all points within the radius will be used to split the line.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SearchRadius { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SplitLineAtPoint SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , object? extent = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, workspace: workspace);
			return this;
		}

	}
}
