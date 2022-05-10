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

    public Transform DiscussionDisplay ;
    public TextMeshProUGUI DiscussionWriterText ;
    public GameObject BotsNarratorTextPrefab;
    public GameObject EmployeeTextPrefab;    
    public GameObject ClientTextPrefab;
    public GameObject ClientWritePrefab ;
    private GameObject ClientWritePrefabInst ;
    public GameObject LunchMissionButtonPrefab ;


    public BlockReference BR ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentName = FlowchartTextMenu.GetStringVariable("Name"); 

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
                if(Input.anyKey && (!Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1) && !Input.GetMouseButtonDown(2) && !Input.GetKeyDown(KeyCode.KeypadEnter)))
                {
                    SetHeightWriterBox(725f, DiscussionWriterText);                       
                    FlowchartTextMenu.SetIntegerVariable("EmployeeMessageDisp", FlowchartTextMenu.GetIntegerVariable("EmployeeMessageDisp") + 1);
   
                }
            } else {
                if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
                {
                    SendEmployeeMessage();
                }
            } 
        }   
    }

    public void CallNextDialog()
    {
        FlowchartTextMenu.SetBooleanVariable("CanDisplayNext", false) ; 
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

    bool TheClientWritePrefabInst = false ;
    void InstantiateClientWrite()
    {
        TheClientWritePrefabInst = true ;
        GameObject ClientWriteIns = Instantiate(ClientWritePrefab, DiscussionDisplay.transform);
        HeightDialogueDisplay();
        ClientWritePrefabInst = ClientWriteIns ;   
       // ClientWritePrefabInst.transform.SetSiblingIndex(1);
    }

    void DisplayCompleteClientMessage()
    {
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
    }

    public void DisplayMission()
    {
        if(DiscussionDisplay.childCount < 2)    BR.Execute();
    }

    void HeightDialogueDisplay()
    {
        float TotalHeight = 0 ;
        foreach (RectTransform Child in DiscussionDisplay)
        {
            TotalHeight += Child.GetComponent<RectTransform>().sizeDelta.y + 10f;
        }

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

                StartCoroutine(WaitBeforeAutorizedNextDialogue(0.1f));
                HeightDialogueDisplay();                   
            }
        }  

        if(CurrentName == DifferentNameInMessage.Mission.ToString())
        {
          /*  if(DiscussionDisplay.childCount == 0 || DiscussionDisplay.GetChild(DiscussionDisplay.childCount -1).name != "Bots Narrator Prefab(Clone)")
            {*/
                GameObject LunchMissionInst = Instantiate(LunchMissionButtonPrefab, DiscussionDisplay.transform);
           /*     BotsNarratorIns.GetComponentInChildren<TextMeshProUGUI>().text = StoryTextReference.text ;
                BotsNarratorIns.GetComponent<RectTransform>().sizeDelta = new Vector2(BotsNarratorIns.GetComponent<RectTransform>().sizeDelta.x, BotsNarratorIns.GetComponentInChildren<TextMeshProUGUI>().preferredHeight + 10f)  ;
*/
                StartCoroutine(WaitBeforeAutorizedNextDialogue(0.1f));
                HeightDialogueDisplay();                   
            //}
        } 

    /*    if(CurrentName == DifferentNameInMessage.Employee.ToString())
        {
            FlowchartTextMenu.SetBooleanVariable("EmployeeWrite", true);
        }  

        if(CurrentName == DifferentNameInMessage.Client.ToString())
        {
            FlowchartTextMenu.SetBooleanVariable("ClientWrite", true);
        }        */
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
}
