using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpWinPhone.Entities
{
    class Record
    {
        private static String CRYPTER = "Crypter";

        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int id { get; set; }
        public DateTime dateTime { get; set; }
        public String typeCrypt { get; set; }
        public String text { get; set; }
        public String password { get; set; }
        public String result { get; set; }

        //Empty contructor
        public Record()
        {    
        }
        //Contructor of Record
        public Record(String text, String password, String typeCrypt)
        {
            this.dateTime = DateTime.Now;
            this.text = text;
            this.password = password;
            this.typeCrypt = typeCrypt;
            this.result = encrypt(text, password, typeCrypt);

        }
        //encrypt text and password
        public String encrypt(String text, String password, String typeCrypt)
        {
            int paramCryp = 1;
            int pwi = 0, temp;
            string result = "";
            if (typeCrypt != CRYPTER)
            {
                paramCryp = -1;
            }
            
            text = text.ToUpper();
            password = password.ToUpper();
            foreach (char t in text)
            {
                if (t < 65) continue;
                temp = t - 65 + paramCryp * (password[pwi] - 65);
                if (temp < 0) temp += 26;
                result += Convert.ToChar(65 + (temp % 26));
                if (++pwi == password.Length) pwi = 0;
            }

            return result;
        }

    }

}
