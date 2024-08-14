using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IndoorsTools
{
	/// <summary>
	/// <para>Create Indoors Database</para>
	/// <para>Creates an Indoors geodatabase that conforms to the ArcGIS Indoors Information Model and contains the feature classes, fields, and tables required for maintaining indoor data for floor plan mapping, routing, space planning, and workspace reservations.</para>
	/// </summary>
	public class CreateIndoorsDatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetGdb">
		/// <para>Target Geodatabase</para>
		/// <para>The geodatabase that will contain the ArcGIS Indoors Information Model to manage indoor GIS information for use with Indoors apps.</para>
		/// </param>
		public CreateIndoorsDatabase(object TargetGdb)
		{
			this.TargetGdb = TargetGdb;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Indoors Database</para>
		/// </summary>
		public override string DisplayName => "Create Indoors Database";

		/// <summary>
		/// <para>Tool Name : CreateIndoorsDatabase</para>
		/// </summary>
		public override string ToolName => "CreateIndoorsDatabase";

		/// <summary>
		/// <para>Tool Excute Name : indoors.CreateIndoorsDatabase</para>
		/// </summary>
		public override string ExcuteName => "indoors.CreateIndoorsDatabase";

		/// <summary>
		/// <para>Toolbox Display Name : Indoors Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Indoors Tools";

		/// <summary>
		/// <para>Toolbox Alise : indoors</para>
		/// </summary>
		public override string ToolboxAlise => "indoors";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { TargetGdb, UpdatedGdb!, CreateNetwork!, SpatialReference!, CreateAttributeRules! };

		/// <summary>
		/// <para>Target Geodatabase</para>
		/// <para>The geodatabase that will contain the ArcGIS Indoors Information Model to manage indoor GIS information for use with Indoors apps.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object TargetGdb { get; set; }

		/// <summary>
		/// <para>Updated Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? UpdatedGdb { get; set; }

		/// <summary>
		/// <para>Create Indoors Network</para>
		/// <para>Specifies whether a network dataset containing the indoor transportation network feature classes—Landmarks, Pathways, and Floor Transitions—will be created in the Indoors database.</para>
		/// <para>Checked—A network dataset and feature classes will be created. This is the default.</para>
		/// <para>Unchecked—A network dataset and feature classes will not be created.</para>
		/// <para><see cref="CreateNetworkEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CreateNetwork { get; set; } = "true";

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>The spatial reference of the output Indoors database. If no spatial reference is set, the output Indoors database will use WGS84 Web Mercator (auxiliary sphere) as the horizontal coordinate system and WGS84 as the vertical coordinate system.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Create Attribute Rules</para>
		/// <para>Specifies whether attribute rules and the associated fields and error datasets will be created in the Indoors database. These attribute rules include validation checks to use in quality control workflows for floor plan data. The target geodatabase must be a file geodatabase or an enterprise geodatabase configured for branch versioning.</para>
		/// <para>Checked—Attribute rules will be created. This is the default.</para>
		/// <para>Unchecked—Attribute rules will not be created.</para>
		/// <para><see cref="CreateAttributeRulesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CreateAttributeRules { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateIndoorsDatabase SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Create Indoors Network</para>
		/// </summary>
		public enum CreateNetworkEnum 
		{
			/// <summary>
			/// <para>Checked—A network dataset and feature classes will be created. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_NETWORK")]
			CREATE_NETWORK,

			/// <summary>
			/// <para>Unchecked—A network dataset and feature classes will not be created.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CREATE_NETWORK")]
			NO_CREATE_NETWORK,

		}

		/// <summary>
		/// <para>Create Attribute Rules</para>
		/// </summary>
		public enum CreateAttributeRulesEnum 
		{
			/// <summary>
			/// <para>Checked—Attribute rules will be created. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_RULES")]
			CREATE_RULES,

			/// <summary>
			/// <para>Unchecked—Attribute rules will not be created.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CREATE_RULES")]
			NO_CREATE_RULES,

		}

#endregion
	}
}
