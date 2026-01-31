using UnityEngine;

public class ParallaxLoop : MonoBehaviour
{
    public Transform cameraTransform;
    [SerializeField] private float parallaxFactor = 0.5f;

    private float spriteWidth;
    private Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (cameraTransform == null) cameraTransform = Camera.main.transform;
        startPos = transform.position;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void LateUpdate()
    {
        float dist = cameraTransform.position.x * parallaxFactor;
        transform.position = new Vector3(startPos.x + dist, cameraTransform.position.y, startPos.z);

        float temp = cameraTransform.position.x * (1f - parallaxFactor);
        if (temp > startPos.x + spriteWidth) startPos.x += spriteWidth*2;
        else if (temp < startPos.x - spriteWidth) startPos.x -= spriteWidth*2;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
