using UnityEngine;

public class LightShow2D : MonoBehaviour
{
    public GameObject lightPrefab; // Assign your light prefab in the inspector
    public int numberOfLights = 10; // Number of lights to spawn
    public float speed = 1f; // Speed of movement
    public float radius = 5f; // Radius of movement
    public float flashInterval = 0.5f; // Time interval for flashing

   

    private GameObject[] lights;
    private float angle;
    private float flashTimer;

    void Start()
    {
        // Spawn lights
        lights = new GameObject[numberOfLights];
        for (int i = 0; i < numberOfLights; i++)
        {

            lights[i] = Instantiate(lightPrefab);
           // lights[i].transform.position = new Vector3(0, 0, 0); // Set initial position at (0, 0, 0)
        }
    }

    void Update()
    {
        // Move lights in a circular pattern around the camera
        angle += Time.deltaTime * speed;
        for (int i = 0; i < lights.Length; i++)
        {
            float x = Mathf.Cos(angle + (i * Mathf.PI / lights.Length)) * radius;
            float y = Mathf.Sin(angle + (i * Mathf.PI / lights.Length)) * radius;
            lights[i].transform.position = new Vector3(x, y, 1) + Camera.main.transform.position;
        }

        // Flashing effect
        flashTimer += Time.deltaTime;
        if (flashTimer >= flashInterval)
        {
            flashTimer = 0f;
            foreach (var light in lights)
            {
                SpriteRenderer spriteRenderer = light.GetComponent<SpriteRenderer>();
                spriteRenderer.enabled = !spriteRenderer.enabled; // Toggle visibility
            }
        }
    }
}
