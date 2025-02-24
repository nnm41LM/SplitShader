using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;


public class ControlModel
{
    private GameObject _robotObj;
    private float _translateSpeed = 0.01f;
    private float _rotateSpeed = 0.1f;
    public float TranslateSpeed { set => _translateSpeed = value; }
    public float RotateSpeed { set => _rotateSpeed = value; }

    public ControlModel(GameObject robotObj)
    {
        Debug.Log("コンストラクタ定義");
        _robotObj = robotObj;
    }

    public void TranslateRobotTransform(Vector3 direction)// TODO: ロボットの方向に合わせる
    {
        _robotObj.transform.localPosition += direction * _translateSpeed;
    }

    public void TranslateRobotLocalTransform(string direction)
    {
        switch (direction)
        {
            case "forward":
                _robotObj.transform.position += _robotObj.transform.forward * _translateSpeed;
                break;
            case "back":
                _robotObj.transform.position -= _robotObj.transform.forward * _translateSpeed;
                break;
            case "right":
                _robotObj.transform.position += _robotObj.transform.right * _translateSpeed;
                break;
            case "left":
                _robotObj.transform.position -= _robotObj.transform.right * _translateSpeed;
                break;

        }
    }

    public void RotateRobotTransform(bool isLeft)
    {
        var coefficient = isLeft ? 1 : -1;
        _robotObj.transform.Rotate(Vector3.up * _rotateSpeed * coefficient);
    }

    public void ResetRobotTransform()
    {
        _robotObj.transform.rotation = Quaternion.identity;
        _robotObj.transform.position = Vector3.zero;
    }

    public void QuitApplication()
    {
        Debug.Log("終了");
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
        Application.Quit();
#endif
    }
}
