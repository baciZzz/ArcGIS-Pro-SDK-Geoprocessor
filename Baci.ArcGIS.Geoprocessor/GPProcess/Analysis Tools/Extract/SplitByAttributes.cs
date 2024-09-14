using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Split By Attributes</para>
	/// <para>Split By Attributes</para>
	/// <para>Splits an input dataset by unique attributes.</para>
	/// </summary>
	public class SplitByAttributes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputTable">
		/// <para>Input Table</para>
		/// <para>The input feature class or table whose data will be split into the target workspace.</para>
		/// </param>
		/// <param name="TargetWorkspace">
		/// <para>Target Workspace</para>
		/// <para>The existing workspace where the output feature classes or tables are written.</para>
		/// </param>
		/// <param name="SplitFields">
		/// <para>Split Fields</para>
		/// <para>The fields on which the input will be split into new feature classes or tables.</para>
		/// </param>
		public SplitByAttributes(object InputTable, object TargetWorkspace, object SplitFields)
		{
			this.InputTable = InputTable;
			this.TargetWorkspace = TargetWorkspace;
			this.SplitFields = SplitFields;
		}

		/// <summary>
		/// <para>Tool Display Name : Split By Attributes</para>
		/// </summary>
		public override string DisplayName() => "Split By Attributes";

		/// <summary>
		/// <para>Tool Name : SplitByAttributes</para>
		/// </summary>
		public override string ToolName() => "SplitByAttributes";

		/// <summary>
		/// <para>Tool Excute Name : analysis.SplitByAttributes</para>
		/// </summary>
		public override string ExcuteName() => "analysis.SplitByAttributes";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise() => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "configKeyword", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputTable, TargetWorkspace, SplitFields, TargetWorkspace2 };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input feature class or table whose data will be split into the target workspace.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputTable { get; set; }

		/// <summary>
		/// <para>Target Workspace</para>
		/// <para>The existing workspace where the output feature classes or tables are written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object TargetWorkspace { get; set; }

		/// <summary>
		/// <para>Split Fields</para>
		/// <para>The fields on which the input will be split into new feature classes or tables.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object SplitFields { get; set; }

		/// <summary>
		/// <para>Update Target Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object TargetWorkspace2 { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SplitByAttributes SetEnviroment(object MDomain = null, object MResolution = null, object MTolerance = null, object XYDomain = null, object XYResolution = null, object XYTolerance = null, object configKeyword = null, object extent = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
