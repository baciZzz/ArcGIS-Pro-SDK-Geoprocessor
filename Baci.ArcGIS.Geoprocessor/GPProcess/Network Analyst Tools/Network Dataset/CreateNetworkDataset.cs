using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkAnalystTools
{
	/// <summary>
	/// <para>Create Network Dataset</para>
	/// <para>Creates a network dataset in an existing feature dataset. The network dataset can be used to perform network analysis on the data in the feature dataset.</para>
	/// </summary>
	public class CreateNetworkDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="FeatureDataset">
		/// <para>Target Feature Dataset</para>
		/// <para>The feature dataset where the network dataset will be created. The feature dataset should contain the source feature classes that will participate in the network dataset.</para>
		/// <para>If the feature dataset is in an enterprise geodatabase, the feature dataset and all source feature classes cannot be versioned.</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Network Dataset Name</para>
		/// <para>The name of the network dataset to be created. The Target Feature Dataset and its parent geodatabase must not already contain a network dataset with this name.</para>
		/// </param>
		/// <param name="SourceFeatureClassNames">
		/// <para>Source Feature Classes</para>
		/// <para>The names of the feature classes to be included in the network dataset as network source features. Specify this parameter as a list of strings.</para>
		/// <para>You must choose at least one line feature class that is not a turn feature class. This line feature class will act as an edge source in the network dataset. You can optionally choose point feature classes to act as junction sources in the network dataset and turn feature classes to act as turn sources.</para>
		/// <para>All source feature classes must reside in the Target Feature Dataset and must not already participate in a geometric network, a utility network, or another network dataset.</para>
		/// </param>
		/// <param name="ElevationModel">
		/// <para>Elevation Model</para>
		/// <para>Specifies the model to be used to control vertical connectivity in the network dataset.</para>
		/// <para>Elevation fields— Coincident endpoints with the same elevation field values are considered connected in the network dataset. This is the default.</para>
		/// <para>Z coordinates—The z-coordinate values in the line feature geometry determine vertical connectivity. Coincident points are considered connected only if they have matching z-coordinate values.</para>
		/// <para>No elevation— Network dataset connectivity is determined only by horizontal coincidence.</para>
		/// <para><see cref="ElevationModelEnum"/></para>
		/// </param>
		public CreateNetworkDataset(object FeatureDataset, object OutName, object SourceFeatureClassNames, object ElevationModel)
		{
			this.FeatureDataset = FeatureDataset;
			this.OutName = OutName;
			this.SourceFeatureClassNames = SourceFeatureClassNames;
			this.ElevationModel = ElevationModel;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Network Dataset</para>
		/// </summary>
		public override string DisplayName() => "Create Network Dataset";

		/// <summary>
		/// <para>Tool Name : CreateNetworkDataset</para>
		/// </summary>
		public override string ToolName() => "CreateNetworkDataset";

		/// <summary>
		/// <para>Tool Excute Name : na.CreateNetworkDataset</para>
		/// </summary>
		public override string ExcuteName() => "na.CreateNetworkDataset";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise() => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { FeatureDataset, OutName, SourceFeatureClassNames, ElevationModel, OutNetworkDataset };

		/// <summary>
		/// <para>Target Feature Dataset</para>
		/// <para>The feature dataset where the network dataset will be created. The feature dataset should contain the source feature classes that will participate in the network dataset.</para>
		/// <para>If the feature dataset is in an enterprise geodatabase, the feature dataset and all source feature classes cannot be versioned.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object FeatureDataset { get; set; }

		/// <summary>
		/// <para>Network Dataset Name</para>
		/// <para>The name of the network dataset to be created. The Target Feature Dataset and its parent geodatabase must not already contain a network dataset with this name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Source Feature Classes</para>
		/// <para>The names of the feature classes to be included in the network dataset as network source features. Specify this parameter as a list of strings.</para>
		/// <para>You must choose at least one line feature class that is not a turn feature class. This line feature class will act as an edge source in the network dataset. You can optionally choose point feature classes to act as junction sources in the network dataset and turn feature classes to act as turn sources.</para>
		/// <para>All source feature classes must reside in the Target Feature Dataset and must not already participate in a geometric network, a utility network, or another network dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object SourceFeatureClassNames { get; set; }

		/// <summary>
		/// <para>Elevation Model</para>
		/// <para>Specifies the model to be used to control vertical connectivity in the network dataset.</para>
		/// <para>Elevation fields— Coincident endpoints with the same elevation field values are considered connected in the network dataset. This is the default.</para>
		/// <para>Z coordinates—The z-coordinate values in the line feature geometry determine vertical connectivity. Coincident points are considered connected only if they have matching z-coordinate values.</para>
		/// <para>No elevation— Network dataset connectivity is determined only by horizontal coincidence.</para>
		/// <para><see cref="ElevationModelEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ElevationModel { get; set; } = "ELEVATION_FIELDS";

		/// <summary>
		/// <para>Output Network Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DENetworkDataset()]
		public object OutNetworkDataset { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Elevation Model</para>
		/// </summary>
		public enum ElevationModelEnum 
		{
			/// <summary>
			/// <para>Elevation fields— Coincident endpoints with the same elevation field values are considered connected in the network dataset. This is the default.</para>
			/// </summary>
			[GPValue("ELEVATION_FIELDS")]
			[Description("Elevation fields")]
			Elevation_fields,

			/// <summary>
			/// <para>Z coordinates—The z-coordinate values in the line feature geometry determine vertical connectivity. Coincident points are considered connected only if they have matching z-coordinate values.</para>
			/// </summary>
			[GPValue("Z_COORDINATES")]
			[Description("Z coordinates")]
			Z_coordinates,

			/// <summary>
			/// <para>No elevation— Network dataset connectivity is determined only by horizontal coincidence.</para>
			/// </summary>
			[GPValue("NO_ELEVATION")]
			[Description("No elevation")]
			No_elevation,

		}

#endregion
	}
}
