using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform tra;
    [Range(0,100)]
    public int speed;
    public Vector2 LAM = new Vector2(0, 2);

    private void Track()
    {
        Vector3 a = transform.position;
        Vector3 b = tra.position;
        b.z = -10;
        a.y = Mathf.Clamp(a.y, LAM.x, LAM.y);
        a=Vector3.Lerp(a, b, Time.deltaTime * speed);
        transform.position = a;
    }

    private void LateUpdate()
    {
        Track();

    }
}
