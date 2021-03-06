using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//お絵描き機能を搭載したキャンパスのスクリプトです。
public class PaintController : MonoBehaviour
{
    public Camera camera;
    Texture2D drawTexture;
    Color[] buffer;

    // Start is called before the first frame update
    void Start()
    {
    //キャンパスのマテリアルの情報とピクセルを取得
        Texture2D mainTexture = (Texture2D)GetComponent<Renderer>().material.mainTexture;
        Color[] pixels = mainTexture.GetPixels();

        buffer = new Color[pixels.Length];
        pixels.CopyTo (buffer, 0);

        drawTexture = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);
        drawTexture.filterMode = FilterMode.Point;
    }

//ペイントの太さと色
    public void Draw(Vector2 p)
    {
        for(int x = 0; x < 256; x++)
        {
            for(int y = 0; y < 256; y++)
            {
                if((p - new Vector2 (x,y)).magnitude < 2)
                {
                    buffer.SetValue(Color.green, x + 256 * y);
                }
            }
        }
    }

//消しゴムの太さと色（白）
    public void Clear(Vector2 p)
    {
        for(int x = 0; x < 256; x++)
        {
            for(int y = 0; y < 256; y++)
            {
                if((p - new Vector2 (x,y)).magnitude < 2)
                {
                    buffer.SetValue(Color.white, x + 256 * y);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    //FPSの銃でよく用いられるRayを使います。
    //マウスの先にある場所に色が付く感じです。
    
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 100.0f))
            {
                Draw(hit.textureCoord * 256);
            }

            drawTexture.SetPixels(buffer);
            drawTexture.Apply();
            GetComponent<Renderer>().material.mainTexture = drawTexture;
        }

        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 100.0f))
            {
                Clear(hit.textureCoord * 256);
            }

            drawTexture.SetPixels(buffer);
            drawTexture.Apply();
            GetComponent<Renderer>().material.mainTexture = drawTexture;
        }
    }
}
