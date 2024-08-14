using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Copy Extended Properties</para>
	/// <para>Copies extended property values from one job to another job in the same Workflow Manager (Classic) repository.</para>
	/// </summary>
	public class CopyExtendedProperties : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="SourceJobId">
		/// <para>Source Job ID</para>
		/// <para>The Job ID of the Workflow Manager (Classic) job that contains the properties to copy.</para>
		/// </param>
		/// <param name="TargetJobId">
		/// <para>Target Job ID</para>
		/// <para>The Job ID of the target job that will have its properties updated.</para>
		/// </param>
		/// <param name="PropertyTableName">
		/// <para>Properties Table Name</para>
		/// <para>The name of the extended properties table that will be updated.</para>
		/// </param>
		/// <param name="PropertyFields">
		/// <para>Property Fields</para>
		/// <para>The properties to be copied from the source job to the target job.</para>
		/// </param>
		public CopyExtendedProperties(object SourceJobId, object TargetJobId, object PropertyTableName, object PropertyFields)
		{
			this.SourceJobId = SourceJobId;
			this.TargetJobId = TargetJobId;
			this.PropertyTableName = PropertyTableName;
			this.PropertyFields = PropertyFields;
		}

		/// <summary>
		/// <para>Tool Display Name : Copy Extended Properties</para>
		/// </summary>
		public override string DisplayName => "Copy Extended Properties";

		/// <summary>
		/// <para>Tool Name : CopyExtendedProperties</para>
		/// </summary>
		public override string ToolName => "CopyExtendedProperties";

		/// <summary>
		/// <para>Tool Excute Name : topographic.CopyExtendedProperties</para>
		/// </summary>
		public override string ExcuteName => "topographic.CopyExtendedProperties";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { SourceJobId, TargetJobId, PropertyTableName, PropertyFields, DatabasePath, UpdatedJobId };

		/// <summary>
		/// <para>Source Job ID</para>
		/// <para>The Job ID of the Workflow Manager (Classic) job that contains the properties to copy.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object SourceJobId { get; set; }

		/// <summary>
		/// <para>Target Job ID</para>
		/// <para>The Job ID of the target job that will have its properties updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object TargetJobId { get; set; }

		/// <summary>
		/// <para>Properties Table Name</para>
		/// <para>The name of the extended properties table that will be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object PropertyTableName { get; set; }

		/// <summary>
		/// <para>Property Fields</para>
		/// <para>The properties to be copied from the source job to the target job.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object PropertyFields { get; set; }

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>The Workflow Manager (Classic) database connection file (.jtc) that contains the job information. If no connection file is specified, the current default Workflow Manager (Classic) database will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object DatabasePath { get; set; }

		/// <summary>
		/// <para>Updated Job ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object UpdatedJobId { get; set; } = "-1";

	}
}
