//  LITH
//  sCameraInputManager
//  Get the inputs from the user and send them to sCameraController
//  Anthony Ramon
//  08/21/17

using UnityEngine;
using System.Collections;
#region Delegates
public delegate void MouseMoved(float xMovement, float yMovement);
#endregion
public class sCameraInputManager : MonoBehaviour
{
    #region Private References

    private float _xMovement;
    private float _yMovement;
    private bool bOneClic = false;
    private bool bTimerRunning;
    private float fTimerDoubleClic;
    private float fDelay = 0.25f;
    private bool bDoubleClic = false;

    public float fSpeed = 1.0f;
    public float fCoeff = 5.0f;
    public float fLength = 35;
    public float fFovStart = 70;
    public float fFov;
    public float fFovBeforeInput = 70;
    public float fFovTarget;

    #endregion

    #region Events
    public static event MouseMoved MouseMoved;
    #endregion

    #region Event Invoker Methods
    private static void OnMouseMoved(float xmovement, float ymovement)
    {
        var handler = MouseMoved;
        if (handler != null) handler(xmovement, ymovement);
    }
    #endregion

    #region Private Methods

    private void InvokeActionOnInput()
    {
        if (Input.GetMouseButtonDown(0)){
            if (!bOneClic){
                bOneClic = true;
                fTimerDoubleClic = Time.time;
            } else {
                bOneClic = false;
                bDoubleClic = true;
                fCoeff = fSpeed;
                if (fFov >= 70)
                    fFovTarget = 35;
                else if (fFov <= 35)
                    fFovTarget = 70;
            }
        }
        /*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved){
            _xMovement = Input.GetTouch(0).deltaPosition.x;
            _yMovement = Input.GetTouch(0).deltaPosition.y;
            OnMouseMoved(_xMovement, _yMovement);
        }*/
        if(Input.GetMouseButton(0)){
            _xMovement = Input.GetAxis("Mouse X");
            _yMovement = Input.GetAxis("Mouse Y");
            OnMouseMoved(_xMovement, _yMovement);
        }
        if (bOneClic) { if ((Time.time - fTimerDoubleClic) > fDelay){ bOneClic = false; }}
    }
    #endregion

    #region Unity CallBacks
   
    void Start() {
        fFov = Camera.main.fieldOfView;
        fFovBeforeInput = fFov;
    }

    void Update()
    {
        InvokeActionOnInput();
        if (bDoubleClic){ 
            if (fFov >= fFovTarget)
                fFov -= Time.deltaTime * (fSpeed * fCoeff);
            else if (fFov <= fFovTarget){
                fFov += Time.deltaTime * (fSpeed * fCoeff);
            }
            Camera.main.fieldOfView = fFov;
            fCoeff *= 1.3f;
            if ((fFov < fFovTarget && fFovBeforeInput > fFovTarget) || (fFov > fFovTarget && fFovBeforeInput < fFovTarget)){
                bDoubleClic = false;
                fCoeff = fSpeed;
            }
        }
        else {
            fFov = Camera.main.fieldOfView;
            fFovBeforeInput = fFov;
        }
    }

    #endregion


}
