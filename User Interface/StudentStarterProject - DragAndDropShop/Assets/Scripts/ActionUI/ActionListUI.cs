using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionListUI : MonoBehaviour
{
    public ActionList actionList;
    public ActionUI prefab;
    List<ActionUI> uis = new List<ActionUI>();
    LayoutGroup layoutGroup;
    ContentSizeFitter contentSizeFitter;
    // Start is called before the first frame update
    IEnumerator Start()
    {

        layoutGroup = GetComponent<LayoutGroup>();
        contentSizeFitter = GetComponent<ContentSizeFitter>();
        StartCoroutine(UpdateUI());

        actionList.onChanged.AddListener(() => { StartCoroutine(UpdateUI()); });
        yield return new WaitForEndOfFrame();
    }

    IEnumerator UpdateUI()
    {
        contentSizeFitter.enabled = true;
        layoutGroup.enabled = true;

        yield return new WaitForEndOfFrame();
        Player player = actionList.GetComponent<Player>();


        for (int i = 0; i < actionList.actions.Length; i++)
        {
            if (i >= uis.Count)
            {
                uis.Add(Instantiate(prefab, transform));
                uis[i].Init(player);
            }
            uis[i].gameObject.SetActive(true);
            uis[i].SetAction(actionList.actions[i]);
            uis[i].transform.SetAsLastSibling();
        }
        for (int i = actionList.actions.Length; i < uis.Count; i++)
            uis[i].gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();

        contentSizeFitter.enabled = false;
        layoutGroup.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
