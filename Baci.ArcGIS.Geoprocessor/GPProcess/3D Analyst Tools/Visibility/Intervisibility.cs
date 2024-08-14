using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Intervisibility</para>
	/// <para>Determines the visibility of sight lines using  potential obstructions defined by any combination of  3D features and surfaces.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class Intervisibility : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="SightLines">
		/// <para>Sight Lines</para>
		/// <para>The 3D sight lines whose visibility will be evaluated.</para>
		/// </param>
		/// <param name="Obstructions">
		/// <para>Obstructions</para>
		/// <para>The 3D features, integrated mesh scene layers, and surfaces that provide potential obstructions for the sight lines.</para>
		/// </param>
		public Intervisibility(object SightLines, object Obstructions)
		{
			this.SightLines = SightLines;
			this.Obstructions = Obstructions;
		}

		/// <summary>
		/// <para>Tool Display Name : Intervisibility</para>
		/// </summary>
		public override string DisplayName => "Intervisibility";

		/// <summary>
		/// <para>Tool Name : Intervisibility</para>
		/// </summary>
		public override string ToolName => "Intervisibility";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Intervisibility</para>
		/// </summary>
		public override string ExcuteName => "3d.Intervisibility";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { SightLines, Obstructions, VisibleField!, OutFeatureClass! };

		/// <summary>
		/// <para>Sight Lines</para>
		/// <para>The 3D sight lines whose visibility will be evaluated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object SightLines { get; set; }

		/// <summary>
		/// <para>Obstructions</para>
		/// <para>The 3D features, integrated mesh scene layers, and surfaces that provide potential obstructions for the sight lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object Obstructions { get; set; }

		/// <summary>
		/// <para>Visible Field Name</para>
		/// <para>The name of the field that will store the visibility results. A resulting value of 0 indicates that the sight line's start and end points are not visible to one another. A value of 1 indicates that the sight line's start and end points are visible to one another. The default field name is VISIBLE. If the field already exists, its values will be overwritten.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? VisibleField { get; set; } = "VISIBLE";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Intervisibility SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

	}
}
