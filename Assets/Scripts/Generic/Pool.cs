using System.Collections.Generic;
using UnityEngine;

namespace Game.Generic
{

    public class Pool<T> : ICustomPool<T> where T : Component
    {
        private ICustomObjectPool<T> _iCustomObjectPool;
        private Stack<T> _pool = new Stack<T>();

        public Pool(ICustomObjectPool<T> iCustomObjectPool)
        {
            _iCustomObjectPool = iCustomObjectPool;
            CreateInitialPool(iCustomObjectPool.StartSize());
        }

        public T Get()
        {
            if (_pool.Count <= 0)
            {
                CreatePoolObject();
            }

            var objPool = _pool.Pop();
            _iCustomObjectPool.TakeObject(objPool);

            return objPool;
        }

        public void Return(T objToReturn)
        {
            _iCustomObjectPool.ReturnObject(objToReturn);
            _pool.Push(objToReturn);
        }

        private void CreateInitialPool(int startingPoolSize)
        {
            for (int i = 0; i < startingPoolSize; i++)
            {
                CreatePoolObject();
            }
        }

        private void CreatePoolObject()
        {

            _pool.Push(_iCustomObjectPool.CreateObject());
        }
    }

    public interface ICustomObjectPool<T> where T : Component
    {
        void TakeObject(T objPool);
        T CreateObject();
        void ReturnObject(T objToReturn);
        int StartSize();
    }

    public interface ICustomPool<T> where T : Component
    {
        T Get();

        void Return(T objToReturn);
    }
}