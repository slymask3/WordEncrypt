using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordEncrypt
{
    class Encrypt
    {
        private String[] original = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private String[] altered = new String[10];

        private String NEWLINE;
        private String SPACE;

        public Encrypt(string keyword)
        {
            //altered = { "M", "/", "w", "\n", "l", "'", "(", "i", "@", "," };

            char[] chars = keyword.ToCharArray();

            int s = 0;
            int e = chars.Length - 1;
            int m;
            
            if(chars.Length >= 3) {
                m = chars.Length / 2;
            }
            else
            {
                m = chars.Length - 1;
            }

            //Console.Write(chars[e].ToString());
            //Console.Write(Int32.Parse(chars[e].ToString()));
            //Console.Write(Int32.Parse(chars[e].ToString()) + 2);
            //Console.Write((Int32.Parse(chars[e].ToString()) + 2) / 2);
            //Console.Write(Convert.ToInt32((Int32.Parse(chars[e].ToString()) + 2) / 2));
            //Console.Write(Convert.ToInt32((Int32.Parse(chars[e].ToString()) + 2) / 2) + 3);
            //Console.Write((Convert.ToInt32((Int32.Parse(chars[e].ToString()) + 2) / 2) + 3).ToString());
            //Console.Write(charToAscii((Convert.ToInt32((Int32.Parse(chars[e].ToString()) + 2) / 2) + 3).ToString()));
            /*
            altered[0] = asciiToChar((Convert.ToInt32((Int32.Parse(charToAscii(chars[e].ToString())) + 2) / 2) + 3).ToString());
            altered[1] = asciiToChar((Convert.ToInt32((Int32.Parse(charToAscii(chars[m].ToString())) + 2) / 2) + 1).ToString());
            altered[2] = asciiToChar((Convert.ToInt32((Int32.Parse(charToAscii(chars[m].ToString())) + 2) / 2) + 7).ToString());
            altered[3] = asciiToChar((Convert.ToInt32((Int32.Parse(charToAscii(chars[m].ToString())) + 2) / 2) + 5).ToString());
            altered[4] = asciiToChar((Convert.ToInt32((Int32.Parse(charToAscii(chars[s].ToString())) + 2) / 2) + 7).ToString());
            altered[5] = asciiToChar((Convert.ToInt32((Int32.Parse(charToAscii(chars[s].ToString())) + 2) / 2) + 2).ToString());
            altered[6] = asciiToChar((Convert.ToInt32((Int32.Parse(charToAscii(chars[s].ToString())) + 2) / 2) + 3).ToString());
            altered[7] = asciiToChar((Convert.ToInt32((Int32.Parse(charToAscii(chars[e].ToString())) + 2) / 2) + 0).ToString());
            altered[8] = asciiToChar((Convert.ToInt32((Int32.Parse(charToAscii(chars[e].ToString())) + 2) / 2) + 6).ToString());
            altered[9] = asciiToChar((Convert.ToInt32((Int32.Parse(charToAscii(chars[e].ToString())) + 2) / 2) + 9).ToString());
            */
            //NEWLINE = asciiToChar((Convert.ToInt32((Int32.Parse(charToAscii(chars[m].ToString())) + 2) / 2) + 0).ToString());
            //SPACE = asciiToChar((Convert.ToInt32((Int32.Parse(charToAscii(chars[e].ToString())) + 2) / 2) + 1).ToString());

            
            /*
            if(chars.Length <= 1) {
                altered[6] = "\n";
            }
            else if (chars.Length >= 2)
            {
                altered[2] = "\n";
            }
            else if (chars.Length >= 4)
            {
                altered[7] = "\n";
            }
            else if (chars.Length >= 6)
            {
                altered[0] = "\n";
            }*/

            //altered = { "M", "/", "w", "\n", "l", "'", "(", "i", "@", "," };

            //String s7 = charToAscii(chars[s]);
            /*
            altered[0] = asciiToChar((Int32.Parse(charToAscii("M")) + (Int32.Parse(charToAscii(chars[s].ToString())) / 10)).ToString());
            altered[1] = "/";
            altered[2] = "w";
            altered[3] = "\n";
            altered[4] = "l";
            altered[5] = "'";
            altered[6] = "(";
            altered[7] = "i";
            altered[8] = "@";
            altered[9] = ",";
            */
            /*
            altered[0] = chars[5].ToString();
            altered[1] = chars[9].ToString();
            altered[2] = chars[6].ToString();
            altered[3] = chars[3].ToString();
            altered[4] = chars[4].ToString();
            altered[5] = chars[8].ToString();
            altered[6] = chars[11].ToString();
            altered[7] = chars[0].ToString();
            altered[8] = chars[1].ToString();
            altered[9] = chars[10].ToString();

            NEWLINE = chars[7].ToString();
            SPACE = chars[2].ToString();
            */

            int all = 0;

            for (int i = 0; i < chars.Length; i++ )
            {
                all += Int32.Parse(charToAscii(chars[i].ToString()));
            }

            int avgAscii = all / chars.Length;
            String avgChar = asciiToChar(avgAscii.ToString());

            altered[0] = asciiToChar((avgAscii + 1).ToString());
            altered[1] = asciiToChar((avgAscii + 2).ToString());
            altered[2] = asciiToChar((avgAscii + 3).ToString());
            altered[3] = asciiToChar((avgAscii - 1).ToString());
            altered[4] = asciiToChar((avgAscii - 2).ToString());
            altered[5] = asciiToChar((avgAscii - 3).ToString());
            altered[6] = asciiToChar((avgAscii + 4).ToString());
            altered[7] = asciiToChar((avgAscii + 5).ToString());
            altered[8] = asciiToChar((avgAscii - 4).ToString());
            altered[9] = asciiToChar((avgAscii - 5).ToString());

            NEWLINE = asciiToChar((avgAscii + 6).ToString());
            SPACE = asciiToChar((avgAscii - 6).ToString());

            if (chars.Length <= 1)
            {
                altered[6] = "\n";
            }
            else if (chars.Length >= 2)
            {
                altered[2] = "\n";
            }
            else if (chars.Length >= 4)
            {
                altered[7] = "\n";
            }
            else if (chars.Length >= 6)
            {
                altered[0] = "\n";
            }
        }

        public String encrypt(String text)
        {
            try
            {
                String temp = "";

                char[] array = text.ToCharArray();
                String[] strings = new String[array.Length];

                for (int i = 0; i < array.Length; i++)
                {
                    if (Int32.Parse(charToAscii(array[i].ToString())) == 10)
                    {
                        strings[i] = NEWLINE;
                    }
                    else
                    {
                        strings[i] = (Int32.Parse(charToAscii(array[i].ToString())) * 9).ToString() + SPACE;
                        //temp += "{" + strings[i] + " " + array[i] + "} ";
                    }
                    temp += strings[i];
                }

                char[] tmpa = temp.ToCharArray();
                String tmp = "";

                for (int i = 0; i < tmpa.Length; i++)
                {
                    if (tmpa[i].ToString().Equals(NEWLINE) || tmpa[i].ToString().Equals(SPACE))
                    {
                        tmp += tmpa[i].ToString();
                    }
                    else
                    {
                        tmp += altered[Int32.Parse(tmpa[i].ToString())];
                    }
                }

                return tmp;
            } catch(Exception e) {
                return "Error Encrypting.";
            }
        }

        public String decrypt(String text)
        {
            try
            {

                //String temp = "";

                char[] tmpa = text.ToCharArray();
                String tmp = "";
                int count = 0;

                for (int i = 0; i < tmpa.Length; i++)
                {
                    if (tmpa[i].ToString().Equals(SPACE) || tmpa[i].ToString().Equals(NEWLINE))
                    {
                        count++;
                    }
                }

                String[] charsAscii = new String[count];

                int c2 = 0;

                for (int i = 0; i < tmpa.Length; i++)
                {
                    if (tmpa[i].ToString().Equals(NEWLINE))
                    {
                        tmp += "\n";

                        charsAscii[c2] += "+";
                        c2++;
                    }
                    else if (tmpa[i].ToString().Equals(SPACE))
                    {
                        tmp += SPACE;
                        c2++;
                    }
                    else
                    {
                        //tmp += altered[Int32.Parse(tmpa[i].ToString())];

                        if (tmpa[i].ToString() == altered[0])
                        {
                            tmp += original[0];
                            charsAscii[c2] += original[0];
                        }
                        else if (tmpa[i].ToString() == altered[1])
                        {
                            tmp += original[1];
                            charsAscii[c2] += original[1];
                        }
                        else if (tmpa[i].ToString() == altered[2])
                        {
                            tmp += original[2];
                            charsAscii[c2] += original[2];
                        }
                        else if (tmpa[i].ToString() == altered[3])
                        {
                            tmp += original[3];
                            charsAscii[c2] += original[3];
                        }
                        else if (tmpa[i].ToString() == altered[4])
                        {
                            tmp += original[4];
                            charsAscii[c2] += original[4];
                        }
                        else if (tmpa[i].ToString() == altered[5])
                        {
                            tmp += original[5];
                            charsAscii[c2] += original[5];
                        }
                        else if (tmpa[i].ToString() == altered[6])
                        {
                            tmp += original[6];
                            charsAscii[c2] += original[6];
                        }
                        else if (tmpa[i].ToString() == altered[7])
                        {
                            tmp += original[7];
                            charsAscii[c2] += original[7];
                        }
                        else if (tmpa[i].ToString() == altered[8])
                        {
                            tmp += original[8];
                            charsAscii[c2] += original[8];
                        }
                        else if (tmpa[i].ToString() == altered[9])
                        {
                            tmp += original[9];
                            charsAscii[c2] += original[9];
                        }

                    }
                }

                String final = "";
                String[] chars = new String[charsAscii.Length];

                for (int i = 0; i < charsAscii.Length; i++)
                {
                    if (charsAscii[i].Equals("+"))
                    {
                        chars[i] = "\n";
                    }
                    else
                    {
                        chars[i] = asciiToChar((Int32.Parse(charsAscii[i]) / 9).ToString());
                    }
                    final += chars[i];
                }

                return final;
            } catch(Exception e) {
                return "Error Decrypting.";
            }
        }

        private String charToAscii(String c)
        {
            return Encoding.ASCII.GetBytes(c)[0].ToString();
        }

        private String asciiToChar(String a)
        {
            return ((char)Int32.Parse(a)).ToString();
        }

        public String encrypt(String text, int amount)
        {
            String newText = text;

            for (int i = 0; i < amount; i++)
            {
                newText = encrypt(newText);
            }

            return newText;
        }

        public String decrypt(String text, int amount)
        {
            String newText = text;

            for (int i = 0; i < amount; i++)
            {
                newText = decrypt(newText);
            }
            
            return newText;
        }
    }
}
