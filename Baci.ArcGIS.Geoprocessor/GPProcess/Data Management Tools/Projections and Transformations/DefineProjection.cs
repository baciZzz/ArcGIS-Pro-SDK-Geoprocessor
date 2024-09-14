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
	/// <para>Define Projection</para>
	/// <para>Define Projection</para>
	/// <para>Overwrites the coordinate system information (map projection and datum) stored with a dataset. This tool is intended for datasets that have an unknown or incorrect coordinate system defined.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class DefineProjection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset or Feature Class</para>
		/// <para>The dataset or feature class whose projection is to be defined.</para>
		/// </param>
		/// <param name="CoorSystem">
		/// <para>Coordinate System</para>
		/// <para>The coordinate system to be applied to the input. The default value is set based on the Output Coordinate System environment setting.</para>
		/// </param>
		public DefineProjection(object InDataset, object CoorSystem)
		{
			this.InDataset = InDataset;
			this.CoorSystem = CoorSystem;
		}

		/// <summary>
		/// <para>Tool Display Name : Define Projection</para>
		/// </summary>
		public override string DisplayName() => "Define Projection";

		/// <summary>
		/// <para>Tool Name : DefineProjection</para>
		/// </summary>
		public override string ToolName() => "DefineProjection";

		/// <summary>
		/// <para>Tool Excute Name : management.DefineProjection</para>
		/// </summary>
		public override string ExcuteName() => "management.DefineProjection";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, CoorSystem, OutDataset };

		/// <summary>
		/// <para>Input Dataset or Feature Class</para>
		/// <para>The dataset or feature class whose projection is to be defined.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>The coordinate system to be applied to the input. The default value is set based on the Output Coordinate System environment setting.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCoordinateSystem()]
		public object CoorSystem { get; set; }

		/// <summary>
		/// <para>Update Input Dataset or Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DefineProjection SetEnviroment(object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
