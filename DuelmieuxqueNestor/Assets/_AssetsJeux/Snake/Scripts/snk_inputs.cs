using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class snk_inputs : MonoBehaviour
    {
        [Header("Inputs")]
        [SerializeField] KeyCode _up;
        [SerializeField] KeyCode _down;
        [SerializeField] KeyCode _left;
        [SerializeField] KeyCode _right;

        public float getAxis_Horizontal()
        {
            float r = 0;
            if (Input.GetKey(_left)) r -= 1;
            if (Input.GetKey(_right)) r += 1;
            return r;
        }

        public float getAxis_Vertical()
        {
            float r = 0;
            if (Input.GetKey(_down)) r -= 1;
            if (Input.GetKey(_up)) r += 1;
            return r;
        }

        public Vector2 getInputVector() => new Vector2(getAxis_Horizontal(), getAxis_Vertical());
    }
}