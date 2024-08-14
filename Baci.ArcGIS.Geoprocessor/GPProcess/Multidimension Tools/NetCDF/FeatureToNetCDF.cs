using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.MultidimensionTools
{
	/// <summary>
	/// <para>Feature to NetCDF</para>
	/// <para>Converts a point feature class to a netCDF file.</para>
	/// </summary>
	public class FeatureToNetCDF : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input point feature class.</para>
		/// </param>
		/// <param name="FieldsToVariables">
		/// <para>Fields to Variables</para>
		/// <para>The field or fields used to create variables in the netCDF file.</para>
		/// <para>Four special fields—Shape.X, Shape.Y, Shape.Z, and Shape.M—can be used for exporting x-coordinates or longitude, y-coordinates or latitude, Z values, and M values of input features, respectively.</para>
		/// <para>Field—A field in the input feature attribute table.</para>
		/// <para>Variable—The netCDF variable name</para>
		/// <para>Units—The units of the data represented by the field</para>
		/// </param>
		/// <param name="OutNetcdfFile">
		/// <para>Output netCDF File</para>
		/// <para>The output netCDF file. The file name must have an .nc extension.</para>
		/// </param>
		public FeatureToNetCDF(object InFeatures, object FieldsToVariables, object OutNetcdfFile)
		{
			this.InFeatures = InFeatures;
			this.FieldsToVariables = FieldsToVariables;
			this.OutNetcdfFile = OutNetcdfFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Feature to NetCDF</para>
		/// </summary>
		public override string DisplayName => "Feature to NetCDF";

		/// <summary>
		/// <para>Tool Name : FeatureToNetCDF</para>
		/// </summary>
		public override string ToolName => "FeatureToNetCDF";

		/// <summary>
		/// <para>Tool Excute Name : md.FeatureToNetCDF</para>
		/// </summary>
		public override string ExcuteName => "md.FeatureToNetCDF";

		/// <summary>
		/// <para>Toolbox Display Name : Multidimension Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Multidimension Tools";

		/// <summary>
		/// <para>Toolbox Alise : md</para>
		/// </summary>
		public override string ToolboxAlise => "md";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, FieldsToVariables, OutNetcdfFile, FieldsToDimensions };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input point feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Fields to Variables</para>
		/// <para>The field or fields used to create variables in the netCDF file.</para>
		/// <para>Four special fields—Shape.X, Shape.Y, Shape.Z, and Shape.M—can be used for exporting x-coordinates or longitude, y-coordinates or latitude, Z values, and M values of input features, respectively.</para>
		/// <para>Field—A field in the input feature attribute table.</para>
		/// <para>Variable—The netCDF variable name</para>
		/// <para>Units—The units of the data represented by the field</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object FieldsToVariables { get; set; }

		/// <summary>
		/// <para>Output netCDF File</para>
		/// <para>The output netCDF file. The file name must have an .nc extension.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutNetcdfFile { get; set; }

		/// <summary>
		/// <para>Fields to Dimensions</para>
		/// <para>The field or fields used to create dimensions in the netCDF file.</para>
		/// <para>Field—A field in the input feature attribute table.</para>
		/// <para>Dimension—The netCDF dimension name</para>
		/// <para>Units—The units of the data represented by the field</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object FieldsToDimensions { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeatureToNetCDF SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
