using UnityEngine;

public class SwingPusher : MonoBehaviour
{
    [SerializeField] private Rigidbody _swing;
    [SerializeField, Min(0)] private float _force;

    private void Update()
    {
        if (Input.GetButtonDown(InputAxes.Swing))
            _swing.AddForceAtPosition(_force * transform.forward, transform.position, ForceMode.VelocityChange);
    }
}
