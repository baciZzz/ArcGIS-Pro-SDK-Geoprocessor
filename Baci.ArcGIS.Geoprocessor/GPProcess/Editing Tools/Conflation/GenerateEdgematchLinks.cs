using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.EditingTools
{
	/// <summary>
	/// <para>Generate Edgematch Links</para>
	/// <para>Finds matching but disconnected line features along the edges of the source data's area and its adjacent data's area, and generates edgematch links from the source lines to the matched adjacent lines.</para>
	/// </summary>
	public class GenerateEdgematchLinks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="SourceFeatures">
		/// <para>Source Features</para>
		/// <para>Line features as edgematching source features. All edgematch links start at source features.</para>
		/// </param>
		/// <param name="AdjacentFeatures">
		/// <para>Adjacent Features</para>
		/// <para>Line features adjacent to source features. All edgematch links end at matched adjacent features.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>Output feature class containing lines representing edgematch links.</para>
		/// </param>
		/// <param name="SearchDistance">
		/// <para>Search Distance</para>
		/// <para>The distance used to search for match candidates. A distance must be specified and it must be greater than zero. You can choose a preferred unit; the default is the feature unit.</para>
		/// </param>
		public GenerateEdgematchLinks(object SourceFeatures, object AdjacentFeatures, object OutFeatureClass, object SearchDistance)
		{
			this.SourceFeatures = SourceFeatures;
			this.AdjacentFeatures = AdjacentFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.SearchDistance = SearchDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Edgematch Links</para>
		/// </summary>
		public override string DisplayName => "Generate Edgematch Links";

		/// <summary>
		/// <para>Tool Name : GenerateEdgematchLinks</para>
		/// </summary>
		public override string ToolName => "GenerateEdgematchLinks";

		/// <summary>
		/// <para>Tool Excute Name : edit.GenerateEdgematchLinks</para>
		/// </summary>
		public override string ExcuteName => "edit.GenerateEdgematchLinks";

		/// <summary>
		/// <para>Toolbox Display Name : Editing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Editing Tools";

		/// <summary>
		/// <para>Toolbox Alise : edit</para>
		/// </summary>
		public override string ToolboxAlise => "edit";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { SourceFeatures, AdjacentFeatures, OutFeatureClass, SearchDistance, MatchFields! };

		/// <summary>
		/// <para>Source Features</para>
		/// <para>Line features as edgematching source features. All edgematch links start at source features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object SourceFeatures { get; set; }

		/// <summary>
		/// <para>Adjacent Features</para>
		/// <para>Line features adjacent to source features. All edgematch links end at matched adjacent features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object AdjacentFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>Output feature class containing lines representing edgematch links.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The distance used to search for match candidates. A distance must be specified and it must be greater than zero. You can choose a preferred unit; the default is the feature unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; }

		/// <summary>
		/// <para>Match Fields</para>
		/// <para>Fields from source and target features, where target fields are from the adjacent features. If specified, each pair of fields are checked for match candidates to help determine the right match.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPFieldDomain()]
		public object? MatchFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateEdgematchLinks SetEnviroment(object? extent = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
