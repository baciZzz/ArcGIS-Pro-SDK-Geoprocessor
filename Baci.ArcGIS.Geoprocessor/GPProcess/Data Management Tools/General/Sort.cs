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
	/// <para>Sort</para>
	/// <para>Sort</para>
	/// <para>Reorders records in a feature class or table, in ascending or descending order, based on one or multiple fields. The reordered result is written to a new dataset.</para>
	/// </summary>
	public class Sort : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>The input dataset whose records will be reordered based on the field values in the sort field or fields.</para>
		/// </param>
		/// <param name="OutDataset">
		/// <para>Output Dataset</para>
		/// <para>The output feature class or table.</para>
		/// </param>
		/// <param name="SortField">
		/// <para>Field(s)</para>
		/// <para>Specifies the field or fields whose values will be used to reorder the input records and the direction the records will be sorted.</para>
		/// <para>Sorting by the Shape field or by multiple fields is only available with an Desktop Advanced license. Sorting by any single attribute field (excluding Shape) is available at all license levels.</para>
		/// <para>Ascending—Records are sorted from low value to high value.</para>
		/// <para>Descending—Records are sorted from high value to low value.</para>
		/// </param>
		public Sort(object InDataset, object OutDataset, object SortField)
		{
			this.InDataset = InDataset;
			this.OutDataset = OutDataset;
			this.SortField = SortField;
		}

		/// <summary>
		/// <para>Tool Display Name : Sort</para>
		/// </summary>
		public override string DisplayName() => "Sort";

		/// <summary>
		/// <para>Tool Name : Sort</para>
		/// </summary>
		public override string ToolName() => "Sort";

		/// <summary>
		/// <para>Tool Excute Name : management.Sort</para>
		/// </summary>
		public override string ExcuteName() => "management.Sort";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "maintainAttachments", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "transferGDBAttributeProperties", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, OutDataset, SortField, SpatialSortMethod! };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>The input dataset whose records will be reordered based on the field values in the sort field or fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// <para>The output feature class or table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutDataset { get; set; }

		/// <summary>
		/// <para>Field(s)</para>
		/// <para>Specifies the field or fields whose values will be used to reorder the input records and the direction the records will be sorted.</para>
		/// <para>Sorting by the Shape field or by multiple fields is only available with an Desktop Advanced license. Sorting by any single attribute field (excluding Shape) is available at all license levels.</para>
		/// <para>Ascending—Records are sorted from low value to high value.</para>
		/// <para>Descending—Records are sorted from high value to low value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object SortField { get; set; }

		/// <summary>
		/// <para>Spatial Sort Method</para>
		/// <para>Specifies how features are spatially sorted. The sort method is only enabled when the Shape field is selected as one of the sort fields.</para>
		/// <para>Upper right—Sorting starts at the upper right corner. This is the default.</para>
		/// <para>Upper left—Sorting starts at the upper left corner.</para>
		/// <para>Lower right—Sorting starts at the lower right corner.</para>
		/// <para>Lower left—Sorting starts at the lower left corner.</para>
		/// <para>Peano curve—Sorting uses a space filling curve algorithm, also known as a Peano curve.</para>
		/// <para><see cref="SpatialSortMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SpatialSortMethod { get; set; } = "UR";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Sort SetEnviroment(object? MDomain = null, double? MResolution = null, double? MTolerance = null, object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, object? extent = null, object? geographicTransformations = null, bool? maintainAttachments = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null, bool? qualifiedFieldNames = null, object? scratchWorkspace = null, bool? transferGDBAttributeProperties = null, object? workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, maintainAttachments: maintainAttachments, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, transferGDBAttributeProperties: transferGDBAttributeProperties, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Spatial Sort Method</para>
		/// </summary>
		public enum SpatialSortMethodEnum 
		{
			/// <summary>
			/// <para>Upper left—Sorting starts at the upper left corner.</para>
			/// </summary>
			[GPValue("UL")]
			[Description("Upper left")]
			Upper_left,

			/// <summary>
			/// <para>Upper right—Sorting starts at the upper right corner. This is the default.</para>
			/// </summary>
			[GPValue("UR")]
			[Description("Upper right")]
			Upper_right,

			/// <summary>
			/// <para>Lower left—Sorting starts at the lower left corner.</para>
			/// </summary>
			[GPValue("LL")]
			[Description("Lower left")]
			Lower_left,

			/// <summary>
			/// <para>Lower right—Sorting starts at the lower right corner.</para>
			/// </summary>
			[GPValue("LR")]
			[Description("Lower right")]
			Lower_right,

			/// <summary>
			/// <para>Peano curve—Sorting uses a space filling curve algorithm, also known as a Peano curve.</para>
			/// </summary>
			[GPValue("PEANO")]
			[Description("Peano curve")]
			Peano_curve,

		}

#endregion
	}
}
