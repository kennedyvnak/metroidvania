using Metroidvania.Serialization;
using UnityEngine;

namespace Metroidvania.Player.SafePoints
{
    public class PlayerSafePoint : MonoBehaviour
    {
        public PlayerSafePointsArea area { get; internal set; }

        [SerializeField] private Vector2 m_triggerSize;
        public Vector2 triggerSize => m_triggerSize;

        [SerializeField] private Vector2 m_triggerOffset;
        public Vector2 triggerOffset => m_triggerOffset;

        [SerializeField] private Vector2 m_relativePoint;
        public Vector2 relativePoint => m_relativePoint;

        [SerializeField] private bool m_facingRight;
        public bool facingRight => m_facingRight;

        [SerializeField] private SerializableGuid m_guid;
        public System.Guid guid => m_guid;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player") && other.TryGetComponent<PlayerController>(out PlayerController player))
            {
                GameData gameData = DataManager.instance.gameData;
                gameData.lastPlayerSafePoint.pointGuid = m_guid;
                gameData.lastPlayerSafePoint.sceneGUID = area.sceneGUID;
            }
        }

#if UNITY_EDITOR
        private void Reset()
        {
            GenerateGUID();
        }

        private void GenerateGUID()
        {
            m_guid = System.Guid.NewGuid();
            UnityEditor.EditorUtility.SetDirty(this);
        }
#endif
    }
}