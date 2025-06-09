using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToBeforePuzzle : MonoBehaviour
{
    // 次のシーンに移動する関数
    public void MoveToBeforeScene()
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
                if(currentNumber==11){
                    nextNumber = 9;
                }else{
                    nextNumber = currentNumber-1;
                }
                
                string nextSceneName = "3_q" + nextNumber;

                // 次のシーンをロード
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.LogError("現在のシーン名に有効な番号が含まれていません: " + currentSceneName);
            }
        }else if(currentSceneName.StartsWith("3r_q")){
            string numberPart = currentSceneName.Substring(4); // "3_q"以降の部分を取得
            if (int.TryParse(numberPart, out int currentNumber))
            {
                int nextNumber=0;
                // 次の番号を計算
                if(currentNumber==11){
                    nextNumber = 9;
                }else{
                    nextNumber = currentNumber-1;
                }
                
                string nextSceneName = "3_q" + nextNumber;

                // 次のシーンをロード
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.LogError("現在のシーン名に有効な番号が含まれていません: " + currentSceneName);
            }
        }
        else
        {
            Debug.LogError("シーン名が「3_qN」の形式ではありません: " + currentSceneName);
        }
    }
}
