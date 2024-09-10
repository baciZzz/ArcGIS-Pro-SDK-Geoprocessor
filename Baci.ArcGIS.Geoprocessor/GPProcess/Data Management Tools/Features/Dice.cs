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
	/// <para>Dice</para>
	/// <para>Subdivides a feature into smaller features based on a specified vertex limit. This tool is intended as a way to subdivide extremely large features that cause issues with drawing, analysis, editing, and/or performance but are difficult to split up with standard editing and geoprocessing tools. This tool should not be used in any cases other than those where tools are failing to complete successfully due to the size of features.</para>
	/// </summary>
	public class Dice : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input feature class or feature layer. The geometry type must be multipoint, line, or polygon.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class of diced features.</para>
		/// </param>
		/// <param name="VertexLimit">
		/// <para>Vertex Limit</para>
		/// <para>Features with geometries that exceed this vertex limit will be subdivided before being written to the output feature class.</para>
		/// </param>
		public Dice(object InFeatures, object OutFeatureClass, object VertexLimit)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.VertexLimit = VertexLimit;
		}

		/// <summary>
		/// <para>Tool Display Name : Dice</para>
		/// </summary>
		public override string DisplayName() => "Dice";

		/// <summary>
		/// <para>Tool Name : Dice</para>
		/// </summary>
		public override string ToolName() => "Dice";

		/// <summary>
		/// <para>Tool Excute Name : management.Dice</para>
		/// </summary>
		public override string ExcuteName() => "management.Dice";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "configKeyword", "qualifiedFieldNames" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, VertexLimit };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input feature class or feature layer. The geometry type must be multipoint, line, or polygon.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline", "Multipoint")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class of diced features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Vertex Limit</para>
		/// <para>Features with geometries that exceed this vertex limit will be subdivided before being written to the output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object VertexLimit { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Dice SetEnviroment(int? autoCommit = null , object configKeyword = null , bool? qualifiedFieldNames = null )
		{
			base.SetEnv(autoCommit: autoCommit, configKeyword: configKeyword, qualifiedFieldNames: qualifiedFieldNames);
			return this;
		}

	}
}
