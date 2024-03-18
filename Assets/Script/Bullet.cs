using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody m_RBody;

    private void OnEnable()
    {
    }
    private void OnDisable()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<Monster>().MonsterHit(2);
            Destroy(gameObject);
        }
    }

    public void ShotBullet(Vector3 _Vec3, float _Power)
    {
        _Vec3.z *= _Power;
        m_RBody.AddForce(_Vec3, ForceMode.Impulse);
    }


}
