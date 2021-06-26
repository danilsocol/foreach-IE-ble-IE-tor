using System;
using System.Collections.Generic;

namespace foreach_IE_ble_IE_tor // не работает
{   
    public class Queue<T> : IEnumerable<T>
    {
		public virtual IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public QueueItem<T> Head { get; private set; }
		QueueItem<T> tail;

		public bool IsEmpty { get { return Head == null; } }

		public void Enqueue(T value)
		{
			if (IsEmpty)
				tail = Head = new QueueItem<T> { Value = value, Next = null };
			else
			{
				var item = new QueueItem<T> { Value = value, Next = null };
				tail.Next = item;
				tail = item;
			}
		}

		public T Dequeue()
		{
			if (Head == null) throw new InvalidOperationException();
			var result = Head.Value;
			Head = Head.Next;
			if (Head == null)
				tail = null;
			return result;
		}
	}

    public class QueueEnumerator<T> : IEnumerator<T>
    {
		Queue<T> queue;
		QueueItem<T> currentItem;

		public QueueEnumerator(Queue<T> queue)
		{
			this.queue = queue;
			this.currentItem = null;
		}

		public T Current
		{
			get { return currentItem.Value; }
		}

		public bool MoveNext()
		{
			if (currentItem == null)
				currentItem = queue.Head;
			else
				currentItem = currentItem.Next;
			return currentItem != null;
		}
		public void Dispose()
		{

		}
		object System.Collections.IEnumerator.Current
		{
			get { return Current; }
		}
		public void Reset()
		{

		}
	}
	public class QueueItem<T>
	{
		public T Value { get; set; }
		public QueueItem<T> Next { get; set; }
	}
	class Program
    {
        static void Main(string[] args)
        {
			Queue<int> queue = new Queue<int>();
			queue.Enqueue(2);
			queue.Enqueue(3);
			queue.Enqueue(4);
            queue.Enqueue(5);

            foreach (var item in queue)
            {
				Console.WriteLine(item);
            }
        }
    }
}
