using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Summarize Attributes</para>
	/// <para>Summarize Attributes</para>
	/// <para>Calculates summary statistics for fields in a feature class.</para>
	/// </summary>
	public class SummarizeAttributes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>The point, polyline, or polygon layer to be summarized.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>A new table with the summarized attributes.</para>
		/// </param>
		public SummarizeAttributes(object InputLayer, object OutTable)
		{
			this.InputLayer = InputLayer;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Summarize Attributes</para>
		/// </summary>
		public override string DisplayName() => "Summarize Attributes";

		/// <summary>
		/// <para>Tool Name : SummarizeAttributes</para>
		/// </summary>
		public override string ToolName() => "SummarizeAttributes";

		/// <summary>
		/// <para>Tool Excute Name : gapro.SummarizeAttributes</para>
		/// </summary>
		public override string ExcuteName() => "gapro.SummarizeAttributes";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise() => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, OutTable, Fields!, SummaryFields!, TimeStepInterval!, TimeStepRepeat!, TimeStepReference! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The point, polyline, or polygon layer to be summarized.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>A new table with the summarized attributes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Fields</para>
		/// <para>A field or fields used to summarize similar features. For example, if you choose a single field called PropertyType with the values of commercial and residential, all of the fields with the value residential fields will be summarized together, with summary statistics calculated, and all of the fields with the value commercial will be summarized together. This example will results in two rows in the output, one for commercial, and one for residential summary values.</para>
		/// <para>You can optionally select no fields and summarize all features in a single summary result.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object? Fields { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>The statistics that will be calculated on specified fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? SummaryFields { get; set; }

		/// <summary>
		/// <para>Time step interval</para>
		/// <para>A value that specifies the duration of the time step. This parameter is only available if the input points are time enabled and represent an instant in time.</para>
		/// <para>Time stepping can only be applied if time is enabled on the input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeStepInterval { get; set; }

		/// <summary>
		/// <para>Time step repeat</para>
		/// <para>A value that specifies how often the time-step interval occurs. This parameter is only available if the input points are time enabled and represent an instant in time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeStepRepeat { get; set; }

		/// <summary>
		/// <para>Time step reference</para>
		/// <para>A date that specifies the reference time with which to align the time steps. The default is January 1, 1970, at 12:00 a.m. This parameter is only available if the input points are time enabled and represent an instant in time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? TimeStepReference { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SummarizeAttributes SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

	}
}
