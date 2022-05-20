#if UNITY_EDITOR
using UnityEngine;

namespace Metroidvania
{
    /// <summary>Object for handle all gizmos color used in game</summary>
    [ResourceObjectPath("Data/Editor/Gizmos Color")]
    public class GizmosColor : ScriptableSingleton<GizmosColor>
    {
        [Header("Player")]
        public Color playerFeet = Color.green;
        public Color playerHand = Color.yellow;
        public Color playerLedgeCheck = Color.red;
        public Color playerAttack = Color.cyan;
    }
}
#endif