using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    

    [SerializeField]
    Sprite[] animSprites = null;

    [SerializeField]
    SpriteRenderer headRenderer = null;

    [SerializeField]
    int currentFaceID = 0;

    int blinking = 0;
    float blinkingValue = 0;
    float blinkingTimer = 0;
    float blinkingTimerTotal = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        headRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    
    void Update()
    {
        blinkingTimer += Time.deltaTime;
        if (blinking == 0 && (Random.value < 0.001f || blinkingTimer > blinkingTimerTotal))
        {
            blinkingTimer = 0;
            blinkingTimerTotal = Random.Range(1.1f, 5.01f);
            blinking = 1;
            blinkingValue = 0;
        }
        else if (blinking == 1)
        {
            blinkingValue += Time.deltaTime * 1000;
            if (blinkingValue > 100)
            {
                blinking = 2;
                headRenderer.sprite = animSprites[currentFaceID];

            }
            else
            {
                headRenderer.sprite = animSprites[1];
            }
        }
        else if (blinking == 2)
        {
            blinkingValue -= Time.deltaTime * 600;
            if (blinkingValue < 0)
            {
                blinking = 0;

                headRenderer.sprite = animSprites[currentFaceID];

            }
            else
            {
                headRenderer.sprite = animSprites[1];
            }
        }
    }

    
    //Old showAnimation function
    /*
    public void ShowAnimation(string animID)
    {
        for (int i = 0; i < 60; i++)
        {
            if (i != 1)
            {
                face_Blendshape.SetBlendShapeWeight(i, 0);
            }
        }

        if (animID == "idle")
        {
            if (Random.value < 0.3f)
            {
                anim.SetTrigger("idle1");
            }
            else if (Random.value < 0.6f)
            {
                anim.SetTrigger("idle2");
            }
            else
            {
                anim.SetTrigger("idle");
            }
            if(Random.value < 0.5f)
            {
                face_Blendshape.SetBlendShapeWeight(9, 100);
            }
            else
            {
                face_Blendshape.SetBlendShapeWeight(24, 67);
            }
        }
        else if (animID == "shy")
        {
            anim.SetTrigger("shy");
        }
        else if (animID == "confuse")
        {
            anim.SetTrigger("confuse");
            face_Blendshape.SetBlendShapeWeight(32, 100);
        }
        else if (animID == "joking")
        {
            anim.SetTrigger("joking");
            face_Blendshape.SetBlendShapeWeight(33, 100);
        }
        else if (animID == "worried")
        {
            anim.SetTrigger("worried");
            face_Blendshape.SetBlendShapeWeight(52, 100);
        }
        else if (animID == "surprise")
        {
            anim.SetTrigger("surprise");
            face_Blendshape.SetBlendShapeWeight(53, 100);
        }
        else if (animID == "focus")
        {
            anim.SetTrigger("focus");
            face_Blendshape.SetBlendShapeWeight(50, 100);
        }
        else if (animID == "angry")
        {
            anim.SetTrigger("angry");
            face_Blendshape.SetBlendShapeWeight(49, 100);
        }
        else if (animID == "cheers")
        {
            anim.SetTrigger("cheers");
            face_Blendshape.SetBlendShapeWeight(24, 100);
        }
        else if (animID == "nod")
        {
            anim.SetTrigger("nod");
            face_Blendshape.SetBlendShapeWeight(9, 100);
        }
        else if (animID == "waving_arm")
        {
            anim.SetTrigger("waving_arm");
            face_Blendshape.SetBlendShapeWeight(24, 100);
        }
        else if (animID == "proud")
        {
            anim.SetTrigger("proud");
            face_Blendshape.SetBlendShapeWeight(24, 100);
        }
    }

    */
    public void ShowAnimation(string animID)
    {

        if (animID == "idle")
        {
            currentFaceID = 0;
            headRenderer.sprite = animSprites[0];
        }
        else if (animID == "angry")
        {

            currentFaceID = 2;
            headRenderer.sprite = animSprites[2];
        }
        else if (animID == "kaboom")
        {

            currentFaceID = 3;
            headRenderer.sprite = animSprites[3];
        }
        else if (animID == "suspicious")
        {

            currentFaceID = 4;
            headRenderer.sprite = animSprites[4];
        }

    }
}
