using Baloon;
using Cysharp.Threading.Tasks;
using System.Collections;
using UnityEngine;
using UniRx;

namespace Bomber
{
    /// <summary>
    /// ゲームマネージャ
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private BaloonController baloonController;

        [SerializeField]
        private UiController uiContoller;

        private GameState gameState = GameState.Standby;
        private int turnPlayerNum = 1;

        private int turnCount = 0;
        private int winPlayerNum = 0;

        // Use this for initialization
        private async void Start()
        {
            // ゲーム開始時
            if(gameState == GameState.Standby)
            {
                uiContoller.SetBuloonCountText((int)baloonController.Counter);
                gameState = GameState.GetTurn;
            }

            while(true)
            {
                await GameLoop();

                // リザルト
                if(gameState == GameState.Result)
                {
                    break;
                }
            }

            // リザルト処理
            uiContoller.ShowResult(winPlayerNum);
        }

        private async UniTask GameLoop()
        {
            await StartTurn();

            await EndTurn();
        }

        private async UniTask StartTurn()
        {
            // ターン獲得
            if(gameState == GameState.GetTurn)
            {
                uiContoller.SetTurnText(++turnCount);

                uiContoller.ShowGetTurnText(turnPlayerNum);
                await UniTask.Delay(1000);
                uiContoller.HideGetTurnText();
                gameState = GameState.RatioSelect;
            }

            int countRatio = 1;
            // 割合選択
            if(gameState == GameState.RatioSelect)
            {
                uiContoller.ShowRatioSelectCounter(turnPlayerNum);
                
                countRatio = await uiContoller.RatioSelectCounter[turnPlayerNum - 1].OnExecuteRatio.ToUniTask(useFirstValue: true);

                uiContoller.HideRatioSelectCounter(turnPlayerNum);

                gameState = GameState.Daice;
            }

            int randomAmount = 0;
            // ランダム係数
            if(gameState == GameState.Daice)
            {
                randomAmount = Random.Range(1, 7);
                gameState = GameState.Execute;
            }

            // 実行
            if(gameState == GameState.Execute)
            {
                baloonController.Add(countRatio, randomAmount);
                uiContoller.SetBuloonCountText((int)baloonController.Counter);
                gameState = GameState.CheckExplosion;
            }

            // 爆破チェック
            if(gameState == GameState.CheckExplosion)
            {
                if(baloonController.IsExplosion)
                {
                    winPlayerNum = turnPlayerNum == 2 ? 1 : 2;
                    gameState = GameState.Result;
                }
            }
        }

        private async UniTask EndTurn()
        {
            if(gameState == GameState.Result)
            {
                return;
            }

            turnPlayerNum = turnPlayerNum == 2 ? 1 : 2;
            Debug.Log($"ターンプレイヤー {turnPlayerNum}P");
            gameState = GameState.GetTurn;
        }
    }
}