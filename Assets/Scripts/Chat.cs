using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour {

	public GameObject prefab;
	public static GameObject commentPrefab;
	public static List<GameObject> commentList;
	private static GameObject content;
	private static Scrollbar scroll;

	// Use this for initialization
	void Start () {
		commentPrefab = prefab;
		content = GetComponentInChildren<LayoutGroup> ().gameObject;
		scroll = GetComponentInChildren<Scrollbar> ();
		commentList = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void AddCommentToChat(string nome, string comentario) {
		GameObject cmt = (GameObject)Instantiate (commentPrefab, content.transform);
		CommentText txt = cmt.GetComponent<CommentText> ();
		txt.userName = nome;
		txt.textBody = comentario;

		commentList.Add (cmt);
		scroll.value = 0;
	}
}
