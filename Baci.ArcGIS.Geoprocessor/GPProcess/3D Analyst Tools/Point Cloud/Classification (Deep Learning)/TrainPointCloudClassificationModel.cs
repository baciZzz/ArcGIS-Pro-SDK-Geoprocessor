using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Train Point Cloud Classification Model</para>
	/// <para>Trains a deep learning model for point cloud classification using the PointCNN architecture.</para>
	/// </summary>
	public class TrainPointCloudClassificationModel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTrainingData">
		/// <para>Input Training Data</para>
		/// <para>The point cloud training data (*.pctd) that will be used to train the classification model.</para>
		/// </param>
		/// <param name="OutModelLocation">
		/// <para>Output Model Location</para>
		/// <para>The existing folder that will store the new directory containing the deep learning model.</para>
		/// </param>
		/// <param name="OutModelName">
		/// <para>Output Model Name</para>
		/// <para>The name of the output Esri model definition file (*.emd), deep learning package (*.dlpk), and the new directory that will be created to store them.</para>
		/// </param>
		public TrainPointCloudClassificationModel(object InTrainingData, object OutModelLocation, object OutModelName)
		{
			this.InTrainingData = InTrainingData;
			this.OutModelLocation = OutModelLocation;
			this.OutModelName = OutModelName;
		}

		/// <summary>
		/// <para>Tool Display Name : Train Point Cloud Classification Model</para>
		/// </summary>
		public override string DisplayName() => "Train Point Cloud Classification Model";

		/// <summary>
		/// <para>Tool Name : TrainPointCloudClassificationModel</para>
		/// </summary>
		public override string ToolName() => "TrainPointCloudClassificationModel";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TrainPointCloudClassificationModel</para>
		/// </summary>
		public override string ExcuteName() => "3d.TrainPointCloudClassificationModel";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "gpuID", "processorType" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTrainingData, OutModelLocation, OutModelName, PretrainedModel, Attributes, MinPoints, ClassRemap, TargetClasses, BackgroundClass, ClassDescriptions, ModelSelectionCriteria, MaxEpochs, EpochIterations, LearningRate, BatchSize, EarlyStop, OutModel, OutModelStats };

		/// <summary>
		/// <para>Input Training Data</para>
		/// <para>The point cloud training data (*.pctd) that will be used to train the classification model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("pctd")]
		public object InTrainingData { get; set; }

		/// <summary>
		/// <para>Output Model Location</para>
		/// <para>The existing folder that will store the new directory containing the deep learning model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutModelLocation { get; set; }

		/// <summary>
		/// <para>Output Model Name</para>
		/// <para>The name of the output Esri model definition file (*.emd), deep learning package (*.dlpk), and the new directory that will be created to store them.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutModelName { get; set; }

		/// <summary>
		/// <para>Pre-trained Model</para>
		/// <para>The pretrained model that will be refined. When a pretrained model is provided, the input training data must have the same attributes, class codes, and maximum number of points that were used by the training data that generated this model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("emd", "dlpk")]
		public object PretrainedModel { get; set; }

		/// <summary>
		/// <para>Attribute Selection</para>
		/// <para>Specifies the point attributes that will be used with the classification code when training the model. Only the attributes that are present in the point cloud training data will be available. No additional attributes are included by default.</para>
		/// <para>Intensity—The measure of the magnitude of the lidar pulse return will be used.</para>
		/// <para>Return Number—The ordinal position of the point obtained from a given lidar pulse will be used.</para>
		/// <para>Number of Returns—The total number of lidar returns that were identified as points from the pulse associated with a given point will be used.</para>
		/// <para>Red Band—The red band&apos;s value from a point cloud with color information will be used.</para>
		/// <para>Green Band—The green band&apos;s value from a point cloud with color information will be used.</para>
		/// <para>Blue Band—The blue band&apos;s value from a point cloud with color information will be used.</para>
		/// <para>Near Infrared Band—The near infrared band&apos;s value from a point cloud with near infrared information will be used.</para>
		/// <para><see cref="AttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Attributes { get; set; }

		/// <summary>
		/// <para>Minimum Points Per Block</para>
		/// <para>The minimum number of points that must be present in a given block for it to be used when training the model. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MinPoints { get; set; } = "0";

		/// <summary>
		/// <para>Class Remapping</para>
		/// <para>Defines how class code values will map to new values prior to training the deep learning model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Manage Classes")]
		public object ClassRemap { get; set; }

		/// <summary>
		/// <para>Class Codes Of Interest</para>
		/// <para>The class codes that will be used to filter the blocks in the training data. When class codes of interest are specified, all other class codes are remapped to the background class code.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Manage Classes")]
		public object TargetClasses { get; set; }

		/// <summary>
		/// <para>Background Class Code</para>
		/// <para>The class code value that will be used for all other class codes when class codes of interest have been specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		[Category("Manage Classes")]
		public object BackgroundClass { get; set; }

		/// <summary>
		/// <para>Class Description</para>
		/// <para>The descriptions of what each class code in the training data represents.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Manage Classes")]
		public object ClassDescriptions { get; set; }

		/// <summary>
		/// <para>Model Selection Criteria</para>
		/// <para>Specifies the statistical basis that will be used to determine the final model.</para>
		/// <para>Validation Loss—The model that achieves the lowest result when the entropy loss function is applied to the validation data will be selected.</para>
		/// <para>Recall—The model that achieves the best macro average of the recall for all class codes will be selected. Each class code&apos;s recall value is determined by the ratio of correctly classified points (true positives) over all the points that should have been classified with this value (expected positives). This is the default.</para>
		/// <para>F1 Score—The model that achieves the best harmonic mean between the macro average of the precision and recall values for all class codes will be selected. This provides a balance between precision and recall, which favors better overall performance.</para>
		/// <para>Precision—The model that achieves the best macro average of the precision for all class codes will be selected. Each class code&apos;s precision is determined by the ratio of points that are correctly classified (true positives) over all the points that are classified (true positives and false positives).</para>
		/// <para>Accuracy—The model that achieves the highest ratio of corrected classified points over all the points in the validation data will be selected.</para>
		/// <para><see cref="ModelSelectionCriteriaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Training Parameters")]
		public object ModelSelectionCriteria { get; set; } = "RECALL";

		/// <summary>
		/// <para>Maximum Number of Epochs</para>
		/// <para>The number of times each block of data is passed forward and backward through the neural network. The default is 25.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Training Parameters")]
		public object MaxEpochs { get; set; } = "25";

		/// <summary>
		/// <para>Iterations Per Epoch (%)</para>
		/// <para>The percentage of the data that is processed in each training epoch. The default is 100.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0.01, Max = 100)]
		[Category("Training Parameters")]
		public object EpochIterations { get; set; } = "100";

		/// <summary>
		/// <para>Learning Rate</para>
		/// <para>The rate at which existing information will be overwritten with new information. If no value is specified, the optimal learning rate will be extracted from the learning curve during the training process. This is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1e-10, Max = 0.99999999989999999)]
		[Category("Training Parameters")]
		public object LearningRate { get; set; }

		/// <summary>
		/// <para>Batch Size</para>
		/// <para>The number of training data blocks that will be processed at any given time. The default is 2.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 256)]
		[Category("Training Parameters")]
		public object BatchSize { get; set; } = "2";

		/// <summary>
		/// <para>Stop training when model no longer improves</para>
		/// <para>Specifies whether the model training will stop when the value specified for the Model Selection Criteria parameter does not register any improvement after 5 consecutive epochs.</para>
		/// <para>Checked—The model training will stop when the model is no longer improving. This is the default.</para>
		/// <para>Unchecked—The model training will continue until the maximum number of epochs has been reached.</para>
		/// <para><see cref="EarlyStopEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Training Parameters")]
		public object EarlyStop { get; set; } = "true";

		/// <summary>
		/// <para>Output Model</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object OutModel { get; set; }

		/// <summary>
		/// <para>Output Model Statistics</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object OutModelStats { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TrainPointCloudClassificationModel SetEnviroment()
		{
			base.SetEnv();
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Attribute Selection</para>
		/// </summary>
		public enum AttributesEnum 
		{
			/// <summary>
			/// <para>Intensity—The measure of the magnitude of the lidar pulse return will be used.</para>
			/// </summary>
			[GPValue("INTENSITY")]
			[Description("Intensity")]
			Intensity,

			/// <summary>
			/// <para>Return Number—The ordinal position of the point obtained from a given lidar pulse will be used.</para>
			/// </summary>
			[GPValue("RETURN_NUMBER")]
			[Description("Return Number")]
			Return_Number,

			/// <summary>
			/// <para>Number of Returns—The total number of lidar returns that were identified as points from the pulse associated with a given point will be used.</para>
			/// </summary>
			[GPValue("NUMBER_OF_RETURNS")]
			[Description("Number of Returns")]
			Number_of_Returns,

			/// <summary>
			/// <para>Red Band—The red band&apos;s value from a point cloud with color information will be used.</para>
			/// </summary>
			[GPValue("RED")]
			[Description("Red Band")]
			Red_Band,

			/// <summary>
			/// <para>Green Band—The green band&apos;s value from a point cloud with color information will be used.</para>
			/// </summary>
			[GPValue("GREEN")]
			[Description("Green Band")]
			Green_Band,

			/// <summary>
			/// <para>Blue Band—The blue band&apos;s value from a point cloud with color information will be used.</para>
			/// </summary>
			[GPValue("BLUE")]
			[Description("Blue Band")]
			Blue_Band,

			/// <summary>
			/// <para>Near Infrared Band—The near infrared band&apos;s value from a point cloud with near infrared information will be used.</para>
			/// </summary>
			[GPValue("NEAR_INFRARED")]
			[Description("Near Infrared Band")]
			Near_Infrared_Band,

		}

		/// <summary>
		/// <para>Model Selection Criteria</para>
		/// </summary>
		public enum ModelSelectionCriteriaEnum 
		{
			/// <summary>
			/// <para>Validation Loss—The model that achieves the lowest result when the entropy loss function is applied to the validation data will be selected.</para>
			/// </summary>
			[GPValue("VALIDATION_LOSS")]
			[Description("Validation Loss")]
			Validation_Loss,

			/// <summary>
			/// <para>Recall—The model that achieves the best macro average of the recall for all class codes will be selected. Each class code&apos;s recall value is determined by the ratio of correctly classified points (true positives) over all the points that should have been classified with this value (expected positives). This is the default.</para>
			/// </summary>
			[GPValue("RECALL")]
			[Description("Recall")]
			Recall,

			/// <summary>
			/// <para>F1 Score—The model that achieves the best harmonic mean between the macro average of the precision and recall values for all class codes will be selected. This provides a balance between precision and recall, which favors better overall performance.</para>
			/// </summary>
			[GPValue("F1_SCORE")]
			[Description("F1 Score")]
			F1_Score,

			/// <summary>
			/// <para>Precision—The model that achieves the best macro average of the precision for all class codes will be selected. Each class code&apos;s precision is determined by the ratio of points that are correctly classified (true positives) over all the points that are classified (true positives and false positives).</para>
			/// </summary>
			[GPValue("PRECISION")]
			[Description("Precision")]
			Precision,

			/// <summary>
			/// <para>Accuracy—The model that achieves the highest ratio of corrected classified points over all the points in the validation data will be selected.</para>
			/// </summary>
			[GPValue("ACCURACY")]
			[Description("Accuracy")]
			Accuracy,

		}

		/// <summary>
		/// <para>Stop training when model no longer improves</para>
		/// </summary>
		public enum EarlyStopEnum 
		{
			/// <summary>
			/// <para>Checked—The model training will stop when the model is no longer improving. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EARLY_STOP")]
			EARLY_STOP,

			/// <summary>
			/// <para>Unchecked—The model training will continue until the maximum number of epochs has been reached.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_EARLY_STOP")]
			NO_EARLY_STOP,

		}

#endregion
	}
}
