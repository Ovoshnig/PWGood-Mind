using System.Collections;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    [SerializeField] private Color _color1;
    [SerializeField] private Color _color2;

    [SerializeField] private GameObject[] _objectPrefabs;

    [SerializeField] private float _minSpawnDelay;
    [SerializeField] private float _maxSpawnDelay;
    [SerializeField] private float _lerpDuration;

    private new Camera camera;

    private Vector3 randCoordinates;
    private Quaternion randRotation;
    private int randSelection;
    private float randScale;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    void Start()
    {
        StartCoroutine(SpawnObjects());
        StartCoroutine(LerpBackground());
    }

    private IEnumerator SpawnObjects()
    {
        while (true) 
        {
            randCoordinates = new Vector3(Random.Range(-10f, 10f), 30f, Random.Range(-10f, 10f));
            randRotation.eulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));
            randScale = Random.Range(1f, 5f);
            randSelection = Random.Range(0, _objectPrefabs.Length);

            Instantiate(_objectPrefabs[randSelection], randCoordinates, randRotation).transform.localScale *= randScale;

            yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));
        }
    }

    private IEnumerator LerpBackground()
    {
        Color color1 = _color1;
        Color color2 = _color2;

        while (true)
        {
            float elapsedTime = 0;

            while (elapsedTime < _lerpDuration)
            {
                Color color = Color.Lerp(color1, color2, elapsedTime / _lerpDuration);
                camera.backgroundColor = color;

                elapsedTime += Time.deltaTime;

                yield return null;
            }

            (color1, color2) = (color2, color1);

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
