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
Client
}
public class MessageManager : MonoBehaviour
{
    public string CurrentName ;
    public Text StoryTextReference ;
    public Text CompleteStoryTextRefence ;
    public Flowchart FlowchartTextMenu ;
    public Text ClientMessageText ;

    public Transform DiscussionDisplay ;
    public TextMeshProUGUI DiscussionWriterText ;
    public GameObject BotsNarratorTextPrefab;
    public GameObject EmployeeTextPrefab;    
    public GameObject ClientTextPrefab;
    public GameObject ClientWritePrefab ;
    private GameObject ClientWritePrefabInst ;


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
            if(StoryTextReference.text.Length != CompleteStoryTextRefence.text.Length)
            {
                DiscussionWriterText.text = StoryTextReference.text ;
                if(!WriteCoroutineLunch) StartCoroutine(HeightDuringWriting(725f, DiscussionWriterText));
            } else {
                FlowchartTextMenu.SetBooleanVariable("EmployeeWrite", false);     
                SetFinalHeight(725f, DiscussionWriterText);
                DiscussionWriterText.text = StoryTextReference.text ;                           
                StopAllCoroutines(); 
            }
        }      
    }

    public void CallNextDialog()
    {
        FlowchartTextMenu.SetBooleanVariable("CanDisplayNext", false) ; 
        NewDialog();
    }

    public void SendEmployeeMessage()
    {   if(CurrentName == DifferentNameInMessage.Employee.ToString())
        {
            DiscussionWriterText.text = "..." ;
            SetFinalHeight(725f, DiscussionWriterText);

            GameObject EmployeeTextIns = Instantiate(EmployeeTextPrefab, DiscussionDisplay.transform);
            HeightDialogueDisplay();
            //EmployeeTextIns.transform.SetSiblingIndex(1);
            EmployeeTextIns.GetComponentInChildren<TextMeshProUGUI>().text = StoryTextReference.text ;

            Vector2 NewSize ;

            if(EmployeeTextIns.GetComponentInChildren<TextMeshProUGUI>().preferredWidth < 460f)
            {
                NewSize.x = EmployeeTextIns.GetComponentInChildren<TextMeshProUGUI>().preferredWidth ;
            } else {
                NewSize.x =  460f ;
            }

            int NumDivision = 0 ;

            while((EmployeeTextIns.GetComponentInChildren<TextMeshProUGUI>().preferredWidth - (445f * NumDivision)) > 445f)
            {
                NumDivision++;
            }

            NewSize.y =  50f + 28f * NumDivision ; 

            EmployeeTextIns.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(NewSize.x + 15f, NewSize.y) ;
            EmployeeTextIns.GetComponent<RectTransform>().sizeDelta = new Vector2(EmployeeTextIns.GetComponent<RectTransform>().sizeDelta.x, NewSize.y + 15f)  ;

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
       // ClientTextIns.transform.SetSiblingIndex(1);
        ClientTextIns.GetComponentInChildren<TextMeshProUGUI>().text = StoryTextReference.text ;

        Vector2 NewSize ;

        if(ClientTextIns.GetComponentInChildren<TextMeshProUGUI>().preferredWidth < 455f)
        {
            NewSize.x = ClientTextIns.GetComponentInChildren<TextMeshProUGUI>().preferredWidth ;
        } else {
            NewSize.x =  460f ;
        }

        int NumDivision = 0 ;

        while((ClientTextIns.GetComponentInChildren<TextMeshProUGUI>().preferredWidth - (445f * NumDivision)) > 445f)
        {
            NumDivision++;
        }

        NewSize.y =  50f + 28f * NumDivision ; 

        ClientTextIns.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(NewSize.x + 15f, NewSize.y) ;
        ClientTextIns.GetComponent<RectTransform>().sizeDelta = new Vector2(ClientTextIns.GetComponent<RectTransform>().sizeDelta.x, NewSize.y + 15f)  ;          
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
            TotalHeight += Child.GetComponent<RectTransform>().sizeDelta.y ;
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
            GameObject BotsNarratorIns = Instantiate(BotsNarratorTextPrefab, DiscussionDisplay.transform);
            BotsNarratorIns.GetComponentInChildren<TextMeshProUGUI>().text = StoryTextReference.text ;
            BotsNarratorIns.GetComponent<RectTransform>().sizeDelta = new Vector2(BotsNarratorIns.GetComponent<RectTransform>().sizeDelta.x, BotsNarratorIns.GetComponentInChildren<TextMeshProUGUI>().preferredHeight + 10f)  ;
            BR.block.DOTogglePause();            
            StartCoroutine(WaitBeforeAutorizedNextDialogue(0.1f));
            HeightDialogueDisplay();            
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

    void GetsAllPrecedentDialog()
    {

    }

    void SetHeightWriterBox(float WidthMax, TextMeshProUGUI TMPCurrent)
    {
        Vector2 NewSize ;
        int NumDivision = 0 ;

        while((TMPCurrent.preferredWidth - (TMPCurrent.preferredWidth * NumDivision)) > WidthMax)
        {
            NumDivision++;
        }

        NewSize.y =  50f + (15f * NumDivision) ; 

        TMPCurrent.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(TMPCurrent.transform.parent.GetComponent<RectTransform>().sizeDelta.x, NewSize.y)  ;
        TMPCurrent.transform.parent.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(TMPCurrent.transform.parent.transform.parent.GetComponent<RectTransform>().sizeDelta.x, NewSize.y)  ;
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

    void SetFinalHeight(float WidthMax, TextMeshProUGUI TMPCurrent)
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
        DiscussionDisplay.GetComponent<VerticalLayoutGroup>().spacing = 0f ;
    }


    IEnumerator WaitBeforeAutorizedNextDialogue(float Delay)
    {
        yield return new WaitForSeconds(Delay);
        FlowchartTextMenu.SetBooleanVariable("CanDisplayNext", true) ; 
    }
}
