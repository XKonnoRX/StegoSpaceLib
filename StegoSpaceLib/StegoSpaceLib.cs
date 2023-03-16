namespace StegoSpaceLib
{
    public class StegoSpaceLib
    {
        static private int[] dictionary = new int[] { 8288, 8289, 8290, 8291, 8292, 8298, 8299, 8300, 8301, 8302, 8303 };
        
        static public string Crypt(string messege, string text)
        {
            string cryptMessege = "";
            foreach (var symbol in messege.ToCharArray())
            {
                foreach (var digit in ((int)symbol).ToString())
                    cryptMessege += (char)dictionary[int.Parse(digit.ToString())];
                cryptMessege += (char)dictionary[10];
            }
            Console.WriteLine(cryptMessege.Length);
            string cryptText = "";
            int numerator = 0;
            foreach (var symbol in text)
            {
                if (symbol == ' ' && cryptMessege.Length > numerator)
                {
                    cryptText += cryptMessege[numerator];
                    numerator++;
                }
                else
                    cryptText += symbol;
            }
            return cryptText;
        }
        static public string Encrypt(string cryptedText)
        {
            string buffer = "";
            string encryptMessege = "";
            foreach (var symbol in cryptedText)
            {
                if (dictionary.Contains((int)symbol))
                {
                    if ((int)symbol == dictionary[10])
                    {
                        byte[] intBytes = BitConverter.GetBytes(int.Parse(buffer));
                        encryptMessege += (char)int.Parse(buffer);
                        buffer = "";
                    }
                    else
                        buffer += Array.IndexOf(dictionary, (int)symbol);
                }
            }
            return encryptMessege;
        }
    }
}