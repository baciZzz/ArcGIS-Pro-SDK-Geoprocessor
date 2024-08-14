using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IndoorPositioningTools
{
	/// <summary>
	/// <para>Generate Indoor Positioning File</para>
	/// <para>Generates a positioning file from ArcGIS IPS Setup survey recordings.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class GenerateIndoorPositioningFile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InIpsRecordings">
		/// <para>IPS Recordings Features</para>
		/// <para>The feature class or feature service that contains ArcGIS IPS Setup survey recordings.</para>
		/// </param>
		/// <param name="TargetIpsPositioning">
		/// <para>Target IPS Positioning Table</para>
		/// <para>The table or feature service where the generated IPS positioning file will be stored.</para>
		/// </param>
		public GenerateIndoorPositioningFile(object InIpsRecordings, object TargetIpsPositioning)
		{
			this.InIpsRecordings = InIpsRecordings;
			this.TargetIpsPositioning = TargetIpsPositioning;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Indoor Positioning File</para>
		/// </summary>
		public override string DisplayName => "Generate Indoor Positioning File";

		/// <summary>
		/// <para>Tool Name : GenerateIndoorPositioningFile</para>
		/// </summary>
		public override string ToolName => "GenerateIndoorPositioningFile";

		/// <summary>
		/// <para>Tool Excute Name : indoorpositioning.GenerateIndoorPositioningFile</para>
		/// </summary>
		public override string ExcuteName => "indoorpositioning.GenerateIndoorPositioningFile";

		/// <summary>
		/// <para>Toolbox Display Name : Indoor Positioning Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Indoor Positioning Tools";

		/// <summary>
		/// <para>Toolbox Alise : indoorpositioning</para>
		/// </summary>
		public override string ToolboxAlise => "indoorpositioning";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InIpsRecordings, TargetIpsPositioning, InIpsTransitions!, InIpsComment!, OutIpsPositioning! };

		/// <summary>
		/// <para>IPS Recordings Features</para>
		/// <para>The feature class or feature service that contains ArcGIS IPS Setup survey recordings.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InIpsRecordings { get; set; }

		/// <summary>
		/// <para>Target IPS Positioning Table</para>
		/// <para>The table or feature service where the generated IPS positioning file will be stored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object TargetIpsPositioning { get; set; }

		/// <summary>
		/// <para>IPS Transitions Features</para>
		/// <para>The line feature class that contains the TRANSITION_TYPE, VERTICAL_ORDER_FROM, and VERTICAL_ORDER_TO fields that define facility entrances and exits. These are used by ArcGIS IPS to improve indoor and outdoor localization and switching. The TRANSITION_TYPE field for entrances and exits must contain a value of 7 to be used by this tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object? InIpsTransitions { get; set; }

		/// <summary>
		/// <para>Comment</para>
		/// <para>The text that will be used to populate the Comment field of the positioning file entry in the Target IPS Positioning Table value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? InIpsComment { get; set; }

		/// <summary>
		/// <para>Updated IPS Positioning Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutIpsPositioning { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateIndoorPositioningFile SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
