using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>Areal Interpolation Layer To Polygons</para>
	/// <para>Reaggregates the predictions of an Areal Interpolation layer to a new set of polygons.</para>
	/// </summary>
	public class ArealInterpolationLayerToPolygons : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InArealInterpolationLayer">
		/// <para>Input areal interpolation geostatistical layer</para>
		/// <para>Input geostatistical layer resulting from an Areal Interpolation model.</para>
		/// </param>
		/// <param name="InPolygonFeatures">
		/// <para>Input polygon features</para>
		/// <para>The polygons where predictions and standard errors will be aggregated.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output polygon feature class</para>
		/// <para>The output feature class containing the aggregated predictions and standard errors for the new polygons.</para>
		/// </param>
		public ArealInterpolationLayerToPolygons(object InArealInterpolationLayer, object InPolygonFeatures, object OutFeatureClass)
		{
			this.InArealInterpolationLayer = InArealInterpolationLayer;
			this.InPolygonFeatures = InPolygonFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Areal Interpolation Layer To Polygons</para>
		/// </summary>
		public override string DisplayName => "Areal Interpolation Layer To Polygons";

		/// <summary>
		/// <para>Tool Name : ArealInterpolationLayerToPolygons</para>
		/// </summary>
		public override string ToolName => "ArealInterpolationLayerToPolygons";

		/// <summary>
		/// <para>Tool Excute Name : ga.ArealInterpolationLayerToPolygons</para>
		/// </summary>
		public override string ExcuteName => "ga.ArealInterpolationLayerToPolygons";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InArealInterpolationLayer, InPolygonFeatures, OutFeatureClass, AppendAllFields };

		/// <summary>
		/// <para>Input areal interpolation geostatistical layer</para>
		/// <para>Input geostatistical layer resulting from an Areal Interpolation model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object InArealInterpolationLayer { get; set; }

		/// <summary>
		/// <para>Input polygon features</para>
		/// <para>The polygons where predictions and standard errors will be aggregated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InPolygonFeatures { get; set; }

		/// <summary>
		/// <para>Output polygon feature class</para>
		/// <para>The output feature class containing the aggregated predictions and standard errors for the new polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Append all fields from input features</para>
		/// <para>Determines whether all fields will be copied from the input features to the output feature class.</para>
		/// <para>Checked—All fields from the input features will be copied to the output feature class. This is the default.</para>
		/// <para>Unchecked—Only the feature ID value will be copied, and it will be named Source_ID on the output feature class.</para>
		/// <para><see cref="AppendAllFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AppendAllFields { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ArealInterpolationLayerToPolygons SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Append all fields from input features</para>
		/// </summary>
		public enum AppendAllFieldsEnum 
		{
			/// <summary>
			/// <para>Checked—All fields from the input features will be copied to the output feature class. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL")]
			ALL,

			/// <summary>
			/// <para>Unchecked—Only the feature ID value will be copied, and it will be named Source_ID on the output feature class.</para>
			/// </summary>
			[GPValue("false")]
			[Description("FID_ONLY")]
			FID_ONLY,

		}

#endregion
	}
}
