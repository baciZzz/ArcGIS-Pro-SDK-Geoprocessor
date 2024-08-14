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
	/// <para>Features To GPX</para>
	/// <para>Converts point, multipoint, or polyline features to a GPX format file (.gpx).</para>
	/// </summary>
	public class FeaturesToGPX : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input point, multipoint, or line features.</para>
		/// </param>
		/// <param name="OutGpxFile">
		/// <para>Output GPX File</para>
		/// <para>The .gpx file that will be created with the geometry and attributes of the input features.</para>
		/// </param>
		public FeaturesToGPX(object InFeatures, object OutGpxFile)
		{
			this.InFeatures = InFeatures;
			this.OutGpxFile = OutGpxFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Features To GPX</para>
		/// </summary>
		public override string DisplayName => "Features To GPX";

		/// <summary>
		/// <para>Tool Name : FeaturesToGPX</para>
		/// </summary>
		public override string ToolName => "FeaturesToGPX";

		/// <summary>
		/// <para>Tool Excute Name : conversion.FeaturesToGPX</para>
		/// </summary>
		public override string ExcuteName => "conversion.FeaturesToGPX";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutGpxFile, NameField, DescriptionField, ZField, DateField };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input point, multipoint, or line features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output GPX File</para>
		/// <para>The .gpx file that will be created with the geometry and attributes of the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutGpxFile { get; set; }

		/// <summary>
		/// <para>Name Field</para>
		/// <para>A field from the input features with values used to populate the GPX name tag.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object NameField { get; set; }

		/// <summary>
		/// <para>Description Field</para>
		/// <para>A field from the input features with values used to populate the GPX desc tag.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object DescriptionField { get; set; }

		/// <summary>
		/// <para>Z Field</para>
		/// <para>A numeric field from the input features with values used to populate the GPX elevation tag. If an elevation field is not specified, the z-values from the input features' geometries will be used to populate the GPX elevation tag.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object ZField { get; set; }

		/// <summary>
		/// <para>Date Field</para>
		/// <para>A date/time field from the input features with values used to populate the GPX time tag.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object DateField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeaturesToGPX SetEnviroment(object extent = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
