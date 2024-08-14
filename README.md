# ArcGIS Pro SDK Geoprocessor

#### 介绍
在ArcGIS Pro SDK(2.8)中仿 ArcGIS Engine 中的Geoprocessor、IGPProcess。


## 实现
1. 2.8版本下的所有工具的生成，包括已过时的工具(1808个).
2. 方法、参数、枚举的`注释`，翻译（机翻,有官方自带的中文翻译，但是似乎没有覆盖所有的gp工具？46：32）。
3. 提供工具`各自支持`的环境变量设置。
4. 参数`是否可选`特性，默认值。
5. `必填参数`的`有参构造`方法。
6. 数据类型为`字符串`或`布尔类型`的参数新增了对应的枚举类。

## 待完善
1. 高版本的工具,有其他版本的需要请联系。

## 示例

```
using Baci.ArcGIS;
using Baci.ArcGIS.ConversionTools;

 await new FeatureClassToFeatureClass()
 {
     _in_features = @"C:\Users\baci\Documents\ArcGIS\Default.gdb\Export_Output",
     _out_path = @"C:\Users\baci\Documents\ArcGIS\Default.gdb",
     _out_name = "Export_Output_666"
 }.SetEnv(outputCoordinateSystem: "4490").Run();

```



