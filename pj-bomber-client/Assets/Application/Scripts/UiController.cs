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
        private GameObject getTurnRoot;

        [SerializeField]
        private Text turnText;

        private void Start()
        {

        }

        private void SetBuloonCount(int count)
        {
            baloonCount.text = count.ToString();
        }

        private void HideBaloonCount()
        {
            baloonCount.gameObject.SetActive(false);
        }

        public void ShowGetTurnText(int playerNum)
        {
            turnText.text = $"{playerNum}Pのターン";
            getTurnRoot.SetActive(true);
        }

        public void HideGetTurnText()
        {
            getTurnRoot.SetActive(false);
        }

    }
}