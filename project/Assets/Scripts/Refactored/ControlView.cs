using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class ControlView : MonoBehaviour
{
    [Header("--- ロボット移動用ボタン ---")]
    [SerializeField] private Button _forwardButton;
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;
    [SerializeField] private Button _rotateLeftButton;
    [SerializeField] private Button _rotateRightButton;
    [SerializeField] private Button _resetRobotButton;
    [Header("--- ロボット移動パラメータ設定フィールド ---")]
    [SerializeField] private TMP_InputField _translateSpeedField;
    [SerializeField] private TMP_InputField _rotateSpeedField;
    [Header("--- ホームメニュー操作用ボタン ---")]
    [SerializeField] private Button _controlMenuButton;
    [SerializeField] private Button _homeMenuButton;
    [SerializeField] private GameObject _robotMovePanelObj;
    [SerializeField] private GameObject _finishPanelObj;
    [Header("--- ゲーム終了操作用ボタン ---")]
    [SerializeField] private Button _exitNoButton;
    [SerializeField] private Button _exitYesButton;


    private bool _isHoldingForward = false;
    private bool _isHoldingBack = false;
    private bool _isHoldingLeft = false;
    private bool _isHoldingRight = false;
    private bool _isHoldingRotateLeft = false;
    private bool _isHoldingRotateRight = false;

    private UnityEvent _onHoldForwardButton = new UnityEvent();
    private UnityEvent _onHoldBackButton = new UnityEvent();
    private UnityEvent _onHoldLeftButton = new UnityEvent();
    private UnityEvent _onHoldRightButton = new UnityEvent();
    private UnityEvent _onHoldRotateLeftButton = new UnityEvent();
    private UnityEvent _onHoldRotateRightButton = new UnityEvent();

    #region 公開プロパティ
    public UnityEvent OnHoldForwardButton { get => _onHoldForwardButton; }
    public UnityEvent OnHoldBackButton { get => _onHoldBackButton; }
    public UnityEvent OnHoldLeftButton { get => _onHoldLeftButton; }
    public UnityEvent OnHoldRightButton { get => _onHoldRightButton; }
    public UnityEvent OnHoldRotateLeftButton { get => _onHoldRotateLeftButton; }
    public UnityEvent OnHoldRotateRightButton { get => _onHoldRotateRightButton; }
    public UnityEvent<string> OnTranslateSpeedChanged { get => _translateSpeedField.onEndEdit; }
    public UnityEvent<string> OnRotateSpeedChanged { get => _rotateSpeedField.onEndEdit; }

    public UnityEvent OnClickExitYesButton { get => _exitYesButton.onClick; }
    public UnityEvent OnClickResetRobotButton { get => _resetRobotButton.onClick; }
    #endregion

    public void Init()
    {
        _finishPanelObj.SetActive(false);

        _forwardButton.GetComponent<EventTrigger>().AddPointerDownListener(_ => _isHoldingForward = true);
        _forwardButton.GetComponent<EventTrigger>().AddPointerUpListener(_ => _isHoldingForward = false);
        _backButton.GetComponent<EventTrigger>().AddPointerDownListener(_ => _isHoldingBack = true);
        _backButton.GetComponent<EventTrigger>().AddPointerUpListener(_ => _isHoldingBack = false);
        _leftButton.GetComponent<EventTrigger>().AddPointerDownListener(_ => _isHoldingLeft = true);
        _leftButton.GetComponent<EventTrigger>().AddPointerUpListener(_ => _isHoldingLeft = false);
        _rightButton.GetComponent<EventTrigger>().AddPointerDownListener(_ => _isHoldingRight = true);
        _rightButton.GetComponent<EventTrigger>().AddPointerUpListener(_ => _isHoldingRight = false);
        _rotateLeftButton.GetComponent<EventTrigger>().AddPointerDownListener(_ => _isHoldingRotateLeft = true);
        _rotateLeftButton.GetComponent<EventTrigger>().AddPointerUpListener(_ => _isHoldingRotateLeft = false);
        _rotateRightButton.GetComponent<EventTrigger>().AddPointerDownListener(_ => _isHoldingRotateRight = true);
        _rotateRightButton.GetComponent<EventTrigger>().AddPointerUpListener(_ => _isHoldingRotateRight = false);

        _controlMenuButton.onClick.AddListener(() => _robotMovePanelObj.SetActive(!_robotMovePanelObj.activeSelf));
        _homeMenuButton.onClick.AddListener(() => _finishPanelObj.SetActive(!_finishPanelObj.activeSelf));

        _exitNoButton.onClick.AddListener(() => _finishPanelObj.SetActive(false));
    }

    public void UpdateCheckMoveButtonHoldStatus()
    {
        if (_isHoldingForward) _onHoldForwardButton?.Invoke();
        if (_isHoldingBack) _onHoldBackButton?.Invoke();
        if (_isHoldingLeft) _onHoldLeftButton?.Invoke();
        if (_isHoldingRight) _onHoldRightButton?.Invoke();
        if (_isHoldingRotateLeft) _onHoldRotateLeftButton?.Invoke();
        if (_isHoldingRotateRight) _onHoldRotateRightButton?.Invoke();
    }
}
