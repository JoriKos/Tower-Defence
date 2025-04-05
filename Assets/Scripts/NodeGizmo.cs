using UnityEngine;

public class NodeGizmo : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
        GameObject otherObject = GameObject.Find("Node " + (int.Parse(gameObject.name.Substring(5, 1)) + 1));

        if (otherObject)
            Gizmos.DrawLine(transform.position, otherObject.transform.position);
    }
}
