using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace parser
{
    class CurrentParser: IParser
    {
        char[] parsChar = { ',', '.', '$', ':', '/', '!', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        string blockClass = "article__middle article__middle_layout_redesign article__middle_theme_undefined article__middle_text-styling_redesign";
        string link = "https://zen.yandex.ru/media/alexniroba/kapitalizaciia-rynka-kriptovaliut-vpervye-prevysila-2-trln-chto-budet-dalshe-606b7bc79573694b24a7ce93";

        public string BlockClass
        {
            get { return blockClass; }
        }
        public string Link
        {
            get { return link; }
        }
        public void setting(string blockClass, string link)
        {
            this.blockClass = blockClass;
            this.link = link;
        }
        public Dictionary<string, int> chet(List<string> put)
        {
            Dictionary<string, int> res = new Dictionary<string, int>();

            foreach (string s in put)
            {
                if (!res.ContainsKey(s))
                    res.Add(s, 1);
                else
                {
                    res[s] += 1;
                }
            }

            return res;
        }
        
        public string pars()
        {
            List<string[]> allText = new List<string[]>();
            

            HtmlWeb ws = new HtmlWeb();
            ws.OverrideEncoding = Encoding.UTF8;
            HtmlDocument doc = ws.Load(link);
            foreach (HtmlNode block in doc.DocumentNode.SelectNodes("//div[@class='"+blockClass+"']"))
            {
                allText.Add(block.InnerText.Split(new char[] { ' ' }));
            }

            string[] mainText = allText[0];

            List<string> listRes = new List<string>();
            for (int j = 0; j < mainText.Length; j++)
            {
                listRes.Add(mainText[j]);
                foreach (char c in parsChar)
                {
                    List<string> b1 = new List<string>();
                    for (int i = 0; i < listRes.Count; i++)
                    {
                        string[] b2 = listRes[i].Split(new char[] { c });
                        listRes.RemoveAt(i);
                        foreach (string s in b2)
                            b1.Add(s);
                    }

                    foreach (string s in b1)
                        if (s != "")
                            listRes.Add(s);
                }
            }


            Dictionary<string, int> dictionaryRes = chet(listRes);

            var sort = dictionaryRes.OrderBy(u => u.Value);
            string res = "";
            foreach (KeyValuePair<string, int> keyValue in sort)
            {
                res += (keyValue.Value + " - " + keyValue.Key) + "\n";
            }
            return res;
        }

    }
}
