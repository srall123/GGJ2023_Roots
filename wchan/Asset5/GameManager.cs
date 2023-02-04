using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public Text scoreText_player1;
	public Text scoreText_player2;
	GameObject root;
	GameObject[] player1s;
	GameObject[] player2s;
	float totalDistance_player1;
	float averageDistance_player1;
	float totalDistance_player2;
	float averageDistance_player2;
	public int scale;
	public Text draw;
	public Text winner1;
	public Text winner2;


	public void score_calculator(int player)
	{
		root = GameObject.FindGameObjectWithTag("Root");
		if (player == 1)
		{
			totalDistance_player1 = 0f;
			player1s = GameObject.FindGameObjectsWithTag("Player1");
			foreach (GameObject player1 in player1s)
			{
				totalDistance_player1 += Vector3.Distance(root.transform.position, player1.transform.position);
			}
			averageDistance_player1 = totalDistance_player1 / player1s.Length * scale;
			scoreText_player1.text = averageDistance_player1.ToString("0");
		}
		if (player == 2)
		{
			totalDistance_player2 = 0f;
			player2s = GameObject.FindGameObjectsWithTag("Player2");
			foreach (GameObject player2 in player2s)
			{
				totalDistance_player2 += Vector3.Distance(root.transform.position, player2.transform.position);
			}
			averageDistance_player2 = totalDistance_player2 / player2s.Length * scale;
			scoreText_player2.text = averageDistance_player2.ToString("0");

		}
	}

	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void EndGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		if (averageDistance_player1 == averageDistance_player2)
			draw.gameObject.SetActive(true);
		else if (averageDistance_player1 > averageDistance_player2)
			winner1.gameObject.SetActive(true);
		else
			winner2.gameObject.SetActive(true);
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

}
