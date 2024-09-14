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
	/// <para>Subdivide Polygon</para>
	/// <para>细分面</para>
	/// <para>用于将面要素分为若干等面积区域或部分。</para>
	/// </summary>
	public class SubdividePolygon : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPolygons">
		/// <para>Input Features</para>
		/// <para>要细分的面要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>细分面的输出要素类。</para>
		/// </param>
		/// <param name="Method">
		/// <para>Subdivision Method</para>
		/// <para>指定用于细分面的方法。</para>
		/// <para>等分数量— 面将被均分为若干部分。这是默认设置。</para>
		/// <para>相等面积—将根据指定的部分数量，将面划分为具有一定面积的多个部分以及剩余部分。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </param>
		public SubdividePolygon(object InPolygons, object OutFeatureClass, object Method)
		{
			this.InPolygons = InPolygons;
			this.OutFeatureClass = OutFeatureClass;
			this.Method = Method;
		}

		/// <summary>
		/// <para>Tool Display Name : 细分面</para>
		/// </summary>
		public override string DisplayName() => "细分面";

		/// <summary>
		/// <para>Tool Name : SubdividePolygon</para>
		/// </summary>
		public override string ToolName() => "SubdividePolygon";

		/// <summary>
		/// <para>Tool Excute Name : management.SubdividePolygon</para>
		/// </summary>
		public override string ExcuteName() => "management.SubdividePolygon";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPolygons, OutFeatureClass, Method, NumAreas, TargetArea, TargetWidth, SplitAngle, SubdivisionType };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要细分的面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InPolygons { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>细分面的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Subdivision Method</para>
		/// <para>指定用于细分面的方法。</para>
		/// <para>等分数量— 面将被均分为若干部分。这是默认设置。</para>
		/// <para>相等面积—将根据指定的部分数量，将面划分为具有一定面积的多个部分以及剩余部分。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "NUMBER_OF_EQUAL_PARTS";

		/// <summary>
		/// <para>Number of Areas</para>
		/// <para>表示面将被划分为的区域数（如果指定了等分数量细分方法）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 2)]
		[High(Allow = false, Value = 2147483647)]
		public object NumAreas { get; set; }

		/// <summary>
		/// <para>Target Area</para>
		/// <para>表示等份的面积（如果已指定等面积细分方法）。如果目标面积大于输入面的面积，则不会对面进行细分。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object TargetArea { get; set; }

		/// <summary>
		/// <para>RESERVED</para>
		/// <para>尚不支持此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		public object TargetWidth { get; set; }

		/// <summary>
		/// <para>Split Angle</para>
		/// <para>用于绘制面的分割线的角度。默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object SplitAngle { get; set; } = "0";

		/// <summary>
		/// <para>Subdivision Type</para>
		/// <para>指定面的分割方式。</para>
		/// <para>条状— 将面分割为条状。这是默认设置。</para>
		/// <para>堆叠的块状—将面分割为堆叠的块状。</para>
		/// <para><see cref="SubdivisionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SubdivisionType { get; set; } = "STRIPS";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SubdividePolygon SetEnviroment(object parallelProcessingFactor = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Subdivision Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>等分数量— 面将被均分为若干部分。这是默认设置。</para>
			/// </summary>
			[GPValue("NUMBER_OF_EQUAL_PARTS")]
			[Description("等分数量")]
			Number_of_equal_parts,

			/// <summary>
			/// <para>相等面积—将根据指定的部分数量，将面划分为具有一定面积的多个部分以及剩余部分。</para>
			/// </summary>
			[GPValue("EQUAL_AREAS")]
			[Description("相等面积")]
			Equal_areas,

		}

		/// <summary>
		/// <para>Subdivision Type</para>
		/// </summary>
		public enum SubdivisionTypeEnum 
		{
			/// <summary>
			/// <para>条状— 将面分割为条状。这是默认设置。</para>
			/// </summary>
			[GPValue("STRIPS")]
			[Description("条状")]
			Strips,

			/// <summary>
			/// <para>堆叠的块状—将面分割为堆叠的块状。</para>
			/// </summary>
			[GPValue("STACKED_BLOCKS")]
			[Description("堆叠的块状")]
			Stacked_blocks,

		}

#endregion
	}
}
