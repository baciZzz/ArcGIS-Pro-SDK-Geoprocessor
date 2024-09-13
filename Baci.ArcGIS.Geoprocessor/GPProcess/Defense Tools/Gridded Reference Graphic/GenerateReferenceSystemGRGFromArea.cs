using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DefenseTools
{
	/// <summary>
	/// <para>Generate Reference System Grid From Area</para>
	/// <para>根据区域生成参考系统格网</para>
	/// <para>基于军事格网参考系 (MGRS) 或美国国家格网 (USNG) 参考格网创建格网化参考图形 (GRG)。</para>
	/// </summary>
	public class GenerateReferenceSystemGRGFromArea : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Feature</para>
		/// <para>将基于 GRG 的输入面要素。</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含 GRG 的输出面要素类。</para>
		/// </param>
		/// <param name="GridReferenceSystem">
		/// <para>Grid Reference System</para>
		/// <para>指定 GRG 将使用的参考系统。</para>
		/// <para>军事格网参考系—将使用军事格网参考系。这是默认设置。</para>
		/// <para>美国国家格网—将使用美国国家格网。</para>
		/// <para><see cref="GridReferenceSystemEnum"/></para>
		/// </param>
		/// <param name="GridSquareSize">
		/// <para>Grid Square Size</para>
		/// <para>指定将用于 GRG 中像元的格网方格大小。</para>
		/// <para>格网区域指示符—格网像元的大小将为“格网区域”。这是默认设置。</para>
		/// <para>100,000 米格网—格网像元的大小将为 100,000 米的格网方格。</para>
		/// <para>10,000 米格网—格网像元的大小将为 10,000 米的格网方格。</para>
		/// <para>1,000 米格网—格网像元的大小将为 1,000 米的格网方格。</para>
		/// <para>100 米格网—格网像元的大小将为 100 米的格网方格。</para>
		/// <para>10 米格网—格网像元的大小将为 10 米的格网方格。</para>
		/// <para><see cref="GridSquareSizeEnum"/></para>
		/// </param>
		public GenerateReferenceSystemGRGFromArea(object InFeatures, object OutputFeatureClass, object GridReferenceSystem, object GridSquareSize)
		{
			this.InFeatures = InFeatures;
			this.OutputFeatureClass = OutputFeatureClass;
			this.GridReferenceSystem = GridReferenceSystem;
			this.GridSquareSize = GridSquareSize;
		}

		/// <summary>
		/// <para>Tool Display Name : 根据区域生成参考系统格网</para>
		/// </summary>
		public override string DisplayName() => "根据区域生成参考系统格网";

		/// <summary>
		/// <para>Tool Name : GenerateReferenceSystemGRGFromArea</para>
		/// </summary>
		public override string ToolName() => "GenerateReferenceSystemGRGFromArea";

		/// <summary>
		/// <para>Tool Excute Name : defense.GenerateReferenceSystemGRGFromArea</para>
		/// </summary>
		public override string ExcuteName() => "defense.GenerateReferenceSystemGRGFromArea";

		/// <summary>
		/// <para>Toolbox Display Name : Defense Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Defense Tools";

		/// <summary>
		/// <para>Toolbox Alise : defense</para>
		/// </summary>
		public override string ToolboxAlise() => "defense";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutputFeatureClass, GridReferenceSystem, GridSquareSize, LargeGridHandling };

		/// <summary>
		/// <para>Input Feature</para>
		/// <para>将基于 GRG 的输入面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含 GRG 的输出面要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Grid Reference System</para>
		/// <para>指定 GRG 将使用的参考系统。</para>
		/// <para>军事格网参考系—将使用军事格网参考系。这是默认设置。</para>
		/// <para>美国国家格网—将使用美国国家格网。</para>
		/// <para><see cref="GridReferenceSystemEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GridReferenceSystem { get; set; } = "MGRS";

		/// <summary>
		/// <para>Grid Square Size</para>
		/// <para>指定将用于 GRG 中像元的格网方格大小。</para>
		/// <para>格网区域指示符—格网像元的大小将为“格网区域”。这是默认设置。</para>
		/// <para>100,000 米格网—格网像元的大小将为 100,000 米的格网方格。</para>
		/// <para>10,000 米格网—格网像元的大小将为 10,000 米的格网方格。</para>
		/// <para>1,000 米格网—格网像元的大小将为 1,000 米的格网方格。</para>
		/// <para>100 米格网—格网像元的大小将为 100 米的格网方格。</para>
		/// <para>10 米格网—格网像元的大小将为 10 米的格网方格。</para>
		/// <para><see cref="GridSquareSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GridSquareSize { get; set; } = "GRID_ZONE_DESIGNATOR";

		/// <summary>
		/// <para>Large Grid Handling</para>
		/// <para>指定可能包含许多要素的大型输入区域的处理方式。</para>
		/// <para>无大格网—在创建 2000 个要素时，处理将停止。这是默认设置。</para>
		/// <para>允许大格网—支持大格网。</para>
		/// <para><see cref="LargeGridHandlingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LargeGridHandling { get; set; } = "NO_LARGE_GRIDS";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateReferenceSystemGRGFromArea SetEnviroment(object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Grid Reference System</para>
		/// </summary>
		public enum GridReferenceSystemEnum 
		{
			/// <summary>
			/// <para>军事格网参考系—将使用军事格网参考系。这是默认设置。</para>
			/// </summary>
			[GPValue("MGRS")]
			[Description("军事格网参考系")]
			Military_Grid_Reference_System,

			/// <summary>
			/// <para>美国国家格网—将使用美国国家格网。</para>
			/// </summary>
			[GPValue("USNG")]
			[Description("美国国家格网")]
			United_States_National_Grid,

		}

		/// <summary>
		/// <para>Grid Square Size</para>
		/// </summary>
		public enum GridSquareSizeEnum 
		{
			/// <summary>
			/// <para>格网区域指示符—格网像元的大小将为“格网区域”。这是默认设置。</para>
			/// </summary>
			[GPValue("GRID_ZONE_DESIGNATOR")]
			[Description("格网区域指示符")]
			Grid_Zone_Designator,

			/// <summary>
			/// <para>100,000 米格网—格网像元的大小将为 100,000 米的格网方格。</para>
			/// </summary>
			[GPValue("100000M_GRID")]
			[Description("100,000 米格网")]
			_100000M_GRID,

			/// <summary>
			/// <para>10,000 米格网—格网像元的大小将为 10,000 米的格网方格。</para>
			/// </summary>
			[GPValue("10000M_GRID")]
			[Description("10,000 米格网")]
			_10000M_GRID,

			/// <summary>
			/// <para>1,000 米格网—格网像元的大小将为 1,000 米的格网方格。</para>
			/// </summary>
			[GPValue("1000M_GRID")]
			[Description("1,000 米格网")]
			_1000M_GRID,

			/// <summary>
			/// <para>100 米格网—格网像元的大小将为 100 米的格网方格。</para>
			/// </summary>
			[GPValue("100M_GRID")]
			[Description("100 米格网")]
			_100_m_grid,

			/// <summary>
			/// <para>10 米格网—格网像元的大小将为 10 米的格网方格。</para>
			/// </summary>
			[GPValue("10M_GRID")]
			[Description("10 米格网")]
			_10_m_grid,

		}

		/// <summary>
		/// <para>Large Grid Handling</para>
		/// </summary>
		public enum LargeGridHandlingEnum 
		{
			/// <summary>
			/// <para>无大格网—在创建 2000 个要素时，处理将停止。这是默认设置。</para>
			/// </summary>
			[GPValue("NO_LARGE_GRIDS")]
			[Description("无大格网")]
			No_large_grids,

			/// <summary>
			/// <para>允许大格网—支持大格网。</para>
			/// </summary>
			[GPValue("ALLOW_LARGE_GRIDS")]
			[Description("允许大格网")]
			Allow_large_grids,

		}

#endregion
	}
}
