using Bomber;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Baloon
{
    public class UiController : MonoBehaviour
    {
        [SerializeField]
        private Text baloonCount;

        [SerializeField]
        private Text turnText;

        [SerializeField]
        private GameObject getTurnRoot;

        [SerializeField]
        private Text playerTurnText;

        [SerializeField]
        private RatioSelectCounter[] ratioSelectCounter;
        public RatioSelectCounter[] RatioSelectCounter => ratioSelectCounter;

        [SerializeField]
        private GameObject resultRoot;

        [SerializeField]
        private Text resultText;

        private void Start()
        {
            getTurnRoot.SetActive(false);
            resultRoot.SetActive(false);
        }

        public void SetBuloonCountText(int count)
        {
            baloonCount.text = count.ToString();
        }

        public void SetTurnText(int turnCount)
        {
            turnText.text = $"{turnCount}ターン目";
        }

        private void HideBaloonCount()
        {
            baloonCount.gameObject.SetActive(false);
        }

        public void ShowGetTurnText(int playerNum)
        {
            playerTurnText.text = $"{playerNum}Pのターン";
            getTurnRoot.SetActive(true);
        }

        public void HideGetTurnText()
        {
            getTurnRoot.SetActive(false);
        }

        public void ShowRatioSelectCounter(int playerNum)
        {
            ratioSelectCounter[playerNum - 1].gameObject.SetActive(true);
        }

        public void HideRatioSelectCounter(int playerNum)
        {
            ratioSelectCounter[playerNum - 1].gameObject.SetActive(false);
        }

        public void ShowResult(int playerNum)
        {
            resultRoot.SetActive(true);
            resultText.text = $"{playerNum}Pの勝ち";
        }
    }
}