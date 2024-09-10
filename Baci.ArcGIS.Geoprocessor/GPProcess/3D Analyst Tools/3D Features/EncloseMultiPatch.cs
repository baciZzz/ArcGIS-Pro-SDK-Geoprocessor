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
	/// <para>Enclose Multipatch</para>
	/// <para>Creates  closed multipatch features from open multipatch features.</para>
	/// </summary>
	public class EncloseMultiPatch : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Multipatch Features</para>
		/// <para>The multipatch features that will be used to construct closed multipatches.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Multipatch Feature Class</para>
		/// <para>The output closed multipatch features.</para>
		/// </param>
		public EncloseMultiPatch(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Enclose Multipatch</para>
		/// </summary>
		public override string DisplayName() => "Enclose Multipatch";

		/// <summary>
		/// <para>Tool Name : EncloseMultiPatch</para>
		/// </summary>
		public override string ToolName() => "EncloseMultiPatch";

		/// <summary>
		/// <para>Tool Excute Name : 3d.EncloseMultiPatch</para>
		/// </summary>
		public override string ExcuteName() => "3d.EncloseMultiPatch";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "ZDomain", "ZResolution", "autoCommit", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, GridSize };

		/// <summary>
		/// <para>Input Multipatch Features</para>
		/// <para>The multipatch features that will be used to construct closed multipatches.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Multipatch Feature Class</para>
		/// <para>The output closed multipatch features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Grid Size</para>
		/// <para>The resolution that will be used to construct the closed multipatch features. This value is defined using the linear units of the input feature's spatial reference.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object GridSize { get; set; } = "0.15";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EncloseMultiPatch SetEnviroment(object XYDomain = null , object XYResolution = null , object ZDomain = null , object ZResolution = null , int? autoCommit = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, ZDomain: ZDomain, ZResolution: ZResolution, autoCommit: autoCommit, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

	}
}
