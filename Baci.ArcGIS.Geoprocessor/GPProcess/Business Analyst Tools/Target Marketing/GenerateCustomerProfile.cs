using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.BusinessAnalystTools
{
	/// <summary>
	/// <para>Generate Customer Segmentation Profile</para>
	/// <para>Generate Customer Segmentation Profile</para>
	/// <para>Creates a segmentation profile with an existing customer layer.</para>
	/// </summary>
	public class GenerateCustomerProfile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCustomersLayer">
		/// <para>Customer Layer</para>
		/// <para>The input point feature class that represents existing customers.</para>
		/// </param>
		/// <param name="InSegmentationBase">
		/// <para>Segmentation Base</para>
		/// <para>The segmentation base for the profile being created. Available options are provided by the segmentation dataset in use.</para>
		/// </param>
		/// <param name="OutProfile">
		/// <para>Output Profile</para>
		/// <para>The name of the segmentation profile file to be created.</para>
		/// </param>
		public GenerateCustomerProfile(object InCustomersLayer, object InSegmentationBase, object OutProfile)
		{
			this.InCustomersLayer = InCustomersLayer;
			this.InSegmentationBase = InSegmentationBase;
			this.OutProfile = OutProfile;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Customer Segmentation Profile</para>
		/// </summary>
		public override string DisplayName() => "Generate Customer Segmentation Profile";

		/// <summary>
		/// <para>Tool Name : GenerateCustomerProfile</para>
		/// </summary>
		public override string ToolName() => "GenerateCustomerProfile";

		/// <summary>
		/// <para>Tool Excute Name : ba.GenerateCustomerProfile</para>
		/// </summary>
		public override string ExcuteName() => "ba.GenerateCustomerProfile";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise() => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "baDataSource", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCustomersLayer, InSegmentationBase, OutProfile, InVolumeField };

		/// <summary>
		/// <para>Customer Layer</para>
		/// <para>The input point feature class that represents existing customers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InCustomersLayer { get; set; }

		/// <summary>
		/// <para>Segmentation Base</para>
		/// <para>The segmentation base for the profile being created. Available options are provided by the segmentation dataset in use.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InSegmentationBase { get; set; }

		/// <summary>
		/// <para>Output Profile</para>
		/// <para>The name of the segmentation profile file to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("sgprofile")]
		public object OutProfile { get; set; }

		/// <summary>
		/// <para>Volume Info Field</para>
		/// <para>The field containing volume information from which the profile can optionally be created. For example, you can create a profile using the sales for each customer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double", "Float", "Long", "Short")]
		public object InVolumeField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateCustomerProfile SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
