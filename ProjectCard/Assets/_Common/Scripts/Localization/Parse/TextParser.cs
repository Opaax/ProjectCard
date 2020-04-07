using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// important pour le lien avec google
using UnityEngine.Networking;
using UnityEditor;
using System;

// SUPER IMPORTANT : 
// IL FAUT LANCER LA FONCTION DL AU RUNTIME
// SINON LA COUROUTINE FONCTIONNE PAS

public class TextParser : MonoBehaviour
{
    // le trick se fait ici.
    // le script ne dl pas l'excel mais le converti directement en csv.
    public string linkReplace = "export?format=csv";

    // un peu malpropre ici, mais j'ai fais un array pour les différentes "feuilles" de l'excel

    // il faut créer un ficher csv et le mettre dans Resources/TextsAssets/
    // donc un string pour chaque lien à dl
    public string[] urls;
    // la fonction de dl ira chercher les données pour les mettre dans ce csv
    // donc aussi un test asset pour chaque lien à dl.
    public UnityEngine.Object[] targetAssets;

    // print les données dans la console au chargement ?
    public bool parsingDebug = false;

    public virtual void Awake()
    {
    // je le vire à l'awake, parce que je debug dans un bouton éditeur.
        parsingDebug = false;
        DownloadCSVs();
        // parser à l'awake pour pas avoir de probleme d'ordre d'exe.
        //ParseCSV();
    }

    #region parse
    public virtual void ParseCSV()
    {
        foreach (var targetAsset in targetAssets)
        {
            // le path de l'asst
            string fileName = targetAsset.name /*+ ".csv"*/;
            Debug.Log(fileName);
            // fetch l'asset
            TextAsset textAsset = Resources.Load<TextAsset>(targetAsset.name);

            // ici le plugin qui va permettre de parser.
            // 1er arg : le text brut // 2eme arg : la fonction qui va récupérer les données.
            fgCSVReader.LoadFromString(textAsset.text, new fgCSVReader.ReadLineDelegate(GetCell));
        }
    }

    public virtual void GetCell(int line_Index, List<string> line)
    {
        Debug.Log(String.Format("\n==> Line {0}, {1} column(s)", line_Index, line.Count));

        for (int i = 0; i < line.Count; i++)
        {
            Debug.Log(String.Format("Cell {0}: *{1}*", i, line[i]));
        }
    }
    #endregion


#if UNITY_EDITOR
    public void DownloadCSVs()
    {
        StartCoroutine(DownloadCSVsCoroutine());
    }
    IEnumerator DownloadCSVsCoroutine()
    {
        int i = 0;
        foreach (var targetAsset in targetAssets)
        {
            string url = urls[i];

            yield return DownloadCSV(url, targetAsset);

            ++i;
        }

        yield return new WaitForEndOfFrame();

        Debug.Log("FINISHED DOWNLOADING");

    }
    IEnumerator DownloadCSV(string tmpUrl, UnityEngine.Object asset)
    {
        tmpUrl = tmpUrl.Replace("edit", linkReplace);

        Debug.Log("Sending request fir " +asset.name + "...");

        float timeOut = Time.realtimeSinceStartup + 10f;

        UnityWebRequest www = UnityWebRequest.Get(tmpUrl);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError("Error when requesting CSV file (responseCode:" + www.responseCode + ")");
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);

            string filepath = AssetDatabase.GetAssetPath(asset);
            System.IO.File.WriteAllText(filepath, www.downloadHandler.text);
            Undo.RecordObject(asset, "Downloaded CSV from distant file");
            Debug.Log("finished downloading : " + asset.name);
            ParseCSV();
        }
    }
#endif
}
