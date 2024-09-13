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
	/// <para>Append Control Points</para>
	/// <para>Append Control Points</para>
	/// <para>Combines control points to an existing control point table.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AppendControlPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMasterControlPoints">
		/// <para>Target Control Points</para>
		/// <para>The input control point table. This is usually the output from the Compute Tie Points tool.</para>
		/// </param>
		/// <param name="InInputControlPoints">
		/// <para>Input Control Points</para>
		/// <para>A point feature class that stores control points. It could be the control point table created from the Compute Control Points tool, the Compute Tie Points tool, or a point feature class that has ground control points.</para>
		/// </param>
		public AppendControlPoints(object InMasterControlPoints, object InInputControlPoints)
		{
			this.InMasterControlPoints = InMasterControlPoints;
			this.InInputControlPoints = InInputControlPoints;
		}

		/// <summary>
		/// <para>Tool Display Name : Append Control Points</para>
		/// </summary>
		public override string DisplayName() => "Append Control Points";

		/// <summary>
		/// <para>Tool Name : AppendControlPoints</para>
		/// </summary>
		public override string ToolName() => "AppendControlPoints";

		/// <summary>
		/// <para>Tool Excute Name : management.AppendControlPoints</para>
		/// </summary>
		public override string ExcuteName() => "management.AppendControlPoints";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMasterControlPoints, InInputControlPoints, InZField!, InTagField!, InDem!, OutMasterControlPoints!, InXyAccuracy!, InZAccuracy!, Geoid!, AreaOfInterest!, AppendOption! };

		/// <summary>
		/// <para>Target Control Points</para>
		/// <para>The input control point table. This is usually the output from the Compute Tie Points tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMasterControlPoints { get; set; }

		/// <summary>
		/// <para>Input Control Points</para>
		/// <para>A point feature class that stores control points. It could be the control point table created from the Compute Control Points tool, the Compute Tie Points tool, or a point feature class that has ground control points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InInputControlPoints { get; set; }

		/// <summary>
		/// <para>Z Value Field Name</para>
		/// <para>The field that stores the control point z-values.</para>
		/// <para>If both the Z Value Field Name and the Input DEM parameters are set, the Z value field is used. If neither the Z Value Field Name nor the Input DEM parameter is set, the z-value is set to 0 for all ground control points and check points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? InZField { get; set; }

		/// <summary>
		/// <para>Tag Field Name</para>
		/// <para>A field in the input control point table that has a unique value. This field will be added to the target control point table, where the tag field can be used to bring in identifiers associated with ground control points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object? InTagField { get; set; }

		/// <summary>
		/// <para>Input DEM</para>
		/// <para>A DEM to use to obtain the z-value for the control points in the input control point table.</para>
		/// <para>If both the Z Value Field Name and Input DEM parameters are set, the Z value field is used. If neither the Z Value Field Name nor the Input DEM parameter is set, the z-value is set to 0 for all ground control points and check points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? InDem { get; set; }

		/// <summary>
		/// <para>Updated Control Points</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutMasterControlPoints { get; set; }

		/// <summary>
		/// <para>XY Accuracy</para>
		/// <para>The input accuracy for the X and Y coordinates. The accuracy is in the same units as the Input Control Points.</para>
		/// <para>This information should be provided by the data provider. If the accuracy information is not available, leave this optional parameter blank.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1.0000000000000001e-09, Max = 1.7976931348623157e+308)]
		public object? InXyAccuracy { get; set; }

		/// <summary>
		/// <para>Z Accuracy</para>
		/// <para>The input accuracy for the vertical coordinates. The accuracy is in the units of the Input Control Points.</para>
		/// <para>This information should be provided by the data provider. If the accuracy information is not available, leave this optional parameter blank.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1.0000000000000001e-09, Max = 1.7976931348623157e+308)]
		public object? InZAccuracy { get; set; }

		/// <summary>
		/// <para>Geoid</para>
		/// <para>The geoid correction is required by rational polynomial coefficients (RPC) that reference ellipsoidal heights. Most elevation datasets are referenced to sea level orthometric heights, so this correction would be required in these cases to convert to ellipsoidal heights.</para>
		/// <para>Unchecked—No geoid correction is made. Use this option only if your DEM is already expressed in ellipsoidal heights. This is the default.</para>
		/// <para>Checked—A geoid correction will be made to convert orthometric heights to ellipsoidal heights (based on EGM96 geoid).</para>
		/// <para><see cref="GeoidEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Geoid { get; set; } = "false";

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>Defines an area of interest extent by entering minimum and maximum x- and y-coordinates in the spatial reference of the input control point table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Append Option</para>
		/// <para>Specifies how control points will be appended to the control point table.</para>
		/// <para>Add all points—Add all points in the input control point table to the target control point table, including GCPs, check points, and all tie points. This is the default.</para>
		/// <para>Add GCPs only—Add only GCPs in the input point table to the target control point table.</para>
		/// <para>Add GCPs and tie points—Add GCPs and tie points specifically associated with the GCPs to the target control point table.Use caution with this option—it is applicable only when the tie points in the input and target control point table have the same transformation. The tie points might not be in the desired positions if they were computed using a different adjustment process.</para>
		/// <para><see cref="AppendOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? AppendOption { get; set; } = "ALL";

		#region InnerClass

		/// <summary>
		/// <para>Geoid</para>
		/// </summary>
		public enum GeoidEnum 
		{
			/// <summary>
			/// <para>Checked—A geoid correction will be made to convert orthometric heights to ellipsoidal heights (based on EGM96 geoid).</para>
			/// </summary>
			[GPValue("true")]
			[Description("GEOID")]
			GEOID,

			/// <summary>
			/// <para>Unchecked—No geoid correction is made. Use this option only if your DEM is already expressed in ellipsoidal heights. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Append Option</para>
		/// </summary>
		public enum AppendOptionEnum 
		{
			/// <summary>
			/// <para>Add all points—Add all points in the input control point table to the target control point table, including GCPs, check points, and all tie points. This is the default.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("Add all points")]
			Add_all_points,

			/// <summary>
			/// <para>Add GCPs only—Add only GCPs in the input point table to the target control point table.</para>
			/// </summary>
			[GPValue("GCP")]
			[Description("Add GCPs only")]
			Add_GCPs_only,

			/// <summary>
			/// <para>Add GCPs and tie points—Add GCPs and tie points specifically associated with the GCPs to the target control point table.Use caution with this option—it is applicable only when the tie points in the input and target control point table have the same transformation. The tie points might not be in the desired positions if they were computed using a different adjustment process.</para>
			/// </summary>
			[GPValue("GCPSET")]
			[Description("Add GCPs and tie points")]
			Add_GCPs_and_tie_points,

		}

#endregion
	}
}
