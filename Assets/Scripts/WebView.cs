using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Web表示機能のスクリプトです。
//iOS,Androidのみ対応。
public class WebView : MonoBehaviour
{
    WebViewObject webViewObject;

    // Start is called before the first frame update
    void Start()
    {
        webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        webViewObject.Init(
           // Id: (msg) => Debug.Log(string.Format("CallOnLoaded[{0}]", msg)),
            enableWKWebView: true);

#if UNITY_EDITOR_OSX||UNITY_STANDALONE_OSX
webViewObject.bitmapRefreshCycle = 1;
#endif

//今回は実験としてGoogleを入れてます。
        webViewObject.LoadURL("https://www.google.co.jp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
