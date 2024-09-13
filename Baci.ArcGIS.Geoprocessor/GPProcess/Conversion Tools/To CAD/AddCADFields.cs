using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>Add CAD Fields</para>
	/// <para>添加 CAD 字段</para>
	/// <para>一步添加多个保留的 CAD 字段。 要素转 CAD 工具使用此工具创建的字段生成具有特定属性的 CAD 实体。 执行此工具后，必须计算或键入合适的字段值。</para>
	/// </summary>
	public class AddCADFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputTable">
		/// <para>Input Table</para>
		/// <para>将添加特定于 CAD 的字段的输入表、要素类或 shapefile。</para>
		/// </param>
		/// <param name="Entities">
		/// <para>Entity Properties</para>
		/// <para>将特定于 CAD 的“实体”属性字段的列表添加到输入表</para>
		/// <para>选中 - 将特定于 CAD 的“实体”属性字段的列表添加到输入表。 这是默认设置。</para>
		/// <para>取消选中 - 特定于 CAD 的“实体”属性字段的列表不会添加到输入表</para>
		/// <para><see cref="EntitiesEnum"/></para>
		/// </param>
		public AddCADFields(object InputTable, object Entities)
		{
			this.InputTable = InputTable;
			this.Entities = Entities;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加 CAD 字段</para>
		/// </summary>
		public override string DisplayName() => "添加 CAD 字段";

		/// <summary>
		/// <para>Tool Name : AddCADFields</para>
		/// </summary>
		public override string ToolName() => "AddCADFields";

		/// <summary>
		/// <para>Tool Excute Name : conversion.AddCADFields</para>
		/// </summary>
		public override string ExcuteName() => "conversion.AddCADFields";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputTable, Entities, Layerprops!, Textprops!, Docprops!, Xdataprops!, OutTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>将添加特定于 CAD 的字段的输入表、要素类或 shapefile。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputTable { get; set; }

		/// <summary>
		/// <para>Entity Properties</para>
		/// <para>将特定于 CAD 的“实体”属性字段的列表添加到输入表</para>
		/// <para>选中 - 将特定于 CAD 的“实体”属性字段的列表添加到输入表。 这是默认设置。</para>
		/// <para>取消选中 - 特定于 CAD 的“实体”属性字段的列表不会添加到输入表</para>
		/// <para><see cref="EntitiesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Entities { get; set; } = "true";

		/// <summary>
		/// <para>Layer Properties</para>
		/// <para>将特定于 CAD 的“图层”属性字段的列表添加到输入表</para>
		/// <para>选中 - 将特定于 CAD 的“图层”属性字段的列表添加到输入表。 这是默认设置。</para>
		/// <para>取消选中 - 特定于 CAD 的“图层”属性字段的列表不会添加到输入表</para>
		/// <para><see cref="LayerpropsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Layerprops { get; set; } = "true";

		/// <summary>
		/// <para>Text Properties</para>
		/// <para>将特定于 CAD 的“文本”属性字段的列表添加到输入表</para>
		/// <para>选中 - 将特定于 CAD 的“文本”属性字段的列表添加到输入表。 这是默认设置。</para>
		/// <para>取消选中 - 特定于 CAD 的“文本”属性字段的列表不会添加到输入表。</para>
		/// <para><see cref="TextpropsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Textprops { get; set; } = "true";

		/// <summary>
		/// <para>Document Properties</para>
		/// <para>将特定于 CAD 的“文档”属性字段的列表添加到输入表</para>
		/// <para>选中 - 将特定于 CAD 的“文档”属性字段的列表添加到输入表。 这是默认设置。</para>
		/// <para>取消选中 - 特定于 CAD 的“文档”属性字段的列表不会添加到输入表。</para>
		/// <para><see cref="DocpropsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Docprops { get; set; } = "true";

		/// <summary>
		/// <para>Add CAD XData Property Fields</para>
		/// <para>将特定于 CAD 的 XData 属性字段的列表添加到输入表</para>
		/// <para>选中 - 将特定于 CAD 的 XData 属性字段的列表添加到输入表。 这是默认设置。</para>
		/// <para>取消选中 - 特定于 CAD 的 XData 属性字段的列表不会添加到输入表。</para>
		/// <para><see cref="XdatapropsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Xdataprops { get; set; } = "true";

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddCADFields SetEnviroment(object? extent = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Entity Properties</para>
		/// </summary>
		public enum EntitiesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_ENTITY_PROPERTIES")]
			ADD_ENTITY_PROPERTIES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ENTITY_PROPERTIES")]
			NO_ENTITY_PROPERTIES,

		}

		/// <summary>
		/// <para>Layer Properties</para>
		/// </summary>
		public enum LayerpropsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_LAYER_PROPERTIES")]
			ADD_LAYER_PROPERTIES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_LAYER_PROPERTIES")]
			NO_LAYER_PROPERTIES,

		}

		/// <summary>
		/// <para>Text Properties</para>
		/// </summary>
		public enum TextpropsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_TEXT_PROPERTIES")]
			ADD_TEXT_PROPERTIES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_TEXT_PROPERTIES")]
			NO_TEXT_PROPERTIES,

		}

		/// <summary>
		/// <para>Document Properties</para>
		/// </summary>
		public enum DocpropsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_DOCUMENT_PROPERTIES")]
			ADD_DOCUMENT_PROPERTIES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DOCUMENT_PROPERTIES")]
			NO_DOCUMENT_PROPERTIES,

		}

		/// <summary>
		/// <para>Add CAD XData Property Fields</para>
		/// </summary>
		public enum XdatapropsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_XDATA_PROPERTIES")]
			ADD_XDATA_PROPERTIES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_XDATA_PROPERTIES")]
			NO_XDATA_PROPERTIES,

		}

#endregion
	}
}
