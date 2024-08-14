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
	/// <para>Create Turn Feature Class</para>
	/// <para>Creates a new turn feature class to store turn features that model turning movements in a network dataset.</para>
	/// </summary>
	public class CreateTurnFeatureClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutLocation">
		/// <para>Output Location</para>
		/// <para>The file, workgroup, or enterprise geodatabase, or the folder in which the output turn feature class will be created. The workspace must already exist.</para>
		/// </param>
		/// <param name="OutFeatureClassName">
		/// <para>Output Turn Feature Class Name</para>
		/// <para>The name of the turn feature class to be created.</para>
		/// </param>
		public CreateTurnFeatureClass(object OutLocation, object OutFeatureClassName)
		{
			this.OutLocation = OutLocation;
			this.OutFeatureClassName = OutFeatureClassName;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Turn Feature Class</para>
		/// </summary>
		public override string DisplayName => "Create Turn Feature Class";

		/// <summary>
		/// <para>Tool Name : CreateTurnFeatureClass</para>
		/// </summary>
		public override string ToolName => "CreateTurnFeatureClass";

		/// <summary>
		/// <para>Tool Excute Name : na.CreateTurnFeatureClass</para>
		/// </summary>
		public override string ExcuteName => "na.CreateTurnFeatureClass";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "configKeyword", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { OutLocation, OutFeatureClassName, MaximumEdges, InNetworkDataset, InTemplateFeatureClass, SpatialReference, ConfigKeyword, SpatialGrid1, SpatialGrid2, SpatialGrid3, HasZ, OutTurnFeatures };

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The file, workgroup, or enterprise geodatabase, or the folder in which the output turn feature class will be created. The workspace must already exist.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutLocation { get; set; }

		/// <summary>
		/// <para>Output Turn Feature Class Name</para>
		/// <para>The name of the turn feature class to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutFeatureClassName { get; set; }

		/// <summary>
		/// <para>Maximum Edges</para>
		/// <para>The maximum number of edges that turns in the new turn feature class can model. The default value is 5. The maximum value is 50.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaximumEdges { get; set; } = "5";

		/// <summary>
		/// <para>Input Network Dataset</para>
		/// <para>The network dataset in which the turn feature class will participate. The resulting turn feature class will be added as a turn source to the network dataset. If no network dataset is specified, the turn feature class will be created as not participating in a network dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPNetworkDatasetLayer()]
		public object InNetworkDataset { get; set; }

		/// <summary>
		/// <para>Template Feature Class</para>
		/// <para>The feature class used as a template to define the attribute schema of the new turn feature class.</para>
		/// <para>If the template feature class has the following fields, they are not created on the output turn feature class; NODE_, NODE#, JUNCTION, F_EDGE, T_EDGE, F-EDGE, T-EDGE, ARC1_, ARC2_, ARC1#, ARC2#, ARC1-ID, ARC2-ID, AZIMUTH, ANGLE.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object InTemplateFeatureClass { get; set; }

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>The spatial reference to be applied to the output turn feature class. This parameter is ignored if the output location is a geodatabase feature dataset, as the output turn feature class will inherit the spatial reference of the feature dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>Specifies the configuration keyword that determines the storage parameters of the new turn feature class. This parameter is used only if the output location is an workgroup or enterprise geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Geodatabase Settings")]
		public object ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Output Spatial Grid 1</para>
		/// <para>This parameter has been deprecated in ArcGIS Pro. Any value you enter is ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Geodatabase Settings")]
		public object SpatialGrid1 { get; set; } = "1000";

		/// <summary>
		/// <para>Output Spatial Grid 2</para>
		/// <para>This parameter has been deprecated in ArcGIS Pro. Any value you enter is ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Geodatabase Settings")]
		public object SpatialGrid2 { get; set; } = "0";

		/// <summary>
		/// <para>Output Spatial Grid 3</para>
		/// <para>This parameter has been deprecated in ArcGIS Pro. Any value you enter is ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Geodatabase Settings")]
		public object SpatialGrid3 { get; set; } = "0";

		/// <summary>
		/// <para>Has Z</para>
		/// <para>Checked—The coordinates in the new turn feature class will have elevation (Z) values. This parameter is automatically checked and disabled if the input network dataset is specified and it supports connectivity based on z coordinate values of the network sources.</para>
		/// <para>Unchecked—The coordinates in the new turn feature class will not have elevation (Z) values.</para>
		/// <para><see cref="HasZEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object HasZ { get; set; } = "false";

		/// <summary>
		/// <para>Output Turn Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutTurnFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateTurnFeatureClass SetEnviroment(object configKeyword = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Has Z</para>
		/// </summary>
		public enum HasZEnum 
		{
			/// <summary>
			/// <para>Checked—The coordinates in the new turn feature class will have elevation (Z) values. This parameter is automatically checked and disabled if the input network dataset is specified and it supports connectivity based on z coordinate values of the network sources.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ENABLED")]
			ENABLED,

			/// <summary>
			/// <para>Unchecked—The coordinates in the new turn feature class will not have elevation (Z) values.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DISABLED")]
			DISABLED,

		}

#endregion
	}
}
