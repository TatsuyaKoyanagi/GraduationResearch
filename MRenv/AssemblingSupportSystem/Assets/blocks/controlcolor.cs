using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlcolor : MonoBehaviour
{
    private Material materialInstance;
    public Color touchedColor = Color.red;
    public Color defaultColor = Color.white;

    void Start()
    {
        // Rendererからマテリアルのインスタンスを取得する（共有マテリアルではない）
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            materialInstance = renderer.material;  // renderer.sharedMaterialではなく、renderer.materialを使用
            materialInstance.color = defaultColor; // 初期色を白に設定
        }
        else
        {
            Debug.LogError("Rendererが見つかりません。オブジェクトにRendererコンポーネントがアタッチされているか確認してください。");
        }
    }

    public void StartChangingColor()
    {
        if (materialInstance != null)
        {
            materialInstance.color = touchedColor; // 赤色に変更
        }
    }

    public void ResetColor()
    {
        if (materialInstance != null)
        {
            materialInstance.color = defaultColor; // 白色に戻す
        }
    }
}