using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Extract Multi Values to Points</para>
	/// <para>Extracts cell values at locations specified in a point feature class from one or more rasters and records the values to the attribute table of the point feature class.</para>
	/// </summary>
	public class ExtractMultiValuesToPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input point features</para>
		/// <para>The input point features to which you want to add raster values.</para>
		/// </param>
		/// <param name="InRasters">
		/// <para>Input rasters</para>
		/// <para>The input raster (or rasters) values you want to extract based on the input point feature location.</para>
		/// <para>Optionally, you can supply the name for the field to store the raster value. By default, a unique field name will be created based on the input raster dataset name.</para>
		/// </param>
		public ExtractMultiValuesToPoints(object InPointFeatures, object InRasters)
		{
			this.InPointFeatures = InPointFeatures;
			this.InRasters = InRasters;
		}

		/// <summary>
		/// <para>Tool Display Name : Extract Multi Values to Points</para>
		/// </summary>
		public override string DisplayName => "Extract Multi Values to Points";

		/// <summary>
		/// <para>Tool Name : ExtractMultiValuesToPoints</para>
		/// </summary>
		public override string ToolName => "ExtractMultiValuesToPoints";

		/// <summary>
		/// <para>Tool Excute Name : sa.ExtractMultiValuesToPoints</para>
		/// </summary>
		public override string ExcuteName => "sa.ExtractMultiValuesToPoints";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "configKeyword", "extent", "mask", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InPointFeatures, InRasters, BilinearInterpolateValues, OutPointFeatures };

		/// <summary>
		/// <para>Input point features</para>
		/// <para>The input point features to which you want to add raster values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer")]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		[GeometryType("Point", "Multipoint")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Input rasters</para>
		/// <para>The input raster (or rasters) values you want to extract based on the input point feature location.</para>
		/// <para>Optionally, you can supply the name for the field to store the raster value. By default, a unique field name will be created based on the input raster dataset name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAExtractValues()]
		[GPCompositeDomain()]
		public object InRasters { get; set; }

		/// <summary>
		/// <para>Bilinear interpolation of values at point locations</para>
		/// <para>Specifies whether interpolation will be used.</para>
		/// <para>Unchecked—No interpolation will be applied; the value of the cell center will be used. This is the default.</para>
		/// <para>Checked—The value of the cell will be calculated from the adjacent cells with valid values using bilinear interpolation. NoData values will be ignored in the interpolation unless all adjacent cells are NoData.</para>
		/// <para><see cref="BilinearInterpolateValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object BilinearInterpolateValues { get; set; } = "false";

		/// <summary>
		/// <para>Updated point features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutPointFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractMultiValuesToPoints SetEnviroment(int? autoCommit = null , object configKeyword = null , object extent = null , object mask = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, mask: mask, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Bilinear interpolation of values at point locations</para>
		/// </summary>
		public enum BilinearInterpolateValuesEnum 
		{
			/// <summary>
			/// <para>Unchecked—No interpolation will be applied; the value of the cell center will be used. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

			/// <summary>
			/// <para>Checked—The value of the cell will be calculated from the adjacent cells with valid values using bilinear interpolation. NoData values will be ignored in the interpolation unless all adjacent cells are NoData.</para>
			/// </summary>
			[GPValue("true")]
			[Description("BILINEAR")]
			BILINEAR,

		}

#endregion
	}
}
