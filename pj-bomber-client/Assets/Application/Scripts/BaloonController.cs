using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Bomber
{
    /// <summary>
    /// 風船制御クラス
    /// </summary>
    public class BaloonController : MonoBehaviour
    {
        [SerializeField]
        private Button testAddButton;

        [SerializeField]
        private Baloon baloon;

        [SerializeField]
        private int baloonSizeMin = 3;

        [SerializeField]
        private int baloonSizeMax = 14;

        [SerializeField]
        private int explosionCount = 100;

        private int counter = 0;

        private void Start()
        {
            testAddButton.OnClickAsObservable()
                .Subscribe(_ => Add())
                .AddTo(this);

            baloon.Initialize(baloonSizeMin);
        }

        public void Add()
        {
            int subtractSize = baloonSizeMax - baloonSizeMin;
            float scaleRatio = (float)subtractSize / (float)explosionCount;

            if(counter < explosionCount)
            {
                counter++;
            }
            else
            {
                return;
            }

            baloon.UpdateScale(scaleRatio);
        }
    }
}