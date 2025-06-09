using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_action_J : MonoBehaviour
{
    // 移動先の座標
    public Vector3 targetPosition = new Vector3(-0.26f, 2.425f, 4);

    // 移動速度
    public float speed = 2.0f;

    // 回転済みかどうかのフラグ
    private bool hasRotated = false;

    // 移動を開始するかどうかのフラグ
    private bool shouldMove = false;

    // 掴んだ時に呼ばれるメソッド
    public void StartMoving()
    {
        shouldMove = true; // 移動を開始する
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            Transform myTransform = this.transform;

            // 1回だけ90度回転させる処理
            if (!hasRotated)
            {
                // Y軸に対して90度回転
                myTransform.rotation = Quaternion.Euler(90, 90, 0);
                hasRotated = true;  // 回転が終わったことを記録
            }

            // Lerpで現在の位置から目標の位置にスムーズに移動
            myTransform.position = Vector3.Lerp(myTransform.position, targetPosition, speed * Time.deltaTime);

            // 移動が完了したら移動を停止する
            if (Vector3.Distance(myTransform.position, targetPosition) < 0.01f)
            {
                shouldMove = false;  // 移動を停止
            }
        }
    }
}
