# Base

## 数组

- Array: new string[2] 固定 长度
- ArrayList: 采用链表（频繁修改会存在碎片化）, 转换成 object，会带来性能损耗
- List<>: 范型，如果指定object 则和 ArrayList 无区别

## property

```
public string Name { get, private set }

new ProductName { Name = 3 } // 能在私有无参数构造函数中使用，更加简单
```

## 匿名类型

- join 和 join2 其实是同一个类型，编译器会自己推断，这样 `join2 = join` 是允许的
```csharp
var join = new { Name = "abc", Age = 3}
var join2 = new { Name = "abc", Age = 3}
Console.WriteLine(join.Name)
join2 = join // 这是允许的
```

## 扩展方法

```csharp
string a = "abc".Reverse()
```

## 不同的初始化方式

```csharp
// 调用无参构造函数
public struct Foo {
    public int Value { get; private set; }
    public Foo(int value): this() 
    {
        this.Value = value;
    }
}
// 表达式构造
var tom = new Person("Tom")
{
    Age = 9,
    Home = { Country = "UK", Town = "Reading "}
}
// 集合初始化
var names = new List<string>
{
    "Holly", "Jon", "Tom"
}
var dic = new Dictonary<string, int>
{
    { "Holly", 36 },
    { "Jon", 8}
}
// 数组初始化

string [] names = { "Holly", "Jon"}

// 参数中
MyMethod(new string[] { "Holly", "jon"} )
MyMethod(new[] { "Holly", "jon"} )

// 匿名类型
var tom = new { Name = "Tom", Age = 9};
```
