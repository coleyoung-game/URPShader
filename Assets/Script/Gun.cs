using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet m_Bullet;
    [SerializeField] private float m_ShotPower;
    
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            GunShot();
        }
    }
    
    private void GunShot()
    {
        Bullet t_Bullet = Instantiate(m_Bullet.gameObject).GetComponent<Bullet>();
        t_Bullet.transform.position = transform.position;
        t_Bullet.transform.rotation = Quaternion.identity;
        t_Bullet.ShotBullet(m_ShotPower);
    }
}
