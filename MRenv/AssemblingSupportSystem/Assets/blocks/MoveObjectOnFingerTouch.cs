using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Hands; // Hand Subsystemを使用
using UnityEngine.XR.Management; // XR Management関連
 
public class MoveObjectOnFingerTouch : MonoBehaviour
{
    // 移動先の座標
    public Vector3 targetPosition = new Vector3(0, 2.5f, 4);
 
    // 移動速度
    public float speed = 2.0f;
 
    // 手の指の位置情報を取得するためのハンドサブシステム
    private XRHandSubsystem handSubsystem;
 
    // 指の位置情報（仮に人差し指の先端を追跡する）
    public Transform fingerTip;  // 指の位置を追跡するTransform
 
    // 指がオブジェクトに触れたかどうかを判定する距離（近さ）
    public float touchThreshold = 0.05f;  // 5cm以内で触れたとみなす
 
    // 移動を開始するかどうかのフラグ
    private bool shouldMove = false;
 
    void Start()
    {
        // 手の情報を取得するサブシステムを直接取得
        List<XRHandSubsystem> handSubsystems = new List<XRHandSubsystem>();
        SubsystemManager.GetInstances(handSubsystems);
 
        if (handSubsystems.Count > 0)
        {
            handSubsystem = handSubsystems[0];
        }
    }
 
    void Update()
    {
        // 指とオブジェクトの距離を計算
        float distanceToFinger = Vector3.Distance(fingerTip.position, transform.position);
 
        // 指がオブジェクトに一定距離以内にあれば触れたと判定
        if (distanceToFinger <= touchThreshold)
        {
            shouldMove = true;
        }
 
        // オブジェクトを移動
        if (shouldMove)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
 
            // 移動が完了したら移動を停止
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                shouldMove = false;  // 移動を停止
            }
        }
    }
}