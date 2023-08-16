using Baloon;
using Cysharp.Threading.Tasks;
using System.Collections;
using UnityEngine;

namespace Bomber
{
    /// <summary>
    /// ゲームマネージャ
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private UiController uiContoller;

        private GameState gameState = GameState.Standby;
        private int turnPlayerNum = 1;

        // Use this for initialization
        private void Start()
        {

        }

        // Update is called once per frame
        private async void Update()
        {
            // ゲーム開始時
            if(gameState == GameState.Standby)
            {
                gameState = GameState.GetTurn;
            }

            await StartTurn();

            if(gameState == GameState.Result)
            {

            }

            await EndTurn();

        }

        private async UniTask StartTurn()
        {
            // ターン獲得
            if(gameState == GameState.GetTurn)
            {
                uiContoller.ShowGetTurnText(turnPlayerNum);
                await UniTask.Delay(1000);
                uiContoller.HideGetTurnText();
                gameState = GameState.RatioSelect;
            }

            if(gameState == GameState.RatioSelect)
            {

            }

            if(gameState == GameState.Daice)
            {

            }

            if(gameState == GameState.Execute)
            {

            }

            if(gameState == GameState.CheckExplosion)
            {
                
            }
        }

        private async UniTask EndTurn()
        {
            turnPlayerNum = turnPlayerNum == 2 ? 1 : 2;
            gameState = GameState.GetTurn;
        }
    }
}