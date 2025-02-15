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
	/// <para>Check Geometry</para>
	/// <para>Check Geometry</para>
	/// <para>Generates a report of geometry problems in a feature class.</para>
	/// </summary>
	public class CheckGeometry : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The feature class or layer to be processed.</para>
		/// <para>A Desktop Basic license only allows shapefiles and feature classes stored in a file geodatabase, GeoPackage, or SpatiaLite database as valid input feature formats. A Desktop Standard or Desktop Advanced license also allows feature classes stored in an enterprise database or enterprise geodatabase to be used as valid input feature formats.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>The report (as a table) of the problems discovered.</para>
		/// </param>
		public CheckGeometry(object InFeatures, object OutTable)
		{
			this.InFeatures = InFeatures;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Check Geometry</para>
		/// </summary>
		public override string DisplayName() => "Check Geometry";

		/// <summary>
		/// <para>Tool Name : CheckGeometry</para>
		/// </summary>
		public override string ToolName() => "CheckGeometry";

		/// <summary>
		/// <para>Tool Excute Name : management.CheckGeometry</para>
		/// </summary>
		public override string ExcuteName() => "management.CheckGeometry";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "extent", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutTable, ValidationMethod! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The feature class or layer to be processed.</para>
		/// <para>A Desktop Basic license only allows shapefiles and feature classes stored in a file geodatabase, GeoPackage, or SpatiaLite database as valid input feature formats. A Desktop Standard or Desktop Advanced license also allows feature classes stored in an enterprise database or enterprise geodatabase to be used as valid input feature formats.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The report (as a table) of the problems discovered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Validation Method</para>
		/// <para>Specifies the geometry validation method that will be used to identify geometry problems.</para>
		/// <para>Esri—The Esri geometry validation method will be used. This is the default.</para>
		/// <para>OGC—The OGC geometry validation method will be used.</para>
		/// <para><see cref="ValidationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ValidationMethod { get; set; } = "ESRI";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CheckGeometry SetEnviroment(object? configKeyword = null, object? extent = null, object? parallelProcessingFactor = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(configKeyword: configKeyword, extent: extent, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Validation Method</para>
		/// </summary>
		public enum ValidationMethodEnum 
		{
			/// <summary>
			/// <para>Esri—The Esri geometry validation method will be used. This is the default.</para>
			/// </summary>
			[GPValue("ESRI")]
			[Description("Esri")]
			Esri,

			/// <summary>
			/// <para>OGC—The OGC geometry validation method will be used.</para>
			/// </summary>
			[GPValue("OGC")]
			[Description("OGC")]
			OGC,

		}

#endregion
	}
}
