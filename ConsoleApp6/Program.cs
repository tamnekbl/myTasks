/*Задача 2. Реализуйте стек*/

using MyContainer.MyStack;
using MyContainer;


MyStack<char> chars = new MyStack<char>();
string? s;
s = Console.ReadLine();
if (s!= null)
    for (int i = 0; i < s.Length; i++) chars.Push(s[i]); 

Print<char> (chars);


void Print<T>(MyStack<T> stack)
{
    IEnumerator iterator = stack.GetIterator();
    Console.Write("Содержимое стэка: ");
    if (iterator != null)
    {
        while (iterator.MoveNext()) Console.Write(iterator.Current());
        Console.WriteLine();
    }
}

