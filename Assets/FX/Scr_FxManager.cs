using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_FxManager : MonoBehaviour
{
    [Header("   ScreenShake")]
    public Animator camAnim;


    public void ScreenShake()
    {
        camAnim.SetTrigger("Shake");
    }
}
