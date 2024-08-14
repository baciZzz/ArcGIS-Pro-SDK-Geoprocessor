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
	/// <para>Iterates over different types of datasets in a workspace.</para>
	/// </summary>
	public class IterateDatasets : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Workspace or Feature Dataset</para>
		/// <para>A workspace or a feature dataset that stores the dataset to iterate.</para>
		/// </param>
		public IterateDatasets(object InWorkspace)
		{
			this.InWorkspace = InWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : Iterate Datasets</para>
		/// </summary>
		public override string DisplayName => "Iterate Datasets";

		/// <summary>
		/// <para>Tool Name : IterateDatasets</para>
		/// </summary>
		public override string ToolName => "IterateDatasets";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateDatasets</para>
		/// </summary>
		public override string ExcuteName => "mb.IterateDatasets";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InWorkspace, Wildcard!, DatasetType!, Recursive!, Dataset!, Name! };

		/// <summary>
		/// <para>Workspace or Feature Dataset</para>
		/// <para>A workspace or a feature dataset that stores the dataset to iterate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Wildcard</para>
		/// <para>A combination of * and characters that help to limit the results. The asterisk is the same as specifying ALL. If no wildcard is specified, all inputs will be returned. For example, it can be used to restrict Iteration over input names starting with a certain character or word (for example, A* or Ari* or Land* and so on).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Wildcard { get; set; }

		/// <summary>
		/// <para>Dataset Type</para>
		/// <para>The dataset type to iterate over.</para>
		/// <para>Computer Aided Design (CAD)—The output will be a CAD dataset.</para>
		/// <para>Feature—The output will be a feature dataset.</para>
		/// <para>Geometric Network—The output will be a geometric network dataset.</para>
		/// <para>Mosaic—The output will be a mosaic dataset.</para>
		/// <para>Network—The output will be a network dataset.</para>
		/// <para>Parcel Fabric For ArcMap—The output will be an ArcMap parcel fabric dataset.</para>
		/// <para>Parcel Fabric—The output will be a parcel fabric dataset.</para>
		/// <para>Raster—The output will be a raster dataset .</para>
		/// <para>Terrain—The output will be a terrain dataset.</para>
		/// <para>Triangular Irregular Networks (TIN)—The output will be a TIN dataset .</para>
		/// <para>Topology—The output will be a topology dataset .</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DatasetType { get; set; }

		/// <summary>
		/// <para>Recursive</para>
		/// <para>Specifies whether subfolders in the input workspace will be iterated recursively.</para>
		/// <para>Checked—Subfolders will be iterated recursively.</para>
		/// <para>Unchecked—Subfolders will not be iterated recursively.</para>
		/// <para><see cref="RecursiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Recursive { get; set; } = "false";

		/// <summary>
		/// <para>Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEDatasetType()]
		public object? Dataset { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? Name { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Recursive</para>
		/// </summary>
		public enum RecursiveEnum 
		{
			/// <summary>
			/// <para>Checked—Subfolders will be iterated recursively.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RECURSIVE")]
			RECURSIVE,

			/// <summary>
			/// <para>Unchecked—Subfolders will not be iterated recursively.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_RECURSIVE")]
			NOT_RECURSIVE,

		}

#endregion
	}
}
