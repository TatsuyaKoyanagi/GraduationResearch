using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class feedback : MonoBehaviour
{
    // Inspectorで設定可能な移動距離
    [SerializeField] private Vector3 moveDistance;

    // Inspectorで設定可能な回転角度
    [SerializeField] private Vector3 rotationAngles;

    // 移動メソッド
    [ContextMenu("Move Object")]
    public void MoveObject()
    {
        transform.position += moveDistance;
    }
    int count=0;
    // ゆっくり回転させるメソッド
    [ContextMenu("Rotate Object")]
    public void RotateObject()
    {
        count++;
        if (count == 1)
        {
            StartCoroutine(MoveAndRotateOverTime(moveDistance, rotationAngles, 0.7f)); // 1秒かけて移動と回転を行う
        }
    }

    private IEnumerator MoveAndRotateOverTime(Vector3 move, Vector3 rotate, float duration)
    {
        Vector3 initialPosition = transform.position;
        Vector3 targetPosition = initialPosition + move;
        Vector3 initialRotation = transform.eulerAngles;
        Vector3 targetRotation = initialRotation + rotate;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / duration);
            transform.eulerAngles = Vector3.Lerp(initialRotation, targetRotation, elapsedTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null; // 次のフレームまで待つ
        }

        transform.position = targetPosition;
        transform.eulerAngles = targetRotation;
    }



    // 移動をリセットするメソッド
    [ContextMenu("Reset Move Object")]
    public void ResetMoveObject()
    {
        transform.position -= moveDistance;
    }

    // 回転をリセットするメソッド
    [ContextMenu("Reset Rotate Object")]
    public void ResetRotateObject()
    {
        StartCoroutine(MoveAndRotateOverTime(-moveDistance,-rotationAngles, 1f)); // 逆方向に回転
    }
}