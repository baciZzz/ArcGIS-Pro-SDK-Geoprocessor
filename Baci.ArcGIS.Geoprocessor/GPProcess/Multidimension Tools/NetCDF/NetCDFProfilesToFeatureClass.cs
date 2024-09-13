using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.MultidimensionTools
{
	/// <summary>
	/// <para>NetCDF Profiles To Feature Class (Discrete Sampling Geometry)</para>
	/// <para>NetCDF Profiles To Feature Class (Discrete Sampling Geometry)</para>
	/// <para>Creates a</para>
	/// <para>feature class from profiles in netCDF files. In the</para>
	/// <para>Climate and Forecast (CF) metadata convention, a profile is a type</para>
	/// <para>of discrete sampling geometry (DSG).</para>
	/// </summary>
	public class NetCDFProfilesToFeatureClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFilesOrFolders">
		/// <para>Input NetCDF Files or Folders</para>
		/// <para>The input netCDF files that will be used to create a feature class. Individual netCDF files, as well as folders that contain multiple netCDF files, can be used.</para>
		/// <para>The input netCDF files must have the same DSG feature type and schema.</para>
		/// </param>
		/// <param name="TargetWorkspace">
		/// <para>Target Workspace</para>
		/// <para>The enterprise or file geodatabase in which the output feature class and table will be created. This must be an existing workspace.</para>
		/// </param>
		/// <param name="OutPointOrPolylineName">
		/// <para>Output Point or Polyline Name</para>
		/// <para>The name of the feature class that will contain the locations from the netCDF variables. These variables will be added as fields from the Instance Variables parameter.</para>
		/// </param>
		public NetCDFProfilesToFeatureClass(object InFilesOrFolders, object TargetWorkspace, object OutPointOrPolylineName)
		{
			this.InFilesOrFolders = InFilesOrFolders;
			this.TargetWorkspace = TargetWorkspace;
			this.OutPointOrPolylineName = OutPointOrPolylineName;
		}

		/// <summary>
		/// <para>Tool Display Name : NetCDF Profiles To Feature Class (Discrete Sampling Geometry)</para>
		/// </summary>
		public override string DisplayName() => "NetCDF Profiles To Feature Class (Discrete Sampling Geometry)";

		/// <summary>
		/// <para>Tool Name : NetCDFProfilesToFeatureClass</para>
		/// </summary>
		public override string ToolName() => "NetCDFProfilesToFeatureClass";

		/// <summary>
		/// <para>Tool Excute Name : md.NetCDFProfilesToFeatureClass</para>
		/// </summary>
		public override string ExcuteName() => "md.NetCDFProfilesToFeatureClass";

		/// <summary>
		/// <para>Toolbox Display Name : Multidimension Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Multidimension Tools";

		/// <summary>
		/// <para>Toolbox Alise : md</para>
		/// </summary>
		public override string ToolboxAlise() => "md";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFilesOrFolders, TargetWorkspace, OutPointOrPolylineName, ObservationVariables!, OutTableName!, InstanceVariables!, OutSchema!, IncludeSubdirectories!, InCfMetadata!, AnalysisExtent!, OutJoinLayer!, OutPointOrPolyline!, OutTable! };

		/// <summary>
		/// <para>Input NetCDF Files or Folders</para>
		/// <para>The input netCDF files that will be used to create a feature class. Individual netCDF files, as well as folders that contain multiple netCDF files, can be used.</para>
		/// <para>The input netCDF files must have the same DSG feature type and schema.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object InFilesOrFolders { get; set; }

		/// <summary>
		/// <para>Target Workspace</para>
		/// <para>The enterprise or file geodatabase in which the output feature class and table will be created. This must be an existing workspace.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object TargetWorkspace { get; set; }

		/// <summary>
		/// <para>Output Point or Polyline Name</para>
		/// <para>The name of the feature class that will contain the locations from the netCDF variables. These variables will be added as fields from the Instance Variables parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutPointOrPolylineName { get; set; }

		/// <summary>
		/// <para>Observation Variables</para>
		/// <para>The netCDF variables that contain all the observation values at each location and each vertical level. These will be added as fields to the output table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? ObservationVariables { get; set; }

		/// <summary>
		/// <para>Output Join or Event Table Name</para>
		/// <para>The name of the output table that will contain all the records from the observation variables.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OutTableName { get; set; }

		/// <summary>
		/// <para>Instance Variables</para>
		/// <para>The netCDF variables that differentiate individual features and represent the locations where observations are made. These variables will be added as fields to the output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? InstanceVariables { get; set; }

		/// <summary>
		/// <para>Output Schema</para>
		/// <para>Specifies the output feature class type that will be created.</para>
		/// <para>Instance and Observation—A feature class containing 2D points that contain the location of each instance and a related table containing all the observation variables will be created. This is the default..</para>
		/// <para>Route and Event—A vertical polyline feature class with 3D vertexes and a linear event table for the observation variables will be created.</para>
		/// <para>Point 3D—A 3D feature class with all instances at all vertical levels will be created.</para>
		/// <para><see cref="OutSchemaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutSchema { get; set; } = "INSTANCE_AND_OBSERVATION";

		/// <summary>
		/// <para>Include Subdirectories</para>
		/// <para>Specifies whether the files residing in the subdirectories of an input folder will be used.</para>
		/// <para>Checked—All netCDF files in all subdirectories will be used.</para>
		/// <para>Unchecked—Only files in the input folder will be used. This is the default.</para>
		/// <para><see cref="IncludeSubdirectoriesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeSubdirectories { get; set; } = "false";

		/// <summary>
		/// <para>Input Climate and Forecast Metadata</para>
		/// <para>The XML file with an .ncml extension that will supply missing or altered CF information for the input netCDF files.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("ncml", "xml")]
		public object? InCfMetadata { get; set; }

		/// <summary>
		/// <para>Analysis Extent</para>
		/// <para>The extent that defines the area of the output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? AnalysisExtent { get; set; }

		/// <summary>
		/// <para>Output Join Layer</para>
		/// <para>The output layer that will be created by joining the output table to the output feature class. This is an optional output and is only available when the Instance and Observation option is specified for the Output Schema parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object? OutJoinLayer { get; set; }

		/// <summary>
		/// <para>Output Point or Polyline</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline")]
		[FeatureType("Simple")]
		public object? OutPointOrPolyline { get; set; }

		/// <summary>
		/// <para>Output Join or Event Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public NetCDFProfilesToFeatureClass SetEnviroment(object? extent = null , object? outputCoordinateSystem = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Schema</para>
		/// </summary>
		public enum OutSchemaEnum 
		{
			/// <summary>
			/// <para>Instance and Observation—A feature class containing 2D points that contain the location of each instance and a related table containing all the observation variables will be created. This is the default..</para>
			/// </summary>
			[GPValue("INSTANCE_AND_OBSERVATION")]
			[Description("Instance and Observation")]
			Instance_and_Observation,

			/// <summary>
			/// <para>Point 3D—A 3D feature class with all instances at all vertical levels will be created.</para>
			/// </summary>
			[GPValue("POINT_3D")]
			[Description("Point 3D")]
			Point_3D,

			/// <summary>
			/// <para>Route and Event—A vertical polyline feature class with 3D vertexes and a linear event table for the observation variables will be created.</para>
			/// </summary>
			[GPValue("ROUTE_AND_EVENT")]
			[Description("Route and Event")]
			Route_and_Event,

		}

		/// <summary>
		/// <para>Include Subdirectories</para>
		/// </summary>
		public enum IncludeSubdirectoriesEnum 
		{
			/// <summary>
			/// <para>Checked—All netCDF files in all subdirectories will be used.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_SUBDIRECTORIES")]
			INCLUDE_SUBDIRECTORIES,

			/// <summary>
			/// <para>Unchecked—Only files in the input folder will be used. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_INCLUDE_SUBDIRECTORIES")]
			DO_NOT_INCLUDE_SUBDIRECTORIES,

		}

#endregion
	}
}
