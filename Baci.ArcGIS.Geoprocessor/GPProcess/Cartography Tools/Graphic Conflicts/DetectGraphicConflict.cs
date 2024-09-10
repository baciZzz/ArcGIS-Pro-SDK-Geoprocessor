using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CartographyTools
{
	/// <summary>
	/// <para>Detect Graphic Conflict</para>
	/// <para>Creates polygons where two or more symbolized features graphically conflict.</para>
	/// </summary>
	public class DetectGraphicConflict : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Layer</para>
		/// <para>The input feature layer containing symbolized features. CAD, coverage, or VPF annotation, and dimensions, charts, dot-density or proportional symbols, raster layers, network datasets, and 3D symbols are not acceptable inputs.</para>
		/// </param>
		/// <param name="ConflictFeatures">
		/// <para>Conflict Layer</para>
		/// <para>The feature layer containing symbolized features potentially in conflict with symbolized features in the input layer.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class to be created to store conflict polygons. It cannot be one of the feature classes associated with the input layers.</para>
		/// </param>
		public DetectGraphicConflict(object InFeatures, object ConflictFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.ConflictFeatures = ConflictFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Detect Graphic Conflict</para>
		/// </summary>
		public override string DisplayName() => "Detect Graphic Conflict";

		/// <summary>
		/// <para>Tool Name : DetectGraphicConflict</para>
		/// </summary>
		public override string ToolName() => "DetectGraphicConflict";

		/// <summary>
		/// <para>Tool Excute Name : cartography.DetectGraphicConflict</para>
		/// </summary>
		public override string ExcuteName() => "cartography.DetectGraphicConflict";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise() => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cartographicCoordinateSystem", "cartographicPartitions", "referenceScale" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, ConflictFeatures, OutFeatureClass, ConflictDistance, LineConnectionAllowance };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The input feature layer containing symbolized features. CAD, coverage, or VPF annotation, and dimensions, charts, dot-density or proportional symbols, raster layers, network datasets, and 3D symbols are not acceptable inputs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Conflict Layer</para>
		/// <para>The feature layer containing symbolized features potentially in conflict with symbolized features in the input layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		public object ConflictFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class to be created to store conflict polygons. It cannot be one of the feature classes associated with the input layers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Conflict Distance</para>
		/// <para>The area where input and conflict symbology is closer than a certain distance. Temporary buffers one-half the size of the conflict distance value are created around symbols in both the input and conflict layers. Conflict polygons will be generated where these buffers overlap. Conflict distance is measured in page units (points, inches, millimeters, or centimeters). If you enter a conflict distance in map units, it will be converted to page units using the reference scale. The default conflict distance is 0, where no buffers are created and only symbols that physically overlap one another are detected as conflicts.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object ConflictDistance { get; set; } = "0 Points";

		/// <summary>
		/// <para>Line Connection Allowance</para>
		/// <para>The radius of a circle, centered where lines join, within which graphic overlaps won't be detected. This parameter is only considered when the input layer and the conflict layer are identical. Zero allowance will detect a conflict at each line join (if end caps are overlapping). Line connection allowance is calculated in page units (points, inches, millimeters, or centimeters). If you enter an allowance in map units, it will be converted to page units using the reference scale. The value cannot be negative; the default value is 1 point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object LineConnectionAllowance { get; set; } = "1 Points";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DetectGraphicConflict SetEnviroment(object cartographicCoordinateSystem = null , object cartographicPartitions = null , object referenceScale = null )
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem, cartographicPartitions: cartographicPartitions, referenceScale: referenceScale);
			return this;
		}

	}
}
