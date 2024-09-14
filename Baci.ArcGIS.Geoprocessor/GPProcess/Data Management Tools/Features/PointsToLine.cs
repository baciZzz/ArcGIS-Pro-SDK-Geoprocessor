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
	/// <para>Points To Line</para>
	/// <para>Points To Line</para>
	/// <para>Creates line features from points.</para>
	/// </summary>
	public class PointsToLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>The point features to be converted into lines.</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The line feature class which will be created from the input points.</para>
		/// </param>
		public PointsToLine(object InputFeatures, object OutputFeatureClass)
		{
			this.InputFeatures = InputFeatures;
			this.OutputFeatureClass = OutputFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Points To Line</para>
		/// </summary>
		public override string DisplayName() => "Points To Line";

		/// <summary>
		/// <para>Tool Name : PointsToLine</para>
		/// </summary>
		public override string ToolName() => "PointsToLine";

		/// <summary>
		/// <para>Tool Excute Name : management.PointsToLine</para>
		/// </summary>
		public override string ExcuteName() => "management.PointsToLine";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatures, OutputFeatureClass, LineField, SortField, CloseLine };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The point features to be converted into lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The line feature class which will be created from the input points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Line Field</para>
		/// <para>Each feature in the output will be based on unique values in the Line Field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "XML")]
		public object LineField { get; set; }

		/// <summary>
		/// <para>Sort Field</para>
		/// <para>By default, points used to create each output line feature will be used in the order they are found. If a different order is desired, specify a Sort Field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "XML", "OID")]
		public object SortField { get; set; }

		/// <summary>
		/// <para>Close Line</para>
		/// <para>Specifies whether output line features should be closed.</para>
		/// <para>Checked—An extra vertex will be added to ensure that every output line feature&apos;s end point will match up with its start point. Then polygons can be generated from the line feature class using the Feature To Polygon tool.</para>
		/// <para>Unchecked—No extra vertices will be added to close an output line feature. This is the default.</para>
		/// <para><see cref="CloseLineEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CloseLine { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PointsToLine SetEnviroment(object MDomain = null, object MResolution = null, object MTolerance = null, object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object configKeyword = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, bool? qualifiedFieldNames = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Close Line</para>
		/// </summary>
		public enum CloseLineEnum 
		{
			/// <summary>
			/// <para>Checked—An extra vertex will be added to ensure that every output line feature&apos;s end point will match up with its start point. Then polygons can be generated from the line feature class using the Feature To Polygon tool.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLOSE")]
			CLOSE,

			/// <summary>
			/// <para>Unchecked—No extra vertices will be added to close an output line feature. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CLOSE")]
			NO_CLOSE,

		}

#endregion
	}
}
