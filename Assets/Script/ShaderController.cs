using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShaderController : MonoBehaviour
{
    private static ShaderController m_Instance;
    public static ShaderController Instance;

    [SerializeField] private Material m_BasicMat;
    private Material m_SelectedMat;
    
    public Material BasicMat { get { return m_BasicMat; } }
    public Material SelectedMat { get { return m_SelectedMat; } }

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
   private  void Start()
    {
        m_SelectedMat = Instantiate(m_BasicMat);
        m_SelectedMat.SetFloat("_E_Emission", 100); 
    }
    private void OnDisable()
    {
        Destroy(m_SelectedMat);
    }
}
