using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RayShooter : MonoBehaviour
{
    [SerializeField] private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        // hide the mouse cursor
        /*Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
            Ray ray = cam.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                // is this object our Enemy?
                if (target != null)
                {
                    target.ReactToHit();
                }
                else
                {
                    // visually indicate where there was a hit
                    StartCoroutine(CreateTempSphereIndicator(hit.point));
                }
            }
        }
    }

    private IEnumerator CreateTempSphereIndicator(Vector3 hitPosition)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        sphere.transform.position = hitPosition;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }

    /*void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = aimSize;
        // find the center of the camera view and adjust for asterisk
        float posX = cam.pixelWidth / 2 - aimSize / 4;
        float posY = cam.pixelHeight / 2 - aimSize / 2;
        GUI.Label(new Rect(posX, posY, aimSize, aimSize), "*", style);
    }*/
}
