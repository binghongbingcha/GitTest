namespace EcgViewPro
{
   public class ChineseJP
    {
        public string ChineseCap(string chineseStr)
        {
            string capstr = "";
            string chinaStr = "";
            for (int i = 0; i <= chineseStr.Length - 1; i++)
            {
                string charStr = chineseStr.Substring(i, 1);
                byte[] zw = System.Text.Encoding.Default.GetBytes(charStr);
                // 得到汉字符的字节数组 
                if (zw.Length == 2)
                {
                    int i1 = zw[0];
                    int i2 = zw[1];
                    long chineseStrInt = i1 * 256 + i2;

                    #region 参数
                    //table of the constant list 
                    // 'A';      //45217..45252 
                    // 'B';      //45253..45760 
                    // 'C';      //45761..46317 
                    // 'D';      //46318..46825 
                    // 'E';      //46826..47009 
                    // 'F';      //47010..47296 
                    // 'G';      //47297..47613 

                    // 'H';      //47614..48118 
                    // 'J';      //48119..49061 
                    // 'K';      //49062..49323 
                    // 'L';      //49324..49895 
                    // 'M';      //49896..50370 
                    // 'N';      //50371..50613 
                    // 'O';      //50614..50621 
                    // 'P';      //50622..50905 
                    // 'Q';      //50906..51386 

                    // 'R';      //51387..51445 
                    // 'S';      //51446..52217 
                    // 'T';      //52218..52697 
                    //没有U,V 
                    // 'W';      //52698..52979 
                    // 'X';      //52980..53640 
                    // 'Y';      //53689..54480 
                    // 'Z';      //54481..55289 

                    #endregion

                    #region 判断
                    if ((chineseStrInt >= 45217) && (chineseStrInt <= 45252))
                    {
                        chinaStr = "a";
                    }
                    else if ((chineseStrInt >= 45253) && (chineseStrInt <= 45760))
                    {
                        chinaStr = "b";
                    }
                    else if ((chineseStrInt >= 45761) && (chineseStrInt <= 46317))
                    {
                        chinaStr = "c";

                    }
                    else if ((chineseStrInt >= 46318) && (chineseStrInt <= 46825))
                    {
                        chinaStr = "d";
                    }
                    else if ((chineseStrInt >= 46826) && (chineseStrInt <= 47009))
                    {
                        chinaStr = "e";
                    }
                    else if ((chineseStrInt >= 47010) && (chineseStrInt <= 47296))
                    {
                        chinaStr = "f";
                    }
                    else if ((chineseStrInt >= 47297) && (chineseStrInt <= 47613))
                    {
                        chinaStr = "g";
                    }
                    else if ((chineseStrInt >= 47614) && (chineseStrInt <= 48118))
                    {

                        chinaStr = "h";
                    }

                    else if ((chineseStrInt >= 48119) && (chineseStrInt <= 49061))
                    {
                        chinaStr = "j";
                    }
                    else if ((chineseStrInt >= 49062) && (chineseStrInt <= 49323))
                    {
                        chinaStr = "k";
                    }
                    else if ((chineseStrInt >= 49324) && (chineseStrInt <= 49895))
                    {
                        chinaStr = "l";
                    }
                    else if ((chineseStrInt >= 49896) && (chineseStrInt <= 50370))
                    {
                        chinaStr = "m";
                    }

                    else if ((chineseStrInt >= 50371) && (chineseStrInt <= 50613))
                    {
                        chinaStr = "n";

                    }
                    else if ((chineseStrInt >= 50614) && (chineseStrInt <= 50621))
                    {
                        chinaStr = "o";
                    }
                    else if ((chineseStrInt >= 50622) && (chineseStrInt <= 50905))
                    {
                        chinaStr = "p";

                    }
                    else if ((chineseStrInt >= 50906) && (chineseStrInt <= 51386))
                    {
                        chinaStr = "q";

                    }

                    else if ((chineseStrInt >= 51387) && (chineseStrInt <= 51445))
                    {
                        chinaStr = "r";
                    }
                    else if ((chineseStrInt >= 51446) && (chineseStrInt <= 52217))
                    {
                        chinaStr = "s";
                    }
                    else if ((chineseStrInt >= 52218) && (chineseStrInt <= 52697))
                    {
                        chinaStr = "t";
                    }
                    else if ((chineseStrInt >= 52698) && (chineseStrInt <= 52979))
                    {
                        chinaStr = "w";
                    }
                    else if ((chineseStrInt >= 52980) && (chineseStrInt <= 53640))
                    {
                        chinaStr = "x";
                    }
                    else if ((chineseStrInt >= 53689) && (chineseStrInt <= 54480))
                    {
                        chinaStr = "y";
                    }
                    else if ((chineseStrInt >= 54481) && (chineseStrInt <= 55289))
                    {
                        chinaStr = "z";
                    }

                    #endregion

                    capstr = capstr + chinaStr;
                }
                else
                {
                    // Capstr = ChineseStr;
                    capstr += charStr;
                    // break;
                }
                // Capstr = Capstr + ChinaStr;
            }

            return capstr;

        } 
    }
}
