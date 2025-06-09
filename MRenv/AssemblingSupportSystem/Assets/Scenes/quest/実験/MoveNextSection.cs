using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveNextSection : MonoBehaviour
{
    // 次のシーンに移動する関数
    public void MoveToNextScene()
    {
        // 現在のシーンの名前を取得
        string currentSceneName = SceneManager.GetActiveScene().name;

        // シーン名が「3_qN」の形式であるかチェック
        if (currentSceneName.StartsWith("reset1"))
        {
            SceneManager.LoadScene("exp2");
        }else if (currentSceneName.StartsWith("reset2")||currentSceneName.StartsWith("Start"))
        {
            SceneManager.LoadScene("exp1");
        }
        else
        {
            Debug.LogError("シーン名が「expN」の形式ではありません: ");
        }
    }
}
