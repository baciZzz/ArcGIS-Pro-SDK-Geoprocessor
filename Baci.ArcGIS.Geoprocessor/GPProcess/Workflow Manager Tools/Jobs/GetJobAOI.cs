using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.WorkflowManagerTools
{
	/// <summary>
	/// <para>Get Job AOI</para>
	/// <para>Get Job AOI</para>
	/// <para>Gets the job's location of interest (LOI)  as a feature layer. The output layer has either the polygon representing the area of interest (AOI) of the job or point representing the point of interest (POI) of the job.</para>
	/// </summary>
	public class GetJobAOI : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputJobid">
		/// <para>Input Job ID</para>
		/// <para>The ID of the job whose AOI is to be retrieved.</para>
		/// </param>
		/// <param name="AoiLayer">
		/// <para>AOI Layer</para>
		/// <para>The layer name for the location of interest retrieved. The output layer has either the polygon representing the area of interest (AOI) of the job or point representing the point of interest (POI) of the job.</para>
		/// </param>
		public GetJobAOI(object InputJobid, object AoiLayer)
		{
			this.InputJobid = InputJobid;
			this.AoiLayer = AoiLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Get Job AOI</para>
		/// </summary>
		public override string DisplayName() => "Get Job AOI";

		/// <summary>
		/// <para>Tool Name : GetJobAOI</para>
		/// </summary>
		public override string ToolName() => "GetJobAOI";

		/// <summary>
		/// <para>Tool Excute Name : wmx.GetJobAOI</para>
		/// </summary>
		public override string ExcuteName() => "wmx.GetJobAOI";

		/// <summary>
		/// <para>Toolbox Display Name : Workflow Manager Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Workflow Manager Tools";

		/// <summary>
		/// <para>Toolbox Alise : wmx</para>
		/// </summary>
		public override string ToolboxAlise() => "wmx";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputJobid, AoiLayer, InputDatabasepath! };

		/// <summary>
		/// <para>Input Job ID</para>
		/// <para>The ID of the job whose AOI is to be retrieved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InputJobid { get; set; }

		/// <summary>
		/// <para>AOI Layer</para>
		/// <para>The layer name for the location of interest retrieved. The output layer has either the polygon representing the area of interest (AOI) of the job or point representing the point of interest (POI) of the job.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object AoiLayer { get; set; }

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>The Workflow Manager (Classic) database connection file for the input job. If no connection file is specified, the current default Workflow Manager (Classic) database in the project is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object? InputDatabasepath { get; set; }

	}
}
