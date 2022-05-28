using UnityEngine;

namespace Platformer.View
{
    /// <summary>
    /// Used to move a transform relative to the main camera position with a scale factor applied.
    /// This is used to implement parallax scrolling effects on different branches of gameobjects.
    /// </summary>
    public class ParallaxLayer : MonoBehaviour
    {
        /// <summary>
        /// Movement of the layer is scaled by this value. // Arkaplan'nın oynar bir hal almasını sağlar, tile'lar belirli oranda kamera ile oynarlar
        /// </summary>
        public Vector3 movementScale = Vector3.one;

        Transform _camera; // Kamera x-y-z verileri

        void Awake()
        {
            _camera = Camera.main.transform; // Ana kameranın x-y-z değerleri _camera ile kaydedilir 
        }

        void LateUpdate()
        {
            transform.position = Vector3.Scale(_camera.position, movementScale); // Ana kameranın pozisyonu değiştirilir
        }

    }
}