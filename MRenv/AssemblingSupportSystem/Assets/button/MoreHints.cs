using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoreHints : MonoBehaviour
{
    // 次のシーンに移動する関数
    public void MoreHintsActive()
    {
        // 現在のシーンの名前を取得
        string currentSceneName = SceneManager.GetActiveScene().name;

        // シーン名が「3_qN」の形式であるかチェック
        if (currentSceneName.StartsWith("3_q"))
        {
            // 現在の番号を取得して、次の番号を計算
            string numberPart = currentSceneName.Substring(3); // "3_q"以降の部分を取得
            if (int.TryParse(numberPart, out int currentNumber))
            {
                int nextNumber=0;
                // 次の番号を計算
                if(currentNumber<=9){
                    nextNumber = currentNumber+10;
                }else{
                    nextNumber = currentNumber-10;
                }
                
                string nextSceneName = "3_q" + nextNumber;

                // 次のシーンをロード
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.LogError("表示できるフィードバックがありません: " + currentSceneName);
            }
        }
        else
        {
            Debug.LogError("シーン名が「3_qN」の形式ではありません: " + currentSceneName);
        }
    }
}
