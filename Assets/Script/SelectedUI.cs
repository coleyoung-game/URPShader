using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectedUI : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private Image m_Image;
    // Start is called before the first frame update
    private void Start()
    {
        m_Image = GetComponent<Image>();
    }
    public void OnDeselect(BaseEventData eventData)
    {
        m_Image.material = ShaderController.Instance.BasicMat;
    }

    public void OnSelect(BaseEventData eventData)
    {
        m_Image.material = ShaderController.Instance.SelectedMat;
    }




    
}
