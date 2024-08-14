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
	/// <para>Merge</para>
	/// <para>Combines multiple input datasets into a single, new output dataset. This tool can combine point, line, or polygon feature classes or tables.</para>
	/// </summary>
	[Obsolete()]
	public class Merge : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputs">
		/// <para>Input Datasets</para>
		/// <para>The input datasets that will be merged into a new output dataset. Input datasets can be point, line, or polygon feature classes or tables. Input feature classes must all be of the same geometry type.</para>
		/// <para>Tables and feature classes can be combined in a single output dataset. The output type is determined by the first input. If the first input is a feature class, the output will be a feature class; if the first input is a table, the output will be a table. If a table is merged into a feature class, the rows from the input table will have null geometry.</para>
		/// </param>
		/// <param name="Output">
		/// <para>Output Dataset</para>
		/// <para>The output dataset that will contain all combined input datasets.</para>
		/// </param>
		public Merge(object Inputs, object Output)
		{
			this.Inputs = Inputs;
			this.Output = Output;
		}

		/// <summary>
		/// <para>Tool Display Name : Merge</para>
		/// </summary>
		public override string DisplayName => "Merge";

		/// <summary>
		/// <para>Tool Name : Merge</para>
		/// </summary>
		public override string ToolName => "Merge";

		/// <summary>
		/// <para>Tool Excute Name : management.Merge</para>
		/// </summary>
		public override string ExcuteName => "management.Merge";

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
		public override string[] ValidEnvironments => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "maintainAttachments", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "transferGDBAttributeProperties", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Inputs, Output, FieldMappings, AddSource };

		/// <summary>
		/// <para>Input Datasets</para>
		/// <para>The input datasets that will be merged into a new output dataset. Input datasets can be point, line, or polygon feature classes or tables. Input feature classes must all be of the same geometry type.</para>
		/// <para>Tables and feature classes can be combined in a single output dataset. The output type is determined by the first input. If the first input is a feature class, the output will be a feature class; if the first input is a table, the output will be a table. If a table is merged into a feature class, the rows from the input table will have null geometry.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Inputs { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// <para>The output dataset that will contain all combined input datasets.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Field Map</para>
		/// <para>Controls which attribute fields will be in the output. By default, all fields from the inputs will be included.</para>
		/// <para>Fields can be added, deleted, renamed, and reordered, and you can change their properties.</para>
		/// <para>Merge rules allow you to specify how values from two or more input fields are merged or combined into a single output value. There are several merge rules you can use to determine how the output field will be populated with values.</para>
		/// <para>First—Use the input fields&apos; first value.</para>
		/// <para>Last—Use the input fields&apos; last value.</para>
		/// <para>Join—Concatenate (join) the input field values.</para>
		/// <para>Sum—Calculate the total of the input field values.</para>
		/// <para>Mean—Calculate the mean (average) of the input field values.</para>
		/// <para>Median—Calculate the median (middle) of the input field values.</para>
		/// <para>Mode—Use the value with the highest frequency.</para>
		/// <para>Min—Use the minimum value of all the input field values.</para>
		/// <para>Max—Use the maximum value of all the input field values.</para>
		/// <para>Standard deviation—Use the standard deviation classification method on all the input field values.</para>
		/// <para>Count—Find the number of records included in the calculation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldMapping()]
		public object FieldMappings { get; set; }

		/// <summary>
		/// <para>Add source information to output</para>
		/// <para>Specifies whether source information will be added to the output dataset in a new text field, MERGE_SRC. The values in the MERGE_SRC field will indicate the input dataset path or layer name that is the source of each record in the output.</para>
		/// <para>Unchecked—Source information will not be added to the output dataset in a MERGE_SRC field. This is the default.</para>
		/// <para>Checked—Source information will be added to the output dataset in a MERGE_SRC field.</para>
		/// <para><see cref="AddSourceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AddSource { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Merge SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Add source information to output</para>
		/// </summary>
		public enum AddSourceEnum 
		{
			/// <summary>
			/// <para>Checked—Source information will be added to the output dataset in a MERGE_SRC field.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_SOURCE_INFO")]
			ADD_SOURCE_INFO,

			/// <summary>
			/// <para>Unchecked—Source information will not be added to the output dataset in a MERGE_SRC field. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SOURCE_INFO")]
			NO_SOURCE_INFO,

		}

#endregion
	}
}
