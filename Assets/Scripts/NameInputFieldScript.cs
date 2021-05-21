using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//プレイヤー名入力欄のスクリプトです。
public class NameInputFieldScript : MonoBehaviour
{
    static string playerNamePrefKey = "PlayerName";

    // Start is called before the first frame update
    void Start()
    {
        string defaultName = "";
        InputField _inputField = this.GetComponent<InputField>();

        if(_inputField != null)
        {
            if (PlayerPrefs.HasKey(playerNamePrefKey))
            {
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                _inputField.text = defaultName;
            }
        }
    }

    public void SetPlayerName(string value)
    {
        PhotonNetwork.playerName = value + " ";
        PlayerPrefs.SetString(playerNamePrefKey, value);
        Debug.Log(PhotonNetwork.player.NickName);
    }
}
