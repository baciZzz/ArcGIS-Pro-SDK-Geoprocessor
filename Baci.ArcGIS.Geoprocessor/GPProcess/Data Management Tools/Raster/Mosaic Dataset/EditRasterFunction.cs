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
	/// <para>Edit Raster Function</para>
	/// <para>Edit Raster Function</para>
	/// <para>Adds, replaces, or removes a function chain in a mosaic dataset or a raster layer that contains a raster function.</para>
	/// </summary>
	public class EditRasterFunction : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input Raster</para>
		/// <para>The mosaic dataset or a raster layer. If you use a raster layer, it must have a function applied.</para>
		/// </param>
		public EditRasterFunction(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Edit Raster Function</para>
		/// </summary>
		public override string DisplayName() => "Edit Raster Function";

		/// <summary>
		/// <para>Tool Name : EditRasterFunction</para>
		/// </summary>
		public override string ToolName() => "EditRasterFunction";

		/// <summary>
		/// <para>Tool Excute Name : management.EditRasterFunction</para>
		/// </summary>
		public override string ExcuteName() => "management.EditRasterFunction";

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
		public override object[] Parameters() => new object[] { InMosaicDataset, EditMosaicDatasetItem!, EditOptions!, FunctionChainDefinition!, LocationFunctionName!, OutRaster! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The mosaic dataset or a raster layer. If you use a raster layer, it must have a function applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Mosaic Dataset Items</para>
		/// <para>Applies the function chain to every item in the mosaic dataset individually or to the mosaic dataset as a whole.</para>
		/// <para>Unchecked—Edits affect the functions associated with the mosaic dataset. This is the default.</para>
		/// <para>Checked—Edits affect the functions associated with all of the items within the mosaic dataset.</para>
		/// <para><see cref="EditMosaicDatasetItemEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? EditMosaicDatasetItem { get; set; } = "false";

		/// <summary>
		/// <para>Edit Options</para>
		/// <para>Insert, replace, or remove a function chain.</para>
		/// <para>Insert—Insert the function chain above the Function Name of the existing chain. Specify the function chain below in the Function Name parameter. This is the default.</para>
		/// <para>Replace—Replace the existing function chain with the function chain specified in this tool. Specify the function chain below in the Function Name parameter.</para>
		/// <para>Remove— Remove the function chain starting from the function specified in the Function Name parameter.</para>
		/// <para><see cref="EditOptionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? EditOptions { get; set; } = "INSERT";

		/// <summary>
		/// <para>Raster Function Template</para>
		/// <para>Choose the function chain (rft.xml file) that you want to insert or replace.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("rft.xml", "rft.json", "rft", "xml", "json")]
		public object? FunctionChainDefinition { get; set; }

		/// <summary>
		/// <para>Function Name</para>
		/// <para>Choose where to insert, replace, or remove the function chain within the existing function chain.</para>
		/// <para>If you Insert the function, it will be inserted above the function specified in the Function Name parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? LocationFunctionName { get; set; }

		/// <summary>
		/// <para>Updated Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EditRasterFunction SetEnviroment(object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Mosaic Dataset Items</para>
		/// </summary>
		public enum EditMosaicDatasetItemEnum 
		{
			/// <summary>
			/// <para>Checked—Edits affect the functions associated with all of the items within the mosaic dataset.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EDIT_MOSAIC_DATASET_ITEM")]
			EDIT_MOSAIC_DATASET_ITEM,

			/// <summary>
			/// <para>Unchecked—Edits affect the functions associated with the mosaic dataset. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EDIT_MOSAIC_DATASET")]
			EDIT_MOSAIC_DATASET,

		}

		/// <summary>
		/// <para>Edit Options</para>
		/// </summary>
		public enum EditOptionsEnum 
		{
			/// <summary>
			/// <para>Insert, replace, or remove a function chain.</para>
			/// </summary>
			[GPValue("INSERT")]
			[Description("Insert")]
			Insert,

			/// <summary>
			/// <para>Replace—Replace the existing function chain with the function chain specified in this tool. Specify the function chain below in the Function Name parameter.</para>
			/// </summary>
			[GPValue("REPLACE")]
			[Description("Replace")]
			Replace,

			/// <summary>
			/// <para>Remove— Remove the function chain starting from the function specified in the Function Name parameter.</para>
			/// </summary>
			[GPValue("REMOVE")]
			[Description("Remove")]
			Remove,

		}

#endregion
	}
}
