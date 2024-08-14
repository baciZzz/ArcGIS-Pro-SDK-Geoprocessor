using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Near 3D</para>
	/// <para>Calculates the three-dimensional distance from each input feature to the nearest feature that resides in one or more near feature classes.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class Near3D : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input feature class whose features will be attributed with information about the nearest feature.</para>
		/// </param>
		/// <param name="NearFeatures">
		/// <para>Near Features</para>
		/// <para>The one or more features whose proximity to the input features will be calculated. If multiple feature classes are specified, an additional field named NEAR_FC will be added to the input feature class to identify which near feature class contained the closest feature.</para>
		/// </param>
		public Near3D(object InFeatures, object NearFeatures)
		{
			this.InFeatures = InFeatures;
			this.NearFeatures = NearFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Near 3D</para>
		/// </summary>
		public override string DisplayName => "Near 3D";

		/// <summary>
		/// <para>Tool Name : Near3D</para>
		/// </summary>
		public override string ToolName => "Near3D";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Near3D</para>
		/// </summary>
		public override string ExcuteName => "3d.Near3D";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, NearFeatures, SearchRadius, Location, Angle, Delta, OutFeatureClass };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input feature class whose features will be attributed with information about the nearest feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Near Features</para>
		/// <para>The one or more features whose proximity to the input features will be calculated. If multiple feature classes are specified, an additional field named NEAR_FC will be added to the input feature class to identify which near feature class contained the closest feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		public object NearFeatures { get; set; }

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>The maximum distance for which the nearest features from a given input will be determined. If no value is specified, the nearest feature at any distance will be determined.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object SearchRadius { get; set; }

		/// <summary>
		/// <para>Location</para>
		/// <para>Determines whether the coordinates of the nearest point in the input and near feature will be added to the input&apos;s attribute table.</para>
		/// <para>Unchecked—The coordinates are not added to the input feature. This is the default.</para>
		/// <para>Checked—The coordinates are added to the input feature.</para>
		/// <para><see cref="LocationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Location { get; set; } = "false";

		/// <summary>
		/// <para>Angle</para>
		/// <para>Determines whether the horizontal arithmetic angle and vertical angle between the input feature and the nearest feature will be added to the input attribute table.</para>
		/// <para>Unchecked—The angles will not be added to the input&apos;s attribute table. This is the default.</para>
		/// <para>Checked—The horizontal arithmetic angle and vertical angle will be added to the NEAR_ANG_H and NEAR_ANG_V fields in the input&apos;s attribute table.</para>
		/// <para><see cref="AngleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Angle { get; set; } = "false";

		/// <summary>
		/// <para>Delta</para>
		/// <para>Determines whether the distances along the X, Y, and Z axes between the input feature and the nearest feature will be added to the input attribute table.</para>
		/// <para>Unchecked—No distances will be added to the input attribute table. This is the default.</para>
		/// <para>Checked—Distances along the X, Y, and Z axes will be calculated in the NEAR_DELTX, NEAR_DELTY, and NEAR_DELTZ fields.</para>
		/// <para><see cref="DeltaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Delta { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Near3D SetEnviroment(object extent = null , object workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Location</para>
		/// </summary>
		public enum LocationEnum 
		{
			/// <summary>
			/// <para>Checked—The coordinates are added to the input feature.</para>
			/// </summary>
			[GPValue("true")]
			[Description("LOCATION")]
			LOCATION,

			/// <summary>
			/// <para>Unchecked—The coordinates are not added to the input feature. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_LOCATION")]
			NO_LOCATION,

		}

		/// <summary>
		/// <para>Angle</para>
		/// </summary>
		public enum AngleEnum 
		{
			/// <summary>
			/// <para>Checked—The horizontal arithmetic angle and vertical angle will be added to the NEAR_ANG_H and NEAR_ANG_V fields in the input&apos;s attribute table.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ANGLE")]
			ANGLE,

			/// <summary>
			/// <para>Unchecked—The angles will not be added to the input&apos;s attribute table. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ANGLE")]
			NO_ANGLE,

		}

		/// <summary>
		/// <para>Delta</para>
		/// </summary>
		public enum DeltaEnum 
		{
			/// <summary>
			/// <para>Checked—Distances along the X, Y, and Z axes will be calculated in the NEAR_DELTX, NEAR_DELTY, and NEAR_DELTZ fields.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DELTA")]
			DELTA,

			/// <summary>
			/// <para>Unchecked—No distances will be added to the input attribute table. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELTA")]
			NO_DELTA,

		}

#endregion
	}
}
