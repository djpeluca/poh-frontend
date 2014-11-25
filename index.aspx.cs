using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool isEnglish = true;
        if (!IsPostBack)
        {
            HttpRequest Request = HttpContext.Current.Request;
            string[] languages = Request.UserLanguages;
            if (languages != null)
            {
                if (languages[0] != null)
                {
                    if (languages[0].Contains("es"))
                    {
                        isEnglish = false;
                    }
                }
            }
            Literal1.Text = GetHtmlPage(isEnglish);
        }
    }
    private string GetHtmlPage(bool isEnglish)
    {
        string url = "http://www.projectsofhumanity.com/html/";
        string strResult;
        WebResponse objResponse;
        WebRequest objRequest;
        if (isEnglish)
        {
             objRequest = HttpWebRequest.Create(url + "index_en.html");
        }
        else
        {
             objRequest = HttpWebRequest.Create(url + "index_es.html");
        }
        
        objResponse = objRequest.GetResponse();
        using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
        {
            strResult = sr.ReadToEnd();
            sr.Close();
        }
        return strResult;
    }
}