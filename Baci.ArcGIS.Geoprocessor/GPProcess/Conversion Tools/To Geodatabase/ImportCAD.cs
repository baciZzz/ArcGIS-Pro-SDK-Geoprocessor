using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>Import from CAD</para>
	/// <para>Imports from one or more CAD files to a staging geodatabase.</para>
	/// </summary>
	[Obsolete()]
	public class ImportCAD : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFiles">
		/// <para>Input Files</para>
		/// </param>
		/// <param name="OutPersonalGdb">
		/// <para>Output Staging Geodatabase</para>
		/// </param>
		public ImportCAD(object InputFiles, object OutPersonalGdb)
		{
			this.InputFiles = InputFiles;
			this.OutPersonalGdb = OutPersonalGdb;
		}

		/// <summary>
		/// <para>Tool Display Name : Import from CAD</para>
		/// </summary>
		public override string DisplayName() => "Import from CAD";

		/// <summary>
		/// <para>Tool Name : ImportCAD</para>
		/// </summary>
		public override string ToolName() => "ImportCAD";

		/// <summary>
		/// <para>Tool Excute Name : conversion.ImportCAD</para>
		/// </summary>
		public override string ExcuteName() => "conversion.ImportCAD";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFiles, OutPersonalGdb, SpatialReference, ExplodeComplex };

		/// <summary>
		/// <para>Input Files</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputFiles { get; set; }

		/// <summary>
		/// <para>Output Staging Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object OutPersonalGdb { get; set; }

		/// <summary>
		/// <para>Spatial Reference</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>Explode Complex Objects</para>
		/// <para><see cref="ExplodeComplexEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExplodeComplex { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Explode Complex Objects</para>
		/// </summary>
		public enum ExplodeComplexEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("Explode_Complex")]
			Explode_Complex,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("Do_Not_Explode_Complex")]
			Do_Not_Explode_Complex,

		}

#endregion
	}
}
