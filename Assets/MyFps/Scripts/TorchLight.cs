using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace MyFps
{
    public class TorchLight : MonoBehaviour
    {
        #region Variables

        public Transform torchLight;
        private Animator animator;
        [SerializeField] private float countdown;
        [SerializeField] private float setTimer = 1f;

        private int lightMode;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            animator = torchLight.GetComponent<Animator>();
            countdown = setTimer;
            InvokeRepeating("LightAnimation", 1f, countdown);
            //lightMode = 0;
        }

        // Update is called once per frame
        void Update()
        {
            //if ((lightMode==0))
            //{
                //StartCoroutine(FlameAnimation());
            //}

            //Debug.Log(Random.Range(1, 4));
            //if (countdown <= 0f)
            //{
            //    animator.SetInteger("LightMode", Random.Range(1, 4));
            //    countdown = setTimer;
            //}
            //countdown -= Time.deltaTime;
        }

        void LightAnimation()
        {
            animator.SetInteger("LightMode", Random.Range(1, 4));
        }

        //IEnumerator FlameAnimation()
        //{
        //    animator.SetInteger("LightMode", Random.Range(1, 4));
        //    yield return new WaitForSeconds(countdown);
        //  lightMode=0;
        //}

    }
}