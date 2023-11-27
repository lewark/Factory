using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Disable();
    }

    public void Disable()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        OnMenuHide();
    }

    public void Enable()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        OnMenuShow();
    }

    virtual protected void OnMenuShow()
    {

    }

    virtual protected void OnMenuHide()
    {

    }
}
