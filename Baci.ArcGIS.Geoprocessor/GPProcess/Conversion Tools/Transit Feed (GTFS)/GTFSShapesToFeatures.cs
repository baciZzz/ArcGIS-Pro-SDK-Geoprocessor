using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>GTFS Shapes To Features</para>
	/// <para>GTFS Shapes To Features</para>
	/// <para>Converts a GTFS shapes.txt file from a GTFS public transit dataset to a polyline feature class showing the physical paths taken by vehicles in the public transit system.</para>
	/// </summary>
	public class GTFSShapesToFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGtfsShapesFile">
		/// <para>Input GTFS Shapes File</para>
		/// <para>A valid shapes.txt file from a GTFS dataset.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class.</para>
		/// </param>
		public GTFSShapesToFeatures(object InGtfsShapesFile, object OutFeatureClass)
		{
			this.InGtfsShapesFile = InGtfsShapesFile;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : GTFS Shapes To Features</para>
		/// </summary>
		public override string DisplayName() => "GTFS Shapes To Features";

		/// <summary>
		/// <para>Tool Name : GTFSShapesToFeatures</para>
		/// </summary>
		public override string ToolName() => "GTFSShapesToFeatures";

		/// <summary>
		/// <para>Tool Excute Name : conversion.GTFSShapesToFeatures</para>
		/// </summary>
		public override string ExcuteName() => "conversion.GTFSShapesToFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGtfsShapesFile, OutFeatureClass };

		/// <summary>
		/// <para>Input GTFS Shapes File</para>
		/// <para>A valid shapes.txt file from a GTFS dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("txt")]
		public object InGtfsShapesFile { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GTFSShapesToFeatures SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
