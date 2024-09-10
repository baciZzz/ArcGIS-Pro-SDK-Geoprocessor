using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ModelTools
{
	/// <summary>
	/// <para>Iterate Datasets</para>
	/// <para>Iterates over datasets in a workspace or feature dataset.</para>
	/// </summary>
	public class IterateDatasets : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Workspace or Feature Dataset</para>
		/// <para>Workspace or a feature dataset which stores the dataset to iterate.</para>
		/// </param>
		public IterateDatasets(object InWorkspace)
		{
			this.InWorkspace = InWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : Iterate Datasets</para>
		/// </summary>
		public override string DisplayName() => "Iterate Datasets";

		/// <summary>
		/// <para>Tool Name : IterateDatasets</para>
		/// </summary>
		public override string ToolName() => "IterateDatasets";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateDatasets</para>
		/// </summary>
		public override string ExcuteName() => "mb.IterateDatasets";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise() => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, Wildcard, DatasetType, Recursive, Dataset, Name };

		/// <summary>
		/// <para>Workspace or Feature Dataset</para>
		/// <para>Workspace or a feature dataset which stores the dataset to iterate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Wildcard</para>
		/// <para>A combination of * and characters that help to limit the results. The asterisk is the same as saying ALL. If no wildcard is specified, all inputs will be returned. For example, it can be used to restrict Iteration over input names starting with a certain character or word (for example, A* or Ari* or Land* and so on).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Wildcard { get; set; }

		/// <summary>
		/// <para>Dataset Type</para>
		/// <para>The dataset type to iterate over.</para>
		/// <para>Computer Aided Design (CAD)—Only CAD dataset will be the output.</para>
		/// <para>Feature—Only Feature dataset will be the output.</para>
		/// <para>Geometric Network—Only Geometric Network dataset will be the output.</para>
		/// <para>Mosaic—Only Mosaic dataset will be the output.</para>
		/// <para>Network—Only Network dataset will be the output.</para>
		/// <para>Parcel Fabric—Only Parcel Fabric dataset will be the output.</para>
		/// <para>Raster—Only Raster dataset will be the output.</para>
		/// <para>Terrain—Only Terrain dataset will be the output.</para>
		/// <para>Triangular Irregular Networks (TIN)—Only TIN dataset will be the output.</para>
		/// <para>Topology—Only Topology dataset will be the output.</para>
		/// <para><see cref="DatasetTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DatasetType { get; set; }

		/// <summary>
		/// <para>Recursive</para>
		/// <para>Determines if subfolders in the input workspace will be iterated through recursively.</para>
		/// <para>Checked—Will iterate through all subfolders.</para>
		/// <para>Unchecked—Will not iterate through all subfolders.</para>
		/// <para><see cref="RecursiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Recursive { get; set; } = "false";

		/// <summary>
		/// <para>Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEDatasetType()]
		public object Dataset { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object Name { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Dataset Type</para>
		/// </summary>
		public enum DatasetTypeEnum 
		{
			/// <summary>
			/// <para>Computer Aided Design (CAD)—Only CAD dataset will be the output.</para>
			/// </summary>
			[GPValue("CAD")]
			[Description("Computer Aided Design (CAD)")]
			CAD,

			/// <summary>
			/// <para>Feature—Only Feature dataset will be the output.</para>
			/// </summary>
			[GPValue("FEATURE")]
			[Description("Feature")]
			Feature,

			/// <summary>
			/// <para>Geometric Network—Only Geometric Network dataset will be the output.</para>
			/// </summary>
			[GPValue("GEOMETRICNETWORK")]
			[Description("Geometric Network")]
			Geometric_Network,

			/// <summary>
			/// <para>Mosaic—Only Mosaic dataset will be the output.</para>
			/// </summary>
			[GPValue("MOSAIC")]
			[Description("Mosaic")]
			Mosaic,

			/// <summary>
			/// <para>Network—Only Network dataset will be the output.</para>
			/// </summary>
			[GPValue("NETWORK")]
			[Description("Network")]
			Network,

			/// <summary>
			/// <para>Parcel Fabric—Only Parcel Fabric dataset will be the output.</para>
			/// </summary>
			[GPValue("PARCELFABRIC")]
			[Description("Parcel Fabric")]
			Parcel_Fabric,

			/// <summary>
			/// <para>Raster—Only Raster dataset will be the output.</para>
			/// </summary>
			[GPValue("RASTER")]
			[Description("Raster")]
			Raster,

			/// <summary>
			/// <para>Terrain—Only Terrain dataset will be the output.</para>
			/// </summary>
			[GPValue("TERRAIN")]
			[Description("Terrain")]
			Terrain,

			/// <summary>
			/// <para>Triangular Irregular Networks (TIN)—Only TIN dataset will be the output.</para>
			/// </summary>
			[GPValue("TIN")]
			[Description("Triangular Irregular Networks (TIN)")]
			TIN,

			/// <summary>
			/// <para>Topology—Only Topology dataset will be the output.</para>
			/// </summary>
			[GPValue("TOPOLOGY")]
			[Description("Topology")]
			Topology,

		}

		/// <summary>
		/// <para>Recursive</para>
		/// </summary>
		public enum RecursiveEnum 
		{
			/// <summary>
			/// <para>Checked—Will iterate through all subfolders.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RECURSIVE")]
			RECURSIVE,

			/// <summary>
			/// <para>Unchecked—Will not iterate through all subfolders.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_RECURSIVE")]
			NOT_RECURSIVE,

		}

#endregion
	}
}
