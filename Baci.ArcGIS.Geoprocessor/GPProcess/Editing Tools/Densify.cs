using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.EditingTools
{
	/// <summary>
	/// <para>Densify</para>
	/// <para>增密</para>
	/// <para>可以沿线要素或面要素添加折点，还可将曲线线段（贝塞尔、圆弧和椭圆弧）替换为线段。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class Densify : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要增密的面或线要素类。</para>
		/// </param>
		public Densify(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 增密</para>
		/// </summary>
		public override string DisplayName() => "增密";

		/// <summary>
		/// <para>Tool Name : 增密</para>
		/// </summary>
		public override string ToolName() => "增密";

		/// <summary>
		/// <para>Tool Excute Name : edit.Densify</para>
		/// </summary>
		public override string ExcuteName() => "edit.Densify";

		/// <summary>
		/// <para>Toolbox Display Name : Editing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Editing Tools";

		/// <summary>
		/// <para>Toolbox Alise : edit</para>
		/// </summary>
		public override string ToolboxAlise() => "edit";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, DensificationMethod!, Distance!, MaxDeviation!, MaxAngle!, OutFeatureClass!, MaxVertexPerSegment! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要增密的面或线要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Densification Method</para>
		/// <para>指定要使用的要素增密方法。</para>
		/// <para>距离—直线和曲线将使用指定的距离进行增密。 这是默认设置。</para>
		/// <para>偏移—曲线将使用指定的最大偏移偏差进行增密。</para>
		/// <para>角—曲线将使用指定的最大偏转角进行增密。</para>
		/// <para><see cref="DensificationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DensificationMethod { get; set; } = "DISTANCE";

		/// <summary>
		/// <para>Distance</para>
		/// <para>折点间的最大距离。 此距离始终应用于线段，并用来简化曲线。 默认值是关于数据的 x,y 容差的函数。</para>
		/// <para>可能无法沿线以此确切间隔插入新折点，只能将它们插入到先前折点的此距离内。 无法确保沿线段以指定的间隔精确添加折点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? Distance { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Maximum Offset Deviation</para>
		/// <para>输出线段与原始线段之间的最大距离。 此参数仅影响曲线。 默认值是关于数据的 x,y 容差的函数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? MaxDeviation { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Maximum Deflection Angle (Degrees)</para>
		/// <para>输出几何与输入几何之间的最大角度。 有效范围是 0 到 90。 默认值为 10。 此参数仅影响曲线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = false, Value = 90)]
		public object? MaxAngle { get; set; } = "10";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Maximum Vertex Count (per segment)</para>
		/// <para>每个线段所允许的最大折点计数。 如果未输入任何值或输入无效值（0 或更小），则线段将没有折点限制，且曲线段的默认值将为 12000。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaxVertexPerSegment { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Densify SetEnviroment(int? autoCommit = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Densification Method</para>
		/// </summary>
		public enum DensificationMethodEnum 
		{
			/// <summary>
			/// <para>距离—直线和曲线将使用指定的距离进行增密。 这是默认设置。</para>
			/// </summary>
			[GPValue("DISTANCE")]
			[Description("距离")]
			Distance,

			/// <summary>
			/// <para>偏移—曲线将使用指定的最大偏移偏差进行增密。</para>
			/// </summary>
			[GPValue("OFFSET")]
			[Description("偏移")]
			Offset,

			/// <summary>
			/// <para>角—曲线将使用指定的最大偏转角进行增密。</para>
			/// </summary>
			[GPValue("ANGLE")]
			[Description("角")]
			Angle,

		}

#endregion
	}
}
