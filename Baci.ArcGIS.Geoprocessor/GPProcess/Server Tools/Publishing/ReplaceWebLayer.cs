using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ServerTools
{
	/// <summary>
	/// <para>Replace Web Layer</para>
	/// <para>Replaces the content of a web layer in a portal with the content of another web layer.</para>
	/// </summary>
	public class ReplaceWebLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetLayer">
		/// <para>Target Layer</para>
		/// <para>The web layer to be replaced. In addition to a layer or catalog path, it can also be specified using the item ID or service URL of one of the following:</para>
		/// <para>Vector tile</para>
		/// <para>Tile layer</para>
		/// <para>Scene layer published from one of the following sources:</para>
		/// <para>Scene layer package</para>
		/// <para>Referenced scene cache in folder or cloud data stores</para>
		/// </param>
		/// <param name="ArchiveLayerName">
		/// <para>Archive Layer Name</para>
		/// <para>The web layer that is replaced remains in the portal as an archive layer. Provide a unique name for the archive layer.</para>
		/// </param>
		/// <param name="UpdateLayer">
		/// <para>Update Layer</para>
		/// <para>The replacement web layer. In addition to a layer or catalog path, it can also be specified using the item ID or service URL of one of the following:</para>
		/// <para>Vector tile</para>
		/// <para>Tile layer</para>
		/// <para>Scene layer published from one of the following sources:</para>
		/// <para>Scene layer package</para>
		/// <para>Referenced scene cache in folder or cloud data stores</para>
		/// </param>
		public ReplaceWebLayer(object TargetLayer, object ArchiveLayerName, object UpdateLayer)
		{
			this.TargetLayer = TargetLayer;
			this.ArchiveLayerName = ArchiveLayerName;
			this.UpdateLayer = UpdateLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Replace Web Layer</para>
		/// </summary>
		public override string DisplayName => "Replace Web Layer";

		/// <summary>
		/// <para>Tool Name : ReplaceWebLayer</para>
		/// </summary>
		public override string ToolName => "ReplaceWebLayer";

		/// <summary>
		/// <para>Tool Excute Name : server.ReplaceWebLayer</para>
		/// </summary>
		public override string ExcuteName => "server.ReplaceWebLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : server</para>
		/// </summary>
		public override string ToolboxAlise => "server";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { TargetLayer, ArchiveLayerName, UpdateLayer, ReplaceItemInfo, UpdatedTargetLayer, CreateNewItem };

		/// <summary>
		/// <para>Target Layer</para>
		/// <para>The web layer to be replaced. In addition to a layer or catalog path, it can also be specified using the item ID or service URL of one of the following:</para>
		/// <para>Vector tile</para>
		/// <para>Tile layer</para>
		/// <para>Scene layer published from one of the following sources:</para>
		/// <para>Scene layer package</para>
		/// <para>Referenced scene cache in folder or cloud data stores</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object TargetLayer { get; set; }

		/// <summary>
		/// <para>Archive Layer Name</para>
		/// <para>The web layer that is replaced remains in the portal as an archive layer. Provide a unique name for the archive layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ArchiveLayerName { get; set; }

		/// <summary>
		/// <para>Update Layer</para>
		/// <para>The replacement web layer. In addition to a layer or catalog path, it can also be specified using the item ID or service URL of one of the following:</para>
		/// <para>Vector tile</para>
		/// <para>Tile layer</para>
		/// <para>Scene layer published from one of the following sources:</para>
		/// <para>Scene layer package</para>
		/// <para>Referenced scene cache in folder or cloud data stores</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object UpdateLayer { get; set; }

		/// <summary>
		/// <para>Replace Item Information</para>
		/// <para>Specifies whether the thumbnail image, summary, description, and tags will be replaced. In either case, the item&apos;s credits (attribution), terms of use, and created from information are not replaced.</para>
		/// <para>Unchecked—The target layer&apos;s item information is not replaced when the layer is updated. This is the default.</para>
		/// <para>Checked—The target layer&apos;s item information is replaced by the update layer&apos;s item information.</para>
		/// <para><see cref="ReplaceItemInfoEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ReplaceItemInfo { get; set; } = "false";

		/// <summary>
		/// <para>Updated Target Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object UpdatedTargetLayer { get; set; }

		/// <summary>
		/// <para>Create New Item For Archive Layer</para>
		/// <para>Specifies whether a new item is created for the archive layer. This option is supported on portals in ArcGIS Online and ArcGIS Enterprise 10.8 or later.</para>
		/// <para>Unchecked—The item ID of the update layer is used for the archive layer. This is the default for vector tile layers and tile layers.</para>
		/// <para>Checked—A new item ID is created for the archive layer. This is the default for scene layers.</para>
		/// <para><see cref="CreateNewItemEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CreateNewItem { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ReplaceWebLayer SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Replace Item Information</para>
		/// </summary>
		public enum ReplaceItemInfoEnum 
		{
			/// <summary>
			/// <para>Checked—The target layer&apos;s item information is replaced by the update layer&apos;s item information.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REPLACE")]
			REPLACE,

			/// <summary>
			/// <para>Unchecked—The target layer&apos;s item information is not replaced when the layer is updated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP")]
			KEEP,

		}

		/// <summary>
		/// <para>Create New Item For Archive Layer</para>
		/// </summary>
		public enum CreateNewItemEnum 
		{
			/// <summary>
			/// <para>Checked—A new item ID is created for the archive layer. This is the default for scene layers.</para>
			/// </summary>
			[GPValue("true")]
			[Description("TRUE")]
			TRUE,

			/// <summary>
			/// <para>Unchecked—The item ID of the update layer is used for the archive layer. This is the default for vector tile layers and tile layers.</para>
			/// </summary>
			[GPValue("false")]
			[Description("FALSE")]
			FALSE,

		}

#endregion
	}
}
