/*Задача 2. Реализуйте стек*/


using System.Collections;
using System.Runtime.Intrinsics.X86;

Stack<char> chars = new Stack<char>();


record StackItem <T>
{
    public T data;
    public StackItem<T>? PrevItem;

}

class Stack<T> : IEnumerator<T>, IEnumerable<T>
{
    private StackItem<T>? StackPointer;
    private StackItem<T>? pCurItem;
    public Stack()
    {
        StackPointer = null;
    }
    public void Push(T data)
    {
        throw new NotImplementedException();
    }
    public T Pop () 
    {
        throw new NotImplementedException();
    }
    public bool MoveNext()
    {
        throw new NotImplementedException();
    }
    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }


    public void Reset()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public T Current => pCurItem.data;

    object IEnumerator.Current => throw new NotImplementedException();
}



