using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TpWinPhone.Entities;
using TpWinPhone.Helpers;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour en savoir plus sur le modèle d’élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkID=390556

namespace TpWinPhone.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class ViewVigenere : PivotItem
    {
        private static string ERREUR = "Le text et le mot de passe sont obligatoires";
        private static string CRYPTER = "Crypter";
        private static string DECRYPTER = "Décrypter";
        public ViewVigenere()
		{
			InitializeComponent(); 
		}

        private void btn_crypter_Click(object sender, RoutedEventArgs e)
        {
            DatabaseHelperClass dbHelper;
            Button btn = (Button)sender;
            String typeCrypt;

            switch (btn.Name)
                {
                    case "btn_crypter":
                        typeCrypt = CRYPTER; break;
                    case "btn_decrypter":
                        typeCrypt = DECRYPTER; break;
                    default:
                        typeCrypt = ""; break;
                }
              
            if (txt_text.Text != "" & txt_password.Text != "" & typeCrypt!="" )
            {
                dbHelper = new DatabaseHelperClass();//Creating object for DatabaseHelperClass.cs from ViewModel/DatabaseHelperClass.cs  
                Record record = new Record(txt_text.Text, txt_password.Text, typeCrypt);
                dbHelper.Insert(record);
                txt_result.Text = record.result;
                //after add contact redirect to contact listbox page 
                //Frame.Navigate(typeof(ReadContactList));       
            }
            else
            {
                //await new MessageDialog(ERREUR).ShowAsync();
            } 

        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            txt_result.Text = "";
            txt_text.Text = "";
            txt_password.Text = "";
        }
    }
}
