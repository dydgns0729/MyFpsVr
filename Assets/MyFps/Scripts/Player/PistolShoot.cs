using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class PistolShoot : MonoBehaviour
    {
        #region Variables
        public ParticleSystem muzzle;
        Animator animator;
        public AudioSource pistolShot;

        public Transform camera;
        public Transform firePoint;

        //공격력
        [SerializeField] private float attackDamage = 5f;

        //연사 딜레이
        [SerializeField] private float fireDelay = 0.5f;
        private bool isFire;

        public GameObject hitImpactPrefab;
        #endregion
        void Awake()
        {
            //참조
            animator = GetComponent<Animator>();
            isFire = false;
        }

        void Update()
        {
            //슛
            if (Input.GetButtonDown("Fire") && !isFire)
            {
                if (PlayerStats.Instance.UseAmmo(1))
                {
                    StartCoroutine(Shoot());
                }
            }
        }

        IEnumerator Shoot()
        {
            muzzle.Play();

            isFire = true;
            //내앞에 100안에 적이 있으면 적에게 데미지를 준다
            float maxDistance = 100f; // 사거리
            RaycastHit hit;
            if (Physics.Raycast(camera.position, camera.TransformDirection(Vector3.forward), out hit, maxDistance))
            {
                //Hit임팩트 효과
                GameObject eff = Instantiate(hitImpactPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(eff, 2f);

                //적에게 데미지를 준다
                //Debug.Log($"{hit.transform.name}에게 데미지를 준다");
                IDamageable damageable = hit.transform.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.TakeDamage(attackDamage);
                }


            }
            //슛효과 - VFX, SFX
            animator.SetTrigger("Fire");

            pistolShot.Play();
            yield return new WaitForSeconds(fireDelay);

            isFire = false;
        }

        //Gizmo 그리기 : 총 위치에서 앞에 충돌체까지 레이저 쏘는 선 그리기
        private void OnDrawGizmosSelected()
        {
            float maxDistance = 100f; // 레이 길이
            RaycastHit hit;
            bool isHit = Physics.Raycast(camera.position, camera.TransformDirection(Vector3.forward), out hit, maxDistance);

            Gizmos.color = Color.red;
            if (isHit)
            {
                Gizmos.DrawRay(camera.position, camera.forward * hit.distance);
            }
            else
            {
                Gizmos.DrawRay(camera.position, camera.forward * maxDistance);
            }
        }
    }
}