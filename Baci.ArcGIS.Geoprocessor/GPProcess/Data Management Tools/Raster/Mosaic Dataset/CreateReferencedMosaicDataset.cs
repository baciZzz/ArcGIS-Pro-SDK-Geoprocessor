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
	/// <para>Create Referenced Mosaic Dataset</para>
	/// <para>创建引用镶嵌数据集</para>
	/// <para>根据现有镶嵌数据集中的项目创建单个镶嵌数据集。</para>
	/// </summary>
	public class CreateReferencedMosaicDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>将从中选择项目的镶嵌数据集。</para>
		/// </param>
		/// <param name="OutMosaicDataset">
		/// <para>Output Mosaic Dataset</para>
		/// <para>要创建的引用镶嵌数据集。</para>
		/// </param>
		public CreateReferencedMosaicDataset(object InDataset, object OutMosaicDataset)
		{
			this.InDataset = InDataset;
			this.OutMosaicDataset = OutMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建引用镶嵌数据集</para>
		/// </summary>
		public override string DisplayName() => "创建引用镶嵌数据集";

		/// <summary>
		/// <para>Tool Name : CreateReferencedMosaicDataset</para>
		/// </summary>
		public override string ToolName() => "CreateReferencedMosaicDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateReferencedMosaicDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateReferencedMosaicDataset";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, OutMosaicDataset, CoordinateSystem!, NumberOfBands!, PixelType!, WhereClause!, InTemplateDataset!, Extent!, SelectUsingFeatures!, LodField!, MinpsField!, MaxpsField!, Pixelsize!, BuildBoundary! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>将从中选择项目的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Mosaic Dataset</para>
		/// <para>要创建的引用镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEMosaicDataset()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>输出镶嵌数据集的投影。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object? CoordinateSystem { get; set; }

		/// <summary>
		/// <para>Number of Bands</para>
		/// <para>引用镶嵌数据集中将具有的波段数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Pixel Properties")]
		public object? NumberOfBands { get; set; }

		/// <summary>
		/// <para>Pixel Type</para>
		/// <para>镶嵌数据集的位深度或辐射分辨率。如果未定义，此值将从第一个栅格数据集获取。</para>
		/// <para>1 位—像素类型为 1 位无符号整数。 值可以为 0 或 1。</para>
		/// <para>2 位—像素类型为 2 位无符号整数。 受支持的值范围为 0 到 3。</para>
		/// <para>4 位—像素类型为 4 位无符号整数。 受支持的值范围为 0 到 15。</para>
		/// <para>8 位无符号—像素类型为 8 位无符号数据类型。 受支持的值范围为 0 到 255。</para>
		/// <para>8 位有符号—像素类型为 8 位有符号数据类型。 受支持的值范围为 -128 到 127。</para>
		/// <para>16 位无符号—像素类型为 16 位无符号数据类型。 取值范围为 0 到 65,535。</para>
		/// <para>16 位有符号—像素类型为 16 位有符号数据类型。 取值范围为 -32,768 到 32,767。</para>
		/// <para>32 位无符号—像素类型为 32 位无符号数据类型。 取值范围为 0 到 4,294,967,295。</para>
		/// <para>32 位有符号—像素类型为 32 位有符号数据类型。 取值范围为 -2,147,483,648 到 2,147,483,647。</para>
		/// <para>32 位浮点型—像素类型为支持小数的 32 位数据类型。</para>
		/// <para>64 位—像素类型为支持小数的 64 位数据类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Pixel Properties")]
		public object? PixelType { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>SQL 表达式将选择包含在输出镶嵌数据集中的栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		[Category("Selection")]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Extent from Dataset</para>
		/// <para>将根据其他图像或要素类范围选择栅格数据集。位于已定义范围边缘的栅格数据集将被包含到镶嵌数据集中。要为该范围手动输入最小坐标和最大坐标，请使用范围参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[Category("Selection")]
		public object? InTemplateDataset { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>针对该范围的最小坐标和最大坐标。如果选中了由数据集确定范围中的数据集，此处将自动显示上述坐标。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEnvelope()]
		[Category("Selection")]
		public object? Extent { get; set; }

		/// <summary>
		/// <para>Using Input Geometry for Selection</para>
		/// <para>选中由数据集确定范围参数中的要素类时，将范围限制为形状或包络矩形。</para>
		/// <para>选中 - 基于要素形状进行选择。这是默认设置。</para>
		/// <para>取消选中 - 基于要素类的范围进行选择。</para>
		/// <para><see cref="SelectUsingFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Selection")]
		public object? SelectUsingFeatures { get; set; } = "true";

		/// <summary>
		/// <para>Scale Field</para>
		/// <para>此参数已弃用，将在工具执行中忽略该参数。此参数因向后兼容性原因而被保留。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		[Category("Visibility")]
		public object? LodField { get; set; }

		/// <summary>
		/// <para>Minimum Cell Size Field</para>
		/// <para>指定覆盖区属性表中的字段，用于定义显示镶嵌数据集的最小像元大小；否则将仅显示覆盖区。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		[Category("Visibility")]
		public object? MinpsField { get; set; }

		/// <summary>
		/// <para>Maximum Cell Size Field</para>
		/// <para>指定覆盖区属性表中的字段，用于定义显示镶嵌数据集的最大像元大小；否则将仅显示覆盖区。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		[Category("Visibility")]
		public object? MaxpsField { get; set; }

		/// <summary>
		/// <para>Maximum Visible Cell Size</para>
		/// <para>设置最大像元大小以显示镶嵌，无需指定字段。如果缩小程度超过该像元大小，则将仅显示覆盖区。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Visibility")]
		public object? Pixelsize { get; set; }

		/// <summary>
		/// <para>Build Boundary</para>
		/// <para>重新构建边界。如果选择覆盖的面积小于源镶嵌数据集的面积，则建议采用此方法。</para>
		/// <para>只有在地理数据库中创建镶嵌数据集时才可用。</para>
		/// <para>选中 - 生成边界。这是默认设置。</para>
		/// <para>未选中 - 不生成边界。</para>
		/// <para><see cref="BuildBoundaryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? BuildBoundary { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateReferencedMosaicDataset SetEnviroment(object? configKeyword = null , object? extent = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Using Input Geometry for Selection</para>
		/// </summary>
		public enum SelectUsingFeaturesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SELECT_USING_FEATURES")]
			SELECT_USING_FEATURES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SELECT_USING_FEATURES")]
			NO_SELECT_USING_FEATURES,

		}

		/// <summary>
		/// <para>Build Boundary</para>
		/// </summary>
		public enum BuildBoundaryEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD_BOUNDARY")]
			BUILD_BOUNDARY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_BOUNDARY")]
			NO_BOUNDARY,

		}

#endregion
	}
}
