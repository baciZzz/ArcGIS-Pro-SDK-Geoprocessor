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
	/// <para>Eliminate</para>
	/// <para>Eliminates polygons by merging them with neighboring polygons that have the largest area or the longest shared border. Eliminate is often used to remove small sliver polygons that are the result of overlay operations, such as Intersect or Union.</para>
	/// </summary>
	public class Eliminate : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Layer</para>
		/// <para>The layer whose polygons will be merged into neighboring polygons.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class to be created.</para>
		/// </param>
		public Eliminate(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Eliminate</para>
		/// </summary>
		public override string DisplayName() => "Eliminate";

		/// <summary>
		/// <para>Tool Name : Eliminate</para>
		/// </summary>
		public override string ToolName() => "Eliminate";

		/// <summary>
		/// <para>Tool Excute Name : management.Eliminate</para>
		/// </summary>
		public override string ExcuteName() => "management.Eliminate";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, Selection, ExWhereClause, ExFeatures };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The layer whose polygons will be merged into neighboring polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Eliminating polygon by border</para>
		/// <para>These options specify which method will be used for eliminating features.</para>
		/// <para>Checked—Merges a selected polygon with a neighboring unselected polygon by dropping the shared border. The neighboring polygon is the one with the longest shared border. This is the default.</para>
		/// <para>Unchecked—Merges a selected polygon with a neighboring unselected polygon by dropping the shared border. The neighboring polygon is the one with the largest area.</para>
		/// <para><see cref="SelectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Selection { get; set; } = "true";

		/// <summary>
		/// <para>Exclusion Expression</para>
		/// <para>An SQL expression used to identify features that will not be altered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object ExWhereClause { get; set; }

		/// <summary>
		/// <para>Exclusion Layer</para>
		/// <para>An input polyline or polygon feature class or layer that defines polygon boundaries, or portions thereof, that should not be eliminated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object ExFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Eliminate SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , bool? qualifiedFieldNames = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Eliminating polygon by border</para>
		/// </summary>
		public enum SelectionEnum 
		{
			/// <summary>
			/// <para>Checked—Merges a selected polygon with a neighboring unselected polygon by dropping the shared border. The neighboring polygon is the one with the longest shared border. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("LENGTH")]
			LENGTH,

			/// <summary>
			/// <para>Unchecked—Merges a selected polygon with a neighboring unselected polygon by dropping the shared border. The neighboring polygon is the one with the largest area.</para>
			/// </summary>
			[GPValue("false")]
			[Description("AREA")]
			AREA,

		}

#endregion
	}
}
