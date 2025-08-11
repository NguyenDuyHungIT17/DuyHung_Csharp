using System;

class Arr<T>
{
    public T Value { get; set; }
    public Arr(T value) => Value = value;
    public void Show() => Console.WriteLine($"Giá trị: {Value}");
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        Arr<int> box1 = new Arr<int>(123);
        box1.Show();

        Arr<string> box2 = new Arr<string>("Hello Generics");
        box2.Show();
    }
}
