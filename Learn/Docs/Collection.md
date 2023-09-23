# 集合

## 惰性求值

https://pythonjishu.com/ttnoeiwviazqzjo/

```csharp
static IEnumerable<int> MyRange(int start, int end)
{
    for (int i = start; i < end; i++)
    {
        yield return i;
    }
}

var numbers = Myrange(1, 11);

foreach (var number in numbers)
{
    Console.WriteLine(number);
}
```