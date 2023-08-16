using System.Collections;
using UnityEngine;

namespace Bomber
{
    public enum GameState
    {
        Standby = 0,        // 準備中
        GetTurn = 1,        // プレイヤーターン獲得
        RatioSelect = 2,    // 割合指定
        Daice = 3,          // サイコロ
        Execute = 4,        // 実行
        CheckExplosion = 5, // 爆破チェック
        Result = 6,         // リザルト
    }
}