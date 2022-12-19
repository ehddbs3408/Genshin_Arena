using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSkillHit : MonoBehaviour
{
    [SerializeField] private GameObject DamagePopupPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Skill"))
        {
            if (DamagePopupPrefab != null)
            {
                ShowDamagePopup();
            }
        }
    }
    
    void ShowDamagePopup()
    {
        GameObject go = Managers.Resource.Instantiate("DamagePopup",transform);
        go.GetComponent<TextMesh>().text = PlayerAbility.swordPower.ToString();
    }
}
