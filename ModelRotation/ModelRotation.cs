using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Watermelon;

public class ModelRotation : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform objToRotate;
    [SerializeField] public Camera camera; // which camera renders the raycasts
    [SerializeField] private bool OnlyInMultiplayer;

    private bool _dragging = false;
    private float _startPos;
    private bool _enabled = true;

    public void Awake()
    {
        if(camera == null)
            camera = CameraBehavior.instance.gameObject.GetComponent<Camera>();
    }

    public void Update()
    {
        if (LevelController.IsGameplayActive || camera == null || !_enabled) return;

        if (OnlyInMultiplayer)
            if (!PlayerBehaviour.instance.inMultiplayer)
                return;
        else if (PlayerBehaviour.instance.inMultiplayer)
            return;
            
        if(Input.GetMouseButtonDown(0)) {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                if(hit.collider.gameObject.GetComponent<ModelRotation>() == this) {
                    _startPos = Input.mousePosition.x;
                    _dragging = true;
                }
            }
        }
        else if (_dragging) {
            if (Input.GetMouseButtonUp(0)) { 
                _dragging = false;
                return; 
            }
            objToRotate.Rotate(new Vector3(0, (_startPos - Input.mousePosition.x) * speed * Time.deltaTime, 0));
            _startPos = Input.mousePosition.x;
        }
    }

    public void EnableDisable(bool value)
    {
        _enabled = value;
    }

}
