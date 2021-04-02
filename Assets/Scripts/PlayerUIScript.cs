using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIScript : MonoBehaviour
{
    public Vector3 ScreenOffset = new Vector3(0f, 30f, 0f);
    public Text PlayerNameText;

    PlayerManager _target;
    float _characterControllerHeight;
    Transform _targetTransform;
    Vector3 _targetPosition;

    void Awake()
    {
        this.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
    }

    // Update is called once per frame
    void Update()
    {
        if(_target == null)
        {
            Destroy(this.gameObject);
            return;
        }
    }

    void LateUpdate()
    {
        if(_targetTransform != null)
        {
            _targetPosition = _targetTransform.position;
            _targetPosition.y += _characterControllerHeight;
            //this.transform.position = Camera.main.WorldToScreenPoint(_targetPosition) + ScreenOffset;
        }
    }

    public void SetTarget(PlayerManager target)
    {
        if(target == null)
        {
            return;
        }
        _target = target;
        _targetTransform = _target.GetComponent<Transform>();

        CharacterController _characterController = _target.GetComponent<CharacterController>();

        if(_characterController != null)
        {
            _characterControllerHeight = _characterController.height;
        }
        if(PlayerNameText != null)
        {
            PlayerNameText.text = _target.photonView.owner.NickName;
        }
    }
}
