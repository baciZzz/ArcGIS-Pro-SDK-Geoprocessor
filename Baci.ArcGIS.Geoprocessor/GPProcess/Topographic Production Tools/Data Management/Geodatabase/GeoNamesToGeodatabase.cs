using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>GeoNames To Geodatabase</para>
	/// <para>Loads GeoNames data into a feature class and table. The feature class is composed of point features, and the table contains fields with information concerning the naming conventions used for the features. The feature class contains the Unique Feature Identifier (UFI) and Unique Name Identifier (UNI), which match the same fields in the GeoNames table.</para>
	/// </summary>
	public class GeoNamesToGeodatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSource">
		/// <para>GeoNames Source File</para>
		/// <para>Path to the source file containing GeoNames information. This needs to be a properly formatted GeoNames file.</para>
		/// </param>
		/// <param name="InFeatureClass">
		/// <para>GeoNames Feature Class Name</para>
		/// <para>The GeoNames feature class; this feature class should be in the working database.</para>
		/// </param>
		/// <param name="InAllowDuplicates">
		/// <para>Allow Duplicates</para>
		/// <para>Allows duplicate features in the GeoNames feature class.</para>
		/// <para>Checked—Allows the tool to import features even if there is already an entry in the GeoNames feature class and table.</para>
		/// <para>Unchecked—Prevents the tool from importing features if there is another feature with the same geometry and attributes in the GeoNames feature class or GeoNames table. This is the default.</para>
		/// <para><see cref="InAllowDuplicatesEnum"/></para>
		/// </param>
		/// <param name="InTable">
		/// <para>GeoNames Table Name</para>
		/// <para>The GeoNames table. This table should be in the working database.</para>
		/// </param>
		public GeoNamesToGeodatabase(object InSource, object InFeatureClass, object InAllowDuplicates, object InTable)
		{
			this.InSource = InSource;
			this.InFeatureClass = InFeatureClass;
			this.InAllowDuplicates = InAllowDuplicates;
			this.InTable = InTable;
		}

		/// <summary>
		/// <para>Tool Display Name : GeoNames To Geodatabase</para>
		/// </summary>
		public override string DisplayName() => "GeoNames To Geodatabase";

		/// <summary>
		/// <para>Tool Name : GeoNamesToGeodatabase</para>
		/// </summary>
		public override string ToolName() => "GeoNamesToGeodatabase";

		/// <summary>
		/// <para>Tool Excute Name : topographic.GeoNamesToGeodatabase</para>
		/// </summary>
		public override string ExcuteName() => "topographic.GeoNamesToGeodatabase";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise() => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSource, InFeatureClass, InAllowDuplicates, InTable, OutFeatureclass, OutTable };

		/// <summary>
		/// <para>GeoNames Source File</para>
		/// <para>Path to the source file containing GeoNames information. This needs to be a properly formatted GeoNames file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSource { get; set; }

		/// <summary>
		/// <para>GeoNames Feature Class Name</para>
		/// <para>The GeoNames feature class; this feature class should be in the working database.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Allow Duplicates</para>
		/// <para>Allows duplicate features in the GeoNames feature class.</para>
		/// <para>Checked—Allows the tool to import features even if there is already an entry in the GeoNames feature class and table.</para>
		/// <para>Unchecked—Prevents the tool from importing features if there is another feature with the same geometry and attributes in the GeoNames feature class or GeoNames table. This is the default.</para>
		/// <para><see cref="InAllowDuplicatesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object InAllowDuplicates { get; set; } = "false";

		/// <summary>
		/// <para>GeoNames Table Name</para>
		/// <para>The GeoNames table. This table should be in the working database.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Out feature class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>Out table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object OutTable { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Allow Duplicates</para>
		/// </summary>
		public enum InAllowDuplicatesEnum 
		{
			/// <summary>
			/// <para>Checked—Allows the tool to import features even if there is already an entry in the GeoNames feature class and table.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALLOW_DUPLICATES")]
			ALLOW_DUPLICATES,

			/// <summary>
			/// <para>Unchecked—Prevents the tool from importing features if there is another feature with the same geometry and attributes in the GeoNames feature class or GeoNames table. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DON'T_ALLOW_DUPLICATES")]
			@false,

		}

#endregion
	}
}
