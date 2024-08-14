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
	/// <para>TIN Compare</para>
	/// <para>Compares two TINs and returns the comparison results.</para>
	/// </summary>
	public class TINCompare : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InBaseTin">
		/// <para>Input Base Tin</para>
		/// <para>The Input Base Tin is compared with the Input Test Tin. Input Base Tin refers to data that you have declared valid. This base data has the correct geometry, tag values (if any), and spatial reference.</para>
		/// </param>
		/// <param name="InTestTin">
		/// <para>Input Test Tin</para>
		/// <para>The Input Test Tin is compared against the Input Base Tin.</para>
		/// </param>
		public TINCompare(object InBaseTin, object InTestTin)
		{
			this.InBaseTin = InBaseTin;
			this.InTestTin = InTestTin;
		}

		/// <summary>
		/// <para>Tool Display Name : TIN Compare</para>
		/// </summary>
		public override string DisplayName => "TIN Compare";

		/// <summary>
		/// <para>Tool Name : TINCompare</para>
		/// </summary>
		public override string ToolName => "TINCompare";

		/// <summary>
		/// <para>Tool Excute Name : management.TINCompare</para>
		/// </summary>
		public override string ExcuteName => "management.TINCompare";

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
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InBaseTin, InTestTin, CompareType, ContinueCompare, OutCompareFile, CompareStatus };

		/// <summary>
		/// <para>Input Base Tin</para>
		/// <para>The Input Base Tin is compared with the Input Test Tin. Input Base Tin refers to data that you have declared valid. This base data has the correct geometry, tag values (if any), and spatial reference.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InBaseTin { get; set; }

		/// <summary>
		/// <para>Input Test Tin</para>
		/// <para>The Input Test Tin is compared against the Input Base Tin.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTestTin { get; set; }

		/// <summary>
		/// <para>Compare Type</para>
		/// <para>The comparison type.</para>
		/// <para>All—This is the default.</para>
		/// <para>Properties only—Refers to both geometry and TIN tag values, if any, that are assigned to nodes and triangles.</para>
		/// <para>Spatial Reference only—Coordinate system information.</para>
		/// <para><see cref="CompareTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CompareType { get; set; } = "ALL";

		/// <summary>
		/// <para>Continue Comparison</para>
		/// <para>Indicates whether to compare all properties after encountering the first mismatch.</para>
		/// <para>Unchecked—Stop after encountering the first mismatch. This is the default.</para>
		/// <para>Checked—Compare other properties after encountering the first mismatch.</para>
		/// <para><see cref="ContinueCompareEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ContinueCompare { get; set; } = "false";

		/// <summary>
		/// <para>Output Compare File</para>
		/// <para>The name and path of the text file which will contain the comparison results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object OutCompareFile { get; set; }

		/// <summary>
		/// <para>Compare Status</para>
		/// <para><see cref="CompareStatusEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CompareStatus { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>Compare Type</para>
		/// </summary>
		public enum CompareTypeEnum 
		{
			/// <summary>
			/// <para>All—This is the default.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>Properties only—Refers to both geometry and TIN tag values, if any, that are assigned to nodes and triangles.</para>
			/// </summary>
			[GPValue("PROPERTIES_ONLY")]
			[Description("Properties only")]
			Properties_only,

			/// <summary>
			/// <para>Spatial Reference only—Coordinate system information.</para>
			/// </summary>
			[GPValue("SPATIAL_REFERENCE_ONLY")]
			[Description("Spatial Reference only")]
			Spatial_Reference_only,

		}

		/// <summary>
		/// <para>Continue Comparison</para>
		/// </summary>
		public enum ContinueCompareEnum 
		{
			/// <summary>
			/// <para>Checked—Compare other properties after encountering the first mismatch.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CONTINUE_COMPARE")]
			CONTINUE_COMPARE,

			/// <summary>
			/// <para>Unchecked—Stop after encountering the first mismatch. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CONTINUE_COMPARE")]
			NO_CONTINUE_COMPARE,

		}

		/// <summary>
		/// <para>Compare Status</para>
		/// </summary>
		public enum CompareStatusEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("NO_DIFFERENCES_FOUND")]
			NO_DIFFERENCES_FOUND,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DIFFERENCES_FOUND")]
			DIFFERENCES_FOUND,

		}

#endregion
	}
}
