using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPresenter : MonoBehaviour
{
    [SerializeField] private GameObject _robotObj;

    private ControlView _view;
    private ControlModel _model;

    void Start()
    {
        _model = new ControlModel(_robotObj);
        _view = FindObjectOfType<ControlView>();
        _view.Init();

        _view.OnHoldForwardButton?.AddListener(() => _model.TranslateRobotLocalTransform("forward"));
        _view.OnHoldBackButton?.AddListener(() => _model.TranslateRobotLocalTransform("back"));
        _view.OnHoldLeftButton?.AddListener(() => _model.TranslateRobotLocalTransform("left"));
        _view.OnHoldRightButton?.AddListener(() => _model.TranslateRobotLocalTransform("right"));

        _view.OnHoldRotateLeftButton?.AddListener(() => _model.RotateRobotTransform(true));
        _view.OnHoldRotateRightButton?.AddListener(() => _model.RotateRobotTransform(false));
        _view.OnTranslateSpeedChanged?.AddListener((speedText) => _model.TranslateSpeed = float.Parse(speedText));
        _view.OnRotateSpeedChanged?.AddListener((speedText) => _model.RotateSpeed = float.Parse(speedText));
        _view.OnClickExitYesButton?.AddListener(_model.QuitApplication);
        _view.OnClickResetRobotButton?.AddListener(_model.ResetRobotTransform);
    }

    void Update()
    {
        _view.UpdateCheckMoveButtonHoldStatus();
    }
}
