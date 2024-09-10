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
	/// <para>CopyMultiple</para>
	/// <para>Copies multiple datasets or tables.</para>
	/// </summary>
	[Obsolete()]
	public class CopyMultiple : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input Data</para>
		/// </param>
		/// <param name="OutPath">
		/// <para>Output Location</para>
		/// </param>
		/// <param name="OutDataName">
		/// <para>Output Base Name</para>
		/// </param>
		public CopyMultiple(object InData, object OutPath, object OutDataName)
		{
			this.InData = InData;
			this.OutPath = OutPath;
			this.OutDataName = OutDataName;
		}

		/// <summary>
		/// <para>Tool Display Name : CopyMultiple</para>
		/// </summary>
		public override string DisplayName() => "CopyMultiple";

		/// <summary>
		/// <para>Tool Name : CopyMultiple</para>
		/// </summary>
		public override string ToolName() => "CopyMultiple";

		/// <summary>
		/// <para>Tool Excute Name : management.CopyMultiple</para>
		/// </summary>
		public override string ExcuteName() => "management.CopyMultiple";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InData, OutPath, OutDataName, AssociatedData, OutData };

		/// <summary>
		/// <para>Input Data</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutPath { get; set; }

		/// <summary>
		/// <para>Output Base Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object OutDataName { get; set; }

		/// <summary>
		/// <para>Secondary Target Names</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object AssociatedData { get; set; }

		/// <summary>
		/// <para>Output Data</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutData { get; set; }

	}
}
