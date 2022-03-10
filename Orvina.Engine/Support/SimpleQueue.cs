﻿namespace Orvina.Engine.Support
{
    /// <summary>
    /// small, efficient queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal sealed class SimpleQueue<T>
    {
        private int currentIdx;
        private T[] nodes;

        public SimpleQueue(int size = 0)
        {
            Reset(size);
        }

        public void Reset(int size = 0)
        {
            nodes = new T[size];
            currentIdx = -1;
        }

        public void Clear()
        {
            currentIdx = -1;
        }

        //public T[] ToArray
        //{
        //    get
        //    {
        //        var temp = new T[currentIdx + 1];
        //        Array.Copy(nodes, temp, temp.Length);
        //        return temp;
        //    }
        //}

        public bool Any
        {
            get
            {
                return Count > 0;
            }
        }

        public int Count
        {
            get
            {
                return currentIdx + 1;
            }
        }

        public T Dequeue()
        {
            var result = nodes[currentIdx];

            var desiredIdx = currentIdx - 1;

            //if (desiredIdx < (nodes.Length - 1) / 2) //need to shrink
            //{
            //    Array.Resize(ref nodes, desiredIdx + 1);
            //}

            currentIdx = desiredIdx;
            return result;
        }

        public void Enqueue(T value)
        {
            var desiredIdx = currentIdx + 1; //on first enqueu will be 0

            if (desiredIdx > nodes.Length - 1) //need to grow
            {
                //double size
                Array.Resize(ref nodes, (desiredIdx + 1) * 2);
            }

            nodes[desiredIdx] = value;
            currentIdx = desiredIdx;
        }

        public bool TryDequeue(out T value)
        {
            if (Any)
            {
                value = Dequeue();
                return true;
            }

            value = default(T);
            return false;
        }
    }
}