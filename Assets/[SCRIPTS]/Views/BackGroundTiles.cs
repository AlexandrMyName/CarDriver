using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.BackGround
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BackGroundTiles : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private float _realitiveSpeedRate;

        private Vector2 _size;
        private Vector3 _cachedPosition;


        private float LeftBorder => _cachedPosition.x - _size.x/2;
        private float RightBorder => _cachedPosition.x + _size.x / 2;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            _cachedPosition = transform.position;
            _size = spriteRenderer.size;
        }

        private void OnValidate()
        {
            spriteRenderer ??= GetComponent<SpriteRenderer>();
        }

        public void Move(float value)
        {
            Vector3 position = transform.position;
            position += Vector3.right * value * _realitiveSpeedRate;

            if(position.x <= LeftBorder)
                position.x = RightBorder - (LeftBorder - position.x);

            if (position.x >= RightBorder)
                position.x = LeftBorder + (RightBorder - position.x);
            transform.position = position;
        }
    }
}
