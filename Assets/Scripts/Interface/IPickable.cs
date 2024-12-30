using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable
{
    void ShowInform();
    void HideInform();
    void OnInteract(PlayerInteraction player);

}
