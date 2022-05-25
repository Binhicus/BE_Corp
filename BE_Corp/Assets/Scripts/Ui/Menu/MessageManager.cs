using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

enum DifferentNameInMessage{
Bots,
Employee,
Client,
Mission
}
public class MessageManager : MonoBehaviour
{
    public string CurrentName ;
    public Text StoryTextReference ;
    public Text EmployeeStoryTextRef ;
    public Flowchart FlowchartTextMenu ;
    public Text ClientMessageText ;

    public GameObject ChooseDiscussion ;
    public GameObject DiscussionLoading ;

    public Transform DiscussionDisplay ;
    public TextMeshProUGUI DiscussionWriterText ;
    public GameObject BotsNarratorTextPrefab;
    public GameObject EmployeeTextPrefab;    
    public GameObject ClientTextPrefab;
    public GameObject ClientWritePrefab ;
    private GameObject ClientWritePrefabInst ;
    public GameObject LunchMissionButtonPrefab ;

    public Button SendEmployeeMessageButton ;

    public SayDialog SD ;
    public BlockReference BR1, BRE1, BRE2, BRE3 ;
    private BlockReference CurrentBlockReference ;

    

    private int CurrentMissionDisplay = -5 ;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Discussion E1", 28);        
        //PlayerPrefs.SetInt("Dialogue L1", 0);        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentName = FlowchartTextMenu.GetStringVariable("Name");   
//        Debug.Log(FlowchartTextMenu.GetIntegerVariable("CurrentStateDiscussion")+  " + " + PlayerPrefs.GetInt(FlowchartTextMenu.GetStringVariable("DiscussionCurrent")));

        if(FlowchartTextMenu.GetIntegerVariable("CurrentStateDiscussion") >= PlayerPrefs.GetInt(FlowchartTextMenu.GetStringVariable("DiscussionCurrent")))
        {
            DiscussionLoading.SetActive(false) ;
            if(DiscussionDisplay.childCount > 2) SD.GetComponent<Writer>().writingSpeed = 20f ;


            if(FlowchartTextMenu.GetBooleanVariable("ClientWrite"))
            {
                if(StoryTextReference.text.Length != ClientMessageText.text.Length)
                {
                    if(!TheClientWritePrefabInst) InstantiateClientWrite() ; // InstantiateWriteAnimation
                } else {
                    FlowchartTextMenu.SetBooleanVariable("ClientWrite", false);                
                    TheClientWritePrefabInst = false ;
                    Destroy(ClientWritePrefabInst);
                    DisplayCompleteClientMessage();               
                    StopAllCoroutines(); 
                }
            }

            if(FlowchartTextMenu.GetBooleanVariable("EmployeeWrite"))
            {          
                DiscussionWriterText.text = EmployeeStoryTextRef.text.Substring(0, FlowchartTextMenu.GetIntegerVariable("EmployeeMessageDisp")) ;
                if(DiscussionWriterText.text.Length != EmployeeStoryTextRef.text.Length)
                {
                    if(Input.anyKey && (!Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2) && !Input.GetKey(KeyCode.KeypadEnter)) &&!Input.GetKeyDown(KeyCode.Return))
                    {
                        SetHeightWriterBox(725f, DiscussionWriterText);                       
                        FlowchartTextMenu.SetIntegerVariable("EmployeeMessageDisp", FlowchartTextMenu.GetIntegerVariable("EmployeeMessageDisp") + 1);
                    }
                } else {
                    if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
                    {
                        if(DiscussionDisplay.childCount != 0)   SendEmployeeMessage();
                    }
                } 
            }   

            if(!FlowchartTextMenu.GetBooleanVariable("EmployeeWrite") || (FlowchartTextMenu.GetBooleanVariable("EmployeeWrite") && DiscussionWriterText.text.Length != EmployeeStoryTextRef.text.Length))
            {
                SetEmployeeButton(false);
            } else {
                SetEmployeeButton(true);
            }
        } else {
            /*if(DiscussionDisplay.childCount > 2)*/ SD.GetComponent<Writer>().writingSpeed = 1000f ;
            DiscussionLoading.SetActive(true) ;

            if(FlowchartTextMenu.GetBooleanVariable("ClientWrite"))
            { 
                if(StoryTextReference.text.Length == ClientMessageText.text.Length)
                {
                    FlowchartTextMenu.SetBooleanVariable("ClientWrite", false);                
                    TheClientWritePrefabInst = false ;
                    Destroy(ClientWritePrefabInst);
                    DisplayCompleteClientMessage();               
                    StopAllCoroutines();                     
                }

            }

            if(FlowchartTextMenu.GetBooleanVariable("EmployeeWrite"))
            { 
                if(DiscussionWriterText.text.Length != EmployeeStoryTextRef.text.Length)
                {
                    if(DiscussionDisplay.childCount != 0)   SendEmployeeMessageExisted();                    
                }
            }
        }
    }

    public void CallNextDialog()
    {
        FlowchartTextMenu.SetBooleanVariable("CanDisplayNext", false) ; 
      //  if(FlowchartTextMenu.GetIntegerVariable("CurrentStateDiscussion") == PlayerPrefs.GetInt(FlowchartTextMenu.GetStringVariable("DiscussionCurrent"))) PlayerPrefs.SetInt(FlowchartTextMenu.GetStringVariable("DiscussionCurrent"), FlowchartTextMenu.GetIntegerVariable("CurrentStateDiscussion")  + 1) ;
        NewDialog();            
    }

    public void SendEmployeeMessage()
    {   
        if(CurrentName == DifferentNameInMessage.Employee.ToString() && DiscussionWriterText.text.Length == EmployeeStoryTextRef.text.Length)
        {
            GameObject EmployeeTextIns = Instantiate(EmployeeTextPrefab, DiscussionDisplay.transform);
            HeightDialogueDisplay();
            EmployeeTextIns.GetComponentInChildren<TextMeshProUGUI>().text = EmployeeStoryTextRef.text ;

            FlowchartTextMenu.SetBooleanVariable("EmployeeWrite", false);
            DiscussionWriterText.text = "..." ;
            EmployeeStoryTextRef.text = "..." ;

            Vector2 NewSize ;

            if(EmployeeTextIns.GetComponentInChildren<TextMeshProUGUI>().preferredWidth < 460f)
            {
                NewSize.x = EmployeeTextIns.GetComponentInChildren<TextMeshProUGUI>().preferredWidth ;
            } else {
                NewSize.x =  460f ;
            }

            NewSize.y = EmployeeTextIns.GetComponentInChildren<TextMeshProUGUI>().preferredHeight + 20f ; 

            EmployeeTextIns.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(NewSize.x + 15f, NewSize.y) ;
            EmployeeTextIns.GetComponent<RectTransform>().sizeDelta = new Vector2(EmployeeTextIns.GetComponent<RectTransform>().sizeDelta.x, NewSize.y)  ;

            SetHeightWriterBox(725f, DiscussionWriterText);    

            StartCoroutine(WaitBeforeAutorizedNextDialogue(0.5f));  
        }  
    }

    void SendEmployeeMessageExisted()
    {   
        GameObject EmployeeTextIns = Instantiate(EmployeeTextPrefab, DiscussionDisplay.transform);
//        HeightDialogueDisplay();
        EmployeeTextIns.GetComponentInChildren<TextMeshProUGUI>().text = EmployeeStoryTextRef.text ;

        FlowchartTextMenu.SetBooleanVariable("EmployeeWrite", false);
        DiscussionWriterText.text = "..." ;
        EmployeeStoryTextRef.text = "..." ;

        Vector2 NewSize ;

        if(EmployeeTextIns.GetComponentInChildren<TextMeshProUGUI>().preferredWidth < 460f)
        {
            NewSize.x = EmployeeTextIns.GetComponentInChildren<TextMeshProUGUI>().preferredWidth ;
        } else {
            NewSize.x =  460f ;
        }

        NewSize.y = EmployeeTextIns.GetComponentInChildren<TextMeshProUGUI>().preferredHeight + 20f ; 

        EmployeeTextIns.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(NewSize.x + 15f, NewSize.y) ;
        EmployeeTextIns.GetComponent<RectTransform>().sizeDelta = new Vector2(EmployeeTextIns.GetComponent<RectTransform>().sizeDelta.x, NewSize.y)  ;

        //SetHeightWriterBox(725f, DiscussionWriterText);    

        StartCoroutine(WaitBeforeAutorizedNextDialogue(0.5f));  
 
    }

    bool TheClientWritePrefabInst = false ;
    void InstantiateClientWrite()
    {
        TheClientWritePrefabInst = true ;
        GameObject ClientWriteIns = Instantiate(ClientWritePrefab, DiscussionDisplay.transform);
        HeightDialogueDisplay();
        ClientWritePrefabInst = ClientWriteIns ;   
       // ClientWritePrefabInst.transform.SetSiblingIndex(1);

        //PlayerPrefs.SetInt(FlowchartTextMenu.GetStringVariable("DiscussionCurrent"), FlowchartTextMenu.GetIntegerVariable("CurrentStateDiscussion")) ;

    }

    void DisplayCompleteClientMessage()
    {
       // PlayerPrefs.SetInt(FlowchartTextMenu.GetStringVariable("DiscussionCurrent"), FlowchartTextMenu.GetIntegerVariable("CurrentStateDiscussion")) ;


        GameObject ClientTextIns = Instantiate(ClientTextPrefab, DiscussionDisplay.transform);

        ClientTextIns.GetComponentInChildren<TextMeshProUGUI>().text = StoryTextReference.text ;

        Vector2 NewSize ;

        if(ClientTextIns.GetComponentInChildren<TextMeshProUGUI>().preferredWidth < 455f)
        {
            NewSize.x = ClientTextIns.GetComponentInChildren<TextMeshProUGUI>().preferredWidth ;
        } else {
            NewSize.x =  460f ;
        }

        NewSize.y = ClientTextIns.GetComponentInChildren<TextMeshProUGUI>().preferredHeight + 20f ; 

        ClientTextIns.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(NewSize.x + 15f, NewSize.y) ;
        ClientTextIns.GetComponent<RectTransform>().sizeDelta = new Vector2(ClientTextIns.GetComponent<RectTransform>().sizeDelta.x, NewSize.y)  ;          
        
        HeightDialogueDisplay();
    }

    public void DisplayMission(int BRNumber)
    {
        ChooseDiscussion.SetActive(false);
        DiscussionLoading.SetActive(false);
        
        if(FlowchartTextMenu.GetStringVariable("DiscussionCurrent") != "")
        {
            if(FlowchartTextMenu.GetIntegerVariable("CurrentStateDiscussion") >= PlayerPrefs.GetInt(FlowchartTextMenu.GetStringVariable("DiscussionCurrent")) && DiscussionDisplay.childCount != 0) PlayerPrefs.SetInt(FlowchartTextMenu.GetStringVariable("DiscussionCurrent"), FlowchartTextMenu.GetIntegerVariable("CurrentStateDiscussion")) ;
            //Debug.Log(FlowchartTextMenu.GetStringVariable("DiscussionCurrent") +  " : " + FlowchartTextMenu.GetIntegerVariable("CurrentStateDiscussion") +  " + " + PlayerPrefs.GetInt(FlowchartTextMenu.GetStringVariable("DiscussionCurrent")));
        }

        if(CurrentMissionDisplay != BRNumber)
        {
            if(BRNumber == 1) LunchDiscussion(BR1, 1);
            if(BRNumber == -1) LunchDiscussion(BRE1, -1);
            if(BRNumber == -2) LunchDiscussion(BRE2, -2);
            if(BRNumber == -3) LunchDiscussion(BRE3, -3);
        }
    }

    void LunchDiscussion(BlockReference BRNeed, int BRNumber)
    {
        foreach (Transform Child in DiscussionDisplay.transform)
        {
            Destroy(Child.gameObject) ;
        }

        if(CurrentBlockReference.block != null) CurrentBlockReference.block.Stop();        
        BRNeed.Execute();
        CurrentBlockReference = BRNeed ;
        CurrentMissionDisplay = BRNumber ;
    }

    void HeightDialogueDisplay()
    {
        float TotalHeight = 0 ;
        foreach (RectTransform Child in DiscussionDisplay)
        {
            TotalHeight += Child.GetComponent<RectTransform>().sizeDelta.y + 10f;
        }
        
        TotalHeight += DiscussionDisplay.GetComponent<VerticalLayoutGroup>().spacing * (DiscussionDisplay.transform.childCount - 1) ;

        if(TotalHeight < 850f) 
        {
            DiscussionDisplay.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
            DiscussionDisplay.GetComponent<RectTransform>().sizeDelta = new Vector2(840f,  850f) ;

            DiscussionDisplay.transform.parent.GetComponent<ScrollRect>().enabled = false ;
            DiscussionDisplay.transform.parent.GetComponent<ScrollRect>().verticalScrollbar.gameObject.SetActive(false) ;

        } else {
            DiscussionDisplay.GetComponent<RectTransform>().anchoredPosition = new Vector2(-15f, 0);
            DiscussionDisplay.GetComponent<RectTransform>().sizeDelta = new Vector2(820f, TotalHeight) ;

            DiscussionDisplay.transform.parent.GetComponent<ScrollRect>().enabled = true ;
            DiscussionDisplay.transform.parent.GetComponent<ScrollRect>().verticalScrollbar.gameObject.SetActive(true) ;
        }
    }

    void NewDialog()
    {
        if(CurrentName == DifferentNameInMessage.Bots.ToString())
        {
            if(DiscussionDisplay.childCount == 0 || DiscussionDisplay.GetChild(DiscussionDisplay.childCount -1).name != "Bots Narrator Prefab(Clone)")
            {
                GameObject BotsNarratorIns = Instantiate(BotsNarratorTextPrefab, DiscussionDisplay.transform);
                BotsNarratorIns.GetComponentInChildren<TextMeshProUGUI>().text = StoryTextReference.text ;
                BotsNarratorIns.GetComponent<RectTransform>().sizeDelta = new Vector2(BotsNarratorIns.GetComponent<RectTransform>().sizeDelta.x, BotsNarratorIns.GetComponentInChildren<TextMeshProUGUI>().preferredHeight + 10f)  ;
                
              //  PlayerPrefs.SetInt(FlowchartTextMenu.GetStringVariable("DiscussionCurrent"), FlowchartTextMenu.GetIntegerVariable("CurrentStateDiscussion")) ;

                StartCoroutine(WaitBeforeAutorizedNextDialogue(0.1f));
                HeightDialogueDisplay();                   
            }
        }  

        if(CurrentName == DifferentNameInMessage.Mission.ToString())
        {
            GameObject LunchMissionInst = Instantiate(LunchMissionButtonPrefab, DiscussionDisplay.transform);
            if(FlowchartTextMenu.GetStringVariable("DiscussionCurrent") == "Discussion E1") LunchMissionInst.GetComponentInChildren<Button>().interactable = false ;

           if(FlowchartTextMenu.GetStringVariable("DiscussionCurrent") != "")
            {
                if(FlowchartTextMenu.GetIntegerVariable("CurrentStateDiscussion") >= PlayerPrefs.GetInt(FlowchartTextMenu.GetStringVariable("DiscussionCurrent")) && DiscussionDisplay.childCount != 0) PlayerPrefs.SetInt(FlowchartTextMenu.GetStringVariable("DiscussionCurrent"), FlowchartTextMenu.GetIntegerVariable("CurrentStateDiscussion")) ;
            }

            StartCoroutine(WaitBeforeAutorizedNextDialogue(0.1f));
            HeightDialogueDisplay();                   
        } 

    }

    bool newBotsmessage = true ;
    IEnumerator WaitBeforeNEwBotsMesssage()
    {
        yield return new WaitForSeconds(0.1f);
        newBotsmessage = true ;
    }

    void SetHeightWriterBox(float WidthMax, TextMeshProUGUI TMPCurrent)
    {
        Vector2 NewSize ;

        if(TMPCurrent.preferredHeight > 0)    NewSize.y = TMPCurrent.preferredHeight + 20f ; 
        else NewSize.y = 50f ;
    


        TMPCurrent.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(TMPCurrent.transform.parent.GetComponent<RectTransform>().sizeDelta.x, NewSize.y)  ;
        TMPCurrent.transform.parent.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(TMPCurrent.transform.parent.transform.parent.GetComponent<RectTransform>().sizeDelta.x, NewSize.y + 20f)  ;  
        TMPCurrent.transform.parent.transform.parent.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(TMPCurrent.transform.parent.transform.parent.transform.parent.GetComponent<RectTransform>().sizeDelta.x, NewSize.y + 30f)  ;  
        
        DiscussionDisplay.transform.parent.GetComponent<RectTransform>().offsetMin = new Vector2(DiscussionDisplay.transform.parent.GetComponent<RectTransform>().offsetMin.x, (NewSize.y + 31f));
        
        DiscussionDisplay.GetComponent<VerticalLayoutGroup>().spacing = 5f ;
    }


    bool WriteCoroutineLunch = false ;
    IEnumerator HeightDuringWriting(float WidthMax, TextMeshProUGUI TMPCurrent)
    {
        WriteCoroutineLunch = true;
        Vector2 NewSize ;
        int NumDivision = 0 ;

        while( ( (TMPCurrent.preferredWidth - (WidthMax * NumDivision) ) > WidthMax))
        {
            NumDivision += 1 ;
        }

        int GoodHeightIns = 0 ;
        while(GoodHeightIns <= NumDivision)
        {
            NewSize.y =  50f + (28f * GoodHeightIns) ; 

            TMPCurrent.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(TMPCurrent.transform.parent.GetComponent<RectTransform>().sizeDelta.x, NewSize.y)  ;
            TMPCurrent.transform.parent.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(TMPCurrent.transform.parent.transform.parent.GetComponent<RectTransform>().sizeDelta.x, NewSize.y + 20f)  ;  
            DiscussionDisplay.GetComponent<VerticalLayoutGroup>().spacing = 0f ;
            DiscussionDisplay.GetComponent<VerticalLayoutGroup>().spacing = 0f ;

            yield return new WaitForSeconds(1.25f) ;    
            GoodHeightIns++ ;                                          
        }
    }

  /*  void SetFinalHeight(float WidthMax, TextMeshProUGUI TMPCurrent)
    {
        Vector2 NewSize ;
        int NumDivision = 1 ;

        while( ( (TMPCurrent.preferredWidth - (WidthMax * NumDivision) ) > WidthMax))
        {
            NumDivision += 1 ;
        }

        NewSize.y =  50f + (25f * NumDivision) ; 

        TMPCurrent.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(TMPCurrent.transform.parent.GetComponent<RectTransform>().sizeDelta.x, NewSize.y)  ;
        TMPCurrent.transform.parent.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(TMPCurrent.transform.parent.transform.parent.GetComponent<RectTransform>().sizeDelta.x, NewSize.y + 20f)  ;  
        TMPCurrent.transform.parent.transform.parent.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(TMPCurrent.transform.parent.transform.parent.transform.parent.GetComponent<RectTransform>().sizeDelta.x, NewSize.y + 30f)  ;  
        
        DiscussionDisplay.transform.parent.GetComponent<RectTransform>().offsetMin = new Vector2(DiscussionDisplay.transform.parent.GetComponent<RectTransform>().offsetMin.x, (NewSize.y + 31f));
        
        DiscussionDisplay.GetComponent<VerticalLayoutGroup>().spacing = 0f ;
    }
*/

    IEnumerator WaitBeforeAutorizedNextDialogue(float Delay)
    {
        yield return new WaitForSeconds(Delay);
        FlowchartTextMenu.SetBooleanVariable("CanDisplayNext", true) ; 
    }


    void SetEmployeeButton(bool StateDisplay)
    {
        if(!StateDisplay)
        {
            SendEmployeeMessageButton.interactable = false ;
        } else {
            SendEmployeeMessageButton.interactable = true ;
        }
    }
}
