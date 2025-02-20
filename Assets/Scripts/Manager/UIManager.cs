using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum UIState { Logo }
public class UIManager : MonoBehaviour
{
    LogoUI LogoUI;

    private UIState CurrentState;

    private void Awake()
    {
        LogoUI = GetComponentInChildren<LogoUI>();
        LogoUI.Init(this);

        ChangeState(UIState.Logo);
    }

    public void SetPlayGame()
    {

    }

    public void ChangeState(UIState state)
    {
        CurrentState = state;
        LogoUI.SetActive(CurrentState);
    }
}
