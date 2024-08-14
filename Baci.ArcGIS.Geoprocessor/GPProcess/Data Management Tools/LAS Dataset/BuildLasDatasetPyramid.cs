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
	/// <para>Build LAS Dataset Pyramid</para>
	/// <para>Constructs or updates a LAS dataset display cache, which optimizes its rendering performance.</para>
	/// </summary>
	public class BuildLasDatasetPyramid : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </param>
		public BuildLasDatasetPyramid(object InLasDataset)
		{
			this.InLasDataset = InLasDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Build LAS Dataset Pyramid</para>
		/// </summary>
		public override string DisplayName => "Build LAS Dataset Pyramid";

		/// <summary>
		/// <para>Tool Name : BuildLasDatasetPyramid</para>
		/// </summary>
		public override string ToolName => "BuildLasDatasetPyramid";

		/// <summary>
		/// <para>Tool Excute Name : management.BuildLasDatasetPyramid</para>
		/// </summary>
		public override string ExcuteName => "management.BuildLasDatasetPyramid";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InLasDataset, PointSelectionMethod, ClassCodesWeights, DerivedLasDataset };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Point Selection Method</para>
		/// <para>Specifies how the point in each binned region will be selected to construct the pyramid. This parameter is disabled if the LAS dataset contains a pyramid.</para>
		/// <para>Lowest Point—The point with the lowest z-value will be selected.</para>
		/// <para>Highest Point—The point with the highest z-value will be selected.</para>
		/// <para>Closest to Center—The point that is closest to the center of the binned region will be selected.</para>
		/// <para>Class Codes and Weights—The point with the highest weight value will be selected.</para>
		/// <para><see cref="PointSelectionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PointSelectionMethod { get; set; } = "CLOSEST_TO_CENTER";

		/// <summary>
		/// <para>Input Class Codes and Weights</para>
		/// <para>The weights assigned to each class code that determine which points are retained in each thinning region. This parameter is only enabled when the Class Code Weights option is specified in the Point Selection Method parameter. The class code with the highest weight will be retained in the thinning region. If two class codes with the same weight exist in a given thinning region, the class code with the smallest point source ID will be retained.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object ClassCodesWeights { get; set; }

		/// <summary>
		/// <para>Output LAS Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLasDatasetLayer()]
		public object DerivedLasDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BuildLasDatasetPyramid SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Point Selection Method</para>
		/// </summary>
		public enum PointSelectionMethodEnum 
		{
			/// <summary>
			/// <para>Closest to Center—The point that is closest to the center of the binned region will be selected.</para>
			/// </summary>
			[GPValue("CLOSEST_TO_CENTER")]
			[Description("Closest to Center")]
			Closest_to_Center,

			/// <summary>
			/// <para>Class Codes and Weights—The point with the highest weight value will be selected.</para>
			/// </summary>
			[GPValue("CLASS_CODE")]
			[Description("Class Codes and Weights")]
			Class_Codes_and_Weights,

			/// <summary>
			/// <para>Lowest Point—The point with the lowest z-value will be selected.</para>
			/// </summary>
			[GPValue("Z_MIN")]
			[Description("Lowest Point")]
			Lowest_Point,

			/// <summary>
			/// <para>Highest Point—The point with the highest z-value will be selected.</para>
			/// </summary>
			[GPValue("Z_MAX")]
			[Description("Highest Point")]
			Highest_Point,

		}

#endregion
	}
}
