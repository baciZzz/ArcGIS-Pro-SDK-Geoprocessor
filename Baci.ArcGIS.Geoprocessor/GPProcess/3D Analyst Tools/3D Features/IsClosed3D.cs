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
	/// <para>Is Closed 3D</para>
	/// <para>Is Closed 3D</para>
	/// <para>Evaluates multipatch features to determine whether each feature completely encloses a volume of space.</para>
	/// </summary>
	public class IsClosed3D : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>Input Multipatch Features</para>
		/// <para>The multipatch features to be tested.</para>
		/// </param>
		public IsClosed3D(object InFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Is Closed 3D</para>
		/// </summary>
		public override string DisplayName() => "Is Closed 3D";

		/// <summary>
		/// <para>Tool Name : IsClosed3D</para>
		/// </summary>
		public override string ToolName() => "IsClosed3D";

		/// <summary>
		/// <para>Tool Excute Name : 3d.IsClosed3D</para>
		/// </summary>
		public override string ExcuteName() => "3d.IsClosed3D";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureClass, OutputFeatureClass };

		/// <summary>
		/// <para>Input Multipatch Features</para>
		/// <para>The multipatch features to be tested.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Updated Input Multipatch Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public IsClosed3D SetEnviroment(object extent = null, object workspace = null)
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

	}
}
