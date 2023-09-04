# Unity 学习笔记


## 其他

- Int.MaxValue + 1 = Inv.MinValue（有符号，溢出）
- 尽量避免 object 作为参数，可以用范型替代，值类型赋值给object 参数会产生装箱(boxing)
- 类的静态变量只有在第一次调用时候才会创建内存空间
- Random.InitState(seed) 用当前时间重置随机种子，避免碰撞
- unity 是左手坐标
- 生产环境去掉 Debug.Log
```csharp
// 封装 Debug.Log
[Conditional("Debug")]
Public void MyLog(...) { Debug.Log(...) }
```


## 渲染
- A 是标准不透明材质，B完全在后边(相机视角), 
- Overdraw 如何避免
- 相机一般放在 LaterUpdate
- Camera.main 是耗时的，因为在游戏中是会动态变化，所以采用 FindGameObjectsWithTag
- Mask 和 RectMask2D 什么区别
- 前向渲染和延迟渲染区别
- ugui 来制作雪条，在同一个CameraMode 下，血条是可以合批的


## 物理引擎

- BoxCollider + rigidBody 才能触发碰撞

## 向量计算

- 四元数 和 欧拉角是啥 ？
- 结构体赋值无效
```csharp
transform.position.x = 3
```
- 向量乘法优化 + 向量单位化
```csharp
// 1. 向量乘法效率很低，如果后边不加括号，会触发向量乘法两次
// 2. Nomalized 不能漏掉，加上才能代表方向
transform.position = (targetPosition - transform.position).Nomalized * (speed * deltaTime)
```
- 时间
  - Time.unscaledDeltaTime 上一帧到这一帧准确的时间间隔
  - Time.deltaTime: Time.unscaledDeltaTime * Time.timeScale
  - Time.time 游戏运行当中的时间
  - Time.realTimeSinceStartUp 真实时间

- 距离检查
```csharp
float distance = Vector3.Distace(target, transform.position); // 效率很低, 会开平方
if (distance > 2.0f) { }

flow distance2 = Vector3.SqrMagnitud(target, transform.position) // 求平方，这样就少了一个开平计算
if (distance > 2.0f * 2) {}
```

## 性能

- 优化反射
```csharp
MethodInfo methodInfo = Type.GetMethodInfo();
Delegate invoDel = Delegate.CreateDelegate(methodInfo);
// 保存invoDel，之后痛殴invoDel.Invoke() 效率更高，因为本质是通过委托直接调用
```
- monobehaviour 慢是因为它的生命周期函数是通过反射来调用的
- 可变参数会产生new，gc，用范型罗列性能更高
- 隐藏物体
  - 通过移动物体位置到很远比 setActive(false) 更好, 因为 setActive 会调用 onDisable/onEnable, 同时 update/laterUpdate 清0， 且是所有的子节点递归调用, 不过移动物体是不会禁止 update 需要自己权衡
  - 更好的方式：修改gameObject 的layer , 是物体在相机的 Culling Mask 之外
  - 更好的方式: MeshRenderer.enabled = false/true 
  - 多个状态的叠加，用enum 位来做叠加，比状态数组性能更好
- List 初始化时候可以先给一个长度，不然list长度不够就会产生一次内存分配并产生gc, 同样 字典也是
