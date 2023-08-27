# 范型

##  早期的参数传递问题

如果参数为object为引用是在堆里, 但是3是在栈里，会出现装箱问题
```csharp

function void Sum(object some) {}

Sum(3)
```

## 范型特点
- 不会写死类型
- 延迟声明：把参数的类型声明推迟到调用

## 范型

```
- where T: IPoint // 类型约束，不能是 seald 密封类
- where T: class // 引用类型 
- where T: struct // 值类型
- where T: new() // 无参数构造函数, 可以使用 new T()
- default(T): // 获取默认值
```