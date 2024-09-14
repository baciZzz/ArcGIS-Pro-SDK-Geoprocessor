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
	/// <para>Project</para>
	/// <para>Project</para>
	/// <para>Projects spatial data from one coordinate system to another.</para>
	/// </summary>
	public class Project : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset or Feature Class</para>
		/// <para>The feature class, feature layer, feature dataset, scene layer, or scene layer package to be projected.</para>
		/// </param>
		/// <param name="OutDataset">
		/// <para>Output Dataset or Feature Class</para>
		/// <para>The output dataset to which the results will be written.</para>
		/// </param>
		/// <param name="OutCoorSystem">
		/// <para>Output Coordinate System</para>
		/// <para>The coordinate system to which the input data will be projected.</para>
		/// </param>
		public Project(object InDataset, object OutDataset, object OutCoorSystem)
		{
			this.InDataset = InDataset;
			this.OutDataset = OutDataset;
			this.OutCoorSystem = OutCoorSystem;
		}

		/// <summary>
		/// <para>Tool Display Name : Project</para>
		/// </summary>
		public override string DisplayName() => "Project";

		/// <summary>
		/// <para>Tool Name : Project</para>
		/// </summary>
		public override string ToolName() => "Project";

		/// <summary>
		/// <para>Tool Excute Name : management.Project</para>
		/// </summary>
		public override string ExcuteName() => "management.Project";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "XYResolution", "XYTolerance", "maintainAttachments", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, OutDataset, OutCoorSystem, TransformMethod, InCoorSystem, PreserveShape, MaxDeviation, Vertical };

		/// <summary>
		/// <para>Input Dataset or Feature Class</para>
		/// <para>The feature class, feature layer, feature dataset, scene layer, or scene layer package to be projected.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Dataset or Feature Class</para>
		/// <para>The output dataset to which the results will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutDataset { get; set; }

		/// <summary>
		/// <para>Output Coordinate System</para>
		/// <para>The coordinate system to which the input data will be projected.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCoordinateSystem()]
		public object OutCoorSystem { get; set; }

		/// <summary>
		/// <para>Geographic Transformation</para>
		/// <para>This method can be used to convert data between two geographic coordinate systems or datums. This optional parameter may be required if the input and output coordinate systems have different datums.</para>
		/// <para>The tool automatically selects a default transformation. You can choose a different transformation from the drop-down list. Transformations are bidirectional. For example, if you&apos;re converting data from WGS 1984 to NAD 1927, you can choose a transformation called NAD_1927_to_WGS_1984_3, and the tool will apply it correctly.</para>
		/// <para>The parameter provides a drop-down list of valid transformation methods. See the usage tips for further information on how to choose one or more appropriate transformations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object TransformMethod { get; set; }

		/// <summary>
		/// <para>Input Coordinate System</para>
		/// <para>The coordinate system of the input feature class or dataset. This parameter becomes active when the input has an unknown or unspecified coordinate system. This allows you to specify the data's coordinate system without having to modify the input data (which may not be possible if the input is in read-only format).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object InCoorSystem { get; set; }

		/// <summary>
		/// <para>Preserve Shape</para>
		/// <para>Specifies whether vertices will be added to the output lines or polygons so their projected shape is more accurate.</para>
		/// <para>Unchecked—Extra vertices will not be added to the output lines or polygons. This is the default.</para>
		/// <para>Checked—Extra vertices will be added to the output lines or polygons, as needed, so their projected shape is more accurate.</para>
		/// <para><see cref="PreserveShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object PreserveShape { get; set; } = "false";

		/// <summary>
		/// <para>Maximum Offset Deviation</para>
		/// <para>The distance a projected line or polygon can deviate from its exact projected location when the Preserve Shape parameter is checked. The default is 100 times the x,y tolerance of the spatial reference of the output dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MaxDeviation { get; set; }

		/// <summary>
		/// <para>Vertical</para>
		/// <para>Specifies whether a vertical transformation will be applied.</para>
		/// <para>The parameter is only active when the input and output coordinate systems have a vertical coordinate system and the input feature class coordinates have z-values. Also, many vertical transformations require additional data files that must be installed using the ArcGIS Coordinate Systems Data installation package.</para>
		/// <para>When Vertical is checked, the Geographic Transformation parameter can include ellipsoidal transformations and transformations between vertical datums. For example, ~NAD_1983_To_NAVD88_CONUS_GEOID12B_Height + NAD_1983_To_WGS_1984_1 transforms geometry vertices that are defined on NAD 1983 datum with NAVD 1988 heights into vertices on the WGS 1984 ellipsoid (with z-values representing ellipsoidal heights). The tilde (~) indicates the reversed direction of transformation.</para>
		/// <para>This parameter is not compatible with the Preserve Shape parameter.</para>
		/// <para>Unchecked—No vertical transformation will be applied. The z-values of geometry coordinates will be ignored and the z-values will not be modified. This is the default.</para>
		/// <para>Checked—The transformation specified in the Geographic Transformation parameter will be applied. The Project tool transforms x-, y-, and z-values of geometry coordinates.</para>
		/// <para><see cref="VerticalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Vertical { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Project SetEnviroment(object XYResolution = null, object XYTolerance = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(XYResolution: XYResolution, XYTolerance: XYTolerance, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Preserve Shape</para>
		/// </summary>
		public enum PreserveShapeEnum 
		{
			/// <summary>
			/// <para>Checked—Extra vertices will be added to the output lines or polygons, as needed, so their projected shape is more accurate.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE_SHAPE")]
			PRESERVE_SHAPE,

			/// <summary>
			/// <para>Unchecked—Extra vertices will not be added to the output lines or polygons. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PRESERVE_SHAPE")]
			NO_PRESERVE_SHAPE,

		}

		/// <summary>
		/// <para>Vertical</para>
		/// </summary>
		public enum VerticalEnum 
		{
			/// <summary>
			/// <para>Checked—The transformation specified in the Geographic Transformation parameter will be applied. The Project tool transforms x-, y-, and z-values of geometry coordinates.</para>
			/// </summary>
			[GPValue("true")]
			[Description("VERTICAL")]
			VERTICAL,

			/// <summary>
			/// <para>Unchecked—No vertical transformation will be applied. The z-values of geometry coordinates will be ignored and the z-values will not be modified. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_VERTICAL")]
			NO_VERTICAL,

		}

#endregion
	}
}
