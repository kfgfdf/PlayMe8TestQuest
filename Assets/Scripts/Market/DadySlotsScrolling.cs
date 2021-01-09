using UnityEngine;

public class DadySlotsScrolling : MonoBehaviour
{
    private Vector2 startPos;
    public Camera camera;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        startPos = camera.ScreenToWorldPoint(Input.mousePosition);
        else if(Input.GetMouseButton(0))
        {
            float curPos = camera.ScreenToWorldPoint(Input.mousePosition).x - startPos.x;
            transform.localPosition = new Vector3(transform.localPosition.x - curPos * 0.01f, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
