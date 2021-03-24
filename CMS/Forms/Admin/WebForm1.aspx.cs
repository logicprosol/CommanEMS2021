using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Forms.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtans_Click(object sender, EventArgs e)
        {
            Label1.Text = "";
            int con = 0, vol = 0;
            con = Convert.ToInt32(txtcons.Text.Trim());
            vol = Convert.ToInt32(txtvowels.Text.Trim());
            
            char[] str = new char[con+vol];
            char[] str2 = new char[con + vol];
            int[] str1 = new int[con + vol];
            int[] str3 = new int[con + vol];
            char[] arrvol = {'a','e','i','o','u'};
            char[] arrcon = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y','z'};

            if (vol > 0)
            {
                for (int i = 0; i < (con + vol); i++)
                {
                    str[i] = 'a';
                    str1[i] = 'a';
                }
            }
            else
            {
                for (int i = 0; i < (con + vol); i++)
                {
                    str[i] = 'b';
                    str1[i] = 'b';
                }
            }

            str2 = str;
            str3 = str1;
            for (int i = 0; i < (con + vol); i++)
            {
                str = str2;
                str1 = str3;
                int z = 0;
                while (str[(con + vol) - (i + 1)] != 'z')
                {
                    if (Label1.Text != "")
                    {
                        for (int ic = 0; ic <= i; ic++)
                        {
                            for(int ch=0;ch<ic;ch++)
                            {
                                z = 0;
                                str1[(con + vol) - (ch + 1)] = 97;
                                str[(con + vol) - (ch + 1)] = 'a';
                            }
                            str1[(con + vol) - (ic + 1)] = str1[(con + vol) - (ic + 1)] + 1;
                            str[(con + vol) - (ic + 1)] = Convert.ToChar(str1[(con + vol) - (ic + 1)]);

                            if (str1[(con + vol) - (ic + 1)] != 123)
                            {
                                break;
                            }
                        }
                    }
                    string txt = "";
                    for (int j = 0; j < (con + vol); j++)
                    {
                        txt = txt + str[j];
                    }
                    Label1.Text = Label1.Text + "\n" + txt;
                }
            }
        }
    }
}