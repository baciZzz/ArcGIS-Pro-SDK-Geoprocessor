using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AviationTools
{
	/// <summary>
	/// <para>Generate OIS Intersection</para>
	/// <para>Creates the most restrictive (lowest) surfaces within the extent of all collective surfaces. Obstruction identification surfaces (OIS) determine  objects that are vertical obstructions. An object is considered a vertical obstruction if it penetrates the OIS surface. Surfaces are used to support planning and design activities.</para>
	/// </summary>
	public class GenerateOISIntersection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InOisFeatures">
		/// <para>Input OIS Features</para>
		/// <para>The input OIS features. The feature class must be a multipatch.</para>
		/// </param>
		/// <param name="OutOisFeatures">
		/// <para>Output OIS Features</para>
		/// <para>The updated feature class containing the meshed OIS with the lowest z-value.</para>
		/// </param>
		public GenerateOISIntersection(object InOisFeatures, object OutOisFeatures)
		{
			this.InOisFeatures = InOisFeatures;
			this.OutOisFeatures = OutOisFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate OIS Intersection</para>
		/// </summary>
		public override string DisplayName => "Generate OIS Intersection";

		/// <summary>
		/// <para>Tool Name : GenerateOISIntersection</para>
		/// </summary>
		public override string ToolName => "GenerateOISIntersection";

		/// <summary>
		/// <para>Tool Excute Name : aviation.GenerateOISIntersection</para>
		/// </summary>
		public override string ExcuteName => "aviation.GenerateOISIntersection";

		/// <summary>
		/// <para>Toolbox Display Name : Aviation Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Aviation Tools";

		/// <summary>
		/// <para>Toolbox Alise : aviation</para>
		/// </summary>
		public override string ToolboxAlise => "aviation";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InOisFeatures, OutOisFeatures, MultipartFeature! };

		/// <summary>
		/// <para>Input OIS Features</para>
		/// <para>The input OIS features. The feature class must be a multipatch.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		public object InOisFeatures { get; set; }

		/// <summary>
		/// <para>Output OIS Features</para>
		/// <para>The updated feature class containing the meshed OIS with the lowest z-value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object OutOisFeatures { get; set; }

		/// <summary>
		/// <para>Create Multipart Feature</para>
		/// <para>Specifies whether multipart features will be created in the output. Multipart features are composed of more than one physical part that only references one set of attributes.</para>
		/// <para>Checked—Multipart features will be created. This is default.</para>
		/// <para>Unchecked—Adjacent triangulated multipart features will be created as individual features.</para>
		/// <para><see cref="MultipartFeatureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MultipartFeature { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>Create Multipart Feature</para>
		/// </summary>
		public enum MultipartFeatureEnum 
		{
			/// <summary>
			/// <para>Checked—Multipart features will be created. This is default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MULTIPART")]
			MULTIPART,

			/// <summary>
			/// <para>Unchecked—Adjacent triangulated multipart features will be created as individual features.</para>
			/// </summary>
			[GPValue("false")]
			[Description("MERGE_ADJACENT")]
			MERGE_ADJACENT,

		}

#endregion
	}
}
