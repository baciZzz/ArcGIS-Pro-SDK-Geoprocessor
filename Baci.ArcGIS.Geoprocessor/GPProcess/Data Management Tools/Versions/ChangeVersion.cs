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
	/// <para>Change Version</para>
	/// <para>Change Version</para>
	/// <para>Modifies the workspace of a  layer or table view to connect to the specified version.</para>
	/// </summary>
	public class ChangeVersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Layer</para>
		/// <para>The layer or table view that will connect to the specified version.</para>
		/// <para>The sublayers of a topology layer, parcel layer, utility network layer, or trace network layer are not valid inputs.</para>
		/// </param>
		/// <param name="VersionType">
		/// <para>Version Type</para>
		/// <para>Specifies the type of version to which the input feature layer will connect.</para>
		/// <para>Traditional version—Connect to a defined state of the database (traditional version).</para>
		/// <para>Historical version—Connect to a version representing a defined moment in time, often specified by a time or historical marker.</para>
		/// <para>Branch version—Connect to a branch version.</para>
		/// <para><see cref="VersionTypeEnum"/></para>
		/// </param>
		public ChangeVersion(object InFeatures, object VersionType)
		{
			this.InFeatures = InFeatures;
			this.VersionType = VersionType;
		}

		/// <summary>
		/// <para>Tool Display Name : Change Version</para>
		/// </summary>
		public override string DisplayName() => "Change Version";

		/// <summary>
		/// <para>Tool Name : ChangeVersion</para>
		/// </summary>
		public override string ToolName() => "ChangeVersion";

		/// <summary>
		/// <para>Tool Excute Name : management.ChangeVersion</para>
		/// </summary>
		public override string ExcuteName() => "management.ChangeVersion";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, VersionType, VersionName, Date, OutFeatureLayer, IncludeParticipating };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The layer or table view that will connect to the specified version.</para>
		/// <para>The sublayers of a topology layer, parcel layer, utility network layer, or trace network layer are not valid inputs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Version Type</para>
		/// <para>Specifies the type of version to which the input feature layer will connect.</para>
		/// <para>Traditional version—Connect to a defined state of the database (traditional version).</para>
		/// <para>Historical version—Connect to a version representing a defined moment in time, often specified by a time or historical marker.</para>
		/// <para>Branch version—Connect to a branch version.</para>
		/// <para><see cref="VersionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object VersionType { get; set; } = "TRANSACTIONAL";

		/// <summary>
		/// <para>Version Name</para>
		/// <para>The name of the version to which the input feature layer will connect. This parameter is optional if you're using a historical version.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object VersionName { get; set; }

		/// <summary>
		/// <para>Date and Time</para>
		/// <para>The date of the historical version to which the input feature layer will connect.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object Date { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureLayer { get; set; }

		/// <summary>
		/// <para>Include participating classes of controller dataset</para>
		/// <para>Specifies whether the workspace of participating classes will also change.</para>
		/// <para>The parameter is only applicable when the input layer is a topology layer, parcel layer, utility network layer, or trace network layer.</para>
		/// <para>Checked—The version of the participating classes of the controller dataset will change if they are from the same workspace as the controller dataset. This is the default.</para>
		/// <para>Unchecked—Only the version of the controller dataset will change.</para>
		/// <para><see cref="IncludeParticipatingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeParticipating { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>Version Type</para>
		/// </summary>
		public enum VersionTypeEnum 
		{
			/// <summary>
			/// <para>Traditional version—Connect to a defined state of the database (traditional version).</para>
			/// </summary>
			[GPValue("TRANSACTIONAL")]
			[Description("Traditional version")]
			Traditional_version,

			/// <summary>
			/// <para>Branch version—Connect to a branch version.</para>
			/// </summary>
			[GPValue("BRANCH")]
			[Description("Branch version")]
			Branch_version,

			/// <summary>
			/// <para>Historical version—Connect to a version representing a defined moment in time, often specified by a time or historical marker.</para>
			/// </summary>
			[GPValue("HISTORICAL")]
			[Description("Historical version")]
			Historical_version,

		}

		/// <summary>
		/// <para>Include participating classes of controller dataset</para>
		/// </summary>
		public enum IncludeParticipatingEnum 
		{
			/// <summary>
			/// <para>Checked—The version of the participating classes of the controller dataset will change if they are from the same workspace as the controller dataset. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE")]
			INCLUDE,

			/// <summary>
			/// <para>Unchecked—Only the version of the controller dataset will change.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE")]
			EXCLUDE,

		}

#endregion
	}
}
