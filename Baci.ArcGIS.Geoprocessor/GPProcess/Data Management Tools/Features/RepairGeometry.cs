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
	/// <para>Repair Geometry</para>
	/// <para>Inspects each  feature in a feature class for problems with its geometry.  Upon discovery of a problem, a fix will be applied, and a one-line description will identify the feature, as well as the geometry problem that was fixed.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RepairGeometry : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The feature class or layer to be processed.</para>
		/// </param>
		public RepairGeometry(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Repair Geometry</para>
		/// </summary>
		public override string DisplayName => "Repair Geometry";

		/// <summary>
		/// <para>Tool Name : RepairGeometry</para>
		/// </summary>
		public override string ToolName => "RepairGeometry";

		/// <summary>
		/// <para>Tool Excute Name : management.RepairGeometry</para>
		/// </summary>
		public override string ExcuteName => "management.RepairGeometry";

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
		public override string[] ValidEnvironments => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, DeleteNull, OutFeatureClass, ValidationMethod };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The feature class or layer to be processed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Delete Features with Null Geometry</para>
		/// <para>Specifies whether features with null geometries will be deleted.</para>
		/// <para>Checked—Features with null geometry will be deleted from the input. This is the default.</para>
		/// <para>Unchecked—Features with null geometry will not be deleted from the input.</para>
		/// <para><see cref="DeleteNullEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DeleteNull { get; set; } = "true";

		/// <summary>
		/// <para>Repaired Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Validation Method</para>
		/// <para>Specifies which geometry validation method will be used to identify geometry problems.</para>
		/// <para>Esri—The Esri geometry validation method will be used. This is the default.</para>
		/// <para>OGC—The OGC geometry validation method will be used.</para>
		/// <para><see cref="ValidationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ValidationMethod { get; set; } = "ESRI";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RepairGeometry SetEnviroment(object extent = null , object workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Delete Features with Null Geometry</para>
		/// </summary>
		public enum DeleteNullEnum 
		{
			/// <summary>
			/// <para>Checked—Features with null geometry will be deleted from the input. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_NULL")]
			DELETE_NULL,

			/// <summary>
			/// <para>Unchecked—Features with null geometry will not be deleted from the input.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_NULL")]
			KEEP_NULL,

		}

		/// <summary>
		/// <para>Validation Method</para>
		/// </summary>
		public enum ValidationMethodEnum 
		{
			/// <summary>
			/// <para>Esri—The Esri geometry validation method will be used. This is the default.</para>
			/// </summary>
			[GPValue("ESRI")]
			[Description("Esri")]
			Esri,

			/// <summary>
			/// <para>OGC—The OGC geometry validation method will be used.</para>
			/// </summary>
			[GPValue("OGC")]
			[Description("OGC")]
			OGC,

		}

#endregion
	}
}
