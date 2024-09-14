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
	/// <para>Generate Rubbersheet Links</para>
	/// <para>Generate Rubbersheet Links</para>
	/// <para>Finds where the source line features spatially match the target line features and generates lines representing links from source locations to corresponding target locations for rubbersheeting.</para>
	/// </summary>
	public class GenerateRubbersheetLinks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="SourceFeatures">
		/// <para>Source Features</para>
		/// <para>Line features as source features for generating rubbersheet links. All links start at source features.</para>
		/// </param>
		/// <param name="TargetFeatures">
		/// <para>Target Features</para>
		/// <para>Line features as target features for generating rubbersheet links. All links end at matched target features.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>Output feature class containing lines representing regular rubbersheet links.</para>
		/// </param>
		/// <param name="SearchDistance">
		/// <para>Search Distance</para>
		/// <para>The distance used to search for match candidates. A distance must be specified and it must be greater than zero. You can choose a preferred unit; the default is the feature unit.</para>
		/// </param>
		public GenerateRubbersheetLinks(object SourceFeatures, object TargetFeatures, object OutFeatureClass, object SearchDistance)
		{
			this.SourceFeatures = SourceFeatures;
			this.TargetFeatures = TargetFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.SearchDistance = SearchDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Rubbersheet Links</para>
		/// </summary>
		public override string DisplayName() => "Generate Rubbersheet Links";

		/// <summary>
		/// <para>Tool Name : GenerateRubbersheetLinks</para>
		/// </summary>
		public override string ToolName() => "GenerateRubbersheetLinks";

		/// <summary>
		/// <para>Tool Excute Name : edit.GenerateRubbersheetLinks</para>
		/// </summary>
		public override string ExcuteName() => "edit.GenerateRubbersheetLinks";

		/// <summary>
		/// <para>Toolbox Display Name : Editing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Editing Tools";

		/// <summary>
		/// <para>Toolbox Alise : edit</para>
		/// </summary>
		public override string ToolboxAlise() => "edit";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { SourceFeatures, TargetFeatures, OutFeatureClass, SearchDistance, MatchFields, OutMatchTable, OutPointFeatureClass };

		/// <summary>
		/// <para>Source Features</para>
		/// <para>Line features as source features for generating rubbersheet links. All links start at source features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object SourceFeatures { get; set; }

		/// <summary>
		/// <para>Target Features</para>
		/// <para>Line features as target features for generating rubbersheet links. All links end at matched target features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object TargetFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>Output feature class containing lines representing regular rubbersheet links.</para>
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
		/// <para>Lists of fields from source and target features. If specified, each pair of fields are checked for match candidates to help determine the right match.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "Blob", "Raster", "XML", "GUID", "OID")]
		[ExcludeField("SHAPE_Length", "SHAPE_Area")]
		public object MatchFields { get; set; }

		/// <summary>
		/// <para>Output Match Table</para>
		/// <para>The output table containing complete feature matching information.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object OutMatchTable { get; set; }

		/// <summary>
		/// <para>Identity Links</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutPointFeatureClass { get; set; } = "output_feature_class_Pnt";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateRubbersheetLinks SetEnviroment(object extent = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
