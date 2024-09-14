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
	/// <para>Create Random Points</para>
	/// <para>创建随机点</para>
	/// <para>创建指定数量的随机点要素。可以在范围窗口中、面要素内、点要素上或线要素沿线生成随机点。</para>
	/// </summary>
	public class CreateRandomPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutPath">
		/// <para>Output Location</para>
		/// <para>创建随机点要素类所要使用的位置或工作空间。此位置或工作空间必须已经存在。</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Output Point Feature Class</para>
		/// <para>要创建的随机点要素类的名称。</para>
		/// </param>
		public CreateRandomPoints(object OutPath, object OutName)
		{
			this.OutPath = OutPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建随机点</para>
		/// </summary>
		public override string DisplayName() => "创建随机点";

		/// <summary>
		/// <para>Tool Name : CreateRandomPoints</para>
		/// </summary>
		public override string ToolName() => "CreateRandomPoints";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateRandomPoints</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateRandomPoints";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "randomGenerator", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutPath, OutName, ConstrainingFeatureClass!, ConstrainingExtent!, NumberOfPointsOrField!, MinimumAllowedDistance!, CreateMultipointOutput!, MultipointSize!, OutFeatureClass! };

		/// <summary>
		/// <para>Output Location</para>
		/// <para>创建随机点要素类所要使用的位置或工作空间。此位置或工作空间必须已经存在。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutPath { get; set; }

		/// <summary>
		/// <para>Output Point Feature Class</para>
		/// <para>要创建的随机点要素类的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Constraining Feature Class</para>
		/// <para>将在此要素类中的要素的内部或沿线生成随机点。约束要素类可以是点、多点、线或面。点将被随机放置在面要素内、线要素沿线或点要素位置处。此要素类中的每个要素内部都会生成指定数量的点（例如，如果您指定 100 个点且约束要素类中包含 5 个要素，则每个要素中会生成 100 个随机点，共生成 500 个点）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline", "Point", "Multipoint")]
		[FeatureType("Simple")]
		public object? ConstrainingFeatureClass { get; set; }

		/// <summary>
		/// <para>Constraining Extent</para>
		/// <para>将在此范围内生成随机点。仅当未指定约束要素类时，才会使用约束范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? ConstrainingExtent { get; set; }

		/// <summary>
		/// <para>Number of Points [value or field]</para>
		/// <para>要随机生成的点的数量。</para>
		/// <para>可将点数指定为长整型数值或指定为约束要素中的字段，其中约束要素需包含表示每个要素中要放置多少随机点的数值。此字段选项仅对面约束要素或线约束要素有效。如果点数以长整型数值的形式提供，则将在约束要素类中每个要素的内部或沿线生成该数量的随机点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? NumberOfPointsOrField { get; set; } = "100";

		/// <summary>
		/// <para>Minimum Allowed Distance [value or field]</para>
		/// <para>任意两个随机放置的点之间的最小允许距离。如果将此距离值指定为 1 米，则所有随机点距最近点的距离都将大于 1 米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? MinimumAllowedDistance { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Create Multipoint Output</para>
		/// <para>确定输出要素类是多部件要素还是单部件要素。</para>
		/// <para>未选中 - 输出的几何类型将为点（每个点均是独立要素）。这是默认设置。</para>
		/// <para>选中 - 输出的几何类型将为多点（所有点是一个要素）。</para>
		/// <para><see cref="CreateMultipointOutputEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CreateMultipointOutput { get; set; } = "false";

		/// <summary>
		/// <para>Maximum Number of Points per Multipoint</para>
		/// <para>如果选中创建多点输出，则需指定每个多点几何中要放置的随机点的数量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 100000)]
		public object? MultipointSize { get; set; } = "10";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateRandomPoints SetEnviroment(object? MDomain = null, double? MResolution = null, double? MTolerance = null, object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null, object? randomGenerator = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, randomGenerator: randomGenerator, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Create Multipoint Output</para>
		/// </summary>
		public enum CreateMultipointOutputEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MULTIPOINT")]
			MULTIPOINT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("POINT")]
			POINT,

		}

#endregion
	}
}
