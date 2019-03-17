using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class NetworkInput : MonoBehaviour {
	public static SocketIOComponent socket;
	private string userName;
	private string userEmail;
	private string userPass;
	public InputField nameInput;
	public InputField emailInput;
	public InputField passInput1;
	public InputField passInput2;
	public GameObject inputForm;
	public GameObject userList;
	public Text listText;
	public bool isVerified;
	
	
	
	// Use this for initialization
	void Start () {
		isVerified = false;
		socket = GetComponent<SocketIOComponent>();
		socket.On("connected", OnConnect);
		socket.On("hideform", OnHideForm);
		userList.SetActive(false);
	}
	
	private void OnHideForm(SocketIOEvent obj)
	{
		
		inputForm.SetActive(false);
		userList.SetActive(true);
		Debug.Log(obj.data["users"].list);
		
		foreach (JSONObject name in obj.data["users"].list)
		{
			listText.text += name["name"].str + "\n";
		}
	}
	
	private void OnConnect(SocketIOEvent obj)
	{
		Debug.Log("The server is connected.");
	}
	
	private void verifyPassword(){
		if(passInput1.text == passInput2.text){
			isVerified = true;
		} else {
			Debug.Log("Passwords did not match.");
		}
	}
	
	// Update is called once per frame
	public void GrabFormData () {
		verifyPassword();
		if(isVerified == true){
		userPass = passInput1.text;
		}
		userEmail = emailInput.text;
		userName = nameInput.text;
		Debug.Log(userName);
		Debug.Log(userEmail);
		Debug.Log(passInput1.text);
		JSONObject data = new JSONObject(JSONObject.Type.OBJECT);
		data.AddField("name", userName);
		data.AddField("email", userEmail);
		data.AddField("password", userPass);
		//Add other fields here
		socket.Emit("senddata", data);
	}
	
	public void PlayScene() {
		SceneManager.LoadScene("MyScene");
		Debug.Log("Playing Game");
	}
}
