using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{

    public Button executeButton;
    public Button codeButton;
    public Button saveButton;
    public Button loadButton;
    public Button storeButton;
    public Button profButton;
    public Button tutorialNextButton;
    public InputField codeInputField;

    void Start()
    {
        executeButton.onClick.AddListener(ExecuteButtonListener);
        codeButton.onClick.AddListener(CodeButtonListener);
        saveButton.onClick.AddListener(SaveButtonListener);
        loadButton.onClick.AddListener(LoadButtonListener);
        storeButton.onClick.AddListener(StoreButtonListener);
        profButton.onClick.AddListener(ProfButtonListener);
        tutorialNextButton.onClick.AddListener(TutorialNextButtonListener);
        codeInputField.onValueChanged.AddListener(delegate {codeInputFieldValueListener();} );
    }

    void ExecuteButtonListener()
    {
        FindObjectOfType<AudioManager>().Play("UIButton01");
        FindObjectOfType<EditExecute>().ExecuteCodeOnCall();
        FindObjectOfType<PlayerController>().Move();
    }

    void CodeButtonListener()
    {
        FindObjectOfType<AudioManager>().Play("UIButton01");
        FindObjectOfType<EditExecute>().EditCodeOnCall();
    }

    void SaveButtonListener()
    {
        FindObjectOfType<AudioManager>().Play("UIButton01");
        FindObjectOfType<PlayerController>().SavePlayer();
    }

    void LoadButtonListener()
    {
        FindObjectOfType<AudioManager>().Play("UIButton01");
        FindObjectOfType<PlayerController>().LoadPlayer();
    }

    void StoreButtonListener()
    {
        FindObjectOfType<AudioManager>().Play("UIButton01");
        FindObjectOfType<EditExecute>().saveThis();
    }

    void ProfButtonListener()
    {
        FindObjectOfType<AudioManager>().Play("UIButton01");
        FindObjectOfType<tutorialcontrol>().ToggleTutorial();
    }

    void TutorialNextButtonListener()
    {
        FindObjectOfType<AudioManager>().Play("UIButton01");
        FindObjectOfType<tutorialcontrol>().nextHelp();
    }

    void codeInputFieldValueListener()
    {
        FindObjectOfType<EditExecute>().IsThereCode();
    }
}
