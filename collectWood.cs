using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectWood : MonoBehaviour {
	bool isClick=false;
	bool tmp;
	int times=0;
	public GameObject wood1;
	public Sprite[] wood; //prefab圖

	private Inventory inventory; //Inventory腳本
	public Animator BtnAni;

	// Start is called before the first frame update
	void Start() {
		inventory=GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>(); //找Inventory腳本下的變數
		BtnAni=GameObject.Find("backPackImg").GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update() {
		times++;

		if(times>10&& !isClick) {
			tmp= !tmp;
			transform.GetComponent<BoxCollider2D>().isTrigger=tmp;
			times=0;
		}

		if (Input.GetKeyDown("p")) 
		{
			for(int i=0; i<inventory.slot.Length; i++) {

				//判斷那個格子裡面有沒有東西
				if(inventory.isFull[i]==false&&inventory.isClickWood==false) {
					Instantiate(wood1, inventory.slot[i].transform, false); //把prefab的圖片放進去slot裡面
					inventory.isFull[i]=true;
					Destroy(this.gameObject); //刪掉object
					inventory.isClickWood=true;
					inventory.countClickWood++;
					BtnAni.SetTrigger("shake");
					BtnAni.SetTrigger("idle");
					break;
				}

				else if(inventory.isClickWood==true) {

					if(inventory.slot[i].transform.childCount>0) {
						if(inventory.slot[i].transform.GetChild(0).name=="wood1(Clone)") {
							if(inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite==wood1.transform.GetComponent<Image>().sprite&&inventory.countClickWood==1) {
								inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite=wood[0];
								Destroy(this.gameObject); //刪掉object
								inventory.countClickWood++;
								BtnAni.SetTrigger("shake");
								BtnAni.SetTrigger("idle");
								break;
							}

							switch (inventory.countClickWood) {
								case 2:
									inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite=wood[1];
								Destroy(this.gameObject); //刪掉object
								inventory.countClickWood++;
								BtnAni.SetTrigger("shake");
								BtnAni.SetTrigger("idle");
								break;
								case 3:
									inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite=wood[2];
								Destroy(this.gameObject); //刪掉object
								inventory.countClickWood++;
								BtnAni.SetTrigger("shake");
								BtnAni.SetTrigger("idle");
								break;
								case 4:
									inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite=wood[3];
								Destroy(this.gameObject); //刪掉object
								inventory.countClickWood++;
								BtnAni.SetTrigger("shake");
								BtnAni.SetTrigger("idle");
								break;
								case 5:
									inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite=wood[4];
								Destroy(this.gameObject); //刪掉object
								inventory.countClickWood++;
								BtnAni.SetTrigger("shake");
								BtnAni.SetTrigger("idle");
								break;
								// case 6:
								//     inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite=wood[5];
								//     Destroy(this.gameObject);//刪掉object
								//     inventory.countClickWood++;
								//     BtnAni.SetTrigger("shake");                
								//     BtnAni.SetTrigger("idle");
								//     break;  
								// case 7:
								//     inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite=wood[6];
								//     Destroy(this.gameObject);//刪掉object
								//     inventory.countClickWood++;
								//     BtnAni.SetTrigger("shake");                
								//     BtnAni.SetTrigger("idle");
								//     break; 
								// case 8:
								//     inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite=wood[7];
								//     Destroy(this.gameObject);//刪掉object
								//     inventory.countClickWood++;
								//     BtnAni.SetTrigger("shake");                
								//     BtnAni.SetTrigger("idle");
								//     break;        
								default:
									break;

							}
						}
					}
				}
			}
		}
		if(GameObject.Find("artisan").GetComponent<clickNPC>().woodnum==6)
		{
			GameObject.Find("boat").GetComponent<SpriteRenderer>().enabled=true;
			return;
		}

	}

	private void OnMouseDown() {
		GameObject.Find("artisan").GetComponent<clickNPC>().woodnum++;
		for(int i=0; i<inventory.slot.Length; i++) {
			//判斷那個格子裡面有沒有東西
			if(inventory.isFull[i]==false&&inventory.isClickWood==false) {
				Instantiate(wood1, inventory.slot[i].transform, false); //把prefab的圖片放進去slot裡面
				inventory.isFull[i]=true;
				inventory.isClickWood=true;
				inventory.countClickWood++;
				Destroy(this.gameObject); //刪掉object
				BtnAni.SetTrigger("shake");
				BtnAni.SetTrigger("idle");
				GameObject.Find("getInventoryEffect").GetComponent<AudioSource>().Play();

				break;
			}
			else if(inventory.isClickWood==true) {

				if(inventory.slot[i].transform.childCount>0) {
					if(inventory.slot[i].transform.GetChild(0).name=="wood1(Clone)") {
						if(inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite==wood1.transform.GetComponent<Image>().sprite&&inventory.countClickWood==1) {
							inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite=wood[0];
							inventory.countClickWood++;
							BtnAni.SetTrigger("shake");
							BtnAni.SetTrigger("idle");
							GameObject.Find("getInventoryEffect").GetComponent<AudioSource>().Play();

							Destroy(this.gameObject); //刪掉object

							break;
						}

						if(inventory.countClickWood==0&&inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite==null) {
							inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite=wood1.transform.GetComponent<Image>().sprite;
							inventory.countClickWood++;
							BtnAni.SetTrigger("shake");
							BtnAni.SetTrigger("idle");
							GameObject.Find("getInventoryEffect").GetComponent<AudioSource>().Play();

							inventory.slot[i].transform.GetChild(0).GetComponent<Image>().color=new Color(255, 255, 255, 1);

							Destroy(this.gameObject); //刪掉object
							break;

						}

						else if(inventory.countClickWood==1&&inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite !=null) {
							inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite=wood[1];
							// inventory.countClickWood++;
							BtnAni.SetTrigger("shake");
							BtnAni.SetTrigger("idle");
							GameObject.Find("getInventoryEffect").GetComponent<AudioSource>().Play();

							Destroy(this.gameObject); //刪掉object
							break;
						}

						switch (inventory.countClickWood) {
							case 2:
								inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite=wood[1];
							inventory.countClickWood++;
							BtnAni.SetTrigger("shake");
							BtnAni.SetTrigger("idle");
							GameObject.Find("getInventoryEffect").GetComponent<AudioSource>().Play();

							Destroy(this.gameObject); //刪掉object

							break;
							case 3:
								inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite=wood[2];
							inventory.countClickWood++;
							BtnAni.SetTrigger("shake");
							BtnAni.SetTrigger("idle");
							GameObject.Find("getInventoryEffect").GetComponent<AudioSource>().Play();

							Destroy(this.gameObject); //刪掉object

							break;
							case 4:
								inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite=wood[3];
							inventory.countClickWood++;
							BtnAni.SetTrigger("shake");
							BtnAni.SetTrigger("idle");
							GameObject.Find("getInventoryEffect").GetComponent<AudioSource>().Play();

							Destroy(this.gameObject); //刪掉object

							break;
							case 5:
								inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite=wood[4];
							inventory.countClickWood++;
							BtnAni.SetTrigger("shake");
							BtnAni.SetTrigger("idle");
							GameObject.Find("getInventoryEffect").GetComponent<AudioSource>().Play();

							Destroy(this.gameObject); //刪掉object

							break;
							case 6:
								inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite=wood[5];
							inventory.countClickWood++;
							BtnAni.SetTrigger("shake");
							BtnAni.SetTrigger("idle");
							GameObject.Find("getInventoryEffect").GetComponent<AudioSource>().Play();

							Destroy(this.gameObject); //刪掉object

							break;
							case 7:
								inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite=wood[6];
							inventory.countClickWood++;
							BtnAni.SetTrigger("shake");
							BtnAni.SetTrigger("idle");
							GameObject.Find("getInventoryEffect").GetComponent<AudioSource>().Play();

							Destroy(this.gameObject); //刪掉object

							break;
							case 8:
								inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite=wood[7];
							inventory.countClickWood++;
							BtnAni.SetTrigger("shake");
							BtnAni.SetTrigger("idle");
							GameObject.Find("getInventoryEffect").GetComponent<AudioSource>().Play();

							Destroy(this.gameObject); //刪掉object
							break;
							default:
								break;

						}
					}
				}
			}
		}

	}
}