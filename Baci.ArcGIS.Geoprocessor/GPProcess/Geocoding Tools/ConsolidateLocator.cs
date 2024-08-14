using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeocodingTools
{
	/// <summary>
	/// <para>Consolidate Locator</para>
	/// <para>Consolidate Locator</para>
	/// </summary>
	[Obsolete()]
	public class ConsolidateLocator : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLocator">
		/// <para>Input Locator</para>
		/// </param>
		/// <param name="OutputFolder">
		/// <para>Output Folder</para>
		/// </param>
		public ConsolidateLocator(object InLocator, object OutputFolder)
		{
			this.InLocator = InLocator;
			this.OutputFolder = OutputFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Consolidate Locator</para>
		/// </summary>
		public override string DisplayName => "Consolidate Locator";

		/// <summary>
		/// <para>Tool Name : ConsolidateLocator</para>
		/// </summary>
		public override string ToolName => "ConsolidateLocator";

		/// <summary>
		/// <para>Tool Excute Name : geocoding.ConsolidateLocator</para>
		/// </summary>
		public override string ExcuteName => "geocoding.ConsolidateLocator";

		/// <summary>
		/// <para>Toolbox Display Name : Geocoding Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Geocoding Tools";

		/// <summary>
		/// <para>Toolbox Alise : geocoding</para>
		/// </summary>
		public override string ToolboxAlise => "geocoding";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InLocator, OutputFolder, CopyArcsdeLocator! };

		/// <summary>
		/// <para>Input Locator</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEAddressLocator()]
		public object InLocator { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Composite locator only: copy participating locators in ArcSDE database instead of referencing them</para>
		/// <para><see cref="CopyArcsdeLocatorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CopyArcsdeLocator { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>Composite locator only: copy participating locators in ArcSDE database instead of referencing them</para>
		/// </summary>
		public enum CopyArcsdeLocatorEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("COPY_ARCSDE")]
			COPY_ARCSDE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("PRESERVE_ARCSDE")]
			PRESERVE_ARCSDE,

		}

#endregion
	}
}
