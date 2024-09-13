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
	/// <para>Analyze</para>
	/// <para>Analyze</para>
	/// <para>Updates database statistics of business tables, feature tables, and delta tables, along with the statistics of those tables' indexes.</para>
	/// </summary>
	public class Analyze : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>The table or feature class to be analyzed.</para>
		/// </param>
		/// <param name="Components">
		/// <para>Components to Analyze</para>
		/// <para>The component type to be analyzed.</para>
		/// <para>Business table—Updates business rules statistics.</para>
		/// <para>Feature table—Updates feature statistics.</para>
		/// <para>Raster table—Updates statistics on raster tables.</para>
		/// <para>Adds table—Updates statistics on added datasets.</para>
		/// <para>Deletes table—Updates statistics on deleted datasets.</para>
		/// <para><see cref="ComponentsEnum"/></para>
		/// </param>
		public Analyze(object InDataset, object Components)
		{
			this.InDataset = InDataset;
			this.Components = Components;
		}

		/// <summary>
		/// <para>Tool Display Name : Analyze</para>
		/// </summary>
		public override string DisplayName() => "Analyze";

		/// <summary>
		/// <para>Tool Name : Analyze</para>
		/// </summary>
		public override string ToolName() => "Analyze";

		/// <summary>
		/// <para>Tool Excute Name : management.Analyze</para>
		/// </summary>
		public override string ExcuteName() => "management.Analyze";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, Components, OutDataset! };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>The table or feature class to be analyzed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Components to Analyze</para>
		/// <para>The component type to be analyzed.</para>
		/// <para>Business table—Updates business rules statistics.</para>
		/// <para>Feature table—Updates feature statistics.</para>
		/// <para>Raster table—Updates statistics on raster tables.</para>
		/// <para>Adds table—Updates statistics on added datasets.</para>
		/// <para>Deletes table—Updates statistics on deleted datasets.</para>
		/// <para><see cref="ComponentsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Components { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Analyze SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Components to Analyze</para>
		/// </summary>
		public enum ComponentsEnum 
		{
			/// <summary>
			/// <para>Business table—Updates business rules statistics.</para>
			/// </summary>
			[GPValue("BUSINESS")]
			[Description("Business table")]
			Business_table,

			/// <summary>
			/// <para>Feature table—Updates feature statistics.</para>
			/// </summary>
			[GPValue("FEATURE")]
			[Description("Feature table")]
			Feature_table,

			/// <summary>
			/// <para>Raster table—Updates statistics on raster tables.</para>
			/// </summary>
			[GPValue("RASTER")]
			[Description("Raster table")]
			Raster_table,

			/// <summary>
			/// <para>Adds table—Updates statistics on added datasets.</para>
			/// </summary>
			[GPValue("ADDS")]
			[Description("Adds table")]
			Adds_table,

			/// <summary>
			/// <para>Deletes table—Updates statistics on deleted datasets.</para>
			/// </summary>
			[GPValue("DELETES")]
			[Description("Deletes table")]
			Deletes_table,

		}

#endregion
	}
}
