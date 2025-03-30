using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints; // Danh sách waypoint để di chuyển
    private int currentWaypointIndex = 0;
    public float moveSpeed = 2f;

    void Start()
    {
        if (waypoints == null || waypoints.Length == 0)
        {
            Debug.LogError(gameObject.name + " không có waypoints!");
            return;
        }
    }

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        // Di chuyển tới waypoint hiện tại
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

        // Khi đến gần waypoint, chuyển sang waypoint tiếp theo
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                Destroy(gameObject); // Xóa quái khi đi hết đường
            }
        }
    }
}
