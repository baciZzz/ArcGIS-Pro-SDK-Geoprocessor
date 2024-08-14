using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Create Big Data Connection</para>
	/// <para>Creates a big data connection file (.bdc) and item. Datasets registered in a big data connection (BDC) can be used as input to GeoAnalytics Desktop tools and other geoprocessing tools.</para>
	/// </summary>
	public class CreateBDC : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="BdcLocation">
		/// <para>Big Data Connection Output Location</para>
		/// <para>The folder where the .bdc file will be created.</para>
		/// </param>
		/// <param name="BdcName">
		/// <para>Output Big Data Connection Name</para>
		/// <para>The name of the .bdc file to be created.</para>
		/// </param>
		/// <param name="ConnectionType">
		/// <para>Connection Type</para>
		/// <para>Specifies the type of connection to be created.</para>
		/// <para>Folder—Connect to a file system location. This is the default.</para>
		/// <para><see cref="ConnectionTypeEnum"/></para>
		/// </param>
		public CreateBDC(object BdcLocation, object BdcName, object ConnectionType)
		{
			this.BdcLocation = BdcLocation;
			this.BdcName = BdcName;
			this.ConnectionType = ConnectionType;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Big Data Connection</para>
		/// </summary>
		public override string DisplayName => "Create Big Data Connection";

		/// <summary>
		/// <para>Tool Name : CreateBDC</para>
		/// </summary>
		public override string ToolName => "CreateBDC";

		/// <summary>
		/// <para>Tool Excute Name : gapro.CreateBDC</para>
		/// </summary>
		public override string ExcuteName => "gapro.CreateBDC";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { BdcLocation, BdcName, ConnectionType, DataSourceFolder, VisibleGeometry, VisibleTime, OutputBdc };

		/// <summary>
		/// <para>Big Data Connection Output Location</para>
		/// <para>The folder where the .bdc file will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object BdcLocation { get; set; }

		/// <summary>
		/// <para>Output Big Data Connection Name</para>
		/// <para>The name of the .bdc file to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object BdcName { get; set; }

		/// <summary>
		/// <para>Connection Type</para>
		/// <para>Specifies the type of connection to be created.</para>
		/// <para>Folder—Connect to a file system location. This is the default.</para>
		/// <para><see cref="ConnectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConnectionType { get; set; } = "FOLDER";

		/// <summary>
		/// <para>Data Source Folder</para>
		/// <para>The folder containing the datasets to be registered with the BDC.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object DataSourceFolder { get; set; }

		/// <summary>
		/// <para>Visible Geometry Fields</para>
		/// <para>Specifies whether the fields used to specify the geometry will be visible as fields when the BDC file is used as input to other geoprocessing tools. When the geometry fields are not visible, geometry is still applied to the dataset. The geometry visibility setting can be modified in the BDC.</para>
		/// <para>Checked—Geometry fields will be included as fields for analysis. This is the default.</para>
		/// <para>Unchecked—Geometry fields will not be included as fields for analysis.</para>
		/// <para><see cref="VisibleGeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object VisibleGeometry { get; set; } = "true";

		/// <summary>
		/// <para>Visible Time Fields</para>
		/// <para>Specifies whether the fields used to specify the time will be visible as fields when the BDC file is used as input to other geoprocessing tools. When the time fields are not visible, time is still applied to the dataset. The time visibility setting can be modified in the BDC.</para>
		/// <para>Checked—Time fields will be included as fields for analysis. This is the default.</para>
		/// <para>Unchecked—Time fields will not be included as fields for analysis.</para>
		/// <para><see cref="VisibleTimeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object VisibleTime { get; set; } = "true";

		/// <summary>
		/// <para>Output BDC</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		[GPFileDomain()]
		public object OutputBdc { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Connection Type</para>
		/// </summary>
		public enum ConnectionTypeEnum 
		{
			/// <summary>
			/// <para>Folder—Connect to a file system location. This is the default.</para>
			/// </summary>
			[GPValue("FOLDER")]
			[Description("Folder")]
			Folder,

		}

		/// <summary>
		/// <para>Visible Geometry Fields</para>
		/// </summary>
		public enum VisibleGeometryEnum 
		{
			/// <summary>
			/// <para>Checked—Geometry fields will be included as fields for analysis. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GEOMETRY_VISIBLE")]
			GEOMETRY_VISIBLE,

			/// <summary>
			/// <para>Unchecked—Geometry fields will not be included as fields for analysis.</para>
			/// </summary>
			[GPValue("false")]
			[Description("GEOMETRY_NOT_VISIBLE")]
			GEOMETRY_NOT_VISIBLE,

		}

		/// <summary>
		/// <para>Visible Time Fields</para>
		/// </summary>
		public enum VisibleTimeEnum 
		{
			/// <summary>
			/// <para>Checked—Time fields will be included as fields for analysis. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("TIME_VISIBLE")]
			TIME_VISIBLE,

			/// <summary>
			/// <para>Unchecked—Time fields will not be included as fields for analysis.</para>
			/// </summary>
			[GPValue("false")]
			[Description("TIME_NOT_VISIBLE")]
			TIME_NOT_VISIBLE,

		}

#endregion
	}
}
