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

	private static int atualiza;

	// Use this for initialization
	void Start () {
		commentPrefab = prefab;
		content = GetComponentInChildren<LayoutGroup> ().gameObject;
		scroll = GetComponentInChildren<Scrollbar> ();
		commentList = new List<GameObject> ();
		atualiza = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (atualiza > 0) {			// Serve para dar um delay de 2 updates para chamar a função AtualizaScroll
			if (--atualiza == 0)
				AtualizaScroll ();
		}
	}

	public static void AddCommentToChat(string nome, string comentario) {
		GameObject cmt = (GameObject)Instantiate (commentPrefab, content.transform);
		CommentText txt = cmt.GetComponent<CommentText> ();
		txt.userName = nome;
		txt.textBody = comentario;

		commentList.Add (cmt);

		atualiza = 2;
	}

	public static void AtualizaScroll() {
		scroll.value = 0;
	}
}
