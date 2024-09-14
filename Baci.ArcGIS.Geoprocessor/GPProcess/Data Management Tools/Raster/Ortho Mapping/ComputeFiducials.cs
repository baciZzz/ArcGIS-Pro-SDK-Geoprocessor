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
	/// <para>Compute Fiducials</para>
	/// <para>Compute Fiducials</para>
	/// <para>Computes the fiducial coordinates in image and film space for each image in a mosaic dataset.</para>
	/// </summary>
	public class ComputeFiducials : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset created from scanned aerial photos using scanned raster type or frame camera raster type.</para>
		/// </param>
		/// <param name="OutFiducialTable">
		/// <para>Output Fiducial Table</para>
		/// <para>The output table that stores all the fiducial coordinate information in image and film space.</para>
		/// </param>
		public ComputeFiducials(object InMosaicDataset, object OutFiducialTable)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.OutFiducialTable = OutFiducialTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Compute Fiducials</para>
		/// </summary>
		public override string DisplayName() => "Compute Fiducials";

		/// <summary>
		/// <para>Tool Name : ComputeFiducials</para>
		/// </summary>
		public override string ToolName() => "ComputeFiducials";

		/// <summary>
		/// <para>Tool Excute Name : management.ComputeFiducials</para>
		/// </summary>
		public override string ExcuteName() => "management.ComputeFiducials";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, OutFiducialTable, WhereClause!, FiducialTemplates!, FilmCoordinateSystem! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset created from scanned aerial photos using scanned raster type or frame camera raster type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Output Fiducial Table</para>
		/// <para>The output table that stores all the fiducial coordinate information in image and film space.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutFiducialTable { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>A query definition string that defines a subset of rasters for computing fiducials.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Fiducial Templates</para>
		/// <para>The fiducial template table that contains required fields for storing fiducial pictures and other properties.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? FiducialTemplates { get; set; }

		/// <summary>
		/// <para>Film Coordinate System</para>
		/// <para>A keyword that defines the film coordinate system of the scanned aerial photograph. It is used in computing fiducial information and affine transformation construction.</para>
		/// <para>No change—Maintain the coordinate system of the mosaic dataset. Do not change the film coordinate system of the scanned aerial photograph. Maintain the coordinate system of the mosaic dataset.</para>
		/// <para>X right, Y up—The origin of the scanned photo&apos;s coordinate system is the center, and positive X points right and positive Y points up.</para>
		/// <para>X up, Y left—The origin of the scanned photo&apos;s coordinate system is the center, and positive X points up and positive Y points left.</para>
		/// <para>X left, Y down—The origin of the scanned photo&apos;s coordinate system is the center, and positive X points left and positive Y points down.</para>
		/// <para>X down, Y right—The origin of the scanned photo&apos;s coordinate system is the center, and positive X points down and positive Y points right.</para>
		/// <para><see cref="FilmCoordinateSystemEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FilmCoordinateSystem { get; set; } = "NO_CHANGE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ComputeFiducials SetEnviroment(object? parallelProcessingFactor = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Film Coordinate System</para>
		/// </summary>
		public enum FilmCoordinateSystemEnum 
		{
			/// <summary>
			/// <para>No change—Maintain the coordinate system of the mosaic dataset. Do not change the film coordinate system of the scanned aerial photograph. Maintain the coordinate system of the mosaic dataset.</para>
			/// </summary>
			[GPValue("NO_CHANGE")]
			[Description("No change")]
			No_change,

			/// <summary>
			/// <para>X right, Y up—The origin of the scanned photo&apos;s coordinate system is the center, and positive X points right and positive Y points up.</para>
			/// </summary>
			[GPValue("X_RIGHT_Y_UP")]
			[Description("X right, Y up")]
			X_RIGHT_Y_UP,

			/// <summary>
			/// <para>X up, Y left—The origin of the scanned photo&apos;s coordinate system is the center, and positive X points up and positive Y points left.</para>
			/// </summary>
			[GPValue("X_UP_Y_LEFT")]
			[Description("X up, Y left")]
			X_UP_Y_LEFT,

			/// <summary>
			/// <para>X left, Y down—The origin of the scanned photo&apos;s coordinate system is the center, and positive X points left and positive Y points down.</para>
			/// </summary>
			[GPValue("X_LEFT_Y_DOWN")]
			[Description("X left, Y down")]
			X_LEFT_Y_DOWN,

			/// <summary>
			/// <para>X down, Y right—The origin of the scanned photo&apos;s coordinate system is the center, and positive X points down and positive Y points right.</para>
			/// </summary>
			[GPValue("X_DOWN_Y_RIGHT")]
			[Description("X down, Y right")]
			X_DOWN_Y_RIGHT,

		}

#endregion
	}
}
