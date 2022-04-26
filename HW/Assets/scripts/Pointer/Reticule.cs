using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticule : MonoBehaviour
{

    public Pointer m_Pointer;
    public SpriteRenderer m_Circlerenderer;

    public Sprite m_OpenSprite;
    public Sprite m_ClosedSprite;

    private Camera m_Camera = null;

    private void Awake()
    {
        m_Pointer.OnPointerUpdate += UpdateSprite;

        m_Camera = Camera.main;

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(m_Camera.gameObject.transform);
    }

    private void OnDestroy()
    {
        m_Pointer.OnPointerUpdate -= UpdateSprite;
    }

    private void UpdateSprite(Vector3 point, GameObject hitObject)
    {
        transform.position = point;

        if (hitObject) {
            m_Circlerenderer.sprite = m_ClosedSprite;
        }
        else
        {
            m_Circlerenderer.sprite = m_OpenSprite;
        }
    }
}
