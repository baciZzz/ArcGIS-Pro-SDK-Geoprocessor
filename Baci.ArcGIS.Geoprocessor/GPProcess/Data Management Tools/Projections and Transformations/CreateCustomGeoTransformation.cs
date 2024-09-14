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
	/// <para>Create Custom Geographic Transformation</para>
	/// <para>Create Custom Geographic Transformation</para>
	/// <para>Creates a transformation method for converting data between two geographic coordinate systems or datums. The output of this tool can be used as a transformation method for any tool with a parameter that requires a geographic transformation.</para>
	/// </summary>
	public class CreateCustomGeoTransformation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="GeotName">
		/// <para>Geographic Transformation Name</para>
		/// <para>Name of the custom transformation method.</para>
		/// <para>All custom geographic transformation files are saved with a .gtf extension and stored in the ESRI\&lt;ArcGIS product&gt;\ArcToolbox\CustomTransformations folder in the user&apos;s Application Data folder. The CustomTransformations folder is created by the tool if it does not exist. If the Application Data folder is read-only or hidden, the output is created in ArcToolbox\CustomTransformations in the user&apos;s temp folder. The location or name of the Application Data and temp folders is dependent on the operating system.</para>
		/// <para>In any Windows operating system the Application Data folder is located in %appdata% and a user&apos;s Temp folder is located in %temp%. Entering %appdata% in a command window returns the Application Data folder location. Entering %temp% returns the temp folder location.</para>
		/// <para>In Unix systems, the tmp and Application Data folders are located in the user&apos;s home directory, under $HOME and $TMP, respectively. Typing /tmp in a terminal returns the location.</para>
		/// </param>
		/// <param name="InCoorSystem">
		/// <para>Input Geographic Coordinate System</para>
		/// <para>The starting geographic coordinate system.</para>
		/// </param>
		/// <param name="OutCoorSystem">
		/// <para>Output Geographic Coordinate System</para>
		/// <para>The final geographic coordinate system.</para>
		/// </param>
		/// <param name="CustomGeot">
		/// <para>Custom Geographic Transformation</para>
		/// <para>Select a transformation method from the drop-down list that will be used to transform the data from the input geographic coordinate system to the output geographic coordinate system. Once chosen, its parameters will appear in the table for editing.</para>
		/// </param>
		public CreateCustomGeoTransformation(object GeotName, object InCoorSystem, object OutCoorSystem, object CustomGeot)
		{
			this.GeotName = GeotName;
			this.InCoorSystem = InCoorSystem;
			this.OutCoorSystem = OutCoorSystem;
			this.CustomGeot = CustomGeot;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Custom Geographic Transformation</para>
		/// </summary>
		public override string DisplayName() => "Create Custom Geographic Transformation";

		/// <summary>
		/// <para>Tool Name : CreateCustomGeoTransformation</para>
		/// </summary>
		public override string ToolName() => "CreateCustomGeoTransformation";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateCustomGeoTransformation</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateCustomGeoTransformation";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { GeotName, InCoorSystem, OutCoorSystem, CustomGeot };

		/// <summary>
		/// <para>Geographic Transformation Name</para>
		/// <para>Name of the custom transformation method.</para>
		/// <para>All custom geographic transformation files are saved with a .gtf extension and stored in the ESRI\&lt;ArcGIS product&gt;\ArcToolbox\CustomTransformations folder in the user&apos;s Application Data folder. The CustomTransformations folder is created by the tool if it does not exist. If the Application Data folder is read-only or hidden, the output is created in ArcToolbox\CustomTransformations in the user&apos;s temp folder. The location or name of the Application Data and temp folders is dependent on the operating system.</para>
		/// <para>In any Windows operating system the Application Data folder is located in %appdata% and a user&apos;s Temp folder is located in %temp%. Entering %appdata% in a command window returns the Application Data folder location. Entering %temp% returns the temp folder location.</para>
		/// <para>In Unix systems, the tmp and Application Data folders are located in the user&apos;s home directory, under $HOME and $TMP, respectively. Typing /tmp in a terminal returns the location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object GeotName { get; set; }

		/// <summary>
		/// <para>Input Geographic Coordinate System</para>
		/// <para>The starting geographic coordinate system.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCoordinateSystem()]
		public object InCoorSystem { get; set; }

		/// <summary>
		/// <para>Output Geographic Coordinate System</para>
		/// <para>The final geographic coordinate system.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCoordinateSystem()]
		public object OutCoorSystem { get; set; }

		/// <summary>
		/// <para>Custom Geographic Transformation</para>
		/// <para>Select a transformation method from the drop-down list that will be used to transform the data from the input geographic coordinate system to the output geographic coordinate system. Once chosen, its parameters will appear in the table for editing.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object CustomGeot { get; set; } = "Null";

	}
}
