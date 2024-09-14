using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Multi Output Map Algebra</para>
	/// <para>Multi Output Map Algebra</para>
	/// <para>Execute Grid's map algebra statements.</para>
	/// </summary>
	[Obsolete()]
	public class MultiOutputMapAlgebra : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="ExpressionString">
		/// <para>expression_string</para>
		/// </param>
		public MultiOutputMapAlgebra(object ExpressionString)
		{
			this.ExpressionString = ExpressionString;
		}

		/// <summary>
		/// <para>Tool Display Name : Multi Output Map Algebra</para>
		/// </summary>
		public override string DisplayName() => "Multi Output Map Algebra";

		/// <summary>
		/// <para>Tool Name : MultiOutputMapAlgebra</para>
		/// </summary>
		public override string ToolName() => "MultiOutputMapAlgebra";

		/// <summary>
		/// <para>Tool Excute Name : sa.MultiOutputMapAlgebra</para>
		/// </summary>
		public override string ExcuteName() => "sa.MultiOutputMapAlgebra";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { ExpressionString };

		/// <summary>
		/// <para>expression_string</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAMapAlgebraExp()]
		public object ExpressionString { get; set; }

	}
}
