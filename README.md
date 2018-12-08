# 语言基础
# 数据结构
# 算法
# 设计模式
# 计算机网络
# 项目经验
##  1. 游戏优化
### UGUI优化
1. 图集优化
- 整理公用图集，原则为：各个界面公用且需要动态加载
- 以界面为单位拆分图集，界面不引用其他界面的图集
- 删除冗余的资源
- 统一图片的压缩格式，避免分Group导致的部分图集空白区域较多
- 可以进行九宫格拉伸的图片，尺寸缩小
- 可以平铺的贴图，尺寸缩小
2. DrawCall优化
- 减少Canvas下面的图集数量
- 避免不需要重叠的UI元素发生重叠
- 慎用Mask
3. OverDraw优化
- 使用Polygon Mode Sprites代替传统的矩形
- Image的FillCenter在适当情况下取消勾选
- 隐藏完全被遮挡的UI界面
- 不要使用空的Image来监听事件，使用脚本
4. Mesh重建优化
- 慎用Text的BestFit和Canvas的Pixel Perfect
- 慎用UI元素的Enable和Disable，替换方案是Enable和Disable UI元素的CanvasRenderer或者Canvas
- 修改组件的Color属性也会导致重绘，修改材质的tint属性
- 动静分离
5. 内存优化和事件监听
- 图集优化
- 游戏内UI和外围的图集分离，减少游戏内的内存
- 透明图集和非透明图集分离
- 不需要监听事件UI的元素禁用Raycast Target
### CPU优化
1. 降低Drawcall
- StaticBatching, DynamicBatching, GPUInstancing
### GPU优化
#### 1. 渲染分级：
1. 模型LOD 
2. ShaderLOD 
3. Mipmap
4. Shadowmap精度
5. 开关后处理
#### 2. Shader优化
1. Only compute what you need.去除无用的Shader属性和计算.
2. Precision of computations.
-    For world space positions and texture coordinates, use float precision.
-    For everything else (vectors, HDR colors, etc.), start with half precision. Increase only if necessary.
-    For very simple operations on texture data, use fixed precision.   
(Ps:Fixed precision is generally only useful for older mobile GPUs. Most modern GPUs (the ones that can run OpenGL ES 3 or Metal) internally treat fixed and half precision exactly the same.)
3. 慎用AlphaTest和ColorMask.
4. [Seven key shader optimizations](https://unity3d.com/cn/how-to/shader-profiling-and-optimization-tips)

### 内存优化
[Unity内存优化之美术资源篇](http://gad.qq.com/article/detail/29272)   
[Unity游戏开发图片纹理压缩方案](https://zhuanlan.zhihu.com/p/25205686)   
[GC优化](https://blog.csdn.net/worisaa/article/details/64121436)
### 资源优化
## 2. 渲染基础

## 3. 游戏框架和工具集
### UI框架
![image](https://github.com/lingllting/KnowledgeArchitecture/blob/master/Assets/Pictures/UIFramework1.jpg)
