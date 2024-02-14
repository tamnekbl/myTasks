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

namespace MyContainer
{
    
interface IEnumerator
{
    bool MoveNext();
    object? Current();
    void Reset();
}

interface IEnumerable
{
    IEnumerator GetIterator();
}

namespace MyStack
{
class Iterator<T> : IEnumerator
{
    private StackItem<T>? pCurItem;
    private MyStack<T> list;
    public Iterator(MyStack<T> _list) => list = _list;
    public object? Current() => pCurItem == null? null:pCurItem.data;

    public bool MoveNext()
    {
        if (list.StackPointer != null) 
        {
            if (pCurItem == null)
            {
                pCurItem = list.StackPointer;
                return true;
            }
            else if (pCurItem.PrevItem!=null)
            {
                pCurItem = pCurItem.PrevItem;
                return true;
            }
            else return false;
        }
        else return false;
    }

    public void Reset() => pCurItem = null;
}
record StackItem <T>
{
    public T? data;
    public StackItem<T>? PrevItem;

}

class MyStack<T> : IEnumerator, IEnumerable
{
    public StackItem<T>? StackPointer;
    private StackItem<T>? pCurItem;
    public MyStack()
    {
        StackPointer = null;
    }
    public void Push(T data)
    {
        StackItem<T>? pItem = new StackItem<T>();
        pItem.data = data;
        pItem.PrevItem = StackPointer;
        StackPointer = pItem;
    }
    public T? Pop () 
    {
        T? result = default(T);
        StackItem<T>? pPrevItem = new StackItem<T>();
        if (StackPointer!= null) 
        {
            result = StackPointer.data;
            pPrevItem = StackPointer.PrevItem;
            StackPointer = pPrevItem;
        } 
        return result;
        
    }
    
    public T? Head() =>StackPointer == null? default(T) : StackPointer.data;
    

    public bool MoveNext()
    {
        if (StackPointer != null)
        {
            if (pCurItem == null)
            {
                pCurItem = StackPointer;
                return true;
            }
            else if (pCurItem.PrevItem != null) return true;
            else return false;
        }
        else return false;
    }

    public object? Current() => pCurItem == null? null:pCurItem.data;
    public void Reset() => pCurItem = null;

    public IEnumerator GetIterator() => new Iterator<T>(this);
}
}
}