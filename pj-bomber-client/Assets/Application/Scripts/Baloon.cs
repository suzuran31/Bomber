using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bomber
{
    /// <summary>
    /// •—‘D‚ÌƒNƒ‰ƒX
    /// </summary>
    public class Baloon : MonoBehaviour
    {
        public void Initialize(float sizeMin)
        {
            transform.localScale = new Vector3(sizeMin, sizeMin, 1);

        }

        public void UpdateScale(float scaleRatio)
        {
            transform.localScale = new Vector3(scaleRatio, scaleRatio, 0);
        }
    }
}