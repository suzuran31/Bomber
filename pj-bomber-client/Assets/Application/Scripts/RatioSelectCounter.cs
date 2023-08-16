using System;
using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Bomber
{
    public class RatioSelectCounter : MonoBehaviour
    {
        [SerializeField]
        private Button addButton;

        [SerializeField]
        private Button subButton;

        [SerializeField]
        private Text countText;

        [SerializeField]
        private Button executeButton;

        public IObservable<int> OnExecuteRatio => onExecuteRatio;
        private readonly Subject<int> onExecuteRatio = new Subject<int>();

        private ReactiveProperty<int> ratioCount = new ReactiveProperty<int>(1);

        private void Start()
        {
            ratioCount
                .Subscribe(count => countText.text = count.ToString())
                .AddTo(this);

            addButton.OnClickAsObservable()
                .Subscribe(_ => ratioCount.Value += ratioCount.Value < 10 ? 1 : 0)
                .AddTo(this);

            subButton.OnClickAsObservable()
                .Subscribe(_ => ratioCount.Value -= ratioCount.Value > 1 ? 1 : 0)
                .AddTo(this);

            executeButton.OnClickAsObservable()
                .Subscribe(_ => onExecuteRatio.OnNext(ratioCount.Value))
                .AddTo(this);
        }

    }
}