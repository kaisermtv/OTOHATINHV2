using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

public class TVSFunction
{
    #region Declare objects
    public string RootUrl = "";
    #endregion

    #region method TVSFunction
    public TVSFunction()
    {
        //RootUrl = System.Configuration.ConfigurationSettings.AppSettings["ROOT"].ToString();
    } 
    #endregion

    #region method convertToUnSign2
    public static string convertToUnSign2(string s)
    {
        string stFormD = s.Normalize(NormalizationForm.FormD);
        StringBuilder sb = new StringBuilder();
        for (int ich = 0; ich < stFormD.Length; ich++)
        {
            System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
            if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
            {
                sb.Append(stFormD[ich]);
            }
        }
        sb = sb.Replace('Đ', 'D');
        sb = sb.Replace('đ', 'd');
        string strReturn = (sb.ToString().Normalize(NormalizationForm.FormD)).Replace("-", " ").Replace(" ", "-").Replace("\"", "").Replace("/", "-").Replace(",", "").Replace(":", "").Replace(".", "").Replace("?", "");
        return strReturn.Replace("/","").ToLower();
    } 
    #endregion

    
}