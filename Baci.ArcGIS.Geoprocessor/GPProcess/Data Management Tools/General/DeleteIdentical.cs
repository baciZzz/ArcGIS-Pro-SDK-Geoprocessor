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
	/// <para>Delete Identical</para>
	/// <para>Deletes records in a feature class or table which have identical values in a list of fields. If the geometry field is selected, feature geometries are compared.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class DeleteIdentical : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>The table or feature class that will have its identical records deleted.</para>
		/// </param>
		/// <param name="Fields">
		/// <para>Field(s)</para>
		/// <para>The field or fields whose values will be compared to find identical records.</para>
		/// </param>
		public DeleteIdentical(object InDataset, object Fields)
		{
			this.InDataset = InDataset;
			this.Fields = Fields;
		}

		/// <summary>
		/// <para>Tool Display Name : Delete Identical</para>
		/// </summary>
		public override string DisplayName() => "Delete Identical";

		/// <summary>
		/// <para>Tool Name : DeleteIdentical</para>
		/// </summary>
		public override string ToolName() => "DeleteIdentical";

		/// <summary>
		/// <para>Tool Excute Name : management.DeleteIdentical</para>
		/// </summary>
		public override string ExcuteName() => "management.DeleteIdentical";

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
		public override string[] ValidEnvironments() => new string[] { "XYTolerance", "ZTolerance", "extent", "maintainSpatialIndex", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, Fields, XyTolerance, ZTolerance, OutDataset };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>The table or feature class that will have its identical records deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Field(s)</para>
		/// <para>The field or fields whose values will be compared to find identical records.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "Geometry", "GUID")]
		public object Fields { get; set; }

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>The xy tolerance that will be applied to each vertex when evaluating if there is an identical vertex in another feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object XyTolerance { get; set; }

		/// <summary>
		/// <para>Z Tolerance</para>
		/// <para>The z tolerance that will be applied to each vertex when evaluating if there is an identical vertex in another feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ZTolerance { get; set; } = "0";

		/// <summary>
		/// <para>Updated Input Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object OutDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeleteIdentical SetEnviroment(object XYTolerance = null , object ZTolerance = null , object extent = null , bool? maintainSpatialIndex = null , object workspace = null )
		{
			base.SetEnv(XYTolerance: XYTolerance, ZTolerance: ZTolerance, extent: extent, maintainSpatialIndex: maintainSpatialIndex, workspace: workspace);
			return this;
		}

	}
}
