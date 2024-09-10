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
	/// <para>Migrate Relationship Class</para>
	/// <para>Migrates an ObjectID-based relationship class to a GlobalID-based relationship class.</para>
	/// </summary>
	public class MigrateRelationshipClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRelationshipClass">
		/// <para>Input Relationship Class</para>
		/// <para>ObjectID-based relationship class that will be migrated to a GlobalID-based relationship class. The origin and destination feature classes or tables must already have GlobalIDs.</para>
		/// </param>
		public MigrateRelationshipClass(object InRelationshipClass)
		{
			this.InRelationshipClass = InRelationshipClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Migrate Relationship Class</para>
		/// </summary>
		public override string DisplayName() => "Migrate Relationship Class";

		/// <summary>
		/// <para>Tool Name : MigrateRelationshipClass</para>
		/// </summary>
		public override string ToolName() => "MigrateRelationshipClass";

		/// <summary>
		/// <para>Tool Excute Name : management.MigrateRelationshipClass</para>
		/// </summary>
		public override string ExcuteName() => "management.MigrateRelationshipClass";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRelationshipClass, OutRelationshipClass };

		/// <summary>
		/// <para>Input Relationship Class</para>
		/// <para>ObjectID-based relationship class that will be migrated to a GlobalID-based relationship class. The origin and destination feature classes or tables must already have GlobalIDs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERelationshipClass()]
		public object InRelationshipClass { get; set; }

		/// <summary>
		/// <para>Migrated Relationship Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERelationshipClass()]
		public object OutRelationshipClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MigrateRelationshipClass SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
