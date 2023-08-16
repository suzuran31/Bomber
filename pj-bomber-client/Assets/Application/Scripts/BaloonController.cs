using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

namespace Bomber
{
    /// <summary>
    /// 風船制御クラス
    /// </summary>
    public class BaloonController : MonoBehaviour
    {
        [SerializeField]
        private Baloon baloon;

        [SerializeField]
        private int baloonSizeMin = 3;

        [SerializeField]
        private int baloonSizeMax = 14;

        [SerializeField]
        private int explosionCount = 100;

        private float counter = 0;
        public float Counter => counter;

        public bool IsExplosion => counter >= explosionCount;

        private void Start()
        {
            baloon.Initialize(baloonSizeMin);
        }

        public void Add(int ratio, int daiceNum)
        {
            int subtractSize = baloonSizeMax - baloonSizeMin;
            float scaleRatio = (float)subtractSize / (float)explosionCount;

            counter += ratio + daiceNum;
            baloon.UpdateScale(baloonSizeMin + (counter * scaleRatio));
        }
    }
}