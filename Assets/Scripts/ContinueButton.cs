using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    public void OnClick()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
