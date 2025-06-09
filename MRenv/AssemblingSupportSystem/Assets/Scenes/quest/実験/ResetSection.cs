using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSection : MonoBehaviour
{
    // 次のシーンに移動する関数
    public void MoveToNextScene()
    {
        // 現在のシーンの名前を取得
        string currentSceneName = SceneManager.GetActiveScene().name;

        // シーン名が「3_qN」の形式であるかチェック
        if (currentSceneName.StartsWith("exp1"))
        {
            SceneManager.LoadScene("reset1");
        }else if(currentSceneName.StartsWith("exp2")){
            SceneManager.LoadScene("reset2");

        }
        else
        {
            Debug.LogError("シーン名が「expN」の形式ではありません: ");
        }
    }
}
