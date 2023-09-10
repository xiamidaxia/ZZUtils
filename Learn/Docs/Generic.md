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
## 范型的协变和逆变

https://blog.csdn.net/zp19860529/article/details/107712557
- 协变：父变量可以传入子变量，范型里用 out 表示，可以解决一个问题就是数组问题
- 逆变：子变量可以传入父变量，范型用 in 表示（不常用）
```
Fruit fruit = apple // 里氏替换原则，合法的
List<Fruit> fruits = new List<Apple>() // 不合法，Apple 虽然是子类，但List<Fruit> 和 List<Apple> 其实是两个类
interface IEnumerable<out T> {}
```