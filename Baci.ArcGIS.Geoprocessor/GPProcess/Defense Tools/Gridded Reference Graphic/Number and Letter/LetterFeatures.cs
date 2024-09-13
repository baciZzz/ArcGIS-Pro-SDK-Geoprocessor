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
	/// <para>Letter Features</para>
	/// <para>使用字母标注要素</para>
	/// <para>将字母添加到要素集的新字段或现有字段中。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class LetterFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>将使用字母标注输入要素。</para>
		/// </param>
		/// <param name="FieldToLetter">
		/// <para>Field to Letter (Existing or New)</para>
		/// <para>将使用字母标注输入字段。 该字段必须为新建或现有文本字段。</para>
		/// </param>
		public LetterFeatures(object InFeatures, object FieldToLetter)
		{
			this.InFeatures = InFeatures;
			this.FieldToLetter = FieldToLetter;
		}

		/// <summary>
		/// <para>Tool Display Name : 使用字母标注要素</para>
		/// </summary>
		public override string DisplayName() => "使用字母标注要素";

		/// <summary>
		/// <para>Tool Name : LetterFeatures</para>
		/// </summary>
		public override string ToolName() => "LetterFeatures";

		/// <summary>
		/// <para>Tool Excute Name : defense.LetterFeatures</para>
		/// </summary>
		public override string ExcuteName() => "defense.LetterFeatures";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, FieldToLetter, InArea!, SpatialSortMethod!, LetteringFormat!, StartingLetter!, OmitLetters!, CenterPoint!, AddDistanceAndBearing!, OutFeatureClass! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将使用字母标注输入要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline", "Multipoint", "Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Field to Letter (Existing or New)</para>
		/// <para>将使用字母标注输入字段。 该字段必须为新建或现有文本字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object FieldToLetter { get; set; }

		/// <summary>
		/// <para>Input Area to Letter</para>
		/// <para>限制要字母标注的要素的面；将仅对此面内的要素进行字母标注。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object? InArea { get; set; }

		/// <summary>
		/// <para>Spatial Sort Method</para>
		/// <para>指定如何对要素进行空间排序以进行字母标注。 不会对表中的要素重新排序。</para>
		/// <para>右上角—要素将从右上角开始排序。 这是默认设置。</para>
		/// <para>左上角—要素将从左上角开始排序。</para>
		/// <para>右下角—要素将从右下角开始排序。</para>
		/// <para>左下角—要素将从左下角开始排序。</para>
		/// <para>皮亚诺曲线—要素将使用空间填充曲线算法（也称为皮亚诺曲线）进行排序。</para>
		/// <para>居中—要素将从中心点开始排序（如果没有提供中心，将使用平均中心）。</para>
		/// <para>顺时针—要素将从中心点开始排序，并按顺时针移动。</para>
		/// <para>逆时针—要素将从中心点开始排序，并按逆时针移动。</para>
		/// <para>无—不会使用空间排序。 将使用与要素类相同的顺序。</para>
		/// <para><see cref="SpatialSortMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SpatialSortMethod { get; set; } = "UR";

		/// <summary>
		/// <para>Lettering Format</para>
		/// <para>指定将用于每个要素的标注格式。</para>
		/// <para>Excel（A、B、C...）—将字母字符（例如，A、B、C）用作标注。 这是默认设置。</para>
		/// <para>Grid（AA、AB、AC...）—将使用具有递增的第二个字母字符格网的常量字母字符（例如，AA、AB、AC）。</para>
		/// <para>交替 Grid（AA、BB、CC...）—将使用为每个要素递增的双字母字符（例如，AA、BB、CC）。</para>
		/// <para><see cref="LetteringFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LetteringFormat { get; set; } = "A_B_C";

		/// <summary>
		/// <para>Starting Letter</para>
		/// <para>将用于开始字母标注的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? StartingLetter { get; set; } = "A";

		/// <summary>
		/// <para>Omit Letters</para>
		/// <para>将从字母序列中省略的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? OmitLetters { get; set; }

		/// <summary>
		/// <para>Center Point</para>
		/// <para>将用于排序和字母标注要素的中心点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object? CenterPoint { get; set; }

		/// <summary>
		/// <para>Add Distance and Bearing to Center</para>
		/// <para>指定是否将距中心点距离和方向角字段添加到输出中。</para>
		/// <para>不添加距离和方位角—不会将距离或方位字段添加到输出中。 这是默认设置。</para>
		/// <para>添加距离和方位角—DIST_TO_CENTER 和 ANGLE_TO_CENTER 字段将被添加到输出中。</para>
		/// <para><see cref="AddDistanceAndBearingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AddDistanceAndBearing { get; set; } = "false";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LetterFeatures SetEnviroment(object? extent = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Spatial Sort Method</para>
		/// </summary>
		public enum SpatialSortMethodEnum 
		{
			/// <summary>
			/// <para>右上角—要素将从右上角开始排序。 这是默认设置。</para>
			/// </summary>
			[GPValue("UR")]
			[Description("右上角")]
			Upper_right,

			/// <summary>
			/// <para>左上角—要素将从左上角开始排序。</para>
			/// </summary>
			[GPValue("UL")]
			[Description("左上角")]
			Upper_left,

			/// <summary>
			/// <para>右下角—要素将从右下角开始排序。</para>
			/// </summary>
			[GPValue("LR")]
			[Description("右下角")]
			Lower_right,

			/// <summary>
			/// <para>左下角—要素将从左下角开始排序。</para>
			/// </summary>
			[GPValue("LL")]
			[Description("左下角")]
			Lower_left,

			/// <summary>
			/// <para>皮亚诺曲线—要素将使用空间填充曲线算法（也称为皮亚诺曲线）进行排序。</para>
			/// </summary>
			[GPValue("PEANO")]
			[Description("皮亚诺曲线")]
			Peano_curve,

			/// <summary>
			/// <para>居中—要素将从中心点开始排序（如果没有提供中心，将使用平均中心）。</para>
			/// </summary>
			[GPValue("CENTER")]
			[Description("居中")]
			Center,

			/// <summary>
			/// <para>逆时针—要素将从中心点开始排序，并按逆时针移动。</para>
			/// </summary>
			[GPValue("COUNTERCLOCKWISE")]
			[Description("逆时针")]
			Counterclockwise,

			/// <summary>
			/// <para>顺时针—要素将从中心点开始排序，并按顺时针移动。</para>
			/// </summary>
			[GPValue("CLOCKWISE")]
			[Description("顺时针")]
			Clockwise,

			/// <summary>
			/// <para>无—不会使用空间排序。 将使用与要素类相同的顺序。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

		}

		/// <summary>
		/// <para>Lettering Format</para>
		/// </summary>
		public enum LetteringFormatEnum 
		{
			/// <summary>
			/// <para>Excel（A、B、C...）—将字母字符（例如，A、B、C）用作标注。 这是默认设置。</para>
			/// </summary>
			[GPValue("A_B_C")]
			[Description("Excel（A、B、C...）")]
			A_B_C,

			/// <summary>
			/// <para>Grid（AA、AB、AC...）—将使用具有递增的第二个字母字符格网的常量字母字符（例如，AA、AB、AC）。</para>
			/// </summary>
			[GPValue("AA_AB_AC")]
			[Description("Grid（AA、AB、AC...）")]
			AA_AB_AC,

			/// <summary>
			/// <para>交替 Grid（AA、BB、CC...）—将使用为每个要素递增的双字母字符（例如，AA、BB、CC）。</para>
			/// </summary>
			[GPValue("AA_BB_CC")]
			[Description("交替 Grid（AA、BB、CC...）")]
			AA_BB_CC,

		}

		/// <summary>
		/// <para>Add Distance and Bearing to Center</para>
		/// </summary>
		public enum AddDistanceAndBearingEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_DISTANCE")]
			ADD_DISTANCE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_ADD_DISTANCE")]
			DONT_ADD_DISTANCE,

		}

#endregion
	}
}
