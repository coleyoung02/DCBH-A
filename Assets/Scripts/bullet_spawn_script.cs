using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_spawn_script : MonoBehaviour
{
    public GameObject bullet;

    void Update()
    {
        if (PauseMenu.GetIsPaused())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            targetPosition.z = 0;

            Vector3 direction = (targetPosition - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            GameObject newBullet = Instantiate(bullet, transform.position, rotation);
            newBullet.GetComponent<Bullet>().SetDirection(direction);

        }
    }
}
