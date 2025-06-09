using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_action_T : MonoBehaviour
{
    // 移動先の座標
    public Vector3 targetPosition = new Vector3(0.11f, 2.3f, 4);
    
    // 移動速度
    public float speed = 2.0f;

    // 移動を開始するかどうかのフラグ
    private bool shouldMove = false;

    // 移動を開始するメソッド（イベントから呼び出される）
    public void StartMoving()
    {
        shouldMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            // 現在の位置と目標位置を補間して移動する
            Transform mytransform = this.transform;

            // Lerpで現在の位置から目標の位置にスムーズに移動
            mytransform.position = Vector3.Lerp(mytransform.position, targetPosition, speed * Time.deltaTime);

            // 目標位置に到達したか確認して、到達したら移動を停止
            if (Vector3.Distance(mytransform.position, targetPosition) < 0.01f)
            {
                shouldMove = false;  // 移動を停止
            }
        }
    }
}
