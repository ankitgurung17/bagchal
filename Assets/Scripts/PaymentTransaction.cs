using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PaymentTransaction : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField number, expirationMonth, expirationYear, cvv, firstName, lastName, orderId, amount, discountAmount;
    public Text log;
    public AudioSource CoinscollectingAudio;

    private void Start()
    {
        number.text = "4111111111111111";
        expirationYear.text = "2020";
        expirationMonth.text = "01";
        cvv.text = "123";

        firstName.text = "Daivd";
        lastName.text = "Yong";
        orderId.text = "1001";
        amount.text = "";
        discountAmount.text = "5";
    }

    public void SaleTransaction()
    {
       
        StartCoroutine(sendRequest());
    }

    IEnumerator sendRequest()
    {
        string host = "https://mybaghchaltest.herokuapp.com/saleorder";
        //adding parameter in address
        host += "?";
        host += "number=" + number.text.Trim();
        host += "&expirationMonth=" + expirationMonth.text.Trim();
        host += "&expirationYear=" + expirationYear.text.Trim();
        host += "&cvv=" + cvv.text.Trim();
        host += "&firstName=" + firstName.text.Trim();
        host += "&lastName=" + lastName.text.Trim();
        host += "&orderId=" + orderId.text.Trim();
        host += "&amount=" + amount.text.Trim();
        host += "&discountAmount=" + discountAmount.text.Trim();

        log.text = "processing...";

        UnityWebRequest www = UnityWebRequest.Get(host);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
            log.text = "Error";
        }
        else
        {
           
            //Show the result
            string source = www.downloadHandler.text;
            Debug.Log(source);

            Transaction transaction = JsonUtility.FromJson<Transaction>(source);
            if (transaction.success == "true")
            {
                Game.coins = Game.coins + 100;
                Player play = new Player();
                play.saveData();
                CoinscollectingAudio.Play();

                Debug.Log("..Transaction successful..");
                log.text = "..Transaction successful..";

            }
        }
    }
}
