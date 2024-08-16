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
	/// <para>Configure Lookup Table</para>
	/// <para>Configures a lookup table for one or more fields used in a multifield route ID.</para>
	/// </summary>
	public class ConfigureLookupTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>LRS Network Feature Class</para>
		/// <para>The input LRS Network feature class in which the lookup table will be configured. The network must have a multifield route ID.</para>
		/// </param>
		/// <param name="LookupTable">
		/// <para>Lookup Table</para>
		/// <para>A table that contains a list of street names and their corresponding GNIS codes. It can be a stand-alone table or reside in an SDE.</para>
		/// </param>
		/// <param name="FieldAppliedTo">
		/// <para>Field Applied To</para>
		/// <para>The route ID field in the LRS Network in which the Lookup Table will be configured.</para>
		/// </param>
		/// <param name="LookupKey">
		/// <para>Lookup Key</para>
		/// <para>The key field in the Lookup Table.</para>
		/// </param>
		public ConfigureLookupTable(object InFeatureClass, object LookupTable, object FieldAppliedTo, object LookupKey)
		{
			this.InFeatureClass = InFeatureClass;
			this.LookupTable = LookupTable;
			this.FieldAppliedTo = FieldAppliedTo;
			this.LookupKey = LookupKey;
		}

		/// <summary>
		/// <para>Tool Display Name : Configure Lookup Table</para>
		/// </summary>
		public override string DisplayName => "Configure Lookup Table";

		/// <summary>
		/// <para>Tool Name : ConfigureLookupTable</para>
		/// </summary>
		public override string ToolName => "ConfigureLookupTable";

		/// <summary>
		/// <para>Tool Excute Name : locref.ConfigureLookupTable</para>
		/// </summary>
		public override string ExcuteName => "locref.ConfigureLookupTable";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatureClass, LookupTable, FieldAppliedTo, LookupKey, LookupDisplay, AllowAnyLookupValue, OutFeatureClass };

		/// <summary>
		/// <para>LRS Network Feature Class</para>
		/// <para>The input LRS Network feature class in which the lookup table will be configured. The network must have a multifield route ID.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Lookup Table</para>
		/// <para>A table that contains a list of street names and their corresponding GNIS codes. It can be a stand-alone table or reside in an SDE.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object LookupTable { get; set; }

		/// <summary>
		/// <para>Field Applied To</para>
		/// <para>The route ID field in the LRS Network in which the Lookup Table will be configured.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FieldAppliedTo { get; set; }

		/// <summary>
		/// <para>Lookup Key</para>
		/// <para>The key field in the Lookup Table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LookupKey { get; set; }

		/// <summary>
		/// <para>Lookup Display</para>
		/// <para>The Lookup Table description field. This field appears in the text box for the multifield route ID.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LookupDisplay { get; set; }

		/// <summary>
		/// <para>Allow any lookup value</para>
		/// <para>Specifies whether a value that is not in the lookup table can be added. The Lookup Display parameter cannot be configured when this option is checked.</para>
		/// <para>Checked—Allow a value to be configured when one is not present in the table.</para>
		/// <para>Unchecked—Don&apos;t allow a lookup display value to be configured. This is the default.</para>
		/// <para><see cref="AllowAnyLookupValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AllowAnyLookupValue { get; set; } = "false";

		/// <summary>
		/// <para>Output Network Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConfigureLookupTable SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Allow any lookup value</para>
		/// </summary>
		public enum AllowAnyLookupValueEnum 
		{
			/// <summary>
			/// <para>Unchecked—Don&apos;t allow a lookup display value to be configured. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_ALLOW_ANY_VALUE")]
			DO_NOT_ALLOW_ANY_VALUE,

			/// <summary>
			/// <para>Checked—Allow a value to be configured when one is not present in the table.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALLOW_ANY_VALUE")]
			ALLOW_ANY_VALUE,

		}

#endregion
	}
}
