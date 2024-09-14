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
	/// <para>Update Interior Orientation</para>
	/// <para>更新内部方向</para>
	/// <para>可从基准表构造仿射变换，以优化镶嵌数据集中每个图像的内部方向。</para>
	/// </summary>
	public class UpdateInteriorOrientation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>使用扫描栅格类型或帧照相机栅格类型，根据扫描航空照片创建的镶嵌数据集。</para>
		/// </param>
		public UpdateInteriorOrientation(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 更新内部方向</para>
		/// </summary>
		public override string DisplayName() => "更新内部方向";

		/// <summary>
		/// <para>Tool Name : UpdateInteriorOrientation</para>
		/// </summary>
		public override string ToolName() => "UpdateInteriorOrientation";

		/// <summary>
		/// <para>Tool Excute Name : management.UpdateInteriorOrientation</para>
		/// </summary>
		public override string ExcuteName() => "management.UpdateInteriorOrientation";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, WhereClause!, FiducialTable!, FilmCoordinateSystem!, UpdateFootprints!, OutMosaicDataset! };

		/// <summary>
		/// <para>Input Mosaic Dataset</para>
		/// <para>使用扫描栅格类型或帧照相机栅格类型，根据扫描航空照片创建的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>用于定义计算基准的栅格子集的查询定义字符串。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Fiducial Table</para>
		/// <para>使用计算基准工具创建的基准表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object? FiducialTable { get; set; }

		/// <summary>
		/// <para>Film Coordinate System</para>
		/// <para>用于定义扫描航空像片的胶片坐标系。可用于计算基准信息和仿射变换构造。</para>
		/// <para>不变—请保留镶嵌数据集的坐标系。不要更改扫描航空像片的胶片坐标系。请保留镶嵌数据集的坐标系。</para>
		/// <para>X 右，Y 上—扫描照片坐标系的原点为中心，正 X 点向右，正 Y 点向上。</para>
		/// <para>X 上，Y 左—扫描照片坐标系的原点为中心，正 X 点向上，正 Y 点向左。</para>
		/// <para>X 左，Y 下—扫描照片坐标系的原点为中心，正 X 点向左，正 Y 点向下。</para>
		/// <para>X 下，Y 右—扫描照片坐标系的原点为中心，正 X 点向下，正 Y 点向右。</para>
		/// <para><see cref="FilmCoordinateSystemEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FilmCoordinateSystem { get; set; } = "NO_CHANGE";

		/// <summary>
		/// <para>Update Footprints</para>
		/// <para>生成或更新镶嵌数据集中数字照片的轮廓线。</para>
		/// <para>选中 - 生成或更新轮廓线。</para>
		/// <para>未选中 - 不生成或更新轮廓线。这是默认设置</para>
		/// <para><see cref="UpdateFootprintsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? UpdateFootprints { get; set; } = "false";

		/// <summary>
		/// <para>Output Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutMosaicDataset { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Film Coordinate System</para>
		/// </summary>
		public enum FilmCoordinateSystemEnum 
		{
			/// <summary>
			/// <para>不变—请保留镶嵌数据集的坐标系。不要更改扫描航空像片的胶片坐标系。请保留镶嵌数据集的坐标系。</para>
			/// </summary>
			[GPValue("NO_CHANGE")]
			[Description("不变")]
			No_change,

			/// <summary>
			/// <para>X 右，Y 上—扫描照片坐标系的原点为中心，正 X 点向右，正 Y 点向上。</para>
			/// </summary>
			[GPValue("X_RIGHT_Y_UP")]
			[Description("X 右，Y 上")]
			X_RIGHT_Y_UP,

			/// <summary>
			/// <para>X 上，Y 左—扫描照片坐标系的原点为中心，正 X 点向上，正 Y 点向左。</para>
			/// </summary>
			[GPValue("X_UP_Y_LEFT")]
			[Description("X 上，Y 左")]
			X_UP_Y_LEFT,

			/// <summary>
			/// <para>X 左，Y 下—扫描照片坐标系的原点为中心，正 X 点向左，正 Y 点向下。</para>
			/// </summary>
			[GPValue("X_LEFT_Y_DOWN")]
			[Description("X 左，Y 下")]
			X_LEFT_Y_DOWN,

			/// <summary>
			/// <para>X 下，Y 右—扫描照片坐标系的原点为中心，正 X 点向下，正 Y 点向右。</para>
			/// </summary>
			[GPValue("X_DOWN_Y_RIGHT")]
			[Description("X 下，Y 右")]
			X_DOWN_Y_RIGHT,

		}

		/// <summary>
		/// <para>Update Footprints</para>
		/// </summary>
		public enum UpdateFootprintsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE")]
			UPDATE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_UPDATE")]
			NO_UPDATE,

		}

#endregion
	}
}
