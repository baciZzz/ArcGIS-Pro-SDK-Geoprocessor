using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LocationReferencingTools
{
	/// <summary>
	/// <para>Create LRS</para>
	/// <para>Create LRS</para>
	/// <para>Creates an ArcGIS Location Referencing linear referencing system (LRS) and minimum schema items in a specified workspace.</para>
	/// </summary>
	public class CreateLRS : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Location</para>
		/// <para>The file or multipurpose geodatabase where the LRS and minimum schema will be created.</para>
		/// </param>
		/// <param name="LrsName">
		/// <para>LRS Name</para>
		/// <para>The name of the output LRS.</para>
		/// </param>
		/// <param name="CenterlineFeatureClassName">
		/// <para>Centerline Feature Class Name</para>
		/// <para>The name of the output centerline feature class.</para>
		/// </param>
		/// <param name="CalibrationPointFeatureClassName">
		/// <para>Calibration Point Feature Class Name</para>
		/// <para>The name of the output calibration point feature class.</para>
		/// </param>
		/// <param name="RedlineFeatureClassName">
		/// <para>Redline Feature Class Name</para>
		/// <para>The name of the output redline feature class.</para>
		/// </param>
		/// <param name="CenterlineSequenceTableName">
		/// <para>Centerline Sequence Table Name</para>
		/// <para>The name of the output centerline sequence table.</para>
		/// </param>
		/// <param name="SpatialReference">
		/// <para>Spatial Reference</para>
		/// <para>The spatial reference for the output feature classes. When using a Python script, you can use the Well Known ID (WKID) for the spatial reference.</para>
		/// </param>
		public CreateLRS(object InWorkspace, object LrsName, object CenterlineFeatureClassName, object CalibrationPointFeatureClassName, object RedlineFeatureClassName, object CenterlineSequenceTableName, object SpatialReference)
		{
			this.InWorkspace = InWorkspace;
			this.LrsName = LrsName;
			this.CenterlineFeatureClassName = CenterlineFeatureClassName;
			this.CalibrationPointFeatureClassName = CalibrationPointFeatureClassName;
			this.RedlineFeatureClassName = RedlineFeatureClassName;
			this.CenterlineSequenceTableName = CenterlineSequenceTableName;
			this.SpatialReference = SpatialReference;
		}

		/// <summary>
		/// <para>Tool Display Name : Create LRS</para>
		/// </summary>
		public override string DisplayName() => "Create LRS";

		/// <summary>
		/// <para>Tool Name : CreateLRS</para>
		/// </summary>
		public override string ToolName() => "CreateLRS";

		/// <summary>
		/// <para>Tool Excute Name : locref.CreateLRS</para>
		/// </summary>
		public override string ExcuteName() => "locref.CreateLRS";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise() => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, LrsName, CenterlineFeatureClassName, CalibrationPointFeatureClassName, RedlineFeatureClassName, CenterlineSequenceTableName, SpatialReference, XyTolerance!, ZTolerance!, XyResolution!, ZResolution!, OutWorkspace!, OutCenterlineFeatureClass!, OutCalibrationPointFeatureClass!, OutRedlineFeatureClass!, OutCenterlineSequenceTable! };

		/// <summary>
		/// <para>Input Location</para>
		/// <para>The file or multipurpose geodatabase where the LRS and minimum schema will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>LRS Name</para>
		/// <para>The name of the output LRS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object LrsName { get; set; }

		/// <summary>
		/// <para>Centerline Feature Class Name</para>
		/// <para>The name of the output centerline feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object CenterlineFeatureClassName { get; set; } = "Centerline";

		/// <summary>
		/// <para>Calibration Point Feature Class Name</para>
		/// <para>The name of the output calibration point feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object CalibrationPointFeatureClassName { get; set; } = "Calibration_Point";

		/// <summary>
		/// <para>Redline Feature Class Name</para>
		/// <para>The name of the output redline feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object RedlineFeatureClassName { get; set; } = "Redline";

		/// <summary>
		/// <para>Centerline Sequence Table Name</para>
		/// <para>The name of the output centerline sequence table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object CenterlineSequenceTableName { get; set; } = "Centerline_Sequence";

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>The spatial reference for the output feature classes. When using a Python script, you can use the Well Known ID (WKID) for the spatial reference.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>The x,y-tolerance of the output feature classes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? XyTolerance { get; set; }

		/// <summary>
		/// <para>Z Tolerance</para>
		/// <para>The z-tolerance of the output feature classes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? ZTolerance { get; set; }

		/// <summary>
		/// <para>XY Resolution</para>
		/// <para>The x,y-resolution of the output feature classes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? XyResolution { get; set; }

		/// <summary>
		/// <para>Z Resolution</para>
		/// <para>The z-resolution of the output feature classes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? ZResolution { get; set; }

		/// <summary>
		/// <para>Updated Input Location</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Output Centerline Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutCenterlineFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Calibration Point Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutCalibrationPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Redline Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutRedlineFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Centerline Sequence Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutCenterlineSequenceTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateLRS SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
