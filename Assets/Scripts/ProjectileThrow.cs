using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

[RequireComponent(typeof(TrajectoryPredictor))]
public class ProjectileThrow : MonoBehaviour
{
    TrajectoryPredictor trajectoryPredictor;

    [SerializeField]
    Rigidbody objectToThrow;

    [SerializeField, Range(0.0f, 50.0f)]
    float force;

    [SerializeField]
    Transform StartPosition;

    public InputAction fire;

    private float timeToFire = 1f;
    private float fireTimer = 0;

    public GameObject hitMarkerObj;

    void OnEnable()
    {
        trajectoryPredictor = GetComponent<TrajectoryPredictor>();

        if (StartPosition == null)
            StartPosition = transform;

        //fire.Enable();
        //fire.performed += ThrowObject;
    }

    void Update()
    {
        Predict();
        if (Input.GetKeyDown(KeyCode.Space) && fireTimer <= 0) {
            ThrowObject();
            fireTimer = timeToFire;
            StartCoroutine(removeHitMarker());
        }
        
        if (fireTimer > 0)
        {
            fireTimer -= Time.deltaTime;
        }
    }

   public IEnumerator removeHitMarker()
    {
        hitMarkerObj.SetActive(true);
        yield return new WaitForSeconds(1f);
        hitMarkerObj.SetActive(false);
    }

    void Predict()
    {
        trajectoryPredictor.PredictTrajectory(ProjectileData());
    }

    ProjectileProperties ProjectileData()
    {
        ProjectileProperties properties = new ProjectileProperties();
        Rigidbody r = objectToThrow.GetComponent<Rigidbody>();

        properties.direction = StartPosition.forward;
        properties.initialPosition = StartPosition.position;
        properties.initialSpeed = force;
        properties.mass = r.mass;
        properties.drag = r.drag;

        return properties;
    }

    void ThrowObject()
    {
        Rigidbody thrownObject = Instantiate(objectToThrow, StartPosition.position, new Quaternion(0, 120, 0, 0));
        thrownObject.AddForce(StartPosition.forward * force, ForceMode.Impulse);
    }
}