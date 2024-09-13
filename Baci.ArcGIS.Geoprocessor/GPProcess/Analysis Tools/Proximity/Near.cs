using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Near</para>
	/// <para>邻近分析</para>
	/// <para>可计算输入要素与其他图层或要素类中的最近要素之间的距离和其他邻近性信息。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class Near : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入要素可以是点、折线、面或多点类型。</para>
		/// </param>
		/// <param name="NearFeatures">
		/// <para>Near Features</para>
		/// <para>一个或多个包含邻近要素候选项的要素图层或要素类。 邻近要素可以是点、折线、面或多点。 如果指定了多个图层或要素类，则 NEAR_FC 字段将添加到输入表中，并将存储含有找到的最近要素的源要素类的路径。 同一要素类或图层可同时用作输入要素和邻近要素。</para>
		/// </param>
		public Near(object InFeatures, object NearFeatures)
		{
			this.InFeatures = InFeatures;
			this.NearFeatures = NearFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 邻近分析</para>
		/// </summary>
		public override string DisplayName() => "邻近分析";

		/// <summary>
		/// <para>Tool Name : 邻近分析</para>
		/// </summary>
		public override string ToolName() => "邻近分析";

		/// <summary>
		/// <para>Tool Excute Name : analysis.Near</para>
		/// </summary>
		public override string ExcuteName() => "analysis.Near";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise() => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, NearFeatures, SearchRadius!, Location!, Angle!, OutFeatureClass!, Method!, FieldNames! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入要素可以是点、折线、面或多点类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Near Features</para>
		/// <para>一个或多个包含邻近要素候选项的要素图层或要素类。 邻近要素可以是点、折线、面或多点。 如果指定了多个图层或要素类，则 NEAR_FC 字段将添加到输入表中，并将存储含有找到的最近要素的源要素类的路径。 同一要素类或图层可同时用作输入要素和邻近要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object NearFeatures { get; set; }

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>用于搜索邻近要素的半径。 如果未指定任何值，则会考虑所有邻近要素。 如果指定了距离，但没有指定任何单位或将单位设置为未知，则将使用输入要素的坐标系单位。 如果针对方法参数使用测地线选项，请使用线性单位，例如千米或英里。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SearchRadius { get; set; }

		/// <summary>
		/// <para>Location</para>
		/// <para>指定是否将邻近要素最近位置的 x 和 y 坐标写入 NEAR_X 和 NEAR_Y 字段。</para>
		/// <para>未选中 - 将不会写入位置。 这是默认设置。</para>
		/// <para>选中 - 将写入位置。</para>
		/// <para><see cref="LocationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Location { get; set; } = "false";

		/// <summary>
		/// <para>Angle</para>
		/// <para>指定是否计算邻近角并将其写入输出表的 NEAR_ANGLE 字段。 邻近角测量连接了输入要素与其最近要素的最近位置的直线的方向。 在方法参数中使用平面方法时，角度在 -180° 到 180° 的范围内，0°代表东，90°代表北，180°（或 -180°）代表西，-90° 代表南。 使用测地线方法时，角度在 -180° 到 180° 的范围内，0° 代表北，90° 代表东，180°（或 -180°）代表南，-90° 代表西。</para>
		/// <para>未选中 - 将不会添加 NEAR_ANGLE 字段。 这是默认设置。</para>
		/// <para>选中 - 将添加 NEAR_ANGLE 字段。</para>
		/// <para><see cref="AngleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Angle { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>指定是使用椭球体上的最短路径（测地线）还是使用地平（平面）方法。 建议您将测地线方法用于在不适合进行距离测量的坐标系（例如 Web 墨卡托或任何地理坐标系）中存储的数据，以及任何地理区域跨度较大的分析。</para>
		/// <para>平面—将在要素之间使用平面距离。 这是默认设置。</para>
		/// <para>测地线—将在要素之间使用测地线距离。 这种方法考虑到椭球体的曲率，并可以正确处理日期变更线和两极附近的数据。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Field Names</para>
		/// <para>指定将在处理期间添加的属性字段的名称。</para>
		/// <para>如果未使用此参数，或从该参数中排除要添加的任何字段，则将使用默认字段名称。</para>
		/// <para>默认情况下，将始终添加 NEAR_FID 和 NEAR_DIST 字段；当启用位置参数（Python 中的 location）时，将添加 NEAR_X 和 NEAR_Y 字段；当启用角度参数（Python 中的 angle）时，将添加 NEAR_ANGLE 字段；当使用多个输入时，将添加 NEAR_FC 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? FieldNames { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Near SetEnviroment(object? extent = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Location</para>
		/// </summary>
		public enum LocationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("LOCATION")]
			LOCATION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_LOCATION")]
			NO_LOCATION,

		}

		/// <summary>
		/// <para>Angle</para>
		/// </summary>
		public enum AngleEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ANGLE")]
			ANGLE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ANGLE")]
			NO_ANGLE,

		}

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>平面—将在要素之间使用平面距离。 这是默认设置。</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("平面")]
			Planar,

			/// <summary>
			/// <para>测地线—将在要素之间使用测地线距离。 这种方法考虑到椭球体的曲率，并可以正确处理日期变更线和两极附近的数据。</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("测地线")]
			Geodesic,

		}

#endregion
	}
}
