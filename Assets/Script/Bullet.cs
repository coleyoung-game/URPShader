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

    public void ShotBullet(float _Power)
    {
        m_RBody.AddForce(new Vector3(0, 0, _Power), ForceMode.Impulse);
    }


}
