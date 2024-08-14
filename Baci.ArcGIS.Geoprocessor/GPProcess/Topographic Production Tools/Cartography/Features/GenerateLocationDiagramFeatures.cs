using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Generate Location Diagram Features</para>
	/// <para>Generates location diagram features for a Joint Operations Graphic (JOG) map sheet. The location diagram must include JOG_Index features, WAC_Index features, ONC_Index features, or LandPoly features for the area surrounding the processed sheet.</para>
	/// </summary>
	public class GenerateLocationDiagramFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureDataset">
		/// <para>Input Feature Dataset</para>
		/// <para>The feature dataset that will contain the location diagram feature classes. The tool will create these features classes if they do not exist.</para>
		/// </param>
		/// <param name="AreaOfInterest">
		/// <para>Area of Interest</para>
		/// <para>A polygon feature layer with a single selected feature that will be used to identify the center and surrounding AOIs.</para>
		/// </param>
		/// <param name="SheetIdField">
		/// <para>Sheet Identifier Field</para>
		/// <para>An attribute field that will be used to identify the generated sheet features. The default value of JOG_SHEET will be used if the field is present in the layer specified by the Area of Interest parameter value. Otherwise, specify a different field.</para>
		/// </param>
		/// <param name="WacFeatures">
		/// <para>WAC Features</para>
		/// <para>The World Aeronautical Chart (WAC) features that will be used to generate the location diagram feature classes in the input geodatabase. The default path is specified for this parameter if the Defense Mapping product files are installed.</para>
		/// </param>
		/// <param name="OncFeatures">
		/// <para>ONC Features</para>
		/// <para>The Operational Navigation Charts (ONC) features that will be used to generate the location diagram feature classes in the input geodatabase. The default path is specified for this parameter if the Defense Mapping product files are installed.</para>
		/// </param>
		/// <param name="LandFeatures">
		/// <para>Land Features</para>
		/// <para>The land features that will be used to generate the location diagram feature classes in the input geodatabase. The default path is specified for this parameter if the Defense Mapping product files are installed.</para>
		/// </param>
		public GenerateLocationDiagramFeatures(object InFeatureDataset, object AreaOfInterest, object SheetIdField, object WacFeatures, object OncFeatures, object LandFeatures)
		{
			this.InFeatureDataset = InFeatureDataset;
			this.AreaOfInterest = AreaOfInterest;
			this.SheetIdField = SheetIdField;
			this.WacFeatures = WacFeatures;
			this.OncFeatures = OncFeatures;
			this.LandFeatures = LandFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Location Diagram Features</para>
		/// </summary>
		public override string DisplayName => "Generate Location Diagram Features";

		/// <summary>
		/// <para>Tool Name : GenerateLocationDiagramFeatures</para>
		/// </summary>
		public override string ToolName => "GenerateLocationDiagramFeatures";

		/// <summary>
		/// <para>Tool Excute Name : topographic.GenerateLocationDiagramFeatures</para>
		/// </summary>
		public override string ExcuteName => "topographic.GenerateLocationDiagramFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "scratchWorkspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatureDataset, AreaOfInterest, SheetIdField, WacFeatures, OncFeatures, LandFeatures, ModifiedFeatureDataset };

		/// <summary>
		/// <para>Input Feature Dataset</para>
		/// <para>The feature dataset that will contain the location diagram feature classes. The tool will create these features classes if they do not exist.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object InFeatureDataset { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>A polygon feature layer with a single selected feature that will be used to identify the center and surrounding AOIs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Sheet Identifier Field</para>
		/// <para>An attribute field that will be used to identify the generated sheet features. The default value of JOG_SHEET will be used if the field is present in the layer specified by the Area of Interest parameter value. Otherwise, specify a different field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object SheetIdField { get; set; }

		/// <summary>
		/// <para>WAC Features</para>
		/// <para>The World Aeronautical Chart (WAC) features that will be used to generate the location diagram feature classes in the input geodatabase. The default path is specified for this parameter if the Defense Mapping product files are installed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object WacFeatures { get; set; }

		/// <summary>
		/// <para>ONC Features</para>
		/// <para>The Operational Navigation Charts (ONC) features that will be used to generate the location diagram feature classes in the input geodatabase. The default path is specified for this parameter if the Defense Mapping product files are installed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object OncFeatures { get; set; }

		/// <summary>
		/// <para>Land Features</para>
		/// <para>The land features that will be used to generate the location diagram feature classes in the input geodatabase. The default path is specified for this parameter if the Defense Mapping product files are installed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object LandFeatures { get; set; }

		/// <summary>
		/// <para>Modified Feature Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureDataset()]
		public object? ModifiedFeatureDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateLocationDiagramFeatures SetEnviroment(object? scratchWorkspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace);
			return this;
		}

	}
}
