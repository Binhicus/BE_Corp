using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicMusic : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void MusicUp()
   {
        //ambiance.volume = iTween.FloatUpdate(0.5f, 0, 1.2f);
        anim.CrossFade("MusicUp", 0.3f);
    }

   public void AmbianceUp()
   {
        anim.CrossFade("AmbianceUp", 0.3f);
        //ambiance.volume = iTween.FloatUpdate(0, 0.5f, 1.2f);
    }

}
