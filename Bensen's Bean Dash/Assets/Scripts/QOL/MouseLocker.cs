using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLocker : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}