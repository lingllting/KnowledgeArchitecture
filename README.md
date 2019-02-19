# 语言基础
1. 《CLR via C#》
# 数学基础
1. 《3D游戏与计算机图形学中的数学方法》
# [数据结构](https://www.cnblogs.com/zhan520g/p/10201822.html)
## 数组
1. [寻找数组中第二小的元素](https://blog.csdn.net/gx864102252/article/details/82596911)
## 栈
## 队列
## 链表
### [单链表](https://www.cnblogs.com/caokai520/p/4334453.html)
1. [判断一个单链表是否有环](https://www.cnblogs.com/dancingrain/p/3405197.html)
2. [反转单链表](https://www.cnblogs.com/byrhuangqiang/p/4311336.html)
### 双链表

## 树
### 二叉树
### 平衡二叉树
### 完全二叉树
### 二叉搜索树
### 红黑树
### B树，B+树
## 散列表
## 图
### 深度优先遍历和广度优先遍历的思想
### 有向图的邻接矩阵
### 无向图的邻接矩阵
### 有向图的邻接表
### 无向图的邻接表

# 算法
## 排序算法
### [排序算法总结](https://github.com/lingllting/KnowledgeArchitecture/blob/master/Assets/Scripts/SortAlgorithm.cs)

# 设计模式
# 计算机网络
# 项目经验
##  1. 游戏优化
### 工具使用
- IOS
    - Unity Profiler（CPU、资源、内存）、Frame Debugger
    - [Xcode Instrument（CPU）](https://blogs.unity3d.com/2016/02/01/profiling-with-instruments/)
    - [Xcode Frame Capture（GPU）](https://developer.apple.com/documentation/metal/tools_profiling_and_debugging/viewing_performance_metrics_with_gpu_counters) 
- Android
    - Unity Profiler（CPU、资源、内存）、Frame Debugger
    - Snapdragon Profiler（GPU）
    - [Mali Graphics Debugger (GPU)](https://www.jianshu.com/p/35096e796aa3)
    - UWA GOT（CPU、资源）
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
- [使用Polygon Mode Sprites代替传统的矩形](https://blog.uwa4d.com/archives/fillrate.html)
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
#### 1.降低Drawcall
- Static Batch 针对静态场景物件
- Dynamic Batch 针对动态物体，有顶点数限制。透明物体需要注意，排序可能会打断Batch，要手动设置RenderQueue让相同材质的物体一起渲染（Mesh粒子无法batch，粒子在真机上无法batch）
- GPU Instancing （目前用于荧光棒、同组的体积光等，不适用于SkinnedMeshRender）
- 角色模型材质较为复杂，考虑运行时合并一个新的模型用来渲染描边、阴影等（测试下来CPU时间几乎一样，GPU渲染阴影有10%的提升，提升不大，性价比低，暂不考虑）

#### [2.脚本代码优化](http://wuzhiwei.net/unity_script_optimization)
- 去除不必要的Update、OnGUI等内置函数
- Shader.PropertyToID、Animator.StringToHash
- 弹簧球根据机型关闭或者降低更新频率
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
5. 减少采样纹理数量，例如贴图通道合并或者用公式或者数组代替贴图（如角色Ramp贴图）

#### 3. 降低显存带宽
- 降低屏幕分辨率（简单、效果明显）
- 降低贴图尺寸（尤其是特效贴图）
- MipMap

### 内存优化
[Unity内存优化之美术资源篇](http://gad.qq.com/article/detail/29272)   
[Unity游戏开发图片纹理压缩方案](https://zhuanlan.zhihu.com/p/25205686)   
[GC优化](https://blog.csdn.net/worisaa/article/details/64121436)  
[动画文件压缩](http://note.youdao.com/noteshare?id=000d6313215e5a96549c6e1d01055516&sub=D31EB54C57624E0DAB4AB325CC60EA4B)

## 2. 渲染基础

## 3. 游戏框架和工具集
### UI框架
![image](https://github.com/lingllting/KnowledgeArchitecture/blob/master/Assets/Pictures/UIFramework1.jpg)

### 实用插件

## 4. 资源管理
### 资源打包
1. Shader打包
2. 
