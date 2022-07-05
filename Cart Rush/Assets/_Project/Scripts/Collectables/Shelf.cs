using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] List<Orange> oranges;
    private bool _playerIsInThisArea = false;

    public void GiveAnOrange()
    {
        if (oranges.Count != 0)
        {
            //�lk eleman� elimizde tutuyoruz. her defas�nda oranges[0] kullanmak yerine orange kullan�yoruz.

            Orange orange = oranges[0];
            player.CollectedOranges.Add(orange);
            oranges.Remove(orange);


            //OrangeStack transformunda parenti yap�yoruz.

            orange.transform.SetParent(player.OrangeStack);


            //Burada offset olu�turup, her orange�n OrangeStackteki positionunu d�zenliyoruz.

            Vector3 offset = new Vector3(0f, (player.OrangeCount * 0.4f), 0f);
            orange.transform.position = player.OrangeStack.position + offset;
            player.OrangeCount++; //Buradaki OrangeCount mant���, her orange�n vector3teki y eksenindeki yerini 0.5 kat� olarak hesaplam�� oluyor. 
        }
    }

    public void StopGivingOranges()
    {

    }

    public IEnumerator GiveOrangeWithDelay()
    {
        while (oranges.Count != 0 && _playerIsInThisArea == true)
        {
            GiveAnOrange();
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _playerIsInThisArea == false)
        {
            _playerIsInThisArea = true;
            StartCoroutine(GiveOrangeWithDelay());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && _playerIsInThisArea == true)
        {
            _playerIsInThisArea = false;
            StopCoroutine(GiveOrangeWithDelay());
        }
    }

}
