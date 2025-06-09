using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changecolor2 : MonoBehaviour
{
    // 変更する色（アルファ値も指定）
    public Color targetColor = new Color(1, 0, 0, 0.5f); // 赤色で半透明

    // 色と透明度の変化速度
    public float colorChangeSpeed = 2.0f;

    // 色を変えるフラグ
    private bool shouldChangeColor = false;

    // 現在のレンダラー
    private Renderer objectRenderer;

    // 掴んだ時に呼ばれるメソッド
    public void StartChangingColor()
    {
        shouldChangeColor = true; // 色と透明度を変え始める
    }

    // Start is called before the first frame update
    void Start()
    {
        // オブジェクトのレンダラーコンポーネントを取得
        objectRenderer = GetComponent<Renderer>();

        // マテリアルの透明度を有効にするためにレンダリングモードを変更
        objectRenderer.material.SetFloat("_Mode", 3);  // 透明度を有効にするためにフェードモードを使用
        objectRenderer.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        objectRenderer.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        objectRenderer.material.SetInt("_ZWrite", 0);
        objectRenderer.material.DisableKeyword("_ALPHATEST_ON");
        objectRenderer.material.EnableKeyword("_ALPHABLEND_ON");
        objectRenderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        objectRenderer.material.renderQueue = 3000;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldChangeColor)
        {
            // 現在の色を取得
            Color currentColor = objectRenderer.material.color;

            // Lerpで色と透明度を徐々に変える
            objectRenderer.material.color = Color.Lerp(currentColor, targetColor, colorChangeSpeed * Time.deltaTime);

            // 色と透明度の変化が完了したらフラグをリセット
            if (Vector4.Distance(currentColor, targetColor) < 0.01f)
            {
                shouldChangeColor = false; // 変更を停止
            }
        }
    }
}
