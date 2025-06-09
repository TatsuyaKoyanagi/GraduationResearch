using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint_T : MonoBehaviour
{
    // 移動先の座標
    public Vector3 targetPosition = new Vector3(0, 2.5f, 4);
    
    // 移動速度
    public float speed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        // 現在の位置と目標位置を補間して移動する
        Transform mytransform = this.transform;

        // Lerpで現在の位置から目標の位置にスムーズに移動
        mytransform.position = Vector3.Lerp(mytransform.position, targetPosition, speed * Time.deltaTime);
    }
}
