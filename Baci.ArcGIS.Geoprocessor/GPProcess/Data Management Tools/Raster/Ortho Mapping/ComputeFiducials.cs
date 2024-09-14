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
	/// <para>Compute Fiducials</para>
	/// <para>计算基准</para>
	/// <para>计算镶嵌数据集中每个图像的图像空间和胶片空间中的基准坐标。</para>
	/// </summary>
	public class ComputeFiducials : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>使用扫描栅格类型或帧照相机栅格类型，根据扫描航空照片创建的镶嵌数据集。</para>
		/// </param>
		/// <param name="OutFiducialTable">
		/// <para>Output Fiducial Table</para>
		/// <para>用于存储图像空间和胶片空间中所有基准坐标信息的输出表格。</para>
		/// </param>
		public ComputeFiducials(object InMosaicDataset, object OutFiducialTable)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.OutFiducialTable = OutFiducialTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算基准</para>
		/// </summary>
		public override string DisplayName() => "计算基准";

		/// <summary>
		/// <para>Tool Name : ComputeFiducials</para>
		/// </summary>
		public override string ToolName() => "ComputeFiducials";

		/// <summary>
		/// <para>Tool Excute Name : management.ComputeFiducials</para>
		/// </summary>
		public override string ExcuteName() => "management.ComputeFiducials";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, OutFiducialTable, WhereClause, FiducialTemplates, FilmCoordinateSystem };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>使用扫描栅格类型或帧照相机栅格类型，根据扫描航空照片创建的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Output Fiducial Table</para>
		/// <para>用于存储图像空间和胶片空间中所有基准坐标信息的输出表格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutFiducialTable { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>用于定义计算基准的栅格子集的查询定义字符串。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Fiducial Templates</para>
		/// <para>包含用于存储基准图片和其他属性的必填字段的基准模板表格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object FiducialTemplates { get; set; }

		/// <summary>
		/// <para>Film Coordinate System</para>
		/// <para>用于定义扫描航空像片的胶片坐标系的关键字。可用于计算基准信息和仿射变换构造。</para>
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
		public object FilmCoordinateSystem { get; set; } = "NO_CHANGE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ComputeFiducials SetEnviroment(object parallelProcessingFactor = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

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

#endregion
	}
}
