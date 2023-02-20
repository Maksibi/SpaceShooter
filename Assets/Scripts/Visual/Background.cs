using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Background : MonoBehaviour
    {
        [Range(0.0f, 4.0f)]
        [SerializeField] private float parallaxPower;
        [SerializeField] private float textureScale;

        private Material material;
        private Vector2 initialOffset;

        private void Start()
        {
            material = GetComponent<MeshRenderer>().material;
            initialOffset = Random.insideUnitCircle;

            material.mainTextureScale = Vector2.one * textureScale;
        }
        private void Update()
        {
            Vector2 offset = initialOffset;

            offset.x += transform.position.x / transform.localScale.x / parallaxPower;
            offset.y += transform.position.y / transform.localScale.y / parallaxPower;

            material.mainTextureOffset = offset;
        }
    }
}