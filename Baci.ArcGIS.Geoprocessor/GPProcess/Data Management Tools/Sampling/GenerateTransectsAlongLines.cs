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
	/// <para>Generate Transects Along Lines</para>
	/// <para>Creates perpendicular transect lines at a regular interval along lines.</para>
	/// </summary>
	public class GenerateTransectsAlongLines : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The line features along which perpendicular transect lines will be generated.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output perpendicular transect lines generated along the input features.</para>
		/// </param>
		/// <param name="Interval">
		/// <para>Distance Between Transects</para>
		/// <para>The interval from the beginning of the feature at which transects will be placed.</para>
		/// </param>
		/// <param name="TransectLength">
		/// <para>Transect Length</para>
		/// <para>The length or width of the transect line. Each transect will be placed in such a way along the input line that half its length falls on one side of the line, and half its length falls on the other side of the line.</para>
		/// <para>This is the overall length of each transect line, not the distance that the transect extends from the input line. To specify how far the transect line should extend from the input line—for example, 100 meters—double this value to specify the transect length (200 meters).</para>
		/// </param>
		public GenerateTransectsAlongLines(object InFeatures, object OutFeatureClass, object Interval, object TransectLength)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.Interval = Interval;
			this.TransectLength = TransectLength;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Transects Along Lines</para>
		/// </summary>
		public override string DisplayName => "Generate Transects Along Lines";

		/// <summary>
		/// <para>Tool Name : GenerateTransectsAlongLines</para>
		/// </summary>
		public override string ToolName => "GenerateTransectsAlongLines";

		/// <summary>
		/// <para>Tool Excute Name : management.GenerateTransectsAlongLines</para>
		/// </summary>
		public override string ExcuteName => "management.GenerateTransectsAlongLines";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClass, Interval, TransectLength, IncludeEnds };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The line features along which perpendicular transect lines will be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output perpendicular transect lines generated along the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Distance Between Transects</para>
		/// <para>The interval from the beginning of the feature at which transects will be placed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object Interval { get; set; }

		/// <summary>
		/// <para>Transect Length</para>
		/// <para>The length or width of the transect line. Each transect will be placed in such a way along the input line that half its length falls on one side of the line, and half its length falls on the other side of the line.</para>
		/// <para>This is the overall length of each transect line, not the distance that the transect extends from the input line. To specify how far the transect line should extend from the input line—for example, 100 meters—double this value to specify the transect length (200 meters).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object TransectLength { get; set; }

		/// <summary>
		/// <para>Generate transects at line start and end</para>
		/// <para>Specifies whether transects will be generated at the start and end of the input line.</para>
		/// <para>Checked—Transects will be generated at the start and end of the input line.</para>
		/// <para>Unchecked—Transects will not be generated at the start and end of the input line. This is the default.</para>
		/// <para><see cref="IncludeEndsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeEnds { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateTransectsAlongLines SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Generate transects at line start and end</para>
		/// </summary>
		public enum IncludeEndsEnum 
		{
			/// <summary>
			/// <para>Checked—Transects will be generated at the start and end of the input line.</para>
			/// </summary>
			[GPValue("true")]
			[Description("END_POINTS")]
			END_POINTS,

			/// <summary>
			/// <para>Unchecked—Transects will not be generated at the start and end of the input line. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_END_POINTS")]
			NO_END_POINTS,

		}

#endregion
	}
}
