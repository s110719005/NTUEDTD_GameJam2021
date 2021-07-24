using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    
    [SerializeField]private RectTransform buttonPanel; //-1200 - -700
    [SerializeField]private float buttonPanelInDuration = 1.0f;
    [SerializeField]private Ease buttonPanelEaseIn;
    [SerializeField]private Ease buttonPanelEaseOut;

    [System.Serializable] public class ActionInfo{
        public string actionName;
        public Sprite btnImage;
    }

    public List<ActionInfo> actionInfo;
    public List<Image> actionPreview;
    // Start is called before the first frame update
    void Start()
    {
        OpenPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClosePanel(){
        buttonPanel.DOAnchorPosX(-1200,buttonPanelInDuration,true).SetEase(buttonPanelEaseOut);
    }
    public void OpenPanel(){
        buttonPanel.DOAnchorPosX(-700,buttonPanelInDuration,true).SetEase(buttonPanelEaseIn);

    }
    public void SetPreviewSprite(int index,int type){
        actionPreview[index].sprite = actionInfo[type].btnImage;
        actionPreview[index].enabled = true;
    }

    public void ResetPreviewSprite(){
        foreach(Image preview in actionPreview){
            preview.enabled = false;
        }
    }
    public void ExecutePreviewSprite(int index){
        actionPreview[index].enabled = false;
    }
}
