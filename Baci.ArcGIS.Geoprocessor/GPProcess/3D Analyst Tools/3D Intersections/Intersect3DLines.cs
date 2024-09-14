using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Intersect 3D Lines</para>
	/// <para>3D 线相交</para>
	/// <para>用于计算 3D 空间中线的相交和重叠线段。</para>
	/// </summary>
	public class Intersect3DLines : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLines">
		/// <para>Input Features</para>
		/// <para>将针对交点进行评估的线要素。输入可以包含一或两个线要素图层或类。如果指定了一个输入，则将每个要素与该要素类中的所有其他要素进行比较。没有要素将与其自身进行比较。</para>
		/// </param>
		public Intersect3DLines(object InLines)
		{
			this.InLines = InLines;
		}

		/// <summary>
		/// <para>Tool Display Name : 3D 线相交</para>
		/// </summary>
		public override string DisplayName() => "3D 线相交";

		/// <summary>
		/// <para>Tool Name : Intersect3DLines</para>
		/// </summary>
		public override string ToolName() => "Intersect3DLines";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Intersect3DLines</para>
		/// </summary>
		public override string ExcuteName() => "3d.Intersect3DLines";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLines, MaxZDiff!, JoinAttributes!, OutPointFc!, OutLineFc!, OutIntersectionCount! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将针对交点进行评估的线要素。输入可以包含一或两个线要素图层或类。如果指定了一个输入，则将每个要素与该要素类中的所有其他要素进行比较。没有要素将与其自身进行比较。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object InLines { get; set; }

		/// <summary>
		/// <para>Maximum Z Difference</para>
		/// <para>相交线段之间的最大垂直距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? MaxZDiff { get; set; }

		/// <summary>
		/// <para>Attributes To Join</para>
		/// <para>指定将输入要素的哪些属性传递到输出要素类。</para>
		/// <para>所有属性—输入要素的所有属性都将传递到输出要素类。 这是默认设置。</para>
		/// <para>除要素 ID 外的所有属性—除 FID 外，将输入要素的其余所有属性都传递到输出要素类。</para>
		/// <para>仅要素 ID—仅输入要素的 FID 字段将传递到输出要素类。</para>
		/// <para><see cref="JoinAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? JoinAttributes { get; set; } = "ALL";

		/// <summary>
		/// <para>Output Point Feature Class</para>
		/// <para>输出点代表输入线相交的位置，其中包括重叠线段的起点和终点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutPointFc { get; set; }

		/// <summary>
		/// <para>Output Line Feature Class</para>
		/// <para>输出线表示存在于输入线之间的重叠部分。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutLineFc { get; set; }

		/// <summary>
		/// <para>Output Intersection Count</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object? OutIntersectionCount { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Intersect3DLines SetEnviroment(object? XYResolution = null, object? XYTolerance = null, object? ZResolution = null, object? ZTolerance = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Attributes To Join</para>
		/// </summary>
		public enum JoinAttributesEnum 
		{
			/// <summary>
			/// <para>除要素 ID 外的所有属性—除 FID 外，将输入要素的其余所有属性都传递到输出要素类。</para>
			/// </summary>
			[GPValue("NO_FID")]
			[Description("除要素 ID 外的所有属性")]
			All_attributes_except_feature_IDs,

			/// <summary>
			/// <para>仅要素 ID—仅输入要素的 FID 字段将传递到输出要素类。</para>
			/// </summary>
			[GPValue("ONLY_FID")]
			[Description("仅要素 ID")]
			Only_feature_IDs,

			/// <summary>
			/// <para>所有属性—输入要素的所有属性都将传递到输出要素类。 这是默认设置。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有属性")]
			All_attributes,

		}

#endregion
	}
}
