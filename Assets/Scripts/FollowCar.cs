using UnityEngine;

public class FollowCar : MonoBehaviour
{

    public Transform car;

    // Update is called once per frame
    void Update()
    {
        Vector3 wantedPosition;

        wantedPosition = car.TransformPoint(0, 2f, -3f);
        wantedPosition.y = 1.2f;
        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * 5.0f);
        transform.LookAt(new Vector3(car.position.x, 0, car.position.z));
    }
}
