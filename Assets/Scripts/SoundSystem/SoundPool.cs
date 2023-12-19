using Game.Generic;
using UnityEngine;

namespace SoundSystem
{
    public class SoundPool : ICustomObjectPool<AudioSource>
    {
        private int _startSize;
        private ICustomPool<AudioSource> _pool;

        Transform _parent;

        public SoundPool(Transform parent, int startSize)
        {
            _parent = parent;
            _startSize = startSize;
            _pool = new Pool<AudioSource>(this);
        }

        public AudioSource Get()
        {
            return _pool.Get();
        }

        public void Return(AudioSource objToReturn)
        {
            _pool.Return(objToReturn);
        }

        #region PoolSettings

        public void TakeObject(AudioSource objPool)
        {
            objPool.gameObject.SetActive(true);
        }

        public AudioSource CreateObject()
        {
            GameObject gameObject = new GameObject(nameof(AudioSource));
            var newObject = gameObject.AddComponent<AudioSource>();

            newObject.transform.SetParent(_parent);
            newObject.gameObject.SetActive(false);
            return newObject;
        }

        public void ReturnObject(AudioSource objToReturn)
        {
            objToReturn.gameObject.SetActive(false);
        }

        public int StartSize()
        {
            return _startSize;
        }

        #endregion
    }
}
