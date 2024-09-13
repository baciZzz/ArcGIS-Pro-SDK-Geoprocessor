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
	/// <para>迁移关系类</para>
	/// <para>将基于 ObjectID 的关系类迁移到基于 GlobalID 的关系类。</para>
	/// </summary>
	public class MigrateRelationshipClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRelationshipClass">
		/// <para>Input Relationship Class</para>
		/// <para>基于 ObjectID 的关系类，将被迁移至基于 GlobalID 的关系类。源要素类和目标要素类或表必须已经具有 GlobalID。</para>
		/// </param>
		public MigrateRelationshipClass(object InRelationshipClass)
		{
			this.InRelationshipClass = InRelationshipClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 迁移关系类</para>
		/// </summary>
		public override string DisplayName() => "迁移关系类";

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
		/// <para>基于 ObjectID 的关系类，将被迁移至基于 GlobalID 的关系类。源要素类和目标要素类或表必须已经具有 GlobalID。</para>
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
