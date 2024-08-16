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
	/// <para>Calculate Transformation Errors</para>
	/// <para>Calculates residue errors and root mean square error (RMSE) based on the coordinates of the input links between known control points to be used for spatial data transformation.</para>
	/// </summary>
	public class CalculateTransformationErrors : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLinkFeatures">
		/// <para>Input Link Features</para>
		/// <para>Input link features that link known control points for spatial transformation.</para>
		/// </param>
		/// <param name="OutLinkTable">
		/// <para>Output Link Table</para>
		/// <para>The output table containing input links feature IDs and their residual errors. The residual errors for input links are written to the specified output table that contains the following fields:</para>
		/// <para>Orig_FID—The input link feature ID</para>
		/// <para>X_Source—The x coordinate of the source or from end location of the link</para>
		/// <para>Y_Source—The y coordinate of the source or from end location of the link</para>
		/// <para>X_Destination—The x coordinate of the destination or to end location of the link</para>
		/// <para>Y_Destination—The y coordinate of the destination or to end location of the link</para>
		/// <para>Residual_Error—The residual error of the transformed location</para>
		/// </param>
		public CalculateTransformationErrors(object InLinkFeatures, object OutLinkTable)
		{
			this.InLinkFeatures = InLinkFeatures;
			this.OutLinkTable = OutLinkTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Transformation Errors</para>
		/// </summary>
		public override string DisplayName => "Calculate Transformation Errors";

		/// <summary>
		/// <para>Tool Name : CalculateTransformationErrors</para>
		/// </summary>
		public override string ToolName => "CalculateTransformationErrors";

		/// <summary>
		/// <para>Tool Excute Name : edit.CalculateTransformationErrors</para>
		/// </summary>
		public override string ExcuteName => "edit.CalculateTransformationErrors";

		/// <summary>
		/// <para>Toolbox Display Name : Editing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Editing Tools";

		/// <summary>
		/// <para>Toolbox Alise : edit</para>
		/// </summary>
		public override string ToolboxAlise => "edit";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InLinkFeatures, OutLinkTable, Method, OutRmse };

		/// <summary>
		/// <para>Input Link Features</para>
		/// <para>Input link features that link known control points for spatial transformation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLinkFeatures { get; set; }

		/// <summary>
		/// <para>Output Link Table</para>
		/// <para>The output table containing input links feature IDs and their residual errors. The residual errors for input links are written to the specified output table that contains the following fields:</para>
		/// <para>Orig_FID—The input link feature ID</para>
		/// <para>X_Source—The x coordinate of the source or from end location of the link</para>
		/// <para>Y_Source—The y coordinate of the source or from end location of the link</para>
		/// <para>X_Destination—The x coordinate of the destination or to end location of the link</para>
		/// <para>Y_Destination—The y coordinate of the destination or to end location of the link</para>
		/// <para>Residual_Error—The residual error of the transformed location</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutLinkTable { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>Transformation method to use to convert input feature coordinates.</para>
		/// <para>Affine transformation—Affine transformation requires a minimum of three transformation links. This is the default.</para>
		/// <para>Projective transformation—Projective transformation requires a minimum of four transformation links.</para>
		/// <para>Similarity transformation—Similarity transformation requires a minimum of two transformation links.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "AFFINE";

		/// <summary>
		/// <para>RMSE</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object OutRmse { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateTransformationErrors SetEnviroment(object extent = null , object workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Affine transformation—Affine transformation requires a minimum of three transformation links. This is the default.</para>
			/// </summary>
			[GPValue("AFFINE")]
			[Description("Affine transformation")]
			Affine_transformation,

			/// <summary>
			/// <para>Projective transformation—Projective transformation requires a minimum of four transformation links.</para>
			/// </summary>
			[GPValue("PROJECTIVE")]
			[Description("Projective transformation")]
			Projective_transformation,

			/// <summary>
			/// <para>Similarity transformation—Similarity transformation requires a minimum of two transformation links.</para>
			/// </summary>
			[GPValue("SIMILARITY")]
			[Description("Similarity transformation")]
			Similarity_transformation,

		}

#endregion
	}
}
