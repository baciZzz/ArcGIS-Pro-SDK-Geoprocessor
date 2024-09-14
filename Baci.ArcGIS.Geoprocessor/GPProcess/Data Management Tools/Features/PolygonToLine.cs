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
	/// <para>Polygon To Line</para>
	/// <para>Polygon To Line</para>
	/// <para>Creates a feature class containing lines that are converted from polygon boundaries with or without considering neighboring polygons.</para>
	/// </summary>
	public class PolygonToLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input features that must be polygon.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output line feature class.</para>
		/// </param>
		public PolygonToLine(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Polygon To Line</para>
		/// </summary>
		public override string DisplayName() => "Polygon To Line";

		/// <summary>
		/// <para>Tool Name : PolygonToLine</para>
		/// </summary>
		public override string ToolName() => "PolygonToLine";

		/// <summary>
		/// <para>Tool Excute Name : management.PolygonToLine</para>
		/// </summary>
		public override string ExcuteName() => "management.PolygonToLine";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, NeighborOption! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features that must be polygon.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output line feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Identify and store polygon neighboring information</para>
		/// <para>Specifies whether or not to identify and store polygon neighboring information.</para>
		/// <para>Checked— Polygon neighboring relationship will be identified and stored in the output. If different segments of a polygon share boundary with different polygons, the boundary will be split such that each uniquely shared segment will become a line with its two neighboring polygon FIDs stored in the output, as shown in the illustration. This is the default.</para>
		/// <para>Unchecked— Polygon neighboring relationship will be ignored; every polygon boundary will become a line feature with its original polygon feature ID stored in the output.</para>
		/// <para><see cref="NeighborOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? NeighborOption { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PolygonToLine SetEnviroment(object? MDomain = null, double? MResolution = null, double? MTolerance = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, object? extent = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Identify and store polygon neighboring information</para>
		/// </summary>
		public enum NeighborOptionEnum 
		{
			/// <summary>
			/// <para>Checked— Polygon neighboring relationship will be identified and stored in the output. If different segments of a polygon share boundary with different polygons, the boundary will be split such that each uniquely shared segment will become a line with its two neighboring polygon FIDs stored in the output, as shown in the illustration. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("IDENTIFY_NEIGHBORS")]
			IDENTIFY_NEIGHBORS,

			/// <summary>
			/// <para>Unchecked— Polygon neighboring relationship will be ignored; every polygon boundary will become a line feature with its original polygon feature ID stored in the output.</para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_NEIGHBORS")]
			IGNORE_NEIGHBORS,

		}

#endregion
	}
}
