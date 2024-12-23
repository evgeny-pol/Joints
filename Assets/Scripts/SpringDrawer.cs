using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(SpringJoint))]
[RequireComponent(typeof(LineRenderer))]
public class SpringDrawer : MonoBehaviour
{
    private SpringJoint _springJoint;
    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _springJoint = GetComponent<SpringJoint>();
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        Rigidbody connectedBody = _springJoint.connectedBody;

        if (connectedBody == null)
        {
            _lineRenderer.positionCount = 0;
            return;
        }

        _lineRenderer.positionCount = 2;
        Vector3 springFrom = transform.TransformPoint(_springJoint.anchor);
        Vector3 springTo = connectedBody.transform.TransformPoint(_springJoint.connectedAnchor);
        _lineRenderer.SetPosition(0, springFrom);
        _lineRenderer.SetPosition(1, springTo);
    }
}
