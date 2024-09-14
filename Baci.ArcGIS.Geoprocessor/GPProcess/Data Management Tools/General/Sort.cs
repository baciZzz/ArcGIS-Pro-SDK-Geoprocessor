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
	/// <para>排序</para>
	/// <para>根据一个或多个字段值对要素类或表中的记录按升序或降序进行重新排序。重新排序的结果将被写入到新数据集中。</para>
	/// </summary>
	public class Sort : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>要根据一个或多个排序字段中的字段值对记录进行重新排序的输入数据集。</para>
		/// </param>
		/// <param name="OutDataset">
		/// <para>Output Dataset</para>
		/// <para>输出要素类或表。</para>
		/// </param>
		/// <param name="SortField">
		/// <para>Field(s)</para>
		/// <para>指定包含对输入记录重新排序所用的值的一个或多个字段，以及记录的排序方向。</para>
		/// <para>按 Shape 字段排序或按多个字段排序仅在具有 Desktop Advanced 许可时适用。按任何单个属性字段（不包括 Shape 字段）排序在所有级别许可下都适用。</para>
		/// <para>升序 - 按照值从低到高的顺序对记录进行排序。</para>
		/// <para>降序 - 按照值从高到低的顺序对记录进行排序。</para>
		/// </param>
		public Sort(object InDataset, object OutDataset, object SortField)
		{
			this.InDataset = InDataset;
			this.OutDataset = OutDataset;
			this.SortField = SortField;
		}

		/// <summary>
		/// <para>Tool Display Name : 排序</para>
		/// </summary>
		public override string DisplayName() => "排序";

		/// <summary>
		/// <para>Tool Name : 排序</para>
		/// </summary>
		public override string ToolName() => "排序";

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
		public override object[] Parameters() => new object[] { InDataset, OutDataset, SortField, SpatialSortMethod };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>要根据一个或多个排序字段中的字段值对记录进行重新排序的输入数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// <para>输出要素类或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutDataset { get; set; }

		/// <summary>
		/// <para>Field(s)</para>
		/// <para>指定包含对输入记录重新排序所用的值的一个或多个字段，以及记录的排序方向。</para>
		/// <para>按 Shape 字段排序或按多个字段排序仅在具有 Desktop Advanced 许可时适用。按任何单个属性字段（不包括 Shape 字段）排序在所有级别许可下都适用。</para>
		/// <para>升序 - 按照值从低到高的顺序对记录进行排序。</para>
		/// <para>降序 - 按照值从高到低的顺序对记录进行排序。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object SortField { get; set; }

		/// <summary>
		/// <para>Spatial Sort Method</para>
		/// <para>指定对要素进行空间排序的方法。仅当将 Shape 字段作为排序字段之一时，排序方法才可用。</para>
		/// <para>右上角—从右上角开始排序。这是默认设置。</para>
		/// <para>左上角—从左上角开始排序。</para>
		/// <para>右下角—从右下角开始排序。</para>
		/// <para>左下角—从左下角开始排序。</para>
		/// <para>皮亚诺曲线—使用空间填充曲线算法（也称为皮亚诺曲线）排序。</para>
		/// <para><see cref="SpatialSortMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SpatialSortMethod { get; set; } = "UR";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Sort SetEnviroment(object MDomain = null, object MResolution = null, object MTolerance = null, object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, bool? qualifiedFieldNames = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Spatial Sort Method</para>
		/// </summary>
		public enum SpatialSortMethodEnum 
		{
			/// <summary>
			/// <para>左上角—从左上角开始排序。</para>
			/// </summary>
			[GPValue("UL")]
			[Description("左上角")]
			Upper_left,

			/// <summary>
			/// <para>右上角—从右上角开始排序。这是默认设置。</para>
			/// </summary>
			[GPValue("UR")]
			[Description("右上角")]
			Upper_right,

			/// <summary>
			/// <para>左下角—从左下角开始排序。</para>
			/// </summary>
			[GPValue("LL")]
			[Description("左下角")]
			Lower_left,

			/// <summary>
			/// <para>右下角—从右下角开始排序。</para>
			/// </summary>
			[GPValue("LR")]
			[Description("右下角")]
			Lower_right,

			/// <summary>
			/// <para>皮亚诺曲线—使用空间填充曲线算法（也称为皮亚诺曲线）排序。</para>
			/// </summary>
			[GPValue("PEANO")]
			[Description("皮亚诺曲线")]
			Peano_curve,

		}

#endregion
	}
}
