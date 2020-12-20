using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraController : MonoBehaviour
{
    public List<CameraRoute> cameraRoutes = new List<CameraRoute>();
    public Camera routeCam;

    private void Start()
    {
        if (cameraRoutes.IsNullOrEmpty()) return;

        setCamPos(cameraRoutes[0].startPoint);
     }

    public void StartCameraRoute()
    {
        StartCameraRoute(0);
    }

    private void StartCameraRoute(int index)
    {
        if (index < cameraRoutes.Count)
        {
            StartCoroutine(LerpPos(cameraRoutes[index], index));
        }
        else
        {
            GameManager.Instance.LoadEndScene();
        }
    }

    private IEnumerator LerpPos(CameraRoute cameraRoute, int index)
    {
        float timeElapsed = 0;
        while(timeElapsed < cameraRoute.duration)
        {
            float xPos = Mathf.Lerp(cameraRoute.startPoint.position.x, cameraRoute.endPoint.position.x, timeElapsed / cameraRoute.duration);
            routeCam.transform.position = new Vector3(xPos, cameraRoute.startPoint.position.y, routeCam.transform.position.z);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        yield return new WaitForSeconds(cameraRoute.waitAfterEnd);
        if(cameraRoute.fadeAtEnd)
        {
            routeCam.GetComponent<CameraFade>().RedoFade();
        }

        StartCameraRoute(++index);
    }

    private void setCamPos(Transform point)
    {
        routeCam.transform.position = new Vector3(point.position.x, point.position.y, routeCam.transform.position.z);
    }
}
