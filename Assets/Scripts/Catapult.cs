using System.Collections;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Transform _projectileSpawnLocation;
    [SerializeField] private SpringJoint _springJoint;
    [SerializeField, Min(0)] private float _springForce = 100;
    [SerializeField, Min(0)] private float _shootDuration = 1;
    [SerializeField, Min(0)] private float _reloadDuration = 1;

    private CatapultState _state = CatapultState.ReadyToShoot;

    private void Update()
    {
        if (_state == CatapultState.ReadyToShoot && Input.GetButtonDown(InputAxes.Shoot))
            StartCoroutine(Shoot());

        if (_state == CatapultState.ReadyToReload && Input.GetButtonDown(InputAxes.Reload))
            StartCoroutine(Reload());
    }

    private IEnumerator Shoot()
    {
        _state = CatapultState.Shooting;
        _springJoint.spring = _springForce;
        yield return new WaitForSeconds(_shootDuration);
        _state = CatapultState.ReadyToReload;
    }

    private IEnumerator Reload()
    {
        _state = CatapultState.Reloading;
        _springJoint.spring = 0;
        yield return new WaitForSeconds(_reloadDuration);
        Instantiate(_projectilePrefab, _projectileSpawnLocation.position, Quaternion.identity);
        _state = CatapultState.ReadyToShoot;
    }

    private enum CatapultState
    {
        ReadyToShoot,
        Shooting,
        ReadyToReload,
        Reloading,
    }
}
