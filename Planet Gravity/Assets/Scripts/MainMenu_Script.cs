using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Script : MonoBehaviour
{
    public GameObject bot;
    private Rigidbody2D rb;
    public GameObject transition;

    private void Start()
    {
        rb = bot.GetComponent<Rigidbody2D>();
    }
    public void StartGame()
    {
        StartCoroutine(StarTrans("PlayScene"));
    }

    public void ShopMenu()
    {
        StartCoroutine(StarTrans("ShopMenu"));
    }

    IEnumerator StarTrans(string name)
    {        
        rb.AddForce(Vector2.up * 500f, ForceMode2D.Force);
        yield return new WaitForSeconds(1f);
        transition.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(name);
    }
}
